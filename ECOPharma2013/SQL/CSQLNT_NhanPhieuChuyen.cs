using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhanPhieuChuyen
    {
        public int Them(string nchid, string sopch, DateTime ngaychungtu, string fromm, string ghichu, string usernhan, bool hangdacbiet)
        {
            SqlParameter [] thamso = { new SqlParameter ("@NCHID", SqlDbType.VarChar),
                                         new SqlParameter ("@SOPCH", SqlDbType.VarChar),
                                         new SqlParameter ("@NGAYCHUNGTU", SqlDbType.DateTime),
                                         new SqlParameter ("@FROMM", SqlDbType.VarChar),
                                         new SqlParameter ("@GHICHU", SqlDbType.VarChar),
                                         new SqlParameter ("@USERNHAN", SqlDbType.VarChar),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                     };
            thamso[0].Value = nchid;
            thamso[1].Value = sopch;
            thamso[2].Value = ngaychungtu;
            thamso[3].Value = fromm;
            thamso[4].Value = ghichu;
            thamso[5].Value = usernhan;
            thamso[6].Value = hangdacbiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NT_NHANCHUYENHANG_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;

            CDuLieu dl = new CDuLieu();
            try 
            {
                return dl.LoadTable("NT_NHANCHUYENHANG_LOADLENLUOI", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayThongTinPhieuChuyen(string nchid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar) };
            thamso[0].Value = nchid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NT_NHANCHUYENHANG_LAYTHONGTIN", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        public int Sua(string nchid, bool daxetduyet, string userXetDuyet, bool hangdacbiet)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar),
                                        new SqlParameter ("@DAXETDUYET", SqlDbType.Bit),
                                        new SqlParameter("@UserXetDuyet", SqlDbType.VarChar),                            
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)};
            thamso[0].Value = nchid;
            thamso[1].Value = daxetduyet;
            thamso[2].Value = userXetDuyet;
            thamso[3].Value = hangdacbiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTNHANCHUYENHANG_SUA", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public DataTable LoadLenLuoiXacNhan()        
        {

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NTNHANCHUYENHANG_LOADLENLUOIXACNHAN", null);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public int XacNhan(string nchid, DateTime ngayxacnhan, string userxacnhan)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar),
                                        new SqlParameter ("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar)};
            thamso[0].Value = nchid;
            thamso[1].Value = ngayxacnhan;
            thamso[2].Value = userxacnhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTNHANCHUYENHANG_XACNHAN", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Them(string nchid, string sopch, DateTime ngaychungtu, string fromm, string ghichu, string usernhan, bool hangdacbiet, DataTable dtChiTiet)
        {
            try {
                SqlParameter[] thamso = { 
                                            new SqlParameter("@NCHID", SqlDbType.VarChar),
                                            new SqlParameter("@SOPCH", SqlDbType.VarChar),
                                            new SqlParameter("@NGAYCHUNGTU", SqlDbType.DateTime),
                                            new SqlParameter("@FROMM", SqlDbType.VarChar),
                                            new SqlParameter("@GHICHU", SqlDbType.VarChar),
                                            new SqlParameter("@USERNHAN", SqlDbType.VarChar),
                                            new SqlParameter("@HangDacBiet", SqlDbType.Bit),
                                            new SqlParameter("@ChiTiet", SqlDbType.Structured),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };

                thamso[0].Value = nchid;
                thamso[1].Value = sopch;
                thamso[2].Value = ngaychungtu;
                thamso[3].Value = fromm;
                thamso[4].Value = ghichu;
                thamso[5].Value = usernhan;
                thamso[6].Value = hangdacbiet;
                thamso[7].Value = dtChiTiet;
                thamso[8].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThi("NT_NhanChuyenHang_ThemMasterVaChiTiet", thamso);
                return thamso[8].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool KiemTraTonTai(string NCHid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@NCHID", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsExist", SqlDbType.Bit)
                                    };
            thamso[0].Value = new Guid(NCHid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NT_NhanChuyenHang_KiemTraTonTai", thamso);

            return Convert.ToBoolean(thamso[1].Value);
        }
    }
}
