using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNPP
    {
        string _sNPPID;

        public string SNPPID
        {
            get { return _sNPPID; }
            set { _sNPPID = value; }
        }
        string _sTenNPP;

        public string STenNPP
        {
            get { return _sTenNPP; }
            set { _sTenNPP = value; }
        }
        string _sMST;

        public string SMST
        {
            get { return _sMST; }
            set { _sMST = value; }
        }
        string _sDiaChi;

        public string SDiaChi
        {
            get { return _sDiaChi; }
            set { _sDiaChi = value; }
        }
        string _sQuanID;

        public string SQuanID
        {
            get { return _sQuanID; }
            set { _sQuanID = value; }
        }
        string _sTPID;

        public string STPID
        {
            get { return _sTPID; }
            set { _sTPID = value; }
        }
        string _sTel;

        public string STel
        {
            get { return _sTel; }
            set { _sTel = value; }
        }
        string _sFax;

        public string SFax
        {
            get { return _sFax; }
            set { _sFax = value; }
        }
        string _sNPPEmail;

        public string SNPPEmail
        {
            get { return _sNPPEmail; }
            set { _sNPPEmail = value; }
        }
        string _sPIC;

        public string SPIC
        {
            get { return _sPIC; }
            set { _sPIC = value; }
        }
        string _sDTDD;

        public string SDTDD
        {
            get { return _sDTDD; }
            set { _sDTDD = value; }
        }
        string _sPICEmail;

        public string SPICEmail
        {
            get { return _sPICEmail; }
            set { _sPICEmail = value; }
        }
        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }
        bool _bKhongSuDung;

        public bool BKhongSuDung
        {
            get { return _bKhongSuDung; }
            set { _bKhongSuDung = value; }
        }
        DateTime _dLastUD;

        public DateTime DLastUD
        {
            get { return _dLastUD; }
            set { _dLastUD = value; }
        }
        DateTime _dNgayTao;

        public DateTime DNgayTao
        {
            get { return _dNgayTao; }
            set { _dNgayTao = value; }
        }
        string _sUserID;

        public string SUserID
        {
            get { return _sUserID; }
            set { _sUserID = value; }
        }

        public CSQLNPP() { }

        public string ThemNPP(CSQLNPP npp)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NPPID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@TenNPP", SqlDbType.NVarChar),
                                        new SqlParameter("@MST", SqlDbType.VarChar),
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                        new SqlParameter("@QuanID", SqlDbType.VarChar),
                                        new SqlParameter("@TPID", SqlDbType.VarChar),
                                        new SqlParameter("@Tel", SqlDbType.VarChar),
                                        new SqlParameter("@Fax", SqlDbType.VarChar),
                                        new SqlParameter("@NPPEmail", SqlDbType.VarChar),
                                        new SqlParameter("@PIC", SqlDbType.NVarChar),
                                        new SqlParameter("@DTDD", SqlDbType.VarChar),
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NText),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar) 
                                    };
                thamso[0].Direction = ParameterDirection.Output;
                thamso[1].Value = npp.STenNPP;
                thamso[2].Value = npp.SMST;
                thamso[3].Value = npp.SDiaChi;
                thamso[4].Value = npp.SQuanID;
                thamso[5].Value = npp.STPID;
                thamso[6].Value = npp.STel;
                thamso[7].Value = npp.SFax;
                thamso[8].Value = npp.SNPPEmail;
                thamso[9].Value = npp.SPIC;
                thamso[10].Value = npp.SDTDD;
                thamso[11].Value = npp.SPICEmail;
                thamso[12].Value = npp.SGhiChu;
                thamso[13].Value = npp.BKhongSuDung;
                thamso[14].Value = npp.DLastUD;
                thamso[15].Value = npp.DNgayTao;
                thamso[16].Value = npp.SUserID;

                CDuLieu dl = new CDuLieu();
                dl.InsertDuLieu("NPP_ThemNPP", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int SuaNPP(CSQLNPP npp)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NPPID", SqlDbType.VarChar),
                                        new SqlParameter("@TenNPP", SqlDbType.NVarChar),
                                        new SqlParameter("@MST", SqlDbType.VarChar),
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                        new SqlParameter("@QuanID", SqlDbType.VarChar),
                                        new SqlParameter("@TPID", SqlDbType.VarChar),
                                        new SqlParameter("@Tel", SqlDbType.VarChar),
                                        new SqlParameter("@Fax", SqlDbType.VarChar),
                                        new SqlParameter("@NPPEmail", SqlDbType.VarChar),
                                        new SqlParameter("@PIC", SqlDbType.NVarChar),
                                        new SqlParameter("@DTDD", SqlDbType.VarChar),
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NText),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar) 
                                    };
                thamso[0].Value = npp.SNPPID;
                thamso[1].Value = npp.STenNPP;
                thamso[2].Value = npp.SMST;
                thamso[3].Value = npp.SDiaChi;
                thamso[4].Value = npp.SQuanID;
                thamso[5].Value = npp.STPID;
                thamso[6].Value = npp.STel;
                thamso[7].Value = npp.SFax;
                thamso[8].Value = npp.SNPPEmail;
                thamso[9].Value = npp.SPIC;
                thamso[10].Value = npp.SDTDD;
                thamso[11].Value = npp.SPICEmail;
                thamso[12].Value = npp.SGhiChu;
                thamso[13].Value = npp.BKhongSuDung;
                thamso[14].Value = npp.DLastUD;
                thamso[15].Value = npp.DNgayTao;
                thamso[16].Value = npp.SUserID;

                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NPP_SuaNPP", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int XoaNPP(string nppid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@NPPID", SqlDbType.VarChar) };
                thamso[0].Value = nppid;
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NPP_XoaNPP", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayNPPLenLuoi(bool xemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = xemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NPP_LayNPPLenLuoi", thamso);
        }

        public DataTable LayNPPTheoMa(string nppid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NPPID", SqlDbType.VarChar) };
            thamso[0].Value = nppid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NPP_LayNPPTheoMa", thamso);
        }



        public int NPP_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NPP_LayMaxCapNhat", null);
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
        public int NPP_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NPP_LayMaxCapNhat", null);
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
        public int NPP_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NPP_LayMaxThemMoi", null);
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
        public int NPP_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NPP_LayMaxThemMoi", null);
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

        public DataTable NPP_LayDSNPPChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NPP_LayDSNPPChuaCapNhatTaiNT", thamso);
        }
        public DataTable NPP_LayDSNPPChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NPP_LayDSNPPChuaThemMoiTaiNT", thamso);
        }
        public void NPP_DongBoThemDanhMuc(DataTable dsNPPChuaThemMoi)
        {
            //MST, DiaChi, QuanID, TPID, Tel, Fax, NPPEmail, PIC, DTDD, PICEmail,
            if (dsNPPChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNPPChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NPPid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNPP", SqlDbType.NVarChar),
                                                new SqlParameter("@MST", SqlDbType.VarChar),
                                                new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                                new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@Tel", SqlDbType.VarChar),
                                                new SqlParameter("@Fax", SqlDbType.VarChar),
                                                new SqlParameter("@NPPEmail", SqlDbType.VarChar),
                                                new SqlParameter("@PIC", SqlDbType.NVarChar),
                                                new SqlParameter("@DTDD", SqlDbType.VarChar),
                                                new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                                };
                    thamso[0].Value = dr["NPPid"].ToString();
                    thamso[1].Value = dr["TenNPP"].ToString();
                    thamso[2].Value = dr["MST"].ToString();
                    thamso[3].Value = dr["DiaChi"].ToString();
                    if (dr["QuanID"].ToString() != null && dr["QuanID"].ToString().Length > 0)
                        thamso[4].Value = dr["QuanID"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["TPID"].ToString() != null && dr["TPID"].ToString().Length > 0)
                        thamso[5].Value = dr["TPID"].ToString();
                    else
                        thamso[5].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[6].Value = dr["Tel"].ToString();
                    thamso[7].Value = dr["Fax"].ToString();
                    thamso[8].Value = dr["NPPEmail"].ToString();
                    thamso[9].Value = dr["PIC"].ToString();
                    thamso[10].Value = dr["DTDD"].ToString();
                    thamso[11].Value = dr["PICEmail"].ToString();
                    thamso[12].Value = dr["GhiChu"].ToString();
                    thamso[13].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[15].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[16].Value = CStaticBien.SmaTaiKhoan;
                    thamso[17].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[18].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[19].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NPP_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void NPP_DongBoSuaDanhMuc(DataTable dsNPPChuaCapNhat)
        {
            if (dsNPPChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNPPChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NPPid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNPP", SqlDbType.NVarChar),
                                                new SqlParameter("@MST", SqlDbType.VarChar),
                                                new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                                new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@Tel", SqlDbType.VarChar),
                                                new SqlParameter("@Fax", SqlDbType.VarChar),
                                                new SqlParameter("@NPPEmail", SqlDbType.VarChar),
                                                new SqlParameter("@PIC", SqlDbType.NVarChar),
                                                new SqlParameter("@DTDD", SqlDbType.VarChar),
                                                new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                         new SqlParameter("@IsXoa", SqlDbType.Bit)};
                    thamso[0].Value = dr["NPPid"].ToString();
                    thamso[1].Value = dr["TenNPP"].ToString();
                    thamso[2].Value = dr["MST"].ToString();
                    thamso[3].Value = dr["DiaChi"].ToString();
                    if (dr["QuanID"].ToString() != null && dr["QuanID"].ToString().Length > 0)
                        thamso[4].Value = dr["QuanID"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["TPID"].ToString() != null && dr["TPID"].ToString().Length > 0)
                        thamso[5].Value = dr["TPID"].ToString();
                    else
                        thamso[5].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[6].Value = dr["Tel"].ToString();
                    thamso[7].Value = dr["Fax"].ToString();
                    thamso[8].Value = dr["NPPEmail"].ToString();
                    thamso[9].Value = dr["PIC"].ToString();
                    thamso[10].Value = dr["DTDD"].ToString();
                    thamso[11].Value = dr["PICEmail"].ToString();
                    thamso[12].Value = dr["GhiChu"].ToString();
                    thamso[13].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[15].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[16].Value = CStaticBien.SmaTaiKhoan;
                    thamso[17].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[18].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NPP_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
        public int KiemTraTrungMST(string mst_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@MST", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);
                XemTC.Value = mst_;
                thamso[0] = XemTC;
                KQ.Direction = ParameterDirection.Output;
                thamso[1] = KQ;
                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NPP_KiemTraTrungMST", thamso);
                return int.Parse(thamso[1].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public DataTable LoadDSNPPLenMComboBox()
        {
            CDuLieu LopDL = new CDuLieu();
            return LopDL.LoadTable("NPP_LoadDSNPPLenMComboBox", null);
        }
    }
}
