namespace ECOPharma2013
{
    partial class frmKho
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvKho = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKho.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvKho
            // 
            this.rgvKho.BackColor = System.Drawing.SystemColors.Control;
            this.rgvKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvKho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvKho.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvKho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvKho.Location = new System.Drawing.Point(0, 0);
            this.rgvKho.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvKho
            // 
            this.rgvKho.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn13.FieldName = "KhoID";
            gridViewTextBoxColumn13.HeaderText = "Kho ID";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "colKhoID";
            gridViewTextBoxColumn14.FieldName = "TenKho";
            gridViewTextBoxColumn14.HeaderText = "Tên Kho";
            gridViewTextBoxColumn14.Name = "colTenKho";
            gridViewTextBoxColumn14.Width = 250;
            gridViewTextBoxColumn15.FieldName = "GhiChu";
            gridViewTextBoxColumn15.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn15.Name = "colGhiChu";
            gridViewTextBoxColumn15.Width = 150;
            gridViewTextBoxColumn16.FieldName = "LoaiKho";
            gridViewTextBoxColumn16.HeaderText = "Loại Kho";
            gridViewTextBoxColumn16.Name = "colLoaiKho";
            gridViewTextBoxColumn16.Width = 170;
            gridViewTextBoxColumn17.FieldName = "NhomKho";
            gridViewTextBoxColumn17.HeaderText = "Nhóm Kho";
            gridViewTextBoxColumn17.Name = "colNhomKho";
            gridViewTextBoxColumn17.Width = 170;
            gridViewTextBoxColumn18.FieldName = "KhongSuDung";
            gridViewTextBoxColumn18.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn18.Name = "colKhongSuDung";
            gridViewTextBoxColumn18.Width = 150;
            gridViewTextBoxColumn19.FieldName = "LastUD";
            gridViewTextBoxColumn19.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn19.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn19.Name = "colLastUD";
            gridViewTextBoxColumn19.Width = 150;
            gridViewTextBoxColumn20.FieldName = "NgayTao";
            gridViewTextBoxColumn20.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn20.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn20.Name = "colNgayTao";
            gridViewTextBoxColumn20.Width = 150;
            gridViewTextBoxColumn21.FieldName = "UserName";
            gridViewTextBoxColumn21.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn21.Name = "colUserName";
            gridViewTextBoxColumn21.Width = 150;
            gridViewTextBoxColumn22.FieldName = "UserID";
            gridViewTextBoxColumn22.HeaderText = "User ID";
            gridViewTextBoxColumn22.IsVisible = false;
            gridViewTextBoxColumn22.Name = "colUserID";
            gridViewTextBoxColumn23.FieldName = "LoaiKhoID";
            gridViewTextBoxColumn23.HeaderText = "LoaiKho ID";
            gridViewTextBoxColumn23.IsVisible = false;
            gridViewTextBoxColumn23.Name = "colLoaiKhoID";
            gridViewTextBoxColumn24.FieldName = "NhomKhoID";
            gridViewTextBoxColumn24.HeaderText = "NhomKho ID";
            gridViewTextBoxColumn24.IsVisible = false;
            gridViewTextBoxColumn24.Name = "colNhomKhoID";
            this.rgvKho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
            this.rgvKho.Name = "rgvKho";
            this.rgvKho.ReadOnly = true;
            this.rgvKho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvKho.ShowGroupPanel = false;
            this.rgvKho.Size = new System.Drawing.Size(772, 274);
            this.rgvKho.TabIndex = 0;
            this.rgvKho.Text = "radGridView1";
            this.rgvKho.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvKho_RowFormatting);
            this.rgvKho.DoubleClick += new System.EventHandler(this.rgvKho_DoubleClick);
            this.rgvKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvKho_KeyDown);
            // 
            // frmKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 274);
            this.Controls.Add(this.rgvKho);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKho";
            this.Text = "frmKho";
            this.Load += new System.EventHandler(this.frmKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvKho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvKho;

    }
}