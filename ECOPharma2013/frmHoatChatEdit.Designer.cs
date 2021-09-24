namespace ECOPharma2013
{
    partial class frmHoatChatEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoatChatEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHCThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnHCLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHCDong = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHoatChat = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHCThemMoi,
            this.btnHCLuu,
            this.btnHCDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHCThemMoi
            // 
            this.btnHCThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnHCThemMoi.Image")));
            this.btnHCThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHCThemMoi.Name = "btnHCThemMoi";
            this.btnHCThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnHCThemMoi.Text = "&Thêm Mới";
            this.btnHCThemMoi.Click += new System.EventHandler(this.btnHCThemMoi_Click);
            // 
            // btnHCLuu
            // 
            this.btnHCLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnHCLuu.Image")));
            this.btnHCLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHCLuu.Name = "btnHCLuu";
            this.btnHCLuu.Size = new System.Drawing.Size(53, 24);
            this.btnHCLuu.Text = "&Lưu";
            this.btnHCLuu.Click += new System.EventHandler(this.btnHCLuu_Click);
            // 
            // btnHCDong
            // 
            this.btnHCDong.Image = ((System.Drawing.Image)(resources.GetObject("btnHCDong.Image")));
            this.btnHCDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHCDong.Name = "btnHCDong";
            this.btnHCDong.Size = new System.Drawing.Size(66, 24);
            this.btnHCDong.Text = "Đóng";
            this.btnHCDong.Click += new System.EventHandler(this.btnHCDong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(726, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(10, 17);
            this.statusTB.Text = " ";
            // 
            // txtHoatChat
            // 
            this.txtHoatChat.Location = new System.Drawing.Point(137, 66);
            this.txtHoatChat.Multiline = true;
            this.txtHoatChat.Name = "txtHoatChat";
            this.txtHoatChat.Size = new System.Drawing.Size(278, 145);
            this.txtHoatChat.TabIndex = 0;
            this.txtHoatChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoatChatEdit_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(137, 237);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(278, 90);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoatChatEdit_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Phân loại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(461, 68);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(109, 22);
            this.ckKhongDung.TabIndex = 2;
            this.ckKhongDung.Text = "Không Dùng";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoatChatEdit_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(419, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 34;
            this.label15.Text = "*";
            // 
            // frmHoatChatEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 367);
            this.ControlBox = false;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtHoatChat);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHoatChatEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân loại";
            this.Load += new System.EventHandler(this.frmHoatChatEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoatChatEdit_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHCThemMoi;
        private System.Windows.Forms.ToolStripButton btnHCLuu;
        private System.Windows.Forms.ToolStripButton btnHCDong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.TextBox txtHoatChat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label15;
    }
}