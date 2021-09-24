namespace ECOPharma2013
{
    partial class frmGiamGiaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiamGiaEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGiamGiaThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnGiamGiaLuu = new System.Windows.Forms.ToolStripButton();
            this.btnGiamGiaDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenGiamGia = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtMucGiam = new System.Windows.Forms.TextBox();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGiamGiaThemMoi,
            this.btnGiamGiaLuu,
            this.btnGiamGiaDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGiamGiaThemMoi
            // 
            this.btnGiamGiaThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnGiamGiaThemMoi.Image")));
            this.btnGiamGiaThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGiamGiaThemMoi.Name = "btnGiamGiaThemMoi";
            this.btnGiamGiaThemMoi.Size = new System.Drawing.Size(82, 22);
            this.btnGiamGiaThemMoi.Text = "&Thêm Mới";
            this.btnGiamGiaThemMoi.Click += new System.EventHandler(this.btnGiamGiaThemMoi_Click);
            // 
            // btnGiamGiaLuu
            // 
            this.btnGiamGiaLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnGiamGiaLuu.Image")));
            this.btnGiamGiaLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGiamGiaLuu.Name = "btnGiamGiaLuu";
            this.btnGiamGiaLuu.Size = new System.Drawing.Size(47, 22);
            this.btnGiamGiaLuu.Text = "&Lưu";
            this.btnGiamGiaLuu.Click += new System.EventHandler(this.btnGiamGiaLuu_Click);
            // 
            // btnGiamGiaDong
            // 
            this.btnGiamGiaDong.Image = ((System.Drawing.Image)(resources.GetObject("btnGiamGiaDong.Image")));
            this.btnGiamGiaDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGiamGiaDong.Name = "btnGiamGiaDong";
            this.btnGiamGiaDong.Size = new System.Drawing.Size(56, 22);
            this.btnGiamGiaDong.Text = "Đóng";
            this.btnGiamGiaDong.Click += new System.EventHandler(this.btnGiamGiaDong_Click);
            // 
            // txtTenGiamGia
            // 
            this.txtTenGiamGia.Location = new System.Drawing.Point(198, 52);
            this.txtTenGiamGia.Name = "txtTenGiamGia";
            this.txtTenGiamGia.Size = new System.Drawing.Size(193, 24);
            this.txtTenGiamGia.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(198, 95);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(193, 79);
            this.txtGhiChu.TabIndex = 3;
            // 
            // txtMucGiam
            // 
            this.txtMucGiam.Location = new System.Drawing.Point(506, 52);
            this.txtMucGiam.Name = "txtMucGiam";
            this.txtMucGiam.Size = new System.Drawing.Size(114, 24);
            this.txtMucGiam.TabIndex = 4;
            this.txtMucGiam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMucGiam_KeyPress);
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(422, 97);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(223, 22);
            this.ckKhongDung.TabIndex = 5;
            this.ckKhongDung.Text = "Không Dùng Chính Sách Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khuyến Mãi/Chiết Khấu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ghi Chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mức Giảm:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(395, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 18);
            this.label16.TabIndex = 33;
            this.label16.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(626, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "*";
            // 
            // frmGiamGiaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 236);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.txtMucGiam);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenGiamGia);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiamGiaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảm Giá";
            this.Load += new System.EventHandler(this.frmGiamGiaEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGiamGiaEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnGiamGiaThemMoi;
        private System.Windows.Forms.ToolStripButton btnGiamGiaLuu;
        private System.Windows.Forms.ToolStripButton btnGiamGiaDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenGiamGia;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtMucGiam;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
    }
}