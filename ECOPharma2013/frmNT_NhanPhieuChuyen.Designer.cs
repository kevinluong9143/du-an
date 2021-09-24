namespace ECOPharma2013
{
    partial class frmNT_NhanPhieuChuyen
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
            this.rgvPhieuChuyen = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuChuyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuChuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvPhieuChuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuChuyen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuChuyen.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NCHid";
            gridViewTextBoxColumn1.HeaderText = "NCHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNCHid";
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Chuyển Hàng";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.Width = 110;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Từ Nhà Thuốc";
            gridViewTextBoxColumn5.Name = "colTenNT";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "GhiChu";
            gridViewTextBoxColumn6.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn6.Name = "colGhiChu";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.FieldName = "NgayNhan";
            gridViewTextBoxColumn7.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn7.HeaderText = "Ngày Nhận";
            gridViewTextBoxColumn7.Name = "colNgayNhan";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "UserNhan";
            gridViewTextBoxColumn8.HeaderText = "UserNhan";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserNhan";
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "NVNhan";
            gridViewTextBoxColumn9.HeaderText = "NV Nhận";
            gridViewTextBoxColumn9.Name = "colNVNhan";
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "LastUD";
            gridViewTextBoxColumn10.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn10.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn10.Name = "colLastUD";
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn11.FieldName = "UserUD";
            gridViewTextBoxColumn11.HeaderText = "UserUD";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "colUserUD";
            gridViewTextBoxColumn12.FieldName = "NVCapNhat";
            gridViewTextBoxColumn12.HeaderText = "NV Cập Nhật";
            gridViewTextBoxColumn12.Name = "colNVCapNhat";
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "DaXetDuyet";
            gridViewTextBoxColumn13.HeaderText = "Đã Xét Duyệt";
            gridViewTextBoxColumn13.Name = "colDaXetDuyet";
            gridViewTextBoxColumn14.FieldName = "NgayXetDuyet";
            gridViewTextBoxColumn14.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn14.HeaderText = "Ngày Xét Duyệt";
            gridViewTextBoxColumn14.Name = "colNgayXetDuyet";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.FieldName = "UserXetDuyet";
            gridViewTextBoxColumn15.HeaderText = "UserXetDuyet";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "colUserXetDuyet";
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn16.FieldName = "NVXetDuyet";
            gridViewTextBoxColumn16.HeaderText = "NV Xét Duyệt";
            gridViewTextBoxColumn16.Name = "colNVXetDuyet";
            gridViewTextBoxColumn16.Width = 100;
            gridViewTextBoxColumn17.FieldName = "DaXacNhanNhapKho";
            gridViewTextBoxColumn17.HeaderText = "Đã Xác Nhận";
            gridViewTextBoxColumn17.Name = "colDaXacNhanNhapKho";
            gridViewTextBoxColumn18.FieldName = "NgayXacNhan";
            gridViewTextBoxColumn18.HeaderText = "Ngày Xác Nhận";
            gridViewTextBoxColumn18.Name = "colNgayXacNhan";
            gridViewTextBoxColumn18.Width = 100;
            gridViewTextBoxColumn19.FieldName = "UserXacNhan";
            gridViewTextBoxColumn19.HeaderText = "UserXacNhan";
            gridViewTextBoxColumn19.IsVisible = false;
            gridViewTextBoxColumn19.Name = "colUserXacNhan";
            gridViewTextBoxColumn20.FieldName = "NVXacNhan";
            gridViewTextBoxColumn20.HeaderText = "NV Xác Nhận";
            gridViewTextBoxColumn20.MinWidth = 6;
            gridViewTextBoxColumn20.Name = "colNVXacNhan";
            gridViewTextBoxColumn20.Width = 100;
            this.rgvPhieuChuyen.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            this.rgvPhieuChuyen.Name = "rgvPhieuChuyen";
            this.rgvPhieuChuyen.ReadOnly = true;
            this.rgvPhieuChuyen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuChuyen.ShowGroupPanel = false;
            this.rgvPhieuChuyen.Size = new System.Drawing.Size(628, 308);
            this.rgvPhieuChuyen.TabIndex = 0;
            this.rgvPhieuChuyen.Text = "radGridView1";
            this.rgvPhieuChuyen.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvPhieuChuyen_CellDoubleClick);
            // 
            // frmNT_NhanPhieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 308);
            this.Controls.Add(this.rgvPhieuChuyen);
            this.Name = "frmNT_NhanPhieuChuyen";
            this.Text = "Nhận Phiếu Chuyển";
            this.Load += new System.EventHandler(this.frmNT_NhanPhieuChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvPhieuChuyen;
    }
}