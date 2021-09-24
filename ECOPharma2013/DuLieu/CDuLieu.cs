
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Threading;

namespace ECOPharma2013.DuLieu
{
    
    class CDuLieu
    {
        SqlConnection conn;

        public SqlConnection connString()
        {
            //string server = @"Server=HAIT\SQLSERVER;Database=ECODCM_TradeAccount;User ID=sa;Password=sql@123";
            //string server = @"Server=HAIT\SQLSERVER;Database=ECODCM265;User ID=sa;Password=sa";
            //string server = @"Server=192.168.1.19;Database=ECODCM_CH;User ID=sa;Password=sql@123";
            //string server = @"Server=192.168.1.19;Database=ECODCM_TradeAccount;User ID=sa;Password=sql@123";
            //string server = @"Server=192.168.3.68\sqlexpress;Database=ECODCM;User ID=sa;Password=pmbl_sql@dmin";

            string server = @"Server=" + CStaticBien._Server + ";Database=" + CStaticBien._Database + ";User ID=" + CStaticBien._UserName + ";Password=" + CStaticBien._Password + "";
            return new SqlConnection(server);
        }

        #region cty
        public DataTable LoadTable(string TenProc, SqlParameter[] ThamSoInput)
        {
            try
            {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    cmd.Dispose();
                    adapter.Dispose();
                    return table;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return null;
            }
        }
        #endregion[

        //#region Nhà Thuốc
        //public DataTable LoadTable(string TenProc, SqlParameter[] ThamSoInput)
        //{
        //    try
        //    {
        //        using (conn = connString())
        //        {
        //            SqlCommand cmd = new SqlCommand(TenProc, conn);
        //            cmd.CommandTimeout = 0;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            if (ThamSoInput != null)
        //            {
        //                cmd.Parameters.AddRange(ThamSoInput);
        //            }
        //            if (conn.State == ConnectionState.Closed)
        //            {
        //                conn.Open();
        //            }
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable table = new DataTable();
        //            adapter.Fill(table);
        //            cmd.Dispose();
        //            adapter.Dispose();
        //            return table;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //throw ex;
        //        throw new UnableToOpenDatabaseException("Kết nối với máy chủ tạm thời bị ngắt.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        throw new UnableToOpenDatabaseException("Kết nối với máy chủ tạm thời bị ngắt.", ex);
        //    }
        //}
        //private static DialogResult ShowThreadExceptionDialog(Exception e)
        //{
        //    string errorMsg = "Kết nối với máy chủ tạm thời bị ngắt"
        //        + "\n\n" +
        //    "Vui lòng chọn OK rồi khởi động lại phần mềm ECOPharma";
        //    return MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //}
        //public class UnableToOpenDatabaseException : Exception
        //{
        //    public UnableToOpenDatabaseException()
        //        : base()
        //    {
        //    }
        //    public UnableToOpenDatabaseException(string Message)
        //        : base(Message)
        //    {
        //    }
        //    public UnableToOpenDatabaseException(string Message, Exception InnerException)
        //        : base(Message, InnerException)
        //    {
        //        DialogResult result = ShowThreadExceptionDialog(InnerException);
        //        if (result == DialogResult.OK)
        //            Application.Exit();
        //    }
        //}
        //#endregion

        public string InsertDuLieu(string TenProc, SqlParameter[] ThamSoInput,SqlParameter ThamSoOutput)
        {
            try
            {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (ThamSoOutput != null)
                    {
                        cmd.Parameters.Add(ThamSoOutput);
                        ThamSoOutput.Direction = ParameterDirection.Output;
                    }
                    if (conn.State == ConnectionState.Closed)
                    
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    if (ThamSoOutput == null)
                        return "";
                    else
                        return ThamSoOutput.Value.ToString();
                }
                //conn = connString();
                //SqlCommand cmd = new SqlCommand(TenProc, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (ThamSoInput != null)
                //{
                //    cmd.Parameters.AddRange(ThamSoInput);
                //}
                //if (ThamSoOutput != null)
                //{
                //    cmd.Parameters.Add(ThamSoOutput);
                //    ThamSoOutput.Direction = ParameterDirection.Output;
                //}

                //conn.Open();
                //cmd.ExecuteNonQuery();
                //return ThamSoOutput.Value.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public string CapNhat(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (ThamSoOutput != null)
                    {
                        cmd.Parameters.Add(ThamSoOutput);
                        ThamSoOutput.Direction = ParameterDirection.Output;
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return ThamSoOutput.Value.ToString();
                }
                
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatDuLieu(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (ThamSoOutput != null)
                    {
                        cmd.Parameters.Add(ThamSoOutput);
                        ThamSoOutput.Direction = ParameterDirection.Output;
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //return "" là luu thành công, else thì return error message
                    return ThamSoOutput.Value.ToString();
                }
                
            }
            catch (Exception ex)
            {
                //return ThamSoOutput.Value.ToString();
                return "";
            }
        }

        public bool KiemTra(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (ThamSoOutput != null)
                    {
                        cmd.Parameters.Add(ThamSoOutput);
                        ThamSoOutput.Direction = ParameterDirection.Output;
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    return bool.Parse(ThamSoOutput.Value.ToString()); //true là ton tai, false là khong ton tai
                }
        }

        public int ThucThiTraVeKetQuaKieuInt(string TenProc, SqlParameter[] ThamSoInput)
        {
            try
            {
                int kq = 0;
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    kq = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int ThucThiTraVeKetQuaKieuInt(string TenProc, SqlParameter[] ThamSoInput, int timeout)
        {
            try
            {
                int kq = 0;
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = timeout; 
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    kq = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //public DateTime LayGioServer()
        //{
        //    string sqlGetDate = "select GetDate()";
        //    conn.Close();
        //    return LoadData(sqlGetDate).Rows[0][0].ToString();
        //}
        public string Them(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (conn = connString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, conn);
                    cmd.CommandType = CommandType.Text;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (ThamSoOutput != null)
                    {
                        cmd.Parameters.Add(ThamSoOutput);
                        ThamSoOutput.Direction = ParameterDirection.Output;
                    }
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    if (ThamSoOutput == null)
                        return "";
                    else
                        return ThamSoOutput.Value.ToString();
                }
                //conn = connString();
                //SqlCommand cmd = new SqlCommand(TenProc, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (ThamSoInput != null)
                //{
                //    cmd.Parameters.AddRange(ThamSoInput);
                //}
                //if (ThamSoOutput != null)
                //{
                //    cmd.Parameters.Add(ThamSoOutput);
                //    ThamSoOutput.Direction = ParameterDirection.Output;
                //}

                //conn.Open();
                //cmd.ExecuteNonQuery();
                //return ThamSoOutput.Value.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public void ThucThi(string TenProc, SqlParameter[] ThamSoInput)
        {
            using (conn = connString())
            {
                SqlCommand cmd = new SqlCommand(TenProc, conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                if (ThamSoInput != null)
                {
                    cmd.Parameters.AddRange(ThamSoInput);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}
