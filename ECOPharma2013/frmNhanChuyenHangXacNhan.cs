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
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ECOPharma2013
{
    public partial class frmNhanChuyenHangXacNhan : Form
    {
        frmMain _frmMain;
        public frmNhanChuyenHangXacNhan()
        {
            InitializeComponent();
        }
        public frmNhanChuyenHangXacNhan(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhanChuyenHangXacNhan_Load(object sender, EventArgs e)
        {
            CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
            rgvPhieuChuyenHang.DataSource = nch.LayDSNhanChuyenHangXacNhanLenLuoi(true, false);
        }
    }
}
