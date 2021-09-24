namespace ECOPharma2013
{
    partial class frmNhanChuyenHangXacNhan
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhieuChuyenHang = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyenHang)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuChuyenHang
            // 
            this.rgvPhieuChuyenHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuChuyenHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuChuyenHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuChuyenHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuChuyenHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuChuyenHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuChuyenHang.Location = new System.Drawing.Point(0, 0);
            this.rgvPhieuChuyenHang.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvPhieuChuyenHang
            // 
            this.rgvPhieuChuyenHang.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.FieldName = "NCHid";
            gridViewTextBoxColumn1.HeaderText = "NCHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNCHid";
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "SP Chuyển Hàng";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 130;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 140;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn5.FieldName = "TenNTGui";
            gridViewTextBoxColumn5.HeaderText = "Từ NT";
            gridViewTextBoxColumn5.Name = "colTenNTGui";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "Destination";
            gridViewTextBoxColumn6.HeaderText = "Destination";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colDestination";
            gridViewTextBoxColumn7.FieldName = "TenNTNhan";
            gridViewTextBoxColumn7.HeaderText = "Tới NT";
            gridViewTextBoxColumn7.Name = "colTenNTNhan";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn8.FieldName = "GhiChu";
            gridViewTextBoxColumn8.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn8.Name = "colGhiChu";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 250;
            this.rgvPhieuChuyenHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvPhieuChuyenHang.Name = "rgvPhieuChuyenHang";
            this.rgvPhieuChuyenHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuChuyenHang.ShowGroupPanel = false;
            this.rgvPhieuChuyenHang.Size = new System.Drawing.Size(633, 362);
            this.rgvPhieuChuyenHang.TabIndex = 0;
            this.rgvPhieuChuyenHang.Text = "radGridView1";
            // 
            // frmNhanChuyenHangXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 362);
            this.Controls.Add(this.rgvPhieuChuyenHang);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhanChuyenHangXacNhan";
            this.Text = "frmNhanChuyenHangXacNhan";
            this.Load += new System.EventHandler(this.frmNhanChuyenHangXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyenHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhieuChuyenHang;

    }
}