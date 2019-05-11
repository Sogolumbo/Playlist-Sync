namespace Playlist
{
    public class MusicLibraryFile : MusicLibraryItem
    {
        public AudioFileType Type { get; set; }
    }

    public enum AudioFileType
    {
        mp3,
        wma,
        wav,
        m4a
    }
}
