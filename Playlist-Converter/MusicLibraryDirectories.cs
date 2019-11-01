using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Playlist
{
    public class MusicLibraryDirectory : MusicLibraryItem
    {
        public MusicLibraryDirectory(string directoryPath, MusicLibraryDirectory parent, List<MusicLibraryItem> directories) : this(directoryPath, parent, false)
        {
            Directories = directories;
        }
        public MusicLibraryDirectory(string directoryPath, MusicLibraryDirectory parent, bool build = true)
        {
            _name = Path.GetFileName(directoryPath);
            if (String.IsNullOrEmpty(_name))
            {
                _name = directoryPath;
                _directoryPath = "";
            }
            else
            {
                _directoryPath = directoryPath.Remove(directoryPath.Length - ("\\" + Path.GetFileName(directoryPath)).Length);
                Parent = parent;
            }
            if (Directories == null)
                Directories = new List<MusicLibraryItem>();
            if (Files == null)
                Files = new List<MusicLibraryItem>();
            if (build)
            {
                foreach (string item in Directory.GetDirectories(directoryPath))
                {
                    var dir = new MusicLibraryDirectory(item, this);
                    dir.UnauthorizedAccess += ThrowUnauthorizedAccessException;
                    Directories.Add(dir);
                }
                foreach (string item in Directory.GetFiles(directoryPath))
                {
                    string extensionWithoutDot = Path.GetExtension(item).Substring(1);
                    string[] ignoredDataTypes = new string[] { "jpg", "png", "m3u", "wpl", "pls", "ini", "ffs_db", "db", "pdf"};
                    AudioFileType Type;
                    if (Enum.TryParse<AudioFileType>(extensionWithoutDot, true, out Type))
                    {
                        var file = new MusicLibraryFile(item, Type, this);
                        Files.Add(file);
                        file.UnauthorizedAccess += ThrowUnauthorizedAccessException;
                    }
                    else if(!(ignoredDataTypes.Contains(extensionWithoutDot)) && item[0] != '.')
                    {
                        throw new NotImplementedException("There is a file (" + item + ")of type " + extensionWithoutDot + ". This program doesn't know what type it is (Audio or Playlist File or Cover Art?).");
                    }
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

        public IEnumerable<MusicLibraryItem> Children
        {
            get => Files.Concat(Directories);
        }

        protected override void LocationChange()
        {
            foreach (MusicLibraryItem item in Children)
            {
                item.DirectoryPath = FullPath;
            }
            base.LocationChange();
        }
    }
}
