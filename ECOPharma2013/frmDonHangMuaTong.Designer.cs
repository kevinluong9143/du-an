namespace ECOPharma2013
{
    partial class frmDonHangMuaTong
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.tableLayoutPanelDHMTong = new System.Windows.Forms.TableLayoutPanel();
            this.rgvDSDHMTong = new Telerik.WinControls.UI.RadGridView();
            this.btnthemDHT = new System.Windows.Forms.Button();
            this.tableLayoutPanelDHMTong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMTong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMTong.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDHMTong
            // 
            this.tableLayoutPanelDHMTong.ColumnCount = 2;
            this.tableLayoutPanelDHMTong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDHMTong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanelDHMTong.Controls.Add(this.rgvDSDHMTong, 0, 0);
            this.tableLayoutPanelDHMTong.Controls.Add(this.btnthemDHT, 1, 0);
            this.tableLayoutPanelDHMTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDHMTong.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDHMTong.Name = "tableLayoutPanelDHMTong";
            this.tableLayoutPanelDHMTong.RowCount = 1;
            this.tableLayoutPanelDHMTong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDHMTong.Size = new System.Drawing.Size(765, 532);
            this.tableLayoutPanelDHMTong.TabIndex = 0;
            // 
            // rgvDSDHMTong
            // 
            this.rgvDSDHMTong.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSDHMTong.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSDHMTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSDHMTong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDSDHMTong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSDHMTong.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSDHMTong.Location = new System.Drawing.Point(3, 3);
            // 
            // rgvDSDHMTong
            // 
            this.rgvDSDHMTong.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "DHMTongid";
            gridViewTextBoxColumn1.HeaderText = "DHMTong id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDHMTongid";
            gridViewTextBoxColumn2.FieldName = "SoDHMT";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Số Đơn Hàng Tổng";
            gridViewTextBoxColumn2.Name = "colSoDHMT";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "TinhTrang";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Tình Trạng";
            gridViewTextBoxColumn3.Name = "colTinhTrang";
            gridViewTextBoxColumn3.Width = 212;
            gridViewTextBoxColumn4.FieldName = "GhiChu";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn4.Name = "colGhiChu";
            gridViewTextBoxColumn4.Width = 212;
            gridViewTextBoxColumn5.FieldName = "NgayTao";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn5.Name = "colNgayTao";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "NVTao";
            gridViewTextBoxColumn6.HeaderText = "NV Tạo id";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colNVTao";
            gridViewTextBoxColumn7.FieldName = "TenNVTao";
            gridViewTextBoxColumn7.HeaderText = "Người Tạo";
            gridViewTextBoxColumn7.Name = "colTenNVTao";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "LastUD";
            gridViewTextBoxColumn8.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn8.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colLastUD";
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.FieldName = "NVUD";
            gridViewTextBoxColumn9.HeaderText = "NV Cập Nhật id";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "colNVUD";
            gridViewTextBoxColumn10.FieldName = "TenNVCapNhat";
            gridViewTextBoxColumn10.HeaderText = "NV Cập Nhật";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colTenNVCapNhat";
            gridViewTextBoxColumn11.FieldName = "IsXoa";
            gridViewTextBoxColumn11.HeaderText = "Is Xoa";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "colIsXoa";
            gridViewTextBoxColumn12.FieldName = "TinhTrangID";
            gridViewTextBoxColumn12.HeaderText = "Tình Trạng id";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "colTinhTrangID";
            this.rgvDSDHMTong.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.rgvDSDHMTong.MasterTemplate.EnableFiltering = true;
            this.rgvDSDHMTong.Name = "rgvDSDHMTong";
            this.rgvDSDHMTong.ReadOnly = true;
            this.rgvDSDHMTong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSDHMTong.ShowGroupPanel = false;
            this.rgvDSDHMTong.Size = new System.Drawing.Size(619, 526);
            this.rgvDSDHMTong.TabIndex = 1;
            this.rgvDSDHMTong.Text = "rgvDSDonHangXuat";
            this.rgvDSDHMTong.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSDHMTong_CellDoubleClick);
            this.rgvDSDHMTong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvDSDHMTong_KeyDown);
            // 
            // btnthemDHT
            // 
            this.btnthemDHT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemDHT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnthemDHT.Location = new System.Drawing.Point(628, 3);
            this.btnthemDHT.Name = "btnthemDHT";
            this.btnthemDHT.Size = new System.Drawing.Size(134, 49);
            this.btnthemDHT.TabIndex = 0;
            this.btnthemDHT.Text = "Thêm ĐH Tổng";
            this.btnthemDHT.UseVisualStyleBackColor = true;
            this.btnthemDHT.Click += new System.EventHandler(this.btnthemDHT_Click);
            // 
            // frmDonHangMuaTong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 532);
            this.Controls.Add(this.tableLayoutPanelDHMTong);
            this.Name = "frmDonHangMuaTong";
            this.Text = "frmDonHangMuaTong";
            this.Load += new System.EventHandler(this.frmDonHangMuaTong_Load);
            this.tableLayoutPanelDHMTong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMTong.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSDHMTong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDHMTong;
        private System.Windows.Forms.Button btnthemDHT;
        public Telerik.WinControls.UI.RadGridView rgvDSDHMTong;

    }
}