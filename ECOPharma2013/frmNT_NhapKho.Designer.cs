namespace ECOPharma2013
{
    partial class frmNT_NhapKho
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
            this.rgvDSPhieuNhap = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSPhieuNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSPhieuNhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSPhieuNhap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSPhieuNhap.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.MasterTemplate.AllowAddNewRow = false;
            this.rgvDSPhieuNhap.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "PNid";
            gridViewTextBoxColumn1.HeaderText = "PN id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colPNid";
            gridViewTextBoxColumn2.FieldName = "SoCTN";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Số Chứng Từ Nhập";
            gridViewTextBoxColumn2.Name = "colSoCTN";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "SoDH";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn3.Name = "colSoDH";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "NgayNhap";
            gridViewTextBoxColumn4.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn4.HeaderText = "Ngày Nhập";
            gridViewTextBoxColumn4.Name = "colNgayNhap";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "LoaiPhatSinh";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Loại Phát Sinh";
            gridViewTextBoxColumn5.Name = "colLoaiPhatSinh";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn6.FieldName = "Fromm";
            gridViewTextBoxColumn6.HeaderText = "Từ ID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colFromm";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn7.FieldName = "TenNT";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Từ";
            gridViewTextBoxColumn7.Name = "colTenNT";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "XNPhieuNhap";
            gridViewTextBoxColumn8.HeaderText = "Đã Xác Nhận Nhập Kho";
            gridViewTextBoxColumn8.Name = "colXNPhieuNhap";
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.FieldName = "GhiChu";
            gridViewTextBoxColumn9.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn9.Name = "colGhiChu";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "NgayXN";
            gridViewTextBoxColumn10.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn10.HeaderText = "Ngày Xác Nhận";
            gridViewTextBoxColumn10.Name = "colNgayXN";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn11.FieldName = "UserNhap";
            gridViewTextBoxColumn11.HeaderText = "User Nhap";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "colUserNhap";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn12.FieldName = "TenNVNhap";
            gridViewTextBoxColumn12.HeaderText = "NV Nhập";
            gridViewTextBoxColumn12.Name = "colTenNVNhap";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "UserXN";
            gridViewTextBoxColumn13.HeaderText = "User XN";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "colUserXN";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn14.FieldName = "TenNVXacNhan";
            gridViewTextBoxColumn14.HeaderText = "NV Xác Nhận";
            gridViewTextBoxColumn14.Name = "colTenNVXacNhan";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.FieldName = "IsPhieuCuoi";
            gridViewTextBoxColumn15.HeaderText = "IsPhieuCuoi";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "colIsPhieuCuoi";
            gridViewTextBoxColumn16.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn16.HeaderText = "Hàng Đặc Biệt";
            gridViewTextBoxColumn16.Name = "colHangDacBiet";
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
            gridViewTextBoxColumn16});
            this.rgvDSPhieuNhap.MasterTemplate.EnableFiltering = true;
            this.rgvDSPhieuNhap.Name = "rgvDSPhieuNhap";
            this.rgvDSPhieuNhap.ReadOnly = true;
            this.rgvDSPhieuNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSPhieuNhap.ShowGroupPanel = false;
            this.rgvDSPhieuNhap.Size = new System.Drawing.Size(780, 353);
            this.rgvDSPhieuNhap.TabIndex = 0;
            this.rgvDSPhieuNhap.Text = "radGridView1";
            this.rgvDSPhieuNhap.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSPhieuNhap_CellDoubleClick);
            // 
            // frmNT_NhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 353);
            this.Controls.Add(this.rgvDSPhieuNhap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNT_NhapKho";
            this.Text = "frmNT_NhapKho";
            this.Load += new System.EventHandler(this.frmNT_NhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSPhieuNhap;

    }
}