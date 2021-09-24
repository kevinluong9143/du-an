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
    public partial class frmLichSuGiaMuaBan : Form
    {
        frmMain fmain;
        public frmLichSuGiaMuaBan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmLichSuGiaMuaBan_Load(object sender, EventArgs e)
        {
            if (fmain.MaSPCanSua_!=null&&fmain.MaSPCanSua_.Length > 0)
            {
                CSQLLichSuGiaMuaBan lsgmb = new CSQLLichSuGiaMuaBan();
                rgvLichSuMuaHang.DataSource = lsgmb.LayLenLuoi(fmain.MaSPCanSua_);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
