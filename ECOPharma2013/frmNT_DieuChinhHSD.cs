using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmNT_DieuChinhHSD : Form
    {
        frmMain _frmMain;
        public frmNT_DieuChinhHSD()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhHSD(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhHSD_Load(object sender, System.EventArgs e)
        {
            CSQLNT_DieuChinhHSD nt_dchsd_ = new CSQLNT_DieuChinhHSD();
            rgvDieuChinhTon.DataSource = nt_dchsd_.LoadNT_DieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvDieuChinhTon_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
        SelectRows_NT_DieuChinhHSD();
        }
        public void SelectRows_NT_DieuChinhHSD()
        {
            CSQLNT_DieuChinhHSD nt_dchsd_ = new CSQLNT_DieuChinhHSD();
            if (rgvDieuChinhTon.CurrentRow.Cells["colDCHDid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNT_DieuChinhHSDEditisOpen_ == false)
            {
                _frmMain.MaNT_DieuChinhHSD_ = rgvDieuChinhTon.CurrentRow.Cells["colDCHDid"].Value.ToString();
                _frmMain.BangNT_DieuChinhHSD_ = nt_dchsd_.LayDieuChinhHSDTheoMa(_frmMain.MaNT_DieuChinhHSD_);

                _frmMain.fNT_DieuChinhHSDEdit_ = new frmNT_DieuChinhHSDEdit(_frmMain);

                _frmMain.frmNT_DieuChinhHSDEditisOpen_ = true;

                _frmMain.fNT_DieuChinhHSDEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNT_DieuChinhHSDEditisOpen_ == true)
            {
                _frmMain.fNT_DieuChinhHSDEdit_.Select();
                return;
            }
        }
    }
}
