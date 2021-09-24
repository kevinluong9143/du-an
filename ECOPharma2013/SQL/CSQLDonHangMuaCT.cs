using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangMuaCT
    {
        public CSQLDonHangMuaCT(){}

        //DonHangMuaEdit_CapNhat(@PNCTID uniqueidentifier, @SPID uniqueidentifier, @SLConThieu decimal(38,15), @DVTID uniqueidentifier, @GhiChu nvarchar(300), @nsxid uniqueidentifier)
        public int CapNhat(string pnctid, string pnid, string spid, decimal slconthieu, string dvtid, string ghichu, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@pnctid", pnctid),
                                    new SqlParameter("@pnid", pnid),
                                    new SqlParameter("@spid", spid),
                                    new SqlParameter("@slconthieu", slconthieu),
                                    new SqlParameter("@dvtid", dvtid),
                                    new SqlParameter("@ghichu", ghichu),
                                    new SqlParameter("@nsxid", nsxid)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaEdit_CapNhat", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Xoa(string pnctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@pnctid", pnctid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaEdit_Xoa", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
