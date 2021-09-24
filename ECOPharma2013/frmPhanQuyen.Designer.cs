namespace ECOPharma2013
{
    partial class frmPhanQuyen
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.Data.GroupDescriptor groupDescriptor1 = new Telerik.WinControls.Data.GroupDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.rgvPhanQuyen = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanQuyen.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPhanQuyen
            // 
            this.rgvPhanQuyen.BackColor = System.Drawing.SystemColors.Control;
            this.rgvPhanQuyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvPhanQuyen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rgvPhanQuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvPhanQuyen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPhanQuyen.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvPhanQuyen
            // 
            this.rgvPhanQuyen.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "NhomNDID";
            gridViewTextBoxColumn1.HeaderText = "NhomID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colNhomNDID";
            gridViewTextBoxColumn2.FieldName = "TenNhom";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Tên Nhóm Người Dùng";
            gridViewTextBoxColumn2.Name = "colTenNhom";
            gridViewTextBoxColumn2.Width = 250;
            gridViewTextBoxColumn3.FieldName = "QuyenID";
            gridViewTextBoxColumn3.HeaderText = "Quyền ID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colQuyenID";
            gridViewTextBoxColumn4.FieldName = "MenuID";
            gridViewTextBoxColumn4.HeaderText = "MenuID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "colMenuID";
            gridViewTextBoxColumn5.FieldName = "TenMenu";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Tên Menu";
            gridViewTextBoxColumn5.Name = "colTenMenu";
            gridViewTextBoxColumn5.Width = 200;
            gridViewTextBoxColumn6.FieldName = "FormID";
            gridViewTextBoxColumn6.HeaderText = "FormID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "colFormID";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "TenForm";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Tên Form";
            gridViewTextBoxColumn7.Name = "colTenForm";
            gridViewTextBoxColumn7.Width = 350;
            gridViewCheckBoxColumn1.FieldName = "Xem";
            gridViewCheckBoxColumn1.FormatString = "";
            gridViewCheckBoxColumn1.HeaderText = "Xem";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colXem";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn2.FieldName = "Them_Sua";
            gridViewCheckBoxColumn2.FormatString = "";
            gridViewCheckBoxColumn2.HeaderText = "Thêm/Sửa";
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "colThem_Sua";
            gridViewCheckBoxColumn2.ReadOnly = true;
            gridViewCheckBoxColumn2.Width = 80;
            gridViewCheckBoxColumn3.FieldName = "Xoa";
            gridViewCheckBoxColumn3.FormatString = "";
            gridViewCheckBoxColumn3.HeaderText = "Xóa";
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "colXoa";
            gridViewCheckBoxColumn3.ReadOnly = true;
            gridViewCheckBoxColumn4.FieldName = "Inn";
            gridViewCheckBoxColumn4.FormatString = "";
            gridViewCheckBoxColumn4.HeaderText = "In";
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "colIn";
            gridViewCheckBoxColumn4.ReadOnly = true;
            this.rgvPhanQuyen.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3,
            gridViewCheckBoxColumn4});
            this.rgvPhanQuyen.MasterTemplate.EnableAlternatingRowColor = true;
            this.rgvPhanQuyen.MasterTemplate.EnableFiltering = true;
            sortDescriptor1.PropertyName = "colTenNhom";
            groupDescriptor1.GroupNames.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.rgvPhanQuyen.MasterTemplate.GroupDescriptors.AddRange(new Telerik.WinControls.Data.GroupDescriptor[] {
            groupDescriptor1});
            this.rgvPhanQuyen.Name = "rgvPhanQuyen";
            this.rgvPhanQuyen.ReadOnly = true;
            this.rgvPhanQuyen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPhanQuyen.Size = new System.Drawing.Size(954, 363);
            this.rgvPhanQuyen.TabIndex = 0;
            this.rgvPhanQuyen.Text = "radGridView1";
            this.rgvPhanQuyen.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvPhanQuyen_CellDoubleClick);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 363);
            this.Controls.Add(this.rgvPhanQuyen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhanQuyen";
            this.Text = "frmPhanQuyen";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanQuyen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPhanQuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvPhanQuyen;

    }
}