using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class Conversion
    {
        public string Title { get; set; }
        public string SourceFolderPath { get; set; }
        public PlaylistType SourcePlaylistType { get; set; }
        public string TargetFolderPath { get; set; }
        public PlaylistType TargetPlaylistType { get; set; }
    }
}
