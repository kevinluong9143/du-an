namespace ECOPharma2013.From_Report
{
    partial class Fr_NT_NhapKho
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
            this.RW_NT_NhapKho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RW_NT_NhapKho
            // 
            this.RW_NT_NhapKho.ActiveViewIndex = -1;
            this.RW_NT_NhapKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RW_NT_NhapKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.RW_NT_NhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RW_NT_NhapKho.Location = new System.Drawing.Point(0, 0);
            this.RW_NT_NhapKho.Name = "RW_NT_NhapKho";
            this.RW_NT_NhapKho.Size = new System.Drawing.Size(968, 626);
            this.RW_NT_NhapKho.TabIndex = 1;
            this.RW_NT_NhapKho.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Fr_NT_NhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.RW_NT_NhapKho);
            this.Name = "Fr_NT_NhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fr_NT_NhapKho";
            this.Load += new System.EventHandler(this.Fr_NT_NhapKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RW_NT_NhapKho;
    }
}