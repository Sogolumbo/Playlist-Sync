using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string SourcePlaylistRegex
        {
            get
            {
                string result;
                switch (SourcePlaylistType)
                {
                    case PlaylistType.M3u:
                        result = ".+\\.m3u";
                        break;
                    case PlaylistType.M3u8:
                        result = ".+\\.mu3u8";
                        break;
                    case PlaylistType.Playlistsync:
                        result = ".+\\.playlistsync(\\.txt)?";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                return result;
            }
        }
        public bool SourceUseSlashAsSeperator { get; set; }
        public Encoding GetSourceEncoding()
        { return PlaylistEncoding.GetEncoding(SourcePlaylistType); }
        public string TargetPlaylistFolderPath { get; set; }
        public PlaylistType TargetPlaylistType { get; set; }
        public bool TargetUseSlashAsSeperator { get; set; }
        public Encoding GetTargetEncoding()
        { return PlaylistEncoding.GetEncoding(TargetPlaylistType); }
        public string TargetFileNamePrefix { get; set; }
        public string TargetFileTypeSuffix { get; set; }
        /// <summary>
        /// First element: source folder, second element: target folder
        /// </summary>
        public Dictionary<string, string> MusicFolderPaths { get; set; }

        public string[] GetSourcePlaylistFiles()
        {
            string[] sourceFiles = new string[] { };
            if (!String.IsNullOrEmpty(SourcePlaylistFolderPath))
            {
                sourceFiles = Directory.GetFiles(SourcePlaylistFolderPath);
                sourceFiles = sourceFiles.Where(file => Regex.IsMatch(file, SourcePlaylistRegex)).ToArray();
            }
            return sourceFiles;
        }
    }
}
