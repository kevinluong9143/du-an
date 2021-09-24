namespace ECOPharma2013
{
    partial class frmNhanTraHangXacNhan
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvPhieuTra = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuTra.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuTra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuTra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuTra.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhieuTra
            // 
            this.rgvPhieuTra.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.FieldName = "Chon";
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewCheckBoxColumn1.Width = 46;
            gridViewTextBoxColumn1.FieldName = "NTHid";
            gridViewTextBoxColumn1.HeaderText = "NTHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNTHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 53;
            gridViewTextBoxColumn2.FieldName = "SoPTH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Trả Hàng";
            gridViewTextBoxColumn2.Name = "colSoPTH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 135;
            gridViewTextBoxColumn3.FieldName = "NgayChungTu";
            gridViewTextBoxColumn3.HeaderText = "Ngày Chứng Từ";
            gridViewTextBoxColumn3.Name = "colNgayChungTu";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 116;
            gridViewTextBoxColumn4.FieldName = "Fromm";
            gridViewTextBoxColumn4.HeaderText = "Fromm";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colFromm";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 58;
            gridViewTextBoxColumn5.FieldName = "NoiTra";
            gridViewTextBoxColumn5.HeaderText = "Nơi Trả";
            gridViewTextBoxColumn5.Name = "colNoiTra";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 60;
            gridViewTextBoxColumn6.FieldName = "LoaiHangTra";
            gridViewTextBoxColumn6.HeaderText = "LoaiHangTra";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colLoaiHangTra";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 95;
            gridViewTextBoxColumn7.FieldName = "TenLoaiHangTra";
            gridViewTextBoxColumn7.HeaderText = "Loại Hàng Trả";
            gridViewTextBoxColumn7.Name = "colTenLoaiHangTra";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 104;
            gridViewTextBoxColumn8.FieldName = "GhiChu";
            gridViewTextBoxColumn8.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn8.Name = "colGhiChu";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 64;
            this.rgvPhieuTra.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvPhieuTra.Name = "rgvPhieuTra";
            this.rgvPhieuTra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuTra.ShowGroupPanel = false;
            this.rgvPhieuTra.Size = new System.Drawing.Size(570, 297);
            this.rgvPhieuTra.TabIndex = 0;
            this.rgvPhieuTra.Text = "radGridView1";
            // 
            // frmNhanTraHangXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 297);
            this.Controls.Add(this.rgvPhieuTra);
            this.Name = "frmNhanTraHangXacNhan";
            this.Text = "frmNhanTraHangXacNhan";
            this.Load += new System.EventHandler(this.frmNhanTraHangXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuTra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvPhieuTra;
    }
}