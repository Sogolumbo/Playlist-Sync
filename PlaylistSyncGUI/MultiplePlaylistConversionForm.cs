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
using Newtonsoft.Json;

namespace PlaylistSyncGUI
{
    public partial class MultiplePlaylistConversionForm : Form
    {
        public MultiplePlaylistConversionForm()
        {
            InitializeComponent();
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.ConversionsAsJson))
            {
                Conversions = new Conversion[] { };
            }
            else
            {
                Conversions = JsonConvert.DeserializeObject<Conversion[]>(Properties.Settings.Default.ConversionsAsJson);
            }
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
            foreach (Conversion conv in Conversions)
            {
                ConversionElement convElement = new ConversionElement(conv);
                convElement.Width = conversionElementWidth();
                conversionsFlowLayoutPanel.Controls.Add(convElement);
                convElement.Remove += ConvElement_Remove;
                convElement.Edit += ConvElement_Edit;
            }
        }

        private int conversionElementWidth()
        {
            return conversionsFlowLayoutPanel.Width - 25;
        }

        private void ConvElement_Edit(object sender, ConversionEventArgs e)
        {
            ShowEditConversionForm(e.Conversion);
        }

        private void ConvElement_Remove(object sender, ConversionEventArgs e)
        {
            RemoveConversion(e.Conversion);
        }

        private void addConversionButton_Click(object sender, EventArgs e)
        {
            Conversion conversion = new Conversion();
            ShowEditConversionForm(conversion);
            AddConversion(conversion);
        }

        private void ShowEditConversionForm(Conversion conversion)
        {
            EditPlaylistConversionForm editPlaylistConversionForm = new EditPlaylistConversionForm(conversion);
            editPlaylistConversionForm.OK += EditPlaylistConversionForm_OK;
            editPlaylistConversionForm.Show();
        }

        private void EditPlaylistConversionForm_OK(object sender, EventArgs e)
        {
            SetConversionElements();
        }

        public void AddConversion(Conversion conversion)
        {
            var conversions = Conversions.ToList();
            conversions.Add(conversion);
            Conversions = conversions.ToArray<Conversion>();
        }
        public void RemoveConversion(Conversion conversion)
        {
            var conversions = Conversions.ToList();
            conversions.Remove(conversion);
            Conversions = conversions.ToArray<Conversion>();
        }

        private void MultiplePlaylistConversionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ConversionsAsJson = JsonConvert.SerializeObject(Conversions);
            Properties.Settings.Default.Save();
        }

        private void conversionsFlowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void ResizeControls()
        {
            foreach(Control control in conversionsFlowLayoutPanel.Controls)
            {
                control.Width = conversionElementWidth();
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            PlaylistConverterPreviewForm playlistConverterPreviewForm = new PlaylistConverterPreviewForm();
            playlistConverterPreviewForm.Show();
        }
    }
}
