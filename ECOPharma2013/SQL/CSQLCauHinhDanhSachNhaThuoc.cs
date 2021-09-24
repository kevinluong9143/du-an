using ECOPharma2013.DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECOPharma2013.SQL
{
    class CSQLCauHinhDanhSachNhaThuoc
    {

        public string LuuThongTinCauHinh(string NTid, string TenNT, string IP, string Database, string UserID, string Pass)
        {
            try
            {
                CDuLieu aCDuLieu = new CDuLieu();
                SqlParameter[] thamso = { 
                                        new SqlParameter("@NTid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@TenNT", SqlDbType.NVarChar, 50),
                                        new SqlParameter("@IP", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Database", SqlDbType.VarChar, 50),
                                        new SqlParameter("@UserID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Pass", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };

                thamso[0].Value = new Guid(NTid);
                thamso[1].Value = TenNT;
                thamso[2].Value = IP;
                thamso[3].Value = Database;
                thamso[4].Value = UserID;
                thamso[5].Value = Pass;
                thamso[6].Direction = ParameterDirection.Output;

                aCDuLieu.ThucThiTraVeKetQuaKieuInt("CauHinhDanhSachNhaThuoc_LuuThongTin", thamso);
                return thamso[6].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable LayThongTinCauHinh(string NTid)
        {
            DataTable dt= new DataTable();
                try { 
                if (!string.IsNullOrEmpty(NTid)) { 
                    CDuLieu aCDuLieu = new CDuLieu();
                    SqlParameter[] thamso = { 
                                                new SqlParameter("@NTid", SqlDbType.UniqueIdentifier)
                                            };

                    thamso[0].Value = new Guid(NTid);

                    dt = aCDuLieu.LoadTable("CauHinhDanhSachNhaThuoc_LayThongTin", thamso);
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch {
                return dt;
            }
        }
    }
}
