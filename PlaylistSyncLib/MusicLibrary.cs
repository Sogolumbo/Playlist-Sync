using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Playlist.Indexing;

namespace Playlist
{
    public class MusicLibrary
    {
        public MusicLibrary(List<string> playlistFiles, List<string> musicDirectories, ICollection<string> nonAudioDataTypes) : this(
            playlistFiles.Select(filepath => new PlaylistItem(filepath, false)).ToList(),
            musicDirectories, nonAudioDataTypes)
        {
            PlaylistFiles = playlistFiles;
        }
        public MusicLibrary(List<PlaylistItem> playlists, List<string> musicDirectories, ICollection<string> nonAudioDataTypes)
        {
            _nonAudioDataTypes = nonAudioDataTypes;

            musicDirectories.Sort();

            Playlists = playlists;
            MusicFolders = musicDirectories;
            ItemFolder = ItemFoldersFromMusicDirectories();
        }

        public List<PlaylistItem> Playlists { get; set; }
        public List<string> PlaylistFiles { get; set; }
        public List<string> MusicFolders { get; set; }
        public MusicLibraryDirectory ItemFolder { get; set; }
        private ICollection<string> _nonAudioDataTypes;

        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;
        public event EventHandler MissingElementFound;

        public MusicLibraryDirectory ItemFoldersFromMusicDirectories()
        {
            return ItemFoldersFromMusicFolders(MusicFolders, Playlists);
        }
        public MusicLibraryDirectory ItemFoldersFromMusicFolders(List<string> musicFolders, List<PlaylistItem> playlists)
        {
            MusicLibraryDirectory itemFolders = null;
            if (musicFolders.Count > 0)
            {
                //first Element
                var dir = new MusicLibraryDirectory(musicFolders[0], null, _nonAudioDataTypes);
                dir.UnauthorizedAccess += Dir_UnauthorizedAccess;

                string directory = dir.DirectoryPath;
                string[] parentDirectories = ParentDirectories(directory, true);
                MusicLibraryDirectory[] directories = new MusicLibraryDirectory[parentDirectories.Length];
                for (int i = parentDirectories.Length - 1; i >= 0; i--)
                {
                    if (i == parentDirectories.Length - 1)
                    {
                        directories[i] = new MusicLibraryDirectory(parentDirectories[i], null, new List<MusicLibraryItem>() { dir }, _nonAudioDataTypes);
                        dir.Parent = directories[i];
                    }
                    else
                    {
                        directories[i] = new MusicLibraryDirectory(parentDirectories[i], null, new List<MusicLibraryItem>() { directories[i + 1] }, _nonAudioDataTypes);
                        directories[i + 1].Parent = directories[i];
                    }
                }
                if (parentDirectories.Length > 0)
                {
                    itemFolders = directories[0];
                }
                else
                {
                    throw new NotImplementedException();
                }

                //the other elements
                for (int i = 1; i < musicFolders.Count; i++)
                {
                    AddMusicFolderToLibrary(musicFolders[i], itemFolders);
                }

                AddAllPlaylistItemsToLibraryFolder(playlists, itemFolders);
            }
            return itemFolders;
        }

        public static int CompareFilePaths(string filePathA, string filePathB)
        {
            string[] pathPartsA = filePathA.Split('\\');
            string[] pathPartsB = filePathB.Split('\\');
            return CompareAtoB(pathPartsA, pathPartsB);
        }


        /// <returns>The highest modified node</returns>
        public MusicLibraryItem MoveItem(MusicLibraryItem item, string newDirectoryPath)
        {
            var newParent = GetItemFromPath(newDirectoryPath);
            if (newParent != null)
            {
                MoveItem(item, newParent);
                return newParent;
            }
            throw new NotImplementedException();
        }

        public void MoveItem(MusicLibraryItem item, MusicLibraryItem newParent)
        {
            if (newParent.IsFile())
            {
                throw new ArgumentException("NewParent can not be a file!", "newParent");
            }
            if (item.DirectoryPath == newParent.FullPath)
            {
                return;
            }

            string oldDirectoryPath = item.DirectoryPath;
            item.MoveFilesystemItem(oldDirectoryPath + "\\" + item.Name, newParent.FullPath + "\\" + item.Name);
            item.DirectoryPath = newParent.FullPath;

            //Remove library item from old parent
            if (item.Parent is MusicLibraryMissingElement)
            {
                (item.Parent as MusicLibraryMissingElement).Children.Remove((MusicLibraryMissingElement)item);
            }
            if (item.Parent is MusicLibraryDirectory)
            {
                if (item.IsFile())
                {
                    (item.Parent as MusicLibraryDirectory).Files.Remove(item);
                }
                else
                {
                    (item.Parent as MusicLibraryDirectory).Directories.Remove(item);
                }
            }

            //Add library item to new parent
            if (newParent is MusicLibraryMissingElement)
            {
                (newParent as MusicLibraryMissingElement).CheckExistence();
                if (newParent is MusicLibraryMissingElement)
                {
                    var list = (newParent as MusicLibraryMissingElement).Children;
                    InsertItemOrdered(item, list);
                }
            }
            if (newParent is MusicLibraryDirectory)
            {
                if (item.IsFile())
                {
                    InsertItemOrdered(item, (newParent as MusicLibraryDirectory).Files);
                }
                else
                {
                    InsertItemOrdered(item, (newParent as MusicLibraryDirectory).Directories);
                }
            }
            item.Parent = newParent;

            //take care of the playlists
            foreach (PlaylistLink plLink in item.PlaylistItems)
            {
                plLink.Item.Parent.RemoveChild(plLink.Item);
                plLink.Playlist.AddItemToPlaylist(plLink.Item);
            }
            item.Reload();
        }

