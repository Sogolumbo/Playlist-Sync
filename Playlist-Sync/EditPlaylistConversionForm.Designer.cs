﻿namespace PlaylistConverterGUI
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
            this.sourceUseSlashAsSeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.targetUseSlashAsSeperatorCheckBox = new System.Windows.Forms.CheckBox();
            this.folderLinksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(125, 12);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(483, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(533, 453);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
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
            this.cancelButton.Location = new System.Drawing.Point(452, 453);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
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
            this.sourcePlaylistFolderTextBox.Size = new System.Drawing.Size(483, 20);
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
            this.targetPlaylistFolderLabel.Location = new System.Drawing.Point(12, 136);
            this.targetPlaylistFolderLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.targetPlaylistFolderLabel.Name = "targetPlaylistFolderLabel";
            this.targetPlaylistFolderLabel.Size = new System.Drawing.Size(108, 13);
            this.targetPlaylistFolderLabel.TabIndex = 9;
            this.targetPlaylistFolderLabel.Text = "Target Playlist Folder:";
            // 
            // targetPlaylistFolderTextBox
            // 
            this.targetPlaylistFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPlaylistFolderTextBox.Location = new System.Drawing.Point(125, 133);
            this.targetPlaylistFolderTextBox.Name = "targetPlaylistFolderTextBox";
            this.targetPlaylistFolderTextBox.Size = new System.Drawing.Size(483, 20);
            this.targetPlaylistFolderTextBox.TabIndex = 8;
            // 
            // targetPlaylistTypeLabel
            // 
            this.targetPlaylistTypeLabel.AutoSize = true;
            this.targetPlaylistTypeLabel.Location = new System.Drawing.Point(12, 162);
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
            this.sourcePlaylistTypeComboBox.Size = new System.Drawing.Size(483, 21);
            this.sourcePlaylistTypeComboBox.TabIndex = 12;
            // 
            // targetPlaylistTypeComboBox
            // 
            this.targetPlaylistTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPlaylistTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetPlaylistTypeComboBox.FormattingEnabled = true;
            this.targetPlaylistTypeComboBox.Location = new System.Drawing.Point(125, 159);
            this.targetPlaylistTypeComboBox.Name = "targetPlaylistTypeComboBox";
            this.targetPlaylistTypeComboBox.Size = new System.Drawing.Size(483, 21);
            this.targetPlaylistTypeComboBox.TabIndex = 13;
            // 
            // sourceUseSlashAsSeperatorCheckBox
            // 
            this.sourceUseSlashAsSeperatorCheckBox.AutoSize = true;
            this.sourceUseSlashAsSeperatorCheckBox.Location = new System.Drawing.Point(12, 103);
            this.sourceUseSlashAsSeperatorCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.sourceUseSlashAsSeperatorCheckBox.Name = "sourceUseSlashAsSeperatorCheckBox";
            this.sourceUseSlashAsSeperatorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sourceUseSlashAsSeperatorCheckBox.Size = new System.Drawing.Size(184, 17);
            this.sourceUseSlashAsSeperatorCheckBox.TabIndex = 16;
            this.sourceUseSlashAsSeperatorCheckBox.Text = "Source uses slashes as seperator";
            this.sourceUseSlashAsSeperatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // targetUseSlashAsSeperatorCheckBox
            // 
            this.targetUseSlashAsSeperatorCheckBox.AutoSize = true;
            this.targetUseSlashAsSeperatorCheckBox.Location = new System.Drawing.Point(12, 186);
            this.targetUseSlashAsSeperatorCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.targetUseSlashAsSeperatorCheckBox.Name = "targetUseSlashAsSeperatorCheckBox";
            this.targetUseSlashAsSeperatorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.targetUseSlashAsSeperatorCheckBox.Size = new System.Drawing.Size(181, 17);
            this.targetUseSlashAsSeperatorCheckBox.TabIndex = 21;
            this.targetUseSlashAsSeperatorCheckBox.Text = "Target uses slashes as seperator";
            this.targetUseSlashAsSeperatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // conversionsFlowLayoutPanel
            // 
            this.folderLinksFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderLinksFlowLayoutPanel.AutoScroll = true;
            this.folderLinksFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.folderLinksFlowLayoutPanel.Location = new System.Drawing.Point(15, 235);
            this.folderLinksFlowLayoutPanel.Name = "conversionsFlowLayoutPanel";
            this.folderLinksFlowLayoutPanel.Size = new System.Drawing.Size(593, 142);
            this.folderLinksFlowLayoutPanel.TabIndex = 22;
            this.folderLinksFlowLayoutPanel.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Music Folder Links:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(15, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Add Folder Link";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditPlaylistConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderLinksFlowLayoutPanel);
            this.Controls.Add(this.targetUseSlashAsSeperatorCheckBox);
            this.Controls.Add(this.sourceUseSlashAsSeperatorCheckBox);
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
        private System.Windows.Forms.CheckBox sourceUseSlashAsSeperatorCheckBox;
        private System.Windows.Forms.CheckBox targetUseSlashAsSeperatorCheckBox;
        private System.Windows.Forms.FlowLayoutPanel folderLinksFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}