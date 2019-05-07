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
                Children = GetChildren(playlistStructure, String.IsNullOrWhiteSpace(path) ? name : path + "\\" + name, this);
            }
            else
            {
                Type = PlaylistItemType.Song;
                GetMediaInfo();
            }
        }


        public List<PlaylistItem> Children { get; private set; }
        public PlaylistItem Parent { get; set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public PlaylistItemType Type { get; private set; }
        public string Title { get; set; } //TODO only set title privately
        public string Album { get; private set; }
        public NodeLink AlbumLink { get; set; }
        public string Artist { get; private set; }
        public NodeLink ArtistLink { get; set; }
        public int? Nr { get; set; }
        public string Genre { get; set; }

        public event EventHandler NameChanged;

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
        public void GetMediaInfo()
        {
            _mediaInfo.Open(System.IO.Path.Combine(Path, Name));
            Title = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Title");
            Album = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Album");
            Artist = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Performer");
            string number = _mediaInfo.Get(MediaInfo.StreamKind.General, 0, "Part_Number");
            Nr = String.IsNullOrWhiteSpace(number) ? null : (int?)int.Parse(number);
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

        private void AlbumNodeChanged(object sender, EventArgs e)
        {
            Album = ((PlaylistItem)sender).Name;
        }
        private void ArtistNodeChanged(object sender, EventArgs e)
        {
            Artist = ((PlaylistItem)sender).Name;
        }

        public void ChangeName(string name, bool renameFileOrFolder)
        {
            if (name != Name)
            {
                if (renameFileOrFolder)
                {
                    string oldPath = Path + "\\" + Name;
                    string newPath = Path + "\\" + name;
                    switch (Type)
                    {
                        case PlaylistItemType.Folder:
                            Directory.Move(oldPath, newPath);
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
                            node.ChangePath(System.IO.Path.Combine(Path, Name), false);
                        }
                        break;
                    case PlaylistItemType.Song:
                    default:
                        break;
                }
                NameChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public void ChangePath(string path, bool moveItem)
        {
            if (path != Path)
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
        }
        public void ChangeArtist(string artist, bool renameFileOrFolder)
        {
            if (artist != Artist)
            {
                if (renameFileOrFolder)
                {
                    throw new NotImplementedException("The Artist Tag of " + Name + " could not be changed from \"" + Artist + "\" to \"" + artist + "\" (@ " + Path + "."); //TODO edit Tag
                }
                Artist = artist;
            }
        }
        public void ChangeAlbum(string album, bool renameFileOrFolder)
        {
            if (album != Album)
            {
                if (renameFileOrFolder)
                {
                    throw new NotImplementedException("The Album Tag of " + Name + " could not be changed from \"" + Album + "\" to \"" + album + "\" (@ " + Path + "."); //TODO edit Tag
                }
                Album = album;
            }
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
