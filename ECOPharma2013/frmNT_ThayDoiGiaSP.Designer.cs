namespace ECOPharma2013
{
    partial class frmNT_ThayDoiGiaSP
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
            this.rgvThayDoiGia = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvThayDoiGia)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvThayDoiGia
            // 
            this.rgvThayDoiGia.BackColor = System.Drawing.SystemColors.Control;
            this.rgvThayDoiGia.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvThayDoiGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvThayDoiGia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvThayDoiGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvThayDoiGia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvThayDoiGia.Location = new System.Drawing.Point(0, 0);
            this.rgvThayDoiGia.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvThayDoiGia
            // 
            this.rgvThayDoiGia.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "TDGid";
            gridViewTextBoxColumn1.HeaderText = "TDG id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colTDGid";
            gridViewTextBoxColumn2.FieldName = "STT";
            gridViewTextBoxColumn2.HeaderText = "STT";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colSTT";
            gridViewTextBoxColumn3.FieldName = "SoCT";
            gridViewTextBoxColumn3.HeaderText = "Số Chứng Từ";
            gridViewTextBoxColumn3.Name = "colSoCT";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "Ngay";
            gridViewTextBoxColumn4.HeaderText = "Ngày";
            gridViewTextBoxColumn4.Name = "colNgay";
            gridViewTextBoxColumn4.Width = 250;
            this.rgvThayDoiGia.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvThayDoiGia.Name = "rgvThayDoiGia";
            this.rgvThayDoiGia.ReadOnly = true;
            this.rgvThayDoiGia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvThayDoiGia.ShowGroupPanel = false;
            this.rgvThayDoiGia.Size = new System.Drawing.Size(426, 363);
            this.rgvThayDoiGia.TabIndex = 0;
            this.rgvThayDoiGia.Text = "radGridView1";
            this.rgvThayDoiGia.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvThayDoiGia_CellDoubleClick);
            // 
            // frmNT_ThayDoiGiaSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 363);
            this.Controls.Add(this.rgvThayDoiGia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNT_ThayDoiGiaSP";
            this.Text = "frmNT_ThayDoiGiaSP";
            this.Load += new System.EventHandler(this.frmNT_ThayDoiGiaSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvThayDoiGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvThayDoiGia;

    }
}