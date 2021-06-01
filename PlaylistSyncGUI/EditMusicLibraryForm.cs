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
using System.Diagnostics;
using System.Text.RegularExpressions;

using Playlist;
using static PlaylistSyncGUI.OpenExternalStuff;

namespace PlaylistSyncGUI
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
        bool _missingElementFound = false;

        private void EditMusicLibraryForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

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
            CreateMusicLibrary();
            ShowLibrary();

            Cursor.Current = Cursors.Default;
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

        private void CreateMusicLibrary()
        {
            HashSet<string> nonAudioDatatypes = new HashSet<string>(Properties.Settings.Default.nonAudioDataTypes.Cast<string>());
            try
            {
                _library = new MusicLibrary(_playlists, _folders, nonAudioDatatypes);
                _library.UnauthorizedAccess += _library_UnauthorizedAccess;
                _library.MissingElementFound += _library_MissingElementFound;
                _library.FileNameAlreadyExists += _library_FileNameAlreadyExists;
                _missingElementFound = false;
            }
            catch (NonAudioDataTypeMissingException e)
            {
                string exceptionHeader = "Unknown Fily Type in Music Library detected";
                MessageBox.Show(e.Message, exceptionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                var res = MessageBox.Show("Do you want to open the folder to change the ignored file type? (Restart Playlist-Sync to see the changes!)", exceptionHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                Close(); //TODO remove this line if the rest of the program won't crash
                if (res == DialogResult.Yes)
                {
                    OpenPathInExplorer(NonAudioDataTypeMissingException.PropertyFilePath);
                }
                throw e;
            }
        }
        private void ShowLibrary()
        {
            libraryTreeView.Nodes.Clear();
            libraryTreeView.Nodes.AddRange(NodesFromLibrary(_library));
        }

        private TreeNode[] NodesFromLibrary(MusicLibrary library)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (library.MusicFolders != null && library.MusicFolders.Count > 0)
            {
                result.Add(NodeFromLibraryItem(library.ItemFolder));
            }
            //TODO result = result.OrderBy(node => node.FullPath).ToList();
            return result.ToArray();
        }
        TreeNode NodeFromLibraryItem(MusicLibraryItem item)
        {
            TreeNode result = new TreeNode(item.Name) { Tag = item, Name = item.Name };
            if (item is MusicLibraryDirectory)
            {
                var folder = item as MusicLibraryDirectory;
                var children = folder.Directories.Select(libraryDirectory => NodeFromLibraryItem(libraryDirectory)).ToList();
                children.AddRange(folder.Files.Select(libraryFile => NodeFromLibraryItem(libraryFile)));
                children.OrderBy(node => node.FullPath);
                result.Nodes.AddRange(children.ToArray());
                result.Expand();
            }
            else
            {
                result.BackColor = BackcolorFromPlaylistItem(item as MusicLibraryFile);
                if (item is MusicLibraryMissingElement)
                {
                    result.ForeColor = Color.White;

                    var folder = item as MusicLibraryMissingElement;
                    var children = folder.Children.Select(element => NodeFromLibraryItem(element)).ToList();
                    result.Nodes.AddRange(children.ToArray());
                }
            }
            return result;
        }
        private Color BackcolorFromPlaylistItem(MusicLibraryItem libraryItem)
        {
            var perfectColor = Color.LightGreen;
            var directArtistLinkColor = Color.LightBlue;
            var onlyOneLinkColor = Color.LightCyan;
            var partialLinkColor = Color.Aquamarine;
            var missingColor = Color.Red;

            if (libraryItem is MusicLibraryFile)
            {
                MusicLibraryFile libraryFile = libraryItem as MusicLibraryFile;
                if (libraryFile.ArtistLink == NodeLink.Parent)
                {
                    return directArtistLinkColor;
                }
                else if (libraryFile.AlbumLink == NodeLink.Parent)
                {
                    if (libraryFile.ArtistLink == NodeLink.ParentOfParent)
                    {
                        return perfectColor;
                    }
                    else if (libraryFile.ArtistLink == NodeLink.ParentOfParentPartially)
                    {
                        return partialLinkColor;
                    }
                    else
                    {
                        return onlyOneLinkColor;
                    }
                }
                else if (libraryFile.AlbumLink == NodeLink.ParentOfParent)
                {
                    return onlyOneLinkColor;
                }
                else if (libraryFile.ArtistLink == NodeLink.ParentOfParent)
                {
                    return onlyOneLinkColor;
                }
                else if (libraryFile.ArtistLink == NodeLink.ParentOfParentPartially || libraryFile.ArtistLink == NodeLink.ParentPartially)
                {
                    return partialLinkColor;
                }
                return libraryTreeView.BackColor;
            }
            else
            {
                return missingColor;
            }

        }


        private void ApplyChanges()
        {
            /// Write Data to all affected library and playlist items and all corresponding files

            MusicLibraryItem selectedLibraryItem = libraryTreeView.SelectedNode.Tag as MusicLibraryItem;

            bool ParentChanged = false;
            bool ParentOfParentChanged = false;

            selectedLibraryItem.Name = itemNameTextBox.Text;
            if (selectedLibraryItem.DirectoryPath != itemPathTextBox.Text)
            {
                ParentChanged = true;
            }
            var modifiedLibraryItem = _library.MoveItem(selectedLibraryItem, itemPathTextBox.Text);

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
                    case NodeLink.ParentPartially:
                        ParentChanged |= true;
                        break;
                    case NodeLink.ParentOfParent:
                    case NodeLink.ParentOfParentPartially:
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
                File.WriteAllLines(playlistPair.Playlist.Path + "\\" + playlistPair.Playlist.Name, playlistPair.Playlist.ToPlaylistLines(), PlaylistEncoding.GetEncoding(playlistPair.Playlist.Name));
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
            ReloadNode(highestModifiedNode);
            var modifiedTreeNode = libraryTreeView.Nodes.Find(modifiedLibraryItem.Name, true);
            var nodesToReload = modifiedTreeNode.Where(trNode => trNode.Tag == modifiedLibraryItem);
            if (nodesToReload.Count() == 1)
            {
                ReloadNode(nodesToReload.First());
            }
            else
            {
                FullReload();
            }

            RestoreTreeViewSelection(selectedLibraryItem);
        }

        private void RestoreTreeViewSelection(MusicLibraryItem selectedLibraryItem)
        {
            TreeNode[] previouslySelectedNodes = libraryTreeView.Nodes.Find(selectedLibraryItem.Name, true);
            if (previouslySelectedNodes.Length == 1)
            {
                libraryTreeView.SelectedNode = previouslySelectedNodes[0];
            }
            else
            {
                throw new NotImplementedException("Could not restore selected Item. Missing implementation to uniquely identify the object.");
            }
        }


        private void _library_MissingElementFound(object sender, EventArgs e)
        {
            _missingElementFound = true;
        }


        #region Reloading
        private void ReloadNode(TreeNode changedTreeNode)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_missingElementFound)
            {
                FullReload();
            }
            else if (changedTreeNode.Parent != null)
            {
                var parent = changedTreeNode.Parent;
                int index = parent.Nodes.IndexOf(changedTreeNode);
                var libraryItem = changedTreeNode.Tag as MusicLibraryItem;

                List<MusicLibraryItem> parentsChildren = null;
                if (libraryItem.Parent is MusicLibraryDirectory)
                    parentsChildren = (libraryItem.Parent as MusicLibraryDirectory).Children.ToList();
                if (libraryItem.Parent is MusicLibraryMissingElement)
                    parentsChildren = (libraryItem.Parent as MusicLibraryMissingElement).Children.ToList<MusicLibraryItem>();

                if (parentsChildren == null || !parentsChildren.Contains(libraryItem))
                {
                    ReloadNode(changedTreeNode.Parent);
                }
                else
                {
                    libraryTreeView.Nodes.Remove(changedTreeNode);
                    libraryItem.Reload();
                    var reloadedNode = NodeFromLibraryItem(libraryItem);
                    if (changedTreeNode.Text != reloadedNode.Text)
                    {
                        index = 0;
                        while (index < parent.Nodes.Count && MusicLibrary.CompareFilePaths(libraryItem.FullPath, parent.Nodes[index].FullPath) > 0)
                        {
                            index++;
                        }
                    }
                    parent.Nodes.Insert(index, reloadedNode);
                    libraryTreeView.SelectedNode = reloadedNode;
                }

            }
            else
            {
                ShowLibrary();
            }

            Cursor.Current = Cursors.Default;
        }
        private void FullReload()
        {
            Cursor.Current = Cursors.WaitCursor;
            var previouslySelectedNode = libraryTreeView.SelectedNode;
            CreateMusicLibrary();
            ShowLibrary();
            if (previouslySelectedNode != null)
            {
                var possiblyEquivalentNodes = libraryTreeView.Nodes.Find(previouslySelectedNode.Name, true);
                var equivalentToSelectedNodes = possiblyEquivalentNodes.Where(node => node.FullPath == (previouslySelectedNode.Tag as MusicLibraryItem).FullPath);
                if (equivalentToSelectedNodes.Count() == 1)
                {
                    libraryTreeView.SelectedNode = equivalentToSelectedNodes.First();
                }
                else
                {
                    MessageBox.Show("Could not restore the selection. There are " + possiblyEquivalentNodes.Count() + " items which have the name " + previouslySelectedNode.Name + " out of which " + equivalentToSelectedNodes.Count() + " have the path" + (previouslySelectedNode.Tag as MusicLibraryItem).FullPath);
                }
                libraryTreeView.Focus();
            }
            Cursor.Current = Cursors.Default;
        }

        private void reloadSelectedButton_Click(object sender, EventArgs e)
        {
            ReloadNode(libraryTreeView.SelectedNode);
        }
        private void reloadButton_Click(object sender, EventArgs e)
        {
            FullReload();
        }
        #endregion

        #region Show Data Of Selected Node
        private void playlistTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowDataOfSelectedNode();
        }
        private void ShowDataOfSelectedNode()
        {
            MusicLibraryItem libraryItem = libraryTreeView.SelectedNode.Tag as MusicLibraryItem;
            selectedItemGroupBox.Tag = libraryItem;
            itemNameTextBox.Text = libraryItem.Name;
            itemPathTextBox.Text = libraryItem.DirectoryPath;
            selectedItemPlaylistsListBox.Items.Clear();
            if (libraryItem.IsFile())
            {
                selectedItemPlaylistsListBox.Items.AddRange(libraryItem.PlaylistItems.Select(node => node.Playlist).ToArray());
            }
            else
            {
                if (libraryItem.PlaylistItems.Count > 0)
                {
                    int maxLength(int childrenCount)
                    {
                        return Math.Max(2, 70 / childrenCount);
                    }
                    int currentMaxElementCountLength = libraryItem.PlaylistItems.Select(node => node.Item.Children.Count).Max().ToString().Length;
                    string playlistText(PlaylistLink node, int maxElementCountLength)
                    {
                        string elementCount = node.Item.Children.Count.ToString();
                        return "≥" + elementCount.PadLeft(maxElementCountLength, '\u2000') + " in "
                                + node.Playlist
                                + " ("
                                + String.Join(", ", node.Item.Children.Select(item => item.Name.Truncate(maxLength(node.Item.Children.Count), true)))
                                + ")";
                    }
                    selectedItemPlaylistsListBox.Items.AddRange(libraryItem.PlaylistItems.Select(node => playlistText(node, currentMaxElementCountLength)).ToArray());
                }
            }

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

        private string linkStateToText(NodeLink linkState)
        {
            switch (linkState)
            {
                case NodeLink.Parent:
                    return "\u21911";
                case NodeLink.ParentOfParent:
                    return "\u21912";
                case NodeLink.ParentPartially:
                    return "(\u21911)";
                case NodeLink.ParentOfParentPartially:
                    return "(\u21912)";
                case NodeLink.None:
                default:
                    return "-";
            }
        }
        #endregion

        #region Show exceptional events

        //TODO remove because there are no references
        private void SelectedPlaylistItem_UnauthorizedAccess(object sender, UnauthorizedAccessEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void _library_FileNameAlreadyExists(object sender, FileNameAlreadyExistsEventArgs e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _library_UnauthorizedAccess(object sender, UnauthorizedAccessEventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show(e.ToString(), "", MessageBoxButtons.RetryCancel))
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Library configuration
        private void ShowListboxEntries()
        {
            playlistListBox.Items.Clear();
            playlistListBox.Items.AddRange(_playlists.Select(filepath => Path.GetFileName(filepath)).ToArray());
            foldersListBox.Items.Clear();
            foldersListBox.Items.AddRange(_folders.Select(filepath => Path.GetFileName(filepath)).ToArray());
        }

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
            Cursor.Current = Cursors.WaitCursor;

            _libraryConfiguration = null;
            CreateMusicLibrary();
            ShowListboxEntries();
            ShowLibrary();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Validate input (item name)
        private void itemNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidFilename(itemNameTextBox.Text))
            {
                itemNameTextBox.BackColor = Color.FromArgb(250, 210, 220);
                applyButton.Enabled = false;
            }
            else
            {
                itemNameTextBox.ResetBackColor();
                applyButton.Enabled = true;
            }
        }

        private bool IsValidFilename(string testName)
        {
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidFileNameChars());
            Regex regInvalidFileName = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");

            if (regInvalidFileName.IsMatch(testName)) { return false; };

            return true;
        }
        #endregion

        #region Open stuff externally
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
        private void openInNotepadButton_Click(object sender, EventArgs e)
        {
            if (playlistListBox.SelectedItem != null)
            {
                var playlistPath = _playlists.Find(entry => Path.GetFileName(entry) == playlistListBox.SelectedItem.ToString());
                OpenFileInNotepad(playlistPath);
            }
        }

        private void openSelectedItemButton_Click(object sender, EventArgs e)
        {
            var libraryItem = selectedItemGroupBox.Tag as MusicLibraryItem;
            OpenItem(libraryItem.FullPath);
        }

        private void OpenItem(string fullPath)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Process process = OpenPathWithStandardApplication(fullPath);
                int maxTimeInMiliseconds = 5 * 1000;
                bool done = process.WaitForExit(maxTimeInMiliseconds);
                if (!done)
                {
                    process.Kill();
                    MessageBox.Show("Could not open the item in a resonable time (" + maxTimeInMiliseconds + "ms). You might have to restart the standard application for this file type.", "Error while trying to open the item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n(Path: '" + fullPath + "')", "Error while opening " + Path.GetFileName(fullPath));
            }
            Cursor = Cursors.Default;
        }
        #endregion

        #region Reduce and Expand (Tree view items)
        private void expandAllButton_Click(object sender, EventArgs e)
        {
            libraryTreeView.ExpandAll();
            if (libraryTreeView.SelectedNode != null)
            {
                libraryTreeView.SelectedNode.EnsureVisible();
            }
        }

        private void reduceAllButton_Click(object sender, EventArgs e)
        {
            libraryTreeView.CollapseAll();

            foreach (TreeNode rootNode in libraryTreeView.Nodes)
            {
                rootNode.Expand();
                TreeNode subject = rootNode;
                while (subject.Nodes.Count == 1)
                {
                    subject = subject.Nodes[0];
                    subject.Expand();
                }
            }
        }

        private void reduceAllExceptMissingItemsButton_Click(object sender, EventArgs e)
        {
            ReduceAllTreeViewItemsExceptConditionMet(item => item is MusicLibraryMissingElement);
        }

        void ReduceAllTreeViewItemsExceptConditionMet(Func<MusicLibraryItem, bool> ConditionMet)
        {
            libraryTreeView.CollapseAll();

            foreach (TreeNode rootNode in libraryTreeView.Nodes)
            {
                ExpandIfConditionMetRecursive(rootNode, ConditionMet);
            }
        }

        bool ExpandIfConditionMetRecursive(TreeNode treeNode, Func<MusicLibraryItem, bool> ConditionMet)
        {
            bool conditionMet = false;
            if (treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    conditionMet |= ExpandIfConditionMetRecursive(node, ConditionMet);
                }
                if (conditionMet)
                {
                    treeNode.Expand();
                }
            }
            else
            {
                conditionMet = ConditionMet(treeNode.Tag as MusicLibraryItem);
            }
            return conditionMet;
        }

        private void reduceAllExceptBadArtistItemsButton_Click(object sender, EventArgs e)
        {
            ReduceAllTreeViewItemsExceptConditionMet(isArtistBad);
        }

        /// <summary>
        /// Returns wether the item has music tags that don't fit to the parent folders. In most cases this means that the file is not well organized.
        /// </summary>
        private bool isArtistBad(MusicLibraryItem item)
        {
            if (item is MusicLibraryFile)
            {
                return ((item as MusicLibraryFile).ArtistLink == NodeLink.None);
            }
            return false;
        }

        private void reduceChildrenButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var current = libraryTreeView.SelectedNode;
            current.Collapse();
            foreach (TreeNode child in current.Nodes)
            {
                child.Collapse(true);
            }
            current.Expand();
            current.EnsureVisible();
            Cursor = DefaultCursor;
            libraryTreeView.Focus();
        }
        #endregion
        
        #region Handle key presses
        private void selectedSongButton_KeyDown(object sender, KeyEventArgs e)
        {
            handleArrowKeysInSelectedSongControls(e);
        }
        private void selectedSongTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            handleArrowKeysInSelectedSongControls(e);
            handleEnterKeyInSelectedSongTextBox(sender, e);
        }


        private void selectedSongControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            declareArrowKeysAsInputKeysInSelectedSongControls(e);
        }

        private void handleArrowKeysInSelectedSongControls(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && libraryTreeView.SelectedNode != null && libraryTreeView.SelectedNode.NextVisibleNode != null)
            {
                libraryTreeView.SelectedNode = libraryTreeView.SelectedNode.NextVisibleNode;
            }
            else if (e.KeyCode == Keys.Up && libraryTreeView.SelectedNode != null && libraryTreeView.SelectedNode.PrevVisibleNode != null)
            {
                libraryTreeView.SelectedNode = libraryTreeView.SelectedNode.PrevVisibleNode;
            }
        }
        private void handleEnterKeyInSelectedSongTextBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && libraryTreeView.SelectedNode != null)
            {
                Cursor = Cursors.WaitCursor;
                ApplyChanges();
                (sender as Control).Focus();
                Cursor = DefaultCursor;
            }
        }

        private static void declareArrowKeysAsInputKeysInSelectedSongControls(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Various Click Handlers
        private void copyFullPathButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((selectedItemGroupBox.Tag as MusicLibraryItem).FullPath);
        }

        private void appendPathToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Clipboard.GetText() + "\n" + (selectedItemGroupBox.Tag as MusicLibraryItem).FullPath);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ShowDataOfSelectedNode();
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
        
        private void debugButton_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
