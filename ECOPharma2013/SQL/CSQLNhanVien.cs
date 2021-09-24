using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhanVien
    {
        string _sNVID;

        public string SNVID
        {
            get { return _sNVID; }
            set { _sNVID = value; }
        }
        string _sBPID;

        public string SBPID
        {
            get { return _sBPID; }
            set { _sBPID = value; }
        }
        string _sSoThe;

        public string SSoThe
        {
            get { return _sSoThe; }
            set { _sSoThe = value; }
        }
        string _sMST;

        public string SMST
        {
            get { return _sMST; }
            set { _sMST = value; }
        }
        string _sHoTen;

        public string SHoTen
        {
            get { return _sHoTen; }
            set { _sHoTen = value; }
        }
        string _sGioiTinhID;

        public string SGioiTinhID
        {
            get { return _sGioiTinhID; }
            set { _sGioiTinhID = value; }
        }
        DateTime _dNgaySinh;

        public DateTime DNgaySinh
        {
            get { return _dNgaySinh; }
            set { _dNgaySinh = value; }
        }
        string _sCMND;

        public string SCMND
        {
            get { return _sCMND; }
            set { _sCMND = value; }
        }
        DateTime _dNgayCap;

        public DateTime DNgayCap
        {
            get { return _dNgayCap; }
            set { _dNgayCap = value; }
        }
        string _sNoiCap;

        public string SNoiCap
        {
            get { return _sNoiCap; }
            set { _sNoiCap = value; }
        }
        string _sDTDD;

        public string SDTDD
        {
            get { return _sDTDD; }
            set { _sDTDD = value; }
        }
        string _sEmail;

        public string SEmail
        {
            get { return _sEmail; }
            set { _sEmail = value; }
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
        string _sMaNV;

        public string SMaNV
        {
            get { return _sMaNV; }
            set { _sMaNV = value; }
        }
        string _sMaDinhDanh;

        public string SMaDinhDanh
        {
            get { return _sMaDinhDanh; }
            set { _sMaDinhDanh = value; }
        }


        public CSQLNhanVien() { }

        public DataTable LayThongTinNhanVienLenLuoi(bool XemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = XemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhanVien_LayNhanVienLenLuoi", thamso);
        }

        public DataTable LayThongTinNhanVienTheoMa(string nvid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NVID", SqlDbType.VarChar) };
            thamso[0].Value = nvid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhanVien_LayNhanVienLenLuoiTheoMa", thamso);
        }

        public string ThemNhanVien(CSQLNhanVien nv)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NVID", SqlDbType.VarChar,50),
                                         new SqlParameter("@BPID", SqlDbType.VarChar),
                                         new SqlParameter("@SoThe", SqlDbType.VarChar),
                                         new SqlParameter("@MST", SqlDbType.VarChar),
                                         new SqlParameter("@HoTen", SqlDbType.NVarChar),
                                         new SqlParameter("@GTID", SqlDbType.Char),
                                         new SqlParameter("@NgaySinh", SqlDbType.DateTime),
                                         new SqlParameter("@CMND", SqlDbType.VarChar),
                                         new SqlParameter("@NgayCap", SqlDbType.DateTime),
                                         new SqlParameter("@NoiCap", SqlDbType.VarChar),
                                         new SqlParameter("@DTDD", SqlDbType.VarChar),
                                         new SqlParameter("@Email", SqlDbType.VarChar),
                                         new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar),
                                         new SqlParameter("@MaNV", SqlDbType.VarChar),
                                         new SqlParameter("@MaDinhDanh", SqlDbType.VarChar)};
                thamso[0].Direction = ParameterDirection.Output;
                thamso[1].Value = nv.SBPID;
                thamso[2].Value = nv.SSoThe;
                thamso[3].Value = nv.SMST;
                thamso[4].Value = nv.SHoTen;
                thamso[5].Value = nv.SGioiTinhID;
                thamso[6].Value = nv.DNgaySinh;
                thamso[7].Value = nv.SCMND;
                thamso[8].Value = nv.DNgayCap;
                thamso[9].Value = nv.SNoiCap;
                thamso[10].Value = nv.SDTDD;
                thamso[11].Value = nv.SEmail;
                thamso[12].Value = nv.SGhiChu;
                thamso[13].Value = nv.BKhongSuDung;
                thamso[14].Value = nv.DLastUD;
                thamso[15].Value = nv.DNgayTao;
                thamso[16].Value = nv.SUserID;
                thamso[17].Value = nv.SMaNV;
                thamso[18].Value = nv.SMaDinhDanh;
                CDuLieu qldl = new CDuLieu();
                qldl.InsertDuLieu("NhanVien_ThemNhanVien", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SuaNhanVien(CSQLNhanVien nv)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NVID", SqlDbType.VarChar),
                                         new SqlParameter("@BPID", SqlDbType.VarChar),
                                         new SqlParameter("@SoThe", SqlDbType.VarChar),
                                         new SqlParameter("@MST", SqlDbType.VarChar),
                                         new SqlParameter("@HoTen", SqlDbType.NVarChar),
                                         new SqlParameter("@GTID", SqlDbType.Char),
                                         new SqlParameter("@NgaySinh", SqlDbType.DateTime),
                                         new SqlParameter("@CMND", SqlDbType.VarChar),
                                         new SqlParameter("@NgayCap", SqlDbType.DateTime),
                                         new SqlParameter("@NoiCap", SqlDbType.VarChar),
                                         new SqlParameter("@DTDD", SqlDbType.VarChar),
                                         new SqlParameter("@Email", SqlDbType.VarChar),
                                         new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar),
                                         new SqlParameter("@MaNV", SqlDbType.VarChar),
                                         new SqlParameter("@MaDinhDanh", SqlDbType.VarChar)};
                thamso[0].Value = nv.SNVID;
                thamso[1].Value = nv.SBPID;
                thamso[2].Value = nv.SSoThe;
                thamso[3].Value = nv.SMST;
                thamso[4].Value = nv.SHoTen;
                thamso[5].Value = nv.SGioiTinhID;
                thamso[6].Value = nv.DNgaySinh;
                thamso[7].Value = nv.SCMND;
                thamso[8].Value = nv.DNgayCap;
                thamso[9].Value = nv.SNoiCap;
                thamso[10].Value = nv.SDTDD;
                thamso[11].Value = nv.SEmail;
                thamso[12].Value = nv.SGhiChu;
                thamso[13].Value = nv.BKhongSuDung;
                thamso[14].Value = nv.DLastUD;
                thamso[15].Value = nv.DNgayTao;
                thamso[16].Value = nv.SUserID;
                thamso[17].Value = nv.SMaNV;
                thamso[18].Value = nv.SMaDinhDanh;
                CDuLieu qldl = new CDuLieu();
                return qldl.ThucThiTraVeKetQuaKieuInt("NhanVien_SuaNhanVien", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int XoaNhanVien(string _nvid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NVID", SqlDbType.VarChar) };
            thamso[0].Value = _nvid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NhanVien_XoaNhanVien", thamso);
        }

        public DataTable LayDSNhanVienTheoBoPhan(string bpid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BPID", SqlDbType.VarChar) };
            thamso[0].Value = bpid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhanVien_LayDSMa_HOTENNhanVienTheoBoPhan", thamso);
        }

        public int NhanVien_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhanVien_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public int NhanVien_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhanVien_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public int NhanVien_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhanVien_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public int NhanVien_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhanVien_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public DataTable NhanVien_LayDSNhanVienChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhanVien_LayDSNhanVienChuaCapNhatTaiNT", thamso);
        }
        public DataTable NhanVien_LayDSNhanVienChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhanVien_LayDSNhanVienChuaThemMoiTaiNT", thamso);
        }
        public void NhanVien_DongBoThemDanhMuc(DataTable _DSNhanVienChuaThem)
        {
            if (_DSNhanVienChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhanVienChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NVID", SqlDbType.VarChar,50),
                                         new SqlParameter("@BPID", SqlDbType.VarChar),
                                         new SqlParameter("@SoThe", SqlDbType.VarChar),
                                         new SqlParameter("@MST", SqlDbType.VarChar),
                                         new SqlParameter("@HoTen", SqlDbType.NVarChar),
                                         new SqlParameter("@GTID", SqlDbType.Char),
                                         new SqlParameter("@NgaySinh", SqlDbType.DateTime),
                                         new SqlParameter("@CMND", SqlDbType.VarChar),
                                         new SqlParameter("@NgayCap", SqlDbType.DateTime),
                                         new SqlParameter("@NoiCap", SqlDbType.VarChar),
                                         new SqlParameter("@DTDD", SqlDbType.VarChar),
                                         new SqlParameter("@Email", SqlDbType.VarChar),
                                         new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar),
                                         new SqlParameter("@MaNV", SqlDbType.VarChar),
                                         new SqlParameter("@MaDinhDanh", SqlDbType.VarChar),
                                         new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                         new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                         new SqlParameter("@IsXoa", SqlDbType.Bit)};
                    thamso[0].Value = dr["NVID"].ToString();
                    if (dr["BPID"].ToString() == "")
                    {
                        thamso[1].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[1].Value = dr["BPID"].ToString();
                    }

                    thamso[2].Value = dr["SoThe"].ToString();
                    thamso[3].Value = dr["MST"].ToString();
                    thamso[4].Value = dr["HoTen"].ToString();
                    thamso[5].Value = dr["GTID"].ToString();
                    if (dr["NgaySinh"].ToString() == "")
                    {
                        thamso[6].Value = DateTime.Parse("1/1/1774");
                    }
                    else
                    {
                        thamso[6].Value = DateTime.Parse(dr["NgaySinh"].ToString());
                    }
                    thamso[7].Value = dr["CMND"].ToString();
                    if (dr["NgayCap"].ToString() == "")
                    {
                        thamso[8].Value = DateTime.Parse("1/1/1774");
                    }
                    else
                    {
                        thamso[8].Value = DateTime.Parse(dr["NgayCap"].ToString());
                    }
                    if (dr["NoiCap"].ToString() == "")
                    {
                        thamso[9].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[9].Value = dr["NoiCap"].ToString();
                    }
                    thamso[10].Value = dr["DTDD"].ToString();
                    thamso[11].Value = dr["Email"].ToString();
                    thamso[12].Value = dr["GhiChu"].ToString();
                    thamso[13].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[15].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[16].Value = CStaticBien.SmaTaiKhoan;
                    thamso[17].Value = dr["MaNV"].ToString();
                    thamso[18].Value = dr["MaDinhDanh"].ToString();
                    thamso[19].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[20].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[21].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhanVien_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void NhanVien_DongBoSuaDanhMuc(DataTable _DSNhanVienChuaCapNhat)
        {
            if (_DSNhanVienChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhanVienChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NVID", SqlDbType.VarChar,50),
                                         new SqlParameter("@BPID", SqlDbType.VarChar),
                                         new SqlParameter("@SoThe", SqlDbType.VarChar),
                                         new SqlParameter("@MST", SqlDbType.VarChar),
                                         new SqlParameter("@HoTen", SqlDbType.NVarChar),
                                         new SqlParameter("@GTID", SqlDbType.Char),
                                         new SqlParameter("@NgaySinh", SqlDbType.DateTime),
                                         new SqlParameter("@CMND", SqlDbType.VarChar),
                                         new SqlParameter("@NgayCap", SqlDbType.DateTime),
                                         new SqlParameter("@NoiCap", SqlDbType.VarChar),
                                         new SqlParameter("@DTDD", SqlDbType.VarChar),
                                         new SqlParameter("@Email", SqlDbType.VarChar),
                                         new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar),
                                         new SqlParameter("@MaNV", SqlDbType.VarChar),
                                         new SqlParameter("@MaDinhDanh", SqlDbType.VarChar),
                                         new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                         new SqlParameter("@IsXoa", SqlDbType.Bit)};
                    thamso[0].Value = dr["NVID"].ToString();
                    if (dr["BPID"].ToString() == "")
                    {
                        thamso[1].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[1].Value = dr["BPID"].ToString();
                    }
                    
                    thamso[2].Value = dr["SoThe"].ToString();
                    thamso[3].Value = dr["MST"].ToString();
                    thamso[4].Value = dr["HoTen"].ToString();
                    thamso[5].Value = dr["GTID"].ToString();
                    if (dr["NgaySinh"].ToString() == "")
                    {
                        thamso[6].Value = DateTime.Parse("1/1/1774");
                    }
                    else
                    {
                        thamso[6].Value = DateTime.Parse(dr["NgaySinh"].ToString());
                    }
                    thamso[7].Value = dr["CMND"].ToString();
                    if (dr["NgayCap"].ToString() == "")
                    {
                        thamso[8].Value = DateTime.Parse("1/1/1774");
                    }
                    else
                    {
                        thamso[8].Value = DateTime.Parse(dr["NgayCap"].ToString());
                    }
                    if (dr["NoiCap"].ToString() == "")
                    {
                        thamso[9].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[9].Value = dr["NoiCap"].ToString();
                    }
                    thamso[10].Value = dr["DTDD"].ToString();
                    thamso[11].Value = dr["Email"].ToString();
                    thamso[12].Value = dr["GhiChu"].ToString();
                    thamso[13].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[15].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[16].Value = CStaticBien.SmaTaiKhoan;
                    thamso[17].Value = dr["MaNV"].ToString();
                    thamso[18].Value = dr["MaDinhDanh"].ToString();
                    thamso[19].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[20].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhanVien_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public int KiemTraTrungMaNV(string manv_, string nvid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@MaNV", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@NVID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);
                

                XemTC.Value = manv_;
                thamso[0] = XemTC;

                nvid.Value = nvid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanVien_KiemTraTrungMaNV", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }


        public int KiemTraTrungCMND(string cmnd_, string nvid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@CMND", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@NVID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);

                XemTC.Value = cmnd_;
                thamso[0] = XemTC;

                nvid.Value = nvid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanVien_KiemTraTrungCMND", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int KiemTraTrungSoThe(string sothe_, string nvid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@SoThe", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@NVID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);

                XemTC.Value = sothe_;
                thamso[0] = XemTC;

                nvid.Value = nvid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanVien_KiemTraTrungSoThe", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int KiemTraTrungMST(string mst_, string nvid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@MST", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@NVID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);

                XemTC.Value = mst_;
                thamso[0] = XemTC;

                nvid.Value = nvid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanVien_KiemTraTrungMST", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int KiemTraTrungMaDinhDanh(string madinhdanh_, string nvid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@MaDinhDanh", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@NVID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);

                XemTC.Value = madinhdanh_;
                thamso[0] = XemTC;

                nvid.Value = nvid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanVien_KiemTraTrungMaDinhDanh", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public DataTable LoadDSNVLenMComboBox()
        {
            CDuLieu LopDL = new CDuLieu();
            return LopDL.LoadTable("NhanVien_LoadDSNhanVienLenMComboBox", null);
        }

    }
}

