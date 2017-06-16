namespace RSEnhancedPhoto.Forms
{
    partial class FormDepthEnhance
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
            this.btnExit = new System.Windows.Forms.Button();
            this.rdoLow = new System.Windows.Forms.RadioButton();
            this.rdoHigh = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(852, 590);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(735, 610);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdoLow
            // 
            this.rdoLow.AutoSize = true;
            this.rdoLow.Location = new System.Drawing.Point(3, 3);
            this.rdoLow.Name = "rdoLow";
            this.rdoLow.Size = new System.Drawing.Size(102, 21);
            this.rdoLow.TabIndex = 1;
            this.rdoLow.Text = "Low Quality";
            this.rdoLow.UseVisualStyleBackColor = true;
            this.rdoLow.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoHigh
            // 
            this.rdoHigh.AutoSize = true;
            this.rdoHigh.Location = new System.Drawing.Point(126, 3);
            this.rdoHigh.Name = "rdoHigh";
            this.rdoHigh.Size = new System.Drawing.Size(90, 21);
            this.rdoHigh.TabIndex = 0;
            this.rdoHigh.Text = "Hi Quality";
            this.rdoHigh.UseVisualStyleBackColor = true;
            this.rdoHigh.Click += new System.EventHandler(this.rdo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdoHigh);
            this.panel1.Controls.Add(this.rdoLow);
            this.panel1.Location = new System.Drawing.Point(492, 610);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 30);
            this.panel1.TabIndex = 4;
            // 
            // FormDepthEnhance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDepthEnhance";
            this.Text = "Depth Enhancement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDepthScaling_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdoLow;
        private System.Windows.Forms.RadioButton rdoHigh;
        private System.Windows.Forms.Panel panel1;
    }
}