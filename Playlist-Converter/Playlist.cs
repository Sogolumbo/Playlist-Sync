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
        public PlaylistItem(string filepath, bool collectItemInfo) : this(
            File.ReadAllLines(filepath),
            System.IO.Path.GetFileName(filepath),
            filepath.Replace("\\" + System.IO.Path.GetFileName(filepath), ""),
            null,
            collectItemInfo)
        { }
        public PlaylistItem(string[] playlistLines, string playlistName, string playlistPath, PlaylistItem parent, bool collectItemInfo)
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

            Children = GetChildren(playlistStructure, String.Empty, this, collectItemInfo);
        }
        public PlaylistItem(List<PlaylistItem> children, string name, string path, PlaylistItemType type, PlaylistItem parent)
        {
            Children = children;
            Name = name;
            Path = path;
            Type = type;
            Parent = parent;
        }
        public PlaylistItem(List<List<string>> playlistStructure, string name, string path, PlaylistItemType type, PlaylistItem parent, bool collectItemInfo)
        {
            Name = name;
            Type = type;
            Path = path;
            Parent = parent;
            if (playlistStructure.Count > 0 && playlistStructure[0].Count > 0)
            {
                Children = GetChildren(playlistStructure, FullPath, this, collectItemInfo);
            }
            else
            {
                Type = PlaylistItemType.Song;
            }
            if (collectItemInfo)
            {
                GetItemInfo();
            }
        }


        #region Props and Vars
        public List<PlaylistItem> Children { get; private set; }
        public PlaylistItem Parent { get; set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public PlaylistItemType Type { get; private set; }
        public bool ItemExists { get; private set; }
        public NodeLink AlbumLink { get; set; }
        public NodeLink ArtistLink { get; set; }
        public AudioFileTag Tag { get; private set; }

        public event EventHandler<NameChangedEventArgs> NameChanged;
        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;
        #endregion


        #region functions
        public string FullPath
        {
            get
            {
                return String.IsNullOrWhiteSpace(Path) ? Name : Path + "\\" + Name;
            }
        }
        public override string ToString()
        {
            return Name;
        }
        private static List<PlaylistItem> GetChildren(List<List<string>> playlistStructure, string path, PlaylistItem parent, bool collectItemInfo)
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
            return children.Select(node => new PlaylistItem(node.Value, node.Key, path, PlaylistItemType.Folder, parent, collectItemInfo)).ToList();
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
                        Tag = new AudioFileTag(FullPath);
                    }
                    else
                    {
                        Tag = new AudioFileTag();
                    }
                    CheckParentNodesForAlbumAndArtist();
                    break;
                case PlaylistItemType.Folder:
                    ItemExists = Directory.Exists(FullPath);
                    break;
            }
        }
        private void CheckParentNodesForAlbumAndArtist()
        {
            if (Tag != null)
            {
                PlaylistItem ParentOfParent = Parent?.Parent;
                if (ParentOfParent != null && ParentOfParent.Name == Tag.Artist)
                {
                    ArtistLink = NodeLink.ParentOfParent;
                    ParentOfParent.NameChanged += ArtistNodeChanged;
                }
                else if (Parent != null && Parent.Name == Tag.Artist)
                {
                    ArtistLink = NodeLink.Parent;
                    Parent.NameChanged += ArtistNodeChanged;
                }
                if (Parent != null && Parent.Name == Tag.Album)
                {
                    AlbumLink = NodeLink.Parent;
                    Parent.NameChanged += AlbumNodeChanged;
                }
                else if (ParentOfParent != null && ParentOfParent.Name == Tag.Album)
                {
                    AlbumLink = NodeLink.ParentOfParent;
                    ParentOfParent.NameChanged += AlbumNodeChanged;
                }
            }
            else
            {
                ArtistLink = NodeLink.None;
                AlbumLink = NodeLink.None;
                if (Parent != null)
                {
                    Parent.NameChanged -= AlbumNodeChanged;
                    Parent.NameChanged -= ArtistNodeChanged;
                }
                if (Parent.Parent != null)
                {
                    Parent.Parent.NameChanged -= AlbumNodeChanged;
                    Parent.Parent.NameChanged -= ArtistNodeChanged;
                }
            }
        }
        #endregion

        #region changes
        private void AlbumNodeChanged(object sender, NameChangedEventArgs e)
        {
            ChangeAlbum(e.NewName, e.EditFilesAndFolder);
        }
        private void ArtistNodeChanged(object sender, NameChangedEventArgs e)
        {
            ChangeArtist(e.NewName, e.EditFilesAndFolder);
        }

        public bool ChangeName(string name, bool editFileOrFolder)
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
                            bool cancel = false;
                            do
                            {
                                try
                                {
                                    Directory.Move(oldPath, newPath);
                                    success = true;
                                }
                                catch (Exception ex)
                                {
                                    if ((ex is UnauthorizedAccessException || ex is IOException) && UnauthorizedAccess != null)
                                    {
                                        success = false;
                                        UnauthorizedAccessEventArgs unauthorizedAccessEventArgs = new UnauthorizedAccessEventArgs(oldPath, Type, ex);
                                        UnauthorizedAccess?.Invoke(this, unauthorizedAccessEventArgs);
                                        cancel = unauthorizedAccessEventArgs.Cancel;
                                    }
                                    else
                                    {
                                        throw;
                                    }
                                }
                            }
                            while (!(success || cancel));
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
                    case PlaylistItemType.Song:
                        if (File.Exists(FullPath))
                        {
                            Tag.FilePath = FullPath;
                        }
                        break;
                    case PlaylistItemType.Folder:
                        foreach (PlaylistItem node in Children)
                        {
                            node.ChangePath(FullPath, false);
                        }
                        break;
                    case PlaylistItemType.Playlist:
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
                    var oldPath = Path;
                    var newPath = path;

                    throw new NotImplementedException();
                }
                Path = path;
                switch (Type)
                {
                    case PlaylistItemType.Song:
                        if (Tag != null && !Tag.Empty)
                        {
                            Tag.FilePath = FullPath;
                        }
                        break;
                    case PlaylistItemType.Folder:
                        foreach (PlaylistItem node in Children)
                        {
                            node.ChangePath(System.IO.Path.Combine(Path, Name), false);
                        }
                        break;
                    case PlaylistItemType.Playlist:
                    default:
                        break;
                }
            }
            return pathChanged;
        }

        public bool ChangeArtist(string artist, bool editFileOrFolder)
        {
            bool artistChanged = artist != Tag.Artist;
            if (artistChanged)
            {
                if (editFileOrFolder)
                {
                    if (File.Exists(FullPath) == false)
                    {
                        throw new FileNotFoundException("The File " + FullPath + " was not found. So the artist tag could not be changed.", FullPath); //TODO maybe define own exception class
                    }
                    Tag.Artist = artist;
                }
            }
            return artistChanged;
        }
        public bool ChangeAlbum(string album, bool editFileOrFolder)
        {
            bool albumChanged = album != Tag.Album;
            if (albumChanged)
            {
                if (editFileOrFolder)
                {
                    Tag.Album = album;
                    if (File.Exists(FullPath) == false)
                    {
                        throw new FileNotFoundException("The File " + FullPath + " was not found. So the album tag could not be changed.", FullPath); //TODO maybe define own exception class
                    }
                }
            }
            return albumChanged && editFileOrFolder;
        }
        public bool ChangeTitle(string title, bool editFileOrFolder)
        {
            bool titleChanged = title != Tag.Title;
            if (titleChanged)
            {
                if (File.Exists(FullPath) == false)
                {
                    throw new FileNotFoundException("The File " + FullPath + " was not found. So the track number tag could not be changed.", FullPath); //TODO maybe define own exception class
                }
                if (editFileOrFolder)
                {
                    Tag.Title = title;
                }
            }
            return titleChanged && editFileOrFolder;

        }
        public bool ChangeNr(string number, bool editFileOrFolder)
        {
            return ChangeNr(uint.Parse(number), editFileOrFolder);
        }
        public bool ChangeNr(uint? number, bool editFileOrFolder)
        {
            bool nrChanged = number != Tag.Nr;
            if (nrChanged && editFileOrFolder)
            {
                if (File.Exists(FullPath) == false)
                {
                    throw new FileNotFoundException("The File " + FullPath + " was not found. So the track number tag could not be changed.", FullPath); //TODO maybe define own exception class
                }
                Tag.Nr = number;
            }
            return nrChanged && editFileOrFolder;
        }
        #endregion

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
    public class UnauthorizedAccessEventArgs : EventArgs
    {
        public UnauthorizedAccessEventArgs(string itemPath, PlaylistItemType type, Exception originalException) : base()
        {
            ItemPath = itemPath;
            Type = type;
            OriginalMessage = originalException.Message;
            OriginalException = originalException;
        }
        public string ItemPath { get; private set; }
        public PlaylistItemType Type { get; private set; }
        public Exception OriginalException { get; private set; }
        public string OriginalMessage { get; private set; }
        public override string ToString()
        {
            return "The " + Type.ToString() + " at " + ItemPath + " can not be moved/renamed. Please close the open files/directories! \nOriginal error message: " + OriginalMessage;
        }
        public bool Cancel { get; set; }
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