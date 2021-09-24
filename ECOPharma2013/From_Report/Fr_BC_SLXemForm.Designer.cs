namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_SLXemForm
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
            this.rgvDS = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtDenNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtTuNgay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnXem = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rgvDS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.939914F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.06009F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 472);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // rgvDS
            // 
            this.rgvDS.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDS.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDS.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDS.Location = new System.Drawing.Point(3, 40);
            // 
            // rgvDS
            // 
            this.rgvDS.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "STT";
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "colSTT";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.FieldName = "FormView";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Form View";
            gridViewTextBoxColumn2.Name = "colFormView";
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn3.FieldName = "FormName";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Form Name";
            gridViewTextBoxColumn3.Name = "colFormName";
            gridViewTextBoxColumn3.Width = 270;
            gridViewTextBoxColumn4.FieldName = "SLXem";
            gridViewTextBoxColumn4.FormatString = "{0:N0}";
            gridViewTextBoxColumn4.HeaderText = "Count View";
            gridViewTextBoxColumn4.Name = "colSLXem";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 100;
            this.rgvDS.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvDS.MasterTemplate.EnableFiltering = true;
            this.rgvDS.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvDS.Name = "rgvDS";
            this.rgvDS.ReadOnly = true;
            this.rgvDS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDS.ShowGroupPanel = false;
            this.rgvDS.Size = new System.Drawing.Size(598, 429);
            this.rgvDS.TabIndex = 5;
            this.rgvDS.Text = "radGridView1";
            this.rgvDS.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDS_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 12;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtDenNgay, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTuNgay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXem, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(598, 31);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // radLabel2
            // 
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(250, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 25);
            this.radLabel2.TabIndex = 36;
            this.radLabel2.Text = "Đến Ngày";
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(43, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(69, 25);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Từ Ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDenNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(333, 3);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Size = new System.Drawing.Size(112, 27);
            this.dtDenNgay.TabIndex = 24;
            this.dtDenNgay.TabStop = false;
            this.dtDenNgay.Text = "radDateTimePicker2";
            this.dtDenNgay.Value = new System.DateTime(2013, 5, 7, 22, 2, 37, 57);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(126, 3);
            this.dtTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Size = new System.Drawing.Size(118, 27);
            this.dtTuNgay.TabIndex = 21;
            this.dtTuNgay.TabStop = false;
            this.dtTuNgay.Text = "radDateTimePicker1";
            this.dtTuNgay.Value = new System.DateTime(2013, 5, 7, 22, 0, 36, 625);
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXem.Location = new System.Drawing.Point(451, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(119, 25);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // Fr_BC_SLXemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Fr_BC_SLXemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Lượt Xem Báo Cáo";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dtDenNgay;
        private Telerik.WinControls.UI.RadDateTimePicker dtTuNgay;
        private Telerik.WinControls.UI.RadButton btnXem;
        private Telerik.WinControls.UI.RadGridView rgvDS;

    }
}