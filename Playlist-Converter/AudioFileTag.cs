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
            ReadFromFile(fullPath);
        }
        public AudioFileTag()
        {
            Empty = true;
        }


        private TagLib.File _tagLib;
        private string _filePath;

        private string _title;
        private string _album;
        private string _artist;
        private uint? _trackNumber;
        private string _genre;


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
            get { return _artist; }
            set
            {
                if (value != _artist)
                {
                    _artist = value;
                    var artists = _artist.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    _tagLib.Tag.Performers = artists;
                    SaveTag();
                    ArtistChanged?.Invoke(this, new NameChangedEventArgs(value, true));
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
            get { return _genre; }
            set
            {
                if (value != _genre)
                {
                    _genre = value;
                    var genres = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    _tagLib.Tag.Genres = genres;
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
            _artist = String.Join("; ", _tagLib.Tag.Performers);
            _trackNumber = _tagLib.Tag.Track;
            _genre = String.Join("; ", _tagLib.Tag.Genres);

            Empty = false;
        }
    }
}
