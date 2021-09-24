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
    public partial class frmNhanChuyenHangEdit : Form
    {
        frmMain _frmMain;
        CSQLCauHinhHeThong chht_ = new CSQLCauHinhHeThong();
        public frmNhanChuyenHangEdit()
        {
            InitializeComponent();
        }
        public frmNhanChuyenHangEdit(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhanChuyenHangEdit_Load(object sender, EventArgs e)
        {
            bool XemKhoDacBiet = (bool)chht_.LayDanhSachCauHinhHeThong().Rows[0]["IsXemKhoDacBiet"];
            if (XemKhoDacBiet == true)
                chkHangDacBiet.Show();
            else
                chkHangDacBiet.Hide();
            //rgvPhieuChuyenCT.Enabled = false;
            if (_frmMain.BangNhanChuyenHang_ != null && _frmMain.BangNhanChuyenHang_.Rows.Count > 0)
            {
                chkHangDacBiet.Enabled = false;
                CSQLNhanChuyenHang nhanchuyenhang_ = new CSQLNhanChuyenHang();
                txtSoPC.Text = _frmMain.BangNhanChuyenHang_.Rows[0]["SoPCH"].ToString();
                dtNgayCT.Value = (DateTime)_frmMain.BangNhanChuyenHang_.Rows[0]["NgayChungTu"];
                txtTuNT.Text = _frmMain.BangNhanChuyenHang_.Rows[0]["TuNT"].ToString();
                txtToiNT.Text = _frmMain.BangNhanChuyenHang_.Rows[0]["ToiNT"].ToString();
                ckDuyetPC.Checked = (bool)_frmMain.BangNhanChuyenHang_.Rows[0]["DaXetDuyet"];
                chkHangDacBiet.Checked = (bool)_frmMain.BangNhanChuyenHang_.Rows[0]["IsKhoDacBiet"];
                txtGhiChu.Text = _frmMain.BangNhanChuyenHang_.Rows[0]["GhiChu"].ToString();

                DataTable Bangnchchitiet = nhanchuyenhang_.LayNhanChuyenHangCT_TheoNCHid(_frmMain.MaNhanChuyenHang_);
                if (Bangnchchitiet != null && Bangnchchitiet.Rows.Count > 0)
                {
                    rgvPhieuChuyenCT.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(rgvPhieuChuyenCT_CellFormatting);
                    rgvPhieuChuyenCT.DataSource = Bangnchchitiet;
                }
                //if ((bool)_frmMain.BangNhanChuyenHang_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNhanChuyenHang_.Rows[0]["DaXacNhan"] == false)
                //{
                //    rgvPhieuChuyenCT.Enabled = false;
                //}
                if ((bool)_frmMain.BangNhanChuyenHang_.Rows[0]["DaXetDuyet"] == true && (bool)_frmMain.BangNhanChuyenHang_.Rows[0]["DaXacNhan"] == true)
                {
                    btnLuu.Enabled = false;
                    ckDuyetPC.Enabled = false;
                }
            }
        }
        void rgvPhieuChuyenCT_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "colSTT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fNhanChuyenHang.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            CSQLNhanChuyenHang nch_ = new CSQLNhanChuyenHang();

            nch_.UpdateDaXetDuyet(_frmMain.MaNhanChuyenHang_, ckDuyetPC.Checked);
            _frmMain.fNhanChuyenHang.rgvNhanChuyenHang.DataSource = nch_.LoadNhanChuyenHangLenLuoi(_frmMain.IsXemTatCa_);

            if (_frmMain.DSNhanCHuyenHangXacNhanIsOpen == true)
            {
                CSQLNhanChuyenHang nch = new CSQLNhanChuyenHang();
                _frmMain.fNhanChuyenHangXacNhan.rgvPhieuChuyenHang.DataSource = nch.LayDSNhanChuyenHangXacNhanLenLuoi(true, false);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.BangNhanChuyenHang_ = null;
            _frmMain.MaNhanChuyenHang_ = "";
            _frmMain.frmNhanChuyenHangEditisOpen_ = false;
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CSQLNhanChuyenHangCT ntch_ = new CSQLNhanChuyenHangCT();
            if (_frmMain.MaNhanChuyenHang_ != null && _frmMain.MaNhanChuyenHang_.Length > 0)
            {
                DataTable NTChuyenHangCT_ = ntch_.IN_NCH_NCHCT(_frmMain.MaNhanChuyenHang_);
                if (NTChuyenHangCT_ != null && NTChuyenHangCT_.Rows.Count > 0)
                {
                    Fr_NTChuyenHang check = new Fr_NTChuyenHang(NTChuyenHangCT_);
                    check.Show();
                }
            }
        }
    }
}
