namespace ECOPharma2013
{
    partial class frmNT_DatHangXacNhan
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
            this.rgv = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgv
            // 
            this.rgv.BackColor = System.Drawing.SystemColors.Control;
            this.rgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgv.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgv.Location = new System.Drawing.Point(0, 0);
            // 
            // rgv
            // 
            this.rgv.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.FieldName = "Chon";
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewTextBoxColumn1.FieldName = "DHid";
            gridViewTextBoxColumn1.HeaderText = "DHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 34;
            gridViewTextBoxColumn2.FieldName = "SoDH";
            gridViewTextBoxColumn2.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn2.Name = "colSoDH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "DonKhan";
            gridViewTextBoxColumn3.HeaderText = "Đơn Khẩn";
            gridViewTextBoxColumn3.Name = "colDonKhan";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.FieldName = "GhiChu";
            gridViewTextBoxColumn4.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn4.Name = "colGhiChu";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "NgayTao";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn5.Name = "colNgayTao";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn6.FieldName = "NgayDuyetDH";
            gridViewTextBoxColumn6.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn6.HeaderText = "Ngày Duyệt";
            gridViewTextBoxColumn6.Name = "colNgayDuyetDH";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn7.FieldName = "NoiDH";
            gridViewTextBoxColumn7.HeaderText = "Nơi ĐH";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colNoiDH";
            gridViewTextBoxColumn7.Width = 45;
            gridViewTextBoxColumn8.FieldName = "TenNoiDH";
            gridViewTextBoxColumn8.HeaderText = "Tên nơi ĐH";
            gridViewTextBoxColumn8.Name = "colTenNoiDH";
            gridViewTextBoxColumn8.Width = 170;
            gridViewTextBoxColumn9.FieldName = "NhomSPID";
            gridViewTextBoxColumn9.HeaderText = "NhomSPID";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "NhomSPID";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn10.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn10.HeaderText = "Hàng Đặc Biệt";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colHangDacBiet";
            this.rgv.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            this.rgv.Name = "rgv";
            this.rgv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgv.ShowGroupPanel = false;
            this.rgv.Size = new System.Drawing.Size(455, 282);
            this.rgv.TabIndex = 0;
            this.rgv.Text = "radGridView1";
            // 
            // frmNT_DatHangXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 282);
            this.Controls.Add(this.rgv);
            this.Name = "frmNT_DatHangXacNhan";
            this.Text = "Đặt Hàng Xác Nhận";
            this.Load += new System.EventHandler(this.frmNT_DatHangXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgv;
    }
}