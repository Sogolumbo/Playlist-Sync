namespace PlaylistSyncGUI
{
    partial class PlaylistToolsMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistToolsMenuForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.editMusicLibraryButton = new System.Windows.Forms.Button();
            this.iconlabel = new System.Windows.Forms.Label();
            this.iconLinkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cleanM3uFilesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openSettingsFolderButton = new System.Windows.Forms.Button();
            this.projectLabel = new System.Windows.Forms.Label();
            this.sourceCodeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.issuesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.releasesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sync / \r\nMultiple\r\nConversion...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 60);
            this.button2.TabIndex = 11;
            this.button2.Text = "Conversion\r\nPreview...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 60);
            this.button3.TabIndex = 10;
            this.button3.Text = "Edit playlist \r\nand folder\r\n structure...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // editMusicLibraryButton
            // 
            this.editMusicLibraryButton.Location = new System.Drawing.Point(113, 12);
            this.editMusicLibraryButton.Name = "editMusicLibraryButton";
            this.editMusicLibraryButton.Size = new System.Drawing.Size(95, 60);
            this.editMusicLibraryButton.TabIndex = 1;
            this.editMusicLibraryButton.Text = "Edit Music Library...";
            this.editMusicLibraryButton.UseVisualStyleBackColor = true;
            this.editMusicLibraryButton.Click += new System.EventHandler(this.editMusicLibraryButton_Click);
            // 
            // iconlabel
            // 
            this.iconlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iconlabel.AutoSize = true;
            this.iconlabel.Location = new System.Drawing.Point(9, 256);
            this.iconlabel.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.iconlabel.Name = "iconlabel";
            this.iconlabel.Size = new System.Drawing.Size(31, 13);
            this.iconlabel.TabIndex = 4;
            this.iconlabel.Text = "Icon:";
            // 
            // iconLinkLabel
            // 
            this.iconLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iconLinkLabel.AutoSize = true;
            this.iconLinkLabel.Location = new System.Drawing.Point(46, 256);
            this.iconLinkLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.iconLinkLabel.Name = "iconLinkLabel";
            this.iconLinkLabel.Size = new System.Drawing.Size(140, 13);
            this.iconLinkLabel.TabIndex = 20;
            this.iconLinkLabel.TabStop = true;
            this.iconLinkLabel.Text = "Smart Playlist by icons8.com";
            this.iconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabelToolTip
            // 
            this.linkLabelToolTip.AutomaticDelay = 0;
            this.linkLabelToolTip.ToolTipTitle = "Links:";
            this.linkLabelToolTip.UseAnimation = false;
            this.linkLabelToolTip.UseFading = false;
            // 
            // cleanM3uFilesButton
            // 
            this.cleanM3uFilesButton.Location = new System.Drawing.Point(12, 78);
            this.cleanM3uFilesButton.Name = "cleanM3uFilesButton";
            this.cleanM3uFilesButton.Size = new System.Drawing.Size(95, 60);
            this.cleanM3uFilesButton.TabIndex = 2;
            this.cleanM3uFilesButton.Text = "Clean M3u files...";
            this.cleanM3uFilesButton.UseVisualStyleBackColor = true;
            this.cleanM3uFilesButton.Click += new System.EventHandler(this.cleanM3uFilesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Legacy:";
            // 
            // openSettingsFolderButton
            // 
            this.openSettingsFolderButton.Location = new System.Drawing.Point(113, 78);
            this.openSettingsFolderButton.Name = "openSettingsFolderButton";
            this.openSettingsFolderButton.Size = new System.Drawing.Size(95, 60);
            this.openSettingsFolderButton.TabIndex = 3;
            this.openSettingsFolderButton.Text = "Open Settings Folder";
            this.openSettingsFolderButton.UseVisualStyleBackColor = true;
            this.openSettingsFolderButton.Click += new System.EventHandler(this.openSettingsFolderButton_Click);
            // 
            // projectLabel
            // 
            this.projectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.projectLabel.AutoSize = true;
            this.projectLabel.Location = new System.Drawing.Point(9, 238);
            this.projectLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(43, 13);
            this.projectLabel.TabIndex = 21;
            this.projectLabel.Text = "Project:";
            // 
            // sourceCodeLinkLabel
            // 
            this.sourceCodeLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sourceCodeLinkLabel.AutoSize = true;
            this.sourceCodeLinkLabel.Location = new System.Drawing.Point(139, 238);
            this.sourceCodeLinkLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.sourceCodeLinkLabel.Name = "sourceCodeLinkLabel";
            this.sourceCodeLinkLabel.Size = new System.Drawing.Size(69, 13);
            this.sourceCodeLinkLabel.TabIndex = 22;
            this.sourceCodeLinkLabel.TabStop = true;
            this.sourceCodeLinkLabel.Text = "Source Code";
            this.sourceCodeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // issuesLinkLabel
            // 
            this.issuesLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.issuesLinkLabel.AutoSize = true;
            this.issuesLinkLabel.Location = new System.Drawing.Point(103, 238);
            this.issuesLinkLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.issuesLinkLabel.Name = "issuesLinkLabel";
            this.issuesLinkLabel.Size = new System.Drawing.Size(37, 13);
            this.issuesLinkLabel.TabIndex = 23;
            this.issuesLinkLabel.TabStop = true;
            this.issuesLinkLabel.Text = "Issues";
            this.issuesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // releasesLinkLabel
            // 
            this.releasesLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.releasesLinkLabel.AutoSize = true;
            this.releasesLinkLabel.Location = new System.Drawing.Point(52, 238);
            this.releasesLinkLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.releasesLinkLabel.Name = "releasesLinkLabel";
            this.releasesLinkLabel.Size = new System.Drawing.Size(51, 13);
            this.releasesLinkLabel.TabIndex = 24;
            this.releasesLinkLabel.TabStop = true;
            this.releasesLinkLabel.Text = "Releases";
            this.releasesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // PlaylistToolsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 278);
            this.Controls.Add(this.releasesLinkLabel);
            this.Controls.Add(this.issuesLinkLabel);
            this.Controls.Add(this.sourceCodeLinkLabel);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.openSettingsFolderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconLinkLabel);
            this.Controls.Add(this.iconlabel);
            this.Controls.Add(this.cleanM3uFilesButton);
            this.Controls.Add(this.editMusicLibraryButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlaylistToolsMenuForm";
            this.Text = "Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button editMusicLibraryButton;
        private System.Windows.Forms.Label iconlabel;
        private System.Windows.Forms.LinkLabel iconLinkLabel;
        private System.Windows.Forms.ToolTip linkLabelToolTip;
        private System.Windows.Forms.Button cleanM3uFilesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openSettingsFolderButton;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.LinkLabel sourceCodeLinkLabel;
        private System.Windows.Forms.LinkLabel issuesLinkLabel;
        private System.Windows.Forms.LinkLabel releasesLinkLabel;
    }
}
