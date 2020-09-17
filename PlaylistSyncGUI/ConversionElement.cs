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
            var sourcefiles = Conversion.GetSourcePlaylistFiles().Select(filePath => Path.GetFileName(filePath)).ToArray();
            PlaylistNamesLabel.Text = sourcefiles.Length + " files: " + String.Join(", ", sourcefiles);
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
            ConversionOutput output = Conversion.DoConversion();
            
            foreach (var tuple in output.LostSongsPerPlaylist)
            {
                string playlistName = Path.GetFileNameWithoutExtension(tuple.Item1);
                string missingLines = String.Join("\n", tuple.Item2);
                string caption = "Error while converting the playlist \"" + playlistName + "\"!";
                string text = "The following songs/lines are left out in the playlist \"" + playlistName + "\":\n" + missingLines;
                MessageBox.Show(text, caption);
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
