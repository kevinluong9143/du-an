using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangMua
    {
        public CSQLDonHangMua() { }

        public DataTable LoadLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@isXemTatCa", isXemTatCa) };
            try 
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMua_LoadLenLuoi", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMua_LayDonHangMuaTheoPNID(@PNID uniqueidentifier)
        public DataTable LayDHMTheoPNID(string pnid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNID", pnid) };
            try 
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMua_LayDonHangMuaTheoPNID", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMua_CapNhatYeuCauNhapKho (@PNID uniqueidentifier, @UserNhap uniqueidentifier, @isYeuCauNhapKho)
        public int CapNhatYeuCauNhapKho(string pnid, string usernhap, bool isYeuCauNhapKho)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNID", pnid),
                                        new SqlParameter("@UserNhap", usernhap),
                                        new SqlParameter("@isYeuCauNhapKho", isYeuCauNhapKho)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMua_CapNhatYeuCauNhapKho", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
