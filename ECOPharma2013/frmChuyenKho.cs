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
    public partial class frmChuyenKho : Form
    {
        frmMain _frmMain;
        public frmChuyenKho()
        {
            InitializeComponent();
        }
        public frmChuyenKho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmChuyenKho_Load(object sender, EventArgs e)
        {
            CSQLChuyenKho chuyenkho = new CSQLChuyenKho();
            rgvChuyenKho.DataSource = chuyenkho.LoadChuyenKhoLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvChuyenKho_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_ChuyenKho();
        }
        public void SelectRows_ChuyenKho()
        {
            CSQLChuyenKho ck = new CSQLChuyenKho();
            if (rgvChuyenKho.CurrentRow.Cells["colCKid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmChuyenKhoEditisOpen_ == false)
            {
                _frmMain.MaChuyenKho_ = rgvChuyenKho.CurrentRow.Cells["colCKid"].Value.ToString();
                _frmMain.BangChuyenKho_ = ck.LayChuyenKhoTheoMa(_frmMain.MaChuyenKho_);
                
                _frmMain.fChuyenKhoEdit_ = new frmChuyenKhoEdit(_frmMain);

                _frmMain.frmChuyenKhoEditisOpen_ = true;

                _frmMain.fChuyenKhoEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmChuyenKhoEditisOpen_ == true)
            {
                _frmMain.fChuyenKhoEdit_.Select();
                return;
            }
        }
    }
}
