using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLTonKho
    {
        public CSQLTonKho() { }

        public DataTable LayDataSPTonKho()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKho_LayDataSPTonKho", null);
        }
        public DataTable LayDataNTTonKho()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKho_LayDataNTTonKho", null);
        }

       

        public DataTable LayMaSP_TenSP()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKho_LayMaTenSP", null);
        }

        public DataTable LayMaSP_TenSP_NT()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKho_LayMaTenSP", null);
        }
        public int TonKho_Them(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("TonKho_Them", thamso);
        }

        public DataTable TonKho_LaySLTon_DVTid(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKho_LaySLTon_DVTid", thamso);
        }
        public DataTable NTTonKho_LaySLTon_DVTid(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TonKho_LaySLTon_DVTid", thamso);
        }

        public DataTable LayMaSP_TenSP(bool IsKhoDacBiet)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit) };
            thamso[0].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("TonKho_LayMaTenSP_IsKhoDacBiet", thamso);
        }
    }
}
