namespace ECOPharma2013
{
    partial class frmThanhPhoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhPhoEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTPThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnTPLuu = new System.Windows.Forms.ToolStripButton();
            this.btnTPDong = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtTenTP = new System.Windows.Forms.TextBox();
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
            this.btnTPThemMoi,
            this.btnTPLuu,
            this.btnTPDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(617, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTPThemMoi
            // 
            this.btnTPThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnTPThemMoi.Image")));
            this.btnTPThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTPThemMoi.Name = "btnTPThemMoi";
            this.btnTPThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnTPThemMoi.Text = "&Thêm Mới";
            this.btnTPThemMoi.Click += new System.EventHandler(this.btnTPThemMoi_Click);
            // 
            // btnTPLuu
            // 
            this.btnTPLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnTPLuu.Image")));
            this.btnTPLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTPLuu.Name = "btnTPLuu";
            this.btnTPLuu.Size = new System.Drawing.Size(53, 24);
            this.btnTPLuu.Text = "&Lưu";
            this.btnTPLuu.Click += new System.EventHandler(this.btnTPLuu_Click);
            // 
            // btnTPDong
            // 
            this.btnTPDong.Image = ((System.Drawing.Image)(resources.GetObject("btnTPDong.Image")));
            this.btnTPDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTPDong.Name = "btnTPDong";
            this.btnTPDong.Size = new System.Drawing.Size(66, 24);
            this.btnTPDong.Text = "Đóng";
            this.btnTPDong.Click += new System.EventHandler(this.btnTPDong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 230);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(617, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(10, 17);
            this.statusTB.Text = " ";
            // 
            // txtTenTP
            // 
            this.txtTenTP.Location = new System.Drawing.Point(154, 62);
            this.txtTenTP.Name = "txtTenTP";
            this.txtTenTP.Size = new System.Drawing.Size(222, 24);
            this.txtTenTP.TabIndex = 0;
            this.txtTenTP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThanhPhoEdit_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(154, 110);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(222, 79);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThanhPhoEdit_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên Thành Phố:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ghi Chú:";
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(407, 65);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(166, 22);
            this.ckKhongDung.TabIndex = 2;
            this.ckKhongDung.Text = "Không Dùng TP Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThanhPhoEdit_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(382, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 35;
            this.label15.Text = "*";
            // 
            // frmThanhPhoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 252);
            this.ControlBox = false;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenTP);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhPhoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thành Phố";
            this.Load += new System.EventHandler(this.frmThanhPhoEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThanhPhoEdit_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ToolStripButton btnTPThemMoi;
        public System.Windows.Forms.ToolStripButton btnTPLuu;
        public System.Windows.Forms.ToolStripButton btnTPDong;
        public System.Windows.Forms.TextBox txtTenTP;
        public System.Windows.Forms.TextBox txtGhiChu;
        public System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label15;
    }
}