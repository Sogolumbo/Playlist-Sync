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
            this.sourceFolderPathLabel = new System.Windows.Forms.Label();
            this.sourceFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.sourcePlaylistTypeLabel = new System.Windows.Forms.Label();
            this.targetFolderPathLabel = new System.Windows.Forms.Label();
            this.targetFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.targetPlaylistTypeLabel = new System.Windows.Forms.Label();
            this.sourcePlaylistTypeComboBox = new System.Windows.Forms.ComboBox();
            this.targetPlaylistTypeComboBox = new System.Windows.Forms.ComboBox();
            this.FoundFilesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(121, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(412, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(458, 198);
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
            this.cancelButton.Location = new System.Drawing.Point(377, 198);
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
            // sourceFolderPathLabel
            // 
            this.sourceFolderPathLabel.AutoSize = true;
            this.sourceFolderPathLabel.Location = new System.Drawing.Point(12, 41);
            this.sourceFolderPathLabel.Name = "sourceFolderPathLabel";
            this.sourceFolderPathLabel.Size = new System.Drawing.Size(101, 13);
            this.sourceFolderPathLabel.TabIndex = 5;
            this.sourceFolderPathLabel.Text = "Source Folder Path:";
            // 
            // sourceFolderPathTextBox
            // 
            this.sourceFolderPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFolderPathTextBox.Location = new System.Drawing.Point(121, 38);
            this.sourceFolderPathTextBox.Name = "sourceFolderPathTextBox";
            this.sourceFolderPathTextBox.Size = new System.Drawing.Size(412, 20);
            this.sourceFolderPathTextBox.TabIndex = 4;
            // 
            // sourcePlaylistTypeLabel
            // 
            this.sourcePlaylistTypeLabel.AutoSize = true;
            this.sourcePlaylistTypeLabel.Location = new System.Drawing.Point(12, 67);
            this.sourcePlaylistTypeLabel.Name = "sourcePlaylistTypeLabel";
            this.sourcePlaylistTypeLabel.Size = new System.Drawing.Size(106, 13);
            this.sourcePlaylistTypeLabel.TabIndex = 7;
            this.sourcePlaylistTypeLabel.Text = "Source Playlist Type:";
            // 
            // targetFolderPathLabel
            // 
            this.targetFolderPathLabel.AutoSize = true;
            this.targetFolderPathLabel.Location = new System.Drawing.Point(12, 94);
            this.targetFolderPathLabel.Name = "targetFolderPathLabel";
            this.targetFolderPathLabel.Size = new System.Drawing.Size(98, 13);
            this.targetFolderPathLabel.TabIndex = 9;
            this.targetFolderPathLabel.Text = "Target Folder Path:";
            // 
            // targetFolderPathTextBox
            // 
            this.targetFolderPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFolderPathTextBox.Location = new System.Drawing.Point(121, 91);
            this.targetFolderPathTextBox.Name = "targetFolderPathTextBox";
            this.targetFolderPathTextBox.Size = new System.Drawing.Size(412, 20);
            this.targetFolderPathTextBox.TabIndex = 8;
            // 
            // targetPlaylistTypeLabel
            // 
            this.targetPlaylistTypeLabel.AutoSize = true;
            this.targetPlaylistTypeLabel.Location = new System.Drawing.Point(12, 120);
            this.targetPlaylistTypeLabel.Name = "targetPlaylistTypeLabel";
            this.targetPlaylistTypeLabel.Size = new System.Drawing.Size(103, 13);
            this.targetPlaylistTypeLabel.TabIndex = 11;
            this.targetPlaylistTypeLabel.Text = "Target Playlist Type:";
            // 
            // sourcePlaylistTypeComboBox
            // 
            this.sourcePlaylistTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourcePlaylistTypeComboBox.FormattingEnabled = true;
            this.sourcePlaylistTypeComboBox.Location = new System.Drawing.Point(121, 64);
            this.sourcePlaylistTypeComboBox.Name = "sourcePlaylistTypeComboBox";
            this.sourcePlaylistTypeComboBox.Size = new System.Drawing.Size(412, 21);
            this.sourcePlaylistTypeComboBox.TabIndex = 12;
            // 
            // targetPlaylistTypeComboBox
            // 
            this.targetPlaylistTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetPlaylistTypeComboBox.FormattingEnabled = true;
            this.targetPlaylistTypeComboBox.Location = new System.Drawing.Point(121, 117);
            this.targetPlaylistTypeComboBox.Name = "targetPlaylistTypeComboBox";
            this.targetPlaylistTypeComboBox.Size = new System.Drawing.Size(412, 21);
            this.targetPlaylistTypeComboBox.TabIndex = 13;
            // 
            // FoundFilesLabel
            // 
            this.FoundFilesLabel.AutoSize = true;
            this.FoundFilesLabel.Location = new System.Drawing.Point(12, 148);
            this.FoundFilesLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.FoundFilesLabel.Name = "FoundFilesLabel";
            this.FoundFilesLabel.Size = new System.Drawing.Size(75, 13);
            this.FoundFilesLabel.TabIndex = 14;
            this.FoundFilesLabel.Text = "No files found.";
            // 
            // EditPlaylistConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 232);
            this.Controls.Add(this.FoundFilesLabel);
            this.Controls.Add(this.targetPlaylistTypeComboBox);
            this.Controls.Add(this.sourcePlaylistTypeComboBox);
            this.Controls.Add(this.targetPlaylistTypeLabel);
            this.Controls.Add(this.targetFolderPathLabel);
            this.Controls.Add(this.targetFolderPathTextBox);
            this.Controls.Add(this.sourcePlaylistTypeLabel);
            this.Controls.Add(this.sourceFolderPathLabel);
            this.Controls.Add(this.sourceFolderPathTextBox);
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
        private System.Windows.Forms.Label sourceFolderPathLabel;
        private System.Windows.Forms.TextBox sourceFolderPathTextBox;
        private System.Windows.Forms.Label sourcePlaylistTypeLabel;
        private System.Windows.Forms.Label targetFolderPathLabel;
        private System.Windows.Forms.TextBox targetFolderPathTextBox;
        private System.Windows.Forms.Label targetPlaylistTypeLabel;
        private System.Windows.Forms.ComboBox sourcePlaylistTypeComboBox;
        private System.Windows.Forms.ComboBox targetPlaylistTypeComboBox;
        private System.Windows.Forms.Label FoundFilesLabel;
    }
}