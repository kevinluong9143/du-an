namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_SLXemForm_ChiTiet
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rgvDS = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rgvDS, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 472);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rgvDS
            // 
            this.rgvDS.BackColor = System.Drawing.SystemColors.Control;
            this.rgvDS.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDS.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvDS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDS.Location = new System.Drawing.Point(3, 3);
            // 
            // rgvDS
            // 
            this.rgvDS.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn4.FieldName = "STT";
            gridViewTextBoxColumn4.HeaderText = "STT";
            gridViewTextBoxColumn4.Name = "colSTT";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.FieldName = "UserName";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Tên Nhân Viên";
            gridViewTextBoxColumn5.Name = "colUserName";
            gridViewTextBoxColumn5.Width = 250;
            gridViewTextBoxColumn6.FieldName = "DateView";
            gridViewTextBoxColumn6.FormatString = "{0:dd/MM/yyyy HH:mm}";
            gridViewTextBoxColumn6.HeaderText = "Ngày Xem";
            gridViewTextBoxColumn6.Name = "colDateView";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 150;
            this.rgvDS.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rgvDS.MasterTemplate.EnableFiltering = true;
            this.rgvDS.MasterTemplate.ShowRowHeaderColumn = false;
            this.rgvDS.Name = "rgvDS";
            this.rgvDS.ReadOnly = true;
            this.rgvDS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDS.ShowGroupPanel = false;
            this.rgvDS.Size = new System.Drawing.Size(453, 466);
            this.rgvDS.TabIndex = 7;
            this.rgvDS.Text = "radGridView1";
            // 
            // Fr_BC_SLXemForm_ChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Fr_BC_SLXemForm_ChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Chi Tiết Lịch Sử Xem Form";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView rgvDS;
    }
}