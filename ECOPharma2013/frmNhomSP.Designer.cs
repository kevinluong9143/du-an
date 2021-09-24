namespace ECOPharma2013
{
    partial class frmNhomSP
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
            this.rgvNhomSP = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomSP.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvNhomSP
            // 
            this.rgvNhomSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvNhomSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvNhomSP.Location = new System.Drawing.Point(0, 0);
            this.rgvNhomSP.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvNhomSP
            // 
            this.rgvNhomSP.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NSPID";
            gridViewTextBoxColumn1.HeaderText = "Nhóm SPID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNSPID";
            gridViewTextBoxColumn2.FieldName = "TenNSP";
            gridViewTextBoxColumn2.HeaderText = "Tên Nhóm Sản Phẩm";
            gridViewTextBoxColumn2.Name = "colTenNSP";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "KhongSuDung";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colKhongSuDung";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "LastUD";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn5.Name = "colLastUD";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "NgayTao";
            gridViewTextBoxColumn6.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn6.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn6.Name = "colNgayTao";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "UserName";
            gridViewTextBoxColumn7.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn7.Name = "colUserName";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "UserID";
            gridViewTextBoxColumn8.HeaderText = "MÃ NV";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserID";
            this.rgvNhomSP.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvNhomSP.Name = "rgvNhomSP";
            this.rgvNhomSP.ReadOnly = true;
            this.rgvNhomSP.ShowGroupPanel = false;
            this.rgvNhomSP.Size = new System.Drawing.Size(926, 382);
            this.rgvNhomSP.TabIndex = 0;
            this.rgvNhomSP.Text = "radGridView1";
            this.rgvNhomSP.DoubleClick += new System.EventHandler(this.rgvNhomSP_DoubleClick);
            this.rgvNhomSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvNhomSP_KeyDown);
            // 
            // frmNhomSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 382);
            this.Controls.Add(this.rgvNhomSP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhomSP";
            this.Text = "frmNhomSP";
            this.Load += new System.EventHandler(this.frmNhomSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomSP.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvNhomSP;

    }
}