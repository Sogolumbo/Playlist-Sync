using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    class MusicLibrary
    {
        public MusicLibrary(List<string> playlistFiles, List<string> musicDirectories) : this(
            playlistFiles.Select(filepath => new PlaylistItem(filepath)).ToList(),
            musicDirectories)
        { }
        public MusicLibrary(List<PlaylistItem> playlists, List<string> musicDirectories)
        {
            Playlists = playlists;
            MusicFolders = musicDirectories;
            ItemFolders = ItemFoldersFromMusicDirectories();
        }
        List<PlaylistItem> Playlists { get; set; }
        List<string> MusicFolders { get; set; }
        List<MusicLibraryDirectory> ItemFolders { get; set; }


        public List<MusicLibraryDirectory> ItemFoldersFromMusicDirectories()
        {
            return ItemFoldersFromMusicFolders(MusicFolders, Playlists);
        }
        public List<MusicLibraryDirectory> ItemFoldersFromMusicFolders(List<string> musicFolders, List<PlaylistItem> playlists)
        {
            List<MusicLibraryDirectory> itemFolders = new List<MusicLibraryDirectory>();
            foreach (string musicFolder in musicFolders)
            {
                itemFolders.Add(new MusicLibraryDirectory(musicFolder));
            }
            foreach (PlaylistItem playlist in playlists)
            {

            }

            throw new NotImplementedException();//TODO
            return ItemFolders;
        }

        public void AddAllPlaylistItemsToMusicFolder(PlaylistItem playlist, MusicLibraryDirectory folder)
        {
            foreach (PlaylistItem item in playlist.Children)
            {
                AddAllPlaylistItemsToMusicFolder(item, playlist, folder);
            }
        }

        public void AddAllPlaylistItemsToMusicFolder(PlaylistItem item, PlaylistItem playlist, MusicLibraryDirectory folder)
        {
            if (item.FullPath.Length == folder.FullPath.Length)
            {
                if (item.FullPath == folder.FullPath)
                {
                    folder.PlaylistItems.Add(new PlaylistLink(item, playlist));
                    foreach (PlaylistItem child in item.Children)
                    {
                        switch (child.Type)
                        {
                            case PlaylistItemType.Folder:
                                foreach (var directory in folder.Directories)
                                {
                                    AddPlaylistItemToMusicFolder(item, playlist, directory);
                                }
                                break;
                            case PlaylistItemType.Song:
                                foreach (var file in folder.Files)
                                {
                                    if (file.FullPath.Length == child.FullPath.Length)
                                    {
                                        if (file.FullPath == item.FullPath)
                                        {
                                            folder.PlaylistItems.Add(new PlaylistLink(item, playlist));
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                else
                {
                    //TODO: can these cases be ignored?
                }
            }
            else if (item.FullPath.Length < folder.FullPath.Length)
            {
                foreach (PlaylistItem child in item.Children)
                {
                    AddAllPlaylistItemsToMusicFolder(child, playlist, folder);
                }
            }
            else
            {
                //TODO: can these cases be ignored?
            }
        }

        public void AddPlaylistItemToMusicFolder(PlaylistItem item, PlaylistItem playlist, MusicLibraryDirectory folder) //TODO delete
        {
            var itemPathLength = item.FullPath.Length;
            if (itemPathLength > folder.FullPath.Length)
            {
                switch (item.Type)
                {
                    case PlaylistItemType.Folder:
                        foreach (var directory in folder.Directories)
                        {
                            AddPlaylistItemToMusicFolder(item, playlist, directory);
                        }
                        break;
                    case PlaylistItemType.Song:
                        foreach (var file in folder.Files)
                        {
                            if (file.FullPath.Length == itemPathLength)
                            {
                                if (file.FullPath == item.FullPath)
                                {
                                    folder.PlaylistItems.Add(new PlaylistLink(item, playlist));
                                }
                            }
                        }
                        break;
                }
            }
            else if ((itemPathLength == folder.FullPath.Length) && (item.Type == PlaylistItemType.Folder))
            {
                if (item.FullPath == folder.FullPath)
                {
                    folder.PlaylistItems.Add(new PlaylistLink(item, playlist));
                }
            }
        }
    }
}
