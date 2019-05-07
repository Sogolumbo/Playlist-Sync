namespace PlaylistConverterGUI
{
    partial class EditPlaylistConversionForm
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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sourcePlaylistFolderLabel = new System.Windows.Forms.Label();
            this.sourcePlaylistFolderTextBox = new System.Windows.Forms.TextBox();
            this.sourcePlaylistTypeLabel = new System.Windows.Forms.Label();
            this.targetPlaylistFolderLabel = new System.Windows.Forms.Label();
            this.targetPlaylistFolderTextBox = new System.Windows.Forms.TextBox();
            this.targetPlaylistTypeLabel = new System.Windows.Forms.Label();
            this.sourcePlaylistTypeComboBox = new System.Windows.Forms.ComboBox();
            this.targetPlaylistTypeComboBox = new System.Windows.Forms.ComboBox();
            this.sourceMusicFolderLabel = new System.Windows.Forms.Label();
            this.sourceMusicFolderTextBox = new System.Windows.Forms.TextBox();
            this.sourceUseSlashAsSeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.targetMusicFolderLabel = new System.Windows.Forms.Label();
            this.targetMusicFolderTextBox = new System.Windows.Forms.TextBox();
            this.targetUseSlashAsSeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(125, 12);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(408, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(458, 269);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(377, 269);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title:";
            // 
            // sourcePlaylistFolderLabel
            // 
            this.sourcePlaylistFolderLabel.AutoSize = true;
            this.sourcePlaylistFolderLabel.Location = new System.Drawing.Point(12, 53);
            this.sourcePlaylistFolderLabel.Name = "sourcePlaylistFolderLabel";
            this.sourcePlaylistFolderLabel.Size = new System.Drawing.Size(111, 13);
            this.sourcePlaylistFolderLabel.TabIndex = 5;
            this.sourcePlaylistFolderLabel.Text = "Source Playlist Folder:";
            // 
            // sourcePlaylistFolderTextBox
            // 
            this.sourcePlaylistFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePlaylistFolderTextBox.Location = new System.Drawing.Point(125, 50);
            this.sourcePlaylistFolderTextBox.Name = "sourcePlaylistFolderTextBox";
            this.sourcePlaylistFolderTextBox.Size = new System.Drawing.Size(408, 20);
            this.sourcePlaylistFolderTextBox.TabIndex = 4;
            // 
            // sourcePlaylistTypeLabel
            // 
            this.sourcePlaylistTypeLabel.AutoSize = true;
            this.sourcePlaylistTypeLabel.Location = new System.Drawing.Point(12, 79);
            this.sourcePlaylistTypeLabel.Name = "sourcePlaylistTypeLabel";
            this.sourcePlaylistTypeLabel.Size = new System.Drawing.Size(106, 13);
            this.sourcePlaylistTypeLabel.TabIndex = 7;
            this.sourcePlaylistTypeLabel.Text = "Source Playlist Type:";
            // 
            // targetPlaylistFolderLabel
            // 
            this.targetPlaylistFolderLabel.AutoSize = true;
            this.targetPlaylistFolderLabel.Location = new System.Drawing.Point(12, 164);
            this.targetPlaylistFolderLabel.Name = "targetPlaylistFolderLabel";
            this.targetPlaylistFolderLabel.Size = new System.Drawing.Size(108, 13);
            this.targetPlaylistFolderLabel.TabIndex = 9;
            this.targetPlaylistFolderLabel.Text = "Target Playlist Folder:";
            // 
            // targetPlaylistFolderTextBox
            // 
            this.targetPlaylistFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPlaylistFolderTextBox.Location = new System.Drawing.Point(125, 161);
            this.targetPlaylistFolderTextBox.Name = "targetPlaylistFolderTextBox";
            this.targetPlaylistFolderTextBox.Size = new System.Drawing.Size(408, 20);
            this.targetPlaylistFolderTextBox.TabIndex = 8;
            // 
            // targetPlaylistTypeLabel
            // 
            this.targetPlaylistTypeLabel.AutoSize = true;
            this.targetPlaylistTypeLabel.Location = new System.Drawing.Point(12, 190);
            this.targetPlaylistTypeLabel.Name = "targetPlaylistTypeLabel";
            this.targetPlaylistTypeLabel.Size = new System.Drawing.Size(103, 13);
            this.targetPlaylistTypeLabel.TabIndex = 11;
            this.targetPlaylistTypeLabel.Text = "Target Playlist Type:";
            // 
            // sourcePlaylistTypeComboBox
            // 
            this.sourcePlaylistTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePlaylistTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourcePlaylistTypeComboBox.FormattingEnabled = true;
            this.sourcePlaylistTypeComboBox.Location = new System.Drawing.Point(125, 76);
            this.sourcePlaylistTypeComboBox.Name = "sourcePlaylistTypeComboBox";
            this.sourcePlaylistTypeComboBox.Size = new System.Drawing.Size(408, 21);
            this.sourcePlaylistTypeComboBox.TabIndex = 12;
            // 
            // targetPlaylistTypeComboBox
            // 
            this.targetPlaylistTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPlaylistTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetPlaylistTypeComboBox.FormattingEnabled = true;
            this.targetPlaylistTypeComboBox.Location = new System.Drawing.Point(125, 187);
            this.targetPlaylistTypeComboBox.Name = "targetPlaylistTypeComboBox";
            this.targetPlaylistTypeComboBox.Size = new System.Drawing.Size(408, 21);
            this.targetPlaylistTypeComboBox.TabIndex = 13;
            // 
            // sourceMusicFolderLabel
            // 
            this.sourceMusicFolderLabel.AutoSize = true;
            this.sourceMusicFolderLabel.Location = new System.Drawing.Point(12, 106);
            this.sourceMusicFolderLabel.Name = "sourceMusicFolderLabel";
            this.sourceMusicFolderLabel.Size = new System.Drawing.Size(107, 13);
            this.sourceMusicFolderLabel.TabIndex = 15;
            this.sourceMusicFolderLabel.Text = "Source Music Folder:";
            // 
            // sourceMusicFolderTextBox
            // 
            this.sourceMusicFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceMusicFolderTextBox.Location = new System.Drawing.Point(125, 103);
            this.sourceMusicFolderTextBox.Name = "sourceMusicFolderTextBox";
            this.sourceMusicFolderTextBox.Size = new System.Drawing.Size(408, 20);
            this.sourceMusicFolderTextBox.TabIndex = 14;
            // 
            // sourceUseSlashAsSeperatorCheckBox
            // 
            this.sourceUseSlashAsSeperatorCheckBox.AutoSize = true;
            this.sourceUseSlashAsSeperatorCheckBox.Location = new System.Drawing.Point(12, 131);
            this.sourceUseSlashAsSeperatorCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.sourceUseSlashAsSeperatorCheckBox.Name = "sourceUseSlashAsSeperatorCheckBox";
            this.sourceUseSlashAsSeperatorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sourceUseSlashAsSeperatorCheckBox.Size = new System.Drawing.Size(184, 17);
            this.sourceUseSlashAsSeperatorCheckBox.TabIndex = 16;
            this.sourceUseSlashAsSeperatorCheckBox.Text = "Source uses slashes as seperator";
            this.sourceUseSlashAsSeperatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // targetMusicFolderLabel
            // 
            this.targetMusicFolderLabel.AutoSize = true;
            this.targetMusicFolderLabel.Location = new System.Drawing.Point(12, 217);
            this.targetMusicFolderLabel.Name = "targetMusicFolderLabel";
            this.targetMusicFolderLabel.Size = new System.Drawing.Size(104, 13);
            this.targetMusicFolderLabel.TabIndex = 20;
            this.targetMusicFolderLabel.Text = "Target Music Folder:";
            // 
            // targetMusicFolderTextBox
            // 
            this.targetMusicFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetMusicFolderTextBox.Location = new System.Drawing.Point(125, 214);
            this.targetMusicFolderTextBox.Name = "targetMusicFolderTextBox";
            this.targetMusicFolderTextBox.Size = new System.Drawing.Size(408, 20);
            this.targetMusicFolderTextBox.TabIndex = 19;
            // 
            // targetUseSlashAsSeperatorCheckBox
            // 
            this.targetUseSlashAsSeperatorCheckBox.AutoSize = true;
            this.targetUseSlashAsSeperatorCheckBox.Location = new System.Drawing.Point(12, 240);
            this.targetUseSlashAsSeperatorCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.targetUseSlashAsSeperatorCheckBox.Name = "targetUseSlashAsSeperatorCheckBox";
            this.targetUseSlashAsSeperatorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.targetUseSlashAsSeperatorCheckBox.Size = new System.Drawing.Size(181, 17);
            this.targetUseSlashAsSeperatorCheckBox.TabIndex = 21;
            this.targetUseSlashAsSeperatorCheckBox.Text = "Target uses slashes as seperator";
            this.targetUseSlashAsSeperatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // EditPlaylistConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 303);
            this.Controls.Add(this.targetUseSlashAsSeperatorCheckBox);
            this.Controls.Add(this.targetMusicFolderLabel);
            this.Controls.Add(this.targetMusicFolderTextBox);
            this.Controls.Add(this.sourceUseSlashAsSeperatorCheckBox);
            this.Controls.Add(this.sourceMusicFolderLabel);
            this.Controls.Add(this.sourceMusicFolderTextBox);
            this.Controls.Add(this.targetPlaylistTypeComboBox);
            this.Controls.Add(this.sourcePlaylistTypeComboBox);
            this.Controls.Add(this.targetPlaylistTypeLabel);
            this.Controls.Add(this.targetPlaylistFolderLabel);
            this.Controls.Add(this.targetPlaylistFolderTextBox);
            this.Controls.Add(this.sourcePlaylistTypeLabel);
            this.Controls.Add(this.sourcePlaylistFolderLabel);
            this.Controls.Add(this.sourcePlaylistFolderTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.titleTextBox);
            this.Name = "EditPlaylistConversionForm";
            this.Text = "EditPlaylistConversion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label sourcePlaylistFolderLabel;
        private System.Windows.Forms.TextBox sourcePlaylistFolderTextBox;
        private System.Windows.Forms.Label sourcePlaylistTypeLabel;
        private System.Windows.Forms.Label targetPlaylistFolderLabel;
        private System.Windows.Forms.TextBox targetPlaylistFolderTextBox;
        private System.Windows.Forms.Label targetPlaylistTypeLabel;
        private System.Windows.Forms.ComboBox sourcePlaylistTypeComboBox;
        private System.Windows.Forms.ComboBox targetPlaylistTypeComboBox;
        private System.Windows.Forms.Label sourceMusicFolderLabel;
        private System.Windows.Forms.TextBox sourceMusicFolderTextBox;
        private System.Windows.Forms.CheckBox sourceUseSlashAsSeperatorCheckBox;
        private System.Windows.Forms.Label targetMusicFolderLabel;
        private System.Windows.Forms.TextBox targetMusicFolderTextBox;
        private System.Windows.Forms.CheckBox targetUseSlashAsSeperatorCheckBox;
    }
}