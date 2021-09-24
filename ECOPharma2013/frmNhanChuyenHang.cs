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
    public partial class frmNhanChuyenHang : Form
    {
        frmMain _frmMain;
        public frmNhanChuyenHang()
        {
            InitializeComponent();
        }
        public frmNhanChuyenHang(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhanChuyenHang_Load(object sender, EventArgs e)
        {
            CSQLNhanChuyenHang nch_ = new CSQLNhanChuyenHang();
            rgvNhanChuyenHang.DataSource = nch_.LoadNhanChuyenHangLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvNhanChuyenHang_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            SelectRows_NhanChuyenHang();
        }
        public void SelectRows_NhanChuyenHang()
        {
            CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
            if (rgvNhanChuyenHang.CurrentRow.Cells["colNCHid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNhanChuyenHangEditisOpen_ == false)
            {
                _frmMain.MaNhanChuyenHang_ = rgvNhanChuyenHang.CurrentRow.Cells["colNCHid"].Value.ToString();
                _frmMain.BangNhanChuyenHang_ = nch.LayNhanChuyenHangTheoMa(_frmMain.MaNhanChuyenHang_);

                _frmMain.fNhanChuyenHangEdit_ = new frmNhanChuyenHangEdit(_frmMain);

                _frmMain.frmNhanChuyenHangEditisOpen_ = true;

                _frmMain.fNhanChuyenHangEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNhanChuyenHangEditisOpen_ == true)
            {
                _frmMain.fNhanChuyenHangEdit_.Select();
                return;
            }
        }
    }
}
