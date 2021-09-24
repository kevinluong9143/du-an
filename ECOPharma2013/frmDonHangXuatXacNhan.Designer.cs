namespace ECOPharma2013
{
    partial class frmDonHangXuatXacNhan
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSDonHang = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDonHang.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSDonHang
            // 
            this.rgvDSDonHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSDonHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSDonHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSDonHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSDonHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSDonHang.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSDonHang
            // 
            this.rgvDSDonHang.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewTextBoxColumn1.FieldName = "DHid";
            gridViewTextBoxColumn1.HeaderText = "DH id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.FieldName = "SoDHChung";
            gridViewTextBoxColumn2.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn2.Name = "colSoDHChung";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "NoiDH";
            gridViewTextBoxColumn3.HeaderText = "Noi DH id";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colNoiDH";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn4.FieldName = "TenNT_NoiDatHang";
            gridViewTextBoxColumn4.HeaderText = "Nơi Đặt Hàng";
            gridViewTextBoxColumn4.Name = "colTenNT_NoiDatHang";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "XuatChoNT";
            gridViewTextBoxColumn5.HeaderText = "NhaThuoc id";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colXuatChoNT";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn6.FieldName = "TenNT";
            gridViewTextBoxColumn6.HeaderText = "Xuất Cho Nhà Thuốc";
            gridViewTextBoxColumn6.Name = "colTenNT";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "DonKhan";
            gridViewTextBoxColumn7.HeaderText = "Đơn Khẩn";
            gridViewTextBoxColumn7.Name = "colDonKhan";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn8.FieldName = "IsXuatCoChiDinh";
            gridViewTextBoxColumn8.HeaderText = "Xuất Có Chỉ Định";
            gridViewTextBoxColumn8.Name = "IsXuatCoChiDinh";
            gridViewTextBoxColumn8.Width = 120;
            gridViewTextBoxColumn9.FieldName = "DuyetDH";
            gridViewTextBoxColumn9.FormatString = "";
            gridViewTextBoxColumn9.HeaderText = "Đã Duyệt Đơn Hàng";
            gridViewTextBoxColumn9.Name = "colDuyetDH";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "NgayDuyetDH";
            gridViewTextBoxColumn10.HeaderText = "Ngày Duyệt Đơn Hàng";
            gridViewTextBoxColumn10.Name = "colNgayDuyetDH";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.FieldName = "GhiChu";
            gridViewTextBoxColumn11.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn11.Name = "colGhiChu";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 100;
            gridViewTextBoxColumn12.FieldName = "LastUD";
            gridViewTextBoxColumn12.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn12.Name = "colLastUD";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "NgayTao";
            gridViewTextBoxColumn13.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn13.Name = "colNgayTao";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.FieldName = "UserNhap";
            gridViewTextBoxColumn14.HeaderText = "Usernhap id";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "colUserNhap";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn15.FieldName = "NVNhap";
            gridViewTextBoxColumn15.HeaderText = "Nhân Viên Nhập";
            gridViewTextBoxColumn15.Name = "colTenNVNhap";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn16.FieldName = "UserDuyet";
            gridViewTextBoxColumn16.HeaderText = "USerDuyet id";
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "colUserDuyet";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn17.FieldName = "NVDuyet";
            gridViewTextBoxColumn17.HeaderText = "Nhân Viên Duyệt";
            gridViewTextBoxColumn17.Name = "colTenNVDuyet";
            gridViewTextBoxColumn17.ReadOnly = true;
            gridViewTextBoxColumn17.Width = 100;
            this.rgvDSDonHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17});
            this.rgvDSDonHang.MasterTemplate.EnableFiltering = true;
            this.rgvDSDonHang.Name = "rgvDSDonHang";
            this.rgvDSDonHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSDonHang.ShowGroupPanel = false;
            this.rgvDSDonHang.Size = new System.Drawing.Size(746, 345);
            this.rgvDSDonHang.TabIndex = 0;
            this.rgvDSDonHang.Text = "radGridView1";
            // 
            // frmDonHangXuatXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 345);
            this.Controls.Add(this.rgvDSDonHang);
            this.Name = "frmDonHangXuatXacNhan";
            this.Text = "frmDonHangXuatXacNhan";
            this.Load += new System.EventHandler(this.frmDonHangXuatXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDonHang.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvDSDonHang;
    }
}