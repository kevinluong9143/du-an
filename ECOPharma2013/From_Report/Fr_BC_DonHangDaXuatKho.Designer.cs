namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_DonHangDaXuatKho
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvDSPhieuXK = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtTuNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnDong = new System.Windows.Forms.Button();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dtDenNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.btnExportToExcel = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuXK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuXK.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rgvDSPhieuXK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1097, 587);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rgvDSPhieuXK
            // 
            this.rgvDSPhieuXK.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSPhieuXK.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSPhieuXK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSPhieuXK.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDSPhieuXK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSPhieuXK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSPhieuXK.Location = new System.Drawing.Point(3, 44);
            // 
            // rgvDSPhieuXK
            // 
            this.rgvDSPhieuXK.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "STT";
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "colSTT";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.FieldName = "SoPX";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Xuất";
            gridViewTextBoxColumn2.Name = "colSoPX";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "SoDH";
            gridViewTextBoxColumn3.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn3.Name = "colSoDH";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "TenNT";
            gridViewTextBoxColumn4.HeaderText = "Nhà Thuốc";
            gridViewTextBoxColumn4.Name = "colTenNT";
            gridViewTextBoxColumn4.Width = 250;
            gridViewTextBoxColumn5.FieldName = "RowNumber";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Số Dòng";
            gridViewTextBoxColumn5.Name = "colRowNumber";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.FieldName = "DonKhan";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Đơn Khẩn";
            gridViewTextBoxColumn6.Name = "colDonKhan";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.FieldName = "Direct";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Hàng Direct";
            gridViewTextBoxColumn7.Name = "colDirect";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "NgayTao";
            gridViewTextBoxColumn8.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn8.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn8.Name = "colNgayTao";
            gridViewTextBoxColumn8.Width = 180;
            gridViewTextBoxColumn9.FieldName = "NgayKiemTra";
            gridViewTextBoxColumn9.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn9.HeaderText = "Ngày Thực Xuất";
            gridViewTextBoxColumn9.Name = "colNgayKiemTra";
            gridViewTextBoxColumn9.Width = 180;
            this.rgvDSPhieuXK.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvDSPhieuXK.MasterTemplate.EnableFiltering = true;
            this.rgvDSPhieuXK.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvDSPhieuXK.Name = "rgvDSPhieuXK";
            this.rgvDSPhieuXK.ReadOnly = true;
            this.rgvDSPhieuXK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSPhieuXK.ShowGroupPanel = false;
            this.rgvDSPhieuXK.Size = new System.Drawing.Size(1091, 540);
            this.rgvDSPhieuXK.TabIndex = 3;
            this.rgvDSPhieuXK.Text = "radGridView1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTuNgay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDong, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.radLabel2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtDenNgay, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportToExcel, 7, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1091, 35);
            this.tableLayoutPanel2.TabIndex = 1;
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
            // btnDong
            // 
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(779, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 26);
            this.btnDong.TabIndex = 36;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(287, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 25);
            this.radLabel2.TabIndex = 28;
            this.radLabel2.Text = "Đến Ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(374, 3);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Size = new System.Drawing.Size(144, 27);
            this.dtDenNgay.TabIndex = 24;
            this.dtDenNgay.TabStop = false;
            this.dtDenNgay.Text = "radDateTimePicker2";
            this.dtDenNgay.Value = new System.DateTime(2013, 5, 7, 22, 2, 37, 57);
            this.dtDenNgay.ValueChanged += new System.EventHandler(this.dtDenNgay_ValueChanged);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(658, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(97, 26);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(540, 3);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(95, 26);
            this.btnExportToExcel.TabIndex = 33;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // Fr_BC_DonHangDaXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fr_BC_DonHangDaXuatKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Đơn Hàng Đã Xuất Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_BC_DonHangDaXuatKho_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuXK.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuXK)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).EndInit();
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
        private Telerik.WinControls.UI.RadDateTimePicker dtTuNgay;
        private Telerik.WinControls.UI.RadButton btnXem;
        private Telerik.WinControls.UI.RadButton btnExportToExcel;
        private System.Windows.Forms.Button btnDong;
        private Telerik.WinControls.UI.RadGridView rgvDSPhieuXK;
    }
}