namespace ECOPharma2013
{
    partial class frmUser
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.rgvUser = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUser.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvUser
            // 
            this.rgvUser.BackColor = System.Drawing.SystemColors.Control;
            this.rgvUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvUser.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rgvUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvUser.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvUser
            // 
            this.rgvUser.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "UserID";
            gridViewTextBoxColumn1.HeaderText = "User ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colUserID";
            gridViewTextBoxColumn2.FieldName = "UserName";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Tên Đăng Nhập";
            gridViewTextBoxColumn2.Name = "colUserName";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "Pass";
            gridViewTextBoxColumn3.HeaderText = "Mật Khẩu";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "colPass";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "KhongSuDung";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colKhongSuDung";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "NVID";
            gridViewTextBoxColumn5.HeaderText = "NVid";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "colNVID";
            gridViewTextBoxColumn6.FieldName = "HoTen";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Họ Tên Nhân Viên";
            gridViewTextBoxColumn6.Name = "colHoTen";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "NhomNDid";
            gridViewTextBoxColumn7.HeaderText = "NhomNDid";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "colNhomNDid";
            gridViewTextBoxColumn8.FieldName = "TenNhom";
            gridViewTextBoxColumn8.FormatString = "";
            gridViewTextBoxColumn8.HeaderText = "Thuộc Nhóm";
            gridViewTextBoxColumn8.Name = "colTenNhom";
            gridViewTextBoxColumn8.Width = 150;
            this.rgvUser.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvUser.MasterTemplate.EnableFiltering = true;
            this.rgvUser.Name = "rgvUser";
            this.rgvUser.ReadOnly = true;
            this.rgvUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvUser.ShowGroupPanel = false;
            this.rgvUser.Size = new System.Drawing.Size(674, 308);
            this.rgvUser.TabIndex = 0;
            this.rgvUser.Text = "radGridView1";
            this.rgvUser.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvUser_CellDoubleClick);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 308);
            this.Controls.Add(this.rgvUser);
            this.Name = "frmUser";
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvUser.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvUser;

    }
}