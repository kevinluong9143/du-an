namespace ECOPharma2013
{
    partial class frmNT_DieuChinhHSDXacNhan
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
            this.rgvDieuChinh = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDieuChinh.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDieuChinh
            // 
            this.rgvDieuChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDieuChinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDieuChinh.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDieuChinh
            // 
            this.rgvDieuChinh.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewTextBoxColumn1.FieldName = "DCHDid";
            gridViewTextBoxColumn1.HeaderText = "DCTKid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDCHDid";
            gridViewTextBoxColumn2.FieldName = "SoPDC";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Điều Chỉnh";
            gridViewTextBoxColumn2.Name = "colSoPDC";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "NgayChinh";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chỉnh";
            gridViewTextBoxColumn3.Name = "colNgayChinh";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "GhiChu";
            gridViewTextBoxColumn4.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn4.Name = "colGhiChu";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 250;
            this.rgvDieuChinh.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvDieuChinh.Name = "rgvDieuChinh";
            this.rgvDieuChinh.ShowGroupPanel = false;
            this.rgvDieuChinh.Size = new System.Drawing.Size(639, 255);
            this.rgvDieuChinh.TabIndex = 1;
            this.rgvDieuChinh.Text = "radGridView1";
            // 
            // frmNT_DieuChinhHSDXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 255);
            this.Controls.Add(this.rgvDieuChinh);
            this.Name = "frmNT_DieuChinhHSDXacNhan";
            this.Text = "frmNT_DieuChinhHSDXacNhan";
            this.Load += new System.EventHandler(this.frmNT_DieuChinhHSDXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDieuChinh.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDieuChinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvDieuChinh;
    }
}