namespace ECOPharma2013
{
    partial class frmSanPham_NSX
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn3 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn4 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvSP_NSX = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NSX.MasterTemplate)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvSP_NSX
            // 
            this.rgvSP_NSX.BackColor = System.Drawing.SystemColors.Control;
            this.rgvSP_NSX.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvSP_NSX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvSP_NSX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvSP_NSX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvSP_NSX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvSP_NSX.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvSP_NSX
            // 
            this.rgvSP_NSX.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn8.FieldName = "SPNSXid";
            gridViewTextBoxColumn8.HeaderText = "SP NSX";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colSPNSXid";
            gridViewTextBoxColumn8.Width = 70;
            gridViewTextBoxColumn9.AcceptsReturn = true;
            gridViewTextBoxColumn9.AcceptsTab = true;
            gridViewTextBoxColumn9.FieldName = "MaSP";
            gridViewTextBoxColumn9.FormatString = "";
            gridViewTextBoxColumn9.HeaderText = "Mã SP";
            gridViewTextBoxColumn9.Name = "colMaSP";
            gridViewTextBoxColumn9.Width = 80;
            gridViewMultiComboBoxColumn3.DisplayMember = null;
            gridViewMultiComboBoxColumn3.FieldName = "SPid";
            gridViewMultiComboBoxColumn3.HeaderText = "Tên Sản Phẩm";
            gridViewMultiComboBoxColumn3.Name = "colSPid";
            gridViewMultiComboBoxColumn3.ValueMember = null;
            gridViewMultiComboBoxColumn3.Width = 350;
            gridViewMultiComboBoxColumn4.DisplayMember = null;
            gridViewMultiComboBoxColumn4.FieldName = "NSXid";
            gridViewMultiComboBoxColumn4.HeaderText = "Nhà Sản Xuất";
            gridViewMultiComboBoxColumn4.Name = "colNSXid";
            gridViewMultiComboBoxColumn4.ValueMember = null;
            gridViewMultiComboBoxColumn4.Width = 200;
            gridViewTextBoxColumn10.FieldName = "GhiChu";
            gridViewTextBoxColumn10.FormatString = "";
            gridViewTextBoxColumn10.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn10.Name = "colGhiChu";
            gridViewTextBoxColumn10.Width = 100;
            gridViewCheckBoxColumn3.FieldName = "KhongSuDung";
            gridViewCheckBoxColumn3.FormatString = "";
            gridViewCheckBoxColumn3.HeaderText = "Ko Sử Dụng";
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "colKhongSuDung";
            gridViewCheckBoxColumn3.Width = 91;
            gridViewCheckBoxColumn4.FieldName = "MacDinh";
            gridViewCheckBoxColumn4.HeaderText = "Mặc Định";
            gridViewCheckBoxColumn4.IsVisible = false;
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "colMacDinh";
            gridViewCheckBoxColumn4.Width = 75;
            gridViewTextBoxColumn11.FieldName = "LastUD";
            gridViewTextBoxColumn11.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn11.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn11.Name = "colLastUD";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "NgayTao";
            gridViewTextBoxColumn12.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn12.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn12.Name = "colNgayTao";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "userid";
            gridViewTextBoxColumn13.HeaderText = "Mã User";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "coluserid";
            gridViewTextBoxColumn14.FieldName = "UserName";
            gridViewTextBoxColumn14.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn14.Name = "colUserName";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 200;
            this.rgvSP_NSX.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewMultiComboBoxColumn3,
            gridViewMultiComboBoxColumn4,
            gridViewTextBoxColumn10,
            gridViewCheckBoxColumn3,
            gridViewCheckBoxColumn4,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.rgvSP_NSX.MasterTemplate.EnableFiltering = true;
            this.rgvSP_NSX.MasterTemplate.MultiSelect = true;
            this.rgvSP_NSX.Name = "rgvSP_NSX";
            this.rgvSP_NSX.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvSP_NSX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvSP_NSX.ShowGroupPanel = false;
            this.rgvSP_NSX.Size = new System.Drawing.Size(753, 429);
            this.rgvSP_NSX.StandardTab = true;
            this.rgvSP_NSX.TabIndex = 0;
            this.rgvSP_NSX.Text = "radGridView1";
            this.rgvSP_NSX.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvSP_NSX_CellEditorInitialized);
            this.rgvSP_NSX.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvSP_NSX_UserAddedRow);
            this.rgvSP_NSX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgvSP_NSX_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(753, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // frmSanPham_NSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 454);
            this.Controls.Add(this.rgvSP_NSX);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSanPham_NSX";
            this.Text = "frmSanPham_NSX";
            this.Load += new System.EventHandler(this.frmSanPham_NSX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NSX.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_NSX)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvSP_NSX;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
    }
}