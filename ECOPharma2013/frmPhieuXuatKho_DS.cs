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
using Telerik.WinControls;

namespace ECOPharma2013
{
    public partial class frmPhieuXuatKho_DS : Form
    {
        frmMain _frmMain;
        public frmPhieuXuatKho_DS()
        {
            InitializeComponent();
        }
        public frmPhieuXuatKho_DS(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmPhieuXuatKho_DS_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLPhieuXuat px_ = new CSQLPhieuXuat();
                rgvDSPhieuXK.DataSource = px_.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rgvDSPhieuXK_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            HienFormEdit();
        }

        public void HienFormEdit()
        {
            try
            {
                CSQLPhieuXuat px_ = new CSQLPhieuXuat();
                if (rgvDSPhieuXK.CurrentRow.Cells["colPXid"].Value == null)
                {
                    return;
                }
                _frmMain.IsBangPhieuXuatKho_ = true;
                if (_frmMain.frmPhieuXuatKhoEditisOpen_ == false)
                {
                    _frmMain.MaPhieuXuatKho_DS_ = rgvDSPhieuXK.CurrentRow.Cells["colPXid"].Value.ToString();
                    _frmMain.BangPhieuXuatKho_DS_ = px_.LayDSPhieuXuat_TheoPXid(_frmMain.MaPhieuXuatKho_DS_);
                    _frmMain.fPhieuXuatKhoEdit = new frmPhieuXuatKhoEdit(_frmMain);
                    _frmMain.frmNhaThuocEditisOpen_ = true;

                    _frmMain.fPhieuXuatKhoEdit.ShowDialog();
                    return;
                }
                else if (_frmMain.frmPhieuXuatKhoEditisOpen_ == true)
                {
                    _frmMain.fPhieuXuatKhoEdit.Select();
                    return;
                }
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}
