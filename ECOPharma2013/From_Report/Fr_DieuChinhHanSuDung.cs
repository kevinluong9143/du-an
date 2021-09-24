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
    public partial class Fr_DieuChinhHanSuDung : Form
    {
        private string DCHSDID;

        public Fr_DieuChinhHanSuDung()
        {
            InitializeComponent();
        }

        public Fr_DieuChinhHanSuDung(string DCHSDID)
        {
            this.DCHSDID = DCHSDID;
            InitializeComponent();
        }

        private void Fr_DieuChinhHanSuDung_Load(object sender, EventArgs e)
        {
            Report_DieuChinhHanSuDung aReport = new Report_DieuChinhHanSuDung();
            CSQLDieuChinhHSD aDieuChinhHSD = new CSQLDieuChinhHSD();
            aReport.SetDataSource(aDieuChinhHSD.InPhieu(new Guid(this.DCHSDID)));

            crvDetail.ReportSource = aReport;
        }
    }
}
