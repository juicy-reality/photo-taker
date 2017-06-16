namespace RSEnhancedPhoto.Forms
{
    partial class FormDepthBlending
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbZOffset = new System.Windows.Forms.TrackBar();
            this.tbYaw = new System.Windows.Forms.TrackBar();
            this.tbRoll = new System.Windows.Forms.TrackBar();
            this.tbPitch = new System.Windows.Forms.TrackBar();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctrlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPitch)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(4, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // ctrlPanel
            // 
            this.ctrlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPanel.Controls.Add(this.label9);
            this.ctrlPanel.Controls.Add(this.label8);
            this.ctrlPanel.Controls.Add(this.tbScale);
            this.ctrlPanel.Controls.Add(this.label7);
            this.ctrlPanel.Controls.Add(this.label6);
            this.ctrlPanel.Controls.Add(this.label5);
            this.ctrlPanel.Controls.Add(this.label4);
            this.ctrlPanel.Controls.Add(this.tbZOffset);
            this.ctrlPanel.Controls.Add(this.tbYaw);
            this.ctrlPanel.Controls.Add(this.tbRoll);
            this.ctrlPanel.Controls.Add(this.tbPitch);
            this.ctrlPanel.Enabled = false;
            this.ctrlPanel.Location = new System.Drawing.Point(662, 7);
            this.ctrlPanel.Name = "ctrlPanel";
            this.ctrlPanel.Size = new System.Drawing.Size(248, 277);
            this.ctrlPanel.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Depth Blend";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Scale";
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(51, 230);
            this.tbScale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(167, 45);
            this.tbScale.TabIndex = 24;
            this.tbScale.Scroll += new System.EventHandler(this.tbBlend_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Z Offset";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Roll";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Pitch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Yaw";
            // 
            // tbZOffset
            // 
            this.tbZOffset.Location = new System.Drawing.Point(51, 182);
            this.tbZOffset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbZOffset.Maximum = 100;
            this.tbZOffset.Name = "tbZOffset";
            this.tbZOffset.Size = new System.Drawing.Size(167, 45);
            this.tbZOffset.TabIndex = 19;
            this.tbZOffset.TickFrequency = 5;
            this.tbZOffset.Scroll += new System.EventHandler(this.tbBlend_Scroll);
            // 
            // tbYaw
            // 
            this.tbYaw.Location = new System.Drawing.Point(51, 38);
            this.tbYaw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbYaw.Maximum = 100;
            this.tbYaw.Name = "tbYaw";
            this.tbYaw.Size = new System.Drawing.Size(167, 45);
            this.tbYaw.TabIndex = 18;
            this.tbYaw.TickFrequency = 5;
            this.tbYaw.Scroll += new System.EventHandler(this.tbBlend_Scroll);
            // 
            // tbRoll
            // 
            this.tbRoll.Location = new System.Drawing.Point(51, 134);
            this.tbRoll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRoll.Maximum = 100;
            this.tbRoll.Name = "tbRoll";
            this.tbRoll.Size = new System.Drawing.Size(167, 45);
            this.tbRoll.TabIndex = 17;
            this.tbRoll.TickFrequency = 5;
            this.tbRoll.Scroll += new System.EventHandler(this.tbBlend_Scroll);
            // 
            // tbPitch
            // 
            this.tbPitch.Location = new System.Drawing.Point(51, 86);
            this.tbPitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPitch.Maximum = 100;
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.Size = new System.Drawing.Size(167, 45);
            this.tbPitch.TabIndex = 16;
            this.tbPitch.TickFrequency = 5;
            this.tbPitch.Scroll += new System.EventHandler(this.tbBlend_Scroll);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(814, 462);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 24);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 286);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Click on the photo, then start to adjust the blending.";
            // 
            // FormDepthBlending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ctrlPanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDepthBlending";
            this.Text = "Depth Blending";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDepthBlending_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctrlPanel.ResumeLayout(false);
            this.ctrlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ctrlPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbZOffset;
        private System.Windows.Forms.TrackBar tbYaw;
        private System.Windows.Forms.TrackBar tbRoll;
        private System.Windows.Forms.TrackBar tbPitch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}