        private static void InsertItemOrdered<T>(MusicLibraryItem item, List<T> list) where T : MusicLibraryItem
        {
            int index = 0;
            while (index < list.Count && CompareFilePaths(item.FullPath, list[index].FullPath) > 0)
            {
                index++;
            }
            list.Insert(index, (T)item);
        }

        private MusicLibraryItem GetItemFromPath(string path)
        {
            Stack<Index> libraryIndex = new Stack<Index>();
            libraryIndex.Push(new Index(0, ItemFolder.Directories.ToList<object>()));
            bool elementsLeft = true;
            while (path.CompareTo(TopLibraryItem(libraryIndex).FullPath) > 0 && elementsLeft)
            {
                elementsLeft = IncrementIndex(libraryIndex, true);
            }
            if (path.CompareTo(TopLibraryItem(libraryIndex).FullPath) != 0)
            {
                return null;
            }
            return TopLibraryItem(libraryIndex);
        }

        private void AddMusicFolderToLibrary(string musicFolderPath, MusicLibraryDirectory itemFolders)
        {
            var dir = new MusicLibraryDirectory(musicFolderPath, null, _nonAudioDataTypes);
            dir.UnauthorizedAccess += Dir_UnauthorizedAccess;

            Stack<Index> libraryIndex = new Stack<Index>();
            libraryIndex.Push(new Index(0, new List<object>() { itemFolders }));
            bool ElementsFinished = false;
            while (0 != musicFolderPath.CompareTo(TopLibraryItem(libraryIndex).FullPath) && !ElementsFinished)
            {
                ElementsFinished = !IncrementIndex(libraryIndex, true);
            }
            if (ElementsFinished)
            {
                string[] directories = ParentDirectories(musicFolderPath, false);
                for (int i = directories.Length - 1; i >= 0; i--)
                {
                    libraryIndex.Clear();
                    libraryIndex.Push(new Index(0, new List<object>() { itemFolders }));
                    ElementsFinished = false;
                    while (0 != directories[i].CompareTo(TopLibraryItem(libraryIndex).FullPath) && !ElementsFinished)
                    {
                        ElementsFinished = !IncrementIndex(libraryIndex, true);
                    }
                    if (!ElementsFinished)
                    {
                        break;
                    }
                    else
                    {
                        var prevDir = dir;
                        dir = new MusicLibraryDirectory(directories[i], null, new List<MusicLibraryItem>() { dir }, _nonAudioDataTypes);
                        prevDir.Parent = dir;
                    }
                }
            }
            (TopLibraryItem(libraryIndex) as MusicLibraryDirectory).Directories.Add(dir);
        }

        private static string[] ParentDirectories(string directory, bool includeDirectory = false)
        {
            string[] parentDirectories = directory.Split('\\');
            for (int i = 1; i < parentDirectories.Length; i++)
            {
                if (i == 1)
                {
                    parentDirectories[i] = parentDirectories[i - 1] + "\\" + parentDirectories[i];
                }
                else
                {
                    parentDirectories[i] = Path.Combine(parentDirectories[i - 1], parentDirectories[i]);
                }
            }
            if (!includeDirectory)
            {
                Array.Resize(ref parentDirectories, parentDirectories.Length - 1);
            }

            return parentDirectories;
        }

        #region new 

