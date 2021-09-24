namespace ECOPharma2013
{
    partial class frmNT_LayPhieuDieuChinhTon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNT_LayPhieuDieuChinhTon));
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.rbtnTaiVe = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.rgvPhieuDieuChinh = new Telerik.WinControls.UI.RadGridView();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rbtnTaiVe});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(932, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // rbtnTaiVe
            // 
            this.rbtnTaiVe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTaiVe.Image = ((System.Drawing.Image)(resources.GetObject("rbtnTaiVe.Image")));
            this.rbtnTaiVe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rbtnTaiVe.Name = "rbtnTaiVe";
            this.rbtnTaiVe.Size = new System.Drawing.Size(70, 24);
            this.rbtnTaiVe.Text = "Tải Về";
            this.rbtnTaiVe.Click += new System.EventHandler(this.rbtnTaiVe_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(932, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(13, 20);
            this.statusTB.Text = " ";
            // 
            // rgvPhieuDieuChinh
            // 
            this.rgvPhieuDieuChinh.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuDieuChinh.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuDieuChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuDieuChinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuDieuChinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuDieuChinh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuDieuChinh.Location = new System.Drawing.Point(0, 27);
            // 
            // rgvPhieuDieuChinh
            // 
            this.rgvPhieuDieuChinh.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.FieldName = "DCTKid";
            gridViewTextBoxColumn1.HeaderText = "DCTKid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDCTKid";
            gridViewTextBoxColumn2.FieldName = "SoPDC";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Điều Chỉnh";
            gridViewTextBoxColumn2.Name = "colSoPDC";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "NgayXacNhan";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
            gridViewTextBoxColumn3.HeaderText = "Ngày Điều Chỉnh";
            gridViewTextBoxColumn3.Name = "colNgayXacNhan";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.FieldName = "NTid";
            gridViewTextBoxColumn4.HeaderText = "NTid";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colNTid";
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Nơi Được Điều Chỉnh";
            gridViewTextBoxColumn5.Name = "colTenNT";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "GhiChu";
            gridViewTextBoxColumn6.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn6.Name = "colGhiChu";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "IsKhoDacBiet";
            gridViewTextBoxColumn7.HeaderText = "Hàng Đặc Biệt";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colIsKhoDacBiet";
            this.rgvPhieuDieuChinh.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.rgvPhieuDieuChinh.Name = "rgvPhieuDieuChinh";
            this.rgvPhieuDieuChinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuDieuChinh.ShowGroupPanel = false;
            this.rgvPhieuDieuChinh.Size = new System.Drawing.Size(932, 210);
            this.rgvPhieuDieuChinh.TabIndex = 2;
            this.rgvPhieuDieuChinh.Text = "radGridView1";
            // 
            // frmNT_LayPhieuDieuChinhTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 262);
            this.Controls.Add(this.rgvPhieuDieuChinh);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmNT_LayPhieuDieuChinhTon";
            this.Text = "frmNT_LayPhieuDieuChinhTon";
            this.Load += new System.EventHandler(this.frmNT_LayPhieuDieuChinhTon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuDieuChinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton rbtnTaiVe;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        public Telerik.WinControls.UI.RadGridView rgvPhieuDieuChinh;
    }
}