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
    public partial class Fr_DatHang : Form
    {
        DataTable _inan;
        bool _donkhan;
        public Fr_DatHang(DataTable dtbinan, bool donkkhan)
        {
            InitializeComponent();
            _inan = dtbinan;
            _donkhan = donkkhan;
        }

        private void Fr_DatHang_Load(object sender, EventArgs e)
        {
            Report_DatHang check = new Report_DatHang();
            check.SetDataSource(_inan);

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (_donkhan == true)
            {
                pdv.Value = true;
            }
            else
            {
                pdv.Value = false;
            }
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["DonHang"].ApplyCurrentValues(pv);

            RW_DatHang.ReportSource = check;
        }
    }
}
