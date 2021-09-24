namespace ECOPharma2013
{
    partial class frmHeSoQuiDoi
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
            this.rgvDSHSQD = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSHSQD)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSHSQD
            // 
            this.rgvDSHSQD.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSHSQD.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSHSQD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSHSQD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSHSQD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSHSQD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSHSQD.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSHSQD
            // 
            this.rgvDSHSQD.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "HSQDid";
            gridViewTextBoxColumn1.HeaderText = "HSQD id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colHSQDid";
            gridViewTextBoxColumn2.FieldName = "SPid";
            gridViewTextBoxColumn2.HeaderText = "SP id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colSPid";
            gridViewTextBoxColumn3.FieldName = "MaSP";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Mã SP";
            gridViewTextBoxColumn3.Name = "colMaSP";
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.FieldName = "TenSP";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Tên Sản Phẩm";
            gridViewTextBoxColumn4.Name = "colTenSP";
            gridViewTextBoxColumn4.Width = 250;
            gridViewTextBoxColumn5.FieldName = "DienGiai";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Diễn Giải";
            gridViewTextBoxColumn5.Name = "colDienGiai";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "TuDVTid";
            gridViewTextBoxColumn6.HeaderText = "TuDVT id";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colTuDVTid";
            gridViewTextBoxColumn7.FieldName = "TenTuDVT";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Từ Đơn Vị";
            gridViewTextBoxColumn7.Name = "colTenTuDV";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "SangDVTid";
            gridViewTextBoxColumn8.HeaderText = "Sang DVT id";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colSangDVTid";
            gridViewTextBoxColumn9.FieldName = "TenSangDVT";
            gridViewTextBoxColumn9.FormatString = "";
            gridViewTextBoxColumn9.HeaderText = "Sang Đơn Vị";
            gridViewTextBoxColumn9.Name = "colTenSangDV";
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "GTQDThuan";
            gridViewTextBoxColumn10.FormatString = "{0:N2}";
            gridViewTextBoxColumn10.HeaderText = "GTQĐ Thuận";
            gridViewTextBoxColumn10.Name = "colGTQDThuan";
            gridViewTextBoxColumn10.Width = 120;
            gridViewTextBoxColumn11.FieldName = "GTQDNguoc";
            gridViewTextBoxColumn11.FormatString = "{0:N2}";
            gridViewTextBoxColumn11.HeaderText = "GTQĐ Ngược";
            gridViewTextBoxColumn11.Name = "colGTQDNguoc";
            gridViewTextBoxColumn11.Width = 120;
            gridViewTextBoxColumn12.FieldName = "CapDo";
            gridViewTextBoxColumn12.HeaderText = "Cấp Độ";
            gridViewTextBoxColumn12.Name = "colCapDo";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "LastUD";
            gridViewTextBoxColumn13.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn13.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn13.Name = "colLastUD";
            gridViewTextBoxColumn13.Width = 120;
            gridViewTextBoxColumn14.FieldName = "NgayTao";
            gridViewTextBoxColumn14.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn14.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn14.Name = "colNgayTao";
            gridViewTextBoxColumn14.Width = 120;
            gridViewTextBoxColumn15.FieldName = "UserID";
            gridViewTextBoxColumn15.HeaderText = "user id";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "colUserID";
            gridViewTextBoxColumn16.FieldName = "NhanVienCapNhat";
            gridViewTextBoxColumn16.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn16.Name = "colHoTen";
            gridViewTextBoxColumn16.Width = 150;
            this.rgvDSHSQD.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            this.rgvDSHSQD.MasterTemplate.EnableFiltering = true;
            this.rgvDSHSQD.Name = "rgvDSHSQD";
            this.rgvDSHSQD.ReadOnly = true;
            this.rgvDSHSQD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSHSQD.ShowGroupPanel = false;
            this.rgvDSHSQD.Size = new System.Drawing.Size(833, 362);
            this.rgvDSHSQD.TabIndex = 1;
            this.rgvDSHSQD.Text = "radGridView1";
            this.rgvDSHSQD.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSHSQD_CellDoubleClick);
            // 
            // frmHeSoQuiDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 362);
            this.Controls.Add(this.rgvDSHSQD);
            this.Name = "frmHeSoQuiDoi";
            this.Text = "frmHeSoQuiDoi";
            this.Load += new System.EventHandler(this.frmHeSoQuiDoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSHSQD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSHSQD;


    }
}