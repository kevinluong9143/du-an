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
    public partial class Fr_NTThayDoiGiaSP : Form
    {
        DataTable _inan;
        public Fr_NTThayDoiGiaSP(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_NTThayDoiGiaSP_Load(object sender, EventArgs e)
        {
            Report_ThayDoiGiaSP check = new Report_ThayDoiGiaSP();
            check.SetDataSource(_inan);
            RW_ThayDoiGiaSP.ReportSource = check;
        }
    }
}
