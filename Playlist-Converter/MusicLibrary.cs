using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    class MusicLibrary
    {
        public MusicLibrary(List<PlaylistItem> playlists, List<string> musicFolders)
        {
            Playlists = playlists;
            MusicFolders = musicFolders;
            ItemFolders = ItemFoldersFromMusicFolders();
        }
        List<PlaylistItem> Playlists { get; set; }
        List<string> MusicFolders { get; set; }
        List<MusicLibraryItem> ItemFolders { get; set; }


        public List<MusicLibraryItem> ItemFoldersFromMusicFolders()
        {
            return ItemFoldersFromMusicFolders(MusicFolders);
        }
        public List<MusicLibraryItem> ItemFoldersFromMusicFolders(List<string> musicFolders)
        {
            List<MusicLibraryItem> IitemFolders = new List<MusicLibraryItem>();
            throw new NotImplementedException();//TODO
            return ItemFolders;
        }
    }

    class MusicLibraryItem
    {
        public List<Dictionary<PlaylistItem, PlaylistItem>> playlistItems { get; set; }
        public List<MusicLibraryItem> Children { get; set; }
    }
}
