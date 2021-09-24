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
    public partial class Fr_ChuyenKho : Form
    {
        DataTable _inan;
        string _cn;
        public Fr_ChuyenKho(DataTable dtbinan, string cn)
        {
            InitializeComponent();
            _inan = dtbinan;
            _cn = cn;
        }

        private void Fr_ChuyenKho_Load(object sender, EventArgs e)
        {
            Report_PhieuChuyenKho check = new Report_PhieuChuyenKho();
            check.SetDataSource(_inan);
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = _cn;
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["NoiChuyen"].ApplyCurrentValues(pv);
            RW_ChuyenKho.ReportSource = check;
        }
    }
}
