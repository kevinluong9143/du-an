using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;
using System.Transactions;
using ECOPharma2013.Report1;

namespace ECOPharma2013
{
    public partial class Fr_Waiting : Form
    {
        frmMain _frmMain;

        public Fr_Waiting()
        {
            InitializeComponent();
        }
        public Fr_Waiting(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void Fr_Waiting_Load(object sender, EventArgs e)
        {
            //this.Opacity = 50;
            timer1.Start();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_frmMain.KT == true)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
