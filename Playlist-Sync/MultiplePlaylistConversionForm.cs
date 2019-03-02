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
    public partial class MultiplePlaylistConversionForm : Form
    {
        public MultiplePlaylistConversionForm()
        {
            InitializeComponent();
            Conversions = new Conversion[]{ };
        }

        private Conversion[] _conversions;

        public Conversion[] Conversions
        {
            get { return _conversions; }
            set
            {
                _conversions = value;
                SetConversionElements();
            }
        }

        private void SetConversionElements()
        {
            conversionsFlowLayoutPanel.Controls.Clear();
            foreach(Conversion conv in Conversions)
            {
                ConversionElement convElement = new ConversionElement(conv);
                conversionsFlowLayoutPanel.Controls.Add(convElement);
                //TODO: listen to Element Events ( Remove, ...? )
            }
        }

        private void addConversionButton_Click(object sender, EventArgs e)
        {
            Conversion conversion = new Conversion();
            EditPlaylistConversionForm editPlaylistConversionForm = new EditPlaylistConversionForm(conversion);
            editPlaylistConversionForm.OK += EditNewPlaylistConversionForm_OK;
            editPlaylistConversionForm.Show();
        }

        private void EditNewPlaylistConversionForm_OK(object sender, EventArgs e)
        {
            var conversion = ((EditPlaylistConversionForm)sender).Conversion;
            var conversions = Conversions.ToList();
            conversions.Add(conversion);
            Conversions = conversions.ToArray<Conversion>();
        }
    }
}
