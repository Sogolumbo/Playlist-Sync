using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Playlist
{
    public class PathConverter
    {
        public string SourceMusicFolderPath { get; set; }
        public string TargetMusicFolderPath { get; set; }
        public bool SourceUsesSlashesAsDirectorySeperator { get; set; }
        public bool TargetUsesSlashesAsDirectorySeperator { get; set; }

        private List<string> _missingLines = new List<string>();
        private List<string> _duplicateLines = new List<string>();

        public PathConverter()
        {
            SourceMusicFolderPath = "";
            TargetMusicFolderPath = "";
        }

        public string[] GetNeutralLines(string[] playlistLines)
        {
            return ConvertedLines(playlistLines, false); ;
        }
        public string[] GetNeutralLines(string playlistFilePath)
        {
            string[] playlistLines = File.ReadAllLines(playlistFilePath);
            return GetNeutralLines(playlistLines);
        }

        public string[] GetConvertedLines (string[] playlistLines)
        {
            return ConvertedLines(playlistLines, true);
        }
        public string[] GetConvertedLines(string playlistFilePath)
        {
            string[] playlistLines = File.ReadAllLines(playlistFilePath);
            return GetConvertedLines(playlistLines);
        }

        private string[] ConvertedLines(string[] playlistLines, bool returnTarget)
        {
            _missingLines.Clear();
            List<string> result = new List<string>();
            string line = String.Empty;
            Regex FolderPathRegex = new Regex(Regex.Escape(SourceMusicFolderPath));
            foreach (string sourceLine in playlistLines)
            {
                if (FolderPathRegex.IsMatch(sourceLine))
                {
                    line = FolderPathRegex.Replace(sourceLine, returnTarget ? TargetMusicFolderPath : "");
                    if (SourceUsesSlashesAsDirectorySeperator && !TargetUsesSlashesAsDirectorySeperator)
                    {
                        line = line.Replace('/', '\\');
                    }
                    if (TargetUsesSlashesAsDirectorySeperator && !SourceUsesSlashesAsDirectorySeperator && returnTarget)
                    {
                        line = line.Replace('\\', '/');
                    }
                    
                    result.Add(line);
                }
                else
                {
                    _missingLines.Add(sourceLine);
                }
            }
            result = SortAndRemoveDuplicates(result);
            return result.ToArray();
        }

        public void Convert(string sourceFilepath, string targetFilepath)
        {
            string[] playlistLines = File.ReadAllLines(sourceFilepath);
            File.WriteAllLines(targetFilepath, GetConvertedLines(playlistLines));
        }

        public string[] GetMissingLines()
        {
            return _missingLines.ToArray();
        }

        private List<string> SortAndRemoveDuplicates (List<string> input)
        {
            _duplicateLines.Clear();
            input.Sort();
            List<string> result = new List<string>();
            for(int i = 0; i < input.Count; i++)
            {
                if(result.Count == 0 || result[result.Count - 1] != input[i])
                {
                    result.Add(input[i]);
                }
                else
                {
                    _duplicateLines.Add(input[i]);
                }
            }
            return result;
        }
    }
}
