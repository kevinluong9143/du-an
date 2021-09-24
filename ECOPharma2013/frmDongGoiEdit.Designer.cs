namespace ECOPharma2013
{
    partial class frmDongGoiEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongGoiEdit));
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
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnXacNhanXong = new System.Windows.Forms.ToolStripButton();
            this.btnDong = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboDVT = new System.Windows.Forms.ComboBox();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.lblPhieuXuat = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rgvDongGoiCT = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoiCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoiCT.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(690, 42);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTB
            // 
            this.statusTB.Name = "statusTB";
            this.statusTB.Size = new System.Drawing.Size(24, 37);
            this.statusTB.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLuu,
            this.btnXacNhanXong,
            this.btnDong});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(690, 44);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(134, 41);
            this.btnLuu.Text = "Lưu - F5";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXacNhanXong
            // 
            this.btnXacNhanXong.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhanXong.Image")));
            this.btnXacNhanXong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXacNhanXong.Name = "btnXacNhanXong";
            this.btnXacNhanXong.Size = new System.Drawing.Size(264, 41);
            this.btnXacNhanXong.Text = "Xác nhận xong - F6";
            this.btnXacNhanXong.Click += new System.EventHandler(this.btnXacNhanXong_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(173, 41);
            this.btnDong.Text = "Đóng - ESC";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboDVT);
            this.splitContainer1.Panel1.Controls.Add(this.lblDonHang);
            this.splitContainer1.Panel1.Controls.Add(this.lblPhieuXuat);
            this.splitContainer1.Panel1.Controls.Add(this.txtSL);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rgvDongGoiCT);
            this.splitContainer1.Size = new System.Drawing.Size(690, 321);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 2;
            // 
            // cboDVT
            // 
            this.cboDVT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDVT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDVT.FormattingEnabled = true;
            this.cboDVT.Location = new System.Drawing.Point(275, 67);
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.Size = new System.Drawing.Size(141, 39);
            this.cboDVT.TabIndex = 6;
            // 
            // lblDonHang
            // 
            this.lblDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonHang.Location = new System.Drawing.Point(423, 64);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(244, 45);
            this.lblDonHang.TabIndex = 5;
            this.lblDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhieuXuat
            // 
            this.lblPhieuXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuXuat.Location = new System.Drawing.Point(27, 64);
            this.lblPhieuXuat.Name = "lblPhieuXuat";
            this.lblPhieuXuat.Size = new System.Drawing.Size(244, 45);
            this.lblPhieuXuat.TabIndex = 4;
            this.lblPhieuXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(287, 18);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(116, 38);
            this.txtSL.TabIndex = 2;
            this.txtSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(473, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đơn Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiếu Xuất";
            // 
            // rgvDongGoiCT
            // 
            this.rgvDongGoiCT.AutoSizeRows = true;
            this.rgvDongGoiCT.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDongGoiCT.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDongGoiCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDongGoiCT.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.rgvDongGoiCT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDongGoiCT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDongGoiCT.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvDongGoiCT
            // 
            this.rgvDongGoiCT.MasterTemplate.AllowAddNewRow = false;
            this.rgvDongGoiCT.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "DGCTid";
            gridViewTextBoxColumn1.HeaderText = "DGCT id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colDGCTid";
            gridViewTextBoxColumn2.FieldName = "DGid";
            gridViewTextBoxColumn2.HeaderText = "DG id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colDGid";
            gridViewTextBoxColumn3.FieldName = "SoPX";
            gridViewTextBoxColumn3.HeaderText = "Số Phiếu Xuất";
            gridViewTextBoxColumn3.Name = "colSoPX";
            gridViewTextBoxColumn3.Width = 180;
            gridViewTextBoxColumn4.FieldName = "SoDH";
            gridViewTextBoxColumn4.HeaderText = "Số Đơn Hàng";
            gridViewTextBoxColumn4.Name = "colSoDH";
            gridViewTextBoxColumn4.Width = 180;
            gridViewTextBoxColumn5.FieldName = "SLDongGoi";
            gridViewTextBoxColumn5.FormatString = "{0:N2}";
            gridViewTextBoxColumn5.HeaderText = "Số Lượng Đóng Gói";
            gridViewTextBoxColumn5.Name = "colSLDongGoi";
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "DVTid";
            gridViewTextBoxColumn6.HeaderText = "DVT id";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colDVTid";
            gridViewTextBoxColumn7.FieldName = "TenDVT";
            gridViewTextBoxColumn7.HeaderText = "ĐVT";
            gridViewTextBoxColumn7.Name = "colTenDVT";
            gridViewTextBoxColumn7.Width = 100;
            this.rgvDongGoiCT.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.rgvDongGoiCT.Name = "rgvDongGoiCT";
            this.rgvDongGoiCT.ReadOnly = true;
            this.rgvDongGoiCT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDongGoiCT.ShowGroupPanel = false;
            this.rgvDongGoiCT.Size = new System.Drawing.Size(690, 199);
            this.rgvDongGoiCT.TabIndex = 0;
            this.rgvDongGoiCT.Text = "radGridView1";
            this.rgvDongGoiCT.DoubleClick += new System.EventHandler(this.rgvDongGoiCT_DoubleClick);
            this.rgvDongGoiCT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvDongGoiCT_KeyDown);
            // 
            // frmDongGoiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 407);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDongGoiEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đóng Gói Xuất Kho";
            this.Load += new System.EventHandler(this.frmDongGoiEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDongGoiEdit_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoiCT.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDongGoiCT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTB;
        private System.Windows.Forms.ToolStripButton btnDong;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView rgvDongGoiCT;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ComboBox cboDVT;
        private System.Windows.Forms.Label lblDonHang;
        private System.Windows.Forms.Label lblPhieuXuat;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnXacNhanXong;
    }
}