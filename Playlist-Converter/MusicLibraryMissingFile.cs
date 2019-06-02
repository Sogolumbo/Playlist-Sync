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
        public MusicLibraryMissingElement(string fullPath, PlaylistLink playlistLink, MusicLibraryItem parent) : base ()
        {
            _name = Path.GetFileName(fullPath);
            _directoryPath = fullPath.Remove(fullPath.Length - 1 - Name.Length);
            PlaylistItems.Add(playlistLink);
            Children = new List<MusicLibraryMissingElement>();
            Parent = parent;
        }

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
                    _name = value;
                    foreach (var playlistLink in PlaylistItems)
                    {
                        playlistLink.Item.ChangeName(Name, false);
                    }
                    LocationChange();
                    if (File.Exists(value) || Directory.Exists(value))
                    {
                        Found?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public List<MusicLibraryMissingElement> Children { get; set; }

        public event EventHandler Found;
    }
}
