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
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.removeSelectedFolderButton = new System.Windows.Forms.Button();
            this.selectedFolderFilepathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.AddPlaylistButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.removeSelectedPlaylistButton = new System.Windows.Forms.Button();
            this.selectedPlaylistFilepathLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.foldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.Location = new System.Drawing.Point(6, 19);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.Size = new System.Drawing.Size(369, 355);
            this.foldersListBox.TabIndex = 1;
            this.foldersListBox.SelectedValueChanged += new System.EventHandler(this.foldersListBox_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.foldersListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(1085, 245);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(378, 23);
            this.AddFolderButton.TabIndex = 50;
            this.AddFolderButton.Text = "Add Folder";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeSelectedFolderButton);
            this.groupBox2.Controls.Add(this.selectedFolderFilepathLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1085, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 88);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Folder";
            // 
            // removeSelectedFolderButton
            // 
            this.removeSelectedFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeSelectedFolderButton.Enabled = false;
            this.removeSelectedFolderButton.Location = new System.Drawing.Point(6, 59);
            this.removeSelectedFolderButton.Name = "removeSelectedFolderButton";
            this.removeSelectedFolderButton.Size = new System.Drawing.Size(366, 23);
            this.removeSelectedFolderButton.TabIndex = 41;
            this.removeSelectedFolderButton.Text = "Remove selected Folder";
            this.removeSelectedFolderButton.UseVisualStyleBackColor = true;
            this.removeSelectedFolderButton.Click += new System.EventHandler(this.removeSelectedFolderButton_Click);
            // 
            // selectedFolderFilepathLabel
            // 
            this.selectedFolderFilepathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedFolderFilepathLabel.Location = new System.Drawing.Point(41, 23);
            this.selectedFolderFilepathLabel.Name = "selectedFolderFilepathLabel";
            this.selectedFolderFilepathLabel.Size = new System.Drawing.Size(331, 33);
            this.selectedFolderFilepathLabel.TabIndex = 2;
            this.selectedFolderFilepathLabel.Text = "(no folder selected)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.playlistListBox);
            this.groupBox3.Location = new System.Drawing.Point(399, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 387);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Playlists";
            // 
            // playlistListBox
            // 
            this.playlistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.Location = new System.Drawing.Point(6, 19);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(668, 355);
            this.playlistListBox.TabIndex = 11;
            this.playlistListBox.SelectedValueChanged += new System.EventHandler(this.playlistsListBox_SelectedValueChanged);
            // 
            // AddPlaylistButton
            // 
            this.AddPlaylistButton.Location = new System.Drawing.Point(1085, 122);
            this.AddPlaylistButton.Name = "AddPlaylistButton";
            this.AddPlaylistButton.Size = new System.Drawing.Size(381, 23);
            this.AddPlaylistButton.TabIndex = 30;
            this.AddPlaylistButton.Text = "Add Playlists";
            this.AddPlaylistButton.UseVisualStyleBackColor = true;
            this.AddPlaylistButton.Click += new System.EventHandler(this.AddPlaylistButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.removeSelectedPlaylistButton);
            this.groupBox4.Controls.Add(this.selectedPlaylistFilepathLabel);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(1085, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 103);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected Playlist";
            // 
            // removeSelectedPlaylistButton
            // 
            this.removeSelectedPlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeSelectedPlaylistButton.Enabled = false;
            this.removeSelectedPlaylistButton.Location = new System.Drawing.Point(6, 74);
            this.removeSelectedPlaylistButton.Name = "removeSelectedPlaylistButton";
            this.removeSelectedPlaylistButton.Size = new System.Drawing.Size(369, 23);
            this.removeSelectedPlaylistButton.TabIndex = 21;
            this.removeSelectedPlaylistButton.Text = "Remove selected Playlist";
            this.removeSelectedPlaylistButton.UseVisualStyleBackColor = true;
            this.removeSelectedPlaylistButton.Click += new System.EventHandler(this.removeSelectedPlaylistButton_Click);
            // 
            // selectedPlaylistFilepathLabel
            // 
            this.selectedPlaylistFilepathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedPlaylistFilepathLabel.Location = new System.Drawing.Point(56, 23);
            this.selectedPlaylistFilepathLabel.Name = "selectedPlaylistFilepathLabel";
            this.selectedPlaylistFilepathLabel.Size = new System.Drawing.Size(319, 48);
            this.selectedPlaylistFilepathLabel.TabIndex = 3;
            this.selectedPlaylistFilepathLabel.Text = "(no playlist selected)";
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
            // openPlaylistDialog
            // 
            this.openPlaylistDialog.FileName = "Playlist.m3u";
            this.openPlaylistDialog.Multiselect = true;
            // 
            // ConfigureMusicLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 412);
            this.Controls.Add(this.AddFolderButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.AddPlaylistButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "ConfigureMusicLibrary";
            this.Text = "Configure Music Library";
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
        private System.Windows.Forms.ListBox playlistListBox;
        private System.Windows.Forms.Button removeSelectedFolderButton;
        private System.Windows.Forms.Button removeSelectedPlaylistButton;
        private System.Windows.Forms.OpenFileDialog openPlaylistDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}