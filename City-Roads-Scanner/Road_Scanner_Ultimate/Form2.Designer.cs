namespace Road_Scanner_Ultimate
{
    partial class ScannerVisualiserPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerVisualiserPage));
            this.debugConsole = new System.Windows.Forms.TextBox();
            this.mapProcessingPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapProcessingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // debugConsole
            // 
            this.debugConsole.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.debugConsole.ForeColor = System.Drawing.Color.LawnGreen;
            this.debugConsole.Location = new System.Drawing.Point(1000, 22);
            this.debugConsole.Multiline = true;
            this.debugConsole.Name = "debugConsole";
            this.debugConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugConsole.Size = new System.Drawing.Size(179, 528);
            this.debugConsole.TabIndex = 3;
            // 
            // mapProcessingPicture
            // 
            this.mapProcessingPicture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapProcessingPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapProcessingPicture.Location = new System.Drawing.Point(25, 22);
            this.mapProcessingPicture.Name = "mapProcessingPicture";
            this.mapProcessingPicture.Size = new System.Drawing.Size(957, 528);
            this.mapProcessingPicture.TabIndex = 2;
            this.mapProcessingPicture.TabStop = false;
            // 
            // ScannerVisualiserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1195, 562);
            this.Controls.Add(this.debugConsole);
            this.Controls.Add(this.mapProcessingPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScannerVisualiserPage";
            this.Text = "Scanner Visualizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapProcessingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox mapProcessingPicture;
        private System.Windows.Forms.TextBox debugConsole;
    }
}