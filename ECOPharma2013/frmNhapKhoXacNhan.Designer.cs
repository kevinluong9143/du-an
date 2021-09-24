namespace ECOPharma2013
{
    partial class frmNhapKhoXacNhan
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
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
            this.rgvDSPhieuNhapXacNhan = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhapXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhapXacNhan.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSPhieuNhapXacNhan
            // 
            this.rgvDSPhieuNhapXacNhan.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSPhieuNhapXacNhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSPhieuNhapXacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSPhieuNhapXacNhan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSPhieuNhapXacNhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSPhieuNhapXacNhan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSPhieuNhapXacNhan.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSPhieuNhapXacNhan
            // 
            this.rgvDSPhieuNhapXacNhan.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.FieldName = "XNPhieuNhap";
            gridViewCheckBoxColumn1.FormatString = "";
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colXNPhieuNhap";
            gridViewTextBoxColumn1.FieldName = "PNid";
            gridViewTextBoxColumn1.HeaderText = "PN id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colPNid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.FieldName = "SoCTN";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Số Chứng Từ Nhập";
            gridViewTextBoxColumn2.Name = "colSoCTN";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 140;
            gridViewTextBoxColumn3.FieldName = "NgayCTN";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayCTN";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 140;
            gridViewTextBoxColumn4.FieldName = "NPPid";
            gridViewTextBoxColumn4.HeaderText = "NPP id";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colNPPid";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn5.FieldName = "TenNPP";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Nhà Phân Phối";
            gridViewTextBoxColumn5.Name = "colTenNPP";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 140;
            gridViewTextBoxColumn6.FieldName = "XuatChoNT";
            gridViewTextBoxColumn6.HeaderText = "NhaThuoc id";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colXuatChoNT";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn7.FieldName = "TenNT";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Xuất Tới Nhà Thuốc";
            gridViewTextBoxColumn7.Name = "colTenNT";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "TongTien";
            gridViewTextBoxColumn8.FormatString = "{0:N2}";
            gridViewTextBoxColumn8.HeaderText = "Tổng tiền";
            gridViewTextBoxColumn8.Name = "ColTongTien";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.FieldName = "TongTienChuaVAT";
            gridViewTextBoxColumn9.FormatString = "{0:N2}";
            gridViewTextBoxColumn9.HeaderText = "Tổng tiền chưa VAT";
            gridViewTextBoxColumn9.Name = "colTongTienChuaVAT";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "Direct";
            gridViewTextBoxColumn10.FormatString = "";
            gridViewTextBoxColumn10.HeaderText = "Direct";
            gridViewTextBoxColumn10.Name = "colDirect";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 70;
            gridViewTextBoxColumn11.FieldName = "NhapXong";
            gridViewTextBoxColumn11.FormatString = "";
            gridViewTextBoxColumn11.HeaderText = "Đã Nhập Xong";
            gridViewTextBoxColumn11.Name = "colNhapXong";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 110;
            gridViewTextBoxColumn12.FieldName = "GhiChu";
            gridViewTextBoxColumn12.FormatString = "";
            gridViewTextBoxColumn12.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn12.Name = "colGhiChu";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 70;
            gridViewTextBoxColumn13.FieldName = "LastUD";
            gridViewTextBoxColumn13.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn13.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn13.Name = "colLastUD";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.FieldName = "NgayTao";
            gridViewTextBoxColumn14.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn14.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn14.Name = "colNgayTao";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.FieldName = "UserNhap";
            gridViewTextBoxColumn15.HeaderText = "NV Nhap id";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "colUserNhap";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn16.FieldName = "TenNVNhap";
            gridViewTextBoxColumn16.HeaderText = "Nhân Viên Nhập";
            gridViewTextBoxColumn16.Name = "colTenNVNhap";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 100;
            this.rgvDSPhieuNhapXacNhan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
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
            gridViewTextBoxColumn16});
            this.rgvDSPhieuNhapXacNhan.MasterTemplate.EnableFiltering = true;
            this.rgvDSPhieuNhapXacNhan.Name = "rgvDSPhieuNhapXacNhan";
            this.rgvDSPhieuNhapXacNhan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSPhieuNhapXacNhan.ShowGroupPanel = false;
            this.rgvDSPhieuNhapXacNhan.Size = new System.Drawing.Size(874, 397);
            this.rgvDSPhieuNhapXacNhan.TabIndex = 0;
            this.rgvDSPhieuNhapXacNhan.Text = "radGridView1";
            // 
            // frmNhapKhoXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 397);
            this.Controls.Add(this.rgvDSPhieuNhapXacNhan);
            this.Name = "frmNhapKhoXacNhan";
            this.Text = "frmNhapKhoXacNhan";
            this.Load += new System.EventHandler(this.frmNhapKhoXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhapXacNhan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhapXacNhan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSPhieuNhapXacNhan;

    }
}