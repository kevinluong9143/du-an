namespace ECOPharma2013.From_Report
{
    partial class Fr_LichXuTonKhoKeToan
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
            this.RW_LichSuTonKhoKeToan = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_LichSuTonKhoKeToan
            // 
            this.RW_LichSuTonKhoKeToan.ActiveViewIndex = -1;
            this.RW_LichSuTonKhoKeToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_LichSuTonKhoKeToan.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_LichSuTonKhoKeToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_LichSuTonKhoKeToan.Location = new System.Drawing.Point(0, 0);
            this.RW_LichSuTonKhoKeToan.Name = "RW_LichSuTonKhoKeToan";
            this.RW_LichSuTonKhoKeToan.Size = new System.Drawing.Size(952, 587);
            this.RW_LichSuTonKhoKeToan.TabIndex = 0;
            this.RW_LichSuTonKhoKeToan.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RW_LichSuTonKhoKeToan.Load += new System.EventHandler(this.RW_LichSuTonKhoKeToan_Load);
            // 
            // Fr_LichXuTonKhoKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 587);
            this.Controls.Add(this.RW_LichSuTonKhoKeToan);
            this.Name = "Fr_LichXuTonKhoKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fr_LichXuTonKhoKeToan";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer RW_LichSuTonKhoKeToan;

    }
}