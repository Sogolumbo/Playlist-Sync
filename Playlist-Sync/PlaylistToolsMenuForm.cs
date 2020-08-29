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

namespace PlaylistConverterGUI
{
    public partial class PlaylistToolsMenuForm : Form
    {
        public PlaylistToolsMenuForm()
        {
            InitializeComponent();

            string iconSourceLink = "https://www.visualpharm.com/free-icons/smart%20playlist-595b40b85ba036ed117daac8";
            LinkLabel.Link iconLink = new LinkLabel.Link(0, iconLinkLabel.Text.Length, iconSourceLink);
            iconLinkLabel.Links.Add(iconLink);
            iconLinkToolTip.SetToolTip(iconLinkLabel, iconSourceLink);
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

        private void iconLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
