namespace ECOPharma2013
{
    partial class frmSanPham_Kho
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn2 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn7 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn8 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn9 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn10 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn11 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn12 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvSP_Kho = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_Kho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_Kho.MasterTemplate)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvSP_Kho
            // 
            this.rgvSP_Kho.BackColor = System.Drawing.SystemColors.Control;
            this.rgvSP_Kho.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvSP_Kho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvSP_Kho.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvSP_Kho.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvSP_Kho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvSP_Kho.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvSP_Kho
            // 
            this.rgvSP_Kho.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn7.FieldName = "SPKhoID";
            gridViewTextBoxColumn7.HeaderText = "SPKho ID";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colSPKhoID";
            gridViewTextBoxColumn8.FieldName = "MaSP";
            gridViewTextBoxColumn8.FormatString = "";
            gridViewTextBoxColumn8.HeaderText = "Mã SP";
            gridViewTextBoxColumn8.Name = "colMaSP";
            gridViewTextBoxColumn8.Width = 65;
            gridViewMultiComboBoxColumn2.DisplayMember = null;
            gridViewMultiComboBoxColumn2.FieldName = "SPid";
            gridViewMultiComboBoxColumn2.FormatString = "";
            gridViewMultiComboBoxColumn2.HeaderText = "Tên Sản Phẩm";
            gridViewMultiComboBoxColumn2.Name = "colSPid";
            gridViewMultiComboBoxColumn2.ValueMember = null;
            gridViewMultiComboBoxColumn2.Width = 320;
            gridViewComboBoxColumn7.DisplayMember = null;
            gridViewComboBoxColumn7.FieldName = "KhoNhapID";
            gridViewComboBoxColumn7.FormatString = "";
            gridViewComboBoxColumn7.HeaderText = "Kho Nhập";
            gridViewComboBoxColumn7.Name = "colKhoNhapID";
            gridViewComboBoxColumn7.ValueMember = null;
            gridViewComboBoxColumn7.Width = 130;
            gridViewComboBoxColumn8.DisplayMember = null;
            gridViewComboBoxColumn8.FieldName = "KhoXuatID";
            gridViewComboBoxColumn8.FormatString = "";
            gridViewComboBoxColumn8.HeaderText = "Kho Xuất";
            gridViewComboBoxColumn8.Name = "colKhoXuatID";
            gridViewComboBoxColumn8.ValueMember = null;
            gridViewComboBoxColumn8.Width = 130;
            gridViewComboBoxColumn9.DisplayMember = null;
            gridViewComboBoxColumn9.FieldName = "KhoHangHuID";
            gridViewComboBoxColumn9.FormatString = "";
            gridViewComboBoxColumn9.HeaderText = "Kho Hàng Hư";
            gridViewComboBoxColumn9.Name = "colKhoHangHuID";
            gridViewComboBoxColumn9.ValueMember = null;
            gridViewComboBoxColumn9.Width = 130;
            gridViewComboBoxColumn10.DisplayMember = null;
            gridViewComboBoxColumn10.FieldName = "KhoNhapNTid";
            gridViewComboBoxColumn10.FormatString = "";
            gridViewComboBoxColumn10.HeaderText = "Kho Nhập NT";
            gridViewComboBoxColumn10.Name = "colKhoNhapNTid";
            gridViewComboBoxColumn10.ValueMember = null;
            gridViewComboBoxColumn10.Width = 130;
            gridViewComboBoxColumn11.DisplayMember = null;
            gridViewComboBoxColumn11.FieldName = "KhoXuatNTid";
            gridViewComboBoxColumn11.HeaderText = "Kho Xuất NT";
            gridViewComboBoxColumn11.Name = "colKhoXuatNTid";
            gridViewComboBoxColumn11.ValueMember = null;
            gridViewComboBoxColumn11.Width = 130;
            gridViewComboBoxColumn12.DisplayMember = null;
            gridViewComboBoxColumn12.FieldName = "KhoHangHuNTid";
            gridViewComboBoxColumn12.HeaderText = "Kho Hàng Hư NT";
            gridViewComboBoxColumn12.Name = "colKhoHangHuNTid";
            gridViewComboBoxColumn12.ValueMember = null;
            gridViewComboBoxColumn12.Width = 130;
            gridViewCheckBoxColumn2.FieldName = "IsMacDinh";
            gridViewCheckBoxColumn2.HeaderText = "Mặc Định";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "colIsMacDinh";
            gridViewCheckBoxColumn2.Width = 75;
            gridViewTextBoxColumn9.FieldName = "LastUD";
            gridViewTextBoxColumn9.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn9.HeaderText = "Ngày Cập Nhật Gần Đây";
            gridViewTextBoxColumn9.Name = "colLastUD";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "NgayTao";
            gridViewTextBoxColumn10.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn10.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn10.Name = "colNgayTao";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 150;
            gridViewTextBoxColumn11.FieldName = "UserID";
            gridViewTextBoxColumn11.HeaderText = "User id";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "colUserID";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 57;
            gridViewTextBoxColumn12.FieldName = "UserName";
            gridViewTextBoxColumn12.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn12.Name = "colUserName";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 149;
            this.rgvSP_Kho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewMultiComboBoxColumn2,
            gridViewComboBoxColumn7,
            gridViewComboBoxColumn8,
            gridViewComboBoxColumn9,
            gridViewComboBoxColumn10,
            gridViewComboBoxColumn11,
            gridViewComboBoxColumn12,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.rgvSP_Kho.MasterTemplate.EnableFiltering = true;
            this.rgvSP_Kho.Name = "rgvSP_Kho";
            this.rgvSP_Kho.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvSP_Kho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.rgvSP_Kho.RootElement.CanFocus = true;
            this.rgvSP_Kho.ShowGroupPanel = false;
            this.rgvSP_Kho.Size = new System.Drawing.Size(842, 381);
            this.rgvSP_Kho.StandardTab = true;
            this.rgvSP_Kho.TabIndex = 0;
            this.rgvSP_Kho.Text = "radGridView1";
            this.rgvSP_Kho.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvSP_Kho_CellEditorInitialized);
            this.rgvSP_Kho.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvSP_Kho_UserAddedRow);
            this.rgvSP_Kho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgvSP_Kho_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(842, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // frmSanPham_Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 406);
            this.Controls.Add(this.rgvSP_Kho);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmSanPham_Kho";
            this.Text = "frmSanPham_Kho";
            this.Load += new System.EventHandler(this.frmSanPham_Kho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_Kho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSP_Kho)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvSP_Kho;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
    }
}