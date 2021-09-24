namespace ECOPharma2013
{
    partial class frmNT_SanPham_Kho
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn3 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvNT_SanPham_Kho = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNT_SanPham_Kho)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvNT_SanPham_Kho
            // 
            this.rgvNT_SanPham_Kho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvNT_SanPham_Kho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvNT_SanPham_Kho.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvNT_SanPham_Kho
            // 
            this.rgvNT_SanPham_Kho.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "SPKhoid";
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "SPKho id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colSPKhoid";
            gridViewTextBoxColumn2.FieldName = "MaSP";
            gridViewTextBoxColumn2.HeaderText = "Mã SP";
            gridViewTextBoxColumn2.Name = "colMaSP";
            gridViewTextBoxColumn2.Width = 100;
            gridViewComboBoxColumn1.DisplayMember = null;
            gridViewComboBoxColumn1.FieldName = "SPid";
            gridViewComboBoxColumn1.HeaderText = "Tên Sản Phẩm";
            gridViewComboBoxColumn1.Name = "colSPid";
            gridViewComboBoxColumn1.ValueMember = null;
            gridViewComboBoxColumn1.Width = 150;
            gridViewComboBoxColumn2.DisplayMember = null;
            gridViewComboBoxColumn2.FieldName = "KhoNhapID";
            gridViewComboBoxColumn2.HeaderText = "Kho Nhập";
            gridViewComboBoxColumn2.Name = "colKhoNhapID";
            gridViewComboBoxColumn2.ValueMember = null;
            gridViewComboBoxColumn2.Width = 100;
            gridViewComboBoxColumn3.DisplayMember = null;
            gridViewComboBoxColumn3.FieldName = "KhoXuatID";
            gridViewComboBoxColumn3.HeaderText = "Kho Xuất";
            gridViewComboBoxColumn3.Name = "colKhoXuatID";
            gridViewComboBoxColumn3.ValueMember = null;
            gridViewComboBoxColumn3.Width = 100;
            gridViewTextBoxColumn3.FieldName = "LastUD";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Cập Nhật Gần Đây";
            gridViewTextBoxColumn3.Name = "colLastUD";
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.FieldName = "NgayTao";
            gridViewTextBoxColumn4.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn4.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn4.Name = "colNgayTao";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "UserID";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "User ID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colUserID";
            gridViewTextBoxColumn6.FieldName = "UserName";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn6.Name = "colUserName";
            gridViewTextBoxColumn6.Width = 200;
            this.rgvNT_SanPham_Kho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2,
            gridViewComboBoxColumn3,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvNT_SanPham_Kho.Name = "rgvNT_SanPham_Kho";
            this.rgvNT_SanPham_Kho.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvNT_SanPham_Kho.ShowGroupPanel = false;
            this.rgvNT_SanPham_Kho.Size = new System.Drawing.Size(968, 317);
            this.rgvNT_SanPham_Kho.TabIndex = 0;
            this.rgvNT_SanPham_Kho.Text = "radGridView1";
            this.rgvNT_SanPham_Kho.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvNT_SanPham_Kho_UserAddedRow);
            this.rgvNT_SanPham_Kho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgvNT_SanPham_Kho_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 317);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(968, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // frmNT_SanPham_Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 342);
            this.Controls.Add(this.rgvNT_SanPham_Kho);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmNT_SanPham_Kho";
            this.Text = "frmNT_SanPham_Kho";
            this.Load += new System.EventHandler(this.frmNT_SanPham_Kho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvNT_SanPham_Kho)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvNT_SanPham_Kho;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
    }
}