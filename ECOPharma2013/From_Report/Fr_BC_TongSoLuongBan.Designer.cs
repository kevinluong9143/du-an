namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_TongSoLuongBan
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvTongSLBan = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtTuNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnDong = new System.Windows.Forms.Button();
            this.dtDenNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.btnExportToExcel = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTongSLBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTongSLBan.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rgvTongSLBan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.070707F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.92929F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1169, 587);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rgvTongSLBan
            // 
            this.rgvTongSLBan.BackColor = System.Drawing.SystemColors.Control;
            this.rgvTongSLBan.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvTongSLBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvTongSLBan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvTongSLBan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvTongSLBan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvTongSLBan.Location = new System.Drawing.Point(3, 44);
            // 
            // rgvTongSLBan
            // 
            this.rgvTongSLBan.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "STT";
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "colSTT";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.FieldName = "MaSP";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Mã SP";
            gridViewTextBoxColumn2.Name = "colMaSP";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.FieldName = "TenSP";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Tên Sản Phẩm";
            gridViewTextBoxColumn3.Name = "colTenSP";
            gridViewTextBoxColumn3.Width = 350;
            gridViewTextBoxColumn4.FieldName = "TenDVT";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "ĐVT";
            gridViewTextBoxColumn4.Name = "colTenDVT";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 70;
            gridViewTextBoxColumn5.FieldName = "SLXuat";
            gridViewTextBoxColumn5.FormatString = "{0:N0}";
            gridViewTextBoxColumn5.HeaderText = "Số Lượng Xuất";
            gridViewTextBoxColumn5.Name = "colSLXuat";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn6.FieldName = "SLTonHT";
            gridViewTextBoxColumn6.FormatString = "{0:N0}";
            gridViewTextBoxColumn6.HeaderText = "SL Tồn Hiện Tại";
            gridViewTextBoxColumn6.Name = "colSLTonHT";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 150;
            this.rgvTongSLBan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvTongSLBan.MasterTemplate.EnableFiltering = true;
            this.rgvTongSLBan.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvTongSLBan.Name = "rgvTongSLBan";
            this.rgvTongSLBan.ReadOnly = true;
            this.rgvTongSLBan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvTongSLBan.ShowGroupPanel = false;
            this.rgvTongSLBan.Size = new System.Drawing.Size(1163, 540);
            this.rgvTongSLBan.TabIndex = 3;
            this.rgvTongSLBan.Text = "radGridView1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTuNgay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDong, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtDenNgay, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.radLabel2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportToExcel, 9, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1163, 35);
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
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(805, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(98, 29);
            this.btnDong.TabIndex = 36;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(392, 3);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Size = new System.Drawing.Size(148, 27);
            this.dtDenNgay.TabIndex = 24;
            this.dtDenNgay.TabStop = false;
            this.dtDenNgay.Text = "radDateTimePicker2";
            this.dtDenNgay.Value = new System.DateTime(2013, 5, 7, 22, 2, 37, 57);
            this.dtDenNgay.ValueChanged += new System.EventHandler(this.dtDenNgay_ValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(287, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 25);
            this.radLabel2.TabIndex = 28;
            this.radLabel2.Text = "Đến Ngày";
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXem.Location = new System.Drawing.Point(556, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 29);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToExcel.Location = new System.Drawing.Point(677, 3);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(105, 29);
            this.btnExportToExcel.TabIndex = 33;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // Fr_BC_TongSoLuongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fr_BC_TongSoLuongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tổng Số Lượng Bán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_BC_TongSoLuongBan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvTongSLBan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTongSLBan)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
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
        private Telerik.WinControls.UI.RadGridView rgvTongSLBan;
        private System.Windows.Forms.Button btnDong;
    }
}