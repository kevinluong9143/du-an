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
using Telerik.WinControls.UI;

namespace ECOPharma2013
{
    public partial class frmNT_DieuChinhTonXacNhan : Form
    {
        frmMain _frmMain;
        public frmNT_DieuChinhTonXacNhan()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhTonXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhTonXacNhan_Load(object sender, EventArgs e)
        {
            CSQLNT_DieuChinhTon nt_xldctk = new CSQLNT_DieuChinhTon();
            rgvDieuChinh.DataSource = nt_xldctk.LayDanhSachNT_DieuChinhTonKhoXacNhanLenLuoi(true, false);
        }
    }
}
