using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaylistSyncGUI
{
    using static OpenExternalStuff;

    public partial class PlaylistToolsMenuForm : Form
    {
        public PlaylistToolsMenuForm()
        {
            InitializeComponent();

            //LinkedLabels - icon
            string iconSourceUrl = "https://www.visualpharm.com/free-icons/smart%20playlist-595b40b85ba036ed117daac8";
            string direcIconSourceUrl = "https://icons8.com/icon/31561/smart-playlist";
            string iconOwnerUrl = "https://icons8.com/";

            LinkLabel.Link iconLink = new LinkLabel.Link(0, 14, iconSourceUrl);
            iconLinkLabel.Links.Add(iconLink);

            LinkLabel.Link iconOwnerLink = new LinkLabel.Link(18, 10, iconOwnerUrl);
            iconLinkLabel.Links.Add(iconOwnerLink);
            linkLabelToolTip.SetToolTip(iconLinkLabel, iconSourceUrl + "\n" + iconOwnerUrl);

            //LinkedLabels - project
            string releasesUrl = "https://github.com/Sogolumbo/Playlist-Sync/releases";
            string issuesUrl = "https://github.com/Sogolumbo/Playlist-Sync/issues";
            string sourceCodeUrl = "https://github.com/Sogolumbo/Playlist-Sync";

            LinkLabel.Link releasesLink = new LinkLabel.Link(0, releasesLinkLabel.Text.Length, releasesUrl);
            releasesLinkLabel.Links.Add(releasesLink);
            linkLabelToolTip.SetToolTip(releasesLinkLabel, releasesUrl);
            LinkLabel.Link issuesLink = new LinkLabel.Link(0, issuesLinkLabel.Text.Length, issuesUrl);
            issuesLinkLabel.Links.Add(issuesLink);
            linkLabelToolTip.SetToolTip(issuesLinkLabel, issuesUrl);
            LinkLabel.Link sourceCodeLink = new LinkLabel.Link(0, sourceCodeLinkLabel.Text.Length, sourceCodeUrl);
            sourceCodeLinkLabel.Links.Add(sourceCodeLink);
            linkLabelToolTip.SetToolTip(sourceCodeLinkLabel, sourceCodeUrl);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new MultiplePlaylistConversionForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new PlaylistConverterPreviewForm());
        }

        private void OpenForm(Form window)
        {
            window.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm(new EditPlaylistForm());
        }

        private void editMusicLibraryButton_Click(object sender, EventArgs e)
        {
            OpenForm(new EditMusicLibraryForm());
        }

        private void cleanM3uFilesButton_Click(object sender, EventArgs e)
        {
            OpenForm(new M3uCleanerGUI());
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void openSettingsFolderButton_Click(object sender, EventArgs e)
        {
            OpenPathWithStandardApplication(Properties.Resources.SettingsFilePath);
        }
    }
}
