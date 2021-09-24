using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;
using ECOPharma2013.From_Report;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    public partial class frmBaoCaoNhaThuoc : Form
    {
        frmMain _frmMain;
        public frmBaoCaoNhaThuoc()
        {
            InitializeComponent();
        }
        public frmBaoCaoNhaThuoc(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmBaoCaoNhaThuoc_Load(object sender, EventArgs e)
        {

        }

        private void rtvBaoCaoNT_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Báo Cáo Tồn Kho Nhà Thuốc")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_TonKho_NT") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                //string tieude = "TỒN KHO NHÀ THUỐC";
                //CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                //DataTable dtbTonKhoCT = tonkhoct_.LoadDataTonKhoNT();
                //if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                //{
                //    Fr_BC_TonKho_NT check = new Fr_BC_TonKho_NT(dtbTonKhoCT, tieude);
                //    check.Show();
                //}
                //else
                //{
                //    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                //}
                Fr_BC_TonKho_NT check = new Fr_BC_TonKho_NT();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Các Sản Phẩm Cận Date")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_CanDate_NT") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_CanDate_NT check = new Fr_BC_CanDate_NT();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Các Sản Phẩm Ít Bán")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_SPItBan_NT") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_SPItBan_NT check = new Fr_BC_SPItBan_NT();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Số Phiếu Hủy")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_PhieuHuy") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_PhieuHuy check = new Fr_BC_PhieuHuy();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Hàng Âm")
            {
                string tieude = "TỒN KHO HÀNG ÂM NHÀ THUỐC";
                CSQLTonKhoCT tonkhoct_ = new CSQLTonKhoCT();
                DataTable dtbTonKhoCT = tonkhoct_.LoadDataTonKhoNTHangAm();
                if (dtbTonKhoCT != null && dtbTonKhoCT.Rows.Count > 0)
                {
                    Fr_BC_HangAm_NT check = new Fr_BC_HangAm_NT(dtbTonKhoCT, tieude);
                    check.Show();
                }
                else
                {
                    MessageBox.Show("Dữ liệu tồn kho không có. Vui lòng kiểm tra lại!");
                }
            }
            else if (e.Node.Text == "Báo Cáo Sản Phẩm Chi Tiết")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_SanPham") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                int dieukiensp = 2;
                Fr_BC_SanPham check = new Fr_BC_SanPham(dieukiensp);
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Tổng Số Lượng Xuất")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_TongSoLuongBan") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_TongSoLuongBan check = new Fr_BC_TongSoLuongBan();
                check.Show();
            }

            else if (e.Node.Text == "Báo Cáo Phiếu Nhập Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NT_NhapKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NT_NhapKho check = new Fr_BC_NT_NhapKho();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Thay Đổi Giá Bán")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NT_ThayDoiGiaBan") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NT_ThayDoiGiaBan check = new Fr_BC_NT_ThayDoiGiaBan();
                check.Show();
            }
        }
    }
}
