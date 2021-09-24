using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonViTinh
    {
        private string MaDVT;

        public string sMaDVT
        {
            get { return MaDVT; }
            set { MaDVT = value; }
        }
        private string TenDVT;

        public string sTenDVT
        {
            get { return TenDVT; }
            set { TenDVT = value; }
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

        public string LuuDVT(CSQLDonViTinh objDVT)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@TenDVT", SqlDbType.NVarChar, 50), new SqlParameter("@Note", SqlDbType.NText), new SqlParameter("@IsKhongDung", SqlDbType.Bit), new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamsoinput[0].Value = objDVT.sTenDVT;
            thamsoinput[1].Value = objDVT.sGhiChu;
            thamsoinput[2].Value = objDVT.bIsKhongDung;
            thamsoinput[3].Value = objDVT.sUserID;

            SqlParameter MaDVTfromTable = new SqlParameter("@MaDVTfrmTable", SqlDbType.VarChar, 50);
            return LopDL.CapNhatDuLieu("DVT_ThemMoi", thamsoinput,MaDVTfromTable); ;
        }

        public DataTable LoadDSDVTLenLuoi(bool IsXemTatCa)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] XemTatCa = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            XemTatCa[0].Value = IsXemTatCa;

            return LopDL.LoadTable("DVT_LayDanhSach", XemTatCa);
        }

        public DataTable LayDVTCanSua(string MaDVT)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaDVTcanTim = { new SqlParameter("@MaDVT", SqlDbType.VarChar, 50) };
            MaDVTcanTim[0].Value = MaDVT;

            return LopDL.LoadTable("DVT_TimDVTTheoMa", MaDVTcanTim);
        }

        public string SuaDVT(CSQLDonViTinh DVT)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaDVT", SqlDbType.VarChar, 50), new SqlParameter("@TenDVT", SqlDbType.NVarChar, 50), new SqlParameter("@Note", SqlDbType.NVarChar), new SqlParameter("@IsKhongDung", SqlDbType.Bit), new SqlParameter("@UserID", SqlDbType.VarChar, 50) };
            thamsoinput[0].Value = DVT.sMaDVT;
            thamsoinput[1].Value = DVT.sTenDVT;
            thamsoinput[2].Value = DVT.sGhiChu;
            thamsoinput[3].Value = DVT.bIsKhongDung;
            thamsoinput[4].Value = DVT.sUserID;

            SqlParameter KetQuaTraVe = new SqlParameter("@KQSua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("DVT_Sua", thamsoinput, KetQuaTraVe);
        }

        public string XoaDVT(string MaDVT)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaDVT", SqlDbType.NVarChar, 50) };
            thamsoinput[0].Value = MaDVT;

            SqlParameter KetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("DVT_Xoa", thamsoinput, KetQua);
        }

        public DataTable LayDonViTinhLenDrdl()
        {
            try
            {
                CDuLieu qldl = new CDuLieu();
                return qldl.LoadTable("DVT_LayLenDrdl", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DVT_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DVT_LayMaxCapNhat", null);
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
        public int DVT_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DVT_LayMaxCapNhat", null);
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
        public int DVT_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DVT_LayMaxThemMoi", null);
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
        public int DVT_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DVT_LayMaxThemMoi", null);
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
        public DataTable DVT_LayDSDVTChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = {new SqlParameter("@MaxCapNhatnt", SqlDbType.Int)};
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DVT_LayDSDVTChuaCapNhatTaiNT", thamso);
        }
        public DataTable DVT_LayDSDVTChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DVT_LayDSDVTChuaThemMoiTaiNT", thamso);
        }
        public void DVT_DongBoThemDanhMuc(DataTable _DSDVTChuaThem)
        {
            if (_DSDVTChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSDVTChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@DVTid", SqlDbType.VarChar),
                                                new SqlParameter("@TenDVT", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["DVTid"].ToString();
                    thamso[1].Value = dr["TenDVT"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DVT_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void DVT_DongBoSuaDanhMuc(DataTable _DSDVTChuaCapNhat)
        {
            if (_DSDVTChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSDVTChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@DVTid", SqlDbType.VarChar),
                                                new SqlParameter("@TenDVT", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["DVTid"].ToString();
                    thamso[1].Value = dr["TenDVT"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DVT_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
