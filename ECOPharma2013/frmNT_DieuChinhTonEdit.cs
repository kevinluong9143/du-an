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
    public partial class frmNT_DieuChinhTonEdit : Form
    {
        frmMain _frmMain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        public frmNT_DieuChinhTonEdit()
        {
            InitializeComponent();
        }
        public frmNT_DieuChinhTonEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNT_DieuChinhTonEdit_Load(object sender, EventArgs e)
        {
            bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
            if (XemKhoDacBiet == true)
                chkHangDacBiet.Show();
            else
                chkHangDacBiet.Hide();
            if (_frmMain.BangNT_DieuChinhTon_ != null && _frmMain.BangNT_DieuChinhTon_.Rows.Count > 0)
            {
                chkHangDacBiet.Enabled = false;
                CSQLNT_DieuChinhTonCT nt_dcckct_ = new CSQLNT_DieuChinhTonCT();
                txtSoPhieu.Text = _frmMain.BangNT_DieuChinhTon_.Rows[0]["SoPDC"].ToString();
                dtNgayCT.Value = (DateTime)_frmMain.BangNT_DieuChinhTon_.Rows[0]["NgayChinh"];
                txtNoiDieuChinh.Text = _frmMain.BangNT_DieuChinhTon_.Rows[0]["TenNT"].ToString();
                ckDuyet.Checked = (bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["DaXetDuyet"];
                chkHangDacBiet.Checked = (bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["IsKhoDacBiet"];
                txtGhiChu.Text = _frmMain.BangNT_DieuChinhTon_.Rows[0]["GhiChu"].ToString();

                DataTable Bangdctkchitiet = nt_dcckct_.LayTT_DCTKCT_TheoMa(_frmMain.MaNT_DieuChinhTon_);
                if (Bangdctkchitiet != null && Bangdctkchitiet.Rows.Count > 0)
                {
                    rgvChiTiet.CellFormatting += new CellFormattingEventHandler(rgvChiTiet_CellFormatting);
                    rgvChiTiet.DataSource = Bangdctkchitiet;
                }

                if ((bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["DaXacNhan"] == false)
                {
                    rgvChiTiet.ReadOnly = true;
                }
                if ((bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNT_DieuChinhTon_.Rows[0]["DaXacNhan"] == true)
                {
                    //rgvChiTiet.Enabled = false;
                    rbtnLuu.Enabled = false;
                    ckDuyet.Enabled = false;
                }
            }
        }

        void rgvChiTiet_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void rbtnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangNT_DieuChinhTon_ = null;
            _frmMain.MaNT_DieuChinhTon_ = "";
            _frmMain.frmNT_DieuChinhTonEditisOpen_ = false;
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
            //rgvChiTiet.Enabled = trangthai;
        }

        private void rbtnLuu_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNT_DieuChinhTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            
            CSQLNT_DieuChinhTon nt_dctk = new CSQLNT_DieuChinhTon();
            nt_dctk.SDCTKid = nt_dctk.LayDCTKidTheoSoPDC(txtSoPhieu.Text);
            nt_dctk.SGhiChu = txtGhiChu.Text;

            if (ckDuyet.Checked == true)
            {
                nt_dctk.BDaXetDuyet = true;
            }
            else
            {
                nt_dctk.BDaXetDuyet = false;
            }

            nt_dctk.DNgayXetDuyet = DateTime.Now;
            nt_dctk.SUserXetDuyet = CStaticBien.SmaTaiKhoan;
            int kq = nt_dctk.Sua(nt_dctk);
            if (kq == 1)
            {
                _frmMain.fNT_DieuChinhTon.rgvDieuChinhTon.DataSource = nt_dctk.LoadNT_DieuChinhTonLenLuoi(_frmMain.IsXemTatCa_);
                statusTB.Text = "Sửa điều chỉnh tồn kho thành công!";
                if (_frmMain.DSNT_DieuChinhTonXacNhanIsOpen == true)
                {
                    CSQLNT_DieuChinhTon nt_xldctk = new CSQLNT_DieuChinhTon();
                    _frmMain.fNT_DieuChinhTonXacNhan.rgvDieuChinh.DataSource = nt_xldctk.LayDanhSachNT_DieuChinhTonKhoXacNhanLenLuoi(true, false);
                }
            }
            else
            {
                statusTB.Text = "Sửa điều chỉnh tồn kho thất bại.";
            }
        }

        private void rbtnIn_Click(object sender, EventArgs e)
        {
            InNT_DieuChinhTon(_frmMain.MaNT_DieuChinhTon_);
        }

        public void InNT_DieuChinhTon(string dctid_)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fNT_DieuChinhTon.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNT_DieuChinhTonCT nt_dctkct_ = new CSQLNT_DieuChinhTonCT();
            DataTable NT_DCTKCT_ = nt_dctkct_.IN_NTDCTK_NTDCTKCT(dctid_);
            Fr_NT_DieuChinhTonKho check = new Fr_NT_DieuChinhTonKho(NT_DCTKCT_);
            check.Show();
        }
    }
}
