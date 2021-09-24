namespace ECOPharma2013
{
    partial class frmBoPhan
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
            this.panelBoPhan = new System.Windows.Forms.Panel();
            this.rgvBoBan = new Telerik.WinControls.UI.RadGridView();
            this.panelBoPhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvBoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvBoBan.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBoPhan
            // 
            this.panelBoPhan.Controls.Add(this.rgvBoBan);
            this.panelBoPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoPhan.Location = new System.Drawing.Point(0, 0);
            this.panelBoPhan.Name = "panelBoPhan";
            this.panelBoPhan.Size = new System.Drawing.Size(1096, 421);
            this.panelBoPhan.TabIndex = 0;
            // 
            // rgvBoBan
            // 
            this.rgvBoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvBoBan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvBoBan.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvBoBan
            // 
            this.rgvBoBan.MasterTemplate.AllowAddNewRow = false;
            this.rgvBoBan.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.FieldName = "RecordBPCT";
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "Record BPCT";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colRecordBPCT";
            gridViewTextBoxColumn2.FieldName = "MaBPCon";
            gridViewTextBoxColumn2.HeaderText = "Mã BP Con";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colMaBPCon";
            gridViewTextBoxColumn3.FieldName = "TenBP";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Tên Bộ Phận";
            gridViewTextBoxColumn3.Name = "colTenBP";
            gridViewTextBoxColumn3.Width = 270;
            gridViewTextBoxColumn4.FieldName = "MaBPCha";
            gridViewTextBoxColumn4.HeaderText = "Mã BP Cha";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colMaBPCha";
            gridViewTextBoxColumn5.FieldName = "TenBPCha";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Thuộc Bộ Phận";
            gridViewTextBoxColumn5.Name = "colTenBPCha";
            gridViewTextBoxColumn5.Width = 270;
            gridViewTextBoxColumn6.FieldName = "ThuCap";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Thứ Cấp";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colThuCap";
            gridViewTextBoxColumn7.FieldName = "GhiChu";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn7.Name = "colGhiChu";
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn8.FieldName = "KhongSuDung";
            gridViewTextBoxColumn8.FormatString = "";
            gridViewTextBoxColumn8.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn8.Name = "colKhongSuDung";
            gridViewTextBoxColumn8.Width = 200;
            gridViewTextBoxColumn9.FieldName = "MaBP";
            gridViewTextBoxColumn9.HeaderText = "Mã BP";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "colMaBP";
            this.rgvBoBan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.rgvBoBan.Name = "rgvBoBan";
            this.rgvBoBan.ReadOnly = true;
            this.rgvBoBan.ShowGroupPanel = false;
            this.rgvBoBan.Size = new System.Drawing.Size(1096, 421);
            this.rgvBoBan.TabIndex = 0;
            this.rgvBoBan.Text = "radGridView1";
            this.rgvBoBan.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvBoBan_CellDoubleClick);
            this.rgvBoBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvBoBan_KeyDown);
            // 
            // frmBoPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 421);
            this.Controls.Add(this.panelBoPhan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBoPhan";
            this.Text = "frmBoPhan";
            this.Load += new System.EventHandler(this.frmBoPhan_Load);
            this.panelBoPhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvBoBan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvBoBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoPhan;
        public Telerik.WinControls.UI.RadGridView rgvBoBan;

    }
}