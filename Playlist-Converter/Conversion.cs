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
        public string SourcePlaylistFolderPath { get; set; }
        public string SourcePlaylistFilterRegex { get; set; }
        public PlaylistType SourcePlaylistType { get; set; }
        public string SourceMusicFolderPath { get; set; }
        public bool SourceUseSlashAsSeperator { get; set; }
        public string TargetPlaylistFolderPath { get; set; }
        public PlaylistType TargetPlaylistType { get; set; }
        public string TargetMusicFolderPath { get; set; }
        public bool TargetUseSlashAsSeperator { get; set; }
    }
}
