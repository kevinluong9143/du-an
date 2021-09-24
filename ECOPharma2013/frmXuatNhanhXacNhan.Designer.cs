namespace ECOPharma2013
{
    partial class frmXuatNhanhXacNhan
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
            this.rgvPhieuXuat = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuXuat
            // 
            this.rgvPhieuXuat.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuXuat.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuXuat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuXuat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuXuat.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhieuXuat
            // 
            this.rgvPhieuXuat.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewTextBoxColumn1.FieldName = "XNid";
            gridViewTextBoxColumn1.HeaderText = "XNid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colXNid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.FieldName = "SoPXN";
            gridViewTextBoxColumn2.HeaderText = "Số PXN";
            gridViewTextBoxColumn2.Name = "colSoPXN";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "LDid";
            gridViewTextBoxColumn3.HeaderText = "LDid";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colLDid";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn4.FieldName = "LyDo";
            gridViewTextBoxColumn4.HeaderText = "Lý Do Xuất";
            gridViewTextBoxColumn4.Name = "colLyDo";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "XuatDenID";
            gridViewTextBoxColumn5.HeaderText = "XuatDenID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colXuatDenID";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn6.FieldName = "TenNPP";
            gridViewTextBoxColumn6.HeaderText = "Xuất Đến";
            gridViewTextBoxColumn6.Name = "colTenNPP";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 200;
            gridViewTextBoxColumn7.FieldName = "GhiChu";
            gridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn7.Name = "colGhiChu";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "NgayTao";
            gridViewTextBoxColumn8.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn8.Name = "colNgayTao";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 90;
            gridViewTextBoxColumn9.FieldName = "NgayXetDuyet";
            gridViewTextBoxColumn9.HeaderText = "Ngày Xét Duyệt";
            gridViewTextBoxColumn9.Name = "colNgayXetDuyet";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 90;
            this.rgvPhieuXuat.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvPhieuXuat.Name = "rgvPhieuXuat";
            this.rgvPhieuXuat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuXuat.ShowGroupPanel = false;
            this.rgvPhieuXuat.Size = new System.Drawing.Size(564, 328);
            this.rgvPhieuXuat.TabIndex = 0;
            this.rgvPhieuXuat.Text = "radGridView1";
            // 
            // frmXuatNhanhXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 328);
            this.Controls.Add(this.rgvPhieuXuat);
            this.Name = "frmXuatNhanhXacNhan";
            this.Text = "frmXuatNhanhXacNhan";
            this.Load += new System.EventHandler(this.frmXuatNhanhXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvPhieuXuat;
    }
}