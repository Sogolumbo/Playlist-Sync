using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class M3uCleaner
    {
        public static string[] CleanLines(string[] lines)
        {
            return lines
                .Where((line)
                   => !String.IsNullOrWhiteSpace(line)
                      && (line[0] != '#')
                ).ToArray();
        }

        public static void CleanFile(string filePath, bool fixRelativePaths)
        {
            string[] oldLines = File.ReadAllLines(filePath, PlaylistEncoding.GetEncoding(filePath));
            List<string> newLines = new List<string>();
            oldLines = CleanLines(oldLines);

            string fileDirectory = Path.GetDirectoryName(filePath);

            foreach (string line in oldLines)
            {
                if(!Path.IsPathRooted(line) && fixRelativePaths) //relative filepath detected
                {
                    string uglyPath = Path.Combine(fileDirectory, line);
                    string cleanPath = new DirectoryInfo(uglyPath).FullName; //removes directory\..\ from file path
                    newLines.Add(cleanPath);
                }
                else
                {
                    newLines.Add(line);
                }
            }

            File.WriteAllLines(filePath, newLines.ToArray(), PlaylistEncoding.GetEncoding(filePath));
        }
    }
}
