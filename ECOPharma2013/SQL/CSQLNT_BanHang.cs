using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_BanHang
    {
        public DataTable LayDSMaSP_TenSPLenMultiColumnComboBox()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSMaSP_TenSPLenMultiColumnCombobox", null);
        }

        public DataTable LayDSLotTheoSPID(string spid, string khoxuatid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@KhoXuatID", SqlDbType.VarChar),
                                    new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoxuatid;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSLotTheoSPID", thamso);
        }

        public DataTable LayNTTKCTTheoSPID(string spid, string khoxuatid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@KhoXuatID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoxuatid;


            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayNTTKCTTheoSPID", thamso);
        }

        public DataTable LayNTTKCTTheoSPIDKhoLot(string spid, string khoid,string lot, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@Khoid", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = lot;
            thamso[3].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayNTTKCTTheoSPIDKhoLot", thamso);
        }


        /// <summary>
        /// Hàm lấy Kho xuất mặc định của sản phẩm trong bảng ntSanPham_Kho
        /// </summary>
        /// <param name="spid">(string-uniqueidentifier): Sản phẩm ID </param>
        /// <returns>KhoXuatID: Nếu có kho xuất    /    NULL: nếu không có kho xuất</returns>
        public string LayKhoXuatMacDinhCuaSanPham(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_BanHang_LayKhoXuatMacDinhCuaSanPham", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
                return dtb.Rows[0]["KhoXuatNTID"].ToString();
            else
                return null;
        }


        public string[] Them(string tenMayThuNgan, string userTao, string nvbanhang, int soca, string khid, bool IsHangDacBiet)
        {
             SqlParameter [] thamso = {
                                          new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar),
                                          new SqlParameter("@UserTao", SqlDbType.VarChar),
                                          new SqlParameter("@NVBanHang", SqlDbType.VarChar),
                                          new SqlParameter("@SoCa", SqlDbType.Int),
                                          new SqlParameter("@SoPhieu", SqlDbType.VarChar,50),
                                          new SqlParameter("@BHID", SqlDbType.VarChar,50),
                                          new SqlParameter("@KHID", SqlDbType.VarChar),
                                          new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                      };
            thamso[0].Value = tenMayThuNgan;
            thamso[1].Value = userTao;
            thamso[2].Value = nvbanhang;
            thamso[3].Value = soca;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Direction = ParameterDirection.Output;
            thamso[6].Value = khid;
            thamso[7].Value = IsHangDacBiet;

            CDuLieu dl = new CDuLieu();
            string [] mangkq = new string[2];
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_BanHang_Them", thamso);
            if(kq>0)
            {
                mangkq[0]= thamso[4].Value.ToString(); //Số phiếu bán hàng
                mangkq[1] = thamso[5].Value.ToString(); //BHID
                return mangkq;
            }
            else
                return null;
        }
        public DataTable LayLenLuoi(bool isXemTatCa, string tenmaythungan)
        {
            SqlParameter[] thamso = { new SqlParameter("@isXemTatCa", SqlDbType.Bit),
                                    new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar)};
            thamso[0].Value = isXemTatCa;
            thamso[1].Value = tenmaythungan;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BANHANG_LAYLENLUOI", thamso);
        }

        public string LayNVBanHangTheoBHID(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar) };
            thamso[0].Value = bhid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_BanHang_LayNVBanHang", thamso);
            if(dtb!=null && dtb.Rows.Count>0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }

        public string LayTongTienThanhToan(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar) };
            thamso[0].Value = bhid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_BanHang_LayTongTienThanhToan", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }

        public string ThanhToan(string bhid, decimal ttnhan, string userthanhtoan)
        {
            try { 
                SqlParameter[] thamso = { 
                                            new SqlParameter("@BHID", SqlDbType.VarChar),
                                            new SqlParameter("@TTNhan", SqlDbType.Decimal),
                                            new SqlParameter("@UserThanhToan", SqlDbType.VarChar),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };

                thamso[0].Value = bhid;
                thamso[1].Value = ttnhan;
                thamso[2].Value = userthanhtoan;
                thamso[3].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThi("NT_BanHang_ThanhToan", thamso);
                return thamso[3].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable LayDanhSachTamTinh(string tenMayThuNgan, int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar) ,
                                    new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = tenMayThuNgan;
            thamso[1].Value = soca_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSPhieuTamTinh", thamso);
        }

        public DataTable LayDanhSachTamTinhCoTongGiaBan(string tenMayThuNgan)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar) };
            thamso[0].Value = tenMayThuNgan;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSPhieuTamTinhCoTongGiaBan", thamso);
        }

        public int IsDaThanhToan(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar)};
            thamso[0].Value = bhid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_BanHang_IsDaThanhToan", thamso);
            int kq = -1;
            if (dtb != null && dtb.Rows.Count > 0)
            {
                kq = int.Parse(dtb.Rows[0][0].ToString());
            }
            return kq;
        }

        public DataTable LayDataTheoSoCa(int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = soca_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_BanHang_LayDataTheoSoCa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayPhieuHuyTheoSoCa(int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = soca_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_BanHang_LayPhieuHuyTheoSoCa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int HuyPhieuBH(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar)};
            thamso[0].Value = bhid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_BanHang_HuyPhieu", thamso);
        }

        public DataTable NT_BanHang_LayDSBanHangDaThanhToanTheoSoCT(string soct)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCT", SqlDbType.VarChar) };
            thamso[0].Value = soct;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSBanHangDaThanhToanTheoSoCT", thamso);
        }

        public bool NT_BanHang_KiemTraDonDaThanhToan(string bHID)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar),
                                        new SqlParameter("@KQ", SqlDbType.Bit)};
            thamso[0].Value = bHID;
            thamso[1].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_BanHang_KiemTraDonDaThanhToan", thamso);
                return (bool)thamso[1].Value;
        }

        public DataTable LayTienThanhToan_Nhan_TraLaiTheoBHID(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar) };
            thamso[0].Value = bhid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayTienThanhToan_Nhan_TraLai", thamso);
            
        }

        public DataTable BanHang_HoatChat_LayDSSanPhamLenLuoiHC(string spid, string phancach)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@PhanCach", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = phancach;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("BanHang_HoatChat_LayDSSanPhamCungHoatChat", thamso);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable NT_BanHang_HoatChat_LayDSSanPhamLenLuoiHC(string spid, string phancach)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@PhanCach", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = phancach;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NT_BanHang_HoatChat_LayDSSanPhamCungHoatChat", thamso);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable LoadDataBanHang(DateTime tungay_, DateTime denngay_)
        {
            SqlParameter[] thamso = new SqlParameter[2];
            SqlParameter XemTC = new SqlParameter("@TuNgay", SqlDbType.DateTime);
            XemTC.Value = tungay_;
            thamso[0] = XemTC;
            SqlParameter XemTC1 = new SqlParameter("@DenNgay", SqlDbType.DateTime);
            XemTC1.Value = denngay_;
            thamso[1] = XemTC1;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LoadData", thamso);
        }

        public bool IsKhoDacBiet(string BHid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@BHid", SqlDbType.UniqueIdentifier), 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(BHid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NT_BanHang_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        public DataTable LayDSMaSP_TenSPLenMultiColumnComboBox(bool IsHangDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                     };

            thamso[0].Value = IsHangDacBiet;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSMaSP_TenSPLenMultiColumnCombobox_IsHangDacBiet", thamso);
        }

        public DataTable LayDSLotDacBietTheoSPID(string spid, string nsxid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayDSLotTheoSPID_HangDacBiet", thamso);
        }

        public DataTable LayNTTKCTTheoSPIDKhoLot(string spid, string lot, string nsxid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };

            thamso[0].Value = spid;
            thamso[1].Value = lot;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHang_LayNTTKCTTheoSPIDKhoLot_HangDacBiet", thamso);
        }

        public void CapNhat(string BHid, bool IsKhoDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@BHid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(BHid);
            thamso[1].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NT_BanHang_CapNhat", thamso);
        }

        public DataTable NTTonKho_LaySLTon_DVTid(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKho_LaySLTon_DVTid_HangDacBiet", thamso);
        }
    }
}
