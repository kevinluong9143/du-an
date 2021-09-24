using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLDBC
    {
        string _sMaDBC;

        public string SMaDBC
        {
            get { return _sMaDBC; }
            set { _sMaDBC = value; }
        }
        string _sTenDBC;

        public string STenDBC
        {
            get { return _sTenDBC; }
            set { _sTenDBC = value; }
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
        string _suserID;

        public string SUserID
        {
            get { return _suserID; }
            set { _suserID = value; }
        }
        public CSQLDBC() { }
        public CSQLDBC(string maDBC, string tenDBC, string ghiChu, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid)
        {
            SMaDBC = maDBC;
            STenDBC = tenDBC;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SUserID = userid;
        }

        public DataTable LayDanhSachDBCLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("DBC_LoadDBCLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ThemMoiDBC(CSQLDBC dbc_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenDBC", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NVarChar), new SqlParameter("@KhongSuDung", SqlDbType.Bit), new SqlParameter("@LastUD", SqlDbType.DateTime), new SqlParameter("@NgayTao", SqlDbType.DateTime), new SqlParameter("@UserID", SqlDbType.VarChar), new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = dbc_.STenDBC;
            thamso[1].Value = dbc_.SGhiChu;
            thamso[2].Value = dbc_.BKhongSuDung;
            thamso[3].Value = dbc_.DLastUD;
            thamso[4].Value = dbc_.DNgayTao;
            thamso[5].Value = dbc_.SUserID;

            thamso[6].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("DBC_ThemMoiDBC", thamso, null);
                return thamso[6].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public DataTable LayDBCTheoMa(string DBCID)
        {
            CSQLDBC quan = new CSQLDBC();
            SqlParameter[] thamso = { new SqlParameter("@DBCID", SqlDbType.VarChar) };
            thamso[0].Value = DBCID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("DBC_LayDBCTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinDBC(CSQLDBC dbc_)
        {
            SqlParameter[] thamso = { new SqlParameter("@DBCID", SqlDbType.VarChar), new SqlParameter("@TenDBC", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@KhongSuDung", SqlDbType.Bit), new SqlParameter("@LastUD", SqlDbType.DateTime), new SqlParameter("@NgayTao", SqlDbType.DateTime), new SqlParameter("@UserID", SqlDbType.VarChar) };
            //tham số mới để chỉnh sửa
            thamso[0].Value = dbc_._sMaDBC;
            thamso[1].Value = dbc_._sTenDBC;
            thamso[2].Value = dbc_._sGhiChu;
            thamso[3].Value = dbc_._bKhongSuDung;
            thamso[4].Value = dbc_.DLastUD;
            thamso[5].Value = dbc_.DNgayTao;
            thamso[6].Value = dbc_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DBC_ChinhSuaThongTinDBC", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinDBC(string _maDBC)
        {
            SqlParameter[] thamso = { new SqlParameter("@DBCID", SqlDbType.VarChar) };
            thamso[0].Value = _maDBC;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DBC_XoaThongTinDBC", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }


        public int DBC_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DBC_LayMaxCapNhat", null);
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
        public int DBC_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DBC_LayMaxCapNhat", null);
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
        public int DBC_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DBC_LayMaxThemMoi", null);
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
        public int DBC_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DBC_LayMaxThemMoi", null);
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

        public DataTable DBC_LayDSDBCChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DBC_LayDSDBCChuaCapNhatTaiNT", thamso);
        }
        public DataTable DBC_LayDSDBCChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DBC_LayDSDBCChuaThemMoiTaiNT", thamso);
        }
        public void DBC_DongBoThemDanhMuc(DataTable dsDBCChuaThemMoi)
        {
            //(DBCID, TenDBC, GhiChu, KhongSuDung, LastUD, NgayTao, UserID,MaxCapNhat)
            if (dsDBCChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsDBCChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@DBCid", SqlDbType.VarChar),
                                                new SqlParameter("@TenDBC", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["DBCid"].ToString();
                    thamso[1].Value = dr["TenDBC"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DBC_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void DBC_DongBoSuaDanhMuc(DataTable dsDBCChuaCapNhat)
        {
            if (dsDBCChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsDBCChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@DBCid", SqlDbType.VarChar),
                                                new SqlParameter("@TenDBC", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["DBCid"].ToString();
                    thamso[1].Value = dr["TenDBC"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DBC_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

    }
}
