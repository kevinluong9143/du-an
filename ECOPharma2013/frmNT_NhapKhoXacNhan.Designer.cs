namespace ECOPharma2013
{
    partial class frmNT_NhapKhoXacNhan
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
            this.statusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rgvDSPhieuNhap = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(14, 21);
            this.statusTB.Text = " ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 280);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(666, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rgvDSPhieuNhap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 280);
            this.panel1.TabIndex = 2;
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDSPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvDSPhieuNhap.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDSPhieuNhap
            // 
            this.rgvDSPhieuNhap.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewTextBoxColumn1.FieldName = "PNID";
            gridViewTextBoxColumn1.HeaderText = "PN id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colPNID";
            gridViewTextBoxColumn2.FieldName = "SoCTN";
            gridViewTextBoxColumn2.HeaderText = "Số Chứng Từ Nhập";
            gridViewTextBoxColumn2.Name = "ColSoCTN";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "SoDH";
            gridViewTextBoxColumn3.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn3.Name = "colSoDH";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "LoaiPhatSinh";
            gridViewTextBoxColumn4.HeaderText = "Loại Phát Sinh";
            gridViewTextBoxColumn4.Name = "colLoaiPhatSinh";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "TenNT";
            gridViewTextBoxColumn5.HeaderText = "Từ";
            gridViewTextBoxColumn5.Name = "colTenNT";
            gridViewTextBoxColumn5.Width = 140;
            this.rgvDSPhieuNhap.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvDSPhieuNhap.Name = "rgvDSPhieuNhap";
            this.rgvDSPhieuNhap.ShowGroupPanel = false;
            this.rgvDSPhieuNhap.Size = new System.Drawing.Size(666, 280);
            this.rgvDSPhieuNhap.TabIndex = 0;
            this.rgvDSPhieuNhap.Text = "radGridView1";
            // 
            // frmNT_NhapKhoXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 306);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNT_NhapKhoXacNhan";
            this.Text = "Xác Nhận Nhập Kho";
            this.Load += new System.EventHandler(this.frmNT_NhapKhoXacNhan_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDSPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        public Telerik.WinControls.UI.RadGridView rgvDSPhieuNhap;

    }
}