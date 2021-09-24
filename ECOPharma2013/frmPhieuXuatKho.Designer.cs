namespace ECOPharma2013
{
    partial class frmPhieuXuatKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuXuatKho));
            this.btnXuatKho = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new Telerik.WinControls.UI.RadButton();
            this.progressBarTinhTrangIn = new System.Windows.Forms.ProgressBar();
            this.btnIn = new Telerik.WinControls.UI.RadButton();
            this.txtDenSo = new System.Windows.Forms.TextBox();
            this.rbtnInNhieuPhieu = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuSo = new System.Windows.Forms.TextBox();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.rbtnInMotPhieu = new System.Windows.Forms.RadioButton();
            this.rbtnInTatCa = new System.Windows.Forms.RadioButton();
            this.progressBarTinhTrangXuatKho = new System.Windows.Forms.ProgressBar();
            this.ckLayPhieuXuatDirect = new System.Windows.Forms.CheckBox();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.cbIsXuatHangCoChiDinh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnXuatKho)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXuatKho
            // 
            this.btnXuatKho.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatKho.Image")));
            this.btnXuatKho.Location = new System.Drawing.Point(39, 14);
            this.btnXuatKho.Name = "btnXuatKho";
            this.btnXuatKho.Size = new System.Drawing.Size(120, 62);
            this.btnXuatKho.TabIndex = 0;
            this.btnXuatKho.Text = "Xuất Kho";
            this.btnXuatKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXuatKho.Click += new System.EventHandler(this.btnXuatKho_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.progressBarTinhTrangIn);
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.txtDenSo);
            this.groupBox1.Controls.Add(this.rbtnInNhieuPhieu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTuSo);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.rbtnInMotPhieu);
            this.groupBox1.Controls.Add(this.rbtnInTatCa);
            this.groupBox1.Location = new System.Drawing.Point(38, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "In Phiếu Xuất Kho";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(35, 170);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(91, 31);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // progressBarTinhTrangIn
            // 
            this.progressBarTinhTrangIn.Location = new System.Drawing.Point(0, 217);
            this.progressBarTinhTrangIn.Name = "progressBarTinhTrangIn";
            this.progressBarTinhTrangIn.Size = new System.Drawing.Size(287, 23);
            this.progressBarTinhTrangIn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTinhTrangIn.TabIndex = 8;
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(152, 170);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(91, 32);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtDenSo
            // 
            this.txtDenSo.Location = new System.Drawing.Point(143, 120);
            this.txtDenSo.Name = "txtDenSo";
            this.txtDenSo.Size = new System.Drawing.Size(100, 20);
            this.txtDenSo.TabIndex = 6;
            // 
            // rbtnInNhieuPhieu
            // 
            this.rbtnInNhieuPhieu.AutoSize = true;
            this.rbtnInNhieuPhieu.Location = new System.Drawing.Point(43, 94);
            this.rbtnInNhieuPhieu.Name = "rbtnInNhieuPhieu";
            this.rbtnInNhieuPhieu.Size = new System.Drawing.Size(99, 17);
            this.rbtnInNhieuPhieu.TabIndex = 5;
            this.rbtnInNhieuPhieu.TabStop = true;
            this.rbtnInNhieuPhieu.Text = "In Từ Phiếu Số:";
            this.rbtnInNhieuPhieu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đến Số:";
            // 
            // txtTuSo
            // 
            this.txtTuSo.Location = new System.Drawing.Point(143, 92);
            this.txtTuSo.Name = "txtTuSo";
            this.txtTuSo.Size = new System.Drawing.Size(100, 20);
            this.txtTuSo.TabIndex = 3;
            this.txtTuSo.TextChanged += new System.EventHandler(this.txtTuSo_TextChanged);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(143, 61);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(100, 20);
            this.txtSoPhieu.TabIndex = 2;
            this.txtSoPhieu.TextChanged += new System.EventHandler(this.txtSoPhieu_TextChanged);
            // 
            // rbtnInMotPhieu
            // 
            this.rbtnInMotPhieu.AutoSize = true;
            this.rbtnInMotPhieu.Location = new System.Drawing.Point(43, 63);
            this.rbtnInMotPhieu.Name = "rbtnInMotPhieu";
            this.rbtnInMotPhieu.Size = new System.Drawing.Size(83, 17);
            this.rbtnInMotPhieu.TabIndex = 1;
            this.rbtnInMotPhieu.TabStop = true;
            this.rbtnInMotPhieu.Text = "In Phiếu Số:";
            this.rbtnInMotPhieu.UseVisualStyleBackColor = true;
            // 
            // rbtnInTatCa
            // 
            this.rbtnInTatCa.AutoSize = true;
            this.rbtnInTatCa.Location = new System.Drawing.Point(43, 29);
            this.rbtnInTatCa.Name = "rbtnInTatCa";
            this.rbtnInTatCa.Size = new System.Drawing.Size(69, 17);
            this.rbtnInTatCa.TabIndex = 0;
            this.rbtnInTatCa.TabStop = true;
            this.rbtnInTatCa.Text = "In Tất Cả";
            this.rbtnInTatCa.UseVisualStyleBackColor = true;
            // 
            // progressBarTinhTrangXuatKho
            // 
            this.progressBarTinhTrangXuatKho.Location = new System.Drawing.Point(38, 109);
            this.progressBarTinhTrangXuatKho.Name = "progressBarTinhTrangXuatKho";
            this.progressBarTinhTrangXuatKho.Size = new System.Drawing.Size(287, 23);
            this.progressBarTinhTrangXuatKho.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTinhTrangXuatKho.TabIndex = 2;
            // 
            // ckLayPhieuXuatDirect
            // 
            this.ckLayPhieuXuatDirect.AutoSize = true;
            this.ckLayPhieuXuatDirect.Location = new System.Drawing.Point(181, 58);
            this.ckLayPhieuXuatDirect.Name = "ckLayPhieuXuatDirect";
            this.ckLayPhieuXuatDirect.Size = new System.Drawing.Size(124, 17);
            this.ckLayPhieuXuatDirect.TabIndex = 3;
            this.ckLayPhieuXuatDirect.Text = "Lấy phiếu xuất direct";
            this.ckLayPhieuXuatDirect.UseVisualStyleBackColor = true;
            this.ckLayPhieuXuatDirect.CheckedChanged += new System.EventHandler(this.ckLayPhieuXuatDirect_CheckedChanged);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.UseEXDialog = true;
            // 
            // cbIsXuatHangCoChiDinh
            // 
            this.cbIsXuatHangCoChiDinh.AutoSize = true;
            this.cbIsXuatHangCoChiDinh.ForeColor = System.Drawing.Color.Red;
            this.cbIsXuatHangCoChiDinh.Location = new System.Drawing.Point(181, 19);
            this.cbIsXuatHangCoChiDinh.Name = "cbIsXuatHangCoChiDinh";
            this.cbIsXuatHangCoChiDinh.Size = new System.Drawing.Size(136, 17);
            this.cbIsXuatHangCoChiDinh.TabIndex = 4;
            this.cbIsXuatHangCoChiDinh.Text = "Xuất Hàng Có Chỉ Định";
            this.cbIsXuatHangCoChiDinh.UseVisualStyleBackColor = true;
            this.cbIsXuatHangCoChiDinh.CheckedChanged += new System.EventHandler(this.cbIsXuatHangCoChiDinh_CheckedChanged);
            // 
            // frmPhieuXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 402);
            this.ControlBox = false;
            this.Controls.Add(this.cbIsXuatHangCoChiDinh);
            this.Controls.Add(this.ckLayPhieuXuatDirect);
            this.Controls.Add(this.progressBarTinhTrangXuatKho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXuatKho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuXuatKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập Phiếu Xuất Kho";
            this.Load += new System.EventHandler(this.frmPhieuXuatKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnXuatKho)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnXuatKho;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnIn;
        private System.Windows.Forms.TextBox txtDenSo;
        private System.Windows.Forms.RadioButton rbtnInNhieuPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTuSo;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.RadioButton rbtnInMotPhieu;
        private System.Windows.Forms.RadioButton rbtnInTatCa;
        private System.Windows.Forms.ProgressBar progressBarTinhTrangXuatKho;
        private System.Windows.Forms.CheckBox ckLayPhieuXuatDirect;
        private System.Windows.Forms.ProgressBar progressBarTinhTrangIn;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private Telerik.WinControls.UI.RadButton btnDong;
        private System.Windows.Forms.CheckBox cbIsXuatHangCoChiDinh;
    }
}