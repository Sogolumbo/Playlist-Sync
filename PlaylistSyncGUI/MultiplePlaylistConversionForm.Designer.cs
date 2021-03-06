﻿namespace PlaylistSyncGUI
{
    partial class MultiplePlaylistConversionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplePlaylistConversionForm));
            this.conversionsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addConversionButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // conversionsFlowLayoutPanel
            // 
            this.conversionsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conversionsFlowLayoutPanel.AutoScroll = true;
            this.conversionsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.conversionsFlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.conversionsFlowLayoutPanel.Name = "conversionsFlowLayoutPanel";
            this.conversionsFlowLayoutPanel.Size = new System.Drawing.Size(796, 694);
            this.conversionsFlowLayoutPanel.TabIndex = 0;
            this.conversionsFlowLayoutPanel.WrapContents = false;
            this.conversionsFlowLayoutPanel.SizeChanged += new System.EventHandler(this.conversionsFlowLayoutPanel_SizeChanged);
            // 
            // addConversionButton
            // 
            this.addConversionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addConversionButton.Location = new System.Drawing.Point(12, 712);
            this.addConversionButton.Name = "addConversionButton";
            this.addConversionButton.Size = new System.Drawing.Size(605, 58);
            this.addConversionButton.TabIndex = 1;
            this.addConversionButton.Text = "Add a conversion";
            this.addConversionButton.UseVisualStyleBackColor = true;
            this.addConversionButton.Click += new System.EventHandler(this.addConversionButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Location = new System.Drawing.Point(623, 712);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(185, 58);
            this.optionsButton.TabIndex = 2;
            this.optionsButton.Text = "Single Playlist Preview";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // MultiplePlaylistConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 782);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.addConversionButton);
            this.Controls.Add(this.conversionsFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiplePlaylistConversionForm";
            this.Text = "MultiplePlaylistConversion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiplePlaylistConversionForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel conversionsFlowLayoutPanel;
        private System.Windows.Forms.Button addConversionButton;
        private System.Windows.Forms.Button optionsButton;
    }
}