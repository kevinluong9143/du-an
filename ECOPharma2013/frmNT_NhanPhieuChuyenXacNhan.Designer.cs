namespace ECOPharma2013
{
    partial class frmNT_NhanPhieuChuyenXacNhan
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
            this.rgvPhieuChuyen = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuChuyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuChuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvPhieuChuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuChuyen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuChuyen.Location = new System.Drawing.Point(0, 0);
            this.rgvPhieuChuyen.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewCheckBoxColumn1.Width = 46;
            gridViewTextBoxColumn1.FieldName = "NCHid";
            gridViewTextBoxColumn1.HeaderText = "NCHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNCHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 54;
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Chuyển";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 140;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 140;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 58;
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Từ Nhà Thuốc";
            gridViewTextBoxColumn5.Name = "colTenNT";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "GhiChu";
            gridViewTextBoxColumn6.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn6.Name = "colGhiChu";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 200;
            this.rgvPhieuChuyen.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvPhieuChuyen.Name = "rgvPhieuChuyen";
            this.rgvPhieuChuyen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuChuyen.ShowGroupPanel = false;
            this.rgvPhieuChuyen.Size = new System.Drawing.Size(824, 363);
            this.rgvPhieuChuyen.TabIndex = 0;
            this.rgvPhieuChuyen.Text = "radGridView1";
            this.rgvPhieuChuyen.Click += new System.EventHandler(this.rgvPhieuChuyen_Click);
            // 
            // frmNT_NhanPhieuChuyenXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 363);
            this.Controls.Add(this.rgvPhieuChuyen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNT_NhanPhieuChuyenXacNhan";
            this.Text = "Nhận Phiếu Chuyển Xác Nhận";
            this.Load += new System.EventHandler(this.frmNT_NhanPhieuChuyenXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhieuChuyen;

    }
}