using System.Collections.Generic;

namespace Playlist
{
    public interface Node
    {
        Node Parent { get; set; }
    }
    public interface NodeFolder
    {

    }
}