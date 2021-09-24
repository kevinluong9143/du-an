using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using ECOPharma2013.SQL;
using CrystalDecisions.Shared;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_NT_NhapKho : Form
    {
        DataTable _inan;
        public Fr_NT_NhapKho(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_NT_NhapKho_Load(object sender, EventArgs e)
        {
            Report_NT_NhapKho check = new Report_NT_NhapKho();
            check.SetDataSource(_inan);
            RW_NT_NhapKho.ReportSource = check;
        }
    }
}
