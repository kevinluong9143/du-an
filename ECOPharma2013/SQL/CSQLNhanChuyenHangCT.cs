using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhanChuyenHangCT
    {
        public int Them(string nchid, string spid, string nsxid, decimal slchuyen, string dvtid, decimal giamuachuatax, decimal ttgiamuachuatax, decimal giaxkchuatax, decimal ttgiaxkchuatax, decimal tax, decimal tttax, decimal ttgiaxkcotax, string lot, DateTime date, DateTime timestamps)
        {
            SqlParameter[] thamso = {   new SqlParameter("@NCHID", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@SLCHUYEN", SqlDbType.Decimal),
                                        new SqlParameter("@DVTID", SqlDbType.VarChar),
                                        new SqlParameter("@GIAMUACHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAMUACHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@GIAXKCHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAXKCHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTTAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAXKCOTAX", SqlDbType.Decimal),
                                        new SqlParameter("@LOT", SqlDbType.VarChar),
                                        new SqlParameter("@DATE", SqlDbType.DateTime),
                                        new SqlParameter("@TIMESTAMPP", SqlDbType.DateTime)
                                    };
            thamso[0].Value = nchid;
            thamso[1].Value = spid;
            thamso[2].Value = nsxid;
            thamso[3].Value = slchuyen;
            thamso[4].Value = dvtid;
            thamso[5].Value = giamuachuatax;
            thamso[6].Value = ttgiamuachuatax;
            thamso[7].Value = giaxkchuatax;
            thamso[8].Value = ttgiaxkchuatax;
            thamso[9].Value = tax;
            thamso[10].Value = tttax;
            thamso[11].Value = ttgiaxkcotax;
            thamso[12].Value = lot;
            thamso[13].Value = date;
            thamso[14].Value = timestamps;
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.ThucThiTraVeKetQuaKieuInt("ECONHANCHUYENHANGCT_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DataTable IN_NCH_NCHCT(string NCHid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHid", SqlDbType.VarChar, 50) };
            thamso[0].Value = NCHid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("ECONHANCHUYENHANGCT_IN_NCH_NCHCT", thamso);
        }
    }
}
