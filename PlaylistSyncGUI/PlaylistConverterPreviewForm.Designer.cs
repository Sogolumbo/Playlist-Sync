namespace PlaylistSyncGUI
{
    partial class PlaylistConverterPreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistConverterPreviewForm));
            this.openSourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTargetFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sourceFilePathTextBox = new System.Windows.Forms.TextBox();
            this.sourceFilePreviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sourceFileGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceFilePreviewButton = new System.Windows.Forms.Button();
            this.openSourceFileButton = new System.Windows.Forms.Button();
            this.sourceFilePreviewLabel = new System.Windows.Forms.Label();
            this.sourceFileMusicFolderLabel = new System.Windows.Forms.Label();
            this.sourceFilePathLabel = new System.Windows.Forms.Label();
            this.sourceFileMusicFolderTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.targetFileGroupBox = new System.Windows.Forms.GroupBox();
            this.saveConvertedPlaylistButton = new System.Windows.Forms.Button();
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.targetFilePreviewButton = new System.Windows.Forms.Button();
            this.targetFileSaveDialogButton = new System.Windows.Forms.Button();
            this.targetFilePreviewLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.targetFileMusicFolderTextBox = new System.Windows.Forms.TextBox();
            this.targetFilePathTextBox = new System.Windows.Forms.TextBox();
            this.targetFilePreviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveTargetFilebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sourceFileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.targetFileGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceFilePathTextBox
            // 
            this.sourceFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFilePathTextBox.Location = new System.Drawing.Point(59, 19);
            this.sourceFilePathTextBox.Name = "sourceFilePathTextBox";
            this.sourceFilePathTextBox.Size = new System.Drawing.Size(346, 20);
            this.sourceFilePathTextBox.TabIndex = 0;
            this.sourceFilePathTextBox.Text = "A:\\Informatik\\GitHub\\Playlist-Sync\\Example Data\\FavoritenDez17.m3u";
            this.sourceFilePathTextBox.TextChanged += new System.EventHandler(this.sourceFilePathTextBox_TextChanged);
            // 
            // sourceFilePreviewRichTextBox
            // 
            this.sourceFilePreviewRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFilePreviewRichTextBox.Location = new System.Drawing.Point(6, 116);
            this.sourceFilePreviewRichTextBox.Name = "sourceFilePreviewRichTextBox";
            this.sourceFilePreviewRichTextBox.Size = new System.Drawing.Size(480, 373);
            this.sourceFilePreviewRichTextBox.TabIndex = 2;
            this.sourceFilePreviewRichTextBox.Text = "";
            // 
            // sourceFileGroupBox
            // 
            this.sourceFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFileGroupBox.Controls.Add(this.sourceFileUsesSlashAsDirectorySeperatorCheckBox);
            this.sourceFileGroupBox.Controls.Add(this.sourceFilePreviewButton);
            this.sourceFileGroupBox.Controls.Add(this.openSourceFileButton);
            this.sourceFileGroupBox.Controls.Add(this.sourceFilePreviewLabel);
            this.sourceFileGroupBox.Controls.Add(this.sourceFileMusicFolderLabel);
            this.sourceFileGroupBox.Controls.Add(this.sourceFilePathLabel);
            this.sourceFileGroupBox.Controls.Add(this.sourceFileMusicFolderTextBox);
            this.sourceFileGroupBox.Controls.Add(this.sourceFilePathTextBox);
            this.sourceFileGroupBox.Controls.Add(this.sourceFilePreviewRichTextBox);
            this.sourceFileGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sourceFileGroupBox.Name = "sourceFileGroupBox";
            this.sourceFileGroupBox.Size = new System.Drawing.Size(492, 495);
            this.sourceFileGroupBox.TabIndex = 4;
            this.sourceFileGroupBox.TabStop = false;
            this.sourceFileGroupBox.Text = "Source File";
            // 
            // sourceFileUsesSlashAsDirectorySeperatorCheckBox
            // 
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.AutoSize = true;
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.Location = new System.Drawing.Point(9, 77);
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.Name = "sourceFileUsesSlashAsDirectorySeperatorCheckBox";
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.Size = new System.Drawing.Size(153, 17);
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.TabIndex = 9;
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.Text = "\'/\' is the directory seperator";
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.UseVisualStyleBackColor = true;
            this.sourceFileUsesSlashAsDirectorySeperatorCheckBox.CheckedChanged += new System.EventHandler(this.sorceFileUsesSlashAsDirectorySeperatorCheckBox_CheckedChanged);
            // 
            // sourceFilePreviewButton
            // 
            this.sourceFilePreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFilePreviewButton.Location = new System.Drawing.Point(411, 45);
            this.sourceFilePreviewButton.Name = "sourceFilePreviewButton";
            this.sourceFilePreviewButton.Size = new System.Drawing.Size(75, 22);
            this.sourceFilePreviewButton.TabIndex = 8;
            this.sourceFilePreviewButton.Text = "Preview";
            this.sourceFilePreviewButton.UseVisualStyleBackColor = true;
            this.sourceFilePreviewButton.Click += new System.EventHandler(this.sourceFilePreviewButton_Click);
            // 
            // openSourceFileButton
            // 
            this.openSourceFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSourceFileButton.Location = new System.Drawing.Point(411, 18);
            this.openSourceFileButton.Name = "openSourceFileButton";
            this.openSourceFileButton.Size = new System.Drawing.Size(75, 22);
            this.openSourceFileButton.TabIndex = 7;
            this.openSourceFileButton.Text = "Choose...";
            this.openSourceFileButton.UseVisualStyleBackColor = true;
            this.openSourceFileButton.Click += new System.EventHandler(this.openSourceFileButton_Click);
            // 
            // sourceFilePreviewLabel
            // 
            this.sourceFilePreviewLabel.AutoSize = true;
            this.sourceFilePreviewLabel.Location = new System.Drawing.Point(6, 100);
            this.sourceFilePreviewLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.sourceFilePreviewLabel.Name = "sourceFilePreviewLabel";
            this.sourceFilePreviewLabel.Size = new System.Drawing.Size(45, 13);
            this.sourceFilePreviewLabel.TabIndex = 6;
            this.sourceFilePreviewLabel.Text = "Preview";
            // 
            // sourceFileMusicFolderLabel
            // 
            this.sourceFileMusicFolderLabel.AutoSize = true;
            this.sourceFileMusicFolderLabel.Location = new System.Drawing.Point(6, 49);
            this.sourceFileMusicFolderLabel.Name = "sourceFileMusicFolderLabel";
            this.sourceFileMusicFolderLabel.Size = new System.Drawing.Size(88, 13);
            this.sourceFileMusicFolderLabel.TabIndex = 5;
            this.sourceFileMusicFolderLabel.Text = "Music folder path";
            // 
            // sourceFilePathLabel
            // 
            this.sourceFilePathLabel.AutoSize = true;
            this.sourceFilePathLabel.Location = new System.Drawing.Point(6, 22);
            this.sourceFilePathLabel.Name = "sourceFilePathLabel";
            this.sourceFilePathLabel.Size = new System.Drawing.Size(47, 13);
            this.sourceFilePathLabel.TabIndex = 4;
            this.sourceFilePathLabel.Text = "File path";
            // 
            // sourceFileMusicFolderTextBox
            // 
            this.sourceFileMusicFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFileMusicFolderTextBox.Location = new System.Drawing.Point(100, 46);
            this.sourceFileMusicFolderTextBox.Name = "sourceFileMusicFolderTextBox";
            this.sourceFileMusicFolderTextBox.Size = new System.Drawing.Size(305, 20);
            this.sourceFileMusicFolderTextBox.TabIndex = 3;
            this.sourceFileMusicFolderTextBox.TextChanged += new System.EventHandler(this.sourceFileMusicFolderTextBox_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceFileGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(998, 501);
            this.splitContainer1.SplitterDistance = 498;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.targetFileGroupBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.saveTargetFilebutton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 495);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source File";
            // 
            // targetFileGroupBox
            // 
            this.targetFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFileGroupBox.Controls.Add(this.saveConvertedPlaylistButton);
            this.targetFileGroupBox.Controls.Add(this.targetFileUsesSlashAsDirectorySeperatorCheckBox);
            this.targetFileGroupBox.Controls.Add(this.targetFilePreviewButton);
            this.targetFileGroupBox.Controls.Add(this.targetFileSaveDialogButton);
            this.targetFileGroupBox.Controls.Add(this.targetFilePreviewLabel);
            this.targetFileGroupBox.Controls.Add(this.label5);
            this.targetFileGroupBox.Controls.Add(this.label6);
            this.targetFileGroupBox.Controls.Add(this.targetFileMusicFolderTextBox);
            this.targetFileGroupBox.Controls.Add(this.targetFilePathTextBox);
            this.targetFileGroupBox.Controls.Add(this.targetFilePreviewRichTextBox);
            this.targetFileGroupBox.Location = new System.Drawing.Point(-1, 0);
            this.targetFileGroupBox.Name = "targetFileGroupBox";
            this.targetFileGroupBox.Size = new System.Drawing.Size(493, 495);
            this.targetFileGroupBox.TabIndex = 9;
            this.targetFileGroupBox.TabStop = false;
            this.targetFileGroupBox.Text = "Target File";
            // 
            // saveConvertedPlaylistButton
            // 
            this.saveConvertedPlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveConvertedPlaylistButton.Enabled = false;
            this.saveConvertedPlaylistButton.Location = new System.Drawing.Point(343, 73);
            this.saveConvertedPlaylistButton.Name = "saveConvertedPlaylistButton";
            this.saveConvertedPlaylistButton.Size = new System.Drawing.Size(144, 22);
            this.saveConvertedPlaylistButton.TabIndex = 10;
            this.saveConvertedPlaylistButton.Text = "Save converted file";
            this.saveConvertedPlaylistButton.UseVisualStyleBackColor = true;
            this.saveConvertedPlaylistButton.Click += new System.EventHandler(this.saveConvertedPlaylistButton_Click);
            // 
            // targetFileUsesSlashAsDirectorySeperatorCheckBox
            // 
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.AutoSize = true;
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.Location = new System.Drawing.Point(9, 77);
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.Name = "targetFileUsesSlashAsDirectorySeperatorCheckBox";
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.Size = new System.Drawing.Size(153, 17);
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.TabIndex = 9;
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.Text = "\'/\' is the directory seperator";
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.UseVisualStyleBackColor = true;
            this.targetFileUsesSlashAsDirectorySeperatorCheckBox.CheckedChanged += new System.EventHandler(this.targetFileUsesSlashAsDirectorySeperatorCheckBox_CheckedChanged);
            // 
            // targetFilePreviewButton
            // 
            this.targetFilePreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFilePreviewButton.Location = new System.Drawing.Point(412, 45);
            this.targetFilePreviewButton.Name = "targetFilePreviewButton";
            this.targetFilePreviewButton.Size = new System.Drawing.Size(75, 22);
            this.targetFilePreviewButton.TabIndex = 8;
            this.targetFilePreviewButton.Text = "Preview";
            this.targetFilePreviewButton.UseVisualStyleBackColor = true;
            this.targetFilePreviewButton.Click += new System.EventHandler(this.targetFilePreviewButton_Click);
            // 
            // targetFileSaveDialogButton
            // 
            this.targetFileSaveDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFileSaveDialogButton.Location = new System.Drawing.Point(412, 18);
            this.targetFileSaveDialogButton.Name = "targetFileSaveDialogButton";
            this.targetFileSaveDialogButton.Size = new System.Drawing.Size(75, 22);
            this.targetFileSaveDialogButton.TabIndex = 7;
            this.targetFileSaveDialogButton.Text = "Choose...";
            this.targetFileSaveDialogButton.UseVisualStyleBackColor = true;
            this.targetFileSaveDialogButton.Click += new System.EventHandler(this.targetFileSaveDialogButton_Click);
            // 
            // targetFilePreviewLabel
            // 
            this.targetFilePreviewLabel.AutoSize = true;
            this.targetFilePreviewLabel.Location = new System.Drawing.Point(7, 100);
            this.targetFilePreviewLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.targetFilePreviewLabel.Name = "targetFilePreviewLabel";
            this.targetFilePreviewLabel.Size = new System.Drawing.Size(45, 13);
            this.targetFilePreviewLabel.TabIndex = 6;
            this.targetFilePreviewLabel.Text = "Preview";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Music folder path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "File path";
            // 
            // targetFileMusicFolderTextBox
            // 
            this.targetFileMusicFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFileMusicFolderTextBox.Location = new System.Drawing.Point(100, 46);
            this.targetFileMusicFolderTextBox.Name = "targetFileMusicFolderTextBox";
            this.targetFileMusicFolderTextBox.Size = new System.Drawing.Size(306, 20);
            this.targetFileMusicFolderTextBox.TabIndex = 3;
            this.targetFileMusicFolderTextBox.TextChanged += new System.EventHandler(this.targetFileMusicFolderTextBox_TextChanged);
            // 
            // targetFilePathTextBox
            // 
            this.targetFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFilePathTextBox.Location = new System.Drawing.Point(59, 19);
            this.targetFilePathTextBox.Name = "targetFilePathTextBox";
            this.targetFilePathTextBox.Size = new System.Drawing.Size(347, 20);
            this.targetFilePathTextBox.TabIndex = 0;
            this.targetFilePathTextBox.Text = "A:\\Informatik\\GitHub\\Playlist-Sync\\Example Data\\ExampleResult.m3u";
            this.targetFilePathTextBox.TextChanged += new System.EventHandler(this.targetFilePathTextBox_TextChanged);
            // 
            // targetFilePreviewRichTextBox
            // 
            this.targetFilePreviewRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFilePreviewRichTextBox.Location = new System.Drawing.Point(6, 116);
            this.targetFilePreviewRichTextBox.Name = "targetFilePreviewRichTextBox";
            this.targetFilePreviewRichTextBox.Size = new System.Drawing.Size(481, 373);
            this.targetFilePreviewRichTextBox.TabIndex = 2;
            this.targetFilePreviewRichTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(409, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // saveTargetFilebutton
            // 
            this.saveTargetFilebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTargetFilebutton.Location = new System.Drawing.Point(409, 18);
            this.saveTargetFilebutton.Name = "saveTargetFilebutton";
            this.saveTargetFilebutton.Size = new System.Drawing.Size(75, 22);
            this.saveTargetFilebutton.TabIndex = 7;
            this.saveTargetFilebutton.Text = "Open...";
            this.saveTargetFilebutton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Preview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Music folder path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "File path";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(100, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(59, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(344, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "A:\\Informatik\\GitHub\\Playlist-Sync\\Example Data\\FavoritenDez17.m3u";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(478, 397);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // PlaylistConverterPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 525);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlaylistConverterPreviewForm";
            this.ShowIcon = false;
            this.Text = "Playlist Converter Preview";
            this.sourceFileGroupBox.ResumeLayout(false);
            this.sourceFileGroupBox.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.targetFileGroupBox.ResumeLayout(false);
            this.targetFileGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openSourceFileDialog;
        private System.Windows.Forms.SaveFileDialog saveTargetFileDialog;
        private System.Windows.Forms.TextBox sourceFilePathTextBox;
        private System.Windows.Forms.RichTextBox sourceFilePreviewRichTextBox;
        private System.Windows.Forms.GroupBox sourceFileGroupBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button sourceFilePreviewButton;
        private System.Windows.Forms.Button openSourceFileButton;
        private System.Windows.Forms.Label sourceFilePreviewLabel;
        private System.Windows.Forms.Label sourceFileMusicFolderLabel;
        private System.Windows.Forms.Label sourceFilePathLabel;
        private System.Windows.Forms.TextBox sourceFileMusicFolderTextBox;
        private System.Windows.Forms.CheckBox sourceFileUsesSlashAsDirectorySeperatorCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveTargetFilebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox targetFileGroupBox;
        private System.Windows.Forms.CheckBox targetFileUsesSlashAsDirectorySeperatorCheckBox;
        private System.Windows.Forms.Button targetFilePreviewButton;
        private System.Windows.Forms.Button targetFileSaveDialogButton;
        private System.Windows.Forms.Label targetFilePreviewLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox targetFileMusicFolderTextBox;
        private System.Windows.Forms.TextBox targetFilePathTextBox;
        private System.Windows.Forms.RichTextBox targetFilePreviewRichTextBox;
        private System.Windows.Forms.Button saveConvertedPlaylistButton;
    }
}

