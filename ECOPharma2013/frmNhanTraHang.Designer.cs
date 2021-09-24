namespace ECOPharma2013
{
    partial class frmNhanTraHang
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhieuTra = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuTra.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuTra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuTra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuTra.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NTHid";
            gridViewTextBoxColumn1.HeaderText = "NTHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNTHid";
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.FieldName = "SoPTH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Trả Hàng";
            gridViewTextBoxColumn2.Name = "colSoPTH";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Trả Hàng";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn4.VisibleInColumnChooser = false;
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "TenNoiTra";
            gridViewTextBoxColumn5.HeaderText = "Nơi Trả";
            gridViewTextBoxColumn5.Name = "colTenNoiTra";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "LoaiHangTra";
            gridViewTextBoxColumn6.HeaderText = "LoaiHangTra";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colLoaiHangTra";
            gridViewTextBoxColumn6.VisibleInColumnChooser = false;
            gridViewTextBoxColumn6.Width = 20;
            gridViewTextBoxColumn7.FieldName = "TenLoaiHangTra";
            gridViewTextBoxColumn7.HeaderText = "Loại Hàng Trả";
            gridViewTextBoxColumn7.Name = "colTenLoaiHangTra";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "GhiChu";
            gridViewTextBoxColumn8.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn8.Name = "colGhiChu";
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "NgayNhan";
            gridViewTextBoxColumn9.HeaderText = "Ngày Nhận";
            gridViewTextBoxColumn9.Name = "colNgayNhan";
            gridViewTextBoxColumn9.Width = 120;
            gridViewTextBoxColumn10.FieldName = "UserNhan";
            gridViewTextBoxColumn10.HeaderText = "UserNhan";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colUserNhan";
            gridViewTextBoxColumn10.VisibleInColumnChooser = false;
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.FieldName = "NVNhan";
            gridViewTextBoxColumn11.HeaderText = "NV Nhận";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "colNVNhan";
            gridViewTextBoxColumn11.Width = 120;
            gridViewTextBoxColumn12.FieldName = "LastUD";
            gridViewTextBoxColumn12.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn12.Name = "colLastUD";
            gridViewTextBoxColumn12.Width = 120;
            gridViewTextBoxColumn13.FieldName = "UserUD";
            gridViewTextBoxColumn13.HeaderText = "UserUD";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "colUserUD";
            gridViewTextBoxColumn13.VisibleInColumnChooser = false;
            gridViewTextBoxColumn13.Width = 150;
            gridViewTextBoxColumn14.FieldName = "NVCapNhat";
            gridViewTextBoxColumn14.HeaderText = "NV Cập Nhật";
            gridViewTextBoxColumn14.Name = "colNVCapNhat";
            gridViewTextBoxColumn14.Width = 120;
            gridViewTextBoxColumn15.FieldName = "DaXetDuyet";
            gridViewTextBoxColumn15.HeaderText = "Đã Xét Duyệt";
            gridViewTextBoxColumn15.Name = "colDaXetDuyet";
            gridViewTextBoxColumn15.Width = 30;
            gridViewTextBoxColumn16.FieldName = "NgayXetDuyet";
            gridViewTextBoxColumn16.HeaderText = "Ngày Xét Duyệt";
            gridViewTextBoxColumn16.Name = "colNgayXetDuyet";
            gridViewTextBoxColumn16.Width = 120;
            gridViewTextBoxColumn17.FieldName = "UserXetDuyet";
            gridViewTextBoxColumn17.HeaderText = "UserXetDuyet";
            gridViewTextBoxColumn17.IsVisible = false;
            gridViewTextBoxColumn17.Name = "colUserXetDuyet";
            gridViewTextBoxColumn17.VisibleInColumnChooser = false;
            gridViewTextBoxColumn17.Width = 150;
            gridViewTextBoxColumn18.FieldName = "NVXetDuyet";
            gridViewTextBoxColumn18.HeaderText = "NV Xét Duyệt";
            gridViewTextBoxColumn18.Name = "colNVXetDuyet";
            gridViewTextBoxColumn18.Width = 150;
            gridViewTextBoxColumn19.FieldName = "DaXacNhanNhapKho";
            gridViewTextBoxColumn19.HeaderText = "Đã Xác Nhận Nhập Kho";
            gridViewTextBoxColumn19.Name = "colDaXacNhanNhapKho";
            gridViewTextBoxColumn19.Width = 30;
            gridViewTextBoxColumn20.FieldName = "NgayXacNhan";
            gridViewTextBoxColumn20.HeaderText = "Ngày Xác Nhận";
            gridViewTextBoxColumn20.Name = "colNgayXacNhan";
            gridViewTextBoxColumn20.Width = 120;
            gridViewTextBoxColumn21.FieldName = "UserXacNhan";
            gridViewTextBoxColumn21.HeaderText = "UserXacNhan";
            gridViewTextBoxColumn21.IsVisible = false;
            gridViewTextBoxColumn21.Name = "colUserXacNhan";
            gridViewTextBoxColumn21.VisibleInColumnChooser = false;
            gridViewTextBoxColumn21.Width = 120;
            gridViewTextBoxColumn22.FieldName = "NVXacNhan";
            gridViewTextBoxColumn22.HeaderText = "NV Xác Nhận";
            gridViewTextBoxColumn22.Name = "colNVXacNhan";
            gridViewTextBoxColumn22.Width = 150;
            gridViewTextBoxColumn23.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn23.HeaderText = "KhoDacBiet";
            gridViewTextBoxColumn23.IsVisible = false;
            gridViewTextBoxColumn23.Name = "colIsKhoDacBiet";
            this.rgvPhieuTra.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23});
            this.rgvPhieuTra.MasterTemplate.EnableFiltering = true;
            this.rgvPhieuTra.Name = "rgvPhieuTra";
            this.rgvPhieuTra.ReadOnly = true;
            this.rgvPhieuTra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuTra.ShowGroupPanel = false;
            this.rgvPhieuTra.Size = new System.Drawing.Size(579, 402);
            this.rgvPhieuTra.TabIndex = 0;
            this.rgvPhieuTra.Text = "radGridView1";
            this.rgvPhieuTra.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvPhieuTra_CellDoubleClick);
            this.rgvPhieuTra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvPhieuTra_KeyDown);
            // 
            // frmNhanTraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 402);
            this.Controls.Add(this.rgvPhieuTra);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhanTraHang";
            this.Text = "frmNhanTraHang";
            this.Load += new System.EventHandler(this.frmNhanTraHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvPhieuTra;

    }
}