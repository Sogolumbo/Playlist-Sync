namespace PlaylistConverterGUI
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
            this.conversionsFlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.conversionsFlowLayoutPanel.Name = "conversionsFlowLayoutPanel";
            this.conversionsFlowLayoutPanel.Size = new System.Drawing.Size(626, 339);
            this.conversionsFlowLayoutPanel.TabIndex = 0;
            // 
            // addConversionButton
            // 
            this.addConversionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addConversionButton.Location = new System.Drawing.Point(12, 357);
            this.addConversionButton.Name = "addConversionButton";
            this.addConversionButton.Size = new System.Drawing.Size(435, 58);
            this.addConversionButton.TabIndex = 1;
            this.addConversionButton.Text = "Add a conversion";
            this.addConversionButton.UseVisualStyleBackColor = true;
            this.addConversionButton.Click += new System.EventHandler(this.addConversionButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Location = new System.Drawing.Point(453, 357);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(185, 58);
            this.optionsButton.TabIndex = 2;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // MultiplePlaylistConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 427);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.addConversionButton);
            this.Controls.Add(this.conversionsFlowLayoutPanel);
            this.Name = "MultiplePlaylistConversionForm";
            this.Text = "MultiplePlaylistConversion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel conversionsFlowLayoutPanel;
        private System.Windows.Forms.Button addConversionButton;
        private System.Windows.Forms.Button optionsButton;
    }
}