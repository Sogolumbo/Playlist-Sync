using System;
using System.Collections.Generic;
using System.IO;

namespace Playlist
{
    public class MusicLibraryItem
    {
        public string Name { get; set; }
        public string DirectoryPath { get; set; }
        public string FullPath
        {
            get
            {
                return String.IsNullOrWhiteSpace(this.DirectoryPath) ? Name : DirectoryPath + "\\" + Name;
            }
            set
            {
                Name = Path.GetFileName(value);
                DirectoryPath = value.Replace("\\" + Name, "");
            }
        }
        public MusicLibraryDirectory Parent { get; set; }
        public List<PlaylistLink> PlaylistItems { get; set; }
    }

    public struct PlaylistLink
    {
        public PlaylistLink(PlaylistItem item, PlaylistItem playlist)
        {
            Item = item;
            Playlist = playlist;
        }
        public PlaylistItem Item;
        public PlaylistItem Playlist;
    }
}
