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
    public partial class frmDieuChinhTonXacNhan : Form
    {
        frmMain _frmMain;
        public frmDieuChinhTonXacNhan()
        {
            InitializeComponent();
        }
        public frmDieuChinhTonXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmDieuChinhTonXacNhan_Load(object sender, EventArgs e)
        {
            CSQLDieuChinhTon xldctk = new CSQLDieuChinhTon();
            rgvPhieuDieuChinh.DataSource = xldctk.LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(true, false);
        }
    }
}
