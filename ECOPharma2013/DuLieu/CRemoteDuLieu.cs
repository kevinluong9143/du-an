using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ECOPharma2013.DuLieu
{
    class CRemoteDuLieu
    {
        SqlConnection RmtConn;

        public SqlConnection RmtConnString()
        {
            string server = @"Server=CEH-PC\SQLEXPRESS;Database=ECODCM;User ID=sa;Password=sa";
            //string server = @"Server=HA-PC\SQLEXPRESS;Database=ECODCM;User ID=sa;Password=sa";
            //string server = @"Server=ISA\SQLEXPRESS;Database=ECODCM;User ID=sa;Password=sa";
            //string server = @"Server=TANNGUYEN-PC;Database=ECODCM;Integrated Security= SSPI";
            return new SqlConnection(server);
        }

        public DataTable LoadTable(string TenProc, SqlParameter[] ThamSoInput)
        {
            try
            {
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }

                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    cmd.Dispose();
                    adapter.Dispose();
                    return table;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string InsertDuLieu(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
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
                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    RmtConn.Close();
                    if (ThamSoOutput == null)
                        return "";
                    else
                        return ThamSoOutput.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhat(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
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
                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
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
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
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
                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
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
            using (RmtConn = RmtConnString())
            {
                SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
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
                if (RmtConn.State == ConnectionState.Closed)
                {
                    RmtConn.Open();
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                RmtConn.Close();
                return bool.Parse(ThamSoOutput.Value.ToString()); //true là ton tai, false là khong ton tai
            }

        }

        public int ThucThiTraVeKetQuaKieuInt(string TenProc, SqlParameter[] ThamSoInput)
        {
            try
            {
                int kq = 0;
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ThamSoInput != null)
                    {
                        cmd.Parameters.AddRange(ThamSoInput);
                    }
                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
                    }
                    kq = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    RmtConn.Close();
                }
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public string Them(string TenProc, SqlParameter[] ThamSoInput, SqlParameter ThamSoOutput)
        {
            try
            {
                using (RmtConn = RmtConnString())
                {
                    SqlCommand cmd = new SqlCommand(TenProc, RmtConn);
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
                    if (RmtConn.State == ConnectionState.Closed)
                    {
                        RmtConn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    RmtConn.Close();
                    if (ThamSoOutput == null)
                        return "";
                    else
                        return ThamSoOutput.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
