using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Playlist
{
    public class MusicLibraryItem
    {
        public MusicLibraryItem()
        {
            PlaylistItems = new HashSet<PlaylistLink>();
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                var nameChanged = value != _name;
                if (nameChanged)
                {
                    if (Parent != null && (Parent as MusicLibraryDirectory).Directories.Where(dir => dir.Name == value).Count() > 0)
                    {
                        if (IsFile())
                        {
                            FireFileNameAlreadyExists(this, new FileNameAlreadyExistsEventArgs(_name, value));
                            return;
                        }
                        else if (this is MusicLibraryMissingElement) // this is a missing folder
                        {
                            var dir = this as MusicLibraryMissingElement;
                            throw new NotImplementedException(); //TODO join the two directories
                        }
                        else // existing folder
                        {
                            var item = (Parent as MusicLibraryDirectory).Directories.First(dir => dir.Name == value);
                            if (item is MusicLibraryMissingElement)
                            {
                                ChangeName(value);
                                (item as MusicLibraryMissingElement).CheckExistence();
                            }
                            else
                            {
                                throw new NotImplementedException(); //TODO join the two directories
                            }
                        }
                    }
                    else if (File.Exists(DirectoryPath + "\\" + value) && (value.ToLower() != _name.ToLower()))
                    {
                        FireFileNameAlreadyExists(this, new FileNameAlreadyExistsEventArgs(_name, value));
                        return;
                    }
                    else
                    {
                        ChangeName(value);
                    }

                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangeName(Name, false);
                    }
                    LocationChange();
                }
            }
        }

        private void ChangeName(string value)
        {
            if (value.ToLower() == _name.ToLower())
            {
                var temporaryName = "temp_" + value;
                ChangeFileSystemName(temporaryName);
                _name = temporaryName;
            }
            ChangeFileSystemName(value);
            _name = value;
        }

        public bool IsFile()
        {
            return this is MusicLibraryFile || (this is MusicLibraryMissingElement && (this as MusicLibraryMissingElement).Type == PlaylistItemType.Song);
        }

        protected virtual void LocationChange()
        {

        }

        protected void AttachItemsTo(MusicLibraryItem musicLibraryItem, IEnumerable<MusicLibraryItem> items)
        {
            if (musicLibraryItem is MusicLibraryMissingElement)
                (musicLibraryItem as MusicLibraryMissingElement).Children.AddRange(items.Cast<MusicLibraryMissingElement>());
            else
            {
                foreach (MusicLibraryItem item in items)
                {
                    if (item.IsFile())
                    {
                        (musicLibraryItem as MusicLibraryDirectory).Files.Add(item);
                    }
                    else
                    {
                        (musicLibraryItem as MusicLibraryDirectory).Directories.Add(item);
                    }
                    item.UnauthorizedAccess += musicLibraryItem.UnauthorizedAccess;
                }
            }
        }

        public string DirectoryPath
        {
            get => _directoryPath;
            set
            {
                if (value != _directoryPath)
                {
                    _directoryPath = value;
                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangePath(_directoryPath, false);
                    }
                    LocationChange();
                }
            }
        }
        public string FullPath
        {
            get
            {
                return String.IsNullOrWhiteSpace(this.DirectoryPath) ? Name : DirectoryPath + "\\" + Name;
            }
            set
            {
                Name = Path.GetFileName(value);
                DirectoryPath = value.Remove(value.Length - 1 - Name.Length);
            }
        }
        public virtual MusicLibraryItem Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                ParentChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public HashSet<PlaylistLink> PlaylistItems { get; set; }

        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;
        public event EventHandler ParentChanged;
        public event EventHandler<FileNameAlreadyExistsEventArgs> FileNameAlreadyExists;

        public virtual void Reload()
        {

        }

        public override string ToString()
        {
            return Name;
        }

        protected virtual void ChangeFileSystemName(string newName)
        {
            string oldPath = FullPath;
            string newPath = DirectoryPath + "\\" + newName;
            MoveFilesystemItem(oldPath, newPath);
        }

        internal virtual void MoveFilesystemItem(string oldPath, string newPath)
        {
            bool success = false;
            bool cancel = false;
            PlaylistItemType type = PlaylistItemType.Song;
            if (GetType() == typeof(MusicLibraryDirectory))
            {
                type = PlaylistItemType.Folder;
            }
            do
            {
                try
                {
                    if (this is MusicLibraryFile)
                    {
                        File.Move(oldPath, newPath);
                    }
                    else if (this is MusicLibraryDirectory)
                    {
                        Directory.Move(oldPath, newPath);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    IOException ioEx = ex as IOException;
                    var data = ioEx.Data;
                    if ((ex is UnauthorizedAccessException || ex is IOException) && UnauthorizedAccess != null)
                    {
                        success = false;
                        var unauthorisedEventArgs = new UnauthorizedAccessEventArgs(oldPath, type, ex);
                        ThrowUnauthorizedAccessException(this, unauthorisedEventArgs);
                        cancel = unauthorisedEventArgs.Cancel;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            while (!(success || cancel));
        }

        internal void ThrowUnauthorizedAccessException(object sender, UnauthorizedAccessEventArgs args)
        {
            if (UnauthorizedAccess != null)
            {
                UnauthorizedAccess.Invoke(sender, args);
            }
            else
            {
                throw args.OriginalException;
            }
        }

        internal void FireFileNameAlreadyExists(object sender, FileNameAlreadyExistsEventArgs fileNameAlreadyExistsEventArgs)
        {
            if (FileNameAlreadyExists != null)
            {
                FileNameAlreadyExists.Invoke(sender, fileNameAlreadyExistsEventArgs);
            }
            else
            {
                throw new Exception(fileNameAlreadyExistsEventArgs.Message);
            }
        }

        public static void InsertItemOrdered<T>(MusicLibraryItem item, List<T> list) where T : MusicLibraryItem
        {
            int index = 0;
            while (index < list.Count && MusicLibrary.CompareFilePaths(item.FullPath, list[index].FullPath) > 0)
            {
                index++;
            }
            list.Insert(index, (T)item);
        }

        protected string _name = String.Empty;
        protected string _directoryPath = String.Empty;
        protected MusicLibraryItem _parent;
    }

    public struct PlaylistLink
    {
        public PlaylistLink(PlaylistItem item, PlaylistItem playlist)
        {
            Item = item;
            Playlist = playlist;
        }
        public PlaylistItem Item;
        public PlaylistItem Playlist;
    }

    public class FileNameAlreadyExistsEventArgs : EventArgs
    {
        public FileNameAlreadyExistsEventArgs(string previousFileName, string newFileName)
        {
            PreviousFileName = previousFileName;
            NewFileName = newFileName;
        }
        public string PreviousFileName { get; private set; }
        public string NewFileName { get; private set; }
        public string Message
        {
            get
            {
                return "Error while trying to rename " + PreviousFileName + " into " + NewFileName + ". A file with that name already exists!";
            }
        }
    }

}
