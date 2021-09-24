namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_GiaTheoNPP
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvChiTiet = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cbbSanPham = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChiTiet.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham.EditorControl.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rgvChiTiet, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 472);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rgvChiTiet
            // 
            this.rgvChiTiet.BackColor = System.Drawing.SystemColors.Control;
            this.rgvChiTiet.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvChiTiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvChiTiet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvChiTiet.Location = new System.Drawing.Point(3, 43);
            // 
            // rgvChiTiet
            // 
            this.rgvChiTiet.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "STT";
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "colSTT";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.FieldName = "MaSP";
            gridViewTextBoxColumn2.HeaderText = "Mã SP";
            gridViewTextBoxColumn2.Name = "colMaSP";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.FieldName = "TenSP";
            gridViewTextBoxColumn3.HeaderText = "Tên SP";
            gridViewTextBoxColumn3.Name = "colTenSP";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.DataEditFormatString = "";
            gridViewTextBoxColumn4.FieldName = "GiaMua";
            gridViewTextBoxColumn4.FormatString = "{0:N2}";
            gridViewTextBoxColumn4.HeaderText = "Giá Mua";
            gridViewTextBoxColumn4.Name = "colGiaMua";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.DataEditFormatString = "";
            gridViewTextBoxColumn5.FieldName = "ChietKhau";
            gridViewTextBoxColumn5.FormatString = "{0:N2}";
            gridViewTextBoxColumn5.HeaderText = "Chiết Khấu (%)";
            gridViewTextBoxColumn5.Name = "colChietKhau";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn6.DataEditFormatString = "";
            gridViewTextBoxColumn6.FieldName = "Tax";
            gridViewTextBoxColumn6.FormatString = "{0:N2}";
            gridViewTextBoxColumn6.HeaderText = "Thuế (%)";
            gridViewTextBoxColumn6.Name = "colTax";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn7.FieldName = "TenNPP";
            gridViewTextBoxColumn7.HeaderText = "Nhà Phân Phối";
            gridViewTextBoxColumn7.Name = "colTenNPP";
            gridViewTextBoxColumn7.Width = 250;
            gridViewTextBoxColumn8.FieldName = "LyDo";
            gridViewTextBoxColumn8.HeaderText = "Lý Do";
            gridViewTextBoxColumn8.Name = "colLyDo";
            gridViewTextBoxColumn8.Width = 250;
            gridViewTextBoxColumn9.DataEditFormatString = "";
            gridViewTextBoxColumn9.FieldName = "NgayDieuChinh";
            gridViewTextBoxColumn9.FormatString = "{0:dd/MM/yyyy HH:mm}";
            gridViewTextBoxColumn9.HeaderText = "Ngày Điều Chỉnh";
            gridViewTextBoxColumn9.Name = "colNgayDieuChinh";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "UserName";
            gridViewTextBoxColumn10.HeaderText = "User Điều Chỉnh";
            gridViewTextBoxColumn10.Name = "colUserName";
            gridViewTextBoxColumn10.Width = 100;
            this.rgvChiTiet.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            this.rgvChiTiet.MasterTemplate.EnableFiltering = true;
            this.rgvChiTiet.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvChiTiet.Name = "rgvChiTiet";
            this.rgvChiTiet.ReadOnly = true;
            this.rgvChiTiet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvChiTiet.ShowGroupPanel = false;
            this.rgvChiTiet.Size = new System.Drawing.Size(1069, 426);
            this.rgvChiTiet.TabIndex = 4;
            this.rgvChiTiet.Text = "radGridView1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableLayoutPanel2.Controls.Add(this.btnExcel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbbSanPham, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1069, 34);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcel.Location = new System.Drawing.Point(514, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(98, 28);
            this.btnExcel.TabIndex = 37;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXem.Location = new System.Drawing.Point(410, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(98, 28);
            this.btnXem.TabIndex = 36;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 25);
            this.radLabel1.TabIndex = 28;
            this.radLabel1.Text = "Sản Phẩm:";
            // 
            // cbbSanPham
            // 
            // 
            // cbbSanPham.NestedRadGridView
            // 
            this.cbbSanPham.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cbbSanPham.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSanPham.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbbSanPham.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cbbSanPham.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cbbSanPham.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cbbSanPham.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cbbSanPham.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cbbSanPham.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cbbSanPham.EditorControl.Name = "NestedRadGridView";
            this.cbbSanPham.EditorControl.ReadOnly = true;
            this.cbbSanPham.EditorControl.ShowGroupPanel = false;
            this.cbbSanPham.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cbbSanPham.EditorControl.TabIndex = 0;
            this.cbbSanPham.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSanPham.Location = new System.Drawing.Point(93, 3);
            this.cbbSanPham.Name = "cbbSanPham";
            // 
            // 
            // 
            this.cbbSanPham.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.cbbSanPham.RootElement.StretchVertically = true;
            this.cbbSanPham.Size = new System.Drawing.Size(311, 26);
            this.cbbSanPham.TabIndex = 35;
            this.cbbSanPham.TabStop = false;
            // 
            // Fr_BC_GiaTheoNPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fr_BC_GiaTheoNPP";
            this.Text = "Lịch Sử Thay Đổi Giá Theo NPP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_BC_GiaTheoNPP_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvChiTiet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChiTiet)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView rgvChiTiet;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cbbSanPham;
        private Telerik.WinControls.UI.RadButton btnXem;
        private Telerik.WinControls.UI.RadButton btnExcel;
    }
}