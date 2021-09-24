﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLTonKhoCT
    {
        public CSQLTonKhoCT() { }

        /// <summary>
        /// Hàm lấy thông tin KhoID và TenKho từ bảng EcoTonKhoChiTiet
        /// </summary>
        /// <param name="spid">(string)Sản phẩm ID</param>
        /// <returns>DataTable lưu danh sách KhoID, TenKho của mã hàng đó</returns>
        public DataTable LayTTKho(string spid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayTTKho", thamso);
        }

        public DataTable LayTTKho_NT(string spid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKhoCT_LayTTKho", thamso);
        }

        /// <summary>
        /// Hàm lấy thông tin KhoID và TenKho từ bảng EcoTonKhoChiTiet
        /// </summary>
        /// <param name="nhomkho">(int) Nhóm kho</param>
        /// <returns>DataTable lưu danh sách KhoID, TenKho của mã hàng đó</returns>
        public DataTable LayTTKho(int nhomkho)
        {
            SqlParameter[] thamso = { new SqlParameter("@NHOMKHO", SqlDbType.Int) };
            thamso[0].Value = nhomkho;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("XUATNHANHCT_LAYKHOLENCBO", thamso);
        }

        /// <summary>
        /// Hàm lấy thông tin DVTid, TenDVT từ bảng EcoTonKhoChiTiet
        /// </summary>
        /// <param name="spid">(string) Sản phẩm ID</param>
        /// <param name="khoid">(string) Kho ID</param>
        /// <returns>Datatable lưu danh sách DVTid, TenDVT</returns>
        public DataTable LayTTKDVT(string spid, string khoid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayTTDVT", thamso);
        }

        /// <summary>
        /// Lấy date của lô hàng
        /// </summary>
        /// <param name="spid">string</param>
        /// <param name="khoid">string</param>
        /// <param name="lot">string</param>
        /// <returns>Trả về ngày hết hạn của sản phẩm theo lô</returns>
        public DataTable LayDate_SLTon_SLCoTheXuat_TheoLo(string spid, string khoid, string lot,string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = lot;
            thamso[3].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayDateTheoSP_KhoID_Lot", thamso);
        }

        public DataTable LayDate_SLTon_SLCoTheXuat_TheoLo_NT(string spid, string khoid, string lot, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = lot;
            thamso[3].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKhoCT_LayDateTheoSP_KhoID_Lot", thamso);
        }

        /// <summary>
        /// Lấy lô theo SPID, KhoID và NSXID
        /// </summary>
        /// <param name="spid">string</param>
        /// <param name="khoid">string</param>
        /// <param name="NSXID">string</param>
        /// <returns>Bảng lưu thông tin số lô trong kho của sản phẩm</returns>
        public DataTable LayLoTheoSPID_KhoID(string spid, string khoid,string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayLotTheoSP_KhoID", thamso);
        }

        public DataTable LayLoTheoSPID_KhoID_NT(string spid, string khoid, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKhoCT_LayLotTheoSP_KhoID", thamso);
        }

        public DataTable LayLoTheoSPID_NSXID(string spid,string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayLotTheoSP_NSXID", thamso);
        }

        public DataTable LayLoTheoSPID_NSXID_KHOID(string spid, string nsxid, string khoid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@KHOID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = khoid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayLotTheoSP_NSXID_KHOID", thamso);
        }

        public DataTable LayDateTheoSP_Lot(string spid, string lot, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = lot;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKhoCT_LayDateTheoSP_Lot", thamso);
        }

        public DataTable LoadDataTonKho()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataFullCTY", null);
        }

        public DataTable LoadDataTonKhoChuaXN()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_ChuaNhapKho_LoadDataFullCTY", null);
        }

        public DataTable LoadDataTonKhoTheoSPid_Cty(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataCTY_TheoSPid", thamso);
        }
        public DataTable LoadDataTonKhoTheo_NT(string spid, string ntid, string dkkiemtra)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar),
                                        new SqlParameter("@DKKiemTra", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = ntid;
            thamso[2].Value = dkkiemtra;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataNT_TheoSPid", thamso);
        }

        public DataTable LoadDataTonKhoNT()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataFullNT", null);
        }

        public DataTable LayDataNTTonKho_HetDate()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataFullNT_HetDate", null);
        }

        public DataTable LoadDataTonKhoNTHangAm()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataFullNTHangAm", null);
        }
        public DataTable LoadDataCanDate(int sothang)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoThang", SqlDbType.Int) };
            thamso[0].Value = sothang;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadDataCanDate", thamso);
        }
        public DataTable LoadDataSanPhamItBan(int sothang)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoThang", SqlDbType.Int) };
            thamso[0].Value = sothang;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_LoadData_SanPhamItBan", thamso);
        }

        public DataTable LoadDataPhieuHuy(int soca)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = soca;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoBanHang_LoadDataPhieuHuy", thamso);
        }

        public DataTable BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_SPid(string tungay_, string denngay_, string spid_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@SPIDBan", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = spid_;
            thamso[3].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_SPid]", thamso);
        }
        public DataTable BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_PhieuHuy(string tungay_, string denngay_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTid_PhieuHuy]", thamso);
        }
        public DataTable BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTID(string tungay_, string denngay_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoBanHang_LoadDSTuNgay_DenNgay_NTID]", thamso);
        }

        public DataTable BaoCaoBanHang_DoanhSoChoAn(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoBanHang_DoanhSoChoAn]", thamso);
        }

        public DataTable BaoCao_DinhMucTonKhoCacNT(DateTime Ngay)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { 
                                            new SqlParameter("@Date", SqlDbType.Date)
                                         };
            thamsoinput[0].Value = Ngay.Date;
            return LopDL.LoadTable("BaoCao_DinhMucTonKhoCacNT", thamsoinput);
        }
        public DataTable BaoCaoBanHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc(string tungay_, string denngay_, string spid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@SPIDBan", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = spid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoBanHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc]", thamso);
        }

        public DataTable BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid_SPid(string tungay_, string denngay_, string spid_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@SPidBan", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = spid_;
            thamso[3].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid_SPid]", thamso);
        }
        public DataTable BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid(string tungay_, string denngay_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoTraHang_LoadDSTuNgay_DenNgay_NTid]", thamso);
        }

        public DataTable BaoCaoTraHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc(string tungay_, string denngay_, string spid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@SPidBan", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = spid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoTraHang_LoadDSTuNgay_DenNgay_SPid_FullNhaThuoc]", thamso);
        }
        public DataTable BaoCaoSanPham_LoadDSTheo_NTID(string ntid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoSanPham_LoadDSTheo_NTID]", thamso);
        }

        public DataTable BaoCaoSanPham_LoadDSTatCaNhaThuoc()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoSanPham_LoadDSTatCaNhaThuoc]", null);
        }
        public DataTable BaoCaoSanPham_LoadDSSanPhamCuaNT()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoSanPham_LoadDSSanPhamCuaNT]", null);
        }
        public DataTable BaoCaoXuatKhoTB_LoadDSTuNgay_DenNgay(DateTime tungay_, DateTime denngay_, string spid_, string nspid_, bool dkkiemtra_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.DateTime),
                                        new SqlParameter("@DenNgay", SqlDbType.DateTime),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSPID", SqlDbType.VarChar),
                                        new SqlParameter("@DKKiemTra", SqlDbType.Bit)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = spid_;
            thamso[3].Value = nspid_;
            thamso[4].Value = dkkiemtra_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoXuatKhoTB_LoadDSTuNgay_DenNgay]", thamso);
        }

        public DataTable TongSLNhapXuatKho(DateTime from, DateTime to, string nsx, string npp)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@From", SqlDbType.Date),
                                        new SqlParameter("@To", SqlDbType.Date),
                                        new SqlParameter("@NSXId", SqlDbType.NVarChar),
                                        new SqlParameter("@NPPId", SqlDbType.NVarChar)
                                    };
            thamso[0].Value = from;
            thamso[1].Value = to;
            thamso[2].Value = nsx;
            thamso[3].Value = npp;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCao_TongSLNhapXuatKho", thamso);
        }

        public decimal LayTongSLCoTheXuatTheoSPid(string spid, string khoid, string nsxid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@KhoId", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@NSXId", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@SoLuong", SqlDbType.Money)
                                    };
            thamso[0].Value = new Guid(spid);
            thamso[1].Value = new Guid(khoid);
            thamso[2].Value = new Guid(nsxid);
            thamso[3].Direction = ParameterDirection.Output; ;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("TonKhoCT_LayTongSLCoTheXuatTheoSPid", thamso);

            return Convert.ToDecimal(thamso[3].Value);
        }
        public DataTable LoadDataCanDate_CTY(int sothang)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoThang", SqlDbType.Int) };
            thamso[0].Value = sothang;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_CanDate_CTY", thamso);
        }
        public DataTable LoadDataHetDate_CTY()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoTonKho_HetDate_CTY", null);
        }
    }
}
