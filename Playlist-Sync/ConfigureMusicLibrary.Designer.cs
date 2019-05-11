namespace PlaylistConverterGUI
{
    partial class ConfigureMusicLibrary
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
            this.foldersListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playlistsListBox = new System.Windows.Forms.ListBox();
            this.selectedFolderFilepathLabel = new System.Windows.Forms.Label();
            this.selectedPlaylistFilepathLabel = new System.Windows.Forms.Label();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.AddPlaylistButton = new System.Windows.Forms.Button();
            this.removeSelectedFolderButton = new System.Windows.Forms.Button();
            this.removeSelectedPlaylistButton = new System.Windows.Forms.Button();
            this.openPlaylistDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldersListBox
            // 
            this.foldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.Location = new System.Drawing.Point(6, 19);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.Size = new System.Drawing.Size(249, 511);
            this.foldersListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.AddFolderButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.foldersListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 540);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeSelectedFolderButton);
            this.groupBox2.Controls.Add(this.selectedFolderFilepathLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(262, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filepath";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.AddPlaylistButton);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.playlistsListBox);
            this.groupBox3.Location = new System.Drawing.Point(666, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(648, 540);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Playlists";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.removeSelectedPlaylistButton);
            this.groupBox4.Controls.Add(this.selectedPlaylistFilepathLabel);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(261, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 74);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filepath";
            // 
            // playlistsListBox
            // 
            this.playlistsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.playlistsListBox.FormattingEnabled = true;
            this.playlistsListBox.Location = new System.Drawing.Point(6, 19);
            this.playlistsListBox.Name = "playlistsListBox";
            this.playlistsListBox.Size = new System.Drawing.Size(249, 511);
            this.playlistsListBox.TabIndex = 0;
            // 
            // selectedFolderFilepathLabel
            // 
            this.selectedFolderFilepathLabel.AutoSize = true;
            this.selectedFolderFilepathLabel.Location = new System.Drawing.Point(56, 23);
            this.selectedFolderFilepathLabel.Name = "selectedFolderFilepathLabel";
            this.selectedFolderFilepathLabel.Size = new System.Drawing.Size(97, 13);
            this.selectedFolderFilepathLabel.TabIndex = 2;
            this.selectedFolderFilepathLabel.Text = "(no folder selected)";
            // 
            // selectedPlaylistFilepathLabel
            // 
            this.selectedPlaylistFilepathLabel.AutoSize = true;
            this.selectedPlaylistFilepathLabel.Location = new System.Drawing.Point(56, 23);
            this.selectedPlaylistFilepathLabel.Name = "selectedPlaylistFilepathLabel";
            this.selectedPlaylistFilepathLabel.Size = new System.Drawing.Size(102, 13);
            this.selectedPlaylistFilepathLabel.TabIndex = 3;
            this.selectedPlaylistFilepathLabel.Text = "(no playlist selected)";
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(262, 100);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(380, 23);
            this.AddFolderButton.TabIndex = 2;
            this.AddFolderButton.Text = "Add Folder";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // AddPlaylistButton
            // 
            this.AddPlaylistButton.Location = new System.Drawing.Point(261, 100);
            this.AddPlaylistButton.Name = "AddPlaylistButton";
            this.AddPlaylistButton.Size = new System.Drawing.Size(381, 23);
            this.AddPlaylistButton.TabIndex = 3;
            this.AddPlaylistButton.Text = "Add Playlist";
            this.AddPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // removeSelectedFolderButton
            // 
            this.removeSelectedFolderButton.Location = new System.Drawing.Point(6, 45);
            this.removeSelectedFolderButton.Name = "removeSelectedFolderButton";
            this.removeSelectedFolderButton.Size = new System.Drawing.Size(368, 23);
            this.removeSelectedFolderButton.TabIndex = 3;
            this.removeSelectedFolderButton.Text = "Remove selected Folder";
            this.removeSelectedFolderButton.UseVisualStyleBackColor = true;
            // 
            // removeSelectedPlaylistButton
            // 
            this.removeSelectedPlaylistButton.Location = new System.Drawing.Point(6, 45);
            this.removeSelectedPlaylistButton.Name = "removeSelectedPlaylistButton";
            this.removeSelectedPlaylistButton.Size = new System.Drawing.Size(369, 23);
            this.removeSelectedPlaylistButton.TabIndex = 4;
            this.removeSelectedPlaylistButton.Text = "Remove selected Playlist";
            this.removeSelectedPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // openPlaylistDialog
            // 
            this.openPlaylistDialog.FileName = "Playlist.m3u";
            // 
            // ConfigureMusicLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 565);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigureMusicLibrary";
            this.Text = "EditMusicLibrary";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox foldersListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label selectedFolderFilepathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AddPlaylistButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label selectedPlaylistFilepathLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox playlistsListBox;
        private System.Windows.Forms.Button removeSelectedFolderButton;
        private System.Windows.Forms.Button removeSelectedPlaylistButton;
        private System.Windows.Forms.OpenFileDialog openPlaylistDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}