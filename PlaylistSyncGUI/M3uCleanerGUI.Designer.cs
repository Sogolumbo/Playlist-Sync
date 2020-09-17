namespace PlaylistConverterGUI
{
    partial class M3uCleanerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cleanFilesButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.fixRelativePathCheckBox = new System.Windows.Forms.CheckBox();
            this.filePathRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cleanFilesButton
            // 
            this.cleanFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanFilesButton.Location = new System.Drawing.Point(393, 466);
            this.cleanFilesButton.Name = "cleanFilesButton";
            this.cleanFilesButton.Size = new System.Drawing.Size(130, 46);
            this.cleanFilesButton.TabIndex = 0;
            this.cleanFilesButton.Text = "Clean file(s)";
            this.cleanFilesButton.UseVisualStyleBackColor = true;
            this.cleanFilesButton.Click += new System.EventHandler(this.cleanFilesButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "playlist.m3u";
            this.openFileDialog.Filter = "M3u-Playlist|*.m3u|All files|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFilesButton.Location = new System.Drawing.Point(12, 12);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(511, 36);
            this.selectFilesButton.TabIndex = 2;
            this.selectFilesButton.Text = "Select Files...";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // fixRelativePathCheckBox
            // 
            this.fixRelativePathCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fixRelativePathCheckBox.AutoSize = true;
            this.fixRelativePathCheckBox.Checked = true;
            this.fixRelativePathCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fixRelativePathCheckBox.Location = new System.Drawing.Point(12, 466);
            this.fixRelativePathCheckBox.Name = "fixRelativePathCheckBox";
            this.fixRelativePathCheckBox.Size = new System.Drawing.Size(212, 17);
            this.fixRelativePathCheckBox.TabIndex = 3;
            this.fixRelativePathCheckBox.Text = "convert relative paths to absolute paths";
            this.fixRelativePathCheckBox.UseVisualStyleBackColor = true;
            // 
            // filePathRichTextBox
            // 
            this.filePathRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathRichTextBox.Location = new System.Drawing.Point(12, 54);
            this.filePathRichTextBox.Name = "filePathRichTextBox";
            this.filePathRichTextBox.ReadOnly = true;
            this.filePathRichTextBox.Size = new System.Drawing.Size(511, 406);
            this.filePathRichTextBox.TabIndex = 4;
            this.filePathRichTextBox.Text = "";
            // 
            // M3uCleanerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 524);
            this.Controls.Add(this.filePathRichTextBox);
            this.Controls.Add(this.fixRelativePathCheckBox);
            this.Controls.Add(this.selectFilesButton);
            this.Controls.Add(this.cleanFilesButton);
            this.Name = "M3uCleanerGUI";
            this.Text = "M3uCleanerGUI";
            this.Load += new System.EventHandler(this.M3uCleanerGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cleanFilesButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button selectFilesButton;
        private System.Windows.Forms.CheckBox fixRelativePathCheckBox;
        private System.Windows.Forms.RichTextBox filePathRichTextBox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}