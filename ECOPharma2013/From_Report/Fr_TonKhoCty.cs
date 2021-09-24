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
    public partial class Fr_TonKhoCty : Form
    {
        DataTable _inan;
        public Fr_TonKhoCty(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_TonKhoCty_Load(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua("Fr_TonKhoNT") == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                this.Close();
                return;
            }
            Report_TonKhoCty check = new Report_TonKhoCty();
            check.SetDataSource(_inan);
            RW_TonKhoCty.ReportSource = check;
        }
    }
}
