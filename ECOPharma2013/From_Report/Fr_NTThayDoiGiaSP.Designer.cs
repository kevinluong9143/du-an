namespace ECOPharma2013.From_Report
{
    partial class Fr_NTThayDoiGiaSP
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
            this.RW_ThayDoiGiaSP = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_ThayDoiGiaSP
            // 
            this.RW_ThayDoiGiaSP.ActiveViewIndex = -1;
            this.RW_ThayDoiGiaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_ThayDoiGiaSP.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_ThayDoiGiaSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_ThayDoiGiaSP.Location = new System.Drawing.Point(0, 0);
            this.RW_ThayDoiGiaSP.Name = "RW_ThayDoiGiaSP";
            this.RW_ThayDoiGiaSP.Size = new System.Drawing.Size(968, 626);
            this.RW_ThayDoiGiaSP.TabIndex = 0;
            this.RW_ThayDoiGiaSP.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_NTThayDoiGiaSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_ThayDoiGiaSP);
            this.Name = "Fr_NTThayDoiGiaSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay Đổi Giá Sản Phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_NTThayDoiGiaSP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_ThayDoiGiaSP;
    }
}