namespace ECOPharma2013
{
    partial class frmLichSuGiaMuaBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLichSuGiaMuaBan));
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
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDong = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.rgvLichSuMuaHang = new Telerik.WinControls.UI.RadGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuMuaHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuMuaHang.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(68, 25);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // rgvLichSuMuaHang
            // 
            this.rgvLichSuMuaHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvLichSuMuaHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvLichSuMuaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvLichSuMuaHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvLichSuMuaHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvLichSuMuaHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvLichSuMuaHang.Location = new System.Drawing.Point(0, 28);
            // 
            // rgvLichSuMuaHang
            // 
            this.rgvLichSuMuaHang.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "LSGiaID";
            gridViewTextBoxColumn1.HeaderText = "LSGia ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colLSGiaID";
            gridViewTextBoxColumn2.FieldName = "SPid";
            gridViewTextBoxColumn2.HeaderText = "SP id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colSPid";
            gridViewTextBoxColumn3.FieldName = "TenSP";
            gridViewTextBoxColumn3.HeaderText = "Sản Phẩm";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colTenSP";
            gridViewTextBoxColumn3.Width = 210;
            gridViewTextBoxColumn4.FieldName = "TenNT";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Tên NT";
            gridViewTextBoxColumn4.Name = "colTenNT";
            gridViewTextBoxColumn4.Width = 177;
            gridViewTextBoxColumn5.FieldName = "GiaMuaChuaTAXChuaChietKhau";
            gridViewTextBoxColumn5.FormatString = "{0:N2}";
            gridViewTextBoxColumn5.HeaderText = "GM (Chưa thuế)";
            gridViewTextBoxColumn5.Name = "colGiaMuaChuaTAXChuaChietKhau";
            gridViewTextBoxColumn5.Width = 107;
            gridViewTextBoxColumn6.FieldName = "PhanTramChietKhau";
            gridViewTextBoxColumn6.FormatString = "{0:N2}";
            gridViewTextBoxColumn6.HeaderText = "% CK";
            gridViewTextBoxColumn6.Name = "colPhanTramChietKhau";
            gridViewTextBoxColumn7.FieldName = "MarkUp";
            gridViewTextBoxColumn7.FormatString = "{0:N2}";
            gridViewTextBoxColumn7.HeaderText = "MU";
            gridViewTextBoxColumn7.Name = "colMarkUp";
            gridViewTextBoxColumn8.FieldName = "TAX";
            gridViewTextBoxColumn8.FormatString = "{0:N2}";
            gridViewTextBoxColumn8.HeaderText = "Thuế";
            gridViewTextBoxColumn8.Name = "colTAX";
            gridViewTextBoxColumn8.Width = 60;
            gridViewTextBoxColumn9.FieldName = "GiaBanCoChietKhauCoTax";
            gridViewTextBoxColumn9.FormatString = "{0:N2}";
            gridViewTextBoxColumn9.HeaderText = "Giá Bán";
            gridViewTextBoxColumn9.Name = "colGiaBanCoChietKhauCoTax";
            gridViewTextBoxColumn9.Width = 110;
            gridViewTextBoxColumn10.FieldName = "DVChuan";
            gridViewTextBoxColumn10.HeaderText = "DVChuan id";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colDVChuan";
            gridViewTextBoxColumn11.FieldName = "TenDVT";
            gridViewTextBoxColumn11.FormatString = "";
            gridViewTextBoxColumn11.HeaderText = "ĐVT Chuẩn/Tồn";
            gridViewTextBoxColumn11.Name = "colTenDVT";
            gridViewTextBoxColumn11.Width = 110;
            gridViewTextBoxColumn12.FieldName = "NgayCapNhat";
            gridViewTextBoxColumn12.FormatString = "";
            gridViewTextBoxColumn12.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn12.Name = "colNgayCapNhat";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "UserCapNhatid";
            gridViewTextBoxColumn13.HeaderText = "usercapnhat id";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "colUserCapNhatid";
            gridViewTextBoxColumn14.FieldName = "HoTen";
            gridViewTextBoxColumn14.FormatString = "";
            gridViewTextBoxColumn14.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn14.Name = "colHoTen";
            gridViewTextBoxColumn14.Width = 200;
            this.rgvLichSuMuaHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn14});
            this.rgvLichSuMuaHang.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.PropertyName = "colTenNT";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgvLichSuMuaHang.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.rgvLichSuMuaHang.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvLichSuMuaHang.Name = "rgvLichSuMuaHang";
            this.rgvLichSuMuaHang.ReadOnly = true;
            this.rgvLichSuMuaHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvLichSuMuaHang.ShowGroupPanel = false;
            this.rgvLichSuMuaHang.Size = new System.Drawing.Size(844, 531);
            this.rgvLichSuMuaHang.TabIndex = 2;
            this.rgvLichSuMuaHang.Text = "radGridView1";
            // 
            // frmLichSuGiaMuaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 581);
            this.ControlBox = false;
            this.Controls.Add(this.rgvLichSuMuaHang);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLichSuGiaMuaBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Sử Giá Mua và Bán";
            this.Load += new System.EventHandler(this.frmLichSuGiaMuaBan_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuMuaHang.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuMuaHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Telerik.WinControls.UI.RadGridView rgvLichSuMuaHang;
    }
}