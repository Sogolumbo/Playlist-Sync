using System.Collections.Generic;
using System.Linq;

namespace Playlist
{
    static class Indexing
    {
        internal static int DecrementLibIndex(Stack<Index> stack, bool checkChildren)
        {
            var TopIndex = stack.Peek();
            if (TopIndex.Number > 0)
            {
                TopIndex.Number--;
                if (checkChildren)
                {
                    var children = MusicLibrary.GetChildrenSorted(TopLibraryItem(stack));
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
        internal static int DecrementPlIndex(Stack<Index> stack, bool checkChildren)
        {
            var TopIndex = stack.Peek();
            if (TopIndex.Number > 0)
            {
                TopIndex.Number--;
                if (checkChildren)
                {
                    var children = TopPlaylistItem(stack).Children;
                    bool childrenExist = children != null && children.Count > 0;

                    if (childrenExist)
                    {
                        stack.Push(new Index(children.Count - 1, children.ToList<object>()));
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

        internal static void IncrementIndexAndRemoveIndexIfStackEmpty(PlaylistIndex plIndex, List<PlaylistIndex> playlistIndices)
        {
            var StackEmpty = !IncrementIndex(plIndex.Stack);
            if (StackEmpty)
            {
                playlistIndices.Remove(plIndex);
            }
        }

        internal static PlaylistItem TopPlaylistItem(PlaylistIndex playlistIndex)
        {
            return TopPlaylistItem(playlistIndex.Stack);
        }
        internal static PlaylistItem TopPlaylistItem(Stack<Index> stack)
        {
            return stack.Peek().Node as PlaylistItem;
        }
        internal static MusicLibraryItem TopLibraryItem(Stack<Index> stack)
        {
            return stack.Peek().Node as MusicLibraryItem;
        }
        internal static bool IncrementIndex(PlaylistIndex playlistIndex)
        {
            return IncrementIndex(playlistIndex.Stack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="includeChildren"></param>
        /// <returns>Returns true if there are elements left, false otherwise</returns>
        internal static bool IncrementIndex(Stack<Index> stack, bool includeChildren = false)
        {
            List<object> children;
            if (stack.Peek().Node is MusicLibraryItem)
            {
                children = MusicLibrary.GetChildrenSorted(stack.Peek().Node as MusicLibraryItem);
            }
            else
            {
                children = (stack.Peek().Node as PlaylistItem).Children?.ToList<object>();
            }
            if (includeChildren && children != null && children.Count > 0)
            {
                stack.Push(new Index(0, children));
                return true;
            }
            else
            {
                var TopIndex = stack.Peek();
                if (TopIndex.Number + 1 < TopIndex.List.Count)
                {
                    TopIndex.Number++;
                    return true;
                }
                else if (stack.Count >= 2)
                {
                    var backup = stack.Pop();
                    var nextElementExists = IncrementIndex(stack);
                    if (!nextElementExists)
                    {
                        stack.Push(backup);
                    }
                    return nextElementExists;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
