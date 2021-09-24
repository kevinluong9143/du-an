namespace ECOPharma2013
{
    partial class frmNhomNguoiDung
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
            this.rgvNhomNguoiDung = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvNhomNguoiDung
            // 
            this.rgvNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvNhomNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvNhomNguoiDung.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvNhomNguoiDung
            // 
            this.rgvNhomNguoiDung.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NhomNDid";
            gridViewTextBoxColumn1.HeaderText = "Nhom ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNhomNDid";
            gridViewTextBoxColumn2.FieldName = "TenNhom";
            gridViewTextBoxColumn2.HeaderText = "Tên Nhóm";
            gridViewTextBoxColumn2.Name = "colTenNhom";
            gridViewTextBoxColumn2.Width = 300;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.FieldName = "IsKhongDung";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colIsKhongDung";
            gridViewTextBoxColumn4.Width = 150;
            this.rgvNhomNguoiDung.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvNhomNguoiDung.Name = "rgvNhomNguoiDung";
            this.rgvNhomNguoiDung.ReadOnly = true;
            this.rgvNhomNguoiDung.ShowGroupPanel = false;
            this.rgvNhomNguoiDung.Size = new System.Drawing.Size(413, 293);
            this.rgvNhomNguoiDung.TabIndex = 0;
            this.rgvNhomNguoiDung.Text = "radGridView1";
            this.rgvNhomNguoiDung.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvNhomNguoiDung_CellDoubleClick);
            // 
            // frmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 293);
            this.Controls.Add(this.rgvNhomNguoiDung);
            this.Name = "frmNhomNguoiDung";
            this.Text = "frmNhomNguoiDung";
            this.Load += new System.EventHandler(this.frmNhomNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvNhomNguoiDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvNhomNguoiDung;

    }
}