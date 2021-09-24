namespace ECOPharma2013
{
    partial class frmNhaSanXuatEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaSanXuatEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNSXThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnNSXLuu = new System.Windows.Forms.ToolStripButton();
            this.btnNSXDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenNSX = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.cboThanhPho = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtEmailNSX = new System.Windows.Forms.TextBox();
            this.txtNLH = new System.Windows.Forms.TextBox();
            this.txtDTDD = new System.Windows.Forms.TextBox();
            this.txtEmailNLH = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.ckKhongDung = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEmailTB = new System.Windows.Forms.Label();
            this.lblEmailNLHTB = new System.Windows.Forms.Label();
            this.btnThemNhanhQuan = new System.Windows.Forms.Button();
            this.btnThemNhanhThanhPho = new System.Windows.Forms.Button();
            this.cboQuocGia = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnThemNhanhQuocGia = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(844, 22);
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
            this.btnNSXThemMoi,
            this.btnNSXLuu,
            this.btnNSXDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(844, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNSXThemMoi
            // 
            this.btnNSXThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnNSXThemMoi.Image")));
            this.btnNSXThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSXThemMoi.Name = "btnNSXThemMoi";
            this.btnNSXThemMoi.Size = new System.Drawing.Size(96, 24);
            this.btnNSXThemMoi.Text = "&Thêm Mới";
            this.btnNSXThemMoi.Click += new System.EventHandler(this.btnNSXThemMoi_Click);
            // 
            // btnNSXLuu
            // 
            this.btnNSXLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnNSXLuu.Image")));
            this.btnNSXLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSXLuu.Name = "btnNSXLuu";
            this.btnNSXLuu.Size = new System.Drawing.Size(53, 24);
            this.btnNSXLuu.Text = "&Lưu";
            this.btnNSXLuu.Click += new System.EventHandler(this.btnNSXLuu_Click);
            // 
            // btnNSXDong
            // 
            this.btnNSXDong.Image = ((System.Drawing.Image)(resources.GetObject("btnNSXDong.Image")));
            this.btnNSXDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNSXDong.Name = "btnNSXDong";
            this.btnNSXDong.Size = new System.Drawing.Size(66, 24);
            this.btnNSXDong.Text = "Đóng";
            this.btnNSXDong.Click += new System.EventHandler(this.btnNSXDong_Click);
            // 
            // txtTenNSX
            // 
            this.txtTenNSX.Location = new System.Drawing.Point(108, 46);
            this.txtTenNSX.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNSX.Name = "txtTenNSX";
            this.txtTenNSX.Size = new System.Drawing.Size(320, 24);
            this.txtTenNSX.TabIndex = 0;
            this.txtTenNSX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(108, 89);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(320, 24);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // cboQuan
            // 
            this.cboQuan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboQuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Location = new System.Drawing.Point(108, 130);
            this.cboQuan.Margin = new System.Windows.Forms.Padding(4);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(180, 26);
            this.cboQuan.TabIndex = 2;
            this.cboQuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // cboThanhPho
            // 
            this.cboThanhPho.FormattingEnabled = true;
            this.cboThanhPho.Location = new System.Drawing.Point(108, 173);
            this.cboThanhPho.Margin = new System.Windows.Forms.Padding(4);
            this.cboThanhPho.Name = "cboThanhPho";
            this.cboThanhPho.Size = new System.Drawing.Size(180, 26);
            this.cboThanhPho.TabIndex = 3;
            this.cboThanhPho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(108, 254);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(135, 24);
            this.txtTel.TabIndex = 4;
            this.txtTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(293, 254);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(135, 24);
            this.txtFax.TabIndex = 5;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // txtEmailNSX
            // 
            this.txtEmailNSX.Location = new System.Drawing.Point(108, 294);
            this.txtEmailNSX.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailNSX.Name = "txtEmailNSX";
            this.txtEmailNSX.Size = new System.Drawing.Size(320, 24);
            this.txtEmailNSX.TabIndex = 6;
            this.txtEmailNSX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            this.txtEmailNSX.Leave += new System.EventHandler(this.txtEmailNSX_Leave);
            // 
            // txtNLH
            // 
            this.txtNLH.Location = new System.Drawing.Point(556, 48);
            this.txtNLH.Margin = new System.Windows.Forms.Padding(4);
            this.txtNLH.Name = "txtNLH";
            this.txtNLH.Size = new System.Drawing.Size(260, 24);
            this.txtNLH.TabIndex = 7;
            this.txtNLH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // txtDTDD
            // 
            this.txtDTDD.Location = new System.Drawing.Point(556, 91);
            this.txtDTDD.Margin = new System.Windows.Forms.Padding(4);
            this.txtDTDD.Name = "txtDTDD";
            this.txtDTDD.Size = new System.Drawing.Size(148, 24);
            this.txtDTDD.TabIndex = 8;
            this.txtDTDD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            this.txtDTDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDTDD_KeyPress);
            // 
            // txtEmailNLH
            // 
            this.txtEmailNLH.Location = new System.Drawing.Point(556, 133);
            this.txtEmailNLH.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailNLH.Name = "txtEmailNLH";
            this.txtEmailNLH.Size = new System.Drawing.Size(148, 24);
            this.txtEmailNLH.TabIndex = 9;
            this.txtEmailNLH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            this.txtEmailNLH.Leave += new System.EventHandler(this.txtEmailNLH_Leave);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(556, 195);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(260, 101);
            this.txtGhiChu.TabIndex = 10;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(556, 313);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(178, 22);
            this.ckKhongDung.TabIndex = 13;
            this.ckKhongDung.Text = "Không Dùng NSX Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tên NSX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Địa Chỉ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Quận:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Thành Phố:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tel.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fax:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 299);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Email NSX:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Người LH:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "ĐTDĐ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(470, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Email NLH:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(487, 198);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ghi Chú:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(429, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 34;
            this.label15.Text = "*";
            // 
            // lblEmailTB
            // 
            this.lblEmailTB.AutoSize = true;
            this.lblEmailTB.ForeColor = System.Drawing.Color.Red;
            this.lblEmailTB.Location = new System.Drawing.Point(111, 319);
            this.lblEmailTB.Name = "lblEmailTB";
            this.lblEmailTB.Size = new System.Drawing.Size(0, 18);
            this.lblEmailTB.TabIndex = 39;
            // 
            // lblEmailNLHTB
            // 
            this.lblEmailNLHTB.AutoSize = true;
            this.lblEmailNLHTB.ForeColor = System.Drawing.Color.Red;
            this.lblEmailNLHTB.Location = new System.Drawing.Point(523, 160);
            this.lblEmailNLHTB.Name = "lblEmailNLHTB";
            this.lblEmailNLHTB.Size = new System.Drawing.Size(0, 18);
            this.lblEmailNLHTB.TabIndex = 40;
            // 
            // btnThemNhanhQuan
            // 
            this.btnThemNhanhQuan.Image = global::ECOPharma2013.Properties.Resources.add2;
            this.btnThemNhanhQuan.Location = new System.Drawing.Point(295, 129);
            this.btnThemNhanhQuan.Name = "btnThemNhanhQuan";
            this.btnThemNhanhQuan.Size = new System.Drawing.Size(24, 25);
            this.btnThemNhanhQuan.TabIndex = 49;
            this.btnThemNhanhQuan.UseVisualStyleBackColor = true;
            this.btnThemNhanhQuan.Click += new System.EventHandler(this.btnThemNhanhQuan_Click);
            // 
            // btnThemNhanhThanhPho
            // 
            this.btnThemNhanhThanhPho.Image = global::ECOPharma2013.Properties.Resources.add2;
            this.btnThemNhanhThanhPho.Location = new System.Drawing.Point(295, 172);
            this.btnThemNhanhThanhPho.Name = "btnThemNhanhThanhPho";
            this.btnThemNhanhThanhPho.Size = new System.Drawing.Size(24, 25);
            this.btnThemNhanhThanhPho.TabIndex = 50;
            this.btnThemNhanhThanhPho.UseVisualStyleBackColor = true;
            this.btnThemNhanhThanhPho.Click += new System.EventHandler(this.btnThemNhanhThanhPho_Click);
            // 
            // cboQuocGia
            // 
            this.cboQuocGia.FormattingEnabled = true;
            this.cboQuocGia.Location = new System.Drawing.Point(108, 212);
            this.cboQuocGia.Name = "cboQuocGia";
            this.cboQuocGia.Size = new System.Drawing.Size(180, 26);
            this.cboQuocGia.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 18);
            this.label12.TabIndex = 52;
            this.label12.Text = "Quốc Gia:";
            // 
            // btnThemNhanhQuocGia
            // 
            this.btnThemNhanhQuocGia.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhanhQuocGia.Image")));
            this.btnThemNhanhQuocGia.Location = new System.Drawing.Point(295, 213);
            this.btnThemNhanhQuocGia.Name = "btnThemNhanhQuocGia";
            this.btnThemNhanhQuocGia.Size = new System.Drawing.Size(24, 25);
            this.btnThemNhanhQuocGia.TabIndex = 53;
            this.btnThemNhanhQuocGia.UseVisualStyleBackColor = true;
            this.btnThemNhanhQuocGia.Click += new System.EventHandler(this.btnThemNhanhQuocGia_Click);
            // 
            // frmNhaSanXuatEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 366);
            this.ControlBox = false;
            this.Controls.Add(this.btnThemNhanhQuocGia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboQuocGia);
            this.Controls.Add(this.btnThemNhanhThanhPho);
            this.Controls.Add(this.btnThemNhanhQuan);
            this.Controls.Add(this.lblEmailNLHTB);
            this.Controls.Add(this.lblEmailTB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckKhongDung);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtEmailNLH);
            this.Controls.Add(this.txtDTDD);
            this.Controls.Add(this.txtNLH);
            this.Controls.Add(this.txtEmailNSX);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.cboThanhPho);
            this.Controls.Add(this.cboQuan);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenNSX);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhaSanXuatEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhà Sản Xuất";
            this.Load += new System.EventHandler(this.frmNhaSanXuatEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhaSanXuatEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnNSXThemMoi;
        private System.Windows.Forms.ToolStripButton btnNSXLuu;
        private System.Windows.Forms.ToolStripButton btnNSXDong;
        private System.Windows.Forms.TextBox txtTenNSX;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.ComboBox cboThanhPho;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtEmailNSX;
        private System.Windows.Forms.TextBox txtNLH;
        private System.Windows.Forms.TextBox txtDTDD;
        private System.Windows.Forms.TextBox txtEmailNLH;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox ckKhongDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblEmailTB;
        private System.Windows.Forms.Label lblEmailNLHTB;
        private System.Windows.Forms.Button btnThemNhanhQuan;
        private System.Windows.Forms.Button btnThemNhanhThanhPho;
        private System.Windows.Forms.ComboBox cboQuocGia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnThemNhanhQuocGia;
    }
}