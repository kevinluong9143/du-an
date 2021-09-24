namespace ECOPharma2013
{
    partial class frmPhanLoaiGia
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhanLoaiGia = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanLoaiGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanLoaiGia.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhanLoaiGia
            // 
            this.rgvPhanLoaiGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhanLoaiGia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhanLoaiGia.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhanLoaiGia
            // 
            this.rgvPhanLoaiGia.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn10.FieldName = "LGID";
            gridViewTextBoxColumn10.FormatString = "";
            gridViewTextBoxColumn10.HeaderText = "LG ID";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colLGID";
            gridViewTextBoxColumn11.FieldName = "TenLG";
            gridViewTextBoxColumn11.FormatString = "";
            gridViewTextBoxColumn11.HeaderText = "Loại Giá";
            gridViewTextBoxColumn11.Name = "colTenLG";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "MarkUp";
            gridViewTextBoxColumn12.FormatString = "{0:N2}";
            gridViewTextBoxColumn12.HeaderText = "Mark Up";
            gridViewTextBoxColumn12.Name = "colMarkUp";
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "GhiChu";
            gridViewTextBoxColumn13.FormatString = "";
            gridViewTextBoxColumn13.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn13.Name = "colGhiChu";
            gridViewTextBoxColumn13.Width = 150;
            gridViewTextBoxColumn14.FieldName = "KhongSuDung";
            gridViewTextBoxColumn14.FormatString = "";
            gridViewTextBoxColumn14.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn14.Name = "colKhongSuDung";
            gridViewTextBoxColumn14.Width = 150;
            gridViewTextBoxColumn15.FieldName = "LastUD";
            gridViewTextBoxColumn15.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn15.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn15.Name = "colLastUD";
            gridViewTextBoxColumn15.Width = 150;
            gridViewTextBoxColumn16.FieldName = "NgayTao";
            gridViewTextBoxColumn16.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn16.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn16.Name = "colNgayTao";
            gridViewTextBoxColumn16.Width = 150;
            gridViewTextBoxColumn17.FieldName = "UserName";
            gridViewTextBoxColumn17.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn17.Name = "colUserName";
            gridViewTextBoxColumn17.Width = 150;
            gridViewTextBoxColumn18.FieldName = "UserID";
            gridViewTextBoxColumn18.HeaderText = "User ID";
            gridViewTextBoxColumn18.IsVisible = false;
            gridViewTextBoxColumn18.Name = "colUserID";
            this.rgvPhanLoaiGia.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18});
            this.rgvPhanLoaiGia.Name = "rgvPhanLoaiGia";
            this.rgvPhanLoaiGia.ReadOnly = true;
            this.rgvPhanLoaiGia.ShowGroupPanel = false;
            this.rgvPhanLoaiGia.Size = new System.Drawing.Size(676, 368);
            this.rgvPhanLoaiGia.TabIndex = 0;
            this.rgvPhanLoaiGia.Text = "radGridView1";
            this.rgvPhanLoaiGia.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvPhanLoaiGia_RowFormatting);
            this.rgvPhanLoaiGia.DoubleClick += new System.EventHandler(this.rgvPhanLoaiGia_DoubleClick);
            this.rgvPhanLoaiGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvPhanLoaiGia_KeyDown);
            // 
            // frmPhanLoaiGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 368);
            this.Controls.Add(this.rgvPhanLoaiGia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhanLoaiGia";
            this.Text = "frmPhanLoaiGia";
            this.Load += new System.EventHandler(this.frmPhanLoaiGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanLoaiGia.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanLoaiGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhanLoaiGia;

    }
}