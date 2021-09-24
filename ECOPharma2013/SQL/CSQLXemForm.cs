using ECOPharma2013.DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECOPharma2013.SQL
{
    class CSQLXemForm
    {
        public void ThemMoi(string UserView, string FormView)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@UserView", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@FormView", SqlDbType.VarChar, 100)
                                    };

            thamso[0].Value = new Guid(UserView);
            thamso[1].Value = FormView;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("XemForm_ThemMoi", thamso);
        }

        public DataTable XemSoLuotView(DateTime From, DateTime To)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@From", SqlDbType.Date),
                                        new SqlParameter("@To", SqlDbType.Date)
                                    };

            thamso[0].Value = From;
            thamso[1].Value = To;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("XemForm_XemSoLuotView", thamso);
        }

        public DataTable XemSoLuotViewChiTiet(DateTime From, DateTime To, string FromView)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@From", SqlDbType.Date),
                                        new SqlParameter("@To", SqlDbType.Date),
                                        new SqlParameter("@FromView", SqlDbType.VarChar)
                                    };

            thamso[0].Value = From;
            thamso[1].Value = To;
            thamso[2].Value = FromView;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("XemForm_XemSoLuotViewChiTiet", thamso);
        }
    }
}
