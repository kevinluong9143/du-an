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
    class CSQLBoPhan
    {
        private string MaBP;
        private string TenBP;
        private string GhiChu;
        private bool IsKhongDung;

        public string sTenBP
        {
            get { return TenBP; }
            set { TenBP = value; }
        }

        public string sGhiChu
        {
            get { return GhiChu; }
            set { GhiChu = value; }
        }

        public bool bIsKhongDung
        {
            get { return IsKhongDung; }
            set { IsKhongDung = value; }
        }

        public string sMaBP
        {
            get { return MaBP; }
            set { MaBP = value; }
        }

        public CSQLBoPhan()
        {
            bIsKhongDung = false;
        }

        public string LuuBoPhan(CSQLBoPhan BoPhan,string MaBPChafrmForm)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@Ten", SqlDbType.NVarChar,50), new SqlParameter("@Note", SqlDbType.NText), new SqlParameter("@IsKhongDung", SqlDbType.Bit),new SqlParameter("@MaBPChatoTable",SqlDbType.VarChar,50),};
            thamsoinput[0].Value = BoPhan.sTenBP;
            thamsoinput[1].Value = BoPhan.sGhiChu;
            thamsoinput[2].Value = BoPhan.bIsKhongDung;
            thamsoinput[3].Value = MaBPChafrmForm;

            SqlParameter MaBPfromTable = new SqlParameter("@MaBPfrmTable", SqlDbType.VarChar, 50);
            //cmd.Parameters.Add(p2);
            //p2.Direction = ParameterDirection.Output;
            return LopDL.InsertDuLieu("BoPhan_ThemBoPhan", thamsoinput, MaBPfromTable);
        }

        public string SuaBoPhan(CSQLBoPhan BoPhan, string MaBPChafrmForm)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaBP", SqlDbType.VarChar, 50), new SqlParameter("@MaBPCha", SqlDbType.VarChar, 50), new SqlParameter("@TenBP", SqlDbType.NVarChar, 50), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@IsKhongDung", SqlDbType.Bit)};
            thamsoinput[0].Value = BoPhan.sMaBP;
            thamsoinput[1].Value = MaBPChafrmForm;
            thamsoinput[2].Value = BoPhan.sTenBP;
            thamsoinput[3].Value = BoPhan.sGhiChu;
            thamsoinput[4].Value = BoPhan.bIsKhongDung;
            

            SqlParameter KetQuaTraVe = new SqlParameter("@KetQua", SqlDbType.NVarChar,500);
            //cmd.Parameters.Add(p2);
            //p2.Direction = ParameterDirection.Output;
            return LopDL.CapNhatDuLieu("BoPhan_SuaBoPhan", thamsoinput, KetQuaTraVe);
        }


        public DataTable LoadDSBoPhanLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@FalseHoatDong", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("BoPhan_LoadDSBoPhanLenCombobox", thamsoinput);
        }

        public DataTable LoadDS_MaBPCha()
        {
            CDuLieu LopDL = new CDuLieu();
            return LopDL.LoadTable("BoPhan_LoadDS_MaBPCha", null);
        }

        public DataTable LoadDSBoPhanLenCombobox_Sua(string MaBPCon)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@FalseHoatDong", SqlDbType.Bit),new SqlParameter("@MaBPCon",SqlDbType.VarChar,50) };
            thamsoinput[0].Value = false;
            thamsoinput[1].Value = MaBPCon;

            return LopDL.LoadTable("BoPhan_LoadDSBoPhanLenCombobox_Sua", thamsoinput);
        }

        public DataTable LoadDSBoPhanLenLuoi(bool IsXemTatCa)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] XemTatCa = {new SqlParameter("@XemTatCa", SqlDbType.Bit)};
            XemTatCa[0].Value = IsXemTatCa;

            return LopDL.LoadTable("BoPhan_LoadDSBoPhanLenLuoi", XemTatCa);
        }

        public DataTable LayBoPhanCanSua(string MaBP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaBPcanTim = { new SqlParameter("@MaBP", SqlDbType.VarChar,50) };
            MaBPcanTim[0].Value = MaBP;

            return LopDL.LoadTable("BoPhan_TimBoPhanTheoMa", MaBPcanTim);
        }

        public DataTable TimMaBPChaTheoMa(string MaBPCon)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaBPcanTim = { new SqlParameter("@MaBPCon", SqlDbType.VarChar, 50) };
            MaBPcanTim[0].Value = MaBPCon;

            return LopDL.LoadTable("BoPhan_TimMaBPChaTheoMa", MaBPcanTim);
        }
        public bool KiemTraRangBuocTruocKhiXoa(string MaBP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaBP", SqlDbType.NVarChar, 50) };
            thamsoinput[0].Value = MaBP;

            SqlParameter KetQua = new SqlParameter("@KetQua", SqlDbType.Bit);
            return LopDL.KiemTra("BoPhan_KiemTraRangBuocTruocKhiXoa", thamsoinput, KetQua);
        }

        public string XoaBoPhan(string MaBP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaBP", SqlDbType.NVarChar, 50) };
            thamsoinput[0].Value = MaBP;

            SqlParameter KetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar,500);
            return LopDL.CapNhatDuLieu("BoPhan_Xoa", thamsoinput, KetQua);
        }

        public int BoPhan_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("BoPhan_LayMaxCapNhat", null);
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
        public int BoPhan_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("BoPhan_LayMaxCapNhat", null);
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
        public int BoPhan_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("BoPhan_LayMaxThemMoi", null);
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
        public int BoPhan_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("BoPhan_LayMaxThemMoi", null);
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
        public DataTable BoPhan_LayDSBoPhanChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("BoPhan_LayDSBoPhanChuaCapNhatTaiNT", thamso);
        }
        public DataTable BoPhan_LayDSBoPhanChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("BoPhan_LayDSBoPhanChuaThemMoiTaiNT", thamso);
        }
        public void BoPhan_DongBoThemDanhMuc(DataTable _DSBoPhanChuaThem)
        {
            if (_DSBoPhanChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSBoPhanChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@MaBP", SqlDbType.VarChar),
                                                new SqlParameter("@TenBP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@BranchNo", SqlDbType.NVarChar)
                                            };
                    thamso[0].Value = dr["MaBP"].ToString();
                    thamso[1].Value = dr["TenBP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[7].Value = dr["BranchNo"].ToString();

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("BoPhan_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void BoPhan_DongBoSuaDanhMuc(DataTable _DSBoPhanChuaCapNhat)
        {
            if (_DSBoPhanChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSBoPhanChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@MaBP", SqlDbType.VarChar),
                                                new SqlParameter("@TenBP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@BranchNo", SqlDbType.NVarChar)
                                            };
                    thamso[0].Value = dr["MaBP"].ToString();
                    thamso[1].Value = dr["TenBP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[6].Value = dr["BranchNo"].ToString();

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("BoPhan_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        //Bộ Phận CT
        public int BoPhanCT_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("BoPhanCT_LayMaxCapNhat", null);
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
        public int BoPhanCT_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("BoPhanCT_LayMaxCapNhat", null);
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
        public int BoPhanCT_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("BoPhanCT_LayMaxThemMoi", null);
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
        public int BoPhanCT_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("BoPhanCT_LayMaxThemMoi", null);
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
        public DataTable BoPhanCT_LayDSBoPhanCTChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("BoPhanCT_LayDSBoPhanCTChuaCapNhatTaiNT", thamso);
        }
        public DataTable BoPhanCT_LayDSBoPhanCTChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("BoPhanCT_LayDSBoPhanCTChuaThemMoiTaiNT", thamso);
        }
        public void BoPhanCT_DongBoThemDanhMuc(DataTable _DSBoPhanCTChuaThem)
        {
            if (_DSBoPhanCTChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSBoPhanCTChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@RecordBPCT", SqlDbType.VarChar),
                                                new SqlParameter("@MaBPCon", SqlDbType.VarChar),
                                                new SqlParameter("@MaBPCha", SqlDbType.VarChar),
                                                new SqlParameter("@ThuCap", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["RecordBPCT"].ToString();
                    thamso[1].Value = dr["MaBPCon"].ToString();
                    thamso[2].Value = dr["MaBPCha"].ToString();
                    thamso[3].Value = int.Parse(dr["ThuCap"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("BoPhanCT_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void BoPhanCT_DongBoSuaDanhMuc(DataTable _DSBoPhanCTChuaCapNhat)
        {
            if (_DSBoPhanCTChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSBoPhanCTChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@RecordBPCT", SqlDbType.VarChar),
                                                new SqlParameter("@MaBPCon", SqlDbType.VarChar),
                                                new SqlParameter("@MaBPCha", SqlDbType.VarChar),
                                                new SqlParameter("@ThuCap", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int)
                                            };
                    thamso[0].Value = dr["RecordBPCT"].ToString();
                    thamso[1].Value = dr["MaBPCon"].ToString();
                    thamso[2].Value = dr["MaBPCha"].ToString();
                    thamso[3].Value = int.Parse(dr["ThuCap"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("BoPhan_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
