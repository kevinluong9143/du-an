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
    public partial class frmDieuChinhHSDXacNhan : Form
    {
        frmMain _frmMain;
        public frmDieuChinhHSDXacNhan()
        {
            InitializeComponent();
        }
        public frmDieuChinhHSDXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmDieuChinhHSDXacNhan_Load(object sender, EventArgs e)
        {
            CSQLDieuChinhHSD xldchsd = new CSQLDieuChinhHSD();
            rgvPhieuDieuChinh.DataSource = xldchsd.LayDanhSachDieuChinhHSDXacNhanLenLuoi(true, false);
        }
    }
}
