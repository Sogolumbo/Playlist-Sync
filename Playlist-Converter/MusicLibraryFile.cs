using System;
using System.IO;
using System.Linq;

namespace Playlist
{
    public class MusicLibraryFile : MusicLibraryItem
    {
        public MusicLibraryFile(string fullPath, AudioFileType type, MusicLibraryDirectory parent)
        {
            Type = type;
            _name = Path.GetFileName(fullPath);
            _directoryPath = fullPath.Remove(fullPath.Length - 1 - _name.Length);
            Tag = new AudioFileTag(fullPath);
            Parent = parent;
            Tag.UnauthorizedAccess += ThrowUnauthorizedAccessException;
            Tag.AlbumChanged += Tag_AlbumChanged;
            Tag.ArtistChanged += Tag_ArtistChanged;
        }

        private void Tag_ArtistChanged(object sender, NameChangedEventArgs e)
        {
            ChangeLinkedNodeName(ArtistLink, Tag.Artist);
        }
        private void Tag_AlbumChanged(object sender, NameChangedEventArgs e)
        {
            ChangeLinkedNodeName(AlbumLink, Tag.Album);
        }
        private void ChangeLinkedNodeName(NodeLink nodeLink, string nodeText)
        {
            switch (nodeLink)
            {
                case NodeLink.Parent:
                    Parent.Name = nodeText;
                    break;
                case NodeLink.ParentOfParent:
                    Parent.Parent.Name = nodeText;
                    break;
                case NodeLink.None:
                default:
                    SetNodeLinks();
                    break;
            }
        }

        public AudioFileType Type { get; set; }
        public AudioFileTag Tag { get; set; }
        public NodeLink AlbumLink { get; private set; }
        public NodeLink ArtistLink { get; private set; }

        public override MusicLibraryDirectory Parent
        {
            get => base.Parent;
            set
            {
                bool parentChanged = (value != _parent);
                base.Parent = value;
                if (parentChanged)
                {
                    value.NameChanged += Parent_NameChanged;
                    _parent.NameChanged -= Parent_NameChanged;
                    _parent.ParentChanged += _parent_ParentChanged;
                    SetNodeLinks();
                }
            }
        }

        private void _parent_ParentChanged(object sender, EventArgs e)
        {
            Parent.Parent.NameChanged += Parent_NameChanged;
        }

        private void Parent_NameChanged(object sender, NameChangedEventArgs e)
        {
            SetNodeLinks();
        }

        protected override void LocationChange()
        {
            base.LocationChange();
            Tag.FilePath = FullPath;
        }

        private void SetNodeLinks()
        {
            AlbumLink = NodeLink.None;
            ArtistLink = NodeLink.None;

            if (Parent.Parent != null)
            {
                Parent.Parent.NameChanged -= AlbumNode_NameChanged;
                Parent.Parent.NameChanged -= ArtistNode_NameChanged;
                if (Array.IndexOf(Tag.Artists, Parent.Parent.Name) != -1)
                {
                    if (Parent.Parent.Name == Tag.Artist)
                    {
                        ArtistLink = NodeLink.ParentOfParent;
                        Parent.Parent.NameChanged += ArtistNode_NameChanged;
                    }
                    else
                    {
                        ArtistLink = NodeLink.ParentOfParentPartially;
                        //TODO NameChanged Events
                    }
                }
                else if (Parent.Parent.Name == Tag.Album)
                {
                    AlbumLink = NodeLink.ParentOfParent;
                    Parent.Parent.NameChanged += AlbumNode_NameChanged;
                }
            }
            if (Parent != null)
            {
                Parent.NameChanged -= AlbumNode_NameChanged;
                Parent.NameChanged -= ArtistNode_NameChanged;

                if (((ArtistLink == NodeLink.None && Array.IndexOf(Tag.Artists, Tag.Album) != -1) || Parent.Name != Tag.Album) && Array.IndexOf(Tag.Artists, Parent.Name) != -1) // special case album==artist and parent of parent is not named after artist
                {
                    if (Parent.Name == Tag.Artist)
                    {
                        ArtistLink = NodeLink.Parent;
                        Parent.NameChanged += ArtistNode_NameChanged;
                    }
                    else
                    {
                        ArtistLink = NodeLink.ParentPartially;
                        //TODO NameChanged Events
                    }
                }
                else if (Parent.Name == Tag.Album)
                {
                    AlbumLink = NodeLink.Parent;
                    Parent.NameChanged += AlbumNode_NameChanged;
                }
            }
        }

        public override void Reload()
        {
            base.Reload();
            SetNodeLinks();
        }

        private void ArtistNode_NameChanged(object sender, NameChangedEventArgs e)
        {
            Tag.Artist = (sender as MusicLibraryDirectory).Name;
        }

        private void AlbumNode_NameChanged(object sender, NameChangedEventArgs e)
        {
            Tag.Album = (sender as MusicLibraryDirectory).Name;
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                Tag.FilePath = FullPath;
            }
        }
    }

    public enum AudioFileType
    {
        mp3,
        wma,
        wav,
        m4a
    }
}
