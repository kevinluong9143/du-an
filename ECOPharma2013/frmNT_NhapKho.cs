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

namespace ECOPharma2013
{
    public partial class frmNT_NhapKho : Form
    {
        frmMain _frmMain;
        public frmNT_NhapKho()
        {
            InitializeComponent();
        }
        public frmNT_NhapKho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLNT_NhapKho nt_nhapkho = new CSQLNT_NhapKho();
        private void frmNT_NhapKho_Load(object sender, EventArgs e)
        {
            rgvDSPhieuNhap.DataSource = nt_nhapkho.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
        }

        public void SelectRows_NTNhapKho()
        {
            if (rgvDSPhieuNhap.CurrentRow.Cells["colPNid"].Value == null)
            {
                return;
            }

            if (_frmMain.frmNT_NhapKhoEditisOpen_ == false)
            {
                _frmMain.MaNT_NhapKho_ = rgvDSPhieuNhap.CurrentRow.Cells["colPNid"].Value.ToString();
                _frmMain.BangNT_NhapKho_ = nt_nhapkho.LayNhapKhoTheoMa(_frmMain.MaNT_NhapKho_);
                _frmMain.fNT_NhapKhoEdit_ = new frmNT_NhapKhoEdit(_frmMain);
                _frmMain.frmNT_NhapKhoEditisOpen_ = true;

                _frmMain.fNT_NhapKhoEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNT_NhapKhoEditisOpen_ == true)
            {
                _frmMain.fNT_NhapKhoEdit_.Select();
                return;
            }
        }

        private void rgvDSPhieuNhap_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NTNhapKho();
        }
    }
}
