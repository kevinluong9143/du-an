namespace ECOPharma2013
{
    partial class frmDBCEdit
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDBCThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnDBCLuu = new System.Windows.Forms.ToolStripButton();
            this.btnDBCDong = new System.Windows.Forms.ToolStripButton();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDBC = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 226);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(650, 22);
            this.statusStrip1.TabIndex = 6;
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
            this.btnDBCThemMoi,
            this.btnDBCLuu,
            this.btnDBCDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(650, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDBCThemMoi
            // 
            this.btnDBCThemMoi.Image = global::ECOPharma2013.Properties.Resources.btnDBCThemMoi_Image;
            this.btnDBCThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBCThemMoi.Name = "btnDBCThemMoi";
            this.btnDBCThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnDBCThemMoi.Text = "&Thêm Mới";
            this.btnDBCThemMoi.ToolTipText = "Thêm Mới";
            this.btnDBCThemMoi.Click += new System.EventHandler(this.btnDBCThemMoi_Click);
            // 
            // btnDBCLuu
            // 
            this.btnDBCLuu.Image = global::ECOPharma2013.Properties.Resources.btnDBCLuu_Image;
            this.btnDBCLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBCLuu.Name = "btnDBCLuu";
            this.btnDBCLuu.Size = new System.Drawing.Size(53, 24);
            this.btnDBCLuu.Text = "&Lưu";
            this.btnDBCLuu.Click += new System.EventHandler(this.btnDBCLuu_Click);
            // 
            // btnDBCDong
            // 
            this.btnDBCDong.Image = global::ECOPharma2013.Properties.Resources.btnDBCDong_Image;
            this.btnDBCDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBCDong.Name = "btnDBCDong";
            this.btnDBCDong.Size = new System.Drawing.Size(66, 24);
            this.btnDBCDong.Text = "Đóng";
            this.btnDBCDong.Click += new System.EventHandler(this.btnDBCDong_Click);
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(440, 63);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(179, 22);
            this.ckKhongDung.TabIndex = 2;
            this.ckKhongDung.Text = "Không Dùng DBC Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dạng Bào Chế:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // txtTenDBC
            // 
            this.txtTenDBC.Location = new System.Drawing.Point(155, 61);
            this.txtTenDBC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDBC.Name = "txtTenDBC";
            this.txtTenDBC.Size = new System.Drawing.Size(245, 24);
            this.txtTenDBC.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(155, 108);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(245, 80);
            this.txtGhiChu.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(407, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 18);
            this.label16.TabIndex = 7;
            this.label16.Text = "*";
            // 
            // frmDBCEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 248);
            this.ControlBox = false;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenDBC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDBCEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dạng Bào Chế";
            this.Load += new System.EventHandler(this.frmDBCEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDBCEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnDBCThemMoi;
        private System.Windows.Forms.ToolStripButton btnDBCLuu;
        private System.Windows.Forms.ToolStripButton btnDBCDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.TextBox txtTenDBC;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label16;
    }
}