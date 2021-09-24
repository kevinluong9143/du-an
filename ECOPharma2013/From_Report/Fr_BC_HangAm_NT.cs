using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using CrystalDecisions.Shared;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_BC_HangAm_NT : Form
    {
        DataTable _inan;
        string _tieudein;
        public Fr_BC_HangAm_NT(DataTable inan, string tieudein)
        {
            InitializeComponent();
            _inan = inan;
            _tieudein = tieudein;
        }

        private void RW_BC_TonKho_Load(object sender, EventArgs e)
        {
            Report_BC_TonKho_HangAm check = new Report_BC_TonKho_HangAm();
            check.SetDataSource(_inan);
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = _tieudein;
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["TieuDe"].ApplyCurrentValues(pv);
            RW_BC_HangAm.ReportSource = check;

            CSQLXemForm xemForm = new CSQLXemForm();
            xemForm.ThemMoi(CStaticBien.SmaTaiKhoan, this.Name);
        }

    }
}
