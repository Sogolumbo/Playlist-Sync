namespace PlaylistConverterGUI
{
    partial class EditPlaylistForm
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
            this.playlistTreeView = new System.Windows.Forms.TreeView();
            this.playlistNameTextBox = new System.Windows.Forms.TextBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemPathTextBox = new System.Windows.Forms.TextBox();
            this.itemTitleTextBox = new System.Windows.Forms.TextBox();
            this.playlistNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.choosePlaylistButton = new System.Windows.Forms.Button();
            this.playlistPathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.itemYearTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.itemGenreTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.itemTrackNumberTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.itemArtistTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.itemAlbumTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.changeFilesAndFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playlistTreeView
            // 
            this.playlistTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistTreeView.Location = new System.Drawing.Point(13, 13);
            this.playlistTreeView.Name = "playlistTreeView";
            this.playlistTreeView.Size = new System.Drawing.Size(636, 476);
            this.playlistTreeView.TabIndex = 0;
            this.playlistTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.playlistTreeView_AfterSelect);
            // 
            // playlistNameTextBox
            // 
            this.playlistNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistNameTextBox.Location = new System.Drawing.Point(731, 42);
            this.playlistNameTextBox.Name = "playlistNameTextBox";
            this.playlistNameTextBox.Size = new System.Drawing.Size(336, 20);
            this.playlistNameTextBox.TabIndex = 1;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemNameTextBox.Location = new System.Drawing.Point(46, 19);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemNameTextBox.TabIndex = 2;
            // 
            // itemPathTextBox
            // 
            this.itemPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemPathTextBox.Location = new System.Drawing.Point(46, 72);
            this.itemPathTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.itemPathTextBox.Name = "itemPathTextBox";
            this.itemPathTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemPathTextBox.TabIndex = 3;
            // 
            // itemTitleTextBox
            // 
            this.itemTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTitleTextBox.Location = new System.Drawing.Point(46, 105);
            this.itemTitleTextBox.Name = "itemTitleTextBox";
            this.itemTitleTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemTitleTextBox.TabIndex = 5;
            // 
            // playlistNameLabel
            // 
            this.playlistNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistNameLabel.AutoSize = true;
            this.playlistNameLabel.Location = new System.Drawing.Point(655, 45);
            this.playlistNameLabel.Name = "playlistNameLabel";
            this.playlistNameLabel.Size = new System.Drawing.Size(73, 13);
            this.playlistNameLabel.TabIndex = 6;
            this.playlistNameLabel.Text = "Playlist Name:";
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
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Title:";
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(992, 362);
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
            this.cancelButton.Location = new System.Drawing.Point(911, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "playlist";
            // 
            // choosePlaylistButton
            // 
            this.choosePlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.choosePlaylistButton.Location = new System.Drawing.Point(977, 13);
            this.choosePlaylistButton.Name = "choosePlaylistButton";
            this.choosePlaylistButton.Size = new System.Drawing.Size(90, 23);
            this.choosePlaylistButton.TabIndex = 13;
            this.choosePlaylistButton.Text = "Choose Playlist";
            this.choosePlaylistButton.UseVisualStyleBackColor = true;
            this.choosePlaylistButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // playlistPathLabel
            // 
            this.playlistPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistPathLabel.AutoSize = true;
            this.playlistPathLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.playlistPathLabel.Location = new System.Drawing.Point(655, 65);
            this.playlistPathLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.playlistPathLabel.Name = "playlistPathLabel";
            this.playlistPathLabel.Size = new System.Drawing.Size(41, 13);
            this.playlistPathLabel.TabIndex = 15;
            this.playlistPathLabel.Text = "filepath";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.itemYearTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.itemGenreTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.itemTrackNumberTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.itemArtistTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.itemAlbumTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.itemTypeComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.itemNameTextBox);
            this.groupBox1.Controls.Add(this.itemPathTextBox);
            this.groupBox1.Controls.Add(this.itemTitleTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(658, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 264);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Item";
            // 
            // itemYearTextBox
            // 
            this.itemYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemYearTextBox.Enabled = false;
            this.itemYearTextBox.Location = new System.Drawing.Point(46, 235);
            this.itemYearTextBox.Name = "itemYearTextBox";
            this.itemYearTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemYearTextBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(6, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Year:";
            // 
            // itemGenreTextBox
            // 
            this.itemGenreTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGenreTextBox.Enabled = false;
            this.itemGenreTextBox.Location = new System.Drawing.Point(46, 209);
            this.itemGenreTextBox.Name = "itemGenreTextBox";
            this.itemGenreTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemGenreTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(6, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Genre:";
            // 
            // itemTrackNumberTextBox
            // 
            this.itemTrackNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTrackNumberTextBox.Enabled = false;
            this.itemTrackNumberTextBox.Location = new System.Drawing.Point(46, 183);
            this.itemTrackNumberTextBox.Name = "itemTrackNumberTextBox";
            this.itemTrackNumberTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemTrackNumberTextBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(6, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nr:";
            // 
            // itemArtistTextBox
            // 
            this.itemArtistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemArtistTextBox.Location = new System.Drawing.Point(46, 157);
            this.itemArtistTextBox.Name = "itemArtistTextBox";
            this.itemArtistTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemArtistTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Artist:";
            // 
            // itemAlbumTextBox
            // 
            this.itemAlbumTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemAlbumTextBox.Location = new System.Drawing.Point(46, 131);
            this.itemAlbumTextBox.Name = "itemAlbumTextBox";
            this.itemAlbumTextBox.Size = new System.Drawing.Size(357, 20);
            this.itemAlbumTextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 134);
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
            this.itemTypeComboBox.Location = new System.Drawing.Point(46, 45);
            this.itemTypeComboBox.Name = "itemTypeComboBox";
            this.itemTypeComboBox.Size = new System.Drawing.Size(357, 21);
            this.itemTypeComboBox.TabIndex = 11;
            // 
            // changeFilesAndFoldersCheckBox
            // 
            this.changeFilesAndFoldersCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeFilesAndFoldersCheckBox.AutoSize = true;
            this.changeFilesAndFoldersCheckBox.Checked = true;
            this.changeFilesAndFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeFilesAndFoldersCheckBox.Location = new System.Drawing.Point(667, 366);
            this.changeFilesAndFoldersCheckBox.Name = "changeFilesAndFoldersCheckBox";
            this.changeFilesAndFoldersCheckBox.Size = new System.Drawing.Size(190, 17);
            this.changeFilesAndFoldersCheckBox.TabIndex = 17;
            this.changeFilesAndFoldersCheckBox.Text = "Edit corresponding files and folders";
            this.changeFilesAndFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // EditPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 501);
            this.Controls.Add(this.changeFilesAndFoldersCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.playlistPathLabel);
            this.Controls.Add(this.choosePlaylistButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.playlistNameLabel);
            this.Controls.Add(this.playlistNameTextBox);
            this.Controls.Add(this.playlistTreeView);
            this.Name = "EditPlaylistForm";
            this.Text = "Edit Playlist";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView playlistTreeView;
        private System.Windows.Forms.TextBox playlistNameTextBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemPathTextBox;
        private System.Windows.Forms.TextBox itemTitleTextBox;
        private System.Windows.Forms.Label playlistNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button choosePlaylistButton;
        private System.Windows.Forms.Label playlistPathLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox itemTypeComboBox;
        private System.Windows.Forms.TextBox itemArtistTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox itemAlbumTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemYearTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox itemGenreTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox itemTrackNumberTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox changeFilesAndFoldersCheckBox;
    }
}