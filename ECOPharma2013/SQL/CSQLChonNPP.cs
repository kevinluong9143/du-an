using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLChonNPP
    {
        public CSQLChonNPP() { }
        //ChonNPP_Lay3NPPMuaGanNhat(@spid uniqueidentifier)
        public DataTable Lay3NPPMuaGanNhat(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@spid", spid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("ChonNPP_Lay3NPPMuaGanNhat", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
