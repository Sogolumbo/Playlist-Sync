using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Playlist
{
    public class PlaylistItem
    {
        public PlaylistItem(List<PlaylistItem> children, string name, string path, PlaylistItemType type, PlaylistItem parent)
        {
            Children = children;
            Name = name;
            Path = path;
            Type = type;
            Parent = parent;
        }

        public PlaylistItem(string[] playlistLines, string playlistName, string playlistPath, PlaylistItem parent)
        {
            Type = PlaylistItemType.Playlist;
            ItemExists = true;
            Name = playlistName;
            Path = playlistPath;
            Parent = parent;

            List<List<string>> playlistStructure = new List<List<string>>(playlistLines.Length);

            for (int i = 0; i < playlistLines.Length; i++)
            {
                playlistStructure.Add(playlistLines[i].Split(System.IO.Path.DirectorySeparatorChar).ToList());
            }

            Children = GetChildren(playlistStructure, String.Empty, this);
        }
        public PlaylistItem(List<List<string>> playlistStructure, string name, string path, PlaylistItemType type, PlaylistItem parent)
        {
            Name = name;
            Type = type;
            Path = path;
            Parent = parent;
            if (playlistStructure.Count > 0 && playlistStructure[0].Count > 0)
            {
                Children = GetChildren(playlistStructure, FullPath, this);
            }
            else
            {
                Type = PlaylistItemType.Song;
            }
            GetItemInfo();
        }

        private string FullPath
        {
            get
            {
                return String.IsNullOrWhiteSpace(Path) ? Name : Path + "\\" + Name;
            }
        }

        public List<PlaylistItem> Children { get; private set; }
        public PlaylistItem Parent { get; set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public PlaylistItemType Type { get; private set; }
        public string Title { get; private set; }
        public string Album { get; private set; }
        public NodeLink AlbumLink { get; set; }
        public string Artist { get; private set; }
        public NodeLink ArtistLink { get; set; }
        public uint? Nr { get; private set; }
        public string Genre { get; set; }
        public bool ItemExists { get; private set; }

        public event EventHandler<NameChangedEventArgs> NameChanged;
        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;

        private MediaInfo.MediaInfo _mediaInfo = new MediaInfo.MediaInfo();

        private static List<PlaylistItem> GetChildren(List<List<string>> playlistStructure, string path, PlaylistItem parent)
        {
            Dictionary<string, List<List<string>>> children = new Dictionary<string, List<List<string>>>();

            foreach (List<string> songPathParts in playlistStructure)
            {
                if (songPathParts.Count > 0)
                {
                    string key = songPathParts[0];
                    songPathParts.RemoveAt(0);

                    if (children.ContainsKey(key))
                    {
                        children[key].Add(songPathParts);
                    }
                    else
                    {
                        children.Add(key, new List<List<string>> { songPathParts });
                    }
                }
            }
            return children.Select(node => new PlaylistItem(node.Value, node.Key, path, PlaylistItemType.Folder, parent)).ToList();
        }
        public void RescanMediaInfo(bool recursive)
        {
            if (recursive && Children != null)
            {
                foreach (var child in Children)
                {
                    child.RescanMediaInfo(true);
                }
            }
            GetItemInfo();
        }
        public void GetItemInfo()
        {
            switch (Type)
            {
                case PlaylistItemType.Song:
                    ItemExists = File.Exists(FullPath);
                    if (ItemExists == true)
                    {
                        TagLib.File tagFile = TagLib.File.Create(FullPath);
                        Title = tagFile.Tag.Title;
                        Album = tagFile.Tag.Album;
                        Artist = String.Join("; ", tagFile.Tag.Performers);
                        Nr = tagFile.Tag.Track;
                        Genre = String.Join("; ", tagFile.Tag.Genres);
                    }
                    CheckParentNodesForAlbumAndArtist();
                    break;
                case PlaylistItemType.Folder:
                    ItemExists = Directory.Exists(FullPath);
                    break;
            }
        }
        private void GetMediaInfoOld()
        {
            _mediaInfo.Open(System.IO.Path.Combine(Path, Name));
            Title = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Title");
            Album = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Album");
            Artist = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Performer");
            string number = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Part_Number");
            Nr = String.IsNullOrWhiteSpace(number) ? null : (uint?)uint.Parse(number);
            Genre = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Genre");
            _mediaInfo.Close();

            CheckParentNodesForAlbumAndArtist();
        }
        private void CheckParentNodesForAlbumAndArtist()
        {
            PlaylistItem ParentOfParent = Parent?.Parent;
            if (ParentOfParent != null && ParentOfParent.Name == Artist)
            {
                ArtistLink = NodeLink.ParentOfParent;
                ParentOfParent.NameChanged += ArtistNodeChanged;
            }
            else if (Parent != null && Parent.Name == Artist)
            {
                ArtistLink = NodeLink.Parent;
                Parent.NameChanged += ArtistNodeChanged;
            }

            if (Parent != null && Parent.Name == Album)
            {
                AlbumLink = NodeLink.Parent;
                Parent.NameChanged += AlbumNodeChanged;
            }
            else if (ParentOfParent != null && ParentOfParent.Name == Album)
            {
                AlbumLink = NodeLink.ParentOfParent;
                ParentOfParent.NameChanged += AlbumNodeChanged;
            }
        }

        private void AlbumNodeChanged(object sender, NameChangedEventArgs e)
        {
            ChangeAlbum(e.NewName, e.EditFilesAndFolder);
        }
        private void ArtistNodeChanged(object sender, NameChangedEventArgs e)
        {
            ChangeArtist(e.NewName, e.EditFilesAndFolder);
        }

        public bool ChangeName(string name, bool editFileOrFolder) //TODO add new form where this changes the name of this item in all playlists if editFileOrFolder is true
        {
            var nameChanged = name != Name;
            if (nameChanged)
            {
                if (editFileOrFolder)
                {
                    string oldPath = Path + "\\" + Name;
                    string newPath = Path + "\\" + name;
                    switch (Type)
                    {
                        case PlaylistItemType.Folder:
                            bool success = false;
                            do
                            {
                                try
                                {
                                    Directory.Move(oldPath, newPath);
                                    success = true;
                                }
                                catch (Exception ex)
                                {
                                    if (ex is UnauthorizedAccessException || ex is IOException)
                                    {
                                        success = false;
                                        UnauthorizedAccess?.Invoke(this, new UnauthorizedAccessEventArgs(oldPath, Type));
                                    }
                                    else
                                    {
                                        throw;
                                    }
                                }
                            }
                            while (!success);
                            break;
                        case PlaylistItemType.Playlist:
                        case PlaylistItemType.Song:
                            File.Move(oldPath, newPath);
                            break;
                    }
                }
                Name = name;
                switch (Type)
                {
                    case PlaylistItemType.Playlist:
                        break;
                    case PlaylistItemType.Folder:
                        foreach (PlaylistItem node in Children)
                        {
                            node.ChangePath(FullPath, false);
                        }
                        break;
                    case PlaylistItemType.Song:
                    default:
                        break;
                }
                NameChanged?.Invoke(this, new NameChangedEventArgs(name, editFileOrFolder));
            }
            return nameChanged;
        }
        public bool ChangePath(string path, bool moveItem)
        {
            var pathChanged = path != Path;
            if (pathChanged)
            {
                if (moveItem)
                {
                    throw new NotImplementedException();
                }
                Path = path;
                switch (Type)
                {
                    case PlaylistItemType.Playlist:
                        break;
                    case PlaylistItemType.Folder:
                        foreach (PlaylistItem node in Children)
                        {
                            node.ChangePath(System.IO.Path.Combine(Path, Name), false);

                        }
                        break;
                    case PlaylistItemType.Song:
                    default:
                        break;
                }
            }
            return pathChanged;
        }
        public bool ChangeArtist(string artist, bool editFileOrFolder)
        {
            bool artistChanged = artist != Artist;
            if (artistChanged)
            {
                Artist = artist;
                if (editFileOrFolder)
                {
                    string filepath = System.IO.Path.Combine(Path, Name);
                    ItemExists = File.Exists(filepath);
                    if (ItemExists == true)
                    {
                        var tagFile = TagLib.File.Create(filepath);
                        if (tagFile.Writeable)
                        {
                            tagFile.Tag.Performers = Artist.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                            tagFile.Save();
                        }
                        else
                        {
                            throw new Exception("TEST"); //TODO: message
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("The File " + filepath + " was not found. So the artist tag could not be changed.", filepath); //TODO maybe define own exception class
                    }
                    //TODO: remove    throw new NotImplementedException("The Artist Tag of " + Name + " could not be changed from \"" + Artist + "\" to \"" + artist + "\" (@ " + Path + "."); //TODO edit Tag
                }
            }
            return artistChanged;
        }
        public bool ChangeAlbum(string album, bool editFileOrFolder)
        {
            bool albumChanged = album != Album;
            if (albumChanged)
            {
                Album = album;
                if (editFileOrFolder)
                {
                    string filepath = System.IO.Path.Combine(Path, Name);
                    ItemExists = File.Exists(filepath);
                    if (ItemExists == true)
                    {
                        var tagFile = TagLib.File.Create(filepath);
                        tagFile.Tag.Album = Album;
                        tagFile.Save();
                    }
                    else
                    {
                        throw new FileNotFoundException("The File " + filepath + " was not found. So the album tag could not be changed.", filepath); //TODO maybe define own exception class
                    }
                    //TODO: remove   throw new NotImplementedException("The Album Tag of " + Name + " could not be changed from \"" + Album + "\" to \"" + album + "\" (@ " + Path + "."); //TODO edit Tag
                }
            }
            return albumChanged;
        }
        public bool ChangeTitle(string title, bool editFileOrFolder)
        {
            bool titleChanged = title != Title;
            if (titleChanged)
            {
                Title = title;
                if (editFileOrFolder)
                {
                    string filepath = System.IO.Path.Combine(Path, Name);
                    ItemExists = File.Exists(filepath);
                    if (ItemExists == true)
                    {
                        var tagFile = TagLib.File.Create(filepath);
                        tagFile.Tag.Title = Title;
                        tagFile.Save();
                    }
                    else
                    {
                        throw new FileNotFoundException("The File " + filepath + " was not found. So the title tag could not be changed.", filepath); //TODO maybe define own exception class
                    }
                    //TODO: remove   throw new NotImplementedException("The Album Tag of " + Name + " could not be changed from \"" + Album + "\" to \"" + album + "\" (@ " + Path + "."); //TODO edit Tag
                }
            }
            return titleChanged;
        }
        public bool ChangeNr(string number, bool editFileOrFolder)
        {
            return ChangeNr(uint.Parse(number), editFileOrFolder);
        }
        public bool ChangeNr(uint? number, bool editFileOrFolder)
        {
            bool nrChanged = number != Nr;
            if (nrChanged)
            {
                Nr = number;
                if (editFileOrFolder)
                {
                    string filepath = System.IO.Path.Combine(Path, Name);
                    ItemExists = File.Exists(filepath);
                    if (ItemExists == true)
                    {
                        var tagFile = TagLib.File.Create(filepath);
                        tagFile.Tag.Track = Nr.Value;
                        tagFile.Save();
                    }
                    else
                    {
                        throw new FileNotFoundException("The File " + filepath + " was not found. So the track number tag could not be changed.", filepath); //TODO maybe define own exception class
                    }
                    //TODO: remove   throw new NotImplementedException("The Album Tag of " + Name + " could not be changed from \"" + Album + "\" to \"" + album + "\" (@ " + Path + "."); //TODO edit Tag
                }
            }
            return nrChanged;
        }

        public string[] ToPlaylistLines()
        {
            List<string> result = new List<string>();
            AddLinesOfChildren(result);
            return result.ToArray();
        }

        public void AddLinesOfChildren(List<string> result)
        {
            foreach (PlaylistItem item in Children)
            {
                if (item.Type == PlaylistItemType.Song)
                {
                    result.Add(item.Path + "\\" + item.Name);
                }
                else
                {
                    item.AddLinesOfChildren(result);
                }
            }
        }

        public class UnauthorizedAccessEventArgs : EventArgs
        {
            public UnauthorizedAccessEventArgs(string itemPath, PlaylistItemType type) : base()
            {
                ItemPath = itemPath;
                Type = type;
            }
            public string ItemPath { get; set; }
            public PlaylistItemType Type { get; set; }
            public override string ToString()
            {
                return "The " + Type.ToString() + " at " + ItemPath + " can not be moved/renamed. Please close the open files/directories!";
            }
        }
        public class NameChangedEventArgs : EventArgs
        {
            public NameChangedEventArgs(string newName, bool editFilesAndFolders) : base()
            {
                NewName = newName;
                EditFilesAndFolder = editFilesAndFolders;
            }
            public string NewName { get; set; }
            public bool EditFilesAndFolder { get; set; }
        }
    }

    public enum PlaylistItemType
    {
        Song,
        Folder,
        Playlist
    }

    public enum NodeLink
    {
        None,
        Parent,
        ParentOfParent
    }
}
