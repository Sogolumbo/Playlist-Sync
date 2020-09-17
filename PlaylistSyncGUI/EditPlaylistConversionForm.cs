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

namespace PlaylistSyncGUI
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
            targetFileNamePrefixTextBox.Text = conversion.TargetFileNamePrefix;
            TargetFileTypeSuffixTextBox.Text = conversion.TargetFileTypeSuffix;
            MusicFolderPaths = new Dictionary<string, string>(conversion.MusicFolderPaths);

            folderLinksFlowLayoutPanel.SizeChanged += EditPlaylistConversionForm_SizeChanged;
        }

        private void EditPlaylistConversionForm_SizeChanged(object sender, EventArgs e)
        {
            SetFolderLinkSize();
        }

        private void SetFolderLinkSize()
        {
            foreach (Control folderLink in folderLinksFlowLayoutPanel.Controls)
            {
                folderLink.Width = ElementWidth();
            }
        }

        private Dictionary<string, string> _musicFolderPaths;

        Dictionary<string, string> MusicFolderPaths
        {
            get { return _musicFolderPaths; }
            set
            {
                _musicFolderPaths = value;
                ShowFolderLinks();
            }
        }

        private void ShowFolderLinks()
        {
            folderLinksFlowLayoutPanel.Controls.Clear();
            foreach (var pair in MusicFolderPaths)
            {
                FolderLinkElement folderLink = new FolderLinkElement(pair);
                folderLink.Width = ElementWidth();
                folderLinksFlowLayoutPanel.Controls.Add(folderLink);
                folderLink.Remove += FolderLink_Remove;
                folderLink.Changed += FolderLink_Changed;
            }
        }

        private void FolderLink_Changed(object sender, EventArgs e)
        {
            MusicFolderPaths.Clear();
            bool noErrors = true;
            foreach (FolderLinkElement folderLink in folderLinksFlowLayoutPanel.Controls)
            {
                try
                {
                    MusicFolderPaths.Add(folderLink.SourceFolder, folderLink.TargetFolder);
                }
                catch(ArgumentException)
                {
                    folderLink.ShowError();
                    noErrors = false;
                }
            }
            OKButton.Enabled = noErrors;
        }

        private void FolderLink_Remove(object sender, EventArgs e)
        {
            var folderLink = (sender as FolderLinkElement).FolderLink;
            MusicFolderPaths.Remove(folderLink.Key);
            ShowFolderLinks();
        }

        private int ElementWidth()
        {
            return folderLinksFlowLayoutPanel.Width - 25;
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
            Conversion.TargetFileNamePrefix = targetFileNamePrefixTextBox.Text;
            Conversion.TargetFileTypeSuffix = TargetFileTypeSuffixTextBox.Text;
            Conversion.MusicFolderPaths = MusicFolderPaths;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFolderLink();
        }

        private void AddFolderLink()
        {
            if (!MusicFolderPaths.ContainsKey(""))
            {
                MusicFolderPaths.Add("", "");
                ShowFolderLinks();
            }
            else
            {
                MessageBox.Show("Use the existing empty element!");
            }
        }
    }
}
