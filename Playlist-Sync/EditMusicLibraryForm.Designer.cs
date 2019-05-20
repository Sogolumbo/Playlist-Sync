namespace PlaylistConverterGUI
{
    partial class EditMusicLibraryForm
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
            this.libraryTreeView = new System.Windows.Forms.TreeView();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemPathTextBox = new System.Windows.Forms.TextBox();
            this.itemTitleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectedItemGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedItemPlaylistsListBox = new System.Windows.Forms.ListBox();
            this.artistLinkLabel = new System.Windows.Forms.Label();
            this.albumLinkLabel = new System.Windows.Forms.Label();
            this.openPathInKid3Button = new System.Windows.Forms.Button();
            this.itemGenreTextBox = new System.Windows.Forms.TextBox();
            this.openPathInExplorerButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.itemTrackNumberTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.itemArtistTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.itemAlbumTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reloadAllButton = new System.Windows.Forms.Button();
            this.reloadSelectedButton = new System.Windows.Forms.Button();
            this.foldersListBox = new System.Windows.Forms.ListBox();
            this.changeFoldersButton = new System.Windows.Forms.Button();
            this.MusicFoldersGroupBox = new System.Windows.Forms.GroupBox();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.debugButton = new System.Windows.Forms.Button();
            this.openInNotepadButton = new System.Windows.Forms.Button();
            this.selectedItemGroupBox.SuspendLayout();
            this.MusicFoldersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // libraryTreeView
            // 
            this.libraryTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryTreeView.Location = new System.Drawing.Point(13, 13);
            this.libraryTreeView.Name = "libraryTreeView";
            this.libraryTreeView.Size = new System.Drawing.Size(636, 655);
            this.libraryTreeView.TabIndex = 0;
            this.libraryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.playlistTreeView_AfterSelect);
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemNameTextBox.Location = new System.Drawing.Point(56, 19);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(347, 20);
            this.itemNameTextBox.TabIndex = 2;
            // 
            // itemPathTextBox
            // 
            this.itemPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemPathTextBox.Location = new System.Drawing.Point(56, 72);
            this.itemPathTextBox.Name = "itemPathTextBox";
            this.itemPathTextBox.ReadOnly = true;
            this.itemPathTextBox.Size = new System.Drawing.Size(347, 20);
            this.itemPathTextBox.TabIndex = 3;
            // 
            // itemTitleTextBox
            // 
            this.itemTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTitleTextBox.Enabled = false;
            this.itemTitleTextBox.Location = new System.Drawing.Point(56, 272);
            this.itemTitleTextBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.itemTitleTextBox.Name = "itemTitleTextBox";
            this.itemTitleTextBox.Size = new System.Drawing.Size(347, 20);
            this.itemTitleTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Title:";
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(992, 645);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 11;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(911, 645);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectedItemGroupBox
            // 
            this.selectedItemGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedItemGroupBox.Controls.Add(this.selectedItemPlaylistsListBox);
            this.selectedItemGroupBox.Controls.Add(this.artistLinkLabel);
            this.selectedItemGroupBox.Controls.Add(this.albumLinkLabel);
            this.selectedItemGroupBox.Controls.Add(this.openPathInKid3Button);
            this.selectedItemGroupBox.Controls.Add(this.itemGenreTextBox);
            this.selectedItemGroupBox.Controls.Add(this.openPathInExplorerButton);
            this.selectedItemGroupBox.Controls.Add(this.label8);
            this.selectedItemGroupBox.Controls.Add(this.itemTrackNumberTextBox);
            this.selectedItemGroupBox.Controls.Add(this.label7);
            this.selectedItemGroupBox.Controls.Add(this.itemArtistTextBox);
            this.selectedItemGroupBox.Controls.Add(this.label6);
            this.selectedItemGroupBox.Controls.Add(this.itemAlbumTextBox);
            this.selectedItemGroupBox.Controls.Add(this.label1);
            this.selectedItemGroupBox.Controls.Add(this.itemTypeComboBox);
            this.selectedItemGroupBox.Controls.Add(this.label2);
            this.selectedItemGroupBox.Controls.Add(this.itemNameTextBox);
            this.selectedItemGroupBox.Controls.Add(this.itemPathTextBox);
            this.selectedItemGroupBox.Controls.Add(this.itemTitleTextBox);
            this.selectedItemGroupBox.Controls.Add(this.label5);
            this.selectedItemGroupBox.Controls.Add(this.label3);
            this.selectedItemGroupBox.Controls.Add(this.label4);
            this.selectedItemGroupBox.Location = new System.Drawing.Point(658, 237);
            this.selectedItemGroupBox.Name = "selectedItemGroupBox";
            this.selectedItemGroupBox.Size = new System.Drawing.Size(409, 402);
            this.selectedItemGroupBox.TabIndex = 16;
            this.selectedItemGroupBox.TabStop = false;
            this.selectedItemGroupBox.Text = "Selected Item";
            // 
            // selectedItemPlaylistsListBox
            // 
            this.selectedItemPlaylistsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedItemPlaylistsListBox.FormattingEnabled = true;
            this.selectedItemPlaylistsListBox.Location = new System.Drawing.Point(9, 134);
            this.selectedItemPlaylistsListBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.selectedItemPlaylistsListBox.Name = "selectedItemPlaylistsListBox";
            this.selectedItemPlaylistsListBox.Size = new System.Drawing.Size(394, 134);
            this.selectedItemPlaylistsListBox.TabIndex = 27;
            // 
            // artistLinkLabel
            // 
            this.artistLinkLabel.AutoSize = true;
            this.artistLinkLabel.Location = new System.Drawing.Point(384, 327);
            this.artistLinkLabel.Name = "artistLinkLabel";
            this.artistLinkLabel.Size = new System.Drawing.Size(19, 13);
            this.artistLinkLabel.TabIndex = 22;
            this.artistLinkLabel.Text = "↑2";
            // 
            // albumLinkLabel
            // 
            this.albumLinkLabel.AutoSize = true;
            this.albumLinkLabel.Location = new System.Drawing.Point(383, 301);
            this.albumLinkLabel.Name = "albumLinkLabel";
            this.albumLinkLabel.Size = new System.Drawing.Size(19, 13);
            this.albumLinkLabel.TabIndex = 21;
            this.albumLinkLabel.Text = "↑1";
            // 
            // openPathInKid3Button
            // 
            this.openPathInKid3Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openPathInKid3Button.Location = new System.Drawing.Point(280, 98);
            this.openPathInKid3Button.Name = "openPathInKid3Button";
            this.openPathInKid3Button.Size = new System.Drawing.Size(123, 23);
            this.openPathInKid3Button.TabIndex = 20;
            this.openPathInKid3Button.Text = "Open path in Kid3";
            this.openPathInKid3Button.UseVisualStyleBackColor = true;
            this.openPathInKid3Button.Click += new System.EventHandler(this.openPathInKid3Button_Click);
            // 
            // itemGenreTextBox
            // 
            this.itemGenreTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGenreTextBox.Enabled = false;
            this.itemGenreTextBox.Location = new System.Drawing.Point(56, 376);
            this.itemGenreTextBox.Name = "itemGenreTextBox";
            this.itemGenreTextBox.Size = new System.Drawing.Size(347, 20);
            this.itemGenreTextBox.TabIndex = 18;
            // 
            // openPathInExplorerButton
            // 
            this.openPathInExplorerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openPathInExplorerButton.Location = new System.Drawing.Point(151, 98);
            this.openPathInExplorerButton.Name = "openPathInExplorerButton";
            this.openPathInExplorerButton.Size = new System.Drawing.Size(123, 23);
            this.openPathInExplorerButton.TabIndex = 19;
            this.openPathInExplorerButton.Text = "Open path in explorer";
            this.openPathInExplorerButton.UseVisualStyleBackColor = true;
            this.openPathInExplorerButton.Click += new System.EventHandler(this.openInExplorerButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Genres:";
            // 
            // itemTrackNumberTextBox
            // 
            this.itemTrackNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTrackNumberTextBox.Enabled = false;
            this.itemTrackNumberTextBox.Location = new System.Drawing.Point(56, 350);
            this.itemTrackNumberTextBox.Name = "itemTrackNumberTextBox";
            this.itemTrackNumberTextBox.Size = new System.Drawing.Size(347, 20);
            this.itemTrackNumberTextBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nr:";
            // 
            // itemArtistTextBox
            // 
            this.itemArtistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemArtistTextBox.Enabled = false;
            this.itemArtistTextBox.Location = new System.Drawing.Point(56, 324);
            this.itemArtistTextBox.Name = "itemArtistTextBox";
            this.itemArtistTextBox.Size = new System.Drawing.Size(322, 20);
            this.itemArtistTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Artist:";
            // 
            // itemAlbumTextBox
            // 
            this.itemAlbumTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemAlbumTextBox.Enabled = false;
            this.itemAlbumTextBox.Location = new System.Drawing.Point(56, 298);
            this.itemAlbumTextBox.Name = "itemAlbumTextBox";
            this.itemAlbumTextBox.Size = new System.Drawing.Size(322, 20);
            this.itemAlbumTextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Album:";
            // 
            // itemTypeComboBox
            // 
            this.itemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemTypeComboBox.Enabled = false;
            this.itemTypeComboBox.FormattingEnabled = true;
            this.itemTypeComboBox.Location = new System.Drawing.Point(56, 45);
            this.itemTypeComboBox.Name = "itemTypeComboBox";
            this.itemTypeComboBox.Size = new System.Drawing.Size(347, 21);
            this.itemTypeComboBox.TabIndex = 11;
            // 
            // reloadAllButton
            // 
            this.reloadAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadAllButton.Location = new System.Drawing.Point(992, 208);
            this.reloadAllButton.Name = "reloadAllButton";
            this.reloadAllButton.Size = new System.Drawing.Size(75, 23);
            this.reloadAllButton.TabIndex = 18;
            this.reloadAllButton.Text = "Reload All";
            this.reloadAllButton.UseVisualStyleBackColor = true;
            this.reloadAllButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // reloadSelectedButton
            // 
            this.reloadSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadSelectedButton.Location = new System.Drawing.Point(892, 208);
            this.reloadSelectedButton.Name = "reloadSelectedButton";
            this.reloadSelectedButton.Size = new System.Drawing.Size(94, 23);
            this.reloadSelectedButton.TabIndex = 20;
            this.reloadSelectedButton.Text = "Reload Selected";
            this.reloadSelectedButton.UseVisualStyleBackColor = true;
            this.reloadSelectedButton.Click += new System.EventHandler(this.reloadSelectedButton_Click);
            // 
            // foldersListBox
            // 
            this.foldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.Location = new System.Drawing.Point(7, 19);
            this.foldersListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.Size = new System.Drawing.Size(166, 134);
            this.foldersListBox.TabIndex = 21;
            // 
            // changeFoldersButton
            // 
            this.changeFoldersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeFoldersButton.Location = new System.Drawing.Point(6, 160);
            this.changeFoldersButton.Name = "changeFoldersButton";
            this.changeFoldersButton.Size = new System.Drawing.Size(325, 23);
            this.changeFoldersButton.TabIndex = 25;
            this.changeFoldersButton.Text = "Edit";
            this.changeFoldersButton.UseVisualStyleBackColor = true;
            this.changeFoldersButton.Click += new System.EventHandler(this.changeFoldersButton_Click);
            // 
            // MusicFoldersGroupBox
            // 
            this.MusicFoldersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicFoldersGroupBox.Controls.Add(this.openInNotepadButton);
            this.MusicFoldersGroupBox.Controls.Add(this.playlistListBox);
            this.MusicFoldersGroupBox.Controls.Add(this.foldersListBox);
            this.MusicFoldersGroupBox.Controls.Add(this.changeFoldersButton);
            this.MusicFoldersGroupBox.Location = new System.Drawing.Point(655, 13);
            this.MusicFoldersGroupBox.Name = "MusicFoldersGroupBox";
            this.MusicFoldersGroupBox.Size = new System.Drawing.Size(412, 189);
            this.MusicFoldersGroupBox.TabIndex = 27;
            this.MusicFoldersGroupBox.TabStop = false;
            this.MusicFoldersGroupBox.Text = "Folders | Playlists";
            // 
            // playlistListBox
            // 
            this.playlistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.Location = new System.Drawing.Point(181, 19);
            this.playlistListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(224, 134);
            this.playlistListBox.TabIndex = 22;
            // 
            // debugButton
            // 
            this.debugButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.debugButton.Location = new System.Drawing.Point(661, 209);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(75, 23);
            this.debugButton.TabIndex = 28;
            this.debugButton.Text = "Debug";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // openInNotepadButton
            // 
            this.openInNotepadButton.Location = new System.Drawing.Point(337, 159);
            this.openInNotepadButton.Name = "openInNotepadButton";
            this.openInNotepadButton.Size = new System.Drawing.Size(68, 23);
            this.openInNotepadButton.TabIndex = 26;
            this.openInNotepadButton.Text = "Notepad++";
            this.openInNotepadButton.UseVisualStyleBackColor = true;
            this.openInNotepadButton.Click += new System.EventHandler(this.openInNotepadButton_Click);
            // 
            // EditMusicLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 680);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.MusicFoldersGroupBox);
            this.Controls.Add(this.reloadSelectedButton);
            this.Controls.Add(this.reloadAllButton);
            this.Controls.Add(this.selectedItemGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.libraryTreeView);
            this.Name = "EditMusicLibraryForm";
            this.Text = "Edit Music Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditMusicLibraryForm_FormClosing);
            this.Load += new System.EventHandler(this.EditMusicLibraryForm_Load);
            this.selectedItemGroupBox.ResumeLayout(false);
            this.selectedItemGroupBox.PerformLayout();
            this.MusicFoldersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView libraryTreeView;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemPathTextBox;
        private System.Windows.Forms.TextBox itemTitleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox selectedItemGroupBox;
        private System.Windows.Forms.ComboBox itemTypeComboBox;
        private System.Windows.Forms.TextBox itemArtistTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox itemAlbumTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemGenreTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox itemTrackNumberTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button reloadAllButton;
        private System.Windows.Forms.Button openPathInExplorerButton;
        private System.Windows.Forms.Button openPathInKid3Button;
        private System.Windows.Forms.Label artistLinkLabel;
        private System.Windows.Forms.Label albumLinkLabel;
        private System.Windows.Forms.Button reloadSelectedButton;
        private System.Windows.Forms.ListBox foldersListBox;
        private System.Windows.Forms.Button changeFoldersButton;
        private System.Windows.Forms.GroupBox MusicFoldersGroupBox;
        private System.Windows.Forms.ListBox selectedItemPlaylistsListBox;
        private System.Windows.Forms.ListBox playlistListBox;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.Button openInNotepadButton;
    }
}