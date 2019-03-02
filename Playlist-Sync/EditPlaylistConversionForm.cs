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

namespace PlaylistConverterGUI
{
    public partial class EditPlaylistConversionForm : Form
    {
        public EditPlaylistConversionForm(Conversion conversion)
        {
            Conversion = conversion;
            InitializeComponent();
            sourcePlaylistTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistType));
            targetPlaylistTypeComboBox.DataSource = Enum.GetValues(typeof(PlaylistType));
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
            Conversion.SourceFolderPath = sourceFolderPathTextBox.Text;
            Conversion.SourcePlaylistType = (PlaylistType)sourcePlaylistTypeComboBox.SelectedItem;
            Conversion.TargetFolderPath = targetFolderPathTextBox.Text;
            Conversion.TargetPlaylistType = (PlaylistType)targetPlaylistTypeComboBox.SelectedItem;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
