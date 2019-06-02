using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class Conversion
    {
        public Conversion()
        {
            MusicFolderPaths = new Dictionary<string, string>();
        }
        public string Title { get; set; }
        public string SourcePlaylistFolderPath { get; set; }
        public string SourcePlaylistFilterRegex { get; set; }
        public PlaylistType SourcePlaylistType { get; set; }
        public bool SourceUseSlashAsSeperator { get; set; }
        public string TargetPlaylistFolderPath { get; set; }
        public PlaylistType TargetPlaylistType { get; set; }
        public bool TargetUseSlashAsSeperator { get; set; }
        /// <summary>
        /// First element: source folder, second element: target folder
        /// </summary>
        public Dictionary<string, string> MusicFolderPaths { get; set; }
    }
}
