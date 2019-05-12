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
                foreach (PlaylistLink playlistLink in libraryItem.PlaylistItems)
                {
                    playlistLink.Item.RescanMediaInfo(true);
                }
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

            bool showSongTagData = false;
            if (libraryItem.PlaylistItems.Count > 0)
            {
                var playlistItem = libraryItem.PlaylistItems.First().Item;
                itemTypeComboBox.Text = playlistItem.Type.ToString();
                showSongTagData = (playlistItem.Type == PlaylistItemType.Song);
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

                albumLinkLabel.Text = linkStateToText(playlistItem.AlbumLink);
                artistLinkLabel.Text = linkStateToText(playlistItem.ArtistLink);
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
        private void OpenPlaylistInNotepad()
        {
            string notepadPath = @"C:\Program Files (x86)\Notepad++\notepad++.exe";
            PlaylistItem playlist = (PlaylistItem)libraryTreeView.Tag;
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
            TreeNode result = new TreeNode(item.Name) { Tag = item };
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

            MusicLibraryItem selectedLibraryItem = libraryTreeView.SelectedNode.Tag as MusicLibraryItem;

            bool firstElementPassed = false;
            bool ParentChanged = false;
            bool ParentOfParentChanged = false;

            foreach (var playlistPair in selectedLibraryItem.PlaylistItems)
            {
                var playlistItem = playlistPair.Item;
                playlistItem.UnauthorizedAccess += SelectedPlaylistItem_UnauthorizedAccess;
                playlistItem.ChangeName(itemNameTextBox.Text, changeFAF);
                playlistItem.ChangePath(itemPathTextBox.Text, false); //TODO true (?)
                if (playlistItem.Type == PlaylistItemType.Song)
                {
                    playlistItem.ChangeTitle(itemTitleTextBox.Text, changeFAF);
                    playlistItem.ChangeAlbum(itemAlbumTextBox.Text, changeFAF);
                    playlistItem.ChangeArtist(itemArtistTextBox.Text, changeFAF);
                }

                /// Write Data to PlaylistFile
                File.WriteAllLines(playlistPair.Playlist.Path + "\\" + playlistPair.Playlist.Name, playlistPair.Playlist.ToPlaylistLines());


                if (!firstElementPassed)
                {
                    switch (playlistItem.AlbumLink)
                    {
                        case NodeLink.Parent:
                            ParentChanged |= playlistItem.Parent.ChangeName(playlistItem.Album, changeFAF);
                            break;
                        case NodeLink.ParentOfParent:
                            ParentOfParentChanged |= playlistItem.Parent.Parent.ChangeName(playlistItem.Album, changeFAF);
                            break;
                        case NodeLink.None:
                        default:
                            break;
                    }
                    switch (playlistItem.ArtistLink)
                    {
                        case NodeLink.Parent:
                            ParentChanged |= playlistItem.Parent.ChangeName(playlistItem.Artist, changeFAF);
                            break;
                        case NodeLink.ParentOfParent:
                            ParentOfParentChanged |= playlistItem.Parent.Parent.ChangeName(playlistItem.Artist, changeFAF);
                            break;
                        case NodeLink.None:
                        default:
                            break;
                    }
                }
            }

            /// Reload View from PlaylistItem
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
            ReloadPlaylist(libraryTreeView.SelectedNode);
        }
        private void reloadButton_Click(object sender, EventArgs e)
        {
            var PlaylistItem = (PlaylistItem)libraryTreeView.Tag;
            //TODO ShowPlaylist(Path.Combine(PlaylistItem.Path, PlaylistItem.Name));
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
