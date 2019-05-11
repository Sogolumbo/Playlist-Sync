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
using System.Diagnostics;

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


        #region fuctions
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

            playlistNameTextBox.Text = Playlist.Name;
            playlistPathLabel.Text = Playlist.Path;
        }
        private void ReloadPlaylist(TreeNode changedTreeNode, PlaylistItem playlist)
        {
            if (changedTreeNode.Parent != null)
            {
                var parent = changedTreeNode.Parent;
                int index = parent.Nodes.IndexOf(changedTreeNode);
                var playlistItem = changedTreeNode.Tag as PlaylistItem;
                playlistTreeView.Nodes.Remove(changedTreeNode);
                playlistItem.RescanMediaInfo(true);
                var reloadedNode = NodeFromPlaylistItem(playlistItem);
                if (changedTreeNode.Text != reloadedNode.Text)
                {
                    index = 0;
                    while (index < parent.Nodes.Count && reloadedNode.Text.CompareTo(parent.Nodes[index].Text) > 0)
                    {
                        index++;
                    }
                }
                parent.Nodes.Insert(index, reloadedNode);
                reloadedNode.ExpandAll();
                playlistTreeView.SelectedNode = reloadedNode;
            }
            else
            {
                ShowPlaylist(playlist);
            }
        }

        private void ShowDataOfSelectedNode()
        {
            PlaylistItem playlistItem = (PlaylistItem)playlistTreeView.SelectedNode.Tag;
            selectedItemGroupBox.Tag = playlistItem;
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
            bool PathExists = playlistItem.ItemExists || playlistItem.Parent.ItemExists;
            openPathInExplorerButton.Enabled = PathExists;
            openPathInKid3Button.Enabled = PathExists;

            albumLinkLabel.Text = linkStateToText(playlistItem.AlbumLink);
            artistLinkLabel.Text = linkStateToText(playlistItem.ArtistLink);
        }

        private void OpenPathInKid(string path)
        {
            string kid3Path = @"C:\Portable Programs\kid3-3.7.0-win32\kid3.exe";
            Process.Start("\"" + kid3Path + "\"", "\"" + path + "\""); //TODO better kid3 path
        }
        private void OpenPathInExplorer(string path)
        {
            Process.Start("explorer", path);
        }
        private void OpenPlaylistInNotepad()
        {
            string notepadPath = @"C:\Program Files (x86)\Notepad++\notepad++.exe";
            PlaylistItem playlist = (PlaylistItem)playlistTreeView.Tag;
            Process.Start("\"" + notepadPath + "\"", "\"" + playlist.Path + "\\" + playlist.Name + "\"");
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
                            result.BackColor = Color.LightCyan;
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
        private string linkStateToText(NodeLink linkState)
        {
            switch (linkState)
            {
                case NodeLink.Parent:
                    return "\u21911";
                case NodeLink.ParentOfParent:
                    return "\u21912";
                case NodeLink.None:
                default:
                    return "-";
            }
        }

        private void ApplyChanges()
        {
            bool changeFAF = changeFilesAndFoldersCheckBox.Checked;

            /// Write Data to all affected PlaylistItems and corresponding files

            PlaylistItem selectedPlaylistItem = (PlaylistItem)playlistTreeView.SelectedNode.Tag;
            if (selectedPlaylistItem.ItemExists || changeFAF == false)
            {
                selectedPlaylistItem.UnauthorizedAccess += SelectedPlaylistItem_UnauthorizedAccess;
                selectedPlaylistItem.ChangeName(itemNameTextBox.Text, changeFAF);
                selectedPlaylistItem.ChangePath(itemPathTextBox.Text, false); //TODO true (?)
                if (selectedPlaylistItem.Type == PlaylistItemType.Song)
                {
                    selectedPlaylistItem.ChangeTitle(itemTitleTextBox.Text, changeFAF);
                    selectedPlaylistItem.ChangeAlbum(itemAlbumTextBox.Text, changeFAF);
                    selectedPlaylistItem.ChangeArtist(itemArtistTextBox.Text, changeFAF);
                }
            }
            else
            {
                MessageBox.Show("The file does not exist so it can not be changed!");
            }

            bool ParentChanged = false;
            bool ParentOfParentChanged = false;
            switch (selectedPlaylistItem.AlbumLink)
            {
                case NodeLink.Parent:
                    ParentChanged |= selectedPlaylistItem.Parent.ChangeName(selectedPlaylistItem.Album, changeFAF);
                    break;
                case NodeLink.ParentOfParent:
                    ParentOfParentChanged |= selectedPlaylistItem.Parent.Parent.ChangeName(selectedPlaylistItem.Album, changeFAF);
                    break;
                case NodeLink.None:
                default:
                    break;
            }
            switch (selectedPlaylistItem.ArtistLink)
            {
                case NodeLink.Parent:
                    ParentChanged |= selectedPlaylistItem.Parent.ChangeName(selectedPlaylistItem.Artist, changeFAF);
                    break;
                case NodeLink.ParentOfParent:
                    ParentOfParentChanged |= selectedPlaylistItem.Parent.Parent.ChangeName(selectedPlaylistItem.Artist, changeFAF);
                    break;
                case NodeLink.None:
                default:
                    break;
            }

            PlaylistItem playlist = (PlaylistItem)playlistTreeView.Tag;
            playlist.ChangeName(playlistNameTextBox.Text, changeFAF);

            /// Reload View from PlaylistItem
            var highestModifiedNode = playlistTreeView.SelectedNode;
            if (ParentOfParentChanged)
            {
                highestModifiedNode = highestModifiedNode.Parent.Parent;
            }
            else if (ParentChanged)
            {
                highestModifiedNode = highestModifiedNode.Parent;
            }
            ReloadPlaylist(highestModifiedNode, playlist);

            /// Write Data to PlaylistFile
            File.WriteAllLines(playlist.Path + "\\" + playlist.Name, playlist.ToPlaylistLines());
        }
        #endregion

        #region EventHandlers
        private void SelectedPlaylistItem_UnauthorizedAccess(object sender, PlaylistItem.UnauthorizedAccessEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void playlistTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowDataOfSelectedNode();
        }

        private void choosePlaylistButton_Click(object sender, EventArgs e)
        {
            OpenPlaylistDialog();
        }
        private void reloadSelectedButton_Click(object sender, EventArgs e)
        {
            ReloadPlaylist(playlistTreeView.SelectedNode, (PlaylistItem)playlistTreeView.Tag);
        }
        private void reloadButton_Click(object sender, EventArgs e)
        {
            var PlaylistItem = (PlaylistItem)playlistTreeView.Tag;
            ShowPlaylist(Path.Combine(PlaylistItem.Path, PlaylistItem.Name));
        }

        private void openPlaylistInNotepad_Click(object sender, EventArgs e)
        {
            OpenPlaylistInNotepad();
        }
        private void openInExplorerButton_Click(object sender, EventArgs e)
        {
            PlaylistItem playlistItem = (PlaylistItem)selectedItemGroupBox.Tag;
            OpenPathInExplorer(playlistItem.Path);
        }
        private void openPathInKid3Button_Click(object sender, EventArgs e)
        {
            PlaylistItem playlistItem = (PlaylistItem)selectedItemGroupBox.Tag;
            OpenPathInKid(playlistItem.Path);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ShowDataOfSelectedNode();
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
        #endregion
    }
}
