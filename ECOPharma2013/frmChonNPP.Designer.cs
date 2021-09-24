namespace ECOPharma2013
{
    partial class frmChonNPP
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn28 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSNPP = new Telerik.WinControls.UI.RadGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSNPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSNPP.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSNPP
            // 
            this.rgvDSNPP.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDSNPP.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDSNPP.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgvDSNPP.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.rgvDSNPP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDSNPP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDSNPP.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSNPP
            // 
            this.rgvDSNPP.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn15.FieldName = "NPPid";
            gridViewTextBoxColumn15.HeaderText = "NPP id";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "NPPid";
            gridViewTextBoxColumn16.FieldName = "TenNPP";
            gridViewTextBoxColumn16.HeaderText = "Tên NPP";
            gridViewTextBoxColumn16.Name = "TenNPP";
            gridViewTextBoxColumn16.Width = 250;
            gridViewTextBoxColumn17.FieldName = "GhiChu1";
            gridViewTextBoxColumn17.HeaderText = "Ghi Chú 1";
            gridViewTextBoxColumn17.Name = "GhiChu1";
            gridViewTextBoxColumn17.Width = 100;
            gridViewTextBoxColumn18.FieldName = "GiaMuaChuaTaxChuaChietKhau";
            gridViewTextBoxColumn18.FormatString = "{0:N2}";
            gridViewTextBoxColumn18.HeaderText = "GM Chưa Tax Chưa CK";
            gridViewTextBoxColumn18.Name = "GiaMuaChuaTaxChuaChietKhau";
            gridViewTextBoxColumn18.Width = 100;
            gridViewTextBoxColumn19.FieldName = "PhanTramChietKhau";
            gridViewTextBoxColumn19.FormatString = "{0:N2}";
            gridViewTextBoxColumn19.HeaderText = "Phần Trăm CK";
            gridViewTextBoxColumn19.Name = "PhanTramChietKhau";
            gridViewTextBoxColumn19.Width = 100;
            gridViewTextBoxColumn20.FieldName = "GiaMuaChuaTaxDaChietKhau";
            gridViewTextBoxColumn20.FormatString = "{0:N2}";
            gridViewTextBoxColumn20.HeaderText = "GM Chưa Tax Đã CK";
            gridViewTextBoxColumn20.Name = "GiaMuaChuaTaxDaChietKhau";
            gridViewTextBoxColumn20.Width = 100;
            gridViewTextBoxColumn21.FieldName = "TAX";
            gridViewTextBoxColumn21.FormatString = "{0:N2}";
            gridViewTextBoxColumn21.HeaderText = "TAX";
            gridViewTextBoxColumn21.Name = "TAX";
            gridViewTextBoxColumn21.Width = 80;
            gridViewTextBoxColumn22.FieldName = "SPid";
            gridViewTextBoxColumn22.HeaderText = "SP id";
            gridViewTextBoxColumn22.IsVisible = false;
            gridViewTextBoxColumn22.Name = "SPid";
            gridViewTextBoxColumn23.FieldName = "MaSP";
            gridViewTextBoxColumn23.HeaderText = "Mã SP";
            gridViewTextBoxColumn23.Name = "MaSP";
            gridViewTextBoxColumn23.Width = 80;
            gridViewTextBoxColumn24.FieldName = "TenSP";
            gridViewTextBoxColumn24.HeaderText = "Tên SP";
            gridViewTextBoxColumn24.Name = "TenSP";
            gridViewTextBoxColumn24.Width = 200;
            gridViewTextBoxColumn25.FieldName = "NSXid";
            gridViewTextBoxColumn25.HeaderText = "NSX id";
            gridViewTextBoxColumn25.IsVisible = false;
            gridViewTextBoxColumn25.Name = "NSXid";
            gridViewTextBoxColumn26.FieldName = "TenNSX";
            gridViewTextBoxColumn26.HeaderText = "NSX";
            gridViewTextBoxColumn26.Name = "TenNSX";
            gridViewTextBoxColumn26.Width = 100;
            gridViewTextBoxColumn27.FieldName = "GhiChu2";
            gridViewTextBoxColumn27.HeaderText = "Ghi Chú 2";
            gridViewTextBoxColumn27.Name = "GhiChu2";
            gridViewTextBoxColumn27.Width = 100;
            gridViewTextBoxColumn28.FieldName = "GhiChu3";
            gridViewTextBoxColumn28.HeaderText = "Ghi Chú 3";
            gridViewTextBoxColumn28.Name = "GhiChu3";
            gridViewTextBoxColumn28.Width = 100;
            this.rgvDSNPP.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24,
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27,
            gridViewTextBoxColumn28});
            this.rgvDSNPP.Name = "rgvDSNPP";
            this.rgvDSNPP.ReadOnly = true;
            this.rgvDSNPP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDSNPP.ShowGroupPanel = false;
            this.rgvDSNPP.Size = new System.Drawing.Size(749, 179);
            this.rgvDSNPP.TabIndex = 0;
            this.rgvDSNPP.Text = "radGridView1";
            this.rgvDSNPP.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSNPP_CellDoubleClick);
            this.rgvDSNPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterTemplate_KeyDown);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(313, 185);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(113, 42);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChonNPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 239);
            this.ControlBox = false;
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.rgvDSNPP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmChonNPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3 Nhà Phân Phối Mua Hàng Gần Đây";
            this.Load += new System.EventHandler(this.frmChonNPP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChonNPP_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSNPP.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSNPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvDSNPP;
        private System.Windows.Forms.Button btnDong;
    }
}