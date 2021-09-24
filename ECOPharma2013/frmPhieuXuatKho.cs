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
using ECOPharma2013.Report1;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace ECOPharma2013
{
    public partial class frmPhieuXuatKho : Form
    {
        frmMain _frmMain;
        int DonHang;
        bool IsPhieuCuoi;
        string PXID;
		// DungLV add Hoa don do start
        String PXID_HOADON;
        String PXID_KHONGHOADON;
        // DungLV add hoa don do end
		public frmPhieuXuatKho()
        {
            InitializeComponent();
        }
        public frmPhieuXuatKho(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(_frmMain.fPhieuXuatKho_DS.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            } 
            try
            {
                progressBarTinhTrangXuatKho.Minimum = 0;
                progressBarTinhTrangXuatKho.Value = 0;

                CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                DataTable dtbdhx = dhx.LayDSDaXacNhanChuaCoPhieuXuat();
                CSQLNhapKho nk = new CSQLNhapKho();
                DataTable dtbnhapdirect = nk.LayDSDonHangDirect();
                // DungLV add Xuat Chi Dinh Don Hang Start
                DataTable dtXuatCoChiDinh = dhx.LayDSDaXacNhanChuaCoPhieuXuat_XuatCoChiDinh();
                // DungLV add Xuat Chi Dinh Don Hang End

                if (ckLayPhieuXuatDirect.Checked == true)
                {
                    //Xử lý phiếu xuất phát sinh từ đơn hàng nhập direct
                    #region Xử lý phiếu xuất phát sinh từ đơn hàng nhập direct
                    if (dtbnhapdirect != null && dtbnhapdirect.Rows.Count > 0)
                    {
                        progressBarTinhTrangXuatKho.Maximum = dtbnhapdirect.Rows.Count;
                        foreach (DataRow drdirect in dtbnhapdirect.Rows)
                        {
                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                            DataTable dtbdirect = px.LayPhieuNhapDirectCT(drdirect["PNID"].ToString());
                            string[] mangpxid_sopx = {};
                            String maKho = "";
                            if (dtbdirect != null && dtbdirect.Rows.Count > 0)
                            {
                                DataRow dtrow = dtbdirect.Rows[0];
                                maKho = dtrow["MaKho"].ToString();
                            }
                            if (maKho == "D6A8C093-0783-478D-B68F-4E7006E577DC") 
                                mangpxid_sopx = px.Them_HoaDon(drdirect["SoCTN"].ToString(), drdirect["XuatChoNT"].ToString(), false, true, 0, DateTime.Now, DateTime.Now, false, CStaticBien.SmaTaiKhoan, CStaticBien.SmaTaiKhoan, false, false);
                            else
                                mangpxid_sopx = px.Them(drdirect["SoCTN"].ToString(), drdirect["XuatChoNT"].ToString(), false, true, 0, DateTime.Now, DateTime.Now, false, CStaticBien.SmaTaiKhoan, CStaticBien.SmaTaiKhoan, false, false);
                            if (mangpxid_sopx != null && mangpxid_sopx[0].Length > 0)
                            {
                                //DataTable dtbdirect = px.LayPhieuNhapDirectCT(drdirect["PNID"].ToString());
                                if (dtbdirect != null && dtbdirect.Rows.Count > 0)
                                {

                                    foreach (DataRow drdirectct in dtbdirect.Rows)
                                    {
                                        CSQLDinhGia dinhgia = new CSQLDinhGia();
                                        decimal markup = (decimal)dinhgia.LayMarkup(drdirectct["SPID"].ToString(), drdirect["XuatChoNT"].ToString());
                                        px.InsertPhieuXuatCT(mangpxid_sopx[0],
                                            drdirectct["SPID"].ToString(),
                                            drdirectct["NSPID"].ToString(),
                                            decimal.Parse(drdirectct["TongSL"].ToString()),
                                            drdirectct["DVT"].ToString(),
                                            drdirectct["MaKho"].ToString(),
                                            decimal.Parse(drdirectct["GiaMuaChuaTaxDaChietKhau"].ToString()),
                                            decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()),
                                            (decimal.Parse(drdirectct["GiaMuaChuaTaxDaChietKhau"].ToString()) + decimal.Parse(drdirectct["GiaMuaChuaTaxDaChietKhau"].ToString()) * markup / 100),
                                            (decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) + decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) * markup / 100),
                                            decimal.Parse(drdirectct["Tax"].ToString()),
                                            //decimal.Parse(drdirectct["TTTax"].ToString()),
                                            ((decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) + decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) * markup / 100) * (decimal.Parse(drdirectct["Tax"].ToString()) / 100)),
                                            //decimal.Parse(drdirectct["TTGiaMuaCoTax"].ToString()),
                                            (decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) + decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) * markup / 100) + ((decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) + decimal.Parse(drdirectct["TTGiaMuaChuaTaxDaChietKhau"].ToString()) * markup / 100) * (decimal.Parse(drdirectct["Tax"].ToString()) / 100)),
                                            drdirectct["Lot"].ToString(),
                                            DateTime.Parse(drdirectct["Date"].ToString()),
                                            drdirectct["MaNSX"].ToString());
                                    }
                                }
                                nk.UpdateDaXuat(drdirect["PNID"].ToString());
                            }
                            progressBarTinhTrangXuatKho.Value += 1;
                        }
                    }
                    #endregion Xử lý phiếu xuất phát sinh từ đơn hàng nhập direct
                }
                // DungLV add Xuat Chi Dinh Don Hang Start
                else if (cbIsXuatHangCoChiDinh.Checked == true)
                {
                    #region Xử lý Phiếu xuất phát sinh từ đơn hàng xuất (trial - Cho phép xuất lot null)
                    if (dtXuatCoChiDinh.Rows.Count > 0)
                    {
                        //Set maximum size của progressbar
                        progressBarTinhTrangXuatKho.Maximum = dtXuatCoChiDinh.Rows.Count;
                        foreach (DataRow drdhx in dtXuatCoChiDinh.Rows)
                        {
                            CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                            // DungLV add Xuat Thu Cong Start
                            bool isXuatThuCong;
                            if (drdhx["IsXuatThuCong"] == null || (drdhx["IsXuatThuCong"].ToString() != null && drdhx["IsXuatThuCong"].ToString().Equals("null"))) 
                                isXuatThuCong = false;
                            else
                                isXuatThuCong = bool.Parse(drdhx["IsXuatThuCong"].ToString());
                            #region xử lý xuất thủ công start
                            if (isXuatThuCong) {
                            // DungLV add Xuat Thu Cong end
                                DataTable dtbdhxct_hoadonthucong = dhxct.PhieuXuat_LayDSDHXCT_HoaDonThuCong(drdhx["DHID"].ToString());
                                if (dtbdhxct_hoadonthucong.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct in dtbdhxct_hoadonthucong.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                            {
                                                PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_HOADON = px.PhieuXuatCT_Tao1CT(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                }

                                DataTable dtbdhxct_khongHoaHonThuCong = dhxct.PhieuXuat_LayDSDHXCT_KhongCoHoaDonThuCong(drdhx["DHID"].ToString());
                                if (dtbdhxct_khongHoaHonThuCong.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct in dtbdhxct_khongHoaHonThuCong.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_KHONGHOADON == null || PXID_KHONGHOADON.Length == 0)
                                            {
                                                PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_KHONGHOADON = px.PhieuXuatCT_Tao1CT(drdhxct["DHCTID"].ToString(), PXID_KHONGHOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                }
                                //DataTable dtbdhxct = dhxct.PhieuXuat_LayDSDHXCT(drdhx["DHID"].ToString());
                                //if (dtbdhxct.Rows.Count > 0)
                                //{
                                //    foreach (DataRow drdhxct in dtbdhxct.Rows)
                                //    {
                                //        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                //        try
                                //        {
                                //            if (PXID == null || PXID.Length == 0)
                                //            {
                                //                PXID = "00000000-0000-0000-0000-000000000000";
                                //            }
                                //            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                //            PXID = px.PhieuXuatCT_Tao1CT(drdhxct["DHCTID"].ToString(), PXID);
                                //        }
                                //        catch (ApplicationException ex)
                                //        {
                                //            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                //        }
                                //        catch (Exception ex)
                                //        {
                                //            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                //        }
                                //        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                //    }
                                //}
                            }
                            #endregion xử lý xuất thủ công
                            // DungLV add Xuat Thu Cong Start
                            #region xử lý xuất tự động
                            else
                            {
                                DataTable dtbdhxct_hoadon = dhxct.PhieuXuat_LayDSDHXCT_hoadon(drdhx["DHID"].ToString());
                                DataTable dtbdhxct_hoadonKM = dhxct.PhieuXuat_LayDSDHXCT_hoadonKM(drdhx["DHID"].ToString());

                                if (dtbdhxct_hoadon.Rows.Count > 0 || dtbdhxct_hoadonKM.Rows.Count > 0)
                                {
                                    if (dtbdhxct_hoadon.Rows.Count > 0)
                                    {
                                        foreach (DataRow drdhxct in dtbdhxct_hoadon.Rows)
                                        {
                                            #region Thêm 1 Thông tin chi tiết phiếu xuất
                                            try
                                            {
                                                if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                                {
                                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                                }
                                                CSQLPhieuXuat px = new CSQLPhieuXuat();
                                                PXID_HOADON = px.PhieuXuatCT_Tao1CT_HoaDon(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                            }
                                            catch (ApplicationException ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                        }
                                    }
                                    if (dtbdhxct_hoadonKM.Rows.Count > 0)
                                    {
                                        foreach (DataRow drdhxct in dtbdhxct_hoadonKM.Rows)
                                        {
                                            #region Thêm 1 Thông tin chi tiết phiếu xuất
                                            try
                                            {
                                                if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                                {
                                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                                }
                                                CSQLPhieuXuat px = new CSQLPhieuXuat();
                                                PXID_HOADON = px.PhieuXuatCT_Tao1CT_HoaDonKhuyenMai(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                            }
                                            catch (ApplicationException ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                        }
                                    }

                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                }

                                DataTable dtbdhxct_khonghoadon = dhxct.PhieuXuat_LayDSDHXCT_KhongCoHoaDon(drdhx["DHID"].ToString());
                                if (dtbdhxct_khonghoadon.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct_khonghoadon in dtbdhxct_khonghoadon.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_KHONGHOADON == null || PXID_KHONGHOADON.Length == 0)
                                            {
                                                PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_KHONGHOADON = px.PhieuXuatCT_Tao1CT_KhongHoaDon(drdhxct_khonghoadon["DHCTID"].ToString(), PXID_KHONGHOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                }
                           // DungLV add Xuat Thu Cong End                                
                            }
                            #endregion xử lý xuất tự động
                            //Set value Progress bar +1
                            progressBarTinhTrangXuatKho.Value += 1;
                        }
                    }
                    #endregion Xử lý Phiếu xuất phát sinh từ đơn hàng xuất (trial)
                }
                // DungLV add Xuat Chi Dinh Don Hang End
                else
                {
                    #region Xử lý Phiếu xuất phát sinh từ đơn hàng xuất (trial - Cho phép xuất lot null)
                    if (dtbdhx.Rows.Count > 0)
                    {
                        //Set maximum size của progressbar
                        progressBarTinhTrangXuatKho.Maximum = dtbdhx.Rows.Count;
                        foreach (DataRow drdhx in dtbdhx.Rows)
                        {
                            //CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                            //DataTable dtbdhxct = dhxct.PhieuXuat_LayDSDHXCT(drdhx["DHID"].ToString());
                            //if (dtbdhxct.Rows.Count > 0)
                            //{
                            //    foreach (DataRow drdhxct in dtbdhxct.Rows)
                            //    {
                            //        #region Thêm 1 Thông tin chi tiết phiếu xuất
                            //        try
                            //        {
                            //            if (PXID == null || PXID.Length == 0)
                            //            {
                            //                PXID = "00000000-0000-0000-0000-000000000000";
                            //            }
                            //            CSQLPhieuXuat px = new CSQLPhieuXuat();
                            //            PXID = px.PhieuXuatCT_Tao1CT(drdhxct["DHCTID"].ToString(), PXID);
                            //        }
                            //        catch (ApplicationException ex)
                            //        {
                            //            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                            //        }
                            //        catch (Exception ex)
                            //        {
                            //            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                            //        }
                            //        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                            //    }
                            //}
                            //PXID = "00000000-0000-0000-0000-000000000000";
                            //Set value Progress bar +1
                            //progressBarTinhTrangXuatKho.Value += 1;
                            CSQLDonHangXuatCT dhxct = new CSQLDonHangXuatCT();
                            // DungLV add Xuat Thu Cong Start
                            bool isXuatThuCong;
                            if (drdhx["IsXuatThuCong"] == null || (drdhx["IsXuatThuCong"].ToString() != null && (drdhx["IsXuatThuCong"].ToString().Equals("null") || drdhx["IsXuatThuCong"].ToString() == "")))
                                isXuatThuCong = false;
                            else
                                isXuatThuCong = bool.Parse(drdhx["IsXuatThuCong"].ToString());
                            #region xử lý xuất thủ công start
                            if (isXuatThuCong)
                            {
                                // DungLV add Xuat Thu Cong end
                                //DataTable dtbdhxct = dhxct.PhieuXuat_LayDSDHXCT(drdhx["DHID"].ToString());
                                DataTable dtbdhxct_hoadonthucong = dhxct.PhieuXuat_LayDSDHXCT_HoaDonThuCong(drdhx["DHID"].ToString());
                                if (dtbdhxct_hoadonthucong.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct in dtbdhxct_hoadonthucong.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                            {
                                                PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_HOADON = px.PhieuXuatCT_Tao1CT_HoaDonThuCong(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                }

                                DataTable dtbdhxct_khongHoaHonThuCong = dhxct.PhieuXuat_LayDSDHXCT_KhongCoHoaDonThuCong(drdhx["DHID"].ToString());
                                if (dtbdhxct_khongHoaHonThuCong.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct in dtbdhxct_khongHoaHonThuCong.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_KHONGHOADON == null || PXID_KHONGHOADON.Length == 0)
                                            {
                                                PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_KHONGHOADON = px.PhieuXuatCT_Tao1CT(drdhxct["DHCTID"].ToString(), PXID_KHONGHOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                }

                            }
                            #endregion xử lý xuất thủ công
                            // DungLV add Xuat Thu Cong Start
                            #region xử lý xuất tự động
                            else
                            {
                                DataTable dtbdhxct_hoadon = dhxct.PhieuXuat_LayDSDHXCT_hoadon(drdhx["DHID"].ToString());
                                DataTable dtbdhxct_hoadonKM = dhxct.PhieuXuat_LayDSDHXCT_hoadonKM(drdhx["DHID"].ToString());

                                if (dtbdhxct_hoadon.Rows.Count > 0 || dtbdhxct_hoadonKM.Rows.Count > 0)
                                {
                                    if (dtbdhxct_hoadon.Rows.Count > 0)
                                    {
                                        foreach (DataRow drdhxct in dtbdhxct_hoadon.Rows)
                                        {
                                            #region Thêm 1 Thông tin chi tiết phiếu xuất
                                            try
                                            {
                                                if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                                {
                                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                                }
                                                CSQLPhieuXuat px = new CSQLPhieuXuat();
                                                PXID_HOADON = px.PhieuXuatCT_Tao1CT_HoaDon(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                            }
                                            catch (ApplicationException ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                        }
                                    }
                                    if (dtbdhxct_hoadonKM.Rows.Count > 0) {
                                        foreach (DataRow drdhxct in dtbdhxct_hoadonKM.Rows)
                                        {
                                            #region Thêm 1 Thông tin chi tiết phiếu xuất
                                            try
                                            {
                                                if (PXID_HOADON == null || PXID_HOADON.Length == 0)
                                                {
                                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                                }
                                                CSQLPhieuXuat px = new CSQLPhieuXuat();
                                                PXID_HOADON = px.PhieuXuatCT_Tao1CT_HoaDonKhuyenMai(drdhxct["DHCTID"].ToString(), PXID_HOADON);
                                            }
                                            catch (ApplicationException ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                            }
                                            #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                        }
                                    }

                                    PXID_HOADON = "00000000-0000-0000-0000-000000000000";
                                }

                                DataTable dtbdhxct_khonghoadon = dhxct.PhieuXuat_LayDSDHXCT_KhongCoHoaDon(drdhx["DHID"].ToString());

                                if (dtbdhxct_khonghoadon.Rows.Count > 0)
                                {
                                    foreach (DataRow drdhxct_khonghoadon in dtbdhxct_khonghoadon.Rows)
                                    {
                                        #region Thêm 1 Thông tin chi tiết phiếu xuất
                                        try
                                        {
                                            if (PXID_KHONGHOADON == null || PXID_KHONGHOADON.Length == 0)
                                            {
                                                PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                            }
                                            CSQLPhieuXuat px = new CSQLPhieuXuat();
                                            PXID_KHONGHOADON = px.PhieuXuatCT_Tao1CT_KhongHoaDon(drdhxct_khonghoadon["DHCTID"].ToString(), PXID_KHONGHOADON);
                                        }
                                        catch (ApplicationException ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã phát sinh lỗi khi thêm phiếu xuất: " + ex.Message);
                                        }
                                        #endregion Thêm 1 Thông tin chi tiết phiếu xuất (trial - Cho phép xuất lot null)
                                    }
                                    PXID_KHONGHOADON = "00000000-0000-0000-0000-000000000000";
                                }
                                // DungLV add Xuat Thu Cong End                                
                            }
                            #endregion xử lý xuất tự động
                            //Set value Progress bar +1
                            progressBarTinhTrangXuatKho.Value += 1;
                        }
                    }
                    #endregion Xử lý Phiếu xuất phát sinh từ đơn hàng xuất (trial)
                }
                if (progressBarTinhTrangXuatKho.Value == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Báo cáo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Hoàn thành!", "Báo cáo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                CSQLPhieuXuat px = new CSQLPhieuXuat();
                px.XoaPhieuXuatRong();
                MessageBox.Show(ex.Message);
            }
            KiemTraPhieuXuat();
            CSQLPhieuXuat px_ = new CSQLPhieuXuat();
            _frmMain.fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = px_.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenIn(_frmMain.fPhieuXuatKho_DS.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }

            CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
            PrintDialog ChonMayIn = new PrintDialog();
            ChonMayIn.AllowPrintToFile = true;
            ChonMayIn.AllowSelection = true;
            ChonMayIn.AllowSomePages = true;
            ChonMayIn.PrintToFile = true;
            if (ChonMayIn.ShowDialog() == DialogResult.OK)
            {
                string MayInDuocChon = ChonMayIn.PrinterSettings.PrinterName;
                //in tất cả...
                #region
                if (rbtnInTatCa.Checked == true)
                {
                    progressBarTinhTrangIn.Minimum = 0;
                    progressBarTinhTrangIn.Value = 0;
                    int kt_in = 0;
                    DataTable pxchuain = phieuxuat_.LayPhieuXuat_TheoSoLanIn(kt_in);
                    if (pxchuain.Rows.Count > 0)
                    {
                        progressBarTinhTrangIn.Maximum = pxchuain.Rows.Count;
                        for (int i = 0; i < pxchuain.Rows.Count; i++)
                        {
                            if (bool.Parse(pxchuain.Rows[i]["DonKhan"].ToString()) == true)
                            {
                                string pxid_ = pxchuain.Rows[i]["PXid"].ToString();
                                kt_in = 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, kt_in);
                                //Tạm khóa
                                if (bool.Parse(pxchuain.Rows[i]["BoSung"].ToString()) == true)
                                {
                                    DonHang = 1;
                                    IsPhieuCuoi = bool.Parse(pxchuain.Rows[i]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                                else
                                {
                                    DonHang = 2;
                                    IsPhieuCuoi = bool.Parse(pxchuain.Rows[i]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }     
                            }
                            else if (bool.Parse(pxchuain.Rows[i]["Direct"].ToString()) == true)
                            {
                                string pxid_ = pxchuain.Rows[i]["PXid"].ToString();
                                kt_in = 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, kt_in);
                                //Tạm khóa
                                DonHang = 3;
                                IsPhieuCuoi = bool.Parse(pxchuain.Rows[i]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            }
                            else
                            {
                                string pxid_ = pxchuain.Rows[i]["PXid"].ToString();
                                kt_in = 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, kt_in);
                                //Tạm khóa
                                if (bool.Parse(pxchuain.Rows[i]["BoSung"].ToString()) == true)
                                {
                                    DonHang = 4;
                                    IsPhieuCuoi = bool.Parse(pxchuain.Rows[i]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                                else
                                {
                                    DonHang = 5;
                                    IsPhieuCuoi = bool.Parse(pxchuain.Rows[i]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                            }
                            progressBarTinhTrangIn.Value += 1;
                        }
                        MessageBox.Show("Đã in thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Số Liệu Không Có. Vui Lòng Kiểm Tra Lại");
                    }
                }
                #endregion
                //in một phiếu...
                #region
                else if (rbtnInMotPhieu.Checked == true)
                {
                    progressBarTinhTrangIn.Minimum = 0;
                    progressBarTinhTrangIn.Value = 0;
                    DataTable pxsophieu = phieuxuat_.LayPhieuXuat_TheoSoPhieuXuat(txtSoPhieu.Text);
                    if (pxsophieu.Rows.Count > 0)
                    {
                        progressBarTinhTrangIn.Maximum = pxsophieu.Rows.Count;
                        if (bool.Parse(pxsophieu.Rows[0]["DonKhan"].ToString()) == true)
                        {
                            string pxid_ = pxsophieu.Rows[0]["PXid"].ToString();
                            int slin = int.Parse(pxsophieu.Rows[0]["SoLanIn"].ToString()) + 1;
                            phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                            //Tạm khóa
                            if (bool.Parse(pxsophieu.Rows[0]["BoSung"].ToString()) == true)
                            {
                                DonHang = 1;
                                IsPhieuCuoi = bool.Parse(pxsophieu.Rows[0]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            }
                            else
                            {
                                DonHang = 2;
                                IsPhieuCuoi = bool.Parse(pxsophieu.Rows[0]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            } 
                            
                        }
                        else if (bool.Parse(pxsophieu.Rows[0]["Direct"].ToString()) == true)
                        {
                            string pxid_ = pxsophieu.Rows[0]["PXid"].ToString();
                            int slin = int.Parse(pxsophieu.Rows[0]["SoLanIn"].ToString()) + 1;
                            phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                            //Tạm khóa
                            DonHang = 3;
                            IsPhieuCuoi = bool.Parse(pxsophieu.Rows[0]["IsPhieuCuoi"].ToString());
                            InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                        }
                        else
                        {
                            string pxid_ = pxsophieu.Rows[0]["PXid"].ToString();
                            int slin = int.Parse(pxsophieu.Rows[0]["SoLanIn"].ToString()) + 1;
                            phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                            //Tạm khóa
                            if (bool.Parse(pxsophieu.Rows[0]["BoSung"].ToString()) == true)
                            {
                                DonHang = 4;
                                IsPhieuCuoi = bool.Parse(pxsophieu.Rows[0]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            }
                            else
                            {
                                DonHang = 5;
                                IsPhieuCuoi = bool.Parse(pxsophieu.Rows[0]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            }
                        }
                        progressBarTinhTrangIn.Value += 1;
                        txtSoPhieu.Text = "";
                        MessageBox.Show("Đã in thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Số Phiếu Này Không Có. Vui Lòng Kiểm Tra Lại");
                    }
                }
                #endregion
                //in nhiều phiếu...
                #region
                else
                {
                    progressBarTinhTrangIn.Minimum = 0;
                    progressBarTinhTrangIn.Value = 0;
                    DataTable pxtu_den = phieuxuat_.LayPhieuXuat_TuSoPX_DenSoPX(txtTuSo.Text, txtDenSo.Text);
                    if (pxtu_den.Rows.Count > 0)
                    {
                        progressBarTinhTrangIn.Maximum = pxtu_den.Rows.Count;
                        for (int i = 0; i < pxtu_den.Rows.Count; i++)
                        {
                            if (bool.Parse(pxtu_den.Rows[i]["DonKhan"].ToString()) == true)
                            {
                                string pxid_ = pxtu_den.Rows[i]["PXid"].ToString();
                                int slin = int.Parse(pxtu_den.Rows[i]["SoLanIn"].ToString()) + 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                                //Tạm khóa
                                if (bool.Parse(pxtu_den.Rows[i]["BoSung"].ToString()) == true)
                                {
                                    DonHang = 1;
                                    IsPhieuCuoi = bool.Parse(pxtu_den.Rows[0]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                                else
                                {
                                    DonHang = 2;
                                    IsPhieuCuoi = bool.Parse(pxtu_den.Rows[0]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                } 
                            }
                            else if (bool.Parse(pxtu_den.Rows[i]["Direct"].ToString()) == true)
                            {
                                string pxid_ = pxtu_den.Rows[i]["PXid"].ToString();
                                int slin = int.Parse(pxtu_den.Rows[i]["SoLanIn"].ToString()) + 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                                //Tạm khóa
                                DonHang = 3;
                                IsPhieuCuoi = bool.Parse(pxtu_den.Rows[0]["IsPhieuCuoi"].ToString());
                                InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                            }
                            else
                            {
                                string pxid_ = pxtu_den.Rows[i]["PXid"].ToString();
                                int slin = int.Parse(pxtu_den.Rows[i]["SoLanIn"].ToString()) + 1;
                                phieuxuat_.UpdateECOPhieuXuat_SoLanIn(pxid_, slin);
                                //Tạm khóa
                                if (bool.Parse(pxtu_den.Rows[i]["BoSung"].ToString()) == true)
                                {
                                    DonHang = 4;
                                    IsPhieuCuoi = bool.Parse(pxtu_den.Rows[0]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                                else
                                {
                                    DonHang = 5;
                                    IsPhieuCuoi = bool.Parse(pxtu_den.Rows[0]["IsPhieuCuoi"].ToString());
                                    InPhieuXuat(MayInDuocChon, phieuxuat_, pxid_, DonHang, IsPhieuCuoi);
                                }
                            }
                            progressBarTinhTrangIn.Value += 1;
                        }
                        txtTuSo.Text = "";
                        txtDenSo.Text = "";
                        MessageBox.Show("Đã in thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Số Phiếu Này Không Có. Vui Lòng Kiểm Tra Lại");
                    }
                }
                #endregion
            }
          _frmMain.fPhieuXuatKho_DS.rgvDSPhieuXK.DataSource = phieuxuat_.LayDanhSachLenLuoi(_frmMain.IsXemTatCa_);
        }
        private static void InPhieuXuat(string TenMayIn, CSQLPhieuXuat phieuxuat_, string pxid_, int donhang_, bool _IsPhieuCuoi)
        {
            Report_PhieuXuatHang check = new Report_PhieuXuatHang();
            check.SetDataSource(phieuxuat_.LayPhieuXuat_TheoSoLanIn_PXid(pxid_));

            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (donhang_ == 1)
            {
                pdv.Value = "Khẩn - Bổ Sung";
            }
            else if(donhang_ == 2)
            {
                pdv.Value = "Khẩn";
            }
            else if (donhang_ == 3)
            {
                pdv.Value = "Trực Tiếp";
            }
            else if (donhang_ == 4)
            {
                pdv.Value = "Thường - Bổ Sung";
            }
            else
            {
                pdv.Value = "Thường";
            }
            ParameterValues pv = new ParameterValues();
            pv.Add(pdv);
            check.DataDefinition.ParameterFields["DonHang"].ApplyCurrentValues(pv);

            ParameterDiscreteValue pdv_1 = new ParameterDiscreteValue();
            if (_IsPhieuCuoi == true)
            {
                pdv_1.Value = true;
            }
            else
            {
                pdv_1.Value = false;
            }
            ParameterValues pv_1 = new ParameterValues();
            pv_1.Add(pdv_1);
            check.DataDefinition.ParameterFields["IsPhieuCuoi"].ApplyCurrentValues(pv_1);
            check.PrintOptions.PrinterName = TenMayIn;
            check.PrintToPrinter(1, true, 1, 1000);
        }


        private void frmPhieuXuatKho_Load(object sender, EventArgs e)
        {
            KiemTraPhieuXuat();
        }

        private void KiemTraPhieuXuat()
        {
            CSQLPhieuXuat phieuxuat_ = new CSQLPhieuXuat();
            DataTable pxchuain = phieuxuat_.LayPhieuXuat_LayMin_MaxSoPX();
            if (pxchuain.Rows[0]["MinSoPX"].ToString() != "" && pxchuain.Rows[0]["MaxSoPX"].ToString() != "")
            {
                if (pxchuain.Rows[0]["MinSoPX"].ToString() == pxchuain.Rows[0]["MaxSoPX"].ToString())
                {
                    rbtnInMotPhieu.Checked = true;
                    txtSoPhieu.Text = pxchuain.Rows[0]["MaxSoPX"].ToString();
                }
                else
                {
                    txtSoPhieu.Text = "";
                    rbtnInNhieuPhieu.Checked = true;
                    txtTuSo.Text = pxchuain.Rows[0]["MinSoPX"].ToString();
                    txtDenSo.Text = pxchuain.Rows[0]["MaxSoPX"].ToString();
                }
            }
        }

        private void txtSoPhieu_TextChanged(object sender, EventArgs e)
        {
            rbtnInMotPhieu.Checked = true;
            txtTuSo.Text = "";
            txtDenSo.Text = "";
        }

        private void txtTuSo_TextChanged(object sender, EventArgs e)
        {
            rbtnInNhieuPhieu.Checked = true;
            txtSoPhieu.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            _frmMain.fPhieuXuatKho_DS.LoadLenLuoi();
            _frmMain.frmPhieuXuatKhoisOpen_ = false;
            this.Close();
        }
        // DungLV add Xuat Chi Dinh Don Hang start
        private void cbIsXuatHangCoChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsXuatHangCoChiDinh.Checked == true)
                ckLayPhieuXuatDirect.Enabled = false;
            else
                ckLayPhieuXuatDirect.Enabled = true;
        }

        private void ckLayPhieuXuatDirect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLayPhieuXuatDirect.Checked == true)
                cbIsXuatHangCoChiDinh.Enabled = false;
            else
                cbIsXuatHangCoChiDinh.Enabled = true;
        }
        // DungLV add Xuat Chi Dinh Don Hang End
       
    }
}