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
    public partial class Fr_DonHangXuat : Form
    {
        DataTable _inan;
        bool _donkhan;
        bool _daxuatdu;
        public Fr_DonHangXuat(DataTable dtbinan, bool donkkhan, bool daxuatdu)
        {
            InitializeComponent();
            _inan = dtbinan;
            _donkhan = donkkhan;
            _daxuatdu = daxuatdu;
        }

        private void Fr_DonHangXuat_Load(object sender, EventArgs e)
        {
            Report_DonHangXuat check = new Report_DonHangXuat();
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

            ParameterDiscreteValue pdv_1 = new ParameterDiscreteValue();
            if (_daxuatdu == true)
            {
                pdv_1.Value = true;
            }
            else
            {
                pdv_1.Value = false;
            }
            ParameterValues pv_1 = new ParameterValues();
            pv_1.Add(pdv_1);
            check.DataDefinition.ParameterFields["DaXuatDu"].ApplyCurrentValues(pv_1);

            RW_DonHangXuat.ReportSource = check;
            
        }
    }
}
