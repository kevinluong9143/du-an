using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhomSP
    {
        private string MaNhomSP;

        public string sMaNhomSP
        {
            get { return MaNhomSP; }
            set { MaNhomSP = value; }
        }
        private string TenNhomSP;

        public string sTenNhomSP
        {
            get { return TenNhomSP; }
            set { TenNhomSP = value; }
        }
        private string GhiChu;

        public string sGhiChu
        {
            get { return GhiChu; }
            set { GhiChu = value; }
        }
        private bool IsKhongDung;

        public bool bIsKhongDung
        {
            get { return IsKhongDung; }
            set { IsKhongDung = value; }
        }
        private string UserID;

        public string sUserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        public string LuuNhomSP(CSQLNhomSP objNhomSP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@TenNhomSP", SqlDbType.NVarChar, 50), new SqlParameter("@Note", SqlDbType.NText), new SqlParameter("@IsKhongDung", SqlDbType.Bit), new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamsoinput[0].Value = objNhomSP.sTenNhomSP;
            thamsoinput[1].Value = objNhomSP.sGhiChu;
            thamsoinput[2].Value = objNhomSP.bIsKhongDung;
            thamsoinput[3].Value = objNhomSP.sUserID;

            SqlParameter MaNhomSPfromTable = new SqlParameter("@MaNhomSPfrmTable", SqlDbType.VarChar, 50);
            return LopDL.CapNhatDuLieu("NhomSP_ThemMoi", thamsoinput, MaNhomSPfromTable);
        }

        public DataTable LoadDSNhomSPLenLuoi(bool IsXemTatCa)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] XemTatCa = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            XemTatCa[0].Value = IsXemTatCa;

            return LopDL.LoadTable("NhomSP_LayDanhSach", XemTatCa);
        }

        public string SuaNhomSP(CSQLNhomSP NhomSP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaNhomSP", SqlDbType.VarChar, 50), new SqlParameter("@TenNhomSP", SqlDbType.NVarChar, 50), new SqlParameter("@Note", SqlDbType.NVarChar), new SqlParameter("@IsKhongDung", SqlDbType.Bit), new SqlParameter("@UserID", SqlDbType.VarChar, 50) };
            thamsoinput[0].Value = NhomSP.sMaNhomSP;
            thamsoinput[1].Value = NhomSP.sTenNhomSP;
            thamsoinput[2].Value = NhomSP.sGhiChu;
            thamsoinput[3].Value = NhomSP.bIsKhongDung;
            thamsoinput[4].Value = NhomSP.sUserID;

            SqlParameter KetQuaTraVe = new SqlParameter("@KQSua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("NhomSP_Sua", thamsoinput, KetQuaTraVe);
        }

        public DataTable LayNhomCanSua(string MaNhomSP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaNhomcanTim = { new SqlParameter("@MaNhomSP", SqlDbType.VarChar, 50) };
            MaNhomcanTim[0].Value = MaNhomSP;

            return LopDL.LoadTable("NhomSP_TimNhomTheoMa", MaNhomcanTim);
        }

        public string XoaNhomSP(string MaNhomSP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaNhomSP", SqlDbType.NVarChar, 50) };
            thamsoinput[0].Value = MaNhomSP;

            SqlParameter KetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("NhomSP_Xoa", thamsoinput, KetQua);
        }

        public int NSP_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NSP_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;     
        }
        public int NSP_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NSP_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NSP_LayMaxThemMoiNT ()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NSP_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NSP_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NSP_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }

        public DataTable NSP_LayDSNSPChuaCapNhatTaiNT (int maxCapNhatNT) 
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NSP_LayDSNSPChuaCapNhatTaiNT", thamso);
        }
        public DataTable NSP_LayDSNSPChuaThemMoiTaiNT(int maxThemMoiNT) 
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NSP_LayDSNSPChuaThemMoiTaiNT", thamso);
        }
        public void NSP_DongBoThemDanhMuc (DataTable dsNSPChuaThemMoi) 
        {
            //(NSPID, TenNSP, GhiChu, KhongSuDung, LastUD, NgayTao, UserID,MaxCapNhat)
            if (dsNSPChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNSPChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NSPid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNSP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["NSPid"].ToString();
                    thamso[1].Value = dr["TenNSP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NSP_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void NSP_DongBoSuaDanhMuc (DataTable dsNSPChuaCapNhat) 
        {
            if (dsNSPChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNSPChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NSPid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNSP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["NSPid"].ToString();
                    thamso[1].Value = dr["TenNSP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NSP_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
