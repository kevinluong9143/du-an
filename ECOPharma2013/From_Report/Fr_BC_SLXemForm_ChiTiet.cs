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
    public partial class Fr_BC_SLXemForm_ChiTiet : Form
    {
        DateTime From;
        DateTime To;
        string FormView;

        public Fr_BC_SLXemForm_ChiTiet()
        {
            InitializeComponent();
        }

        public Fr_BC_SLXemForm_ChiTiet(DateTime From, DateTime To, string FormView)
        {
            InitializeComponent();
            this.From = From;
            this.To = To;
            this.FormView = FormView;

            CSQLXemForm aXemForm = new CSQLXemForm();
            rgvDS.DataSource = aXemForm.XemSoLuotViewChiTiet(this.From, this.To, this.FormView);
        }
    }
}
