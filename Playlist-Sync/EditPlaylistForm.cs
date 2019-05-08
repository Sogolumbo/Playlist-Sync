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
using System.IO;

namespace PlaylistConverterGUI
{
    public partial class EditPlaylistForm : Form
    {
        public EditPlaylistForm()
        {
            InitializeComponent();
            OpenPlaylistDialog();
            itemTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistItemType));
        }
        public EditPlaylistForm(string playlistFilePath)
        {
            InitializeComponent();
            ShowPlaylist(playlistFilePath);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenPlaylistDialog();
        }

        private void OpenPlaylistDialog()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ShowPlaylist(openFileDialog.FileName);
            }
        }

        private void ShowPlaylist(string filePath)
        {
            string[] playlistLines = System.IO.File.ReadAllLines(filePath);
            var fileName = System.IO.Path.GetFileName(filePath);
            PlaylistItem Playlist = new PlaylistItem(playlistLines, fileName, filePath.Replace("\\" + fileName, ""), null);
            ShowPlaylist(Playlist);
        }
        private void ShowPlaylist(PlaylistItem Playlist)
        {
            playlistTreeView.Nodes.Clear();
            playlistTreeView.Tag = Playlist;
            playlistTreeView.Nodes.Add(NodeFromPlaylistItem(Playlist));
            playlistTreeView.ExpandAll();
            playlistTreeView.SelectedNode = playlistTreeView.TopNode;

            playlistNameTextBox.Text = Playlist.Name;
            playlistPathLabel.Text = Playlist.Path;
        }

        private TreeNode NodeFromPlaylistItem(PlaylistItem playlistItem)
        {
            TreeNode result;

            if (playlistItem.Children != null)
                result = new TreeNode(playlistItem.Name, playlistItem.Children?.Select(item => NodeFromPlaylistItem(item)).ToArray());
            else
                result = new TreeNode(playlistItem.Name);

            result.Tag = playlistItem;
            if (playlistItem.ItemExists == false)
            {
                result.BackColor = Color.DarkRed;
                result.ForeColor = Color.White;
            }
            else
            {
                if (playlistItem.Type == PlaylistItemType.Song)
                {

                    if (playlistItem.ArtistLink == NodeLink.Parent)
                    {
                        result.BackColor = Color.LightBlue;
                    }
                    else if (playlistItem.AlbumLink == NodeLink.Parent)
                    {
                        if (playlistItem.ArtistLink == NodeLink.ParentOfParent)
                        {
                            result.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            result.BackColor = Color.LightYellow;
                        }
                    }
                    else if (playlistItem.AlbumLink == NodeLink.ParentOfParent)
                    {
                        result.BackColor = Color.Orange;
                    }
                }
            }
            return result;
        }

        private void playlistTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowDataOfSelectedNode();
        }

        private void ShowDataOfSelectedNode()
        {
            PlaylistItem playlistItem = (PlaylistItem)playlistTreeView.SelectedNode.Tag;
            itemNameTextBox.Text = playlistItem.Name;
            itemPathTextBox.Text = playlistItem.Path;
            itemTypeComboBox.Text = playlistItem.Type.ToString();

            bool showSongTagData = (playlistItem.ItemExists == true) && (playlistItem.Type == PlaylistItemType.Song);
            itemTitleTextBox.Enabled = showSongTagData;
            itemAlbumTextBox.Enabled = showSongTagData;
            itemArtistTextBox.Enabled = showSongTagData;
            itemGenreTextBox.Enabled = showSongTagData;
            itemTrackNumberTextBox.Enabled = showSongTagData;
            if (showSongTagData)
            {
                itemTitleTextBox.Text = playlistItem.Title;
                itemAlbumTextBox.Text = playlistItem.Album;
                itemArtistTextBox.Text = playlistItem.Artist;
                itemGenreTextBox.Text = playlistItem.Genre;
                itemTrackNumberTextBox.Text = playlistItem.Nr.ToString();
            }
            else
            {
                itemTitleTextBox.Text = null;
                itemAlbumTextBox.Text = null;
                itemArtistTextBox.Text = null;
                itemGenreTextBox.Text = null;
                itemTrackNumberTextBox.Text = null;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ShowDataOfSelectedNode();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            bool changeFAF = changeFilesAndFoldersCheckBox.Checked;

            /// Write Data to all affected PlaylistItems and corresponding files

            PlaylistItem selectedPlaylistItem = (PlaylistItem)playlistTreeView.SelectedNode.Tag;
            selectedPlaylistItem.ChangeName(itemNameTextBox.Text, changeFAF);
            selectedPlaylistItem.ChangePath(itemPathTextBox.Text, false); //TODO true
            if (selectedPlaylistItem.Type == PlaylistItemType.Song)
            {
                selectedPlaylistItem.Title = itemTitleTextBox.Text;
                selectedPlaylistItem.ChangeAlbum(itemAlbumTextBox.Text, changeFAF);
                selectedPlaylistItem.ChangeArtist(itemArtistTextBox.Text, changeFAF);
            }

            switch (selectedPlaylistItem.AlbumLink)
            {
                case NodeLink.Parent:
                    selectedPlaylistItem.Parent.ChangeName(selectedPlaylistItem.Album, changeFAF);
                    break;
                case NodeLink.ParentOfParent:
                    selectedPlaylistItem.Parent.Parent.ChangeName(selectedPlaylistItem.Album, changeFAF);
                    break;
                case NodeLink.None:
                default:
                    break;
            }
            switch (selectedPlaylistItem.ArtistLink)
            {
                case NodeLink.Parent:
                    selectedPlaylistItem.Parent.ChangeName(selectedPlaylistItem.Artist, changeFAF);
                    break;
                case NodeLink.ParentOfParent:
                    selectedPlaylistItem.Parent.Parent.ChangeName(selectedPlaylistItem.Artist, changeFAF);
                    break;
                case NodeLink.None:
                default:
                    break;
            }

            PlaylistItem Playlist = (PlaylistItem)playlistTreeView.TopNode.Tag;
            Playlist.ChangeName(playlistNameTextBox.Text, changeFAF);


            /// Reload View from PlaylistItem
            ShowPlaylist(Playlist);
            //TODO: optimize behaviour (no full reload; keep focus)


            /// Write Data to PlaylistFile
            File.WriteAllLines(Playlist.Path + "\\" + Playlist.Name, Playlist.ToPlaylistLines());

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            var PlaylistItem = (PlaylistItem)playlistTreeView.Tag;
            ShowPlaylist(Path.Combine(PlaylistItem.Path, PlaylistItem.Name));
        }
    }
}
