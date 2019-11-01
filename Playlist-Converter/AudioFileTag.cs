using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class AudioFileTag
    {
        public AudioFileTag(string fullPath)
        {
            try
            {
                ReadFromFile(fullPath);
            }
            catch (ArgumentOutOfRangeException) { } //TODO
        }
        public AudioFileTag()
        {
            Empty = true;
            _artists = new string[0];
        }


        private TagLib.File _tagLib;
        private string _filePath;

        private string _title = String.Empty;
        private string _album = String.Empty;
        private string[] _artists = new string[0];
        private uint? _trackNumber = null;
        private string[] _genres = new string[0];


        public event EventHandler<UnauthorizedAccessEventArgs> UnauthorizedAccess;
        public event EventHandler<NameChangedEventArgs> ArtistChanged;
        public event EventHandler<NameChangedEventArgs> AlbumChanged;


        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (Empty)
                {
                    if (System.IO.File.Exists(value))
                    {
                        ReadFromFile(value);
                    }
                }
                else
                {
                    _filePath = value;
                    _tagLib = TagLib.File.Create(value);
                }
            }
        }
        public bool Empty { get; private set; }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    _tagLib.Tag.Title = _title;
                    SaveTag();
                }
            }
        }

        public string Album
        {
            get { return _album; }
            set
            {
                if (value != _album)
                {
                    _album = value;
                    _tagLib.Tag.Album = _album;
                    SaveTag();
                    AlbumChanged?.Invoke(this, new NameChangedEventArgs(value, true));
                }
            }
        }
        public string Artist
        {
            get { return String.Join("; ", Artists); }
            set
            {
                Artists = value.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public string[] Artists
        {
            get => _artists;
            set
            {
                if (!Enumerable.SequenceEqual(value, _artists))
                {
                    _artists = value;
                    _tagLib.Tag.Performers = _artists;
                    SaveTag();
                    ArtistChanged?.Invoke(this, new NameChangedEventArgs(Artist, true));
                }
            }
        }
        public uint? Nr
        {
            get { return _trackNumber; }
            set
            {
                bool saveNewTracknumber = (value != _trackNumber) && value != null;
                _trackNumber = value;
                if (saveNewTracknumber)
                {
                    _tagLib.Tag.Track = value.Value;
                    SaveTag();
                }
            }
        }
        public string Genre
        {
            get { return String.Join("; ", Genres); }
            set
            {
                var Genres = value.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public string[] Genres
        {
            get => _genres;
            set
            {
                if (!Array.Equals(value, _genres))
                {
                    _genres = value;
                    _tagLib.Tag.Genres = _genres;
                    SaveTag();
                }
            }
        }


        private void SaveTag()
        {
            try
            {
                _tagLib.Save();
            }
            catch (Exception ex)
            {
                if (ex is System.IO.IOException && UnauthorizedAccess != null)
                {
                    UnauthorizedAccess?.Invoke(this, new UnauthorizedAccessEventArgs(FilePath, PlaylistItemType.Song, ex));
                }
                else
                {
                    throw;
                }
            }
        }
        private void ReadFromFile(string fullPath)
        {
            _filePath = fullPath;

            _tagLib = TagLib.File.Create(fullPath);
            _title = _tagLib.Tag.Title;
            _album = _tagLib.Tag.Album;
            _artists = _tagLib.Tag.Performers;
            _trackNumber = _tagLib.Tag.Track;
            _genres = _tagLib.Tag.Genres;

            Empty = false;
        }
    }
}
