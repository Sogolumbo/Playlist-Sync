namespace PlaylistSyncGUI
{
    partial class ConversionElement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversionElement));
            this.convertPlaylistsButton = new System.Windows.Forms.Button();
            this.sourcePathLabel = new System.Windows.Forms.Label();
            this.sourceTypeLabel = new System.Windows.Forms.Label();
            this.targetPathLabel = new System.Windows.Forms.Label();
            this.PlaylistNamesLabel = new System.Windows.Forms.Label();
            this.targetTypeLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // convertPlaylistsButton
            // 
            this.convertPlaylistsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertPlaylistsButton.Location = new System.Drawing.Point(448, 5);
            this.convertPlaylistsButton.Margin = new System.Windows.Forms.Padding(3, 5, 5, 2);
            this.convertPlaylistsButton.Name = "convertPlaylistsButton";
            this.convertPlaylistsButton.Size = new System.Drawing.Size(110, 67);
            this.convertPlaylistsButton.TabIndex = 0;
            this.convertPlaylistsButton.Text = "Convert Playlists";
            this.convertPlaylistsButton.UseVisualStyleBackColor = true;
            this.convertPlaylistsButton.Click += new System.EventHandler(this.convertPlaylistsButton_Click);
            // 
            // sourcePathLabel
            // 
            this.sourcePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePathLabel.Location = new System.Drawing.Point(106, 25);
            this.sourcePathLabel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.sourcePathLabel.Name = "sourcePathLabel";
            this.sourcePathLabel.Size = new System.Drawing.Size(336, 13);
            this.sourcePathLabel.TabIndex = 1;
            this.sourcePathLabel.Text = "sourcePathLabel";
            // 
            // sourceTypeLabel
            // 
            this.sourceTypeLabel.Location = new System.Drawing.Point(3, 25);
            this.sourceTypeLabel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.sourceTypeLabel.Name = "sourceTypeLabel";
            this.sourceTypeLabel.Size = new System.Drawing.Size(97, 13);
            this.sourceTypeLabel.TabIndex = 2;
            this.sourceTypeLabel.Text = "sourceType";
            // 
            // targetPathLabel
            // 
            this.targetPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPathLabel.Location = new System.Drawing.Point(106, 40);
            this.targetPathLabel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.targetPathLabel.Name = "targetPathLabel";
            this.targetPathLabel.Size = new System.Drawing.Size(336, 13);
            this.targetPathLabel.TabIndex = 3;
            this.targetPathLabel.Text = "targetPathLabel";
            // 
            // PlaylistNamesLabel
            // 
            this.PlaylistNamesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistNamesLabel.AutoEllipsis = true;
            this.PlaylistNamesLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PlaylistNamesLabel.Location = new System.Drawing.Point(3, 59);
            this.PlaylistNamesLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PlaylistNamesLabel.Name = "PlaylistNamesLabel";
            this.PlaylistNamesLabel.Size = new System.Drawing.Size(439, 41);
            this.PlaylistNamesLabel.TabIndex = 4;
            this.PlaylistNamesLabel.Text = resources.GetString("PlaylistNamesLabel.Text");
            // 
            // targetTypeLabel
            // 
            this.targetTypeLabel.Location = new System.Drawing.Point(3, 40);
            this.targetTypeLabel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.targetTypeLabel.Name = "targetTypeLabel";
            this.targetTypeLabel.Size = new System.Drawing.Size(97, 13);
            this.targetTypeLabel.TabIndex = 5;
            this.targetTypeLabel.Text = "targetType";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.removeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Location = new System.Drawing.Point(498, 77);
            this.removeButton.Margin = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(210)))), ((int)(((byte)(110)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(448, 77);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(44, 23);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.06F);
            this.titleLabel.Location = new System.Drawing.Point(4, 4);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(438, 17);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Title";
            // 
            // ConversionElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.targetTypeLabel);
            this.Controls.Add(this.PlaylistNamesLabel);
            this.Controls.Add(this.targetPathLabel);
            this.Controls.Add(this.sourceTypeLabel);
            this.Controls.Add(this.sourcePathLabel);
            this.Controls.Add(this.convertPlaylistsButton);
            this.Name = "ConversionElement";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.Size = new System.Drawing.Size(564, 106);
            this.Load += new System.EventHandler(this.ConversionElement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button convertPlaylistsButton;
        private System.Windows.Forms.Label sourcePathLabel;
        private System.Windows.Forms.Label sourceTypeLabel;
        private System.Windows.Forms.Label targetPathLabel;
        private System.Windows.Forms.Label PlaylistNamesLabel;
        private System.Windows.Forms.Label targetTypeLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label titleLabel;
    }
}
