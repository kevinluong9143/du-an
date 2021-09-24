using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_ChuyenHangCT
    {
        #region CÁC HÀM KHỞI TẠO THÔNG TIN LÊN FORM
        /// <summary>
        /// Hàm lấy danh sách nhà thuốc lên combobox
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSNhaThuoc()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_CHUYENHANGCT_LAYDSNHATHUOC", null);
        }


        /// <summary>
        /// Hàm dùng lấy danh sách sản phẩm tồn tại trong tồn kho lên multicombobox 
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSThongTinSanPham(bool khodacbiet)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter ("@KhoDacBiet", SqlDbType.Bit)
                                     };
            thamso[0].Value = khodacbiet;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_CHUYENHANGCT_LAYDSMASP_TENSP", thamso);
        }

        /// <summary>
        /// Lấy danh sách nhà sản xuất theo sản phẩm ID
        /// </summary>
        /// <param name="spid"></param>
        /// <returns></returns>
        public DataTable LayDSNhaSanXuat(string spid)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter ("@SPID", SqlDbType.VarChar)
                                     };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try
            {
                dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYDSNSX", thamso);
            }
            catch
            {
                dtb = null;
            }
            return dtb;
        }

        /// <summary>
        /// LẤY DANH SÁCH KHO CỦA SẢN PHẨM ĐƯA LÊN COMBOBOX
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="nsxid"></param>
        /// <returns></returns>
        public DataTable LayDSKho(string spid, string nsxid, bool HangDacBiet)
        {
            SqlParameter[] thamso = { new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),                            
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = HangDacBiet;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try
            {
                dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYKHO", thamso);
            }
            catch
            {
                dtb = null;
            }
            return dtb;
        }

        /// <summary>
        /// LẤY DANH SÁCH ĐƠN VỊ TÍNH CỦA SẢN PHẨM ĐỂ ĐƯA LÊN COMBOBOX
        /// </summary>
        /// <param name="spid"></param>
        /// <returns></returns>
        public DataTable LayDSDVT(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try { dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYDSDVT", thamso); }
            catch { return null; }
            return dtb;
        }

        /// <summary>
        /// LẤY ĐƠN VỊ XUẤT MẶC ĐỊNH CỦA SẢN PHẨM
        /// </summary>
        /// <param name="spid"></param>
        /// <returns></returns>
        public string LayDVXuat(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try
            {
                dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYDVXUAT", thamso);
                return dtb.Rows[0][0].ToString();
            }
            catch { return null; }
        }

        /// <summary>
        /// LẤY LOT CỦA SẢN PHẨM
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="nsxid"></param>
        /// <param name="khoid"></param>
        /// <returns></returns>
        public DataTable LayLot(string spid, string nsxid, string khoid)
        {
            SqlParameter[] thamso = {   new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@Khoid", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = khoid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try
            {
                dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYDSLOT", thamso);
            }
            catch
            {
                dtb = null;
            }
            return dtb;
        }

        /// <summary>
        /// LẤY DATE, SLTON, SLCOTHEBAN CỦA SẢN PHẨM
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="nsxid"></param>
        /// <param name="khoid"></param>
        /// <param name="lot"></param>
        /// <returns></returns>
        public DataTable LayDateSLTonSLCoTheXuat(string spid, string nsxid, string khoid, string lot, string dvtid)
        {
            SqlParameter[] thamso = {   new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@Khoid", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Dvtid", SqlDbType.VarChar)
                                        };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = khoid;
            thamso[3].Value = lot;
            thamso[4].Value = dvtid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = new DataTable();
                dtb = dl.LoadTable("NT_CHUYENHANGCT_LAYDATESLTONSLCOTHEXUAT", thamso);
                return dtb;
            }
            catch
            {
                return null;
            }
        }


        public DataTable LayLenLuoi(string chid)
        {
            SqlParameter[] thamso = {   new SqlParameter ("@chid", SqlDbType.VarChar)};
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = new DataTable();
                dtb = dl.LoadTable("NTCHUYENHANGCTNT_LAYLENLUOI", thamso);
                return dtb;
            }
            catch
            {
                return null;
            }
        }

        #endregion CÁC HÀM KHỞI TẠO THÔNG TIN LÊN FORM

        #region CÁC HÀM INSERT, UPDATE, DELETE
        public int NTChuyenHangCT_Them(string chid, string spid, string nsxid, decimal slchuyen, string dvtid, string khoid, string lot, DateTime date, string chctid)
        {
            SqlParameter[] thamso = {  new SqlParameter("@CHID", SqlDbType.VarChar),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@NSXID", SqlDbType.VarChar),
                                         new SqlParameter("@SLCHUYEN", SqlDbType.Decimal),
                                         new SqlParameter("@DVTID", SqlDbType.VarChar),
                                         new SqlParameter("@KHoID", SqlDbType.VarChar),
                                         new SqlParameter("@LOT", SqlDbType.VarChar),
                                         new SqlParameter("@Date", SqlDbType.DateTime),
                                         new SqlParameter("@CHCTID", SqlDbType.VarChar)
                                     };
            thamso[0].Value = chid;
            thamso[1].Value = spid;
            thamso[2].Value = nsxid;
            thamso[3].Value = slchuyen;
            thamso[4].Value = dvtid;
            thamso[5].Value = khoid;
            thamso[6].Value = lot;
            thamso[7].Value = date;
            thamso[8].Value = chctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGCTNT_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NTChuyenHangCT_Xoa(string chctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CHCTID", SqlDbType.VarChar) };
            thamso[0].Value = chctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGCTNT_XOA", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion CÁC HÀM INSERT, UPDATE, DELETE



        public DataTable LayDanhSach(string CHID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@CHID", SqlDbType.UniqueIdentifier) 
                                    };

            thamso[0].Value = new Guid(CHID);

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NTChuyenHangCTNT_LayDanhSach", thamso);
        }
    }
}
