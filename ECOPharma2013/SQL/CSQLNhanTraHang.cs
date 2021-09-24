using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhanTraHang
    {
         string _sNTHid;

        public string SNCHid
        {
            get { return _sNTHid; }
            set { _sNTHid = value; }
        }
        bool _bDaXacNhan;

        public bool BDaXacNhan
        {
            get { return _bDaXacNhan; }
            set { _bDaXacNhan = value; }
        }
        DateTime _dNgayXacNhan;

        public DateTime DNgayXacNhan
        {
            get { return _dNgayXacNhan; }
            set { _dNgayXacNhan = value; }
        }
        string _sUserXacNhan;

        public string SUserXacNhan
        {
            get { return _sUserXacNhan; }
            set { _sUserXacNhan = value; }
        }

        public CSQLNhanTraHang() { }

        public DataTable LoadNhanTraHangLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();   
            return dl.LoadTable("NhanTraHang_LoadNhanTraHangLenLuoi", thamso);
        }

        /// <summary>
        /// HÀM THÊM THÔNG TIN NHẬN TRẢ HÀNG TỪ NHÀ THUỐC
        /// </summary>
        /// <param name="SoPTH"></param>
        /// <param name="ngaychungtu"></param>
        /// <param name="fromm"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public string Them(string SoPTH, DateTime ngaychungtu, string fromm, string ghichu, int loaihangtra, bool IsKhoDacBiet)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SoPTH", SqlDbType.VarChar),
                                        new SqlParameter("@NgayChungTu", SqlDbType.DateTime),
                                        new SqlParameter("@Fromm", SqlDbType.VarChar),
                                        new SqlParameter("@NTHID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Ghichu", SqlDbType.NVarChar),
                                        new SqlParameter("@LoaiHangTra", SqlDbType.Int),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = SoPTH;
            thamso[1].Value = ngaychungtu;
            thamso[2].Value = fromm;
            thamso[3].Direction = ParameterDirection.Output;
            thamso[4].Value = ghichu;
            thamso[5].Value = loaihangtra;
            thamso[6].Value = IsKhoDacBiet;

            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                dlrm.ThucThiTraVeKetQuaKieuInt("ECONhanTraHang_THEM", thamso);
                return thamso[3].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayNhanTraHangTheoMa(string NTHid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTHid", SqlDbType.VarChar) };
            thamso[0].Value = NTHid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhanTraHang_LayNhanTraHangTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayNhanTraHangCT_TheoNTHid(string nthid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTHid", SqlDbType.VarChar, 50) };
            thamso[0].Value = nthid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhanTraHangCT_LayNTHCT_TheoNTHid", thamso);
        }
        public int UpdateDaXetDuyet(string nthid_, string userxetduyet, bool daxetduyet, Guid KhoDen)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@NTHid", SqlDbType.VarChar), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@UserUD", SqlDbType.VarChar),
                                        new SqlParameter("@DaXetDuyet", SqlDbType.Bit),
                                        new SqlParameter("@KhoDen", SqlDbType.UniqueIdentifier)
                                    };
            thamso[0].Value = nthid_;
            thamso[1].Value = DateTime.Now;
            thamso[2].Value = userxetduyet;
            thamso[3].Value = daxetduyet;
            thamso[4].Value = KhoDen;

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanTraHang_UpdateDaXetDuyet", thamso);
            return kq;
        }

        public DataTable LayLenLuoiXacNhan()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NhanTraHang_LayLenLuoiXacNhan", null);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int XacNhan(string nthid, string userxacnhan, DateTime ngayxacnhan)
        {
            SqlParameter[] thamso = {   new SqlParameter("@NTHid", SqlDbType.VarChar), 
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime)};
            thamso[0].Value = nthid;
            thamso[1].Value = userxacnhan;
            thamso[2].Value = ngayxacnhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NHANTRAHANG_XACNHAN", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Them(string SoPTH, DateTime ngaychungtu, string fromm, string ghichu, int loaihangtra, bool IsKhoDacBiet, DataTable dtChiTiet)
        {
            try
            {
                SqlParameter[] thamso = {   
                                        new SqlParameter("@SoPTH", SqlDbType.VarChar),
                                        new SqlParameter("@NgayChungTu", SqlDbType.DateTime),
                                        new SqlParameter("@Fromm", SqlDbType.VarChar),
                                        new SqlParameter("@Ghichu", SqlDbType.NVarChar),
                                        new SqlParameter("@LoaiHangTra", SqlDbType.Int),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        new SqlParameter("@ChiTiet", SqlDbType.Structured),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1),
                                    };
                thamso[0].Value = SoPTH;
                thamso[1].Value = ngaychungtu;
                thamso[2].Value = fromm;
                thamso[3].Value = ghichu;
                thamso[4].Value = loaihangtra;
                thamso[5].Value = IsKhoDacBiet;
                thamso[6].Value = dtChiTiet;
                thamso[7].Direction = ParameterDirection.Output;

                CDuLieuRemote dlrm = new CDuLieuRemote();
                dlrm.ThucThi("ECONhanTraHang_ThemMasterVaChiTiet", thamso);
                return thamso[7].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }          
        }

        public string[] KiemTraTonTaiSoPTH(string SoPTH)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@SoPTH", SqlDbType.VarChar, 12),
                                        new SqlParameter("@IsExist", SqlDbType.Bit),
                                        new SqlParameter("@NTid", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = SoPTH;
            thamso[1].Direction = ParameterDirection.Output;
            thamso[2].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            dl.ThucThi("ECONhanTraHang_KiemTraTonTaiSoPTH", thamso);

            return new string[] { thamso[1].Value.ToString(), thamso[2].Value.ToString() }; 
            //return Convert.ToBoolean(thamso[1].Value);
        }
    }
}
