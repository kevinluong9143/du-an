namespace ECOPharma2013
{
    partial class Fr_DangXuLy
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblThoiGianChay = new System.Windows.Forms.Label();
            this.timerTG = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đang nạp dữ liệu vui lòng đợi...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ECOPharma2013.Properties.Resources.ajax_loader_blue_round;
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 58);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblThoiGianChay
            // 
            this.lblThoiGianChay.AutoSize = true;
            this.lblThoiGianChay.Location = new System.Drawing.Point(75, 45);
            this.lblThoiGianChay.Name = "lblThoiGianChay";
            this.lblThoiGianChay.Size = new System.Drawing.Size(0, 13);
            this.lblThoiGianChay.TabIndex = 2;
            // 
            // timerTG
            // 
            this.timerTG.Interval = 1000;
            this.timerTG.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Fr_DangXuLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 86);
            this.Controls.Add(this.lblThoiGianChay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fr_DangXuLy";
            this.ShowInTaskbar = false;
            this.Text = "F003_Flashing";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThoiGianChay;
        private System.Windows.Forms.Timer timerTG;
    }
}