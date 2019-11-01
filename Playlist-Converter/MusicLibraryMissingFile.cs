using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class MusicLibraryMissingElement : MusicLibraryItem
    {
        public MusicLibraryMissingElement(string fullPath, PlaylistLink playlistLink, MusicLibraryItem parent) : base()
        {
            _name = Path.GetFileName(fullPath);
            _directoryPath = fullPath.Remove(fullPath.Length - 1 - Name.Length);
            PlaylistItems.Add(playlistLink);
            Children = new List<MusicLibraryMissingElement>();
            Parent = parent;
        }


        public event EventHandler Found;


        public override string Name
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
                    List<MusicLibraryItem> neighbours = null;
                    if (Parent is MusicLibraryDirectory)
                        neighbours = (Parent as MusicLibraryDirectory).Children.ToList();
                    else if (Parent is MusicLibraryMissingElement)
                        neighbours = (Parent as MusicLibraryMissingElement).Children.ToList<MusicLibraryItem>();
                    neighbours.Remove(this);
                    var index = Array.IndexOf(neighbours.Select(item => item.Name).ToArray(), value);
                    if (index != -1) //already exists
                    {
                        if (neighbours[index].Name != value) //TODO remove if error never occurs
                        {
                            throw new Exception();
                        }
                        if (neighbours[index] is MusicLibraryMissingElement && (neighbours[index] as MusicLibraryMissingElement).Type == PlaylistItemType.Song)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            foreach (var link in PlaylistItems)
                            {
                                neighbours[index].PlaylistItems.Add(link);
                            }
                            if (Children.Count > 0)
                            {
                                AttachItemsTo(neighbours[index], Children);
                            }

                            if (Parent is MusicLibraryDirectory)
                            {
                                if (Type == PlaylistItemType.Folder)
                                {
                                    (Parent as MusicLibraryDirectory).Directories.Remove(this);
                                }
                                if (Type == PlaylistItemType.Song)
                                {
                                    (Parent as MusicLibraryDirectory).Files.Remove(this);
                                }
                            }
                            else if (Parent is MusicLibraryMissingElement)
                            {
                                (Parent as MusicLibraryMissingElement).Children.Remove(this);
                            }
                            //TODO force reload
                        }
                    }
                    _name = value;
                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangeName(value, false);
                    }
                    foreach (var item in Children)
                    {
                        item.DirectoryPath = FullPath;
                    }
                    LocationChange();
                }
            }
        }

        public List<MusicLibraryMissingElement> Children { get; set; }

        public PlaylistItemType Type
        {
            get => PlaylistItems.First().Item.Type;
        }

        protected override void LocationChange()
        {
            foreach (MusicLibraryItem item in Children)
            {
                item.DirectoryPath = FullPath;
            }
            CheckExistence();
            base.LocationChange();
        }

        internal void CheckExistence()
        {
            if (File.Exists(FullPath) || Directory.Exists(FullPath))
            {
                Found?.Invoke(this, EventArgs.Empty);
            }
        }

        internal override void MoveFilesystemItem(string oldPath, string newPath)
        {
            
        }

        public override void Reload()
        {
            CheckExistence();
            base.Reload();
        }
    }
}
