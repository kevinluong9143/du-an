using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_ChuyenHang
    {
        public string[] ThemChuyenHang(string dest, string ghichu, DateTime ngaytao, string usertao, bool hangdacbiet)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@DESTINATION", SqlDbType.VarChar),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@NGAYTAO", SqlDbType.DateTime),
                                        new SqlParameter("@USERTAO", SqlDbType.VarChar),
                                        new SqlParameter("@CHID", SqlDbType.VarChar,50),
                                        new SqlParameter("@SOPCH", SqlDbType.VarChar,12),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                     };
            thamso[0].Value = dest;
            thamso[1].Value = ghichu;
            thamso[2].Value = ngaytao;
            thamso[3].Value = usertao;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Direction = ParameterDirection.Output;
            thamso[6].Value = hangdacbiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGNT_THEM", thamso);
                string[] chid_sopch = new string[2];
                if (thamso[4].Value != null && thamso[4].Value.ToString().Length > 0)
                {
                    chid_sopch[0] = thamso[4].Value.ToString();
                    chid_sopch[1] = thamso[5].Value.ToString();
                }
                else
                {
                    chid_sopch[0] = "00000000-0000-0000-0000-000000000000";
                    chid_sopch[1] = "000000000000";
                }
                return chid_sopch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SuaChuyenHang(string chid, string dest, string ghichu, DateTime lastud, string userud, bool daxetduyet, DateTime ngayxetduyet, string userxetduyet, bool hangdacbiet)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@CHID", SqlDbType.VarChar),
                                        new SqlParameter("@DESTINATION", SqlDbType.VarChar),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@LASTUD", SqlDbType.DateTime),
                                        new SqlParameter("@USERUD", SqlDbType.VarChar),
                                        new SqlParameter("@DAXETDUYET", SqlDbType.Bit),
                                        new SqlParameter("@NGAYXETDUYET", SqlDbType.DateTime),
                                        new SqlParameter("@USERXETDUYET", SqlDbType.VarChar),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                     };
            thamso[0].Value = chid;
            thamso[1].Value = dest;
            thamso[2].Value = ghichu;
            thamso[3].Value = lastud;
            thamso[4].Value = userud;
            thamso[5].Value = daxetduyet;
            thamso[6].Value = ngayxetduyet;
            thamso[7].Value = userxetduyet;
            thamso[8].Value = hangdacbiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NTCHUYEHANGNT_SUA", thamso);
                if (dtb != null && dtb.Rows.Count > 0)
                    return dtb;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDSChuyenHangLenLuoi(bool IsXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = IsXemTatCa;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NTCHUYENHANGNT_LAYLENLUOI", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayChuyenHang(string chid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CHID", SqlDbType.VarChar) };
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NTCHUYENHANGNT_LAYCHUYENHANG", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable IN_NTCH_NTCHCT(string CHID)
        {
            SqlParameter[] thamso = { new SqlParameter("@CHID", SqlDbType.VarChar, 50) };
            thamso[0].Value = CHID;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NTCHUYENHANGCTNT_IN_NTCH_NTCHCT", thamso);
        }

        public DataTable LayChuyenHangLenLuoiXacNhan(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NTCHUYENHANGNT_LAYLENLUOIXACNHAN", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime XacNhanChuyenHang(string chid, DateTime ngayxacnhan, string userxacnhan)
        {
            DateTime NGAYXACNHAN = DateTime.MinValue;
            SqlParameter[] thamso = {   new SqlParameter("@CHID", SqlDbType.VarChar),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                    };
            thamso[0].Value = chid;
            thamso[1].Direction = ParameterDirection.Output;
            thamso[2].Value = userxacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                if (dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGNT_XACNHAN", thamso)>0) {
                    NGAYXACNHAN = DateTime.Parse(thamso[1].Value.ToString());
                }
                return NGAYXACNHAN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CapNhatIsDaChuyenVeCty(string chid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@CHID", SqlDbType.VarChar)};
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGNT_CAPNHATISDACHUYENVECTY", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int XoaToanBo(string chid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CHID", SqlDbType.VarChar) };
            thamso[0].Value = chid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTCHUYENHANGNT_XOATOANBO", thamso);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
