using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ECOPharma2013.DuLieu
{
    class CDuLieuAccess
    {
        OleDbConnection conn;
        DataTable Bang;
        OleDbDataAdapter da;
        DataSet ds;

        public OleDbConnection connString()
        {
            string server = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=M:\DATA\POS.mdb";
            //string server = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\\Projects\\Softwares\\Eco_Ecopharma2013\\Data Pos HBT413\\POS.mdb";
            //string server = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\Projects\Softwares\VietHoaDonNhaThuoc\397 hbt\POS.mdb";
            return new OleDbConnection(server);
        }

        public void CapNhatDataMDB(string sql)
        {
            try
            {
                using (conn = connString())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    OleDbCommand cm = new OleDbCommand(sql, conn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
                throw ex;
            }
        }

        public DataTable LoadDataMDB(string sql)
        {
            Bang = new DataTable();
            try
            {
                using (conn = connString())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    da = new OleDbDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "Tables");
                    Bang = ds.Tables["Tables"];
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return null;
                throw ex;
            }
            finally
            {
                conn.Close();
                da.Dispose();
                ds.Dispose();
            }
            return Bang;
        }

        public decimal Tinh(string sql)
        {
            decimal kq = 0;
            OleDbCommand cm;
            try
            {
                using (conn = connString())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cm = new OleDbCommand(sql, conn);
                    if (cm.ExecuteScalar().ToString() == "")
                    {
                        kq = 0;
                    }
                    else if (cm.ExecuteScalar().ToString() != "")
                    {
                        kq = decimal.Parse(cm.ExecuteScalar().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return kq;
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return kq;
        }
    }
}
