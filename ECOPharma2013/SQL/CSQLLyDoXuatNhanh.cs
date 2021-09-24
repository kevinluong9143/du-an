using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLLyDoXuatNhanh
    {
        public DataTable LayNhomKhoTuLyDo(int LDid)
        {
            SqlParameter[] thamso = { new SqlParameter("@LDID", SqlDbType.Int) };
            thamso[0].Value = LDid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("LYDOXUAT_LayNhomKho", thamso);
        }
    }
}
