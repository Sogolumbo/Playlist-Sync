using System;
using System.Collections.Generic;
using System.IO;

namespace Playlist
{
    public class MusicLibraryDirectory : MusicLibraryItem
    {
        public MusicLibraryDirectory(string directoryPath)
        {
            Name = System.IO.Path.GetFileName(directoryPath);
            DirectoryPath = directoryPath.Remove(directoryPath.Length - ("\\" + System.IO.Path.GetFileName(directoryPath)).Length);
            Parent = null;
            Directories = new List<MusicLibraryDirectory>();
            Files = new List<MusicLibraryFile>();
            foreach (string item in Directory.GetDirectories(directoryPath))
            {
                Directories.Add(new MusicLibraryDirectory(item));
            }
            foreach (string item in Directory.GetFiles(directoryPath))
            {
                string extensionWithoutDot = System.IO.Path.GetExtension(item).Substring(1);
                AudioFileType Type;
                if(Enum.TryParse<AudioFileType>(extensionWithoutDot, true, out Type)){
                    Files.Add(new MusicLibraryFile() {FullPath = item, Type = Type});
                }
            }
        }

        public List<MusicLibraryDirectory> Directories { get; set; }
        public List<MusicLibraryFile> Files { get; set; }
    }
}
