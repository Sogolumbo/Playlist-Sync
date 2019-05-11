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
    public partial class PlaylistToolsMenuForm : Form
    {
        public PlaylistToolsMenuForm()
        {
            InitializeComponent();
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
    }
}
