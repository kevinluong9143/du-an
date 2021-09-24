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
    public partial class frmNT_DieuChinhHSDXacNhan : Form
    {
        frmMain _frmMain;
        public frmNT_DieuChinhHSDXacNhan()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhHSDXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhHSDXacNhan_Load(object sender, EventArgs e)
        {
            CSQLNT_DieuChinhHSD nt_xldchsd = new CSQLNT_DieuChinhHSD();
            rgvDieuChinh.DataSource = nt_xldchsd.LayDanhSachNT_DieuChinhHSDXacNhanLenLuoi(true, false);
        }
    }
}
