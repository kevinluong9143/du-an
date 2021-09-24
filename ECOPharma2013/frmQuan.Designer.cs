namespace ECOPharma2013
{
    partial class frmQuan
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
            this.rgvQuan = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuan.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvQuan
            // 
            this.rgvQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvQuan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvQuan.Location = new System.Drawing.Point(0, 0);
            this.rgvQuan.Margin = new System.Windows.Forms.Padding(4);
            // 
            // rgvQuan
            // 
            this.rgvQuan.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "QuanID";
            gridViewTextBoxColumn1.HeaderText = "Mã Quận";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colQuanID";
            gridViewTextBoxColumn2.FieldName = "TenQ";
            gridViewTextBoxColumn2.HeaderText = "Tên Quận";
            gridViewTextBoxColumn2.Name = "colTenQ";
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "KhongSuDung";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colKhongSuDung";
            gridViewTextBoxColumn4.Width = 150;
            this.rgvQuan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvQuan.Name = "rgvQuan";
            this.rgvQuan.ReadOnly = true;
            this.rgvQuan.ShowGroupPanel = false;
            this.rgvQuan.Size = new System.Drawing.Size(635, 242);
            this.rgvQuan.TabIndex = 0;
            this.rgvQuan.Text = "radGridView1";
            this.rgvQuan.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvQuan_RowFormatting);
            this.rgvQuan.DoubleClick += new System.EventHandler(this.rgvQuan_DoubleClick);
            this.rgvQuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvQuan_KeyDown);
            // 
            // frmQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 242);
            this.Controls.Add(this.rgvQuan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuan";
            this.Text = "frmQuan";
            this.Load += new System.EventHandler(this.frmQuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvQuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvQuan;

    }
}