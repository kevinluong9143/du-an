namespace ECOPharma2013
{
    partial class frmCauHinhHeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinhHeThong));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveKhoDacBiet = new System.Windows.Forms.Button();
            this.cbxKhoDacBiet = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChuKy = new System.Windows.Forms.TextBox();
            this.txtMucTon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBoPhan = new System.Windows.Forms.ComboBox();
            this.txtTienQuy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenChiNhanh = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cboTenChiNhanh = new System.Windows.Forms.ComboBox();
            this.txtMaChiNhanh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnLuu = new System.Windows.Forms.ToolStripButton();
            this.cbIsDonTraHang = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 510);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbIsDonTraHang);
            this.groupBox3.Controls.Add(this.btnSaveKhoDacBiet);
            this.groupBox3.Controls.Add(this.cbxKhoDacBiet);
            this.groupBox3.Location = new System.Drawing.Point(489, 261);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(399, 134);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình xem kho đặc biệt";
            // 
            // btnSaveKhoDacBiet
            // 
            this.btnSaveKhoDacBiet.Location = new System.Drawing.Point(16, 59);
            this.btnSaveKhoDacBiet.Name = "btnSaveKhoDacBiet";
            this.btnSaveKhoDacBiet.Size = new System.Drawing.Size(179, 34);
            this.btnSaveKhoDacBiet.TabIndex = 1;
            this.btnSaveKhoDacBiet.Text = "Lưu";
            this.btnSaveKhoDacBiet.UseVisualStyleBackColor = true;
            this.btnSaveKhoDacBiet.Click += new System.EventHandler(this.btnSaveKhoDacBiet_Click);
            // 
            // cbxKhoDacBiet
            // 
            this.cbxKhoDacBiet.AutoSize = true;
            this.cbxKhoDacBiet.Location = new System.Drawing.Point(20, 31);
            this.cbxKhoDacBiet.Name = "cbxKhoDacBiet";
            this.cbxKhoDacBiet.Size = new System.Drawing.Size(142, 22);
            this.cbxKhoDacBiet.TabIndex = 0;
            this.cbxKhoDacBiet.Text = "Xem kho đặc biệt";
            this.cbxKhoDacBiet.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTestConn);
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtServerName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(489, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(399, 212);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin kết nối về tổng công ty";
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(122, 158);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(257, 38);
            this.btnTestConn.TabIndex = 8;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(122, 128);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(257, 24);
            this.txtData.TabIndex = 7;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(122, 97);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(257, 24);
            this.txtPass.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(122, 66);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(257, 24);
            this.txtUserName.TabIndex = 5;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(122, 35);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(257, 24);
            this.txtServerName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 131);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Database:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Server Name:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(976, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtChuKy);
            this.groupBox1.Controls.Add(this.txtMucTon);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboBoPhan);
            this.groupBox1.Controls.Add(this.txtTienQuy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenChiNhanh);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.cboTenChiNhanh);
            this.groupBox1.Controls.Add(this.txtMaChiNhanh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(467, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Chi Nhánh";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(269, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "tuần";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 15;
            this.label12.Text = "tuần";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "Chu Kỳ Đặt Hàng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 18);
            this.label10.TabIndex = 13;
            this.label10.Text = "Mức Tồn Kho:";
            // 
            // txtChuKy
            // 
            this.txtChuKy.Location = new System.Drawing.Point(163, 245);
            this.txtChuKy.MaxLength = 2;
            this.txtChuKy.Name = "txtChuKy";
            this.txtChuKy.Size = new System.Drawing.Size(100, 24);
            this.txtChuKy.TabIndex = 12;
            // 
            // txtMucTon
            // 
            this.txtMucTon.Location = new System.Drawing.Point(163, 215);
            this.txtMucTon.MaxLength = 2;
            this.txtMucTon.Name = "txtMucTon";
            this.txtMucTon.Size = new System.Drawing.Size(100, 24);
            this.txtMucTon.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bộ Phận:";
            // 
            // cboBoPhan
            // 
            this.cboBoPhan.FormattingEnabled = true;
            this.cboBoPhan.Location = new System.Drawing.Point(163, 120);
            this.cboBoPhan.Margin = new System.Windows.Forms.Padding(4);
            this.cboBoPhan.Name = "cboBoPhan";
            this.cboBoPhan.Size = new System.Drawing.Size(288, 26);
            this.cboBoPhan.TabIndex = 9;
            // 
            // txtTienQuy
            // 
            this.txtTienQuy.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienQuy.Location = new System.Drawing.Point(163, 154);
            this.txtTienQuy.Margin = new System.Windows.Forms.Padding(4);
            this.txtTienQuy.Multiline = true;
            this.txtTienQuy.Name = "txtTienQuy";
            this.txtTienQuy.Size = new System.Drawing.Size(288, 54);
            this.txtTienQuy.TabIndex = 8;
            this.txtTienQuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienQuy.TextChanged += new System.EventHandler(this.txtTienQuy_TextChanged);
            this.txtTienQuy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienQuy_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tiền Quỹ Thu Ngân:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chọn Chi Nhánh:";
            // 
            // txtTenChiNhanh
            // 
            this.txtTenChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChiNhanh.Location = new System.Drawing.Point(163, 92);
            this.txtTenChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenChiNhanh.Name = "txtTenChiNhanh";
            this.txtTenChiNhanh.Size = new System.Drawing.Size(288, 22);
            this.txtTenChiNhanh.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(163, 283);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(171, 42);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cboTenChiNhanh
            // 
            this.cboTenChiNhanh.FormattingEnabled = true;
            this.cboTenChiNhanh.Location = new System.Drawing.Point(163, 35);
            this.cboTenChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.cboTenChiNhanh.Name = "cboTenChiNhanh";
            this.cboTenChiNhanh.Size = new System.Drawing.Size(288, 26);
            this.cboTenChiNhanh.TabIndex = 3;
            this.cboTenChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cboTenChiNhanh_SelectedIndexChanged);
            // 
            // txtMaChiNhanh
            // 
            this.txtMaChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChiNhanh.Location = new System.Drawing.Point(163, 64);
            this.txtMaChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaChiNhanh.Name = "txtMaChiNhanh";
            this.txtMaChiNhanh.Size = new System.Drawing.Size(288, 22);
            this.txtMaChiNhanh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Chi Nhánh:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Chi Nhánh:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnLuu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(976, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnLuu
            // 
            this.tbtnLuu.Image = ((System.Drawing.Image)(resources.GetObject("tbtnLuu.Image")));
            this.tbtnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnLuu.Name = "tbtnLuu";
            this.tbtnLuu.Size = new System.Drawing.Size(47, 22);
            this.tbtnLuu.Text = "Lưu";
            this.tbtnLuu.Click += new System.EventHandler(this.tbtnLuu_Click);
            // 
            // cbIsDonTraHang
            // 
            this.cbIsDonTraHang.AutoSize = true;
            this.cbIsDonTraHang.Location = new System.Drawing.Point(200, 31);
            this.cbIsDonTraHang.Name = "cbIsDonTraHang";
            this.cbIsDonTraHang.Size = new System.Drawing.Size(112, 22);
            this.cbIsDonTraHang.TabIndex = 2;
            this.cbIsDonTraHang.Text = "Đơn trả hàng";
            this.cbIsDonTraHang.UseVisualStyleBackColor = true;
            // 
            // frmCauHinhHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 510);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCauHinhHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.frmCauHinhHeThong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaChiNhanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTenChiNhanh;
        private System.Windows.Forms.TextBox txtTenChiNhanh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTienQuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBoPhan;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnLuu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChuKy;
        private System.Windows.Forms.TextBox txtMucTon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveKhoDacBiet;
        private System.Windows.Forms.CheckBox cbxKhoDacBiet;
        private System.Windows.Forms.CheckBox cbIsDonTraHang;
    }
}