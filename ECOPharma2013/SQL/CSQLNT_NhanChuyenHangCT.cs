using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhanChuyenHangCT
    {
        public DataTable NhanPhieuChuyenCT(string nchid)
        {
            SqlParameter [] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar)};
            thamso[0].Value = nchid;

            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.LoadTable("NTNHANCHUYENHANGCT_LAYPHIEUCHUYEN", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
