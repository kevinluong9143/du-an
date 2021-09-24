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
    public partial class frmDonHangMuaTong : Form
    {
        frmMain _frmMain;
        public frmDonHangMuaTong()
        {
            InitializeComponent();
        }
        public frmDonHangMuaTong(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void btnthemDHT_Click(object sender, EventArgs e)
        {
            #region
            if (_frmMain.frmChonDHLamDHTisOpen_ == false)
            {
                _frmMain.fChonDHLamDHT = new frmChonDHLamDHT(_frmMain);
                _frmMain.fChonDHLamDHT.Show();
                _frmMain.frmChonDHLamDHTisOpen_ = true;
            }
            else
            {
                _frmMain.fChonDHLamDHT.Select();
                return;
            }
            #endregion
        }

        private void frmDonHangMuaTong_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            try
            {
                CSQLDonHangMuaTong dhmt = new CSQLDonHangMuaTong();
                rgvDSDHMTong.DataSource = dhmt.LoadLenLuoi(_frmMain.IsXemTatCa_);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi phát sinh khi lấy dữ liệu lên lưới! \n" + ex.Message + "\n" + ex.InnerException.Message);
            }
        }

        public void HienFormChiTiet(string dhmtongid, string sodhmt)
        {
            if (rgvDSDHMTong.CurrentRow != null)
            {
                if (_frmMain.frmDonHangMuaTongEditisOpen_ == true)
                {
                    _frmMain.fDonHangMuaTongEdit.Select();
                }
                else
                {
                    _frmMain.fDonHangMuaTongEdit = new frmDonHangMuaTongEdit(_frmMain);
                    _frmMain.fDonHangMuaTongEdit.NhanDuLieuTuFormMaster(dhmtongid, sodhmt);
                    _frmMain.fDonHangMuaTongEdit.Show();
                }
            }
        }

        private void rgvDSDHMTong_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            HienFormChiTiet(rgvDSDHMTong.CurrentRow.Cells["colDHMTongid"].Value.ToString(), rgvDSDHMTong.CurrentRow.Cells["colSoDHMT"].Value.ToString());
        }

        private void rgvDSDHMTong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (int.Parse(rgvDSDHMTong.CurrentRow.Cells["colTinhTrangID"].Value.ToString()) == 1)
                {
                    //Xóa đơn hàng tổng
                    CSQLDonHangMuaTong dhmt = new CSQLDonHangMuaTong();
                    if (dhmt.Xoa(rgvDSDHMTong.CurrentRow.Cells["colDHMTongID"].Value.ToString(), CStaticBien.SmaTaiKhoan) > 0)
                    {
                        LoadLenLuoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }
    }
}
