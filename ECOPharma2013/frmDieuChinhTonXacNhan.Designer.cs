namespace ECOPharma2013
{
    partial class frmDieuChinhTonXacNhan
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
            this.rgvPhieuDieuChinh = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).BeginInit();
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
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.FieldName = "DCTKid";
            gridViewTextBoxColumn1.HeaderText = "DCTKid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDCTKid";
            gridViewTextBoxColumn2.FieldName = "SoPDC";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Điều Chỉnh";
            gridViewTextBoxColumn2.Name = "colSoPDC";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 140;
            gridViewTextBoxColumn3.FieldName = "NgayTao";
            gridViewTextBoxColumn3.HeaderText = "Ngày Điều Chỉnh";
            gridViewTextBoxColumn3.Name = "colNgayTao";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "NTid";
            gridViewTextBoxColumn4.HeaderText = "NTid";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colNTid";
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Nơi Được Điều Chỉnh";
            gridViewTextBoxColumn5.Name = "colTenNT";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "GhiChu";
            gridViewTextBoxColumn6.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn6.Name = "colGhiChu";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 250;
            this.rgvPhieuDieuChinh.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvPhieuDieuChinh.Name = "rgvPhieuDieuChinh";
            this.rgvPhieuDieuChinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuDieuChinh.ShowGroupPanel = false;
            this.rgvPhieuDieuChinh.Size = new System.Drawing.Size(584, 345);
            this.rgvPhieuDieuChinh.TabIndex = 0;
            this.rgvPhieuDieuChinh.Text = "radGridView1";
            // 
            // frmDieuChinhTonXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 345);
            this.Controls.Add(this.rgvPhieuDieuChinh);
            this.Name = "frmDieuChinhTonXacNhan";
            this.Text = "frmDieuChinhTonXacNhan";
            this.Load += new System.EventHandler(this.frmDieuChinhTonXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhieuDieuChinh;

    }
}