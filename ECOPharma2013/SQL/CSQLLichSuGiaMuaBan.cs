using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLLichSuGiaMuaBan
    {
        public DataTable LayLenLuoi(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("LichSuGiaMuaBan_LayLenLuoi", thamso);
        }
        public DataTable BaoCaoLichSuGiaMuaBan_LoadDSTuNgay_DenNgay_NTid(string tungay_, string denngay_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoLichSuGiaMuaBan_LoadDSTuNgay_DenNgay_NTid]", thamso);
        }
    }
}
