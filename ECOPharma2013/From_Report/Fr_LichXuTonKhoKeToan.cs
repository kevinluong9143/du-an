using ECOPharma2013.Report1;
using ECOPharma2013.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_LichXuTonKhoKeToan : Form
    {
        DateTime aDate = DateTime.Now.Date;
        string Key = "";
        string NTid = "";

        public Fr_LichXuTonKhoKeToan()
        {
            InitializeComponent();
        }

        public Fr_LichXuTonKhoKeToan(DateTime Date, string key, string NTid)
        {
            this.aDate = Date;
            this.Key = key;
            this.NTid = NTid;
            InitializeComponent();
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void RW_LichSuTonKhoKeToan_Load(object sender, EventArgs e)
        {
            Report_LichSuTonKhoKeToan aReport = new Report_LichSuTonKhoKeToan();
            CSQLLSTonKhoKeToan aLSTonKhoKeToan = new CSQLLSTonKhoKeToan();
            if (NTid.ToLower().Equals("f08f270f-de84-480d-95f9-0b9cc1285f37")) {
                aReport.SetDataSource(aLSTonKhoKeToan.LayThongTinLenLuoi(aDate, Key));
            }
            else
            {
                aReport.SetDataSource(aLSTonKhoKeToan.LayThongTinNhaThuocLenLuoi(aDate, Key, NTid));
            }

            RW_LichSuTonKhoKeToan.ReportSource = aReport;
        }
    }
}
