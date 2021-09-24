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
    
    public partial class frmDieuChinhHSD : Form
    {
        frmMain _frmMain;
        public frmDieuChinhHSD()
        {
            InitializeComponent();
        }
        public frmDieuChinhHSD(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmDieuChinhHSD_Load(object sender, EventArgs e)
        {
            CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
            rgvPhieuDCHSD.DataSource = dchsd_.LoadDieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvPhieuDCHSD_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_DieuChinhKho();
        }
        public void SelectRows_DieuChinhKho()
        {
            CSQLDieuChinhHSD dchsd_ = new CSQLDieuChinhHSD();
            if (rgvPhieuDCHSD.CurrentRow.Cells["colDCHDid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmDieuChinhHSDEditisOpen_ == false)
            {
                _frmMain.MaDieuChinhHSD_ = rgvPhieuDCHSD.CurrentRow.Cells["colDCHDid"].Value.ToString();
                _frmMain.BangDieuChinhHSD_ = dchsd_.LayDieuChinhHSDTheoMa(_frmMain.MaDieuChinhHSD_);

                _frmMain.fDieuChinhHSDEdit_ = new frmDieuChinhHSDEdit(_frmMain);

                _frmMain.frmDieuChinhHSDEditisOpen_ = true;

                _frmMain.fDieuChinhHSDEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmDieuChinhHSDEditisOpen_ == true)
            {
                _frmMain.fDieuChinhHSDEdit_.Select();
                return;
            }
        }
    }
}
