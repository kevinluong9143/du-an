namespace ECOPharma2013
{
    partial class frmPhanLoaiGiaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanLoaiGiaEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPLGThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnPLGLuu = new System.Windows.Forms.ToolStripButton();
            this.btnPLGDong = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtLoaiGia = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtMarkUp = new System.Windows.Forms.TextBox();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPLGThemMoi,
            this.btnPLGLuu,
            this.btnPLGDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPLGThemMoi
            // 
            this.btnPLGThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnPLGThemMoi.Image")));
            this.btnPLGThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPLGThemMoi.Name = "btnPLGThemMoi";
            this.btnPLGThemMoi.Size = new System.Drawing.Size(82, 22);
            this.btnPLGThemMoi.Text = "&Thêm Mới";
            this.btnPLGThemMoi.Click += new System.EventHandler(this.btnPLGThemMoi_Click);
            // 
            // btnPLGLuu
            // 
            this.btnPLGLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnPLGLuu.Image")));
            this.btnPLGLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPLGLuu.Name = "btnPLGLuu";
            this.btnPLGLuu.Size = new System.Drawing.Size(47, 22);
            this.btnPLGLuu.Text = "&Lưu";
            this.btnPLGLuu.Click += new System.EventHandler(this.btnPLGLuu_Click);
            // 
            // btnPLGDong
            // 
            this.btnPLGDong.Image = ((System.Drawing.Image)(resources.GetObject("btnPLGDong.Image")));
            this.btnPLGDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPLGDong.Name = "btnPLGDong";
            this.btnPLGDong.Size = new System.Drawing.Size(56, 22);
            this.btnPLGDong.Text = "Đóng";
            this.btnPLGDong.Click += new System.EventHandler(this.btnPLGDong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 224);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // txtLoaiGia
            // 
            this.txtLoaiGia.Location = new System.Drawing.Point(124, 57);
            this.txtLoaiGia.Name = "txtLoaiGia";
            this.txtLoaiGia.Size = new System.Drawing.Size(190, 24);
            this.txtLoaiGia.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(124, 104);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(190, 66);
            this.txtGhiChu.TabIndex = 3;
            // 
            // txtMarkUp
            // 
            this.txtMarkUp.Location = new System.Drawing.Point(454, 57);
            this.txtMarkUp.Name = "txtMarkUp";
            this.txtMarkUp.Size = new System.Drawing.Size(116, 24);
            this.txtMarkUp.TabIndex = 4;
            this.txtMarkUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarkUp_KeyPress);
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(382, 148);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(202, 22);
            this.ckKhongDung.TabIndex = 5;
            this.ckKhongDung.Text = "Không Dùng Loại Giá Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Loại Giá:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ghi Chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mark Up:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(320, 57);
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
            this.label4.Location = new System.Drawing.Point(576, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "*";
            // 
            // frmPhanLoaiGiaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 246);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.txtMarkUp);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtLoaiGia);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhanLoaiGiaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân Loại Giá";
            this.Load += new System.EventHandler(this.frmPhanLoaiGiaEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhanLoaiGiaEdit_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPLGThemMoi;
        private System.Windows.Forms.ToolStripButton btnPLGLuu;
        private System.Windows.Forms.ToolStripButton btnPLGDong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoaiGia;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtMarkUp;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
    }
}