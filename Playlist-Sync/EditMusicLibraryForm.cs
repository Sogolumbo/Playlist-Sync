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
            libraryTreeView.Nodes.Clear();
            libraryTreeView.Nodes.AddRange(NodesFromLibrary(_library));
            libraryTreeView.ExpandAll();

        }
        private void ReloadPlaylist(TreeNode changedTreeNode)
        {
            if (changedTreeNode.Parent != null)
            {
                var parent = changedTreeNode.Parent;
                int index = parent.Nodes.IndexOf(changedTreeNode);
                var libraryItem = changedTreeNode.Tag as MusicLibraryItem;
                libraryTreeView.Nodes.Remove(changedTreeNode);
                libraryItem.Reload();
                var reloadedNode = NodeFromLibraryItem(libraryItem);
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
                libraryTreeView.SelectedNode = reloadedNode;
            }
            else
            {
                ShowLibrary();
            }
        }


        private void ShowDataOfSelectedNode()
        {
            MusicLibraryItem libraryItem = libraryTreeView.SelectedNode.Tag as MusicLibraryItem;
            selectedItemGroupBox.Tag = libraryItem;
            itemNameTextBox.Text = libraryItem.Name;
            itemPathTextBox.Text = libraryItem.DirectoryPath;
            selectedItemPlaylistsListBox.Items.Clear();
            selectedItemPlaylistsListBox.Items.AddRange(libraryItem.PlaylistItems.Select(node => node.Playlist).ToArray());

            bool showSongTagData = libraryItem is MusicLibraryFile;
            if (showSongTagData)
            {
                var tag = (libraryItem as MusicLibraryFile).Tag;
                itemTitleTextBox.Text = tag.Title;
                itemAlbumTextBox.Text = tag.Album;
                itemArtistTextBox.Text = tag.Artist;
                itemGenreTextBox.Text = tag.Genre;
                itemTrackNumberTextBox.Text = tag.Nr.ToString();


                albumLinkLabel.Text = linkStateToText((libraryItem as MusicLibraryFile).AlbumLink);
                artistLinkLabel.Text = linkStateToText((libraryItem as MusicLibraryFile).ArtistLink);
            }
            else
            {
                itemTitleTextBox.Text = null;
                itemAlbumTextBox.Text = null;
                itemArtistTextBox.Text = null;
                itemGenreTextBox.Text = null;
                itemTrackNumberTextBox.Text = null;
                artistLinkLabel.Text = linkStateToText(NodeLink.None);
                albumLinkLabel.Text = linkStateToText(NodeLink.None);
            }

            itemTitleTextBox.Enabled = showSongTagData;
            itemAlbumTextBox.Enabled = showSongTagData;
            itemArtistTextBox.Enabled = showSongTagData;
            itemGenreTextBox.Enabled = showSongTagData;
            itemTrackNumberTextBox.Enabled = showSongTagData;
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
        private void OpenPlaylistInNotepad(string path)
        {
            string notepadPath = @"C:\Program Files (x86)\Notepad++\notepad++.exe";
            Process.Start("\"" + notepadPath + "\"", "\"" + path + "\"");
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
            TreeNode result = new TreeNode(item.Name) { Tag = item };
            if (item is MusicLibraryDirectory)
            {
                var folder = item as MusicLibraryDirectory;
                var children = folder.Directories.Select(libraryDirectory => NodeFromLibraryItem(libraryDirectory)).ToList();
                children.AddRange(folder.Files.Select(libraryFile => NodeFromLibraryItem(libraryFile)));
                children.OrderBy(node => node.Text);
                result.Nodes.AddRange(children.ToArray());
            }
            else
            {
                result.BackColor = BackcolorFromPlaylistItem(item as MusicLibraryFile);
            }
            return result;
        }
        private Color BackcolorFromPlaylistItem(MusicLibraryFile libraryItem)
        {
            if (libraryItem.ArtistLink == NodeLink.Parent)
            {
                return (Color.LightBlue);
            }
            else if (libraryItem.AlbumLink == NodeLink.Parent)
            {
                if (libraryItem.ArtistLink == NodeLink.ParentOfParent)
                {
                    return (Color.LightGreen);
                }
                else
                {
                    return (Color.LightCyan);
                }
            }
            else if (libraryItem.AlbumLink == NodeLink.ParentOfParent)
            {
                return (Color.LightCyan);
            }
            else if (libraryItem.ArtistLink == NodeLink.ParentOfParent)
            {
                return (Color.LightCyan);
            }
            return libraryTreeView.BackColor;
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
            /// Write Data to all affected PlaylistItems and corresponding files

            MusicLibraryItem selectedLibraryItem = libraryTreeView.SelectedNode.Tag as MusicLibraryItem;

            bool ParentChanged = false;
            bool ParentOfParentChanged = false;

            selectedLibraryItem.Name = itemNameTextBox.Text;
            if (selectedLibraryItem is MusicLibraryFile)
            {
                var tag = (selectedLibraryItem as MusicLibraryFile).Tag;
                tag.Title = itemTitleTextBox.Text;
                tag.Album = itemAlbumTextBox.Text;
                tag.Artist = itemArtistTextBox.Text;
                if (uint.TryParse(itemTrackNumberTextBox.Text, out uint trackNumber))
                {
                    tag.Nr = trackNumber;
                }
                tag.Genre = itemGenreTextBox.Text;

                ///Determine whether parent nodes changed
                switch ((selectedLibraryItem as MusicLibraryFile).AlbumLink)
                {
                    case NodeLink.Parent:
                        ParentChanged |= true;
                        break;
                    case NodeLink.ParentOfParent:
                        ParentOfParentChanged |= true;
                        break;
                    case NodeLink.None:
                    default:
                        break;
                }
                switch ((selectedLibraryItem as MusicLibraryFile).ArtistLink)
                {
                    case NodeLink.Parent:
                        ParentChanged |= true;
                        break;
                    case NodeLink.ParentOfParent:
                        ParentOfParentChanged |= true;
                        break;
                    case NodeLink.None:
                    default:
                        break;
                }
            }

            /// Write Data to PlaylistFile
            foreach (var playlistPair in selectedLibraryItem.PlaylistItems)
            {
                File.WriteAllLines(playlistPair.Playlist.Path + "\\" + playlistPair.Playlist.Name, playlistPair.Playlist.ToPlaylistLines());
            }

            /// Reload View of libraryItem
            var highestModifiedNode = libraryTreeView.SelectedNode;
            if (ParentOfParentChanged)
            {
                highestModifiedNode = highestModifiedNode.Parent.Parent;
            }
            else if (ParentChanged)
            {
                highestModifiedNode = highestModifiedNode.Parent;
            }
            ReloadPlaylist(highestModifiedNode);
        }
        #endregion

        #region EventHandlers
        private void SelectedPlaylistItem_UnauthorizedAccess(object sender, UnauthorizedAccessEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void playlistTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowDataOfSelectedNode();
        }

        private void reloadSelectedButton_Click(object sender, EventArgs e)
        {
            ReloadPlaylist(libraryTreeView.SelectedNode);
        }
        private void reloadButton_Click(object sender, EventArgs e)
        {
            _library = new MusicLibrary(_playlists, _folders);
            _library.UnauthorizedAccess += _library_UnauthorizedAccess;
            ShowLibrary();
        }

        private void _library_UnauthorizedAccess(object sender, UnauthorizedAccessEventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show(e.ToString(), "", MessageBoxButtons.RetryCancel))
            {
                e.Cancel = true;
            }
        }
        
        private void openInExplorerButton_Click(object sender, EventArgs e)
        {
            var libraryItem = selectedItemGroupBox.Tag as MusicLibraryItem;
            OpenPathInExplorer(libraryItem.DirectoryPath);
        }
        private void openPathInKid3Button_Click(object sender, EventArgs e)
        {
            var libraryItem = selectedItemGroupBox.Tag as MusicLibraryItem;
            OpenPathInKid(libraryItem.DirectoryPath);
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
            _library.UnauthorizedAccess += _library_UnauthorizedAccess;
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
            _library.UnauthorizedAccess += _library_UnauthorizedAccess;
            ShowLibrary();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
        }

        private void openInNotepadButton_Click(object sender, EventArgs e)
        {
            if(playlistListBox.SelectedItem != null)
            {
                var playlistPath = _playlists.Find(entry => Path.GetFileName(entry) == playlistListBox.SelectedItem.ToString());
                OpenPlaylistInNotepad(playlistPath);
            }
        }
    }
}
