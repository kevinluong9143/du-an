namespace ECOPharma2013
{
    partial class frmDonHangXuatReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonHangXuatReport));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDong = new System.Windows.Forms.ToolStripButton();
            this.rgvLichSuDonHangXuat = new Telerik.WinControls.UI.RadGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuDonHangXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuDonHangXuat.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(68, 25);
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // rgvLichSuDonHangXuat
            // 
            this.rgvLichSuDonHangXuat.BackColor = System.Drawing.SystemColors.Control;
            this.rgvLichSuDonHangXuat.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvLichSuDonHangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvLichSuDonHangXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvLichSuDonHangXuat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvLichSuDonHangXuat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvLichSuDonHangXuat.Location = new System.Drawing.Point(0, 28);
            // 
            // rgvLichSuDonHangXuat
            // 
            this.rgvLichSuDonHangXuat.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "STT";
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "colSTT";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 30;
            gridViewTextBoxColumn2.FieldName = "SoDH";
            gridViewTextBoxColumn2.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn2.Name = "colSoDH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.FieldName = "TenNT";
            gridViewTextBoxColumn3.HeaderText = "Nhà Thuốc";
            gridViewTextBoxColumn3.Name = "colTenNT";
            gridViewTextBoxColumn3.Width = 180;
            gridViewTextBoxColumn4.FieldName = "SLDat";
            gridViewTextBoxColumn4.FormatString = "{0:N0}";
            gridViewTextBoxColumn4.HeaderText = "SL Đặt";
            gridViewTextBoxColumn4.Name = "colSLDat";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 60;
            gridViewTextBoxColumn5.FieldName = "SLDapUng";
            gridViewTextBoxColumn5.FormatString = "{0:N0}";
            gridViewTextBoxColumn5.HeaderText = "SL Đáp Ứng";
            gridViewTextBoxColumn5.Name = "colSLDapUng";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn6.FieldName = "SLConThieu";
            gridViewTextBoxColumn6.FormatString = "{0:N0}";
            gridViewTextBoxColumn6.HeaderText = "SL Còn Thiếu";
            gridViewTextBoxColumn6.Name = "colSLConThieu";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 90;
            gridViewTextBoxColumn7.FieldName = "TenDVT";
            gridViewTextBoxColumn7.HeaderText = "ĐVT";
            gridViewTextBoxColumn7.Name = "colTenDVT";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn7.Width = 55;
            gridViewTextBoxColumn8.FieldName = "NgayTao";
            gridViewTextBoxColumn8.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn8.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn8.Name = "colNgayTao";
            gridViewTextBoxColumn8.Width = 160;
            gridViewCheckBoxColumn1.FieldName = "DuyetDH";
            gridViewCheckBoxColumn1.HeaderText = "Duyệt ĐH";
            gridViewCheckBoxColumn1.Name = "colDuyetDH";
            gridViewCheckBoxColumn1.Width = 65;
            gridViewCheckBoxColumn2.FieldName = "DaXacNhanDH";
            gridViewCheckBoxColumn2.HeaderText = "XN ĐH";
            gridViewCheckBoxColumn2.Name = "colDaXacNhanDH";
            gridViewCheckBoxColumn2.Width = 65;
            gridViewTextBoxColumn9.FieldName = "ChuKiID";
            gridViewTextBoxColumn9.HeaderText = "Chu Kì";
            gridViewTextBoxColumn9.Name = "colChuKiID";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 80;
            this.rgvLichSuDonHangXuat.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn9});
            this.rgvLichSuDonHangXuat.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvLichSuDonHangXuat.Name = "rgvLichSuDonHangXuat";
            this.rgvLichSuDonHangXuat.ReadOnly = true;
            this.rgvLichSuDonHangXuat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvLichSuDonHangXuat.ShowGroupPanel = false;
            this.rgvLichSuDonHangXuat.Size = new System.Drawing.Size(958, 212);
            this.rgvLichSuDonHangXuat.TabIndex = 1;
            this.rgvLichSuDonHangXuat.TabStop = false;
            this.rgvLichSuDonHangXuat.Text = "radGridView1";
            // 
            // frmDonHangXuatReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 240);
            this.ControlBox = false;
            this.Controls.Add(this.rgvLichSuDonHangXuat);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDonHangXuatReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Sử Đơn Hàng Xuất Của Một Sản Phẩm";
            this.Load += new System.EventHandler(this.frmDonHangXuatReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuDonHangXuat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLichSuDonHangXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDong;
        private Telerik.WinControls.UI.RadGridView rgvLichSuDonHangXuat;
    }
}