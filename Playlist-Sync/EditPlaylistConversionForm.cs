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
            sourceMusicFolderTextBox.Text = conversion.SourceMusicFolderPath;
            sourceUseSlashAsSeperatorCheckBox.Checked = conversion.SourceUseSlashAsSeperator;
            targetPlaylistFolderTextBox.Text = conversion.TargetPlaylistFolderPath;
            targetPlaylistTypeComboBox.Text = conversion.TargetPlaylistType.ToString();
            targetMusicFolderTextBox.Text = conversion.TargetMusicFolderPath;
            targetUseSlashAsSeperatorCheckBox.Checked = conversion.TargetUseSlashAsSeperator;
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
            Conversion.SourceMusicFolderPath = sourceMusicFolderTextBox.Text;
            Conversion.SourceUseSlashAsSeperator = sourceUseSlashAsSeperatorCheckBox.Checked;
            Conversion.TargetPlaylistFolderPath = targetPlaylistFolderTextBox.Text;
            Conversion.TargetPlaylistType = (PlaylistType)targetPlaylistTypeComboBox.SelectedItem;
            Conversion.TargetMusicFolderPath = targetMusicFolderTextBox.Text;
            Conversion.TargetUseSlashAsSeperator = targetUseSlashAsSeperatorCheckBox.Checked;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
