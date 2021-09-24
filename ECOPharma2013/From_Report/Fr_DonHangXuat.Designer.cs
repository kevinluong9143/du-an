namespace ECOPharma2013.From_Report
{
    partial class Fr_DonHangXuat
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
            this.RW_DonHangXuat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_DonHangXuat
            // 
            this.RW_DonHangXuat.ActiveViewIndex = -1;
            this.RW_DonHangXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_DonHangXuat.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_DonHangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_DonHangXuat.Location = new System.Drawing.Point(0, 0);
            this.RW_DonHangXuat.Name = "RW_DonHangXuat";
            this.RW_DonHangXuat.Size = new System.Drawing.Size(968, 626);
            this.RW_DonHangXuat.TabIndex = 0;
            this.RW_DonHangXuat.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_DonHangXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_DonHangXuat);
            this.Name = "Fr_DonHangXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Hàng Xuất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_DonHangXuat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_DonHangXuat;
    }
}