namespace Road_Scanner_Ultimate
{
    partial class MainPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.button1 = new System.Windows.Forms.Button();
            this.debugBox = new System.Windows.Forms.TextBox();
            this.createPicButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.redMapPathTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chunkSizeTextBox = new System.Windows.Forms.TextBox();
            this.visualiseCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.realMapHeightInMeetersTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeInPixelTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.mapPathButton = new System.Windows.Forms.Panel();
            this.cityMapPreview = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityMapPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(9, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Scanning";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // debugBox
            // 
            this.debugBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.debugBox.ForeColor = System.Drawing.SystemColors.Info;
            this.debugBox.Location = new System.Drawing.Point(43, 373);
            this.debugBox.Multiline = true;
            this.debugBox.Name = "debugBox";
            this.debugBox.ReadOnly = true;
            this.debugBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugBox.Size = new System.Drawing.Size(566, 89);
            this.debugBox.TabIndex = 4;
            this.debugBox.Text = "Debug info...";
            // 
            // createPicButton
            // 
            this.createPicButton.BackColor = System.Drawing.Color.AliceBlue;
            this.createPicButton.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.createPicButton.Location = new System.Drawing.Point(40, 298);
            this.createPicButton.Name = "createPicButton";
            this.createPicButton.Size = new System.Drawing.Size(155, 34);
            this.createPicButton.TabIndex = 6;
            this.createPicButton.Text = "Create Picture";
            this.createPicButton.UseVisualStyleBackColor = false;
            this.createPicButton.Click += new System.EventHandler(this.createPicButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGreen;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(40, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 34);
            this.button2.TabIndex = 0;
            this.button2.Text = "Create Chunks";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 32);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(40, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Config";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Road_Scanner_Ultimate.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 2);
            this.panel2.TabIndex = 8;
            // 
            // redMapPathTextBox
            // 
            this.redMapPathTextBox.Location = new System.Drawing.Point(68, 32);
            this.redMapPathTextBox.Name = "redMapPathTextBox";
            this.redMapPathTextBox.Size = new System.Drawing.Size(541, 20);
            this.redMapPathTextBox.TabIndex = 10;
            this.redMapPathTextBox.Enter += new System.EventHandler(this.redMapPathTextBox_Enter);
            this.redMapPathTextBox.Leave += new System.EventHandler(this.redMapPathTextBox_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.chunkSizeTextBox);
            this.panel3.Controls.Add(this.visualiseCheckBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.realMapHeightInMeetersTextBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.rangeInPixelTextBox);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.createPicButton);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(629, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 430);
            this.panel3.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Chunk size";
            // 
            // chunkSizeTextBox
            // 
            this.chunkSizeTextBox.Location = new System.Drawing.Point(9, 111);
            this.chunkSizeTextBox.Name = "chunkSizeTextBox";
            this.chunkSizeTextBox.Size = new System.Drawing.Size(187, 20);
            this.chunkSizeTextBox.TabIndex = 15;
            this.chunkSizeTextBox.Text = "0";
            this.chunkSizeTextBox.TextChanged += new System.EventHandler(this.chunkSizeTextBox_TextChanged);
            // 
            // visualiseCheckBox
            // 
            this.visualiseCheckBox.AutoSize = true;
            this.visualiseCheckBox.Location = new System.Drawing.Point(9, 147);
            this.visualiseCheckBox.Name = "visualiseCheckBox";
            this.visualiseCheckBox.Size = new System.Drawing.Size(115, 17);
            this.visualiseCheckBox.TabIndex = 14;
            this.visualiseCheckBox.Text = "Visualise generator";
            this.visualiseCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Real map height in meeters";
            // 
            // realMapHeightInMeetersTextBox
            // 
            this.realMapHeightInMeetersTextBox.Location = new System.Drawing.Point(9, 23);
            this.realMapHeightInMeetersTextBox.Name = "realMapHeightInMeetersTextBox";
            this.realMapHeightInMeetersTextBox.Size = new System.Drawing.Size(187, 20);
            this.realMapHeightInMeetersTextBox.TabIndex = 12;
            this.realMapHeightInMeetersTextBox.Text = "0";
            this.realMapHeightInMeetersTextBox.TextChanged += new System.EventHandler(this.realMapHeightInMeetersTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Range between points in pixels";
            // 
            // rangeInPixelTextBox
            // 
            this.rangeInPixelTextBox.Location = new System.Drawing.Point(9, 66);
            this.rangeInPixelTextBox.Name = "rangeInPixelTextBox";
            this.rangeInPixelTextBox.Size = new System.Drawing.Size(187, 20);
            this.rangeInPixelTextBox.TabIndex = 10;
            this.rangeInPixelTextBox.Text = "0";
            this.rangeInPixelTextBox.TextChanged += new System.EventHandler(this.rangeInPixelTextBox_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Location = new System.Drawing.Point(-1, 205);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 2);
            this.panel4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Map";
            // 
            // mapPathButton
            // 
            this.mapPathButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mapPathButton.BackgroundImage = global::Road_Scanner_Ultimate.Properties.Resources.select;
            this.mapPathButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mapPathButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapPathButton.Location = new System.Drawing.Point(43, 31);
            this.mapPathButton.Name = "mapPathButton";
            this.mapPathButton.Size = new System.Drawing.Size(25, 21);
            this.mapPathButton.TabIndex = 17;
            this.mapPathButton.Click += new System.EventHandler(this.mapPathButton_Click);
            // 
            // cityMapPreview
            // 
            this.cityMapPreview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cityMapPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cityMapPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cityMapPreview.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cityMapPreview.InitialImage = null;
            this.cityMapPreview.Location = new System.Drawing.Point(43, 52);
            this.cityMapPreview.Name = "cityMapPreview";
            this.cityMapPreview.Size = new System.Drawing.Size(566, 321);
            this.cityMapPreview.TabIndex = 0;
            this.cityMapPreview.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(836, 472);
            this.Controls.Add(this.mapPathButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.redMapPathTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.cityMapPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "Road Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.MainPage_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityMapPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cityMapPreview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox debugBox;
        private System.Windows.Forms.Button createPicButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox redMapPathTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rangeInPixelTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox realMapHeightInMeetersTextBox;
        private System.Windows.Forms.CheckBox visualiseCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox chunkSizeTextBox;
        private System.Windows.Forms.Panel mapPathButton;
    }
}

