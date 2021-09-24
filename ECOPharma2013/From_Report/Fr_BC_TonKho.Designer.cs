namespace ECOPharma2013.From_Report
{
    partial class Fr_BC_TonKho
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
            this.RW_BC_TonKho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_BC_TonKho
            // 
            this.RW_BC_TonKho.ActiveViewIndex = -1;
            this.RW_BC_TonKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_BC_TonKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_BC_TonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_BC_TonKho.Location = new System.Drawing.Point(0, 0);
            this.RW_BC_TonKho.Name = "RW_BC_TonKho";
            this.RW_BC_TonKho.Size = new System.Drawing.Size(968, 626);
            this.RW_BC_TonKho.TabIndex = 0;
            this.RW_BC_TonKho.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RW_BC_TonKho.Load += new System.EventHandler(this.RW_BC_TonKho_Load);
            // 
            // Fr_BC_TonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_BC_TonKho);
            this.Name = "Fr_BC_TonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tồn Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_BC_TonKho;
    }
}