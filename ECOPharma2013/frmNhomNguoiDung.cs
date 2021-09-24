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
    public partial class frmNhomNguoiDung : Form
    {
        private frmMain _frmMain;

        public frmNhomNguoiDung(frmMain fMain)
        {
            InitializeComponent();
            _frmMain = fMain;
        }

        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            CSQLNhomNguoiDung nndung_ = new CSQLNhomNguoiDung();
            rgvNhomNguoiDung.DataSource = nndung_.LayDSNhomNguoiDungLenLuoi(_frmMain.IsXemTatCa_);

        }

        private void rgvNhomNguoiDung_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
                SelectRows_NhomNguoiDung();
        }
        public void SelectRows_NhomNguoiDung()
        {
            CSQLNhomNguoiDung nndung_ = new CSQLNhomNguoiDung();
            if (rgvNhomNguoiDung.CurrentRow.Cells["colNhomNDid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNhomNguoiDungEditisOpen_ == false)
            {
                _frmMain.MaNhomNguoiDungCanSua_ = rgvNhomNguoiDung.CurrentRow.Cells["colNhomNDid"].Value.ToString();
                _frmMain.BangNhomNguoiDungCanSua_ = nndung_.LayNhomNguoiDungTheoMa(_frmMain.MaNhomNguoiDungCanSua_);

                _frmMain.fNhomNguoiDungEdit_ = new frmNhomNguoiDungEdit(_frmMain);

                _frmMain.frmNhomNguoiDungEditisOpen_ = true;

                _frmMain.fNhomNguoiDungEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNhomNguoiDungEditisOpen_ == true)
            {
                _frmMain.fNhomNguoiDungEdit_.Select();
                return;
            }
        }
    }
}
