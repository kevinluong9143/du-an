namespace ECOPharma2013
{
    partial class frmSanPham_NPP
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
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn1 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn2 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor1 = new Telerik.WinControls.Data.FilterDescriptor();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.rgvSP_NPP = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NPP.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 337);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // rgvSP_NPP
            // 
            this.rgvSP_NPP.BackColor = System.Drawing.SystemColors.Control;
            this.rgvSP_NPP.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvSP_NPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvSP_NPP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvSP_NPP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvSP_NPP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvSP_NPP.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvSP_NPP
            // 
            this.rgvSP_NPP.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.FieldName = "SPNPPid";
            gridViewTextBoxColumn1.HeaderText = "SP NPP";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colSPNPPid";
            gridViewTextBoxColumn1.Width = 70;
            gridViewTextBoxColumn2.AcceptsReturn = true;
            gridViewTextBoxColumn2.AcceptsTab = true;
            gridViewTextBoxColumn2.FieldName = "MaSP";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Mã SP";
            gridViewTextBoxColumn2.Name = "colMaSP";
            gridViewTextBoxColumn2.Width = 80;
            gridViewMultiComboBoxColumn1.DisplayMember = null;
            gridViewMultiComboBoxColumn1.FieldName = "SPid";
            gridViewMultiComboBoxColumn1.FormatString = "";
            gridViewMultiComboBoxColumn1.HeaderText = "Tên Sản Phẩm";
            gridViewMultiComboBoxColumn1.Name = "colSPid";
            gridViewMultiComboBoxColumn1.ValueMember = null;
            gridViewMultiComboBoxColumn1.Width = 350;
            gridViewComboBoxColumn1.DisplayMember = null;
            gridViewComboBoxColumn1.FieldName = "NSXid";
            gridViewComboBoxColumn1.FormatString = "";
            gridViewComboBoxColumn1.HeaderText = "Nhà Sản Xuất";
            gridViewComboBoxColumn1.Name = "colNSXid";
            gridViewComboBoxColumn1.ReadOnly = true;
            gridViewComboBoxColumn1.ValueMember = null;
            gridViewComboBoxColumn1.Width = 150;
            gridViewMultiComboBoxColumn2.DisplayMember = null;
            gridViewMultiComboBoxColumn2.FieldName = "NPPid";
            gridViewMultiComboBoxColumn2.FormatString = "";
            gridViewMultiComboBoxColumn2.HeaderText = "Nhà Phân Phối";
            gridViewMultiComboBoxColumn2.Name = "colNPPid";
            gridViewMultiComboBoxColumn2.ValueMember = null;
            gridViewMultiComboBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "GhiChu1";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú 1";
            gridViewTextBoxColumn3.Name = "colGhiChu1";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "GhiChu2";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Ghi Chú 2";
            gridViewTextBoxColumn4.Name = "colGhiChu2";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "GhiChu3";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Ghi Chú 3";
            gridViewTextBoxColumn5.Name = "colGhiChu3";
            gridViewTextBoxColumn5.Width = 100;
            gridViewCheckBoxColumn1.FieldName = "IsMacDinh";
            gridViewCheckBoxColumn1.HeaderText = "Mặc Định";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colIsMacDinh";
            gridViewCheckBoxColumn1.Width = 75;
            gridViewCheckBoxColumn2.FieldName = "KhongSuDung";
            gridViewCheckBoxColumn2.HeaderText = "Ko Sử Dụng";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "colKhongSuDung";
            gridViewCheckBoxColumn2.Width = 91;
            gridViewTextBoxColumn6.FieldName = "LastUD";
            gridViewTextBoxColumn6.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn6.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn6.Name = "colLastUD";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "NgayTao";
            gridViewTextBoxColumn7.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn7.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn7.Name = "colNgayTao";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "userid";
            gridViewTextBoxColumn8.HeaderText = "Mã User";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "coluserid";
            gridViewTextBoxColumn9.FieldName = "UserName";
            gridViewTextBoxColumn9.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn9.Name = "colUserName";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 200;
            this.rgvSP_NPP.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewMultiComboBoxColumn1,
            gridViewComboBoxColumn1,
            gridViewMultiComboBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvSP_NPP.MasterTemplate.EnableFiltering = true;
            filterDescriptor1.IsFilterEditor = true;
            filterDescriptor1.PropertyName = null;
            this.rgvSP_NPP.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor1});
            this.rgvSP_NPP.MasterTemplate.MultiSelect = true;
            this.rgvSP_NPP.Name = "rgvSP_NPP";
            this.rgvSP_NPP.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvSP_NPP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvSP_NPP.ShowGroupPanel = false;
            this.rgvSP_NPP.Size = new System.Drawing.Size(1003, 337);
            this.rgvSP_NPP.StandardTab = true;
            this.rgvSP_NPP.TabIndex = 1;
            this.rgvSP_NPP.Text = "radGridView1";
            this.rgvSP_NPP.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MasterTemplate_CellEditorInitialized);
            this.rgvSP_NPP.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvSP_NPP_UserAddedRow);
            this.rgvSP_NPP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgvSP_NPP_KeyPress);
            // 
            // frmSanPham_NPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 359);
            this.Controls.Add(this.rgvSP_NPP);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmSanPham_NPP";
            this.Text = "frmSanPham_NPP";
            this.Load += new System.EventHandler(this.frmSanPham_NPP_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NPP.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
        public Telerik.WinControls.UI.RadGridView rgvSP_NPP;
    }
}