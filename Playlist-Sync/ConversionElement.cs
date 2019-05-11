using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Playlist;
using System.IO;
using System.Text.RegularExpressions;

namespace PlaylistConverterGUI
{
    public partial class ConversionElement : UserControl
    {
        public ConversionElement(Conversion conversion)
        {
            Conversion = conversion;
            InitializeComponent();
            titleLabel.Text = conversion.Title;
            sourcePathLabel.Text = conversion.SourcePlaylistFolderPath;
            sourceTypeLabel.Text = conversion.SourcePlaylistType.ToString();
            targetPathLabel.Text = conversion.TargetPlaylistFolderPath;
            targetTypeLabel.Text = conversion.TargetPlaylistType.ToString();
        }

        public Conversion Conversion { get; set; }
        public event EventHandler<ConversionEventArgs> Remove;
        public event EventHandler<ConversionEventArgs> Edit;

        private void ConversionElement_Load(object sender, EventArgs e)
        {
            titleLabel.Font = new Font(Font.FontFamily, Font.Size * 1.25f);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            Remove(this, new ConversionEventArgs(Conversion));
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Edit(this, new ConversionEventArgs(Conversion));
        }

        private void convertPlaylistsButton_Click(object sender, EventArgs e)
        {
            string[] sourceFiles = Directory.GetFiles(Conversion.SourcePlaylistFolderPath);
            sourceFiles = sourceFiles.Where(file => Regex.IsMatch(file, ".+(\\.playlistsync)?\\.(txt|m3u|playlistsync)")).ToArray();
            PathConverter converter = new PathConverter
            {
                SourceMusicFolderPath = Conversion.SourceMusicFolderPath,
                SourceUsesSlashesAsDirectorySeperator = Conversion.SourceUseSlashAsSeperator,
                TargetMusicFolderPath = Conversion.TargetMusicFolderPath,
                TargetUsesSlashesAsDirectorySeperator = Conversion.TargetUseSlashAsSeperator
            };

            string targetFile;
            foreach (string sourceFile in sourceFiles)
            {
                targetFile = Path.GetFileNameWithoutExtension(sourceFile);
                targetFile = "Synced - " + Regex.Replace(targetFile, ".playlistsync", String.Empty);
                targetFile = Path.Combine(Conversion.TargetPlaylistFolderPath, targetFile + '.' + Conversion.TargetPlaylistType.ToString().ToLower());
                File.WriteAllLines(targetFile, converter.GetConvertedLines(sourceFile));
                String[] LostLines = converter.GetMissingLines();
                if (LostLines.Length > 0)
                {
                    MessageBox.Show("The following lines are left out in the playlist \"" + Path.GetFileNameWithoutExtension(sourceFile) + "\":\n" + String.Join("\n", LostLines), "Error while converting the playlist \"" + Path.GetFileNameWithoutExtension(sourceFile) + "\"!");
                }
            }
        }
    }

    public class ConversionEventArgs : EventArgs
    {
        public ConversionEventArgs(Conversion conversion)
        {
            Conversion = conversion;
        }

        public Conversion Conversion { get; set; }
    }
}
