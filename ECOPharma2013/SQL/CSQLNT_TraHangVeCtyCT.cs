using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_TraHangVeCtyCT
    {
        #region CÁC HÀM KHỞI TẠO THÔNG TIN LÊN FORM
        /// <summary>
        /// Hàm lấy danh sách nhà thuốc lên combobox
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSNhaThuoc()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TRAHANGVECTY_LAYDSNHATHUOC", null);
        }


        /// <summary>
        /// Hàm dùng lấy danh sách sản phẩm tồn tại trong tồn kho lên multicombobox 
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSThongTinSanPham()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_CHUYENHANGCT_LAYDSMASP_TENSP", null);
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
        public DataTable LayDSKho(string spid, string nsxid, bool IsHangDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@IsHangDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = IsHangDacBiet;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = new DataTable();
            try
            {
                dtb = dl.LoadTable("NT_TRAHANGCT_LAYKHO", thamso);
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
            SqlParameter[] thamso = { new SqlParameter("@THid", SqlDbType.VarChar) };
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = new DataTable();
                dtb = dl.LoadTable("NTTRAHANGVECTYCT_LAYLENLUOI", thamso);
                return dtb;
            }
            catch
            {
                return null;
            }
        }

        public DataTable IN_NTTH_NTTHCT(string chid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THid", SqlDbType.VarChar) };
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = new DataTable();
                dtb = dl.LoadTable("NTTRAHANGVECTYCT_IN_NTTH_NTTHCT", thamso);
                return dtb;
            }
            catch
            {
                return null;
            }
        }

        #endregion CÁC HÀM KHỞI TẠO THÔNG TIN LÊN FORM

        #region CÁC HÀM INSERT, UPDATE, DELETE
        public int NTTraHangVeCtyCT_Them(string thid, string spid, string nsxid, decimal slchuyen, string dvtid, string khoid, string lot, DateTime date, string thctid)
        {
            SqlParameter[] thamso = {  new SqlParameter("@THID", SqlDbType.VarChar),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@NSXID", SqlDbType.VarChar),
                                         new SqlParameter("@SLCHUYEN", SqlDbType.Decimal),
                                         new SqlParameter("@DVTID", SqlDbType.VarChar),
                                         new SqlParameter("@KHoID", SqlDbType.VarChar),
                                         new SqlParameter("@LOT", SqlDbType.VarChar),
                                         new SqlParameter("@Date", SqlDbType.DateTime),
                                         new SqlParameter("@THCTID", SqlDbType.VarChar)
                                     };
            thamso[0].Value = thid;
            thamso[1].Value = spid;
            thamso[2].Value = nsxid;
            thamso[3].Value = slchuyen;
            thamso[4].Value = dvtid;
            thamso[5].Value = khoid;
            thamso[6].Value = lot;
            thamso[7].Value = date;
            thamso[8].Value = thctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTYCT_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NTTraHangVeCtyCT_Xoa(string thctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THCTID", SqlDbType.VarChar) };
            thamso[0].Value = thctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTYCT_XOA", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion CÁC HÀM INSERT, UPDATE, DELETE


        public bool KiemTraCoHangDacBiet(string THID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@THID", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(THID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NTTRAHANGVECTYCT_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        public DataTable LayDSThongTinSanPham(bool IsHangDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = IsHangDacBiet;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TRAHANGCT_LAYDSMASP_TENSP_IsHangDacBiet", thamso);
        }

        public DataTable LayDanhSach(string THid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@THid", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = new Guid(THid);

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NTTraHangVeCtyCT_LayDanhSach", thamso); 
        }
    }
}
