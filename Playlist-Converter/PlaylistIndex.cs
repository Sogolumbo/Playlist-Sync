using System.Collections.Generic;

namespace Playlist
{
    class PlaylistIndex
    {
        public PlaylistIndex(Stack<Index> stack, PlaylistItem playlist)
        {
            Stack = stack;
            Playlist = playlist;
        }
        public Stack<Index> Stack { get; set; }
        public PlaylistItem Playlist { get; }
    }
}
