using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;


using System.Data;

namespace ECOPharma2013.SQL
{
    class CServer
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public CServer()
        {
            CMaHoa LopMaHoa = new CMaHoa();
            FileInfo file = new FileInfo(@"C:\ECOPharmaConf.con");
            StreamReader reader = file.OpenText();
            CStaticBien._Server = LopMaHoa.GiaiMa(reader.ReadLine().Split(':')[1]);
            CStaticBien._UserName = LopMaHoa.GiaiMa(reader.ReadLine().Split(':')[1]);
            CStaticBien._Password = LopMaHoa.GiaiMa(reader.ReadLine().Split(':')[1]);
            CStaticBien._Database = LopMaHoa.GiaiMa(reader.ReadLine().Split(':')[1]);
            reader.Close();

            try
            {
                TestConn();
            }
            catch (Exception)
            {
                frmServer fServer = new frmServer();
                fServer.ShowDialog();
            }
        }

        public static void TestConn()
        {
            SqlConnection conn;
            CDuLieu LopDL=new CDuLieu();
            conn = LopDL.connString();
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }

        public static void GhiFileConfig(string SQLServer, string SQLUser, string SQLPass, string SQLDatabase)
        {
            CMaHoa LopMaHoa = new CMaHoa();
            FileInfo file = new FileInfo(@"c:\ECOPharmaConf.con");
            StreamWriter writer = new StreamWriter(@"C:\ECOPharmaConf.con");
            writer.WriteLine("Server:" + LopMaHoa.MaHoa(SQLServer));
            writer.WriteLine("UserName:" + LopMaHoa.MaHoa(SQLUser));
            writer.WriteLine("PassWord:" + LopMaHoa.MaHoa(SQLPass));
            writer.WriteLine("Database:" + LopMaHoa.MaHoa(SQLDatabase));
            writer.Close();
        }
    }
}
