namespace ECOPharma2013
{
    partial class frmChuyenKhoXacNhan
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvChuyenKho = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenKho.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvChuyenKho
            // 
            this.rgvChuyenKho.BackColor = System.Drawing.SystemColors.Control;
            this.rgvChuyenKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvChuyenKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvChuyenKho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvChuyenKho.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvChuyenKho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvChuyenKho.Location = new System.Drawing.Point(0, 0);
            this.rgvChuyenKho.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvChuyenKho
            // 
            this.rgvChuyenKho.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.FieldName = "CKid";
            gridViewTextBoxColumn1.HeaderText = "CKid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colCKid";
            gridViewTextBoxColumn2.FieldName = "SoPCK";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Chuyển";
            gridViewTextBoxColumn2.Name = "colSoPCK";
            gridViewTextBoxColumn2.Width = 140;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "NgayTao";
            gridViewTextBoxColumn4.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn4.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn4.Name = "colNgayTao";
            gridViewTextBoxColumn4.Width = 140;
            gridViewTextBoxColumn5.FieldName = "UserTao";
            gridViewTextBoxColumn5.HeaderText = "UserTao";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colUserTao";
            gridViewTextBoxColumn5.Width = 250;
            gridViewTextBoxColumn6.FieldName = "NVTao";
            gridViewTextBoxColumn6.HeaderText = "NV Tạo";
            gridViewTextBoxColumn6.Name = "colNVTao";
            gridViewTextBoxColumn6.Width = 250;
            this.rgvChuyenKho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvChuyenKho.Name = "rgvChuyenKho";
            this.rgvChuyenKho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvChuyenKho.ShowGroupPanel = false;
            this.rgvChuyenKho.Size = new System.Drawing.Size(712, 318);
            this.rgvChuyenKho.TabIndex = 0;
            this.rgvChuyenKho.Text = "radGridView1";
            // 
            // frmChuyenKhoXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 318);
            this.Controls.Add(this.rgvChuyenKho);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChuyenKhoXacNhan";
            this.Text = "Chuyển Kho Xác Nhận";
            this.Load += new System.EventHandler(this.frmChuyenKhoXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenKho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvChuyenKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvChuyenKho;

    }
}