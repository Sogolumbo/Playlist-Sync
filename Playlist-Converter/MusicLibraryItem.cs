using System;
using System.Collections.Generic;
using System.IO;

namespace Playlist
{
    public class MusicLibraryItem
    {
        public MusicLibraryItem()
        {
            PlaylistItems = new List<PlaylistLink>();
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
                    if(value.ToLower() == _name.ToLower())
                    {
                        var temporaryName = "temp_" + value;
                        ChangeFileSystemName(temporaryName);
                        _name = temporaryName;
                    }
                    ChangeFileSystemName(value);
                    _name = value;
                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangeName(Name, false);
                    }
                    LocationChange();
                }
            }
        }

        protected virtual void LocationChange()
        {
            
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
        public virtual MusicLibraryDirectory Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                ParentChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public List<PlaylistLink> PlaylistItems { get; set; }

        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;
        public event EventHandler ParentChanged;

        public virtual void Reload()
        {
            foreach (var item in PlaylistItems)
            {
                item.Item.RescanMediaInfo(true);
            }
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
                    if (GetType() == typeof(MusicLibraryFile))
                    {
                        File.Move(FullPath, DirectoryPath + "\\" + newName);
                    }
                    else if (GetType() == typeof(MusicLibraryDirectory))
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
        protected MusicLibraryDirectory _parent;
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
