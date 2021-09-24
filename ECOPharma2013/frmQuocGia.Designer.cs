namespace ECOPharma2013
{
    partial class frmQuocGia
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSQuocGia = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSQuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSQuocGia.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSQuocGia
            // 
            this.rgvDSQuocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSQuocGia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSQuocGia.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSQuocGia
            // 
            this.rgvDSQuocGia.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn5.FieldName = "QGid";
            gridViewTextBoxColumn5.HeaderText = "QG id";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colQGid";
            gridViewTextBoxColumn6.FieldName = "TenQuocGia";
            gridViewTextBoxColumn6.HeaderText = "Quốc Gia";
            gridViewTextBoxColumn6.Name = "colTenQuocGia";
            gridViewTextBoxColumn6.Width = 180;
            gridViewTextBoxColumn7.FieldName = "GhiChu";
            gridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn7.Name = "colGhiChu";
            gridViewTextBoxColumn7.Width = 180;
            gridViewTextBoxColumn8.FieldName = "KhongSuDung";
            gridViewTextBoxColumn8.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn8.Name = "colKhongSuDung";
            gridViewTextBoxColumn8.Width = 180;
            this.rgvDSQuocGia.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvDSQuocGia.MasterTemplate.EnableFiltering = true;
            this.rgvDSQuocGia.Name = "rgvDSQuocGia";
            this.rgvDSQuocGia.ReadOnly = true;
            this.rgvDSQuocGia.ShowGroupPanel = false;
            this.rgvDSQuocGia.Size = new System.Drawing.Size(551, 315);
            this.rgvDSQuocGia.TabIndex = 0;
            this.rgvDSQuocGia.Text = "radGridView1";
            this.rgvDSQuocGia.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvDSQuocGia_RowFormatting);
            // 
            // frmQuocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 315);
            this.Controls.Add(this.rgvDSQuocGia);
            this.Name = "frmQuocGia";
            this.Text = "frmQuocGia";
            this.Load += new System.EventHandler(this.frmQuocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSQuocGia.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSQuocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSQuocGia;

    }
}