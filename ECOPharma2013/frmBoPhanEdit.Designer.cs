namespace ECOPharma2013
{
    partial class frmBoPhanEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoPhanEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBPThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnBPLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBPDong = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.txtTenBP = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cboBoPhan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 236);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 6;
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
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBPThemMoi,
            this.btnBPLuu,
            this.btnBPDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(828, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBPThemMoi
            // 
            this.btnBPThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnBPThemMoi.Image")));
            this.btnBPThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBPThemMoi.Name = "btnBPThemMoi";
            this.btnBPThemMoi.Size = new System.Drawing.Size(101, 25);
            this.btnBPThemMoi.Text = "Thêm Mới";
            this.btnBPThemMoi.Click += new System.EventHandler(this.btnBPThemMoi_Click);
            // 
            // btnBPLuu
            // 
            this.btnBPLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnBPLuu.Image")));
            this.btnBPLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBPLuu.Name = "btnBPLuu";
            this.btnBPLuu.Size = new System.Drawing.Size(56, 25);
            this.btnBPLuu.Text = "Lưu";
            this.btnBPLuu.Click += new System.EventHandler(this.btnBPLuu_Click);
            // 
            // btnBPDong
            // 
            this.btnBPDong.Image = ((System.Drawing.Image)(resources.GetObject("btnBPDong.Image")));
            this.btnBPDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBPDong.Name = "btnBPDong";
            this.btnBPDong.Size = new System.Drawing.Size(68, 25);
            this.btnBPDong.Text = "Đóng";
            this.btnBPDong.Click += new System.EventHandler(this.btnBPDong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên Bộ Phận:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ghi Chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thuộc Bộ Phận:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(591, 115);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(200, 22);
            this.ckKhongDung.TabIndex = 3;
            this.ckKhongDung.Text = "Không Dùng Bộ Phận Này";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.CheckedChanged += new System.EventHandler(this.ckKhongDung_CheckedChanged);
            // 
            // txtTenBP
            // 
            this.txtTenBP.Location = new System.Drawing.Point(136, 67);
            this.txtTenBP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenBP.Name = "txtTenBP";
            this.txtTenBP.Size = new System.Drawing.Size(284, 24);
            this.txtTenBP.TabIndex = 0;
            this.txtTenBP.TextChanged += new System.EventHandler(this.txtTenBP_TextChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(136, 113);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(284, 80);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // cboBoPhan
            // 
            this.cboBoPhan.FormattingEnabled = true;
            this.cboBoPhan.Location = new System.Drawing.Point(591, 66);
            this.cboBoPhan.Name = "cboBoPhan";
            this.cboBoPhan.Size = new System.Drawing.Size(185, 26);
            this.cboBoPhan.TabIndex = 1;
            this.cboBoPhan.SelectedIndexChanged += new System.EventHandler(this.cboBoPhan_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(424, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "*";
            // 
            // frmBoPhanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 258);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBoPhan);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenBP);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoPhanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bộ Phận";
            this.Load += new System.EventHandler(this.frmBoPhanEdit_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBPThemMoi;
        private System.Windows.Forms.ToolStripButton btnBPLuu;
        private System.Windows.Forms.ToolStripButton btnBPDong;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.TextBox txtTenBP;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cboBoPhan;
        private System.Windows.Forms.Label label4;
    }
}