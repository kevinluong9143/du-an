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
    public partial class frmNT_DieuChinhTon : Form
    {
        frmMain _frmMain;
        public frmNT_DieuChinhTon()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhTon(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhTon_Load(object sender, EventArgs e)
        {
            CSQLNT_DieuChinhTon nt_dct_ = new CSQLNT_DieuChinhTon();
            rgvDieuChinhTon.DataSource = nt_dct_.LoadNT_DieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvDieuChinhTon_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NT_DieuChinhKho();
        }
        public void SelectRows_NT_DieuChinhKho()
        {
            CSQLNT_DieuChinhTon nt_dct_ = new CSQLNT_DieuChinhTon();
            if (rgvDieuChinhTon.CurrentRow.Cells["colDCTKid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNT_DieuChinhTonEditisOpen_ == false)
            {
                _frmMain.MaNT_DieuChinhTon_ = rgvDieuChinhTon.CurrentRow.Cells["colDCTKid"].Value.ToString();
                _frmMain.BangNT_DieuChinhTon_ = nt_dct_.LayDieuChinhTonKhoTheoMa(_frmMain.MaNT_DieuChinhTon_);

                _frmMain.fNT_DieuChinhTonEdit_ = new frmNT_DieuChinhTonEdit(_frmMain);

                _frmMain.frmNT_DieuChinhTonEditisOpen_ = true;

                _frmMain.fNT_DieuChinhTonEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNT_DieuChinhTonEditisOpen_ == true)
            {
                _frmMain.fNT_DieuChinhTonEdit_.Select();
                return;
            }
        }
    }
}
