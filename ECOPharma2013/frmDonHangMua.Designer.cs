namespace ECOPharma2013
{
    partial class frmDonHangMua
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSDHMua = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMua.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSDHMua
            // 
            this.rgvDSDHMua.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSDHMua.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSDHMua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSDHMua.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.rgvDSDHMua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSDHMua.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSDHMua.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSDHMua
            // 
            this.rgvDSDHMua.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "PNid";
            gridViewTextBoxColumn1.HeaderText = "PN id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colPNid";
            gridViewTextBoxColumn1.Width = 73;
            gridViewTextBoxColumn2.FieldName = "NPPid";
            gridViewTextBoxColumn2.HeaderText = "NPP id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colNPPid";
            gridViewTextBoxColumn2.Width = 63;
            gridViewTextBoxColumn3.FieldName = "TenNPP";
            gridViewTextBoxColumn3.HeaderText = "Tên NPP";
            gridViewTextBoxColumn3.Name = "TenNPP";
            gridViewTextBoxColumn3.Width = 259;
            gridViewTextBoxColumn4.FieldName = "SoDHMua";
            gridViewTextBoxColumn4.HeaderText = "Số ĐH Mua";
            gridViewTextBoxColumn4.Name = "colSoDHMua";
            gridViewTextBoxColumn4.Width = 142;
            gridViewTextBoxColumn5.FieldName = "SoDHTong";
            gridViewTextBoxColumn5.HeaderText = "Số ĐH Tổng";
            gridViewTextBoxColumn5.Name = "colSoDHTong";
            gridViewTextBoxColumn5.Width = 152;
            gridViewTextBoxColumn6.FieldName = "NgayTao";
            gridViewTextBoxColumn6.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn6.Name = "colNgayTao";
            gridViewTextBoxColumn6.Width = 197;
            gridViewTextBoxColumn7.FieldName = "IsYeuCauNhapKho";
            gridViewTextBoxColumn7.HeaderText = "Đã YC Nhập Kho";
            gridViewTextBoxColumn7.Name = "colIsYeuCauNhapKho";
            gridViewTextBoxColumn7.Width = 152;
            gridViewTextBoxColumn8.FieldName = "TinhTrang";
            gridViewTextBoxColumn8.HeaderText = "Tinh Trang id";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colTinhTrang";
            gridViewTextBoxColumn8.Width = 173;
            gridViewTextBoxColumn9.FieldName = "TenTinhTrang";
            gridViewTextBoxColumn9.HeaderText = "Tình Trạng";
            gridViewTextBoxColumn9.Name = "TenTinhTrang";
            gridViewTextBoxColumn9.Width = 229;
            this.rgvDSDHMua.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvDSDHMua.Name = "rgvDSDHMua";
            this.rgvDSDHMua.ReadOnly = true;
            this.rgvDSDHMua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSDHMua.ShowGroupPanel = false;
            this.rgvDSDHMua.Size = new System.Drawing.Size(591, 291);
            this.rgvDSDHMua.TabIndex = 0;
            this.rgvDSDHMua.Text = "radGridView1";
            this.rgvDSDHMua.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSDHMua_CellDoubleClick);
            // 
            // frmDonHangMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 291);
            this.Controls.Add(this.rgvDSDHMua);
            this.Name = "frmDonHangMua";
            this.Text = "frmDonHangMua";
            this.Load += new System.EventHandler(this.frmDonHangMua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMua.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvDSDHMua;
    }
}