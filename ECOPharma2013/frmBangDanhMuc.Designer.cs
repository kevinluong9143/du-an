namespace ECOPharma2013
{
    partial class frmBangDanhMuc
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
            this.rgvBangDM = new Telerik.WinControls.UI.RadGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusThongBaoLoi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rgvBangDM)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvBangDM
            // 
            this.rgvBangDM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvBangDM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvBangDM.Location = new System.Drawing.Point(0, 0);
            // 
            // rgvBangDM
            // 
            gridViewTextBoxColumn1.FieldName = "TenBang";
            gridViewTextBoxColumn1.HeaderText = "Tên Bảng";
            gridViewTextBoxColumn1.Name = "colTenBang";
            gridViewTextBoxColumn1.Width = 200;
            gridViewTextBoxColumn2.FieldName = "MoTa";
            gridViewTextBoxColumn2.HeaderText = "Mô Tả";
            gridViewTextBoxColumn2.Name = "colMoTa";
            gridViewTextBoxColumn2.Width = 400;
            this.rgvBangDM.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.rgvBangDM.Name = "rgvBangDM";
            this.rgvBangDM.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvBangDM.ShowGroupPanel = false;
            this.rgvBangDM.Size = new System.Drawing.Size(632, 262);
            this.rgvBangDM.TabIndex = 0;
            this.rgvBangDM.Text = "radGridView1";
            this.rgvBangDM.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.rgvBangDM_UserAddedRow);
            this.rgvBangDM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgvBangDM_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusThongBaoLoi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(632, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusThongBaoLoi
            // 
            this.toolStripStatusThongBaoLoi.Name = "toolStripStatusThongBaoLoi";
            this.toolStripStatusThongBaoLoi.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusThongBaoLoi.Text = " ";
            // 
            // frmBangDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 287);
            this.Controls.Add(this.rgvBangDM);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmBangDanhMuc";
            this.Text = "frmBangDanhMuc";
            this.Load += new System.EventHandler(this.frmBangDanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvBangDM)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvBangDM;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusThongBaoLoi;
    }
}