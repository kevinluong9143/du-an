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
    public partial class Fr_TraHangVeCty : Form
    {
        DataTable _inan;
        int _cn;
        public Fr_TraHangVeCty(DataTable dtbinan, int cn)
        {
            InitializeComponent();
            _inan = dtbinan;
            _cn = cn;
        }

        private void Fr_TraHangVeCty_Load(object sender, EventArgs e)
        {
            Report_TraHangVeCty check = new Report_TraHangVeCty();
            check.SetDataSource(_inan);
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (_cn == 1)
            {
                pdv.Value = "Bình Thường";
            }
            else
            {
                pdv.Value = " Sắp Hết HSD - Hết HSD - Hư Hỏng - Thu Hồi";
            }
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["LoaiHang"].ApplyCurrentValues(pv);
            RW_TraHangVeCty.ReportSource = check;
        }
    }
}
