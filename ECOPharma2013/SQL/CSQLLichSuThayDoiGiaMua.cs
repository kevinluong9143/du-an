using ECOPharma2013.DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECOPharma2013.SQL
{
    class CSQLLichSuThayDoiGiaMua
    {
        public void ThemMoi(Guid SPid, decimal GiaMua, decimal ChietKhau, decimal Tax, Guid NPPid, string LyDo, Guid UserDieuChinh)
        {
            CDuLieu aDuLieu = new CDuLieu();

            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@GiaMua", SqlDbType.Decimal),
                                        new SqlParameter("@ChietKhau", SqlDbType.Decimal),
                                        new SqlParameter("@Tax", SqlDbType.Decimal),
                                        new SqlParameter("@NPPid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@LyDo", SqlDbType.NVarChar, -1),
                                        new SqlParameter("@UserDieuChinh", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = SPid;
            thamso[1].Value = GiaMua;
            thamso[2].Value = ChietKhau;
            thamso[3].Value = Tax;
            thamso[4].Value = NPPid;
            thamso[5].Value = LyDo;
            thamso[6].Value = UserDieuChinh;

            aDuLieu.ThucThi("LichSuThayDoiGiaMua_ThemMoi", thamso);
        }

        public DataTable LayThongTinMoiNhatTheoSPid(Guid SPid)
        {
            CDuLieu aDuLieu = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = SPid;

            return aDuLieu.LoadTable("LichSuThayDoiGiaMua_LayThongTinMoiNhatTheoSPid", thamso);
        }

        public DataTable BaoCaoTheoSPid(Guid SPid)
        {
            CDuLieu aDuLieu = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = SPid;

            return aDuLieu.LoadTable("LichSuThayDoiGiaMua_BaoCaoTheoSPid", thamso);
        }

        public DataTable LayNPPHienTai(Guid SPid)
        {
            CDuLieu aDuLieu = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier)
                                    };

            thamso[0].Value = SPid;

            return aDuLieu.LoadTable("LichSuThayDoiGiaMua_LayNPPHienTai", thamso);
        }
    }
}
