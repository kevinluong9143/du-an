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
    public partial class frmNT_KetCa : Form
    {
        frmMain _frmMain;
        public frmNT_KetCa()
        {
            InitializeComponent();
        }
        public frmNT_KetCa(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        CSQLNT_KetCa nt_ketca = new CSQLNT_KetCa();
        private void frmNT_KetCa_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLNT_KetCa ketca = new CSQLNT_KetCa();
                rgvDSKetCa.DataSource = ketca.LayDanhSachLenLuoi();
            }
            catch (Exception ex) { throw ex; }
        }

        public void SelectRows_NTKetCa()
        {
            if (rgvDSKetCa.CurrentRow.Cells["colCKCid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNT_KetCaEditisOpen_ == false)
            {

                if (rgvDSKetCa.CurrentRow.Cells["colTenMayThuNgan"].Value.ToString() == CStaticBien.STenMayThuNgan)
                {
                    Fr_DangXuLy.ShowFormCho();
                    _frmMain.IsDaXacNhan_ = (bool)rgvDSKetCa.CurrentRow.Cells["colIsDaXacNhan"].Value;
                    _frmMain.MaNT_KetCa_ = rgvDSKetCa.CurrentRow.Cells["colCKCid"].Value.ToString();
                    _frmMain.BangNT_KetCa_ = nt_ketca.LayDanhSachTheo_MaCKCid(_frmMain.MaNT_KetCa_);
                    _frmMain.fNT_KetCaEdit_ = new frmNT_KetCaEdit(_frmMain);
                    _frmMain.frmNT_KetCaEditisOpen_ = true;
                    _frmMain.fNT_KetCaEdit_.ShowDialog();
                    return;
                }
            }
            else if (_frmMain.frmNT_KetCaEditisOpen_ == true)
            {
                _frmMain.fNT_KetCaEdit_.Select();
                return;
            }
        }

        private void rgvDSKetCa_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NTKetCa();
        }

        private void rgvDSKetCa_Click(object sender, EventArgs e)
        {

        }
    }
}
