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
    public partial class Fr_NTChuyenHang : Form
    {
        DataTable _inan;
        public Fr_NTChuyenHang(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_NTChuyenHang_Load(object sender, EventArgs e)
        {
            Report_NTChuyenHang check = new Report_NTChuyenHang();
            check.SetDataSource(_inan);
            RW_NTChuyenHang.ReportSource = check;
        }
    }
}
