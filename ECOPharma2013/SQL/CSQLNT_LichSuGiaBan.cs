using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;


namespace ECOPharma2013.SQL
{
    class CSQLNT_LichSuGiaBan
    {
        public DataTable LoadLenLuoi()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("NTLichSuGiaBan_LoadLenLuoi", null);
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
