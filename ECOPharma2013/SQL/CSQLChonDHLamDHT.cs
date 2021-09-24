using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLChonDHLamDHT
    {
        public DataTable LoadDuLieu()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("ChonDHLamDHT_Load", null);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
