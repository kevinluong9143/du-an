namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_LuotKhachHang
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvLuotKhachHang = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtDenNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.RbtNT = new Telerik.WinControls.UI.RadRadioButton();
            this.dtTuNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboNhaThuoc = new Telerik.WinControls.UI.RadDropDownList();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.btnExportToExcel = new Telerik.WinControls.UI.RadButton();
            this.btnDong = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLuotKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLuotKhachHang.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbtNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rgvLuotKhachHang, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1169, 587);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rgvLuotKhachHang
            // 
            this.rgvLuotKhachHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvLuotKhachHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvLuotKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvLuotKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvLuotKhachHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvLuotKhachHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvLuotKhachHang.Location = new System.Drawing.Point(3, 73);
            // 
            // rgvLuotKhachHang
            // 
            this.rgvLuotKhachHang.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "TenNT";
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "Tên Nhà Thuốc";
            gridViewTextBoxColumn1.Name = "colTenNT";
            gridViewTextBoxColumn1.Width = 250;
            gridViewTextBoxColumn2.FieldName = "NgayThanhToan";
            gridViewTextBoxColumn2.FormatString = "{0:dd/MM/yyyy}";
            gridViewTextBoxColumn2.HeaderText = "Ngày Thanh Toán";
            gridViewTextBoxColumn2.Name = "colNgayThanhToan";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.FieldName = "Tu";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Từ Giờ";
            gridViewTextBoxColumn3.Name = "colTu";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "Den";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Đến Giờ";
            gridViewTextBoxColumn4.Name = "colDen";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "Quality";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Số Lượt Khách";
            gridViewTextBoxColumn5.Name = "colQuality";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 100;
            this.rgvLuotKhachHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvLuotKhachHang.MasterTemplate.EnableFiltering = true;
            this.rgvLuotKhachHang.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvLuotKhachHang.Name = "rgvLuotKhachHang";
            this.rgvLuotKhachHang.ReadOnly = true;
            this.rgvLuotKhachHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvLuotKhachHang.ShowGroupPanel = false;
            this.rgvLuotKhachHang.Size = new System.Drawing.Size(1163, 511);
            this.rgvLuotKhachHang.TabIndex = 3;
            this.rgvLuotKhachHang.Text = "radGridView1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtDenNgay, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.RbtNT, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTuNgay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboNhaThuoc, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnExportToExcel, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDong, 9, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1091, 64);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(43, 35);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 25);
            this.radLabel2.TabIndex = 28;
            this.radLabel2.Text = "Đến Ngày";
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(43, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(69, 25);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Từ Ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(126, 35);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Size = new System.Drawing.Size(141, 27);
            this.dtDenNgay.TabIndex = 24;
            this.dtDenNgay.TabStop = false;
            this.dtDenNgay.Text = "radDateTimePicker2";
            this.dtDenNgay.Value = new System.DateTime(2013, 5, 7, 22, 2, 37, 57);
            this.dtDenNgay.ValueChanged += new System.EventHandler(this.dtDenNgay_ValueChanged);
            // 
            // RbtNT
            // 
            this.RbtNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RbtNT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbtNT.Location = new System.Drawing.Point(287, 3);
            this.RbtNT.Name = "RbtNT";
            this.RbtNT.Size = new System.Drawing.Size(99, 26);
            this.RbtNT.TabIndex = 26;
            this.RbtNT.Text = "Nhà Thuốc";
            this.RbtNT.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.RbtNT.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.RbtNT_ToggleStateChanged);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(126, 3);
            this.dtTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Size = new System.Drawing.Size(141, 27);
            this.dtTuNgay.TabIndex = 21;
            this.dtTuNgay.TabStop = false;
            this.dtTuNgay.Text = "radDateTimePicker1";
            this.dtTuNgay.Value = new System.DateTime(2013, 5, 7, 22, 0, 36, 625);
            // 
            // cboNhaThuoc
            // 
            this.cboNhaThuoc.DefaultItemsCountInDropDown = 10;
            this.cboNhaThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhaThuoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaThuoc.Location = new System.Drawing.Point(392, 3);
            this.cboNhaThuoc.Name = "cboNhaThuoc";
            this.cboNhaThuoc.ShowImageInEditorArea = true;
            this.cboNhaThuoc.Size = new System.Drawing.Size(311, 27);
            this.cboNhaThuoc.TabIndex = 29;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(724, 35);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(95, 26);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(724, 3);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(95, 26);
            this.btnExportToExcel.TabIndex = 33;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnDong
            // 
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(845, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(82, 26);
            this.btnDong.TabIndex = 36;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Fr_BC_LuotKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fr_BC_LuotKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Lượt Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_BC_LuotKhachHang_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvLuotKhachHang.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLuotKhachHang)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbtNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dtDenNgay;
        private Telerik.WinControls.UI.RadRadioButton RbtNT;
        private Telerik.WinControls.UI.RadDateTimePicker dtTuNgay;
        private Telerik.WinControls.UI.RadDropDownList cboNhaThuoc;
        private Telerik.WinControls.UI.RadButton btnXem;
        private Telerik.WinControls.UI.RadButton btnExportToExcel;
        private System.Windows.Forms.Button btnDong;
        private Telerik.WinControls.UI.RadGridView rgvLuotKhachHang;
    }
}