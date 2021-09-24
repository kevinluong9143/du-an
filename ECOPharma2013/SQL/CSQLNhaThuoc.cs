using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNhaThuoc
    {
        string _sNTID;

        public string SNTID
        {
            get { return _sNTID; }
            set { _sNTID = value; }
        }

        string _sMaNT;

        public string SMaNT
        {
            get { return _sMaNT; }
            set { _sMaNT = value; }
        }

        string _sTenNT;

        public string STenNT
        {
            get { return _sTenNT; }
            set { _sTenNT = value; }
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

        string _sNTEmail;

        public string SNTEmail
        {
            get { return _sNTEmail; }
            set { _sNTEmail = value; }
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

        string _sLGID;

        public string SLGID
        {
            get { return _sLGID; }
            set { _sLGID = value; }
        }

        decimal _dMaxTon;

        public decimal DMaxTon
        {
            get { return _dMaxTon; }
            set { _dMaxTon = value; }
        }

        decimal _dSaiSo;

        public decimal DSaiSo
        {
            get { return _dSaiSo; }
            set { _dSaiSo = value; }
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

        int _iNhomLoai;

        public int INhomLoai
        {
            get { return _iNhomLoai; }
            set { _iNhomLoai = value; }
        }

        public CSQLNhaThuoc() { }
        public CSQLNhaThuoc(string ntid, string tennt, string diachi, string quanid, string tpid, string tel, string fax, string ntemail, string pic, string dtdd, string picemail, string lgid, decimal maxton, decimal saiso, string ghichu, bool khongsudung, DateTime lastud, DateTime ngaytao, string userid, int nhomloai )
        {
            SNTID = ntid;
            STenNT = tennt;
            SDiaChi = diachi;
            SQuanID = quanid;
            STPID = tpid;
            STel = tel;
            SFax = fax;
            SNTEmail = ntemail;
            SPIC = pic;
            SDTDD = dtdd;
            SPICEmail = picemail;
            SLGID = lgid;
            DMaxTon = maxton;
            DSaiSo = saiso;
            SGhiChu = ghichu;
            BKhongSuDung = khongsudung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SUserID = userid;
            INhomLoai = nhomloai;
        }
        public string LayDinhMucTonNhaThuocTheoMa(string NTID)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = NTID;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayDinhMucTonNhaThuocTheoMa", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["DinhMucTonCuaHang"].ToString();
            }
            else
            {
                return null;
            }
        }
        public DataTable LayDanhSachNhaThuocLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhaThuoc_LoadNhaThuocLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ThemMoiNhaThuoc(CSQLNhaThuoc nhathuoc_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@TenNT", SqlDbType.NVarChar), 
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar), 
                                        new SqlParameter("@QuanID", SqlDbType.VarChar), 
                                        new SqlParameter("@TPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Tel", SqlDbType.VarChar), 
                                        new SqlParameter("@Fax", SqlDbType.VarChar), 
                                        new SqlParameter("@NTEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@PIC", SqlDbType.VarChar), 
                                        new SqlParameter("@DTDD", SqlDbType.VarChar), 
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@LGID", SqlDbType.VarChar),  
                                        new SqlParameter("@MaxTon", SqlDbType.Decimal),
                                        new SqlParameter("@SaiSo", SqlDbType.Decimal),
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@NhomLoai", SqlDbType.Int), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = nhathuoc_.STenNT;
            thamso[1].Value = nhathuoc_.SDiaChi;
            thamso[2].Value = nhathuoc_.SQuanID;
            thamso[3].Value = nhathuoc_.STPID;
            thamso[4].Value = nhathuoc_.STel;
            thamso[5].Value = nhathuoc_.SFax;
            thamso[6].Value = nhathuoc_.SNTEmail;
            thamso[7].Value = nhathuoc_.SPIC;
            thamso[8].Value = nhathuoc_.SDTDD;
            thamso[9].Value = nhathuoc_.SPICEmail;
            thamso[10].Value = nhathuoc_.SLGID;
            thamso[11].Value = nhathuoc_.DMaxTon;
            thamso[12].Value = nhathuoc_.DSaiSo;
            thamso[13].Value = nhathuoc_.SGhiChu;
            thamso[14].Value = nhathuoc_.BKhongSuDung;
            thamso[15].Value = nhathuoc_.DLastUD;
            thamso[16].Value = nhathuoc_.DNgayTao;
            thamso[17].Value = nhathuoc_.SUserID;
            thamso[18].Value = nhathuoc_.INhomLoai;
            thamso[19].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NhaThuoc_ThemMoiNhaThuoc", thamso, null);
                return thamso[19].Value.ToString();
            }
            //catch (Exception Exception) { throw Exception; }
            catch { return null; }
        }

        public DataTable LayNhaThuocTheoMa(string NTID)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = NTID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhaThuoc_LayNhaThuocTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinNhaThuoc(CSQLNhaThuoc nhathuoc_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@NTID", SqlDbType.VarChar),
                                        new SqlParameter("@TenNT", SqlDbType.NVarChar), 
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar), 
                                        new SqlParameter("@QuanID", SqlDbType.VarChar), 
                                        new SqlParameter("@TPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Tel", SqlDbType.VarChar), 
                                        new SqlParameter("@Fax", SqlDbType.VarChar), 
                                        new SqlParameter("@NTEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@PIC", SqlDbType.VarChar), 
                                        new SqlParameter("@DTDD", SqlDbType.VarChar), 
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@LGID", SqlDbType.VarChar),  
                                        new SqlParameter("@MaxTon", SqlDbType.Decimal), 
                                        new SqlParameter("@SaiSo", SqlDbType.Decimal),
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar),
                                        new SqlParameter("@NhomLoai", SqlDbType.Int)};
            thamso[0].Value = nhathuoc_.SNTID;
            thamso[1].Value = nhathuoc_.STenNT;
            thamso[2].Value = nhathuoc_.SDiaChi;
            thamso[3].Value = nhathuoc_.SQuanID;
            thamso[4].Value = nhathuoc_.STPID;
            thamso[5].Value = nhathuoc_.STel;
            thamso[6].Value = nhathuoc_.SFax;
            thamso[7].Value = nhathuoc_.SNTEmail;
            thamso[8].Value = nhathuoc_.SPIC;
            thamso[9].Value = nhathuoc_.SDTDD;
            thamso[10].Value = nhathuoc_.SPICEmail;
            thamso[11].Value = nhathuoc_.SLGID;
            thamso[12].Value = nhathuoc_.DMaxTon;
            thamso[13].Value = nhathuoc_.DSaiSo;
            thamso[14].Value = nhathuoc_.SGhiChu;
            thamso[15].Value = nhathuoc_.BKhongSuDung;
            thamso[16].Value = nhathuoc_.DLastUD;
            thamso[17].Value = nhathuoc_.SUserID;
            thamso[18].Value = nhathuoc_.INhomLoai;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhaThuoc_ChinhSuaThongTinNhaThuoc", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinNhaThuoc(string _maNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = _maNT;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhaThuoc_XoaThongTinNhaThuoc", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable NhaThuoc_LayDSNhaThuocLenCBBox()
        {
            try {
                CDuLieu qldl = new CDuLieu();
                return qldl.LoadTable("NhaThuoc_LayDSNhaThuocLenCBBox", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NhaThuoc_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayMaxCapNhat", null);
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
        public int NhaThuoc_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try{
                return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NhaThuoc_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayMaxThemMoi", null);
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
        public int NhaThuoc_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayMaxThemMoi", null);
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
        public DataTable NhaThuoc_LayDSNhaThuocChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhaThuoc_LayDSNhaThuocChuaCapNhatTaiNT", thamso);
        }
        public DataTable NhaThuoc_LayDSNhaThuocChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhaThuoc_LayDSNhaThuocChuaThemMoiTaiNT", thamso);
        }
        public void NhaThuoc_DongBoThemDanhMuc(DataTable _DSNhaThuocChuaThem)
        {
            if (_DSNhaThuocChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhaThuocChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar),
                                         new SqlParameter("@TenNT", SqlDbType.NVarChar), 
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar), 
                                        new SqlParameter("@QuanID", SqlDbType.VarChar), 
                                        new SqlParameter("@TPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Tel", SqlDbType.VarChar), 
                                        new SqlParameter("@Fax", SqlDbType.VarChar), 
                                        new SqlParameter("@NTEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@PIC", SqlDbType.VarChar), 
                                        new SqlParameter("@DTDD", SqlDbType.VarChar), 
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@LGID", SqlDbType.VarChar),  
                                        new SqlParameter("@MaxTon", SqlDbType.Decimal),
                                        new SqlParameter("@SaiSo", SqlDbType.Decimal),
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@NhomLoai", SqlDbType.Int), 
                                        new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                        new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@MaNT", SqlDbType.VarChar)
                                        };
                    thamso[0].Value = dr["NTID"].ToString();
                    thamso[1].Value = dr["TenNT"].ToString();
                    thamso[2].Value = dr["DiaChi"].ToString();
                    thamso[3].Value = dr["QuanID"].ToString();
                    thamso[4].Value = dr["TPID"].ToString();
                    thamso[5].Value = dr["Tel"].ToString();
                    thamso[6].Value = dr["Fax"].ToString();
                    thamso[7].Value = dr["NTEmail"].ToString();
                    thamso[8].Value = dr["PIC"].ToString();
                    thamso[9].Value = dr["DTDD"].ToString();
                    thamso[10].Value = dr["PICEmail"].ToString();
                    if (dr["LGID"].ToString() == "")
                    {
                        thamso[11].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[11].Value = dr["LGID"].ToString();
                    }
                    thamso[12].Value = decimal.Parse(dr["MaxTon"].ToString());
                    thamso[13].Value = decimal.Parse(dr["SaiSo"].ToString());
                    thamso[14].Value = dr["GhiChu"].ToString();
                    thamso[15].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[16].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[17].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[18].Value = CStaticBien.SmaTaiKhoan;
                    thamso[19].Value = int.Parse(dr["NhomLoai"].ToString());
                    thamso[20].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[21].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[22].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[23].Value = dr["MaNT"].ToString(); ;
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhaThuoc_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void NhaThuoc_DongBoSuaDanhMuc(DataTable _DSNhaThuocChuaCapNhat)
        {
            if (_DSNhaThuocChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhaThuocChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar),
                                         new SqlParameter("@TenNT", SqlDbType.NVarChar), 
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar), 
                                        new SqlParameter("@QuanID", SqlDbType.VarChar), 
                                        new SqlParameter("@TPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Tel", SqlDbType.VarChar), 
                                        new SqlParameter("@Fax", SqlDbType.VarChar), 
                                        new SqlParameter("@NTEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@PIC", SqlDbType.VarChar), 
                                        new SqlParameter("@DTDD", SqlDbType.VarChar), 
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar), 
                                        new SqlParameter("@LGID", SqlDbType.VarChar),  
                                        new SqlParameter("@MaxTon", SqlDbType.Decimal),
                                        new SqlParameter("@SaiSo", SqlDbType.Decimal),
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@NhomLoai", SqlDbType.Int), 
                                         new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                         new SqlParameter("@IsXoa", SqlDbType.Bit),
                                          new SqlParameter("@MaNT", SqlDbType.VarChar)  };
                    thamso[0].Value = dr["NTID"].ToString();
                    thamso[1].Value = dr["TenNT"].ToString();
                    thamso[2].Value = dr["DiaChi"].ToString();
                    thamso[3].Value = dr["QuanID"].ToString();
                    thamso[4].Value = dr["TPID"].ToString();
                    thamso[5].Value = dr["Tel"].ToString();
                    thamso[6].Value = dr["Fax"].ToString();
                    thamso[7].Value = dr["NTEmail"].ToString();
                    thamso[8].Value = dr["PIC"].ToString();
                    thamso[9].Value = dr["DTDD"].ToString();
                    thamso[10].Value = dr["PICEmail"].ToString();
                    if (dr["LGID"].ToString() == "")
                    {
                        thamso[11].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    else
                    {
                        thamso[11].Value = dr["LGID"].ToString();
                    }
                    thamso[12].Value = decimal.Parse(dr["MaxTon"].ToString());
                    thamso[13].Value = decimal.Parse(dr["SaiSo"].ToString());
                    thamso[14].Value = dr["GhiChu"].ToString();
                    thamso[15].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[16].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[17].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[18].Value = CStaticBien.SmaTaiKhoan;
                    thamso[19].Value = int.Parse(dr["NhomLoai"].ToString());
                    thamso[20].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[21].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[22].Value = dr["MaNT"].ToString();

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhaThuoc_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
        public DataTable LayDSNhaThuoc()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhaThuoc_layDSNhaThuoc", null);
        }

        public int LayNhomLoaiNhaThuoc()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhaThuoc_LayNhomLoaiNhaThuoc", null);
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
    }
}
