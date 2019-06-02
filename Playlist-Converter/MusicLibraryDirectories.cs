using System;
using System.Collections.Generic;
using System.IO;

namespace Playlist
{
    public class MusicLibraryDirectory : MusicLibraryItem
    {
        public MusicLibraryDirectory(string directoryPath, MusicLibraryDirectory parent)
        {
            _name = Path.GetFileName(directoryPath);
            DirectoryPath = directoryPath.Remove(directoryPath.Length - ("\\" + System.IO.Path.GetFileName(directoryPath)).Length);
            Parent = parent;
            Directories = new List<MusicLibraryItem>();
            Files = new List<MusicLibraryItem>();
            foreach (string item in Directory.GetDirectories(directoryPath))
            {
                var dir = new MusicLibraryDirectory(item, this);
                dir.UnauthorizedAccess += ThrowUnauthorizedAccessException;
                Directories.Add(dir);
            }
            foreach (string item in Directory.GetFiles(directoryPath))
            {
                string extensionWithoutDot = Path.GetExtension(item).Substring(1);
                AudioFileType Type;
                if (Enum.TryParse<AudioFileType>(extensionWithoutDot, true, out Type))
                {
                    Files.Add(new MusicLibraryFile(item, Type, this));
                }
            }
        }

        public event EventHandler<NameChangedEventArgs> NameChanged;

        public List<MusicLibraryItem> Directories { get; set; }
        public List<MusicLibraryItem> Files { get; set; }
        public List<MusicLibraryMissingElement> MissingElements { get; set; }

        public override string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
                foreach (var item in Directories)
                {
                    item.DirectoryPath = FullPath;
                }
                foreach (var item in Files)
                {
                    item.DirectoryPath = FullPath;
                }
                NameChanged?.Invoke(this, new NameChangedEventArgs(value, true));
            }
        }

        public MusicLibraryDirectory Parent
        {
            get => base.Parent as MusicLibraryDirectory;
            set
            {
                base.Parent = value;
            }
        }

        public override void Reload()
        {
            foreach (var item in Directories)
            {
                item.Reload();
            }
            foreach (var item in Files)
            {
                item.Reload();
            }
            base.Reload();
        }
    }
}
