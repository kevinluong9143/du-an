using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;
using System.Data.SqlClient;
using System.Data;

namespace ECOPharma2013.SQL
{
    class CSQLDangNhap
    {
        string TK;
        CDuLieu LopDL = new CDuLieu();
        public string TaiKhoan
        {
            get { return TK; }
            set { TK = value; }
        }
        string MK;

        public string MatKhau
        {
            get { return MK; }
            set { MK = value; }
        }

        public DataTable KiemTraTK(string _TaiKhoan)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@UserName", SqlDbType.VarChar, 20) };
            thamsoinput[0].Value = _TaiKhoan;

            return LopDL.LoadTable("User_LoadthongTinUser", thamsoinput);
        }

        public DataTable KiemTraMK(string _TaiKhoan, string _MatKhau)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@UserName", SqlDbType.VarChar, 20), new SqlParameter("@Pass", SqlDbType.VarChar, 50) };
            thamsoinput[0].Value = _TaiKhoan;
            thamsoinput[1].Value = _MatKhau;

            return LopDL.LoadTable("User_LoadThongTinMK", thamsoinput);
        }
    }
}
