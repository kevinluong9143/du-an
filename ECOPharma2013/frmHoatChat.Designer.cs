namespace ECOPharma2013
{
    partial class frmHoatChat
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
            this.rgvHoatChat = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHoatChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHoatChat.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvHoatChat
            // 
            this.rgvHoatChat.BackColor = System.Drawing.SystemColors.Control;
            this.rgvHoatChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvHoatChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvHoatChat.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.rgvHoatChat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvHoatChat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvHoatChat.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvHoatChat
            // 
            this.rgvHoatChat.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "HCID";
            gridViewTextBoxColumn1.HeaderText = "Mã HC";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "colHCID";
            gridViewTextBoxColumn2.FieldName = "TenHC";
            gridViewTextBoxColumn2.HeaderText = "Tên phân loại";
            gridViewTextBoxColumn2.Name = "colTenHC";
            gridViewTextBoxColumn2.Width = 250;
            gridViewTextBoxColumn3.FieldName = "GhiChu";
            gridViewTextBoxColumn3.HeaderText = "Ghi Chú";
            gridViewTextBoxColumn3.Name = "colGhiChu";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "KhongSuDung";
            gridViewTextBoxColumn4.HeaderText = "Không Sử Dụng";
            gridViewTextBoxColumn4.Name = "colKhongSuDung";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "LastUD";
            gridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn5.HeaderText = "Ngày Cập Nhật";
            gridViewTextBoxColumn5.Name = "colLastUD";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "NgayTao";
            gridViewTextBoxColumn6.FormatString = "{0:dd/MM/yyyy hh:mm:ss}";
            gridViewTextBoxColumn6.HeaderText = "Ngày Tạo";
            gridViewTextBoxColumn6.Name = "colNgayTao";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "UserName";
            gridViewTextBoxColumn7.HeaderText = "Nhân Viên Cập Nhật";
            gridViewTextBoxColumn7.Name = "colUserName";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.FieldName = "UserID";
            gridViewTextBoxColumn8.HeaderText = "MÃ NV";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "colUserID";
            this.rgvHoatChat.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvHoatChat.Name = "rgvHoatChat";
            this.rgvHoatChat.ReadOnly = true;
            this.rgvHoatChat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvHoatChat.ShowGroupPanel = false;
            this.rgvHoatChat.Size = new System.Drawing.Size(772, 324);
            this.rgvHoatChat.TabIndex = 0;
            this.rgvHoatChat.Text = "radGridView1";
            this.rgvHoatChat.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.rgvHoatChat_RowFormatting);
            this.rgvHoatChat.DoubleClick += new System.EventHandler(this.rgvHoatChat_DoubleClick);
            this.rgvHoatChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgvHoatChat_KeyDown);
            // 
            // frmHoatChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 324);
            this.Controls.Add(this.rgvHoatChat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHoatChat";
            this.Text = "Phân loại";
            this.Load += new System.EventHandler(this.frmHoatChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvHoatChat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvHoatChat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView rgvHoatChat;

    }
}