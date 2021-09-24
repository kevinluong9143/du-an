namespace ECOPharma2013
{
    partial class frmQuanEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnQuanThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnQuanLuu = new System.Windows.Forms.ToolStripButton();
            this.btnQuanDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenQuan = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB,
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(610, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(10, 17);
            this.statusTB.Text = " ";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuanThemMoi,
            this.btnQuanLuu,
            this.btnQuanDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(610, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnQuanThemMoi
            // 
            this.btnQuanThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanThemMoi.Image")));
            this.btnQuanThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuanThemMoi.Name = "btnQuanThemMoi";
            this.btnQuanThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnQuanThemMoi.Text = "&Thêm Mới";
            this.btnQuanThemMoi.Click += new System.EventHandler(this.btnQuanThemMoi_Click);
            // 
            // btnQuanLuu
            // 
            this.btnQuanLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLuu.Image")));
            this.btnQuanLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuanLuu.Name = "btnQuanLuu";
            this.btnQuanLuu.Size = new System.Drawing.Size(53, 24);
            this.btnQuanLuu.Text = "&Lưu";
            this.btnQuanLuu.Click += new System.EventHandler(this.btnQuanLuu_Click);
            // 
            // btnQuanDong
            // 
            this.btnQuanDong.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanDong.Image")));
            this.btnQuanDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuanDong.Name = "btnQuanDong";
            this.btnQuanDong.Size = new System.Drawing.Size(66, 24);
            this.btnQuanDong.Text = "Đóng";
            this.btnQuanDong.Click += new System.EventHandler(this.btnQuanDong_Click);
            // 
            // txtTenQuan
            // 
            this.txtTenQuan.Location = new System.Drawing.Point(134, 64);
            this.txtTenQuan.Name = "txtTenQuan";
            this.txtTenQuan.Size = new System.Drawing.Size(228, 24);
            this.txtTenQuan.TabIndex = 0;
            this.txtTenQuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuanEdit_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(134, 113);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(228, 71);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuanEdit_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên Quận:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(399, 63);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(183, 22);
            this.ckKhongDung.TabIndex = 2;
            this.ckKhongDung.Text = "Không Dùng Quận Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuanEdit_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(368, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 35;
            this.label15.Text = "*";
            // 
            // frmQuanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 259);
            this.ControlBox = false;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenQuan);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quận";
            this.Load += new System.EventHandler(this.frmQuanEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuanEdit_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnQuanDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
        public System.Windows.Forms.ToolStripButton btnQuanThemMoi;
        public System.Windows.Forms.ToolStripButton btnQuanLuu;
        public System.Windows.Forms.TextBox txtTenQuan;
        public System.Windows.Forms.TextBox txtGhiChu;
        public System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label15;
    }
}