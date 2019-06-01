using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class MusicLibrary
    {
        public MusicLibrary(List<string> playlistFiles, List<string> musicDirectories) : this(
            playlistFiles.Select(filepath => new PlaylistItem(filepath, false)).ToList(),
            musicDirectories)
        {
            PlaylistFiles = playlistFiles;
        }
        public MusicLibrary(List<PlaylistItem> playlists, List<string> musicDirectories)
        {
            musicDirectories.Sort();

            Playlists = playlists;
            MusicFolders = musicDirectories;
            ItemFolders = ItemFoldersFromMusicDirectories();
        }

        public List<PlaylistItem> Playlists { get; set; }
        public List<string> PlaylistFiles { get; set; }
        public List<string> MusicFolders { get; set; }
        public List<MusicLibraryDirectory> ItemFolders { get; set; }

        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;


        public List<MusicLibraryDirectory> ItemFoldersFromMusicDirectories()
        {
            return ItemFoldersFromMusicFolders(MusicFolders, Playlists);
        }
        public List<MusicLibraryDirectory> ItemFoldersFromMusicFolders(List<string> musicFolders, List<PlaylistItem> playlists)
        {
            List<MusicLibraryDirectory> itemFolders = new List<MusicLibraryDirectory>();
            foreach (string musicFolder in musicFolders)
            {
                var dir = new MusicLibraryDirectory(musicFolder, null);
                dir.UnauthorizedAccess += Dir_UnauthorizedAccess;
                itemFolders.Add(dir);
            }
            //TODO Add PlaylistItems that don't exist
            AddAllPlaylistItemsToMusicFolder(playlists, itemFolders);
            foreach (PlaylistItem playlist in playlists)
            {
                foreach (MusicLibraryDirectory folder in itemFolders)
                {
                    AddAllPlaylistItemsToMusicFolder(playlist, folder);
                }
            }
            return itemFolders;
        }

        #region new 

        private void AddAllPlaylistItemsToMusicFolder(List<PlaylistItem> playlists, List<MusicLibraryDirectory> itemFolders) //TODO only accepts non-empty elements in both lists. Both Lists must be sorted
        {
            HashSet<string> ignoredPlaylistItems = new HashSet<string>();

            ///Setup indices
            List<PlaylistIndex> playlistIndices = new List<PlaylistIndex>(playlists.Count);
            Stack<Index> itemFolderIndex = new Stack<Index>();

            itemFolderIndex.Push(new Index(0, itemFolders.ToList<object>()));
            for (int i = 0; i < playlists.Count; i++)
            {
                var children = playlists[i].Children;
                if (children != null && children.Count > 0)
                {
                    var stack = new Stack<Index>();
                    stack.Push(new Index(0, children.ToList<object>()));
                    playlistIndices.Add(new PlaylistIndex(stack, playlists[i]));
                }
                else
                {
                    ignoredPlaylistItems.Add(playlists[i].FullPath);
                }
            }


            bool finished = false;

            /// Ignore top level playlist items (e.g. "C:", "user", ...)
            var topLibraryItemLength = TopLibraryItem(itemFolderIndex).FullPath.Length;
            foreach (PlaylistIndex plIndex in playlistIndices)
            {
                while (TopPlaylistItem(plIndex).FullPath.Length < topLibraryItemLength)
                {
                    ignoredPlaylistItems.Add(TopPlaylistItem(plIndex).FullPath);
                    List<PlaylistItem> children = TopPlaylistItem(plIndex).Children;
                    if (children != null && children.Count > 0)
                    {
                        plIndex.Stack.Push(new Index(0, children.ToList<object>()));
                    }
                    else
                    {
                        var StackEmpty = !IncrementIndex(plIndex.Stack);
                        if (StackEmpty)
                        {
                            playlistIndices.Remove(plIndex);
                        }
                    }
                }
            }

            while (!finished)
            {
                foreach (var stack in playlistIndices)
                {
                    //TODO: Add items and increment playlist indices to match library items
                    while (false)
                    {

                    }
                }
                //TODO: increment library index

                finished = true; //TODO all indices at the end
            }


        }

        private PlaylistItem TopPlaylistItem(PlaylistIndex playlistIndex)
        {
            return TopPlaylistItem(playlistIndex.Stack);
        }
        private PlaylistItem TopPlaylistItem(Stack<Index> stack)
        {
            return stack.Peek().Node as PlaylistItem;
        }
        private MusicLibraryItem TopLibraryItem(Stack<Index> stack)
        {
            return stack.Peek().Node as MusicLibraryItem;
        }
        private bool IncrementIndex(Stack<Index> stack)
        {
            var TopIndex = stack.Peek();
            if (TopIndex.Number + 1 < TopIndex.List.Count)
            {
                TopIndex.Number++;
                return true;
            }
            else if (stack.Count >= 2)
            {
                stack.Pop();
                return IncrementIndex(stack);
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void Dir_UnauthorizedAccess(object sender, UnauthorizedAccessEventArgs e)
        {
            if (UnauthorizedAccess != null)
            {
                UnauthorizedAccess.Invoke(sender, e);
            }
            else
            {
                throw e.OriginalException;
            }
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
                                    AddAllPlaylistItemsToMusicFolder(child, playlist, directory as MusicLibraryDirectory);
                                }
                                break;
                            case PlaylistItemType.Song:
                                foreach (var file in folder.Files)
                                {
                                    if (file.FullPath.Length == child.FullPath.Length)
                                    {
                                        if (file.FullPath == child.FullPath)
                                        {
                                            file.PlaylistItems.Add(new PlaylistLink(child, playlist));
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
            else if ((item.FullPath.Length < folder.FullPath.Length) && (item.Children != null))
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

        //TODO
        //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playlistIndex"></param>
        /// <param name="libraryItem"></param>
        /// <returns>False if playlistItem was missing in the library. True else.</returns>
        bool AddPlaylistItem(PlaylistIndex playlistIndex, MusicLibraryItem libraryItem)
        {
            var plItem = TopPlaylistItem(playlistIndex);
            int comparisonValue = plItem.FullPath.CompareTo(libraryItem.FullPath);
            switch (comparisonValue)
            {
                case 0: //strings are equal
                    libraryItem.PlaylistItems.Add(new PlaylistLink(plItem, playlistIndex.Playlist));
                    return true;

                case -1: //playlist item preceeds library item
                    //this playlist item is missing in the library item
                    //TODO check which cases end up here
                    var folder = libraryItem.Parent as MusicLibraryDirectory;
                    var missingElement = new MusicLibraryMissingElement(plItem.FullPath, new PlaylistLink(plItem, playlistIndex.Playlist));
                    missingElement.Found += MissingElement_Found;
                    switch (plItem.Type)
                    {
                        case PlaylistItemType.Song:
                            folder.Files.Add(missingElement);
                            break;
                        case PlaylistItemType.Folder:
                            folder.Directories.Add(missingElement);
                            break;
                    }
                    /*
                    foreach (PlaylistItem child in plItem.Children)
                    {
                        switch (child.Type)
                        {
                            case PlaylistItemType.Folder:
                                foreach (var directory in libraryItem.Directories)
                                {
                                    AddAllPlaylistItemsToMusicFolder(child, playlist, directory);
                                }
                                break;
                            case PlaylistItemType.Song:
                                foreach (var file in libraryItem.Files)
                                {
                                    if (file.FullPath.Length == child.FullPath.Length)
                                    {
                                        if (file.FullPath == child.FullPath)
                                        {
                                            file.PlaylistItems.Add(new PlaylistLink(child, playlist));
                                        }
                                    }
                                }
                                break;
                        }
                    }*/
                    return false;
                case 1: //playlist item follows library item
                    return true;
                default:
                    throw new NotImplementedException("Comparison value unexpected: " + comparisonValue);
            }
            //elseif
            if ((plItem.FullPath.Length < libraryItem.FullPath.Length) && (plItem.Children != null))
            {
            }
        }

        private void MissingElement_Found(object sender, EventArgs e)
        {
            throw new NotImplementedException("MissingElement_Found not implemented. " + (sender as MusicLibraryMissingElement).FullPath);
        }

        ///
    }
}