namespace ECOPharma2013
{
    partial class frmNhanChuyenHang
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
            this.rgvNhanChuyenHang = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhanChuyenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhanChuyenHang.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvNhanChuyenHang
            // 
            this.rgvNhanChuyenHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvNhanChuyenHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvNhanChuyenHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvNhanChuyenHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvNhanChuyenHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvNhanChuyenHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvNhanChuyenHang.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvNhanChuyenHang
            // 
            this.rgvNhanChuyenHang.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NCHid";
            gridViewTextBoxColumn1.HeaderText = "NCH id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNCHid";
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "SP Chuyển Hàng";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.Width = 130;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "TenNTGui";
            gridViewTextBoxColumn5.HeaderText = "Từ Nhà Thuốc";
            gridViewTextBoxColumn5.Name = "colTenNTGui";
            gridViewTextBoxColumn5.Width = 140;
            gridViewTextBoxColumn6.FieldName = "Destination";
            gridViewTextBoxColumn6.HeaderText = "Destination";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colDestination";
            gridViewTextBoxColumn7.FieldName = "TenNTNhan";
            gridViewTextBoxColumn7.HeaderText = "Tới Nhà Thuốc";
            gridViewTextBoxColumn7.Name = "colTenNTNhan";
            gridViewTextBoxColumn7.Width = 140;
            gridViewTextBoxColumn8.FieldName = "GhiChu";
            gridViewTextBoxColumn8.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn8.Name = "colGhiChu";
            gridViewTextBoxColumn8.Width = 101;
            gridViewTextBoxColumn9.FieldName = "NgayNhan";
            gridViewTextBoxColumn9.HeaderText = "Ngày Nhận";
            gridViewTextBoxColumn9.Name = "colNgayNhan";
            gridViewTextBoxColumn9.Width = 130;
            gridViewTextBoxColumn10.FieldName = "DaXetDuyet";
            gridViewTextBoxColumn10.HeaderText = "Đã Xét Duyệt";
            gridViewTextBoxColumn10.Name = "colDaXetDuyet";
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn11.FieldName = "NgayXetDuyet";
            gridViewTextBoxColumn11.HeaderText = "Ngày Xét Duyệt";
            gridViewTextBoxColumn11.Name = "colNgayXetDuyet";
            gridViewTextBoxColumn11.Width = 130;
            gridViewTextBoxColumn12.FieldName = "UserXetDuyet";
            gridViewTextBoxColumn12.HeaderText = "UserXetDuyet";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "colUserXetDuyet";
            gridViewTextBoxColumn13.FieldName = "NVXetDuyet";
            gridViewTextBoxColumn13.HeaderText = "NV Xét Duyệt";
            gridViewTextBoxColumn13.Name = "colNVXetDuyet";
            gridViewTextBoxColumn13.Width = 150;
            gridViewTextBoxColumn14.FieldName = "DaXacNhan";
            gridViewTextBoxColumn14.HeaderText = "Đã Xác Nhận";
            gridViewTextBoxColumn14.Name = "colDaXacNhan";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.FieldName = "NgayXacNhan";
            gridViewTextBoxColumn15.HeaderText = "Ngày Xác Nhận";
            gridViewTextBoxColumn15.Name = "colNgayXacNhan";
            gridViewTextBoxColumn15.Width = 130;
            gridViewTextBoxColumn16.FieldName = "UserXacNhan";
            gridViewTextBoxColumn16.HeaderText = "UserXacNhan";
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "colUserXacNhan";
            gridViewTextBoxColumn17.FieldName = "HoTen";
            gridViewTextBoxColumn17.HeaderText = "NV Xác Nhận";
            gridViewTextBoxColumn17.Name = "colHoTen";
            gridViewTextBoxColumn17.Width = 150;
            gridViewTextBoxColumn18.FieldName = "ChiNhanhDaTaiVe";
            gridViewTextBoxColumn18.HeaderText = "NT Nhận Đã Tải Về";
            gridViewTextBoxColumn18.Name = "colChiNhanhDaTaiVe";
            gridViewTextBoxColumn18.Width = 80;
            this.rgvNhanChuyenHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn18});
            this.rgvNhanChuyenHang.MasterTemplate.EnableFiltering = true;
            this.rgvNhanChuyenHang.Name = "rgvNhanChuyenHang";
            this.rgvNhanChuyenHang.ReadOnly = true;
            this.rgvNhanChuyenHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvNhanChuyenHang.ShowGroupPanel = false;
            this.rgvNhanChuyenHang.Size = new System.Drawing.Size(717, 314);
            this.rgvNhanChuyenHang.TabIndex = 0;
            this.rgvNhanChuyenHang.Text = "radGridView1";
            this.rgvNhanChuyenHang.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvNhanChuyenHang_CellDoubleClick);
            // 
            // frmNhanChuyenHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 314);
            this.Controls.Add(this.rgvNhanChuyenHang);
            this.Name = "frmNhanChuyenHang";
            this.Text = "frmNhanChuyenHang";
            this.Load += new System.EventHandler(this.frmNhanChuyenHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhanChuyenHang.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhanChuyenHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvNhanChuyenHang;

    }
}