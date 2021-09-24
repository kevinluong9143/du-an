﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.Report1;
using ECOPharma2013.SQL;

namespace ECOPharma2013.From_Report
{
    public partial class Fr_DieuChinhTonKho : Form
    {
        DataTable _inan;
        public Fr_DieuChinhTonKho(DataTable dtbinan)
        {
            InitializeComponent();
            _inan = dtbinan;
        }

        private void Fr_DieuChinhTonKho_Load(object sender, EventArgs e)
        {
            Report_DieuChinhTonKho check = new Report_DieuChinhTonKho();
            check.SetDataSource(_inan);
            RW_DieuChinhTonKho.ReportSource = check;
        }
    }
}