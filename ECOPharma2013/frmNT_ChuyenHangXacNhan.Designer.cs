namespace ECOPharma2013
{
    partial class frmNT_ChuyenHangXacNhan
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
            this.rgvChuyenHang = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenHang.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvChuyenHang
            // 
            this.rgvChuyenHang.BackColor = System.Drawing.SystemColors.Control;
            this.rgvChuyenHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvChuyenHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvChuyenHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvChuyenHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvChuyenHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvChuyenHang.Location = new System.Drawing.Point(0, 0);
            this.rgvChuyenHang.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvChuyenHang
            // 
            this.rgvChuyenHang.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewCheckBoxColumn1.Width = 46;
            gridViewTextBoxColumn1.FieldName = "CHid";
            gridViewTextBoxColumn1.HeaderText = "CH id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colCHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 47;
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Chuyển Hàng";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 165;
            gridViewTextBoxColumn3.FieldName = "Destination";
            gridViewTextBoxColumn3.HeaderText = "Destination";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colDestination";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 87;
            gridViewTextBoxColumn4.FieldName = "TENNTDESTINATION";
            gridViewTextBoxColumn4.HeaderText = "Chuyển Tới NT";
            gridViewTextBoxColumn4.Name = "colTenNTDESTINATION";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "GhiChu";
            gridViewTextBoxColumn5.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn5.Name = "colGhiChu";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn6.FieldName = "NgayTao";
            gridViewTextBoxColumn6.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn6.Name = "colNgayTao";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn7.FieldName = "Fromm";
            gridViewTextBoxColumn7.HeaderText = "Fromm";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colFromm";
            gridViewTextBoxColumn7.Width = 58;
            gridViewTextBoxColumn8.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn8.HeaderText = "Kho Đặc Biệt";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colIsKhoDacBiet";
            this.rgvChuyenHang.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvChuyenHang.Name = "rgvChuyenHang";
            this.rgvChuyenHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvChuyenHang.ShowGroupPanel = false;
            this.rgvChuyenHang.Size = new System.Drawing.Size(685, 365);
            this.rgvChuyenHang.TabIndex = 0;
            this.rgvChuyenHang.Text = "radGridView1";
            // 
            // frmNT_ChuyenHangXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 365);
            this.ControlBox = false;
            this.Controls.Add(this.rgvChuyenHang);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNT_ChuyenHangXacNhan";
            this.Text = "Xác Nhận Chuyển Hàng";
            this.Load += new System.EventHandler(this.frmNT_ChuyenHangXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenHang.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvChuyenHang;

    }
}