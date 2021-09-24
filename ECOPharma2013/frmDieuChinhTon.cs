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

namespace ECOPharma2013
{
    public partial class frmDieuChinhTon : Form
    {
        frmMain _frmMain;
        public frmDieuChinhTon()
        {
            InitializeComponent();
        }
        public frmDieuChinhTon(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmDieuChinhTon_Load(object sender, EventArgs e)
        {
            CSQLDieuChinhTon dct_ = new CSQLDieuChinhTon();
            rgvPhieuDCTon.DataSource = dct_.LoadDieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvPhieuDCTon_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_DieuChinhKho();
        }
        public void SelectRows_DieuChinhKho()
        {
            CSQLDieuChinhTon dct_ = new CSQLDieuChinhTon();
            if (rgvPhieuDCTon.CurrentRow.Cells["colDCTKid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmDieuChinhTonEditisOpen_ == false)
            {
                _frmMain.MaDieuChinhTon_ = rgvPhieuDCTon.CurrentRow.Cells["colDCTKid"].Value.ToString();
                _frmMain.BangDieuChinhTon_ = dct_.LayDieuChinhTonKhoTheoMa(_frmMain.MaDieuChinhTon_);

                _frmMain.fDieuChinhTonEdit_ = new frmDieuChinhTonEdit(_frmMain);

                _frmMain.frmDieuChinhTonEditisOpen_ = true;

                _frmMain.fDieuChinhTonEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmDieuChinhTonEditisOpen_ == true)
            {
                _frmMain.fDieuChinhTonEdit_.Select();
                return;
            }
        }
    }
}
