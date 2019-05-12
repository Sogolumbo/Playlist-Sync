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
    public partial class EditMusicLibraryForm : Form
    {
        public EditMusicLibraryForm()
        {
            InitializeComponent();
            itemTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistItemType));
        }

        Form _libraryConfiguration;
        MusicLibrary _library;
        List<string> _playlists = new List<string>();
        List<string> _folders = new List<string>();

        #region fuctions
        private void ShowListboxEntries()
        {
            playlistListBox.Items.Clear();
            playlistListBox.Items.AddRange(_playlists.Select(filepath => Path.GetFileName(filepath)).ToArray());
            foldersListBox.Items.Clear();
            foldersListBox.Items.AddRange(_folders.Select(filepath => Path.GetFileName(filepath)).ToArray());
        }

        private void ShowLibrary()
        {
            playlistTreeView.Nodes.Clear();
            playlistTreeView.Nodes.AddRange(NodesFromLibrary(_library));
            playlistTreeView.ExpandAll();

        }
        private void ReloadPlaylist(TreeNode changedTreeNode, PlaylistItem playlist)
        {
            //if (changedTreeNode.Parent != null)
            //{
            //    var parent = changedTreeNode.Parent;
            //    int index = parent.Nodes.IndexOf(changedTreeNode);
            //    var playlistItem = changedTreeNode.Tag as PlaylistItem;
            //    playlistTreeView.Nodes.Remove(changedTreeNode);
            //    playlistItem.RescanMediaInfo(true);
            //    var reloadedNode = NodeFromPlaylistItem(playlistItem);
            //    if (changedTreeNode.Text != reloadedNode.Text)
            //    {
            //        index = 0;
            //        while (index < parent.Nodes.Count && reloadedNode.Text.CompareTo(parent.Nodes[index].Text) > 0)
            //        {
            //            index++;
            //        }
            //    }
            //    parent.Nodes.Insert(index, reloadedNode);
            //    reloadedNode.ExpandAll();
            //    playlistTreeView.SelectedNode = reloadedNode;
            //}
            //else
            //{
            //    ShowLibrary(playlist);
            //}
        }


        private void ShowDataOfSelectedNode()
        {
            MusicLibraryItem playlistItem = playlistTreeView.SelectedNode.Tag as MusicLibraryItem;
            selectedItemGroupBox.Tag = playlistItem;
            itemNameTextBox.Text = playlistItem.Name;
            itemPathTextBox.Text = playlistItem.DirectoryPath;
            selectedItemPlaylistsListBox.Items.Clear();
            selectedItemPlaylistsListBox.Items.AddRange(playlistItem.PlaylistItems.Select(node => node.Playlist.Name).ToArray());
            //itemTypeComboBox.Text = playlistItem.Type.ToString();

            //bool showSongTagData = (playlistItem.ItemExists == true) && (playlistItem.Type == PlaylistItemType.Song);
            //itemTitleTextBox.Enabled = showSongTagData;
            //itemAlbumTextBox.Enabled = showSongTagData;
            //itemArtistTextBox.Enabled = showSongTagData;
            //itemGenreTextBox.Enabled = showSongTagData;
            //itemTrackNumberTextBox.Enabled = showSongTagData;
            //if (showSongTagData)
            //{
            //    itemTitleTextBox.Text = playlistItem.Title;
            //    itemAlbumTextBox.Text = playlistItem.Album;
            //    itemArtistTextBox.Text = playlistItem.Artist;
            //    itemGenreTextBox.Text = playlistItem.Genre;
            //    itemTrackNumberTextBox.Text = playlistItem.Nr.ToString();
            //}
            //else
            //{
            //    itemTitleTextBox.Text = null;
            //    itemAlbumTextBox.Text = null;
            //    itemArtistTextBox.Text = null;
            //    itemGenreTextBox.Text = null;
            //    itemTrackNumberTextBox.Text = null;
            //}
            //bool PathExists = playlistItem.ItemExists || playlistItem.Parent.ItemExists;
            //openPathInExplorerButton.Enabled = PathExists;
            //openPathInKid3Button.Enabled = PathExists;

            //albumLinkLabel.Text = linkStateToText(playlistItem.AlbumLink);
            //artistLinkLabel.Text = linkStateToText(playlistItem.ArtistLink);
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

        private TreeNode[] NodesFromLibrary(MusicLibrary library)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (library.MusicFolders != null)
            {
                foreach (var folder in library.ItemFolders)
                {
                    result.Add(NodeFromLibraryItem(folder));
                }
            }
            return result.OrderBy(node => node.Text).ToArray();
        }
        TreeNode NodeFromLibraryItem(MusicLibraryItem item)
        {
            TreeNode result = new TreeNode(item.Name) { Tag = item};
            if (item is MusicLibraryDirectory)
            {
                var folder = item as MusicLibraryDirectory;
                var children = folder.Directories.Select(libraryDirectory => NodeFromLibraryItem(libraryDirectory)).ToList();
                children.AddRange(folder.Files.Select(libraryFile => NodeFromLibraryItem(libraryFile)));
                children.OrderBy(node => node.Text);
                result.Nodes.AddRange(children.ToArray());
            }
            else if (item.PlaylistItems.Count > 0)
            {
                var anyPlaylistItem = item.PlaylistItems[0].Item;
                result.BackColor = BackcolorFromPlaylistItem(anyPlaylistItem);
            }
            return result;
        }
        private static Color BackcolorFromPlaylistItem(PlaylistItem anyPlaylistItem)
        {
            if (anyPlaylistItem.ArtistLink == NodeLink.Parent)
            {
                return (Color.LightBlue);
            }
            else if (anyPlaylistItem.AlbumLink == NodeLink.Parent)
            {
                if (anyPlaylistItem.ArtistLink == NodeLink.ParentOfParent)
                {
                    return (Color.LightGreen);
                }
                else
                {
                    return (Color.LightCyan);
                }
            }
            else if (anyPlaylistItem.AlbumLink == NodeLink.ParentOfParent)
            {
                return (Color.LightCyan);
            }
            return TreeView.DefaultBackColor;
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
            //playlist.ChangeName(playlistNameTextBox.Text, changeFAF);

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
        
        private void reloadSelectedButton_Click(object sender, EventArgs e)
        {
            ReloadPlaylist(playlistTreeView.SelectedNode, (PlaylistItem)playlistTreeView.Tag);
        }
        private void reloadButton_Click(object sender, EventArgs e)
        {
            var PlaylistItem = (PlaylistItem)playlistTreeView.Tag;
            //ShowPlaylist(Path.Combine(PlaylistItem.Path, PlaylistItem.Name));
        }

        private void openPlaylistInNotepad_Click(object sender, EventArgs e)
        {
            OpenPlaylistInNotepad();
        }
        private void openInExplorerButton_Click(object sender, EventArgs e)
        {
            var libraryItem = selectedItemGroupBox.Tag as MusicLibraryItem;
            OpenPathInExplorer(libraryItem.DirectoryPath);
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

        private void changeFoldersButton_Click(object sender, EventArgs e)
        {
            if (_libraryConfiguration == null)
            {
                _libraryConfiguration = new ConfigureMusicLibrary(_playlists, _folders);
                _libraryConfiguration.FormClosed += _libraryConfiguration_FormClosed;
            }
            _libraryConfiguration.ShowDialog();
        }

        private void _libraryConfiguration_FormClosed(object sender, FormClosedEventArgs e)
        {
            _libraryConfiguration = null;
            _library = new MusicLibrary(_playlists, _folders);
            ShowListboxEntries();
            ShowLibrary();
        }

        private void EditMusicLibraryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Collections.Specialized.StringCollection folderCollection = new System.Collections.Specialized.StringCollection();
            System.Collections.Specialized.StringCollection playlistCollection = new System.Collections.Specialized.StringCollection();
            folderCollection.AddRange(_folders.ToArray());
            playlistCollection.AddRange(_playlists.ToArray());
            Properties.Settings.Default.MusicLibraryFolders = folderCollection;
            Properties.Settings.Default.MusicLibraryPlaylists = playlistCollection;
            Properties.Settings.Default.Save();
        }

        private void EditMusicLibraryForm_Load(object sender, EventArgs e)
        {
            var folderCollection = Properties.Settings.Default.MusicLibraryFolders;
            var playlistCollection = Properties.Settings.Default.MusicLibraryPlaylists;
            if (folderCollection != null)
            {
                _folders = Properties.Settings.Default.MusicLibraryFolders.Cast<string>().ToList();
            }
            if (playlistCollection != null)
            {
                _playlists = Properties.Settings.Default.MusicLibraryPlaylists.Cast<string>().ToList();
            }
            ShowListboxEntries();
            _library = new MusicLibrary(_playlists, _folders);
            ShowLibrary();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
        }
    }
}
