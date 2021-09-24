namespace ECOPharma2013
{
    partial class frmNT_LayPhieuChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNT_LayPhieuChuyen));
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTaiVe = new System.Windows.Forms.ToolStripButton();
            this.rgvPhieuChuyen = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 265);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(550, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(13, 20);
            this.statusTB.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaiVe});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(550, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTaiVe
            // 
            this.btnTaiVe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiVe.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiVe.Image")));
            this.btnTaiVe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaiVe.Name = "btnTaiVe";
            this.btnTaiVe.Size = new System.Drawing.Size(70, 24);
            this.btnTaiVe.Text = "Tải Về";
            this.btnTaiVe.Click += new System.EventHandler(this.btnTaiVe_Click);
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhieuChuyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhieuChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhieuChuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvPhieuChuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhieuChuyen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhieuChuyen.Location = new System.Drawing.Point(0, 27);
            // 
            // rgvPhieuChuyen
            // 
            this.rgvPhieuChuyen.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewCheckBoxColumn1.Width = 46;
            gridViewTextBoxColumn1.FieldName = "NCHid";
            gridViewTextBoxColumn1.HeaderText = "NCHid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNCHid";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 54;
            gridViewTextBoxColumn2.FieldName = "SoPCH";
            gridViewTextBoxColumn2.HeaderText = "Số Phiếu Chuyển";
            gridViewTextBoxColumn2.Name = "colSoPCH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 125;
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
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Từ NT";
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
            this.rgvPhieuChuyen.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.rgvPhieuChuyen.Name = "rgvPhieuChuyen";
            this.rgvPhieuChuyen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhieuChuyen.ShowGroupPanel = false;
            this.rgvPhieuChuyen.Size = new System.Drawing.Size(550, 238);
            this.rgvPhieuChuyen.TabIndex = 2;
            this.rgvPhieuChuyen.Text = "radGridView1";
            // 
            // frmNT_LayPhieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 290);
            this.Controls.Add(this.rgvPhieuChuyen);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNT_LayPhieuChuyen";
            this.Text = "frmNT_LayPhieuChuyen";
            this.Load += new System.EventHandler(this.frmNT_LayPhieuChuyen_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhieuChuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTaiVe;
        private Telerik.WinControls.UI.RadGridView rgvPhieuChuyen;
    }
}