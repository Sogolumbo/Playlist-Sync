namespace PlaylistConverterGUI
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
            this.iconLinkToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sync / \r\nMultiple\r\nConversion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Conversion\r\nPreview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit playlist \r\nand folder\r\n structure";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // editMusicLibraryButton
            // 
            this.editMusicLibraryButton.Location = new System.Drawing.Point(113, 78);
            this.editMusicLibraryButton.Name = "editMusicLibraryButton";
            this.editMusicLibraryButton.Size = new System.Drawing.Size(95, 60);
            this.editMusicLibraryButton.TabIndex = 3;
            this.editMusicLibraryButton.Text = "Edit Music Library";
            this.editMusicLibraryButton.UseVisualStyleBackColor = true;
            this.editMusicLibraryButton.Click += new System.EventHandler(this.editMusicLibraryButton_Click);
            // 
            // iconlabel
            // 
            this.iconlabel.AutoSize = true;
            this.iconlabel.Location = new System.Drawing.Point(12, 145);
            this.iconlabel.Name = "iconlabel";
            this.iconlabel.Size = new System.Drawing.Size(31, 13);
            this.iconlabel.TabIndex = 4;
            this.iconlabel.Text = "Icon:";
            // 
            // iconLinkLabel
            // 
            this.iconLinkLabel.AutoSize = true;
            this.iconLinkLabel.Location = new System.Drawing.Point(49, 145);
            this.iconLinkLabel.Name = "iconLinkLabel";
            this.iconLinkLabel.Size = new System.Drawing.Size(117, 13);
            this.iconLinkLabel.TabIndex = 5;
            this.iconLinkLabel.TabStop = true;
            this.iconLinkLabel.Text = "Smart Playlist by icons8";
            this.iconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconLinkLabel_LinkClicked);
            // 
            // iconLinkToolTip
            // 
            this.iconLinkToolTip.AutomaticDelay = 0;
            this.iconLinkToolTip.ToolTipTitle = "Link:";
            this.iconLinkToolTip.UseAnimation = false;
            this.iconLinkToolTip.UseFading = false;
            // 
            // PlaylistToolsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 165);
            this.Controls.Add(this.iconLinkLabel);
            this.Controls.Add(this.iconlabel);
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
        private System.Windows.Forms.ToolTip iconLinkToolTip;
    }
}