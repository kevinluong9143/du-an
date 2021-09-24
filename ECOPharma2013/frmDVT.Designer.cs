namespace ECOPharma2013
{
    partial class frmDVT
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
            this.rgvDVT = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDVT.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDVT
            // 
            this.rgvDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDVT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDVT.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDVT
            // 
            this.rgvDVT.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "DVTID";
            gridViewTextBoxColumn1.HeaderText = "DVT ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDVTID";
            gridViewTextBoxColumn2.FieldName = "TenDVT";
            gridViewTextBoxColumn2.HeaderText = "Tên ĐVT";
            gridViewTextBoxColumn2.Name = "colTenDVT";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.FieldName = "KhongSuDung";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colKhongSuDung";
            gridViewTextBoxColumn4.Width = 130;
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
            gridViewTextBoxColumn7.FieldName = "HoTen";
            gridViewTextBoxColumn7.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn7.Name = "colHoTen";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "UserID";
            gridViewTextBoxColumn8.HeaderText = "Mã NV Cập Nhật";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserID";
            this.rgvDVT.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvDVT.MasterTemplate.EnableGrouping = false;
            this.rgvDVT.Name = "rgvDVT";
            this.rgvDVT.ReadOnly = true;
            this.rgvDVT.Size = new System.Drawing.Size(988, 306);
            this.rgvDVT.TabIndex = 0;
            this.rgvDVT.Text = "radGridView1";
            this.rgvDVT.DoubleClick += new System.EventHandler(this.rgvDVT_DoubleClick);
            this.rgvDVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvDVT_KeyDown);
            // 
            // frmDVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 306);
            this.Controls.Add(this.rgvDVT);
            this.Name = "frmDVT";
            this.Text = "frmDVT";
            this.Load += new System.EventHandler(this.frmDVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDVT.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDVT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDVT;

    }
}