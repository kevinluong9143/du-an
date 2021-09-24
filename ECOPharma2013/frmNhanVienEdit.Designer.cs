namespace ECOPharma2013
{
    partial class frmNhanVienEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVienEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNVThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btnNVLuu = new System.Windows.Forms.ToolStripButton();
            this.btnNVDong = new System.Windows.Forms.ToolStripButton();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.cboNoiCap = new System.Windows.Forms.ComboBox();
            this.txtDTDD = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboBoPhan = new System.Windows.Forms.ComboBox();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.txtMST = new System.Windows.Forms.TextBox();
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
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpkNgayCap = new System.Windows.Forms.DateTimePicker();
            this.dtpkNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaDinhDanh = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblEmailTB = new System.Windows.Forms.Label();
            this.btnThemNhanhNoiCap = new System.Windows.Forms.Button();
            this.btnThemBoPhan = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNVThemMoi,
            this.btnNVLuu,
            this.btnNVDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(740, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNVThemMoi
            // 
            this.btnNVThemMoi.Image = global::ECOPharma2013.Properties.Resources.btnDBCThemMoi_Image;
            this.btnNVThemMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNVThemMoi.Name = "btnNVThemMoi";
            this.btnNVThemMoi.Size = new System.Drawing.Size(82, 22);
            this.btnNVThemMoi.Text = "&Thêm Mới";
            this.btnNVThemMoi.Click += new System.EventHandler(this.btnNVThemMoi_Click);
            // 
            // btnNVLuu
            // 
            this.btnNVLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnNVLuu.Image")));
            this.btnNVLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNVLuu.Name = "btnNVLuu";
            this.btnNVLuu.Size = new System.Drawing.Size(47, 22);
            this.btnNVLuu.Text = "&Lưu";
            this.btnNVLuu.Click += new System.EventHandler(this.btnNVLuu_Click);
            // 
            // btnNVDong
            // 
            this.btnNVDong.Image = global::ECOPharma2013.Properties.Resources.btnDBCDong_Image;
            this.btnNVDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNVDong.Name = "btnNVDong";
            this.btnNVDong.Size = new System.Drawing.Size(56, 22);
            this.btnNVDong.Text = "Đóng";
            this.btnNVDong.Click += new System.EventHandler(this.btnNVDong_Click);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(112, 79);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(222, 24);
            this.txtTenNV.TabIndex = 0;
            this.txtTenNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(112, 151);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(109, 26);
            this.cboGioiTinh.TabIndex = 3;
            this.cboGioiTinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(112, 188);
            this.txtCMND.Margin = new System.Windows.Forms.Padding(4);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(222, 24);
            this.txtCMND.TabIndex = 4;
            this.txtCMND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtCMND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCMND_KeyPress);
            this.txtCMND.Leave += new System.EventHandler(this.txtCMND_Leave);
            // 
            // cboNoiCap
            // 
            this.cboNoiCap.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNoiCap.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNoiCap.FormattingEnabled = true;
            this.cboNoiCap.Location = new System.Drawing.Point(112, 259);
            this.cboNoiCap.Margin = new System.Windows.Forms.Padding(4);
            this.cboNoiCap.Name = "cboNoiCap";
            this.cboNoiCap.Size = new System.Drawing.Size(191, 26);
            this.cboNoiCap.TabIndex = 6;
            this.cboNoiCap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // txtDTDD
            // 
            this.txtDTDD.Location = new System.Drawing.Point(112, 291);
            this.txtDTDD.Margin = new System.Windows.Forms.Padding(4);
            this.txtDTDD.Name = "txtDTDD";
            this.txtDTDD.Size = new System.Drawing.Size(222, 24);
            this.txtDTDD.TabIndex = 7;
            this.txtDTDD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtDTDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDTDD_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 324);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(222, 24);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // cboBoPhan
            // 
            this.cboBoPhan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBoPhan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBoPhan.FormattingEnabled = true;
            this.cboBoPhan.Location = new System.Drawing.Point(496, 78);
            this.cboBoPhan.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoPhan.Name = "cboBoPhan";
            this.cboBoPhan.Size = new System.Drawing.Size(180, 26);
            this.cboBoPhan.TabIndex = 1;
            this.cboBoPhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // txtSoThe
            // 
            this.txtSoThe.Location = new System.Drawing.Point(496, 115);
            this.txtSoThe.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Size = new System.Drawing.Size(218, 24);
            this.txtSoThe.TabIndex = 9;
            this.txtSoThe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtSoThe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoThe_KeyPress);
            this.txtSoThe.Leave += new System.EventHandler(this.txtSoThe_Leave);
            // 
            // txtMST
            // 
            this.txtMST.Location = new System.Drawing.Point(496, 152);
            this.txtMST.Margin = new System.Windows.Forms.Padding(4);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(218, 24);
            this.txtMST.TabIndex = 10;
            this.txtMST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtMST.Leave += new System.EventHandler(this.txtMST_Leave);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(496, 188);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(218, 93);
            this.txtGhiChu.TabIndex = 11;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // ckKhongDung
            // 
            this.ckKhongDung.AutoSize = true;
            this.ckKhongDung.Location = new System.Drawing.Point(496, 328);
            this.ckKhongDung.Margin = new System.Windows.Forms.Padding(4);
            this.ckKhongDung.Name = "ckKhongDung";
            this.ckKhongDung.Size = new System.Drawing.Size(167, 22);
            this.ckKhongDung.TabIndex = 13;
            this.ckKhongDung.Text = "Khóa Nhân Viên Này.";
            this.ckKhongDung.UseVisualStyleBackColor = true;
            this.ckKhongDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Họ Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ngày Sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Giới Tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "CMND:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ngày Cấp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nơi Cấp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 294);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "ĐTDĐ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 327);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 82);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Thuộc Bộ Phận:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Số Thẻ:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(444, 155);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "MST:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(422, 191);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 18);
            this.label12.TabIndex = 26;
            this.label12.Text = "Ghi Chú:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 18);
            this.label13.TabIndex = 27;
            this.label13.Text = "Mã NV:";
            // 
            // dtpkNgayCap
            // 
            this.dtpkNgayCap.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayCap.Location = new System.Drawing.Point(112, 222);
            this.dtpkNgayCap.Name = "dtpkNgayCap";
            this.dtpkNgayCap.Size = new System.Drawing.Size(222, 24);
            this.dtpkNgayCap.TabIndex = 5;
            this.dtpkNgayCap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // dtpkNgaySinh
            // 
            this.dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgaySinh.Location = new System.Drawing.Point(112, 115);
            this.dtpkNgaySinh.Name = "dtpkNgaySinh";
            this.dtpkNgaySinh.Size = new System.Drawing.Size(222, 24);
            this.dtpkNgaySinh.TabIndex = 2;
            this.dtpkNgaySinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(385, 292);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 18);
            this.label14.TabIndex = 32;
            this.label14.Text = "Mã  định danh:";
            // 
            // txtMaDinhDanh
            // 
            this.txtMaDinhDanh.Location = new System.Drawing.Point(496, 289);
            this.txtMaDinhDanh.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaDinhDanh.Name = "txtMaDinhDanh";
            this.txtMaDinhDanh.Size = new System.Drawing.Size(218, 24);
            this.txtMaDinhDanh.TabIndex = 12;
            this.txtMaDinhDanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNV_KeyDown);
            this.txtMaDinhDanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDinhDanh_KeyPress);
            this.txtMaDinhDanh.Leave += new System.EventHandler(this.txtMaDinhDanh_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(336, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 33;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(678, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 18);
            this.label16.TabIndex = 34;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(223, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 18);
            this.label17.TabIndex = 35;
            this.label17.Text = "*";
            // 
            // lblEmailTB
            // 
            this.lblEmailTB.AutoSize = true;
            this.lblEmailTB.ForeColor = System.Drawing.Color.Red;
            this.lblEmailTB.Location = new System.Drawing.Point(116, 350);
            this.lblEmailTB.Name = "lblEmailTB";
            this.lblEmailTB.Size = new System.Drawing.Size(0, 18);
            this.lblEmailTB.TabIndex = 40;
            // 
            // btnThemNhanhNoiCap
            // 
            this.btnThemNhanhNoiCap.Image = global::ECOPharma2013.Properties.Resources.add2;
            this.btnThemNhanhNoiCap.Location = new System.Drawing.Point(310, 260);
            this.btnThemNhanhNoiCap.Name = "btnThemNhanhNoiCap";
            this.btnThemNhanhNoiCap.Size = new System.Drawing.Size(24, 25);
            this.btnThemNhanhNoiCap.TabIndex = 46;
            this.btnThemNhanhNoiCap.UseVisualStyleBackColor = true;
            this.btnThemNhanhNoiCap.Click += new System.EventHandler(this.btnThemNhanhNoiCap_Click);
            // 
            // btnThemBoPhan
            // 
            this.btnThemBoPhan.Image = global::ECOPharma2013.Properties.Resources.add2;
            this.btnThemBoPhan.Location = new System.Drawing.Point(690, 79);
            this.btnThemBoPhan.Name = "btnThemBoPhan";
            this.btnThemBoPhan.Size = new System.Drawing.Size(24, 25);
            this.btnThemBoPhan.TabIndex = 47;
            this.btnThemBoPhan.UseVisualStyleBackColor = true;
            this.btnThemBoPhan.Click += new System.EventHandler(this.btnThemBoPhan_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(113, 45);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(222, 24);
            this.txtMaNV.TabIndex = 48;
            this.txtMaNV.Leave += new System.EventHandler(this.txtMaNV_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(337, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 18);
            this.label18.TabIndex = 49;
            this.label18.Text = "*";
            // 
            // frmNhanVienEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 409);
            this.ControlBox = false;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.btnThemBoPhan);
            this.Controls.Add(this.btnThemNhanhNoiCap);
            this.Controls.Add(this.lblEmailTB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMaDinhDanh);
            this.Controls.Add(this.dtpkNgaySinh);
            this.Controls.Add(this.dtpkNgayCap);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.txtMST);
            this.Controls.Add(this.txtSoThe);
            this.Controls.Add(this.cboBoPhan);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDTDD);
            this.Controls.Add(this.cboNoiCap);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhanVienEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVienEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhanVienEdit_KeyDown);
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
        private System.Windows.Forms.ToolStripButton btnNVThemMoi;
        private System.Windows.Forms.ToolStripButton btnNVLuu;
        private System.Windows.Forms.ToolStripButton btnNVDong;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.ComboBox cboNoiCap;
        private System.Windows.Forms.TextBox txtDTDD;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboBoPhan;
        private System.Windows.Forms.TextBox txtSoThe;
        private System.Windows.Forms.TextBox txtMST;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpkNgayCap;
        private System.Windows.Forms.DateTimePicker dtpkNgaySinh;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMaDinhDanh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblEmailTB;
        private System.Windows.Forms.Button btnThemNhanhNoiCap;
        private System.Windows.Forms.Button btnThemBoPhan;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label18;
    }
}