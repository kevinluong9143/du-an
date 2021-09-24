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
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_TonKho : Form
    {
        DataTable _inan;
        string _tieudein;
        bool _LayReport;
        public Fr_BC_TonKho(DataTable dtbinan, string tieudein, bool layReport)
        {
            InitializeComponent();
            _inan = dtbinan;
            _tieudein = tieudein;
            _LayReport = layReport;
        }

        private void RW_BC_TonKho_Load(object sender, EventArgs e)
        {
           
            if (_LayReport == true)
            {
                Report_BC_TonKho check = new Report_BC_TonKho();
                check.SetDataSource(_inan);
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                pdv.Value = _tieudein;
                ParameterValues pv = new ParameterValues();
                pv.Add(pdv);
                check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
                RW_BC_TonKho.ReportSource = check;
            }
            else
            {
                Report_BC_TonKho_CacNT check = new Report_BC_TonKho_CacNT();
                check.SetDataSource(_inan);
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                pdv.Value = _tieudein;
                ParameterValues pv = new ParameterValues();
                pv.Add(pdv);
                check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
                RW_BC_TonKho.ReportSource = check;
            }
        }
    }
}
