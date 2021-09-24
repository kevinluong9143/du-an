namespace ECOPharma2013.From_Report
{
    partial class Fr_NTBanHang
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
            this.RW_NTBanHang = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_NTBanHang
            // 
            this.RW_NTBanHang.ActiveViewIndex = -1;
            this.RW_NTBanHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_NTBanHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_NTBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_NTBanHang.Location = new System.Drawing.Point(0, 0);
            this.RW_NTBanHang.Name = "RW_NTBanHang";
            this.RW_NTBanHang.Size = new System.Drawing.Size(968, 626);
            this.RW_NTBanHang.TabIndex = 0;
            this.RW_NTBanHang.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_NTBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_NTBanHang);
            this.Name = "Fr_NTBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Bán Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_NTBanHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_NTBanHang;
    }
}