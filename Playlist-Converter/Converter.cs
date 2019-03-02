using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Playlist
{
    public class Converter
    {
        private string LinesToM3u(string[] playlistlines)
        {
            List<string> m3uFile = new List<string>();
            m3uFile.Add("#EXTM3U");
            int i = 1;
            foreach (string line in playlistlines)
            {
                m3uFile.Add("#EXTINF:" + i++ + "," + Path.GetFileNameWithoutExtension(line));
                m3uFile.Add(line);
            }
            return String.Join("\n", m3uFile);
        }

        public void Convert(string sourceFile, PlaylistType sourceType, string targetFile,  PlaylistType targetType)
        {
            File.WriteAllText(targetFile, Convert(File.ReadAllLines(sourceFile), sourceType, targetType));
        }

        public string Convert(string[] playlistLines, PlaylistType sourceType, PlaylistType targetType)
        {
            string[] lines;

            switch (sourceType)
            {
                case PlaylistType.Playlistsync:
                    lines = playlistLines;
                    break;
                case PlaylistType.M3u:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            string result;
            switch (targetType)
            {
                case PlaylistType.Playlistsync:
                    throw new NotImplementedException();
                    break;
                case PlaylistType.M3u:
                    result = LinesToM3u(lines);
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
            return result;
        }
    }

    public enum PlaylistType
    {

        Playlistsync,
        M3u
    }
}
