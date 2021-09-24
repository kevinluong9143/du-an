using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDongGoiCT
    {
        public int Them(string dgid, decimal sldonggoi, string dvtid)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter ("@dgid", SqlDbType.VarChar),
                                         new SqlParameter ("@sldonggoi", SqlDbType.Decimal),
                                         new SqlParameter ("@dvtid", SqlDbType.VarChar)
                                     };
            thamso[0].Value = dgid;
            thamso[1].Value = sldonggoi;
            thamso[2].Value = dvtid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DongGoiCT_Them", thamso);
        }

        public int Sua(string dgctid, decimal sldonggoi, string dvtid)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter ("@dgctid", SqlDbType.VarChar),
                                         new SqlParameter ("@sldonggoi", SqlDbType.Decimal),
                                         new SqlParameter ("@dvtid", SqlDbType.VarChar)
                                     };
            thamso[0].Value = dgctid;
            thamso[1].Value = sldonggoi;
            thamso[2].Value = dvtid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DongGoiCT_Sua", thamso);
        }

        public DataTable LayLenLuoi()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DongGoiCT_LoadLenLuoi", null);
        }

        public DataTable LayLenLuoi_TheoDGID(string dgid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DGID", SqlDbType.VarChar) };
            thamso[0].Value = dgid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DongGoiCT_LoadLenLuoi_TheoDGID", thamso);
        }

        public int Xoa(string dgctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DGCTID", SqlDbType.VarChar) };
            thamso[0].Value = dgctid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DongGoiCT_Xoa", thamso);
        }

    }
}
