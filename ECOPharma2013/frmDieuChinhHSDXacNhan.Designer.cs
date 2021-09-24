namespace ECOPharma2013
{
    partial class frmDieuChinhHSDXacNhan
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhieuDieuChinh = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuDieuChinh
            // 
            this.rgvPhieuDieuChinh.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuDieuChinh.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuDieuChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuDieuChinh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvPhieuDieuChinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuDieuChinh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuDieuChinh.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhieuDieuChinh
            // 
            this.rgvPhieuDieuChinh.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn2.HeaderText = "Chọn";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "column1";
            gridViewTextBoxColumn7.FieldName = "DCHDid";
            gridViewTextBoxColumn7.HeaderText = "DCTKid";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colDCHDid";
            gridViewTextBoxColumn8.FieldName = "SoPDCHD";
            gridViewTextBoxColumn8.HeaderText = "Số Phiếu Điều Chỉnh";
            gridViewTextBoxColumn8.Name = "colSoPDCHD";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 140;
            gridViewTextBoxColumn9.FieldName = "NgayTao";
            gridViewTextBoxColumn9.HeaderText = "Ngày Điều Chỉnh";
            gridViewTextBoxColumn9.Name = "colNgayTao";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "NTid";
            gridViewTextBoxColumn10.HeaderText = "NTid";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colNTid";
            gridViewTextBoxColumn11.FieldName = "TenNT";
            gridViewTextBoxColumn11.HeaderText = "Nơi Được Điều Chỉnh";
            gridViewTextBoxColumn11.Name = "colTenNT";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 200;
            gridViewTextBoxColumn12.FieldName = "GhiChu";
            gridViewTextBoxColumn12.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn12.Name = "colGhiChu";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 250;
            this.rgvPhieuDieuChinh.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.rgvPhieuDieuChinh.Name = "rgvPhieuDieuChinh";
            this.rgvPhieuDieuChinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuDieuChinh.ShowGroupPanel = false;
            this.rgvPhieuDieuChinh.Size = new System.Drawing.Size(626, 289);
            this.rgvPhieuDieuChinh.TabIndex = 1;
            this.rgvPhieuDieuChinh.Text = "radGridView1";
            // 
            // frmDieuChinhHSDXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 289);
            this.Controls.Add(this.rgvPhieuDieuChinh);
            this.Name = "frmDieuChinhHSDXacNhan";
            this.Text = "frmDieuChinhHSDXacNhan";
            this.Load += new System.EventHandler(this.frmDieuChinhHSDXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhieuDieuChinh;
    }
}