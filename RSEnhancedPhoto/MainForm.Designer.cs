namespace RSEnhancedPhoto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoStreamDepth = new System.Windows.Forms.RadioButton();
            this.rdoStreamColor = new System.Windows.Forms.RadioButton();
            this.btnTakeDepthPhoto = new System.Windows.Forms.Button();
            this.btnStopStream = new System.Windows.Forms.Button();
            this.btnStartStream = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbEnhancements = new System.Windows.Forms.GroupBox();
            this.btnPasteOnPlane = new System.Windows.Forms.Button();
            this.btnDepthEnhance = new System.Windows.Forms.Button();
            this.btnRefocus = new System.Windows.Forms.Button();
            this.btnDepthResize = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2.SuspendLayout();
            this.gbEnhancements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoStreamDepth);
            this.groupBox2.Controls.Add(this.rdoStreamColor);
            this.groupBox2.Controls.Add(this.btnTakeDepthPhoto);
            this.groupBox2.Controls.Add(this.btnStopStream);
            this.groupBox2.Controls.Add(this.btnStartStream);
            this.groupBox2.Location = new System.Drawing.Point(657, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(164, 102);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Streaming";
            // 
            // rdoStreamDepth
            // 
            this.rdoStreamDepth.AutoSize = true;
            this.rdoStreamDepth.Location = new System.Drawing.Point(80, 72);
            this.rdoStreamDepth.Name = "rdoStreamDepth";
            this.rdoStreamDepth.Size = new System.Drawing.Size(54, 17);
            this.rdoStreamDepth.TabIndex = 5;
            this.rdoStreamDepth.Text = "Depth";
            this.rdoStreamDepth.UseVisualStyleBackColor = true;
            // 
            // rdoStreamColor
            // 
            this.rdoStreamColor.AutoSize = true;
            this.rdoStreamColor.Checked = true;
            this.rdoStreamColor.Location = new System.Drawing.Point(32, 72);
            this.rdoStreamColor.Name = "rdoStreamColor";
            this.rdoStreamColor.Size = new System.Drawing.Size(49, 17);
            this.rdoStreamColor.TabIndex = 4;
            this.rdoStreamColor.TabStop = true;
            this.rdoStreamColor.Text = "Color";
            this.rdoStreamColor.UseVisualStyleBackColor = true;
            // 
            // btnTakeDepthPhoto
            // 
            this.btnTakeDepthPhoto.Image = global::RSEnhancedPhoto.Properties.Resources.Camera_32xLG;
            this.btnTakeDepthPhoto.Location = new System.Drawing.Point(60, 20);
            this.btnTakeDepthPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTakeDepthPhoto.Name = "btnTakeDepthPhoto";
            this.btnTakeDepthPhoto.Size = new System.Drawing.Size(42, 46);
            this.btnTakeDepthPhoto.TabIndex = 3;
            this.btnTakeDepthPhoto.Tag = "TAKE_PHOTO";
            this.btnTakeDepthPhoto.UseVisualStyleBackColor = true;
            this.btnTakeDepthPhoto.Click += new System.EventHandler(this.btnTakeDepthPhoto_Click);
            this.btnTakeDepthPhoto.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTakeDepthPhoto.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnStopStream
            // 
            this.btnStopStream.Image = global::RSEnhancedPhoto.Properties.Resources.StatusAnnotations_Critical_32xLG;
            this.btnStopStream.Location = new System.Drawing.Point(106, 20);
            this.btnStopStream.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopStream.Name = "btnStopStream";
            this.btnStopStream.Size = new System.Drawing.Size(42, 46);
            this.btnStopStream.TabIndex = 2;
            this.btnStopStream.Tag = "STREAM_STOP";
            this.btnStopStream.UseVisualStyleBackColor = true;
            this.btnStopStream.Click += new System.EventHandler(this.btnStopStream_Click);
            this.btnStopStream.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnStopStream.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnStartStream
            // 
            this.btnStartStream.Image = global::RSEnhancedPhoto.Properties.Resources.CameraOrbit_32x;
            this.btnStartStream.Location = new System.Drawing.Point(12, 20);
            this.btnStartStream.Name = "btnStartStream";
            this.btnStartStream.Size = new System.Drawing.Size(42, 46);
            this.btnStartStream.TabIndex = 1;
            this.btnStartStream.Tag = "STREAM_START";
            this.btnStartStream.UseVisualStyleBackColor = true;
            this.btnStartStream.Click += new System.EventHandler(this.btnStream_Click);
            this.btnStartStream.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnStartStream.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(669, 490);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 24);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbEnhancements
            // 
            this.gbEnhancements.Controls.Add(this.btnPasteOnPlane);
            this.gbEnhancements.Controls.Add(this.btnDepthEnhance);
            this.gbEnhancements.Controls.Add(this.btnRefocus);
            this.gbEnhancements.Controls.Add(this.btnDepthResize);
            this.gbEnhancements.Controls.Add(this.btnMeasure);
            this.gbEnhancements.Location = new System.Drawing.Point(657, 130);
            this.gbEnhancements.Name = "gbEnhancements";
            this.gbEnhancements.Size = new System.Drawing.Size(164, 190);
            this.gbEnhancements.TabIndex = 6;
            this.gbEnhancements.TabStop = false;
            this.gbEnhancements.Text = "Photo Enhancements";
            // 
            // btnPasteOnPlane
            // 
            this.btnPasteOnPlane.Location = new System.Drawing.Point(12, 149);
            this.btnPasteOnPlane.Name = "btnPasteOnPlane";
            this.btnPasteOnPlane.Size = new System.Drawing.Size(136, 24);
            this.btnPasteOnPlane.TabIndex = 5;
            this.btnPasteOnPlane.Text = "Paste On Plane";
            this.btnPasteOnPlane.UseVisualStyleBackColor = true;
            this.btnPasteOnPlane.Click += new System.EventHandler(this.btnPasteOnPlane_Click);
            // 
            // btnDepthEnhance
            // 
            this.btnDepthEnhance.Location = new System.Drawing.Point(12, 58);
            this.btnDepthEnhance.Name = "btnDepthEnhance";
            this.btnDepthEnhance.Size = new System.Drawing.Size(136, 24);
            this.btnDepthEnhance.TabIndex = 4;
            this.btnDepthEnhance.Text = "Depth Enhance";
            this.btnDepthEnhance.UseVisualStyleBackColor = true;
            this.btnDepthEnhance.Click += new System.EventHandler(this.btnDepthEnhance_Click);
            // 
            // btnRefocus
            // 
            this.btnRefocus.Location = new System.Drawing.Point(12, 118);
            this.btnRefocus.Name = "btnRefocus";
            this.btnRefocus.Size = new System.Drawing.Size(136, 24);
            this.btnRefocus.TabIndex = 2;
            this.btnRefocus.Text = "Refocus";
            this.btnRefocus.UseVisualStyleBackColor = true;
            this.btnRefocus.Click += new System.EventHandler(this.btnRefocus_Click);
            // 
            // btnDepthResize
            // 
            this.btnDepthResize.Location = new System.Drawing.Point(12, 88);
            this.btnDepthResize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDepthResize.Name = "btnDepthResize";
            this.btnDepthResize.Size = new System.Drawing.Size(136, 24);
            this.btnDepthResize.TabIndex = 6;
            this.btnDepthResize.Text = "Depth Resize";
            this.btnDepthResize.Click += new System.EventHandler(this.btnDepthResize_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Location = new System.Drawing.Point(12, 27);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(136, 24);
            this.btnMeasure.TabIndex = 0;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 496);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Click Start Streamig to begin streaming. Click Take Snapshot to generate a photo " +
    "for enhancement, streaming will automatically stop.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statStrip
            // 
            this.statStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statStrip.Location = new System.Drawing.Point(0, 530);
            this.statStrip.Name = "statStrip";
            this.statStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statStrip.Size = new System.Drawing.Size(832, 22);
            this.statStrip.SizingGrip = false;
            this.statStrip.TabIndex = 8;
            this.statStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 552);
            this.Controls.Add(this.statStrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbEnhancements);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Intel RealSense Enhanced Photography Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbEnhancements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statStrip.ResumeLayout(false);
            this.statStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStartStream;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopStream;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTakeDepthPhoto;
        private System.Windows.Forms.RadioButton rdoStreamDepth;
        private System.Windows.Forms.RadioButton rdoStreamColor;
        private System.Windows.Forms.GroupBox gbEnhancements;
        private System.Windows.Forms.Button btnRefocus;
        private System.Windows.Forms.Button btnDepthResize;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button btnPasteOnPlane;
        private System.Windows.Forms.Button btnDepthEnhance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