        private void AddAllPlaylistItemsToLibraryFolder(List<PlaylistItem> playlists, MusicLibraryDirectory itemFolder) //TODO only accepts non-empty elements in both lists. Both Lists must be sorted
        {
            HashSet<PlaylistItem> ignoredPlaylistItems = new HashSet<PlaylistItem>();

            ///Setup indices
            List<PlaylistIndex> playlistIndices = new List<PlaylistIndex>(playlists.Count);
            Stack<Index> libraryIndex = new Stack<Index>();

            libraryIndex.Push(new Index(0, new List<object>() { itemFolder }));
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

            while (!(libraryFinished && playlistIndices.Count == 0))
            {
                foreach (var plIndex in playlistIndices.ToArray())
                {
                    var forLoopIndexDebug = playlistIndices.IndexOf(plIndex); //TODO remove debugging tools
                    var comparisonValueDebug = CompareFilePaths(TopPlaylistItem(plIndex).FullPath, TopLibraryItem(libraryIndex).FullPath); //TODO remove debugging tools
                    var temp1 = TopPlaylistItem(plIndex).FullPath;
                    var temp2 = TopLibraryItem(libraryIndex).FullPath; //TODO remove debugging tools
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
        }

        internal static List<object> GetChildrenSorted(MusicLibraryDirectory directory)
        {
            return directory.Directories.Concat(directory.Files).OrderBy(item => item.FullPath).ToList<object>();
        }
        internal static List<object> GetChildrenSorted(MusicLibraryItem libraryItem)
        {
            if (libraryItem is MusicLibraryDirectory)
            {
                return GetChildrenSorted(libraryItem as MusicLibraryDirectory).ToList<object>();
            }
            else if (libraryItem is MusicLibraryMissingElement)
            {
                var folder = (libraryItem as MusicLibraryMissingElement);
                return folder.Children.OrderBy(item => item.FullPath).ToList<object>();
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


        /// <summary>
        /// Adds PlaylistItem to library item if it is the right element. If the playlist item is missing in the library a new library item will be added.
        /// </summary>
        /// <param name="playlistIndex"></param>
        /// <param name="libraryIndex"></param>
        /// <returns>False if playlistItem was missing in the library. True else.</returns>
        int AddPlaylistItem(PlaylistIndex playlistIndex, Stack<Index> libraryIndex, List<PlaylistIndex> playlistIndices)
        {
            var plItem = TopPlaylistItem(playlistIndex);

            int comparisonValue = CompareFilePaths(plItem.FullPath, TopLibraryItem(libraryIndex).FullPath);
            if (comparisonValue == 0) //strings are equal
            {
                TopLibraryItem(libraryIndex).PlaylistItems.Add(new PlaylistLink(plItem, playlistIndex.Playlist));
            }
            else if (comparisonValue <= -1) //playlist item preceeds library item
                                            //this playlist item is missing in the library item
            {
                MusicLibraryMissingElement missingElement = AddMissingElement(playlistIndex, libraryIndex);
                comparisonValue = -RecursiveAmountOfElements(missingElement);
            }
            return comparisonValue;
        }

        private static int CompareAtoB(string[] pathPartsA, string[] pathPartsB)
        {
            int index = 0;
            while (pathPartsA[index].CompareTo(pathPartsB[index]) == 0)
            {
                index++;
                if (index >= pathPartsA.Length || index >= pathPartsB.Length)
                {
                    return pathPartsA.Length.CompareTo(pathPartsB.Length);
                }
            }
            return pathPartsA[index].CompareTo(pathPartsB[index]);
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
                        folder.Files = folder.Files.OrderBy(item => item.FullPath).ToList();
                        break;
                    case PlaylistItemType.Folder:
                        folder.Directories.Add(missingElement);
                        folder.Directories = folder.Directories.OrderBy(item => item.FullPath).ToList();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                var folder = parentOfMissingElement as MusicLibraryMissingElement;
                folder.Children.Add(missingElement);
                folder.Children = folder.Children.OrderBy(item => item.FullPath).ToList();
            }
            var childrenOfParent = GetChildrenSorted(TopLibraryItem(libraryIndex));
            libraryIndex.Push(new Index(childrenOfParent.IndexOf(missingElement), childrenOfParent));
            missingElement.UnauthorizedAccess += parentOfMissingElement.ThrowUnauthorizedAccessException;
            return missingElement;
        }

        private MusicLibraryItem FindParentOfMissingElement(PlaylistItem playlistItem, Stack<Index> libraryIndex)
        {
            if (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath))
            {
                var prevDirection = 1;
                while (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath) && prevDirection > 0)
                {
                    prevDirection = DecrementLibIndex(libraryIndex, true);
                }
                while (0 != playlistItem.Path.CompareTo(TopLibraryItem(libraryIndex).FullPath))
                {
                    prevDirection = DecrementLibIndex(libraryIndex, false);
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
            AddAllChildrenToMissingElement(missingElement, playlistLink);
            missingElement.Found += MissingElement_Found;
            return missingElement;
        }

        private void AddAllChildrenToMissingElement(MusicLibraryMissingElement missingElement, PlaylistLink playlistLink)
        {
            if (playlistLink.Item.Children != null)
            {
                foreach (var item in playlistLink.Item.Children)
                {
                    missingElement.Children.Add(CreateMissingElement(new PlaylistLink(item, playlistLink.Playlist), missingElement));
                }
            }
        }

        private void MissingElement_Found(object sender, EventArgs e)
        {
            if (MissingElementFound != null)
            {
                MissingElementFound.Invoke(this, EventArgs.Empty);
            }
            else
            {
                throw new NotImplementedException("MissingElement_Found not implemented. " + (sender as MusicLibraryMissingElement).FullPath); 
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
    }
}