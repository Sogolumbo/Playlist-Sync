using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Playlist
{
    public class Conversion
    {
        public Conversion()
        {
            MusicFolderPaths = new Dictionary<string, string>();
        }
        public string Title { get; set; }
        public string SourcePlaylistFolderPath { get; set; }
        public string SourcePlaylistFilterRegex { get; set; }
        public PlaylistType SourcePlaylistType { get; set; }
        public string SourcePlaylistRegex
        {
            get
            {
                string result;
                switch (SourcePlaylistType)
                {
                    case PlaylistType.M3u:
                        result = ".+\\.m3u";
                        break;
                    case PlaylistType.M3u8:
                        result = ".+\\.mu3u8";
                        break;
                    case PlaylistType.Playlistsync:
                        result = ".+\\.playlistsync(\\.txt)?";
                        break;
                    case PlaylistType.Xml:
                        result = "playlists_export_[0-9]*\\.xml";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                return result;
            }
        }
        public bool SourceUseSlashAsSeperator { get; set; }
        public Encoding GetSourceEncoding()
        { return PlaylistEncoding.GetEncoding(SourcePlaylistType); }
        public string TargetPlaylistFolderPath { get; set; }
        public PlaylistType TargetPlaylistType { get; set; }
        public bool TargetUseSlashAsSeperator { get; set; }
        public Encoding GetTargetEncoding()
        { return PlaylistEncoding.GetEncoding(TargetPlaylistType); }
        public string TargetFileNamePrefix { get; set; }
        public string TargetFileTypeSuffix { get; set; }
        /// <summary>
        /// First element: source folder, second element: target folder
        /// </summary>
        public Dictionary<string, string> MusicFolderPaths { get; set; }

        public string[] GetSourcePlaylistFiles()
        {
            string[] sourceFiles = new string[] { };
            if (!String.IsNullOrEmpty(SourcePlaylistFolderPath))
            {
                sourceFiles = Directory.GetFiles(SourcePlaylistFolderPath);
                sourceFiles = sourceFiles.Where(file => Regex.IsMatch(file, SourcePlaylistRegex)).ToArray();
            }
            if (SourcePlaylistType != PlaylistType.Xml)
            {
                return sourceFiles;
            }
            else
            {
                string[] files = sourceFiles.OrderByDescending((path) => path).ToArray();
                if (files.Length > 0)
                {
                    return new string[1] { files.First() };
                }
                else
                {
                    return new string[0] { };
                }
            }
        }


        public ConversionOutput DoConversion()
        {
            PathConverter converter = new PathConverter
            {
                MusicFolderPaths = MusicFolderPaths,
                SourceUsesSlashesAsDirectorySeperator = SourceUseSlashAsSeperator,
                TargetUsesSlashesAsDirectorySeperator = TargetUseSlashAsSeperator
            };

            Tuple<string, string[]>[] neutralPlaylists;

            // Read source playlists
            switch (SourcePlaylistType)
            {
                case PlaylistType.M3u:
                case PlaylistType.M3u8:
                case PlaylistType.Playlistsync:
                    neutralPlaylists = getPlaylistsFromM3uOrPlaylistsync(converter);
                    break;
                case PlaylistType.Xml:
                    neutralPlaylists = getPlaylistsFromSlightBackupXml(converter);
                    break;
                default:
                    throw new NotImplementedException("Error: Conversion from the Playlist type " + SourcePlaylistType.ToString() + " is not implemented yet.");
            }

            ConversionOutput output;

            // Write target playlists
            switch (TargetPlaylistType)
            {
                case PlaylistType.M3u:
                case PlaylistType.M3u8:
                case PlaylistType.Playlistsync:
                    output = WritePlaylistsAsM3uOrPlaylistsync(converter, neutralPlaylists);
                    break;
                case PlaylistType.Xml:
                    output = WritePlaylistsAsSlightBackupXml(converter, neutralPlaylists);
                    break;
                default:
                    throw new NotImplementedException("Error: Conversion to the Playlist type " + SourcePlaylistType.ToString() + " is not implemented yet.");
            }

            return output;
        }

        ConversionOutput WritePlaylistsAsM3uOrPlaylistsync(PathConverter converter, Tuple<string, string[]>[] neutralPlaylists)
        {
            string targetFile;
            List<Tuple<string, string[]>> lostSongsPerPlaylist = new List<Tuple<string, string[]>>();
            foreach (Tuple<string, string[]> PlaylistTuple in neutralPlaylists)
            {
                targetFile = Path.Combine(TargetPlaylistFolderPath, TargetFileNamePrefix + PlaylistTuple.Item1 + '.' + TargetPlaylistType.ToString().ToLower() + TargetFileTypeSuffix);
                File.WriteAllLines(targetFile, converter.GetConvertedLines(PlaylistTuple.Item2), GetTargetEncoding());
                string[] missingLines = converter.GetMissingLines();
                if (missingLines.Length > 0)
                {
                    lostSongsPerPlaylist.Add(new Tuple<string, string[]>(PlaylistTuple.Item1, missingLines));
                }
            }
            return new ConversionOutput(lostSongsPerPlaylist.ToArray());
        }
        ConversionOutput WritePlaylistsAsSlightBackupXml(PathConverter converter, Tuple<string, string[]>[] neutralPlaylists)
        {
            DateTime now = DateTime.Now;
            string currentDate = GetUnixDate(DateTime.Now).ToString();
            string currentShortDate = ((long)GetUnixDate(DateTime.Now) / 1000).ToString();
            string targetFile = Path.Combine(TargetPlaylistFolderPath, TargetFileNamePrefix + "playlists_export_pc_" + currentDate + "." + TargetPlaylistType.ToString().ToLower() + TargetFileTypeSuffix);
            List<Tuple<string, string[]>> lostSongsPerPlaylist = new List<Tuple<string, string[]>>();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("  ");
            using (XmlWriter writer = XmlWriter.Create(targetFile, settings))
            {
                writer.WriteStartElement("playlists");
                writer.WriteAttributeString("date", currentDate);
                writer.WriteAttributeString("count", neutralPlaylists.Length.ToString());

                foreach (Tuple<string, string[]> PlaylistTuple in neutralPlaylists)
                {
                    writer.WriteStartElement("playlist", "");
                    writer.WriteAttributeString("_data", "/storage/emulated/0/Playlists/" + PlaylistTuple.Item1);
                    writer.WriteAttributeString("name", PlaylistTuple.Item1);
                    writer.WriteAttributeString("date_added", currentShortDate);
                    foreach (string line in converter.GetConvertedLines(PlaylistTuple.Item2))
                    {
                        writer.WriteStartElement("file", "");
                        writer.WriteAttributeString("_data", line);
                        writer.WriteEndElement();
                    }
                    string[] missingLines = converter.GetMissingLines();
                    if (missingLines.Length > 0)
                    {
                        lostSongsPerPlaylist.Add(new Tuple<string, string[]>(PlaylistTuple.Item1, missingLines));
                    }
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.Flush();
            }
            return new ConversionOutput(lostSongsPerPlaylist.ToArray());
        }

        Tuple<string, string[]>[] getPlaylistsFromM3uOrPlaylistsync(PathConverter converter)
        {
            string cleanFileName;
            List<Tuple<string, string[]>> result = new List<Tuple<string, string[]>>();
            foreach (string sourceFile in GetSourcePlaylistFiles())
            {
                cleanFileName = Path.GetFileNameWithoutExtension(sourceFile);
                cleanFileName = Regex.Replace(cleanFileName, @"^(Synced - )*([^.]+)(.playlistsync)?$", @"$2"); //Clean name
                string[] rawLines = File.ReadAllLines(sourceFile, GetSourceEncoding());
                string[] cleanLines = rawLines.Where(line => (line.Length > 0) && (line[0] != '#')).ToArray();
                result.Add(new Tuple<string, string[]>(cleanFileName, cleanLines));
            }
            return result.ToArray();
        }

        Tuple<string, string[]>[] getPlaylistsFromSlightBackupXml(PathConverter converter)
        {
            List<Tuple<string, string[]>> result = new List<Tuple<string, string[]>>();
            string xmlFile = GetSourcePlaylistFiles()[0];

            bool inPlaylistsNode = false;
            int playlistCounter = 0; //used to check whether the amount of read playlists is correct
            int expectedPlaylistCount = -1;
            string playlistName = null;
            List<string> fileNames = new List<string>(0);
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "playlists")
                            {
                                inPlaylistsNode = true;
                                expectedPlaylistCount = int.Parse(reader.GetAttribute("count"));
                            }
                            else if (inPlaylistsNode)
                            {
                                switch (reader.Name)
                                {
                                    case "playlist":
                                        playlistName = reader.GetAttribute("name");
                                        fileNames = new List<string>();
                                        break;
                                    case "file":
                                        fileNames.Add(reader.GetAttribute("_data"));
                                        break;
                                    default:
                                        throw new NotImplementedException("Unexpected xml node in playlists: " + reader.Name);
                                }
                            }

                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == "playlists")
                            {
                                inPlaylistsNode = false;
                            }
                            else if (inPlaylistsNode && reader.Name == "playlist")
                            {
                                result.Add(new Tuple<string, string[]>(playlistName, fileNames.ToArray()));
                                playlistCounter++;
                            }
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.Whitespace:
                            break; //Ignore
                        case XmlNodeType.Text:
                        default:
                            throw new NotImplementedException("Unexpected xml node type: " + reader.NodeType.ToString());
                    }
                }
            }
            if (inPlaylistsNode == true)
            {
                throw new Exception("Error while parsing backup: the playlists element was not closed.");
            }
            if (playlistCounter - expectedPlaylistCount != 0)
            {
                throw new Exception("Error while parsing backup: found " + playlistCounter + " playlists when expecting " + expectedPlaylistCount + ".");
            }
            return result.ToArray();
        }


        private long GetUnixDate(DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)unixTime.TotalMilliseconds;
        }
    }

    public class ConversionOutput
    {
        public ConversionOutput(Tuple<string, string[]>[] lostSongsPerPlaylist)
        {
            LostSongsPerPlaylist = lostSongsPerPlaylist;
        }
        public Tuple<string, string[]>[] LostSongsPerPlaylist { get; private set; }
    }
}
