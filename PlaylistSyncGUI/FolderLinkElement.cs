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
using System.IO;
using System.Text.RegularExpressions;

namespace PlaylistConverterGUI
{
    public partial class FolderLinkElement : UserControl
    {
        public FolderLinkElement(KeyValuePair<string, string> pair) : this(pair.Key, pair.Value)
        {
        }
        public FolderLinkElement(string source, string target)
        {
            InitializeComponent();
            sourceTextBox.Text = source;
            targetTextBox.Text = target;

            sourceTextBox.TextChanged += TextBox_TextChanged;
            targetTextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            sourceTextBox.ResetBackColor();
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public string SourceFolder
        {
            get => sourceTextBox.Text;
        }
        public string TargetFolder
        {
            get => targetTextBox.Text;
        }
        public KeyValuePair<string, string> FolderLink
        {
            get => new KeyValuePair<string, string>(SourceFolder, TargetFolder);
        }

        public event EventHandler Remove;
        public event EventHandler Changed;

        private void removeButton_Click(object sender, EventArgs e)
        {
            Remove?.Invoke(this, EventArgs.Empty);
        }

        internal void ShowError()
        {
            sourceTextBox.BackColor = Color.FromArgb(250, 210, 220);
        }
    }
}
