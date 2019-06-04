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
                    if (Parent != null && (Parent as MusicLibraryDirectory).Directories.Select(dir => dir.Name).Contains(value))
                    {
                        if (IsFile())
                        {
                            throw new NotImplementedException(); //fire custom "file already exists" event
                        }
                        else if(this is MusicLibraryMissingElement) // missing folder
                        {
                            var dir = this as MusicLibraryMissingElement;
                            throw new NotImplementedException(); //join the two directories
                        }
                        else // existing folder
                        {
                            var dir = this as MusicLibraryDirectory;
                            throw new NotImplementedException(); //join the two directories
                        }
                    }
                    else
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
                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangeName(Name, false);
                    }
                    LocationChange();
                }
            }
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

        public virtual void Reload()
        {

        }

        public override string ToString()
        {
            return Name;
        }

        protected virtual void ChangeFileSystemName(string newName)
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
                        File.Move(FullPath, DirectoryPath + "\\" + newName);
                    }
                    else if (this is MusicLibraryDirectory)
                    {
                        Directory.Move(FullPath, DirectoryPath + "\\" + newName);
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
                        var unauthorisedEventArgs = new UnauthorizedAccessEventArgs(FullPath, type, ex);
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
        protected void ThrowUnauthorizedAccessException(object sender, UnauthorizedAccessEventArgs args)
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
}
