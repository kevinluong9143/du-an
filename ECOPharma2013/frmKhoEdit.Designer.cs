namespace ECOPharma2013
{
    partial class frmKhoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnKhoThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnKhoLuu = new System.Windows.Forms.ToolStripButton();
            this.btnKhoDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboLoaiKho = new System.Windows.Forms.ComboBox();
            this.cboNhomKho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(688, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKhoThemMoi,
            this.btnKhoLuu,
            this.btnKhoDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(688, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnKhoThemMoi
            // 
            this.btnKhoThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoThemMoi.Image")));
            this.btnKhoThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKhoThemMoi.Name = "btnKhoThemMoi";
            this.btnKhoThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnKhoThemMoi.Text = "&Thêm Mới";
            this.btnKhoThemMoi.Click += new System.EventHandler(this.btnKhoThemMoi_Click);
            // 
            // btnKhoLuu
            // 
            this.btnKhoLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoLuu.Image")));
            this.btnKhoLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKhoLuu.Name = "btnKhoLuu";
            this.btnKhoLuu.Size = new System.Drawing.Size(53, 24);
            this.btnKhoLuu.Text = "&Lưu";
            this.btnKhoLuu.Click += new System.EventHandler(this.btnKhoLuu_Click);
            // 
            // btnKhoDong
            // 
            this.btnKhoDong.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoDong.Image")));
            this.btnKhoDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKhoDong.Name = "btnKhoDong";
            this.btnKhoDong.Size = new System.Drawing.Size(66, 24);
            this.btnKhoDong.Text = "Đóng";
            this.btnKhoDong.Click += new System.EventHandler(this.btnKhoDong_Click);
            // 
            // txtTenKho
            // 
            this.txtTenKho.Location = new System.Drawing.Point(85, 100);
            this.txtTenKho.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(258, 24);
            this.txtTenKho.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(85, 140);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(258, 92);
            this.txtGhiChu.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên Kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(85, 250);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(174, 22);
            this.ckKhongDung.TabIndex = 6;
            this.ckKhongDung.Text = "Không Dùng Kho Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(348, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 18);
            this.label16.TabIndex = 33;
            this.label16.Text = "*";
            // 
            // cboLoaiKho
            // 
            this.cboLoaiKho.FormattingEnabled = true;
            this.cboLoaiKho.Location = new System.Drawing.Point(452, 58);
            this.cboLoaiKho.Name = "cboLoaiKho";
            this.cboLoaiKho.Size = new System.Drawing.Size(213, 26);
            this.cboLoaiKho.TabIndex = 34;
            // 
            // cboNhomKho
            // 
            this.cboNhomKho.FormattingEnabled = true;
            this.cboNhomKho.Location = new System.Drawing.Point(452, 98);
            this.cboNhomKho.Name = "cboNhomKho";
            this.cboNhomKho.Size = new System.Drawing.Size(213, 26);
            this.cboNhomKho.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Loại Kho:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nhóm Kho:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(671, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 18);
            this.label5.TabIndex = 38;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(671, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 39;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 63);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "Mã Kho:";
            // 
            // txtMaKho
            // 
            this.txtMaKho.Enabled = false;
            this.txtMaKho.Location = new System.Drawing.Point(85, 60);
            this.txtMaKho.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(144, 24);
            this.txtMaKho.TabIndex = 40;
            // 
            // frmKhoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 300);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaKho);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNhomKho);
            this.Controls.Add(this.cboLoaiKho);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenKho);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmKhoEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhoEdit_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnKhoThemMoi;
        private System.Windows.Forms.ToolStripButton btnKhoLuu;
        private System.Windows.Forms.ToolStripButton btnKhoDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboLoaiKho;
        private System.Windows.Forms.ComboBox cboNhomKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaKho;
    }
}