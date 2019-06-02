using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Playlist;

namespace PlaylistConverterGUI
{
    public partial class EditPlaylistConversionForm : Form
    {
        public EditPlaylistConversionForm(Conversion conversion)
        {
            InitializeComponent();

            sourcePlaylistTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistType));
            targetPlaylistTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistType));

            Conversion = conversion;
            titleTextBox.Text = conversion.Title;
            sourcePlaylistFolderTextBox.Text = conversion.SourcePlaylistFolderPath;
            sourcePlaylistTypeComboBox.Text = conversion.SourcePlaylistType.ToString();
            sourceUseSlashAsSeperatorCheckBox.Checked = conversion.SourceUseSlashAsSeperator;
            targetPlaylistFolderTextBox.Text = conversion.TargetPlaylistFolderPath;
            targetPlaylistTypeComboBox.Text = conversion.TargetPlaylistType.ToString();
            targetUseSlashAsSeperatorCheckBox.Checked = conversion.TargetUseSlashAsSeperator;
            MusicFolderPaths = new Dictionary<string, string> (conversion.MusicFolderPaths);
        }

        private Dictionary<string, string> _musicFolderPaths;

        Dictionary<string, string> MusicFolderPaths
        {
            get { return _musicFolderPaths; }
            set
            {
                _musicFolderPaths = value;
                SetConversionElements();
            }
        }

        private void SetConversionElements()
        {
            conversionsFlowLayoutPanel.Controls.Clear();
            foreach (var pair in MusicFolderPaths)
            {
                FolderLinkElement convElement = new FolderLinkElement(pair);
                convElement.Width = conversionElementWidth();
                conversionsFlowLayoutPanel.Controls.Add(convElement);
                convElement.Remove += ConvElement_Remove;
                convElement.Changed += ConvElement_Changed;
            }
        }

        private void ConvElement_Changed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConvElement_Remove(object sender, EventArgs e)
        {
            var folderLink = (sender as FolderLinkElement).FolderLink;
            MusicFolderPaths.Remove(folderLink.Key);
        }

        private int conversionElementWidth()
        {
            return conversionsFlowLayoutPanel.Width - 25;
        }


        public Conversion Conversion { get; private set; }
        public event EventHandler OK;

        private void OKButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
            OK(this, EventArgs.Empty);
            Close();
        }

        private void SaveChanges()
        {
            Conversion.Title = titleTextBox.Text;
            Conversion.SourcePlaylistFolderPath = sourcePlaylistFolderTextBox.Text;
            Conversion.SourcePlaylistType = (PlaylistType)sourcePlaylistTypeComboBox.SelectedItem;
            Conversion.SourceUseSlashAsSeperator = sourceUseSlashAsSeperatorCheckBox.Checked;
            Conversion.TargetPlaylistFolderPath = targetPlaylistFolderTextBox.Text;
            Conversion.TargetPlaylistType = (PlaylistType)targetPlaylistTypeComboBox.SelectedItem;
            Conversion.TargetUseSlashAsSeperator = targetUseSlashAsSeperatorCheckBox.Checked;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
