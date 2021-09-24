using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLGiamGia
    {
        string _sMaGG;

        public string SMaGG
        {
            get { return _sMaGG; }
            set { _sMaGG = value; }
        }

        string _sTenGG;

        public string STenGG
        {
            get { return _sTenGG; }
            set { _sTenGG = value; }
        }

        decimal _dMucGiam;

        public decimal DMucGiam
        {
            get { return _dMucGiam; }
            set { _dMucGiam = value; }
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

        public string SuserID
        {
            get { return _suserID; }
            set { _suserID = value; }
        }

        public CSQLGiamGia() { }
        public CSQLGiamGia(string maGG, string tenGG, decimal mucgiam, string ghiChu, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid)
        {
            SMaGG = maGG;
            STenGG = tenGG;
            DMucGiam = mucgiam;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SuserID = userid;
        }
        public DataTable LayDanhSachGiamGiaLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("GiamGia_LoadGiamGiaLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ThemMoiGiamGia(CSQLGiamGia giamgia_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenGG", SqlDbType.NVarChar),
                                        new SqlParameter("@MucGiam", SqlDbType.Decimal), 
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = giamgia_.STenGG;
            thamso[1].Value = giamgia_.DMucGiam;
            thamso[2].Value = giamgia_.SGhiChu;
            thamso[3].Value = giamgia_.BKhongSuDung;
            thamso[4].Value = giamgia_.DLastUD;
            thamso[5].Value = giamgia_.DNgayTao;
            thamso[6].Value = giamgia_.SuserID;

            thamso[7].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("GiamGia_ThemMoiGiamGia", thamso, null);
                return thamso[7].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public DataTable LayGiamGiaTheoMa(string GGID)
        {
            CSQLGiamGia giamgia = new CSQLGiamGia();
            SqlParameter[] thamso = { new SqlParameter("@GGID", SqlDbType.VarChar) };
            thamso[0].Value = GGID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("GiamGia_LayGiamGiaTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinGiamGia(CSQLGiamGia giamgia_)
        {
            SqlParameter[] thamso = { new SqlParameter("@GGID", SqlDbType.VarChar), new SqlParameter("@TenGG", SqlDbType.NVarChar), new SqlParameter("@MucGiam", SqlDbType.Decimal), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@KhongSuDung", SqlDbType.Bit), new SqlParameter("@LastUD", SqlDbType.DateTime), new SqlParameter("@NgayTao", SqlDbType.DateTime), new SqlParameter("@UserID", SqlDbType.VarChar) };
            //tham số mới để chỉnh sửa
            thamso[0].Value = giamgia_.SMaGG;
            thamso[1].Value = giamgia_.STenGG;
            thamso[2].Value = giamgia_.DMucGiam;
            thamso[3].Value = giamgia_.SGhiChu;
            thamso[4].Value = giamgia_.BKhongSuDung;
            thamso[5].Value = giamgia_.DLastUD;
            thamso[6].Value = giamgia_.DNgayTao;
            thamso[7].Value = giamgia_.SuserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("GiamGia_ChinhSuaThongTinGiamGia", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinGiamGia(string _maGG)
        {
            SqlParameter[] thamso = { new SqlParameter("@GGID", SqlDbType.VarChar) };
            thamso[0].Value = _maGG;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("GiamGia_XoaThongTinGiamGia", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int GiamGia_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("GiamGia_LayMaxCapNhat", null);
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
        public int GiamGia_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("GiamGia_LayMaxCapNhat", null);
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
        public int GiamGia_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("GiamGia_LayMaxThemMoi", null);
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
        public int GiamGia_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("GiamGia_LayMaxThemMoi", null);
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
        public DataTable GiamGia_LayDSGiamGiaChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("GiamGia_LayDSGiamGiaChuaCapNhatTaiNT", thamso);
        }
        public DataTable GiamGia_LayDSGiamGiaChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("GiamGia_LayDSGiamGiaChuaThemMoiTaiNT", thamso);
        }
        public void GiamGia_DongBoThemDanhMuc(DataTable _DSGiamGiaChuaThem)
        {
            if (_DSGiamGiaChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSGiamGiaChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@GGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenGG", SqlDbType.NVarChar),
                                                new SqlParameter("@MucGiam", SqlDbType.Decimal), 
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["GGID"].ToString();
                    thamso[1].Value = dr["TenGG"].ToString();
                    thamso[2].Value = decimal.Parse(dr["MucGiam"].ToString());
                    thamso[3].Value = dr["GhiChu"].ToString();
                    thamso[4].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[6].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[7].Value = CStaticBien.SmaTaiKhoan;
                    thamso[8].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[9].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[10].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("GiamGia_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void GiamGia_DongBoSuaDanhMuc(DataTable _DSGiamGiaChuaCapNhat)
        {
            if (_DSGiamGiaChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSGiamGiaChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@GGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenGG", SqlDbType.NVarChar),
                                                new SqlParameter("@MucGiam", SqlDbType.Decimal), 
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["GGID"].ToString();
                    thamso[1].Value = dr["TenGG"].ToString();
                    thamso[2].Value = decimal.Parse(dr["MucGiam"].ToString());
                    thamso[3].Value = dr["GhiChu"].ToString();
                    thamso[4].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[6].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[7].Value = CStaticBien.SmaTaiKhoan;
                    thamso[8].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("GiamGia_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
