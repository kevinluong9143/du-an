namespace ECOPharma2013
{
    partial class frmDBC
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDBC = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDBC.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDBC
            // 
            this.rgvDBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDBC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDBC.Location = new System.Drawing.Point(0, 0);
            this.rgvDBC.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvDBC
            // 
            this.rgvDBC.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn9.FieldName = "DBCID";
            gridViewTextBoxColumn9.HeaderText = "DBC ID";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "colDBCID";
            gridViewTextBoxColumn10.FieldName = "TenDBC";
            gridViewTextBoxColumn10.HeaderText = "Dạng Bào Chế";
            gridViewTextBoxColumn10.Name = "colTenDBC";
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.FieldName = "GhiChu";
            gridViewTextBoxColumn11.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn11.Name = "colGhiChu";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "KhongSuDung";
            gridViewTextBoxColumn12.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn12.Name = "colKhongSuDung";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "LastUD";
            gridViewTextBoxColumn13.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn13.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn13.Name = "colLastUD";
            gridViewTextBoxColumn13.Width = 150;
            gridViewTextBoxColumn14.FieldName = "NgayTao";
            gridViewTextBoxColumn14.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn14.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn14.Name = "colNgayTao";
            gridViewTextBoxColumn14.Width = 150;
            gridViewTextBoxColumn15.FieldName = "UserName";
            gridViewTextBoxColumn15.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn15.Name = "colUserName";
            gridViewTextBoxColumn15.Width = 150;
            gridViewTextBoxColumn16.FieldName = "UserID";
            gridViewTextBoxColumn16.HeaderText = "User ID";
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "colUserID";
            this.rgvDBC.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.rgvDBC.Name = "rgvDBC";
            this.rgvDBC.ReadOnly = true;
            this.rgvDBC.ShowGroupPanel = false;
            this.rgvDBC.Size = new System.Drawing.Size(785, 304);
            this.rgvDBC.TabIndex = 0;
            this.rgvDBC.Text = "radGridView1";
            this.rgvDBC.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvDBC_RowFormatting);
            this.rgvDBC.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDBC_CellDoubleClick);
            this.rgvDBC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvDBC_KeyDown);
            // 
            // frmDBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 304);
            this.Controls.Add(this.rgvDBC);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDBC";
            this.Text = "frmDBC";
            this.Load += new System.EventHandler(this.frmDBC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDBC.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDBC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDBC;

    }
}