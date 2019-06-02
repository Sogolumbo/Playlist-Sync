﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            AddAllPlaylistItemsToLibraryFolders(playlists, itemFolders);
            return itemFolders;
        }

        #region new 

        private void AddAllPlaylistItemsToLibraryFolders(List<PlaylistItem> playlists, List<MusicLibraryDirectory> itemFolders) //TODO only accepts non-empty elements in both lists. Both Lists must be sorted
        {
            HashSet<PlaylistItem> ignoredPlaylistItems = new HashSet<PlaylistItem>();

            ///Setup indices
            List<PlaylistIndex> playlistIndices = new List<PlaylistIndex>(playlists.Count);
            Stack<Index> libraryIndex = new Stack<Index>();

            libraryIndex.Push(new Index(0, itemFolders.ToList<object>()));
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
                    ignoredPlaylistItems.Add(playlists[i]);
                }
            }

            /// Ignore top level playlist items (e.g. "C:", "user", ...)
            var topLibraryItemLength = TopLibraryItem(libraryIndex).FullPath.Length;
            foreach (PlaylistIndex plIndex in playlistIndices)
            {
                while (TopPlaylistItem(plIndex).FullPath.Length < topLibraryItemLength)
                {
                    ignoredPlaylistItems.Add(TopPlaylistItem(plIndex));
                    List<PlaylistItem> children = TopPlaylistItem(plIndex).Children;
                    if (children != null && children.Count > 0)
                    {
                        plIndex.Stack.Push(new Index(0, children.ToList<object>()));
                    }
                    else
                    {
                        IncrementIndexAndRemoveIndexIfStackEmpty(plIndex, playlistIndices);
                    }
                }
            }

            bool libraryFinished = false;
            //TODO remove debugging tools
            int loopCounter = 0;
            int loopCounterDecrement = 0;
            StringBuilder history = new StringBuilder(); 

            while (!(libraryFinished && playlistIndices.Count == 0)) // TODO && playlistIndices.Count == 0
            {
                var libraryIndexChange = 1;
                foreach (var plIndex in playlistIndices.ToArray())
                {
                    var forLoopIndexDebug = playlistIndices.IndexOf(plIndex); //TODO remove
                    var comparisonValueDebug = TopPlaylistItem(plIndex).FullPath.CompareTo(TopLibraryItem(libraryIndex).FullPath); //TODO remove
                    var comparisonValue = AddPlaylistItem(plIndex, libraryIndex, playlistIndices);
                    if (comparisonValue == 0) // playlistItem has been added => increment playlist index
                    {
                        var plChildren = TopPlaylistItem(plIndex).Children;
                        if (plChildren != null && plChildren.Count > 0)
                        {
                            plIndex.Stack.Push(new Index(0, plChildren.ToList<object>()));
                        }
                        else
                        {
                            IncrementIndexAndRemoveIndexIfStackEmpty(plIndex, playlistIndices);
                        }
                    }
                    else if (comparisonValue < 0)
                    {
                        loopCounterDecrement++;
                        history.AppendLine("     (" + (-comparisonValue).ToString() + ") Elements added from [" + playlistIndices.IndexOf(plIndex) + "] (" + plIndex.Playlist.Name + "):      " + TopPlaylistItem(plIndex).Name);
                        IncrementIndexAndRemoveIndexIfStackEmpty(plIndex, playlistIndices);

                        libraryIndex.Peek().List = GetChildrenSorted(libraryIndex.ToArray<Index>()[1].Node as MusicLibraryItem);
                        libraryIndexChange = 0;
                    }
                }

                history.AppendLine(loopCounter.ToString() + "  " + TopLibraryItem(libraryIndex).FullPath);

                List<object> libChildren = GetChildrenSorted(TopLibraryItem(libraryIndex));
                if (libChildren != null && libChildren.Count > 0)
                {
                    libraryIndex.Push(new Index(0, libChildren));
                    libraryFinished = false;
                }
                else
                {
                    libraryFinished = !IncrementIndex(libraryIndex);
                    if (libraryFinished && playlistIndices.Count > 0)
                    {
                        AddMissingElement(playlistIndices[0], libraryIndex);
                        IncrementIndexAndRemoveIndexIfStackEmpty(playlistIndices[0], playlistIndices);
                    }
                }
                loopCounter++;
            }
            var waitDebug = 0; //TODO remove
        }

        private List<object> GetChildrenSorted(MusicLibraryDirectory directory)
        {
            return directory.Directories.Concat(directory.Files).OrderBy(item => item.FullPath).ToList<object>();
        }
        private List<object> GetChildrenSorted(MusicLibraryItem libraryItem)
        {
            if (libraryItem is MusicLibraryDirectory)
            {
                return GetChildrenSorted(libraryItem as MusicLibraryDirectory).ToList<object>();
            }
            else if (libraryItem is MusicLibraryMissingElement)
            {
                var folder = (libraryItem as MusicLibraryMissingElement);
                return folder.Children.OrderBy(item => item.Name).ToList<object>();
            }
            else if (libraryItem is MusicLibraryFile || libraryItem is MusicLibraryItem)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private int DecrementIndex(Stack<Index> stack, bool checkChildren)
        {
            var TopIndex = stack.Peek();
            if (TopIndex.Number > 0)
            {
                TopIndex.Number--;
                if (checkChildren)
                {
                    var children = GetChildrenSorted(TopLibraryItem(stack));
                    bool childrenExist = children != null && children.Count > 0;

                    if (childrenExist)
                    {
                        stack.Push(new Index(children.Count - 1, children));
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                stack.Pop();
                return -1;
            }
        }

        private void IncrementIndexAndRemoveIndexIfStackEmpty(PlaylistIndex plIndex, List<PlaylistIndex> playlistIndices)
        {
            var StackEmpty = !IncrementIndex(plIndex.Stack);
            if (StackEmpty)
            {
                playlistIndices.Remove(plIndex);
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
        private bool IncrementIndex(PlaylistIndex playlistIndex)
        {
            return IncrementIndex(playlistIndex.Stack);
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

        /// <summary>
        /// Adds PlaylistItem to library item if it is the right element. If the playlist item is missing in the library a new library item will be added.
        /// </summary>
        /// <param name="playlistIndex"></param>
        /// <param name="libraryIndex"></param>
        /// <returns>False if playlistItem was missing in the library. True else.</returns>
        int AddPlaylistItem(PlaylistIndex playlistIndex, Stack<Index> libraryIndex, List<PlaylistIndex> playlistIndices)
        {
            var plItem = TopPlaylistItem(playlistIndex);
            int comparisonValue = plItem.FullPath.CompareTo(TopLibraryItem(libraryIndex).FullPath);
            if (comparisonValue == 0) //strings are equal
            {
                TopLibraryItem(libraryIndex).PlaylistItems.Add(new PlaylistLink(plItem, playlistIndex.Playlist));
            }
            else if (comparisonValue <= -1) //playlist item preceeds library item
                                            //this playlist item is missing in the library item
                                            //TODO check which cases end up here
            {
                MusicLibraryMissingElement missingElement = AddMissingElement(playlistIndex, libraryIndex);
                comparisonValue = -RecursiveAmountOfElements(missingElement);
            }
            return comparisonValue;
        }

        private MusicLibraryMissingElement AddMissingElement(PlaylistIndex playlistIndex, Stack<Index> libraryIndex)
        {
            PlaylistItem plItem = TopPlaylistItem(playlistIndex);
            MusicLibraryItem parentOfMissingElement = FindParentOfMissingElement(plItem, libraryIndex);
            MusicLibraryMissingElement missingElement = CreateMissingElement(new PlaylistLink(plItem, playlistIndex.Playlist), parentOfMissingElement);
            if (parentOfMissingElement is MusicLibraryDirectory)
            {
                var folder = parentOfMissingElement as MusicLibraryDirectory;
                switch (plItem.Type)
                {
                    case PlaylistItemType.Song:
                        folder.Files.Add(missingElement);
                        folder.Files = folder.Files.OrderBy(item => item.Name).ToList();
                        break;
                    case PlaylistItemType.Folder:
                        folder.Directories.Add(missingElement);
                        folder.Directories = folder.Directories.OrderBy(item => item.Name).ToList();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                var folder = parentOfMissingElement as MusicLibraryMissingElement;
                folder.Children.Add(missingElement);
                folder.Children = folder.Children.OrderBy(item => item.Name).ToList();
            }
            var childrenOfParent = GetChildrenSorted(TopLibraryItem(libraryIndex));
            libraryIndex.Push(new Index(childrenOfParent.IndexOf(missingElement), childrenOfParent));
            return missingElement;
        }

        private MusicLibraryItem FindParentOfMissingElement(PlaylistItem playlistItem, Stack<Index> libraryIndex)
        {
            if (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath))
            {
                var prevDirection = 1;
                while (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath) && prevDirection > 0)
                {
                    prevDirection = DecrementIndex(libraryIndex, true);
                }
                while (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath))
                {
                    prevDirection = DecrementIndex(libraryIndex, false);
                }
            }
            var folder = TopLibraryItem(libraryIndex);
            return folder;
        }

        private int RecursiveAmountOfElements(MusicLibraryMissingElement missingElement)
        {
            int res = 1;
            foreach (var element in missingElement.Children)
            {
                res += RecursiveAmountOfElements(element);
            }
            return res;
        }

        private MusicLibraryMissingElement CreateMissingElement(PlaylistLink playlistLink, MusicLibraryItem parent)
        {
            var missingElement = new MusicLibraryMissingElement(playlistLink.Item.FullPath, playlistLink, parent);
            AddAllChildrenToMissingElement(missingElement, playlistLink, parent);
            missingElement.Found += MissingElement_Found;
            return missingElement;
        }

        private void AddAllChildrenToMissingElement(MusicLibraryMissingElement missingElement, PlaylistLink playlistLink, MusicLibraryItem parent)
        {
            if (playlistLink.Item.Children != null)
            {
                foreach (var item in playlistLink.Item.Children)
                {
                    missingElement.Children.Add(CreateMissingElement(new PlaylistLink(item, playlistLink.Playlist), parent));
                }
            }
        }

        private void MissingElement_Found(object sender, EventArgs e)
        {
            throw new NotImplementedException("MissingElement_Found not implemented. " + (sender as MusicLibraryMissingElement).FullPath);
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

        public void AddAllPlaylistItemsToMusicFolder(PlaylistItem playlist, MusicLibraryDirectory folder) //TODO delete
        {
            foreach (PlaylistItem item in playlist.Children)
            {
                AddAllPlaylistItemsToMusicFolder(item, playlist, folder);
            }
        }

        public void AddAllPlaylistItemsToMusicFolder(PlaylistItem item, PlaylistItem playlist, MusicLibraryDirectory folder) //TODO delete
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
    }
}