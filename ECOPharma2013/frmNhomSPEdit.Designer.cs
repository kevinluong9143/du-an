namespace ECOPharma2013
{
    partial class frmNhomSPEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomSPEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNSPThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnNSPLuu = new System.Windows.Forms.ToolStripButton();
            this.btnNSPDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenNSP = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(753, 22);
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
            this.btnNSPThemMoi,
            this.btnNSPLuu,
            this.btnNSPDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(753, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNSPThemMoi
            // 
            this.btnNSPThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnNSPThemMoi.Image")));
            this.btnNSPThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSPThemMoi.Name = "btnNSPThemMoi";
            this.btnNSPThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnNSPThemMoi.Text = "Thêm Mới";
            this.btnNSPThemMoi.Click += new System.EventHandler(this.btnNSPThemMoi_Click);
            // 
            // btnNSPLuu
            // 
            this.btnNSPLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnNSPLuu.Image")));
            this.btnNSPLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSPLuu.Name = "btnNSPLuu";
            this.btnNSPLuu.Size = new System.Drawing.Size(53, 24);
            this.btnNSPLuu.Text = "Lưu";
            this.btnNSPLuu.Click += new System.EventHandler(this.btnNSPLuu_Click);
            // 
            // btnNSPDong
            // 
            this.btnNSPDong.Image = ((System.Drawing.Image)(resources.GetObject("btnNSPDong.Image")));
            this.btnNSPDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSPDong.Name = "btnNSPDong";
            this.btnNSPDong.Size = new System.Drawing.Size(66, 24);
            this.btnNSPDong.Text = "Đóng";
            this.btnNSPDong.Click += new System.EventHandler(this.btnNSPDong_Click);
            // 
            // txtTenNSP
            // 
            this.txtTenNSP.Location = new System.Drawing.Point(193, 69);
            this.txtTenNSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNSP.Name = "txtTenNSP";
            this.txtTenNSP.Size = new System.Drawing.Size(275, 24);
            this.txtTenNSP.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(193, 109);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(275, 90);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên Nhóm Sản Phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(515, 70);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(212, 22);
            this.ckKhongDung.TabIndex = 6;
            this.ckKhongDung.Text = "Không Dùng Nhóm SP Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            // 
            // frmNhomSPEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 277);
            this.ControlBox = false;
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenNSP);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhomSPEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm Sản Phẩm";
            this.Load += new System.EventHandler(this.frmNhomSPEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhomSPEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnNSPThemMoi;
        private System.Windows.Forms.ToolStripButton btnNSPLuu;
        private System.Windows.Forms.ToolStripButton btnNSPDong;
        private System.Windows.Forms.TextBox txtTenNSP;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckKhongDung;
    }
}