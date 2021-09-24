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
    public partial class Fr_XuatNhanh : Form
    {
        DataTable _inan;
        public Fr_XuatNhanh(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_XuatNhanh_Load(object sender, EventArgs e)
        {
            Report_DonHangXuatNhanh check = new Report_DonHangXuatNhanh();
            check.SetDataSource(_inan);
            //ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //pdv.Value = _cn;
            //ParameterValues pv = new ParameterValues();
            //pv.Add(pdv);
            //check.DataDefinition.ParameterFields["NoiChuyen"].ApplyCurrentValues(pv);
            RW_XuatNhanh.ReportSource = check;
        }
    }
}
