namespace ECOPharma2013
{
    partial class frmKiemTraXuatKho
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
            this.components = new System.ComponentModel.Container();
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvKiemTraXuatKho = new Telerik.WinControls.UI.RadGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xácNhậnThựcXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKiemTraXuatKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKiemTraXuatKho.MasterTemplate)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvKiemTraXuatKho
            // 
            this.rgvKiemTraXuatKho.BackColor = System.Drawing.SystemColors.Control;
            this.rgvKiemTraXuatKho.ContextMenuStrip = this.contextMenu;
            this.rgvKiemTraXuatKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvKiemTraXuatKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvKiemTraXuatKho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvKiemTraXuatKho.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvKiemTraXuatKho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvKiemTraXuatKho.Location = new System.Drawing.Point(0, 0);
            this.rgvKiemTraXuatKho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // rgvKiemTraXuatKho
            // 
            this.rgvKiemTraXuatKho.MasterTemplate.AllowAddNewRow = false;
            this.rgvKiemTraXuatKho.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "KTid";
            gridViewTextBoxColumn1.HeaderText = "KT id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colKTid";
            gridViewTextBoxColumn2.FieldName = "PXid";
            gridViewTextBoxColumn2.HeaderText = "PX id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colPXid";
            gridViewTextBoxColumn3.FieldName = "SoPX";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Số Phiếu Xuất";
            gridViewTextBoxColumn3.Name = "colSoPX";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "SoDH";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn4.Name = "colSoDH";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "NgayKiemTra";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Kiểm Tra";
            gridViewTextBoxColumn5.Name = "colNgayKiemTra";
            gridViewTextBoxColumn5.Width = 180;
            gridViewTextBoxColumn6.FieldName = "IsXong";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Đã KT Xong";
            gridViewTextBoxColumn6.Name = "colIsXong";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.FieldName = "NgayXong";
            gridViewTextBoxColumn7.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn7.HeaderText = "Ngày KT Xong";
            gridViewTextBoxColumn7.Name = "colNgayXong";
            gridViewTextBoxColumn7.Width = 180;
            gridViewTextBoxColumn8.FieldName = "UserKiemTra";
            gridViewTextBoxColumn8.HeaderText = "KTID";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserKiemTra";
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.FieldName = "TenNVKT";
            gridViewTextBoxColumn9.HeaderText = "Nhân Viên KT";
            gridViewTextBoxColumn9.Name = "colTenNVKT";
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "IsChuyenDongGoi";
            gridViewTextBoxColumn10.HeaderText = "Đã Chuyển Đóng Gói";
            gridViewTextBoxColumn10.Name = "colIsChuyenDongGoi";
            gridViewTextBoxColumn10.Width = 180;
            gridViewTextBoxColumn11.FieldName = "IsChuyenchiNhanh";
            gridViewTextBoxColumn11.HeaderText = "Chuyển Chi Nhánh";
            gridViewTextBoxColumn11.Name = "colIsChuyenchiNhanh";
            gridViewTextBoxColumn11.Width = 100;
            this.rgvKiemTraXuatKho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.rgvKiemTraXuatKho.MasterTemplate.EnableFiltering = true;
            this.rgvKiemTraXuatKho.Name = "rgvKiemTraXuatKho";
            this.rgvKiemTraXuatKho.ReadOnly = true;
            this.rgvKiemTraXuatKho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvKiemTraXuatKho.ShowGroupPanel = false;
            this.rgvKiemTraXuatKho.Size = new System.Drawing.Size(719, 376);
            this.rgvKiemTraXuatKho.TabIndex = 0;
            this.rgvKiemTraXuatKho.Text = "radGridView1";
            this.rgvKiemTraXuatKho.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvKiemTraXuatKho_CellDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.xácNhậnThựcXuấtToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Cập nhật phiếu xuất";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 376);
            this.panel1.TabIndex = 2;
            // 
            // xácNhậnThựcXuấtToolStripMenuItem
            // 
            this.xácNhậnThựcXuấtToolStripMenuItem.Name = "xácNhậnThựcXuấtToolStripMenuItem";
            this.xácNhậnThựcXuấtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xácNhậnThựcXuấtToolStripMenuItem.Text = "Xác nhận thực xuất";
            this.xácNhậnThựcXuấtToolStripMenuItem.Click += new System.EventHandler(this.xácNhậnThựcXuấtToolStripMenuItem_Click);
            // 
            // frmKiemTraXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 376);
            this.Controls.Add(this.rgvKiemTraXuatKho);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKiemTraXuatKho";
            this.Text = "frmKiemTraXuatKho";
            this.Load += new System.EventHandler(this.frmKiemTraXuatKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvKiemTraXuatKho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvKiemTraXuatKho)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        public Telerik.WinControls.UI.RadGridView rgvKiemTraXuatKho;
        private System.Windows.Forms.ToolStripMenuItem xácNhậnThựcXuấtToolStripMenuItem;
    }
}