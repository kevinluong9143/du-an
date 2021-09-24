using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class FrmChuKy : Form
    {
        frmMain fmain = new frmMain();
        public FrmChuKy(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        public FrmChuKy()
        {
            InitializeComponent();
        }

        private void FrmChuKy_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLChuKy ck = new CSQLChuKy();
                this.radGridView1.DataSource = ck.LoadLenLuoi(fmain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
