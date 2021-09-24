namespace ECOPharma2013
{
    partial class frmNhapKho
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSPhieuNhap = new Telerik.WinControls.UI.RadGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSPhieuNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDSPhieuNhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSPhieuNhap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSPhieuNhap.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "PNid";
            gridViewTextBoxColumn1.HeaderText = "PN id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colPNid";
            gridViewTextBoxColumn2.FieldName = "SoCTN";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Số Chứng Từ Nhập";
            gridViewTextBoxColumn2.Name = "colSoCTN";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "NgayCTN";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayCTN";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "NPPid";
            gridViewTextBoxColumn4.HeaderText = "NPP id";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colNPPid";
            gridViewTextBoxColumn5.FieldName = "TenNPP";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Nhà Phân Phối";
            gridViewTextBoxColumn5.Name = "colTenNPP";
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "XuatChoNT";
            gridViewTextBoxColumn6.HeaderText = "NT id";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colXuatChoNT";
            gridViewTextBoxColumn7.FieldName = "TenNT";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Xuất Tới Nhà Thuốc";
            gridViewTextBoxColumn7.Name = "colTenNT";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "TongTien";
            gridViewTextBoxColumn8.FormatString = "{0:N2}";
            gridViewTextBoxColumn8.HeaderText = "Tổng tiền";
            gridViewTextBoxColumn8.Name = "colTongTien";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.FieldName = "TongTienChuaVAT";
            gridViewTextBoxColumn9.FormatString = "{0:N2}";
            gridViewTextBoxColumn9.HeaderText = "Tổng tiền Chưa VAT";
            gridViewTextBoxColumn9.Name = "colTongTienChuaVAT";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "Direct";
            gridViewTextBoxColumn10.HeaderText = "Phiếu Nhập Direct";
            gridViewTextBoxColumn10.Name = "colDirect";
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.FieldName = "NhapXong";
            gridViewTextBoxColumn11.HeaderText = "Đã Nhập Xong";
            gridViewTextBoxColumn11.Name = "colNhapXong";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "XNPhieuNhap";
            gridViewTextBoxColumn12.HeaderText = "Đã Xác Nhận";
            gridViewTextBoxColumn12.Name = "colXNPhieuNhap";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "GhiChu";
            gridViewTextBoxColumn13.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn13.Name = "colGhiChu";
            gridViewTextBoxColumn13.Width = 150;
            gridViewTextBoxColumn14.FieldName = "NgayTao";
            gridViewTextBoxColumn14.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn14.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn14.Name = "colNgayTao";
            gridViewTextBoxColumn14.Width = 150;
            gridViewTextBoxColumn15.FieldName = "LastUD";
            gridViewTextBoxColumn15.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn15.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn15.Name = "colLastUD";
            gridViewTextBoxColumn15.Width = 150;
            gridViewTextBoxColumn16.FieldName = "NgayXacNhan";
            gridViewTextBoxColumn16.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn16.HeaderText = "Ngày Nhập Kho";
            gridViewTextBoxColumn16.Name = "colNgayXacNhan";
            gridViewTextBoxColumn16.Width = 150;
            gridViewTextBoxColumn17.FieldName = "UserNhap";
            gridViewTextBoxColumn17.HeaderText = "NV Nhập id";
            gridViewTextBoxColumn17.IsVisible = false;
            gridViewTextBoxColumn17.Name = "colUserNhap";
            gridViewTextBoxColumn18.FieldName = "TenNVNhap";
            gridViewTextBoxColumn18.HeaderText = "Nhân Viên Nhập";
            gridViewTextBoxColumn18.Name = "colTenNVNhap";
            gridViewTextBoxColumn18.Width = 150;
            gridViewTextBoxColumn19.FieldName = "UserXN";
            gridViewTextBoxColumn19.HeaderText = "NV XN id";
            gridViewTextBoxColumn19.IsVisible = false;
            gridViewTextBoxColumn19.Name = "colUserXN";
            gridViewTextBoxColumn20.FieldName = "TenNVXacNhan";
            gridViewTextBoxColumn20.HeaderText = "Nhân Viên Xác Nhận";
            gridViewTextBoxColumn20.Name = "colTenNVXacNhan";
            gridViewTextBoxColumn20.Width = 150;
            this.rgvDSPhieuNhap.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20});
            this.rgvDSPhieuNhap.MasterTemplate.EnableFiltering = true;
            this.rgvDSPhieuNhap.Name = "rgvDSPhieuNhap";
            this.rgvDSPhieuNhap.ReadOnly = true;
            this.rgvDSPhieuNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSPhieuNhap.ShowGroupPanel = false;
            this.rgvDSPhieuNhap.Size = new System.Drawing.Size(757, 328);
            this.rgvDSPhieuNhap.TabIndex = 0;
            this.rgvDSPhieuNhap.Text = "radGridView1";
            this.rgvDSPhieuNhap.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSPhieuNhap_CellDoubleClick);
            this.rgvDSPhieuNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvDSPhieuNhap_KeyDown);
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 328);
            this.Controls.Add(this.rgvDSPhieuNhap);
            this.Name = "frmNhapKho";
            this.Text = "frmNhapKho";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSPhieuNhap;
        private System.Drawing.Printing.PrintDocument printDocument1;

    }
}