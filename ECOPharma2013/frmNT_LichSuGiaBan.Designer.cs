namespace ECOPharma2013
{
    partial class frmNT_LichSuGiaBan
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            this.rgvLichSuGiaBan = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuGiaBan.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvLichSuGiaBan
            // 
            this.rgvLichSuGiaBan.BackColor = System.Drawing.SystemColors.Control;
            this.rgvLichSuGiaBan.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvLichSuGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvLichSuGiaBan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvLichSuGiaBan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvLichSuGiaBan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvLichSuGiaBan.Location = new System.Drawing.Point(0, 0);
            this.rgvLichSuGiaBan.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvLichSuGiaBan
            // 
            this.rgvLichSuGiaBan.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "SPid";
            gridViewTextBoxColumn1.HeaderText = "SP id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colSPid";
            gridViewTextBoxColumn2.FieldName = "MaSP";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Mã SP";
            gridViewTextBoxColumn2.Name = "colMaSP";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.FieldName = "TenSP";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Tên Sản Phẩm";
            gridViewTextBoxColumn3.Name = "colTenSP";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.FieldName = "NSXid";
            gridViewTextBoxColumn4.HeaderText = "NSX id";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colNSXid";
            gridViewTextBoxColumn5.FieldName = "TenNSX";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Nhà Sản Xuất";
            gridViewTextBoxColumn5.Name = "colTenNSX";
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "GiaBanCoTAXMoiTheoDVBan";
            gridViewTextBoxColumn6.FormatString = "{0:N2}";
            gridViewTextBoxColumn6.HeaderText = "Giá Bán Có Thuế";
            gridViewTextBoxColumn6.Name = "colGiaBanCoTAXMoiTheoDVBan";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "DVBanID";
            gridViewTextBoxColumn7.HeaderText = "DVBan id";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colDVBanID";
            gridViewTextBoxColumn8.FieldName = "TenDVBan";
            gridViewTextBoxColumn8.FormatString = "";
            gridViewTextBoxColumn8.HeaderText = "Đơn Vị Tính";
            gridViewTextBoxColumn8.Name = "colTenDVBan";
            gridViewTextBoxColumn8.Width = 100;
            gridViewDateTimeColumn1.FieldName = "Ngay";
            gridViewDateTimeColumn1.FormatString = "";
            gridViewDateTimeColumn1.HeaderText = "Ngày";
            gridViewDateTimeColumn1.Name = "colNgay";
            gridViewDateTimeColumn1.Width = 140;
            this.rgvLichSuGiaBan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDateTimeColumn1});
            this.rgvLichSuGiaBan.MasterTemplate.EnableFiltering = true;
            this.rgvLichSuGiaBan.Name = "rgvLichSuGiaBan";
            this.rgvLichSuGiaBan.ReadOnly = true;
            this.rgvLichSuGiaBan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvLichSuGiaBan.ShowGroupPanel = false;
            this.rgvLichSuGiaBan.Size = new System.Drawing.Size(998, 351);
            this.rgvLichSuGiaBan.TabIndex = 1;
            this.rgvLichSuGiaBan.Text = "radGridView1";
            // 
            // frmNT_LichSuGiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 351);
            this.Controls.Add(this.rgvLichSuGiaBan);
            this.Name = "frmNT_LichSuGiaBan";
            this.Text = "frmNT_LichSuGiaBan";
            this.Load += new System.EventHandler(this.frmNT_LichSuGiaBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuGiaBan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuGiaBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvLichSuGiaBan;
    }
}