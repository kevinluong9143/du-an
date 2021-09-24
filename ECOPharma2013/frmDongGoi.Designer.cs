namespace ECOPharma2013
{
    partial class frmDongGoi
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
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongGoi));
            this.rgvDongGoi = new Telerik.WinControls.UI.RadGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemLamMoi = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoi)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvDongGoi
            // 
            this.rgvDongGoi.ContextMenuStrip = this.contextMenuStrip1;
            this.rgvDongGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDongGoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDongGoi.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDongGoi
            // 
            this.rgvDongGoi.MasterTemplate.AllowAddNewRow = false;
            this.rgvDongGoi.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "DGid";
            gridViewTextBoxColumn1.HeaderText = "DG id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDGid";
            gridViewTextBoxColumn2.FieldName = "KTid";
            gridViewTextBoxColumn2.HeaderText = "KT id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colKTid";
            gridViewTextBoxColumn3.FieldName = "SoPX";
            gridViewTextBoxColumn3.HeaderText = "Số Phiếu Xuất";
            gridViewTextBoxColumn3.Name = "colSoPX";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "SoDH";
            gridViewTextBoxColumn4.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn4.Name = "colSoDH";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "NgayDG";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Đóng Gói";
            gridViewTextBoxColumn5.Name = "colNgayDG";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "IsXong";
            gridViewTextBoxColumn6.HeaderText = "Đã Đóng Xong";
            gridViewTextBoxColumn6.Name = "colIsXong";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "NgayDGXong";
            gridViewTextBoxColumn7.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn7.HeaderText = "Ngày Đóng Xong";
            gridViewTextBoxColumn7.Name = "colNgayDGXong";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "UserDG";
            gridViewTextBoxColumn8.HeaderText = "Nhân Viên Đóng Gói id";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserDG";
            gridViewTextBoxColumn9.FieldName = "HoTen";
            gridViewTextBoxColumn9.HeaderText = "Nhân Viên Đóng Gói";
            gridViewTextBoxColumn9.Name = "colHoTen";
            gridViewTextBoxColumn9.Width = 150;
            this.rgvDongGoi.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvDongGoi.MasterTemplate.EnableFiltering = true;
            this.rgvDongGoi.Name = "rgvDongGoi";
            this.rgvDongGoi.ReadOnly = true;
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            this.rgvDongGoi.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.rgvDongGoi.ShowGroupPanel = false;
            this.rgvDongGoi.Size = new System.Drawing.Size(808, 314);
            this.rgvDongGoi.TabIndex = 0;
            this.rgvDongGoi.Text = "radGridView1";
            this.rgvDongGoi.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDongGoi_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLamMoi});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // ToolStripMenuItemLamMoi
            // 
            this.ToolStripMenuItemLamMoi.Name = "ToolStripMenuItemLamMoi";
            this.ToolStripMenuItemLamMoi.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemLamMoi.Text = "&Làm mới dữ liệu";
            this.ToolStripMenuItemLamMoi.Click += new System.EventHandler(this.ToolStripMenuItemLamMoi_Click);
            // 
            // frmDongGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 314);
            this.Controls.Add(this.rgvDongGoi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDongGoi";
            this.Text = "frmDongGoi";
            this.Load += new System.EventHandler(this.frmDongGoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoi)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLamMoi;
        public Telerik.WinControls.UI.RadGridView rgvDongGoi;
    }
}