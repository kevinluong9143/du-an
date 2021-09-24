namespace ECOPharma2013
{
    partial class frmThanhPho
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvThanhPho = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvThanhPho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvThanhPho.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvThanhPho
            // 
            this.rgvThanhPho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvThanhPho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvThanhPho.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvThanhPho
            // 
            this.rgvThanhPho.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn5.FieldName = "TPID";
            gridViewTextBoxColumn5.HeaderText = "MÃ TP";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colTPID";
            gridViewTextBoxColumn6.FieldName = "TenTP";
            gridViewTextBoxColumn6.HeaderText = "Tên Thành Phố";
            gridViewTextBoxColumn6.Name = "colTenTP";
            gridViewTextBoxColumn6.Width = 200;
            gridViewTextBoxColumn7.FieldName = "GhiChu";
            gridViewTextBoxColumn7.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn7.Name = "colGhiChu";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "KhongSuDung";
            gridViewTextBoxColumn8.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn8.Name = "colKhongSuDung";
            gridViewTextBoxColumn8.Width = 150;
            this.rgvThanhPho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvThanhPho.MasterTemplate.EnableFiltering = true;
            this.rgvThanhPho.Name = "rgvThanhPho";
            this.rgvThanhPho.ReadOnly = true;
            this.rgvThanhPho.ShowGroupPanel = false;
            this.rgvThanhPho.Size = new System.Drawing.Size(632, 363);
            this.rgvThanhPho.TabIndex = 0;
            this.rgvThanhPho.Text = "radGridView1";
            this.rgvThanhPho.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvThanhPho_RowFormatting);
            this.rgvThanhPho.DoubleClick += new System.EventHandler(this.rgvThanhPho_DoubleClick);
            this.rgvThanhPho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvThanhPho_KeyDown);
            // 
            // frmThanhPho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 363);
            this.Controls.Add(this.rgvThanhPho);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThanhPho";
            this.Text = "frmThanhPho";
            this.Load += new System.EventHandler(this.frmThanhPho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvThanhPho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvThanhPho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvThanhPho;

    }
}