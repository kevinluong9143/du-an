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

namespace ECOPharma2013
{
    public partial class frmBaoCaoCongTy : Form
    {
        frmMain _frmMain;
        public frmBaoCaoCongTy()
        {
            InitializeComponent();
        }
        public frmBaoCaoCongTy(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        private void frmBaoCaoTonKhoCty_Load(object sender, EventArgs e)
        {

        }
        private void rtvBaoCaoCty_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Báo Cáo Tồn Kho Công Ty Và Nhà Thuốc")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_TonKho_Cty") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_TonKho_Cty check = new Fr_BC_TonKho_Cty();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Xuất Kho Trung Bình")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_XuatKhoTB") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_XuatKhoTB check = new Fr_BC_XuatKhoTB();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Bán Hàng Chi Tiết")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_BanHang") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_BanHang check = new Fr_BC_BanHang();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Trả Hàng Chi Tiết")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_TraHang") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_TraHang check = new Fr_BC_TraHang();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Sản Phẩm Chi Tiết")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_SanPham") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                int dieukiensp = 1;
                Fr_BC_SanPham check = new Fr_BC_SanPham(dieukiensp);
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Đơn Hàng Chờ")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_DonHangCho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_DonHangCho check = new Fr_BC_DonHangCho();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Biên Bản Kiểm Kê")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_BienBanKiemKe") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_BienBanKiemKe check = new Fr_BC_BienBanKiemKe();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Chuyển Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_ChuyenKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_ChuyenKho check = new Fr_BC_ChuyenKho();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Tổng SL Xuất Nhập Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_TongSLXuatNhapKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                Fr_BC_TongSLXuatNhapKho _form = new Fr_BC_TongSLXuatNhapKho();
                _form.Show();
            }
            else if (e.Node.Text == "Báo Cáo Định Mức Tồn Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_DinhMucTonKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                Fr_BC_DinhMucTonKho _form = new Fr_BC_DinhMucTonKho();
                _form.Show();
            }
            else if (e.Node.Text == "Báo Cáo Đơn Hàng Đã Xuất Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_DonHangDaXuatKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                Fr_BC_DonHangDaXuatKho _form = new Fr_BC_DonHangDaXuatKho();
                _form.Show();
            }
            
            
        }

        private void rtvBaoCaoCty_1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Báo Cáo Đơn Hàng Đã Nhập Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_HoanThanhNhapKho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_HoanThanhNhapKho check = new Fr_BC_HoanThanhNhapKho();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Hệ Số Qui Đổi")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_HeSoQuiDoi") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_HeSoQuiDoi check = new Fr_BC_HeSoQuiDoi();
                check.Show();
            }

            else if (e.Node.Text == "Báo Cáo Lịch Sử Giá Bán Của Nhà Thuốc")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_LichSuGiaBan") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_LichSuGiaBan check = new Fr_BC_LichSuGiaBan();
                check.Show();
            }

            else if (e.Node.Text == "Báo Cáo Doanh Số Bán Hàng")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_DoanhSoBanHang") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_DoanhSoBanHang check = new Fr_BC_DoanhSoBanHang();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Nhập Kho Theo Nhà Cung Cấp")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NhapKhoTheoNCC") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NhapKhoTheoNCC check = new Fr_BC_NhapKhoTheoNCC();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Lượt Khách Hàng")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_LuotKhachHang") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_LuotKhachHang check = new Fr_BC_LuotKhachHang();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Nhà Thuốc Trả Hàng Về Công Ty")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NT_TraHangVeCty") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NT_TraHangVeCty check = new Fr_BC_NT_TraHangVeCty();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Lượt Xem Báo Cáo")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_SLXemForm") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }

                Fr_BC_SLXemForm check = new Fr_BC_SLXemForm();
                check.ShowDialog();
            }
            else if (e.Node.Text == "Báo Cáo Lịch Sử Giá Mua Theo NPP")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_GiaTheoNPP") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_GiaTheoNPP aGiaTheoNPP = new Fr_BC_GiaTheoNPP();
                aGiaTheoNPP.ShowDialog();
            }
            else if (e.Node.Text == "Báo Cáo Cận Hạn Dùng - Hết Hạn Dùng")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_CanDate_HetDate_CTY") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_CanDate_HetDate_CTY CanDate_HetDate_CTY = new Fr_BC_CanDate_HetDate_CTY();
                CanDate_HetDate_CTY.ShowDialog();
            }
            else if (e.Node.Text == "Báo Cáo Xuất Nhanh")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_XuatNhanh") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_XuatNhanh xuatnhanh = new Fr_BC_XuatNhanh();
                xuatnhanh.ShowDialog();
            }
            else if (e.Node.Text == "Báo Cáo Ngày Tạo Phiếu Nhập Kho")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NhapKhoTheoNCC_Kho") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NhapKhoTheoNCC_Kho check = new Fr_BC_NhapKhoTheoNCC_Kho();
                check.Show();
            }
            else if (e.Node.Text == "Báo Cáo Nhập Kho Theo Nhà Sản Xuất")
            {
                CQuyenTruyCap qtc = new CQuyenTruyCap();
                if (qtc.KiemTraQuyenXem("Fr_BC_NhapKhoTheoNSX") == false)
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                    return;
                }
                Fr_BC_NhapKhoTheoNSX check = new Fr_BC_NhapKhoTheoNSX();
                check.Show();
            }

        }

        private void rtvBaoCaoCty_1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
