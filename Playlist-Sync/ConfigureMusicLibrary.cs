using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaylistConverterGUI
{
    public partial class ConfigureMusicLibrary : Form
    {
        public ConfigureMusicLibrary(List<string> playlists, List<string> folders)
        {
            InitializeComponent();
            Playlists = playlists;
            Folders = folders;
            playlistListBox.Tag = Playlists;
            foldersListBox.Tag = Folders;
            ShowEntries();
            foldersListBox.Focus();
        }

        private void ShowEntries()
        {
            playlistListBox.Items.Clear();
            playlistListBox.Items.AddRange(Playlists.ToArray());
            if(playlistListBox.Items.Count > 0)
                playlistListBox.SelectedIndex = 0;
            foldersListBox.Items.Clear();
            foldersListBox.Items.AddRange(Folders.ToArray());
            if (foldersListBox.Items.Count > 0)
                foldersListBox.SelectedIndex = 0;
        }

        public List<string> Playlists { get; set; }
        public List<string> Folders{ get; set; }

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                Folders.Add(folderBrowserDialog.SelectedPath);
                ShowEntries();
            }
        }

        private void foldersListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedFolderFilepathLabel.Text = foldersListBox.SelectedItem?.ToString();
            removeSelectedFolderButton.Tag = foldersListBox.SelectedItem;
            removeSelectedFolderButton.Enabled = true;
        }

        private void removeSelectedFolderButton_Click(object sender, EventArgs e)
        {
            Folders.Remove((string)removeSelectedFolderButton.Tag);
            removeSelectedFolderButton.Enabled = false;
            ShowEntries();
            foldersListBox.Focus();
        }

        private void removeSelectedPlaylistButton_Click(object sender, EventArgs e)
        {
            Playlists.Remove((string)removeSelectedPlaylistButton.Tag);
            removeSelectedPlaylistButton.Enabled = false;
            ShowEntries();
            playlistListBox.Focus();
        }

        private void AddPlaylistButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openPlaylistDialog.ShowDialog())
            {
                Playlists.AddRange(openPlaylistDialog.FileNames);
                ShowEntries();
            }
        }

        private void playlistsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedPlaylistFilepathLabel.Text = playlistListBox.SelectedItem?.ToString();
            removeSelectedPlaylistButton.Tag = playlistListBox.SelectedItem;
            removeSelectedPlaylistButton.Enabled = true;
        }
    }
}
