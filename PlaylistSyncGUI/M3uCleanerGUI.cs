using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaylistSyncGUI
{
    public partial class M3uCleanerGUI : Form
    {
        public M3uCleanerGUI()
        {
            InitializeComponent();
            toolTip.SetToolTip(cleanFilesButton, "Removes Metadata (indicated with #EXT...) and empty lines.");
        }

        private void M3uCleanerGUI_Load(object sender, EventArgs e)
        {
            filePathRichTextBox.Text = String.Join(Environment.NewLine, openFileDialog.FileNames);
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePathRichTextBox.Text = String.Join(Environment.NewLine, openFileDialog.FileNames);
        }

        private void cleanFilesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (string file in openFileDialog.FileNames)
            {
                Playlist.M3uCleaner.CleanFile(file, fixRelativePathCheckBox.Checked);
            }
            Cursor = DefaultCursor;            
        }
    }
}
