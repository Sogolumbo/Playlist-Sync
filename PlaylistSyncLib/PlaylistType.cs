using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Playlist
{
    public enum PlaylistType
    {
        Playlistsync,
        M3u,
        M3u8,
        Xml  // this type specifies .xml files exported by the "Slight Backup" Android app (https://github.com/airon90/Slight-backup)
    }

    public static class PlaylistEncoding
    {
        public static Encoding GetEncoding(PlaylistType type)
        {
            switch (type)
            {
                case PlaylistType.M3u:
                    return Encoding.Default; //previously Encoding.GetEncoding(1252);

                case PlaylistType.Playlistsync:
                case PlaylistType.M3u8:
                case PlaylistType.Xml:
                    return Encoding.UTF8;

                default:
                    throw new NotImplementedException();
            }
        }
        public static Encoding GetEncoding(string path)
        {
            PlaylistType type = (PlaylistType) Enum.Parse(typeof(Playlist.PlaylistType), Path.GetExtension(path).Replace(".", ""), true);
            return GetEncoding(type);
        }
    }
}