namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_DinhMucTonKho
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvDinhMucTonKho = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtTuNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnExportToExcel = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDinhMucTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDinhMucTonKho.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rgvDinhMucTonKho, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 587);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rgvDinhMucTonKho
            // 
            this.rgvDinhMucTonKho.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDinhMucTonKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDinhMucTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDinhMucTonKho.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDinhMucTonKho.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDinhMucTonKho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDinhMucTonKho.Location = new System.Drawing.Point(3, 44);
            // 
            // rgvDinhMucTonKho
            // 
            this.rgvDinhMucTonKho.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "Date";
            gridViewTextBoxColumn1.FormatString = "{0:dd/MM/yyyy}";
            gridViewTextBoxColumn1.HeaderText = "Thời Gian";
            gridViewTextBoxColumn1.Name = "colDate";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 120;
            gridViewTextBoxColumn2.FieldName = "TenNT";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Tên Nhà Thuốc";
            gridViewTextBoxColumn2.Name = "colTenNT";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "DMTKCH";
            gridViewTextBoxColumn3.FormatString = "{0:N2}";
            gridViewTextBoxColumn3.HeaderText = "Định Mức Tồn Kho";
            gridViewTextBoxColumn3.Name = "colDMTKCH";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "DinhMucTonKho";
            gridViewTextBoxColumn4.FormatString = "{0:N2}";
            gridViewTextBoxColumn4.HeaderText = "Tồn Kho Hiện Tại";
            gridViewTextBoxColumn4.Name = "colDinhMucTonKho";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 150;
            this.rgvDinhMucTonKho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvDinhMucTonKho.MasterTemplate.EnableFiltering = true;
            this.rgvDinhMucTonKho.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvDinhMucTonKho.Name = "rgvDinhMucTonKho";
            this.rgvDinhMucTonKho.ReadOnly = true;
            this.rgvDinhMucTonKho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDinhMucTonKho.ShowGroupPanel = false;
            this.rgvDinhMucTonKho.Size = new System.Drawing.Size(569, 540);
            this.rgvDinhMucTonKho.TabIndex = 3;
            this.rgvDinhMucTonKho.Text = "radGridView1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTuNgay, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDong, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportToExcel, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(569, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(46, 25);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Ngày";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(54, 3);
            this.dtTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Size = new System.Drawing.Size(128, 27);
            this.dtTuNgay.TabIndex = 21;
            this.dtTuNgay.TabStop = false;
            this.dtTuNgay.Text = "radDateTimePicker1";
            this.dtTuNgay.Value = new System.DateTime(2013, 5, 7, 22, 0, 36, 625);
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXem.Location = new System.Drawing.Point(311, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(96, 29);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(430, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 29);
            this.btnDong.TabIndex = 36;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToExcel.Location = new System.Drawing.Point(202, 3);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(90, 29);
            this.btnExportToExcel.TabIndex = 33;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // Fr_BC_DinhMucTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fr_BC_DinhMucTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Định Mức Tồn Kho";
            this.Load += new System.EventHandler(this.Fr_BC_DinhMucTonKho_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDinhMucTonKho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDinhMucTonKho)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView rgvDinhMucTonKho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Button btnDong;
        private Telerik.WinControls.UI.RadButton btnXem;
        private Telerik.WinControls.UI.RadDateTimePicker dtTuNgay;
        private Telerik.WinControls.UI.RadButton btnExportToExcel;
    }
}