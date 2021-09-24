using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;
using System.Data;

namespace ECOPharma2013.SQL
{
    class CRmtServer
    {
        public string RmtServer { get; set; }
        public string RmtUserName { get; set; }
        public string RmtPassword { get; set; }
        public string RmtDatabase { get; set; }

        public static void LayChuoiKetNoiRmt()
        {
            CSQLCauHinhHeThong LopCHHT = new CSQLCauHinhHeThong();
            CMaHoa LopMaHoa = new CMaHoa();
            DataTable BangTTServer = new DataTable();
            BangTTServer = LopCHHT.LayThongTinServerTongCty();
            if (BangTTServer.Rows.Count > 0)
            {
                CStaticBien._RmtServer = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["ServerPath"].ToString());
                CStaticBien._RmtUserName = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["UserData"].ToString());
                CStaticBien._RmtPassword = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["PassData"].ToString());
                CStaticBien._RmtDatabase = LopMaHoa.GiaiMa(BangTTServer.Rows[0]["Data"].ToString());
                //return true;
            }
            else
            {
                CStaticBien._RmtServer = "";
                CStaticBien._RmtUserName = "";
                CStaticBien._RmtPassword = "";
                CStaticBien._RmtDatabase = "";
            }
            //    return false;
        }

        public bool KiemTraKetNoiRmtServer()
        {
            try
            {
                LayChuoiKetNoiRmt();

                SqlConnection RmtConn;
                CDuLieuRemote LopDLRmt = new CDuLieuRemote();
                RmtConn = LopDLRmt.RmtConnString();
                RmtConn.Open();
                if (RmtConn.State == ConnectionState.Open)
                {
                    RmtConn.Close();
                }
                RmtConn.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
