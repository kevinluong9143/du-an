using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhanChuyenHang
    {
        public DataTable NhanPhieuChuyen()
        {
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.LoadTable("NTNHANCHUYENHANG_LAYPHIEUCHUYEN", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string Them(string sopch, DateTime ngaychungtu, string fromm, string ghichu, DateTime ngaynhan, string usernhan)
        //{
        //    SqlParameter [] thamso = {  
        //                                 new SqlParameter("@SoPCH", SqlDbType.VarChar),
        //                                 new SqlParameter("@NgayChungTu", SqlDbType.DateTime),
        //                                 new SqlParameter("@Fromm", SqlDbType.VarChar),
        //                                 new SqlParameter("@GhiChu", SqlDbType.VarChar),
        //                                 new SqlParameter("@NgayNhan", SqlDbType.DateTime),
        //                                 new SqlParameter("@UserNhan", SqlDbType.VarChar)
        //                             };
        //    thamso[0].Value = sopch;
        //    thamso[1].Value = ngaychungtu;
        //    thamso[2].Value = fromm;
        //    thamso[3].Value = ghichu;
        //    thamso[4].Value = ngaynhan;
        //    thamso[5].Value = usernhan;

        //}


        //    NTNHANCHUYENHANG_THEM(@SOPCH VARCHAR(50), @NGAYCHUNGTU DATETIME, @FROMM UNIQUEIDENTIFIER, @GHICHU NVARCHAR(MAX), @NGAYNHAN DATETIME, @USERNHAN UNIQUEIDENTIFIER)
    }
}
