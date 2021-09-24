using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNTThayDoiGiaSP
    {
        public string NTThayDoiGiaSP_Them()
        {
            SqlParameter[] thamso = {new SqlParameter("@TDGID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Ngay", SqlDbType.DateTime)};
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = DateTime.Now;
            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSP_Them", thamso);
            if (thamso[0].Value != null && thamso[0].Value.ToString().Length > 0)
            {
                return thamso[0].Value.ToString();
            }
            else
                return "";
        }
        public int NTThayDoiGiaSP_Xoa(string TDGID)
        {
            SqlParameter[] thamso = { new SqlParameter("@TDGID", SqlDbType.VarChar) };
            thamso[0].Value = TDGID;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSP_Xoa", thamso);

        }
        public int NTThayDoiGiaSP_XoaCTKhongCoNoiDung(string TDGID)
        {
            SqlParameter[] thamso = { new SqlParameter("@TDGID", SqlDbType.VarChar) };
            thamso[0].Value = TDGID;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSP_XoaCTKhongCoNoiDung", thamso);
        }
        public DataTable LoadLenLuoi()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("NTTHAYDOIGIASP_LOADLENLUOI", null);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Load1Record(string tdgid)
        {
            SqlParameter[] thamso = { new SqlParameter("@tdgid", SqlDbType.VarChar) };
            thamso[0].Value = tdgid;
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("NTTHAYDOIGIASP_LAY1RECORD", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
