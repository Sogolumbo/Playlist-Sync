using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PlaylistConverterGUI
{
    public partial class PlaylistConverterPreviewForm : Form
    {
        public PlaylistConverterPreviewForm()
        {
            InitializeComponent();
            targetFileMusicFolderTextBox.Text = Properties.Settings.Default.TargetMusicFolder;
            targetFilePathTextBox.Text = Properties.Settings.Default.TargetPlaylistFilePath;
            sourceFilePathTextBox.Text = Properties.Settings.Default.SourcePlalyistFilePath;
        }

        Playlist.PathConverter _converter = new Playlist.PathConverter();

        private void openSourceFileButton_Click(object sender, EventArgs e)
        {
            var result = openSourceFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                sourceFilePathTextBox.Text = openSourceFileDialog.FileName;
                sourceFilePreviewLabel.Text = "Preview (raw file)";
                sourceFilePreviewRichTextBox.Text = File.ReadAllText(openSourceFileDialog.FileName);
                if (String.IsNullOrWhiteSpace(sourceFileMusicFolderTextBox.Text))
                {
                    sourceFileMusicFolderTextBox.Text = Playlist.CommonPathGuesser.Path(openSourceFileDialog.FileName, 0.95f);
                    if (!String.IsNullOrWhiteSpace(sourceFileMusicFolderTextBox.Text))
                    {
                        PreviewSource();
                    }
                }
            }
        }

        private void sourceFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(sourceFilePathTextBox.Text))
            {
                openSourceFileDialog.FileName = sourceFilePathTextBox.Text;
                sourceFilePathTextBox.BackColor = SystemColors.Window;
                Properties.Settings.Default.SourcePlalyistFilePath = sourceFilePathTextBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                sourceFilePathTextBox.BackColor = Color.FromArgb(255, 200, 200); //Red
            }
        }

        private void sourceFilePreviewButton_Click(object sender, EventArgs e)
        {
            PreviewSource();
        }

        private void PreviewSource()
        {
            sourceFilePreviewLabel.Text = "Preview (platform independent preview)";
            sourceFilePreviewRichTextBox.Text = String.Join("\n", _converter.GetNeutralLines(openSourceFileDialog.FileName));

        }

        private void sourceFileMusicFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            _converter.SourceMusicFolderPath = sourceFileMusicFolderTextBox.Text;
        }

        private void sorceFileUsesSlashAsDirectorySeperatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _converter.SourceUsesSlashesAsDirectorySeperator = sourceFileUsesSlashAsDirectorySeperatorCheckBox.Checked;
            PreviewSource();
        }

        private void targetFileSaveDialogButton_Click(object sender, EventArgs e)
        {
            var result = saveTargetFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                targetFilePathTextBox.Text = saveTargetFileDialog.FileName;
            }
        }

        private void targetFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            saveTargetFileDialog.FileName = targetFilePathTextBox.Text;
            saveConvertedPlaylistButton.Enabled = true;
            Properties.Settings.Default.TargetPlaylistFilePath = targetFilePathTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void targetFilePreviewButton_Click(object sender, EventArgs e)
        {
            PreviewTargetFile();
        }

        private void PreviewTargetFile()
        {
            if (!String.IsNullOrWhiteSpace(openSourceFileDialog.FileName))
            {
                targetFilePreviewRichTextBox.Text = String.Join("\n", _converter.GetConvertedLines(openSourceFileDialog.FileName));
            }
        }

        private void saveConvertedPlaylistButton_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(saveTargetFileDialog.FileName, _converter.GetConvertedLines(openSourceFileDialog.FileName));
            String[] LostLines = _converter.GetMissingLines();
            if (LostLines.Length > 0)
            {
                MessageBox.Show("The following lines are left out in the converted playlist: \n" + String.Join("\n", LostLines), "Error while converting the playlist!");
            }
        }

        private void targetFileMusicFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            _converter.TargetMusicFolderPath = targetFileMusicFolderTextBox.Text;
            PreviewTargetFile();
            Properties.Settings.Default.TargetMusicFolder = targetFileMusicFolderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void targetFileUsesSlashAsDirectorySeperatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _converter.TargetUsesSlashesAsDirectorySeperator = targetFileUsesSlashAsDirectorySeperatorCheckBox.Checked;
            PreviewTargetFile();
        }

    }
}
