namespace ECOPharma2013
{
    partial class frmNT_KetCa
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvDSKetCa = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSKetCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSKetCa.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDSKetCa
            // 
            this.rgvDSKetCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSKetCa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSKetCa.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSKetCa
            // 
            this.rgvDSKetCa.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn10.FieldName = "CKCid";
            gridViewTextBoxColumn10.HeaderText = "CKC id";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "colCKCid";
            gridViewTextBoxColumn11.FieldName = "SoCa";
            gridViewTextBoxColumn11.HeaderText = "Ca Thứ";
            gridViewTextBoxColumn11.Name = "colSoCa";
            gridViewTextBoxColumn11.Width = 100;
            gridViewTextBoxColumn12.FieldName = "NgayBatDau";
            gridViewTextBoxColumn12.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn12.HeaderText = "Ngày Bắt Đầu";
            gridViewTextBoxColumn12.Name = "colNgayBatDau";
            gridViewTextBoxColumn12.Width = 190;
            gridViewTextBoxColumn13.FieldName = "NgayKetThuc";
            gridViewTextBoxColumn13.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn13.HeaderText = "Ngày Kết Ca";
            gridViewTextBoxColumn13.Name = "colNgayKetThuc";
            gridViewTextBoxColumn13.Width = 190;
            gridViewTextBoxColumn14.FieldName = "TenMayThuNgan";
            gridViewTextBoxColumn14.HeaderText = "Tên Máy Thu Ngân";
            gridViewTextBoxColumn14.Name = "colTenMayThuNgan";
            gridViewTextBoxColumn14.Width = 150;
            gridViewTextBoxColumn15.FieldName = "IsDaKetCa";
            gridViewTextBoxColumn15.HeaderText = "Đã Kết Ca";
            gridViewTextBoxColumn15.Name = "colIsDaKetCa";
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn16.FieldName = "IsDaXacNhan";
            gridViewTextBoxColumn16.HeaderText = "Đã Xác Nhận";
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "colIsDaXacNhan";
            gridViewTextBoxColumn17.FieldName = "UserID";
            gridViewTextBoxColumn17.HeaderText = "User ID";
            gridViewTextBoxColumn17.IsVisible = false;
            gridViewTextBoxColumn17.Name = "colUserID";
            gridViewTextBoxColumn18.FieldName = "HoTen";
            gridViewTextBoxColumn18.HeaderText = "Nhân Viên Kết Ca";
            gridViewTextBoxColumn18.Name = "colHoTen";
            gridViewTextBoxColumn18.Width = 200;
            this.rgvDSKetCa.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18});
            this.rgvDSKetCa.Name = "rgvDSKetCa";
            this.rgvDSKetCa.ReadOnly = true;
            this.rgvDSKetCa.ShowGroupPanel = false;
            this.rgvDSKetCa.Size = new System.Drawing.Size(925, 367);
            this.rgvDSKetCa.TabIndex = 0;
            this.rgvDSKetCa.Text = "radGridView1";
            this.rgvDSKetCa.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDSKetCa_CellDoubleClick);
            this.rgvDSKetCa.Click += new System.EventHandler(this.rgvDSKetCa_Click);
            // 
            // frmNT_KetCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 367);
            this.Controls.Add(this.rgvDSKetCa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNT_KetCa";
            this.Text = "Kết Ca";
            this.Load += new System.EventHandler(this.frmNT_KetCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSKetCa.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSKetCa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDSKetCa;

    }
}