namespace ECOPharma2013
{
    partial class frmDVTEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDVTEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDVTThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnDVTLuu = new System.Windows.Forms.ToolStripButton();
            this.btnDVTDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenDVT = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 260);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(714, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(10, 17);
            this.statusTB.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDVTThemMoi,
            this.btnDVTLuu,
            this.btnDVTDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(714, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDVTThemMoi
            // 
            this.btnDVTThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnDVTThemMoi.Image")));
            this.btnDVTThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDVTThemMoi.Name = "btnDVTThemMoi";
            this.btnDVTThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnDVTThemMoi.Text = "Thêm Mới";
            this.btnDVTThemMoi.Click += new System.EventHandler(this.btnDVTThemMoi_Click);
            // 
            // btnDVTLuu
            // 
            this.btnDVTLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnDVTLuu.Image")));
            this.btnDVTLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDVTLuu.Name = "btnDVTLuu";
            this.btnDVTLuu.Size = new System.Drawing.Size(53, 24);
            this.btnDVTLuu.Text = "Lưu";
            this.btnDVTLuu.Click += new System.EventHandler(this.btnDVTLuu_Click);
            // 
            // btnDVTDong
            // 
            this.btnDVTDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDVTDong.Image")));
            this.btnDVTDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDVTDong.Name = "btnDVTDong";
            this.btnDVTDong.Size = new System.Drawing.Size(66, 24);
            this.btnDVTDong.Text = "Đóng";
            this.btnDVTDong.Click += new System.EventHandler(this.btnDVTDong_Click);
            // 
            // txtTenDVT
            // 
            this.txtTenDVT.Location = new System.Drawing.Point(171, 74);
            this.txtTenDVT.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDVT.Name = "txtTenDVT";
            this.txtTenDVT.Size = new System.Drawing.Size(254, 24);
            this.txtTenDVT.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(171, 129);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(254, 80);
            this.txtGhiChu.TabIndex = 3;
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(488, 75);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(172, 22);
            this.ckKhongDung.TabIndex = 4;
            this.ckKhongDung.Text = "Không Dùng ĐVT Này";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên Đơn Vị Tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ghi Chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(432, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "*";
            // 
            // frmDVTEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 282);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenDVT);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDVTEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Vị Tính";
            this.Load += new System.EventHandler(this.frmDVTEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDVTEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnDVTThemMoi;
        private System.Windows.Forms.ToolStripButton btnDVTLuu;
        private System.Windows.Forms.ToolStripButton btnDVTDong;
        private System.Windows.Forms.TextBox txtTenDVT;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}