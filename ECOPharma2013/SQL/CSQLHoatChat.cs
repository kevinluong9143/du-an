using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLHoatChat
    {
        string _sHCID;

        public string SHCID
        {
            get { return _sHCID; }
            set { _sHCID = value; }
        }
        string _sTenHC;

        public string STenHC
        {
            get { return _sTenHC; }
            set { _sTenHC = value; }
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

        public CSQLHoatChat() { }

        public CSQLHoatChat(string hcid, string tenHC, string ghichu, bool khongSuDung, DateTime lastUD, DateTime ngayTao, string userid)
        {
            SHCID = hcid;
            STenHC = tenHC;
            SGhiChu = ghichu;
            BKhongSuDung = khongSuDung;
            DLastUD = lastUD;
            DNgayTao = ngayTao;
            SUserID = userid;
        }
    
        public string ThemHoatChat(CSQLHoatChat hc)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter ("@HCID", SqlDbType.VarChar,50),
                                         new SqlParameter ("@TenHC", SqlDbType.NVarChar),
                                         new SqlParameter ("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter ("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter ("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter ("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter ("@UserID", SqlDbType.VarChar)};
                thamso[0].Direction = ParameterDirection.Output;
                thamso[1].Value = hc.STenHC;
                thamso[2].Value = hc.SGhiChu;
                thamso[3].Value = hc.BKhongSuDung;
                thamso[4].Value = hc.DLastUD;
                thamso[5].Value = hc.DLastUD;
                thamso[6].Value = hc.SUserID;

                CDuLieu qldl = new CDuLieu();
                qldl.InsertDuLieu("HoatChat_ThemHoatChat", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
        public int SuaHoatChat(CSQLHoatChat hc)
        {
            try {
                SqlParameter[] thamso = { new SqlParameter ("@HCID", SqlDbType.VarChar),
                                         new SqlParameter ("@TenHC", SqlDbType.NVarChar),
                                         new SqlParameter ("@GhiChu", SqlDbType.NVarChar),
                                         new SqlParameter ("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter ("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter ("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter ("@UserID", SqlDbType.VarChar)};
                thamso[0].Value = hc.SHCID;
                thamso[1].Value = hc.STenHC;
                thamso[2].Value = hc.SGhiChu;
                thamso[3].Value = hc.BKhongSuDung;
                thamso[4].Value = hc.DLastUD;
                thamso[5].Value = hc.DLastUD;
                thamso[6].Value = hc.SUserID;
                CDuLieu qldl = new CDuLieu();
                return qldl.ThucThiTraVeKetQuaKieuInt("HoatChat_SuaHoatChat", thamso);
            }
            catch (Exception ex) { throw ex; }
        }
        public int XoaHoatChat(string hcid) 
        {
            try
            {
                CDuLieu qldl = new CDuLieu();
                SqlParameter[] thamso = { new SqlParameter("@HCID", SqlDbType.VarChar) };
                thamso[0].Value = hcid;
                return qldl.ThucThiTraVeKetQuaKieuInt("HoatChat_Xoa", thamso);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable LayHoatChatLenLuoi(bool XemTatCa_)
        {
            try
            {
                CDuLieu qldl = new CDuLieu();
                SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
                thamso[0].Value = XemTatCa_;
                return qldl.LoadTable("HoatChat_LayHoatChatLenLuoi", thamso);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable LayHoatChatTheoMa(string hcid)
        {
            try
            {
                CDuLieu qldl = new CDuLieu();
                SqlParameter[] thamso = { new SqlParameter("@HCID", SqlDbType.VarChar) };
                thamso[0].Value = hcid;
                return qldl.LoadTable("HoatChat_LayHoatChatTheoMa", thamso);
            }
            catch (Exception ex) { throw ex; }
        }

        public int HoatChat_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("HoatChat_LayMaxCapNhat", null);
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
        public int HoatChat_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("HoatChat_LayMaxCapNhat", null);
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
        public int HoatChat_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("HoatChat_LayMaxThemMoi", null);
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
        public int HoatChat_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("HoatChat_LayMaxThemMoi", null);
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
        public DataTable HoatChat_LayDSHoatChatChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("HoatChat_LayDSHoatChatChuaCapNhatTaiNT", thamso);
        }
        public DataTable HoatChat_LayDSHoatChatChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("HoatChat_LayDSHoatChatChuaThemMoiTaiNT", thamso);
        }
        public void HoatChat_DongBoThemDanhMuc(DataTable _DSHoatChatChuaThem)
        {
            if (_DSHoatChatChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSHoatChatChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@HCID", SqlDbType.VarChar),
                                                new SqlParameter("@TenHC", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["HCID"].ToString();
                    thamso[1].Value = dr["TenHC"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("HoatChat_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void HoatChat_DongBoSuaDanhMuc(DataTable _DSHoatChatChuaCapNhat)
        {
            if (_DSHoatChatChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSHoatChatChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@HCID", SqlDbType.VarChar),
                                                new SqlParameter("@TenHC", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["HCID"].ToString();
                    thamso[1].Value = dr["TenHC"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("HoatChat_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
