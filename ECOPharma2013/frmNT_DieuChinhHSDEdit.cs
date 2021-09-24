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
using Telerik.WinControls.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ECOPharma2013.From_Report;


namespace ECOPharma2013
{
    public partial class frmNT_DieuChinhHSDEdit : Form
    {
        frmMain _frmMain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        public frmNT_DieuChinhHSDEdit()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhHSDEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhHSDEdit_Load(object sender, EventArgs e)
        {
            bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
            if (XemKhoDacBiet == true)
                chkHangDacBiet.Show();
            else
                chkHangDacBiet.Hide();
            if (_frmMain.BangNT_DieuChinhHSD_ != null && _frmMain.BangNT_DieuChinhHSD_.Rows.Count > 0)
            {
                chkHangDacBiet.Enabled = false;
                CSQLNT_DieuChinhHSDCT nt_dchsdct_ = new CSQLNT_DieuChinhHSDCT();
                txtSoPhieu.Text = _frmMain.BangNT_DieuChinhHSD_.Rows[0]["SoPDC"].ToString();
                dtNgayCT.Value = (DateTime)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["NgayChinh"];
                txtNoiDieuChinh.Text = _frmMain.BangNT_DieuChinhHSD_.Rows[0]["TenNT"].ToString();
                ckDuyet.Checked = (bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["DaXetDuyet"];
                chkHangDacBiet.Checked = (bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["IsKhoDacBiet"];
                txtGhiChu.Text = _frmMain.BangNT_DieuChinhHSD_.Rows[0]["GhiChu"].ToString();

                DataTable Bangdctkchitiet = nt_dchsdct_.LayTT_DCHDCT_TheoMa(_frmMain.MaNT_DieuChinhHSD_);
                if (Bangdctkchitiet != null && Bangdctkchitiet.Rows.Count > 0)
                {
                    rgvChiTiet.DataSource = Bangdctkchitiet;
                }

                if ((bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["DaXacNhan"] == false)
                {
                    rgvChiTiet.ReadOnly = true;
                }
                if ((bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNT_DieuChinhHSD_.Rows[0]["DaXacNhan"] == true)
                {
                    //rgvChiTiet.Enabled = false;
                    rbtnLuu.Enabled = false;
                    ckDuyet.Enabled = false;
                }
            }
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangNT_DieuChinhHSD_ = null;
            _frmMain.MaNT_DieuChinhHSD_ = "";
            _frmMain.frmNT_DieuChinhHSDEditisOpen_ = false;
            this.Close();
        }

        private void ckDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDuyet.Checked == true)
            {
                ThayDoiTrangThaiControls(false);
            }
            else
            {
                ThayDoiTrangThaiControls(true);
            }
        }
        private void ThayDoiTrangThaiControls(bool trangthai)
        {
            txtGhiChu.Enabled = trangthai;

        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            //CQuyenTruyCap qtc = new CQuyenTruyCap();
            //if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_DieuChinhTon.Name) == false)
            //{
            //    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
            //    return;
            //}

            CSQLNT_DieuChinhHSD nt_dchsd = new CSQLNT_DieuChinhHSD();
            nt_dchsd.SDCHDid = nt_dchsd.LayDCHDidTheoSoPDC(txtSoPhieu.Text);
            nt_dchsd.SGhiChu = txtGhiChu.Text;

            if (ckDuyet.Checked == true)
            {
                nt_dchsd.BDaXetDuyet = true;
            }
            else
            {
                nt_dchsd.BDaXetDuyet = false;
            }

            nt_dchsd.DNgayXetDuyet = DateTime.Now;
            nt_dchsd.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
            int kq = nt_dchsd.Sua(nt_dchsd);
            if (kq == 1)
            {
                _frmMain.fNT_DieuChinhHSD.rgvDieuChinhTon.DataSource = nt_dchsd.LoadNT_DieuChinhHSDLenLuoi(_frmMain.IsXemTatCa_);
                statusTB.Text = "Sửa chuyển kho thành công!";
                if (_frmMain.DSNT_DieuChinhHSDXacNhanIsOpen == true)
                {
                    CSQLNT_DieuChinhHSD nt_xldchsd = new CSQLNT_DieuChinhHSD();
                    _frmMain.fNT_DieuChinhHSDXacNhan.rgvDieuChinh.DataSource = nt_xldchsd.LayDanhSachNT_DieuChinhHSDXacNhanLenLuoi(true, false);
                }
            }
            else
            {
                statusTB.Text = "Sửa chuyển kho thất bại.";
            }
        }
    }
}
