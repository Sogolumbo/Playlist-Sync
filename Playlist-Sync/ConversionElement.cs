using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Playlist;

namespace PlaylistConverterGUI
{
    public partial class ConversionElement : UserControl
    {
        public ConversionElement(Conversion conversion)
        {
            Conversion = conversion;
            InitializeComponent();
            titleLabel.Text = conversion.Title;
            sourcePathLabel.Text = conversion.SourceFolderPath;
            sourceTypeLabel.Text = conversion.SourcePlaylistType.ToString();
            targetPathLabel.Text = conversion.TargetFolderPath;
            targetTypeLabel.Text = conversion.TargetPlaylistType.ToString();
        }

        public Conversion Conversion { get; set; }

        private void ConversionElement_Load(object sender, EventArgs e)
        {
            titleLabel.Font = new Font(Font.FontFamily, Font.Size * 1.25f);            
        }
    }
}
