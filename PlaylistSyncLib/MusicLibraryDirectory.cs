using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Playlist
{
    public class MusicLibraryDirectory : MusicLibraryItem
    {
        public MusicLibraryDirectory(string directoryPath, MusicLibraryDirectory parent, List<MusicLibraryItem> directories, ICollection<string> nonAudioDataTypes) : this(directoryPath, parent, nonAudioDataTypes, false)
        {
            Directories = directories;
        }
        public MusicLibraryDirectory(string directoryPath, MusicLibraryDirectory parent, ICollection<string> nonAudioDataTypes, bool build = true)
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
                    if (Path.GetFileName(item) == ".git")
                    {
                        continue;
                    }
                    var dir = new MusicLibraryDirectory(item, this, nonAudioDataTypes);
                    dir.UnauthorizedAccess += ThrowUnauthorizedAccessException;
                    dir.FileNameAlreadyExists += FireFileNameAlreadyExists;
                    Directories.Add(dir);
                }
                foreach (string item in Directory.GetFiles(directoryPath))
                {

                    string extensionWithoutDot = null;
                    string fullExtension = Path.GetExtension(item);
                    if (!String.IsNullOrWhiteSpace(fullExtension))
                    {
                        extensionWithoutDot = Path.GetExtension(item)?.Substring(1);
                    }
                    AudioFileType Type;
                    if (Enum.TryParse<AudioFileType>(extensionWithoutDot, true, out Type))
                    {
                        var file = new MusicLibraryFile(item, Type, this);
                        Files.Add(file);
                        file.UnauthorizedAccess += ThrowUnauthorizedAccessException;
                        file.FileNameAlreadyExists += FireFileNameAlreadyExists;
                    }
                    else if (!(nonAudioDataTypes.Contains(extensionWithoutDot)) && Path.GetFileName(item)[0] != '.')
                    {
                        throw new NonAudioDataTypeMissingException(item, extensionWithoutDot);
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

    public class NonAudioDataTypeMissingException : Exception
    {
        public NonAudioDataTypeMissingException(string dataType, string fileName) : base(message(dataType, fileName)) { }

        public string File { get; set; }
        public string DataType { get; set; }

        private static string message(string dataType, string fileName)
        {
            return "There is a file (" + fileName + ")of type " + dataType + " in the music library folders. If it's an audio file this program doesn't know how to handle it. If it is different kind of file, pleas add it to the list of ignored file formats (located in " + NonAudioDataTypeMissingException.PropertyFilePath + ").";
        }

        public static string PropertyFilePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\Local\PlaylistSyncGUI\");
            }
        }

    }
}
