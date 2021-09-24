namespace ECOPharma2013
{
    partial class frmNT_TraHangVeCtyXacNhan
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhieuTra = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuTra.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuTra.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvPhieuTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuTra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuTra.Location = new System.Drawing.Point(0, 0);
            this.rgvPhieuTra.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewCheckBoxColumn1.Width = 46;
            gridViewTextBoxColumn1.FieldName = "THid";
            gridViewTextBoxColumn1.HeaderText = "THid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colTHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 41;
            gridViewTextBoxColumn2.FieldName = "SoPTH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Trả Hàng";
            gridViewTextBoxColumn2.Name = "colSoPTH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 135;
            gridViewTextBoxColumn3.FieldName = "Destination";
            gridViewTextBoxColumn3.HeaderText = "Destination";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colDestination";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 87;
            gridViewTextBoxColumn4.FieldName = "TENNOINHAN";
            gridViewTextBoxColumn4.HeaderText = "Nơi Nhận";
            gridViewTextBoxColumn4.Name = "colTENNOINHAN";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "LoaiHangTra";
            gridViewTextBoxColumn5.HeaderText = "LoaiHangTra";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colLoaiHangTra";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 95;
            gridViewTextBoxColumn6.FieldName = "TenLoaiHangTra";
            gridViewTextBoxColumn6.HeaderText = "Loại Hàng Trả";
            gridViewTextBoxColumn6.Name = "colTenLoaiHangTra";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 104;
            gridViewTextBoxColumn7.FieldName = "GhiChu";
            gridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn7.Name = "colGhiChu";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn8.FieldName = "NgayTao";
            gridViewTextBoxColumn8.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn8.Name = "colNgayTao";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 140;
            gridViewTextBoxColumn9.FieldName = "Fromm";
            gridViewTextBoxColumn9.HeaderText = "Fromm";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "colFromm";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn10.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn10.HeaderText = "Hàng Đặc Biệt";
            gridViewTextBoxColumn10.Name = "colHangDacBiet";
            this.rgvPhieuTra.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.rgvPhieuTra.Name = "rgvPhieuTra";
            this.rgvPhieuTra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuTra.ShowGroupPanel = false;
            this.rgvPhieuTra.Size = new System.Drawing.Size(600, 334);
            this.rgvPhieuTra.TabIndex = 0;
            this.rgvPhieuTra.Text = "radGridView1";
            // 
            // frmNT_TraHangVeCtyXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 334);
            this.Controls.Add(this.rgvPhieuTra);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNT_TraHangVeCtyXacNhan";
            this.Text = "Trả Hàng Về Công Ty Xác Nhận";
            this.Load += new System.EventHandler(this.frmNT_TraHangVeCtyXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhieuTra;

    }
}