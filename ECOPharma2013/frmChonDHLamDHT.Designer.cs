namespace ECOPharma2013
{
    partial class frmChonDHLamDHT
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTaoDHTong = new System.Windows.Forms.Button();
            this.btnTaoDHTuDo = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.rgvDHNhathuoc = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanelMaster = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDHNhathuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDHNhathuoc.MasterTemplate)).BeginInit();
            this.tableLayoutPanelMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnTaoDHTong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTaoDHTuDo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDong, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(692, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(120, 241);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnTaoDHTong
            // 
            this.btnTaoDHTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoDHTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDHTong.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTaoDHTong.Location = new System.Drawing.Point(3, 3);
            this.btnTaoDHTong.Name = "btnTaoDHTong";
            this.btnTaoDHTong.Size = new System.Drawing.Size(114, 74);
            this.btnTaoDHTong.TabIndex = 0;
            this.btnTaoDHTong.Text = "Tạo ĐH Tổng";
            this.btnTaoDHTong.UseVisualStyleBackColor = true;
            this.btnTaoDHTong.Click += new System.EventHandler(this.btnTaoDHTong_Click);
            // 
            // btnTaoDHTuDo
            // 
            this.btnTaoDHTuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaoDHTuDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDHTuDo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTaoDHTuDo.Location = new System.Drawing.Point(3, 83);
            this.btnTaoDHTuDo.Name = "btnTaoDHTuDo";
            this.btnTaoDHTuDo.Size = new System.Drawing.Size(114, 74);
            this.btnTaoDHTuDo.TabIndex = 1;
            this.btnTaoDHTuDo.Text = "Tạo ĐH Tự Do";
            this.btnTaoDHTuDo.UseVisualStyleBackColor = true;
            this.btnTaoDHTuDo.Click += new System.EventHandler(this.btnTaoDHTuDo_Click);
            // 
            // btnDong
            // 
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(3, 163);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(114, 75);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // rgvDHNhathuoc
            // 
            this.rgvDHNhathuoc.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDHNhathuoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDHNhathuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDHNhathuoc.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.rgvDHNhathuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDHNhathuoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDHNhathuoc.Location = new System.Drawing.Point(3, 3);
            // 
            // rgvDHNhathuoc
            // 
            this.rgvDHNhathuoc.MasterTemplate.AllowAddNewRow = false;
            gridViewCheckBoxColumn1.HeaderText = "Chọn";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colChon";
            gridViewTextBoxColumn1.FieldName = "SoDHChung";
            gridViewTextBoxColumn1.HeaderText = "Số ĐH Nhà Thuốc";
            gridViewTextBoxColumn1.Name = "colSoDHChung";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.FieldName = "NoiDH";
            gridViewTextBoxColumn2.HeaderText = "NoiDH id";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colNoiDH";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn3.FieldName = "TenNT";
            gridViewTextBoxColumn3.HeaderText = "Nơi Đặt Hàng";
            gridViewTextBoxColumn3.Name = "colTenNT";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "NgayTao";
            gridViewTextBoxColumn4.HeaderText = "Ngày Đặt Hàng";
            gridViewTextBoxColumn4.Name = "colNgayTao";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "LoaiDH";
            gridViewTextBoxColumn5.HeaderText = "Loại Đơn Hàng";
            gridViewTextBoxColumn5.Name = "colLoaiDH";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.FieldName = "DHID";
            gridViewTextBoxColumn6.HeaderText = "DHID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colDHID";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn7.FieldName = "TenNhomSP";
            gridViewTextBoxColumn7.HeaderText = "Nhóm";
            gridViewTextBoxColumn7.Name = "TenNhomSP";
            gridViewTextBoxColumn7.Width = 80;
            this.rgvDHNhathuoc.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.rgvDHNhathuoc.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvDHNhathuoc.Name = "rgvDHNhathuoc";
            this.rgvDHNhathuoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDHNhathuoc.ShowGroupPanel = false;
            this.rgvDHNhathuoc.Size = new System.Drawing.Size(683, 351);
            this.rgvDHNhathuoc.TabIndex = 1;
            this.rgvDHNhathuoc.Text = "radGridView1";
            // 
            // tableLayoutPanelMaster
            // 
            this.tableLayoutPanelMaster.ColumnCount = 2;
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.75862F));
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.24138F));
            this.tableLayoutPanelMaster.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelMaster.Controls.Add(this.rgvDHNhathuoc, 0, 0);
            this.tableLayoutPanelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMaster.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMaster.Name = "tableLayoutPanelMaster";
            this.tableLayoutPanelMaster.RowCount = 1;
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMaster.Size = new System.Drawing.Size(833, 357);
            this.tableLayoutPanelMaster.TabIndex = 1;
            // 
            // frmChonDHLamDHT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 357);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChonDHLamDHT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Đơn Hàng Làm Đơn Hàng Tổng";
            this.Load += new System.EventHandler(this.frmChonDHLamDHT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDHNhathuoc.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDHNhathuoc)).EndInit();
            this.tableLayoutPanelMaster.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTaoDHTong;
        private System.Windows.Forms.Button btnTaoDHTuDo;
        private Telerik.WinControls.UI.RadGridView rgvDHNhathuoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMaster;
    }
}