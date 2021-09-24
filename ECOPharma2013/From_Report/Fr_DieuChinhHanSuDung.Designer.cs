namespace ECOPharma2013.From_Report
{
    partial class Fr_DieuChinhHanSuDung
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
            this.crvDetail = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvDetail
            // 
            this.crvDetail.ActiveViewIndex = -1;
            this.crvDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDetail.Location = new System.Drawing.Point(0, 0);
            this.crvDetail.Name = "crvDetail";
            this.crvDetail.Size = new System.Drawing.Size(968, 626);
            this.crvDetail.TabIndex = 1;
            this.crvDetail.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_DieuChinhHanSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.crvDetail);
            this.Name = "Fr_DieuChinhHanSuDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều Chỉnh Hạn Sử Dụng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fr_DieuChinhHanSuDung_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetail;
    }
}