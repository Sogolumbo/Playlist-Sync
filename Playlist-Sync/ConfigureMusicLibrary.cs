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
    public partial class ConfigureMusicLibrary : Form
    {
        public ConfigureMusicLibrary( )
        {
            InitializeComponent();

        }

        public List<string> Playlists { get; set; }
        public List<string> Folders{ get; set; }

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }
    }
}
