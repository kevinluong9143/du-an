using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using Telerik.WinControls;
using ECOPharma2013.DuLieu;
using System.Drawing.Printing;
using System.IO;

namespace ECOPharma2013
{
    public partial class frmNhapKho : Form
    {
        frmMain _frmMain;
        CSQLNhapKho xlnhapkho = null;
        public frmNhapKho()
        {
            InitializeComponent();
        }
        public frmNhapKho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            xlnhapkho = new CSQLNhapKho();
            rgvDSPhieuNhap.DataSource = xlnhapkho.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
        }

        public void rgvDSPhieuNhap_LoadLenLuoi()
        {
            xlnhapkho = new CSQLNhapKho();
            rgvDSPhieuNhap.DataSource = xlnhapkho.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void rgvDSPhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXoa(_frmMain.fNhapKho.Name) == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                string PNid = rgvDSPhieuNhap.CurrentRow.Cells["colPNid"].Value.ToString();
                if (MessageBox.Show("Bạn có thực sự muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CSQLNhapKho nhapkho = new CSQLNhapKho();
                    int kq = nhapkho.XoaNhapKho(PNid, CStaticBien.SmaTaiKhoan);
                    if (kq > 0)
                    {
                        rgvDSPhieuNhap.DataSource = nhapkho.LayDanhSachNhapKhoLenLuoi(_frmMain.IsXemTatCa_);
                    }
                    else
                        MessageBox.Show("Xóa thất bại");
                }
            }
        }

            
        

        private void rgvDSPhieuNhap_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NhapKho();
        }

        public void SelectRows_NhapKho()
        {
            if (rgvDSPhieuNhap.CurrentRow.Cells["colPNid"].Value == null)
            {
                return;
            }
            if (_frmMain.frmNhapKhoEditisOpen_ == false)
            {
                _frmMain.IsSuaNhapKho_ = (bool)rgvDSPhieuNhap.CurrentRow.Cells["colNhapXong"].Value;
                _frmMain.XNnhapkho = (bool)rgvDSPhieuNhap.CurrentRow.Cells["colXNPhieuNhap"].Value;
                _frmMain.MaNhapKhoCanSua_ = rgvDSPhieuNhap.CurrentRow.Cells["colPNid"].Value.ToString();
                _frmMain.BangNhapKhoCanSua_ = xlnhapkho.LayNhapKhoTheoMa(_frmMain.MaNhapKhoCanSua_);
                _frmMain.fNhapKhoEdit_ = new frmNhapKhoEdit(_frmMain);
                _frmMain.kiemtraphieunhapkho = false;
                _frmMain.frmNhapKhoEditisOpen_ = true;

                _frmMain.fNhapKhoEdit_.ShowDialog();
                return;
            }
            else if (_frmMain.frmNhapKhoEditisOpen_ == true)
            {
                _frmMain.fNhapKhoEdit_.Select();
                return;
            }
        }
    }
}
