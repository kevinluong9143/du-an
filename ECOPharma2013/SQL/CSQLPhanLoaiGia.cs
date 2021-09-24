using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLPhanLoaiGia
    {
        string _sMaLG;

        public string SMaLG
        {
          get { return _sMaLG; }
          set { _sMaLG = value; }
        }

        string _sTenLG;

        public string STenLG
        {
          get { return _sTenLG; }
          set { _sTenLG = value; }
        }

        decimal _dMarkUp;

        public decimal DMarkUp
        {
          get { return _dMarkUp; }
          set { _dMarkUp = value; }
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

        public CSQLPhanLoaiGia() { }
        public CSQLPhanLoaiGia(string maLG, string tenLG, decimal markup, string ghiChu, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid)
        {
            SMaLG = maLG;
            STenLG = tenLG;
            DMarkUp = markup;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SuserID = userid;
        }
        public DataTable LayDanhSachPhanloaiGiaLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("PhanloaiGia_LoadPhanloaiGiaLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ThemMoiPhanloaiGia(CSQLPhanLoaiGia phanloaigia_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenLG", SqlDbType.NVarChar), new SqlParameter("@MarkUp", SqlDbType.Decimal), new SqlParameter("@GhiChu", SqlDbType.NVarChar), new SqlParameter("@KhongSuDung", SqlDbType.Bit), new SqlParameter("@LastUD", SqlDbType.DateTime), new SqlParameter("@NgayTao", SqlDbType.DateTime), new SqlParameter("@UserID", SqlDbType.VarChar), new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = phanloaigia_.STenLG;
            thamso[1].Value = phanloaigia_.DMarkUp;
            thamso[2].Value = phanloaigia_.SGhiChu;
            thamso[3].Value = phanloaigia_.BKhongSuDung;
            thamso[4].Value = phanloaigia_.DLastUD;
            thamso[5].Value = phanloaigia_.DNgayTao;
            thamso[6].Value = phanloaigia_.SuserID;

            thamso[7].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("PhanloaiGia_ThemMoiPhanloaiGia", thamso, null);
                return thamso[7].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public DataTable LayPhanloaiGiaTheoMa(string LGID)
        {
            CSQLPhanLoaiGia phanloaigia = new CSQLPhanLoaiGia();
            SqlParameter[] thamso = { new SqlParameter("@LGID", SqlDbType.VarChar) };
            thamso[0].Value = LGID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("PhanloaiGia_LayPhanloaiGiaTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinPhanloaiGia(CSQLPhanLoaiGia phanloaigia_)
        {
            SqlParameter[] thamso = { new SqlParameter("@LGID", SqlDbType.VarChar), 
                                        new SqlParameter("@TenLG", SqlDbType.NVarChar), 
                                        new SqlParameter("@MarkUp", SqlDbType.Decimal), 
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            //tham số mới để chỉnh sửa
            thamso[0].Value = phanloaigia_.SMaLG;
            thamso[1].Value = phanloaigia_.STenLG;
            thamso[2].Value = phanloaigia_.DMarkUp;
            thamso[3].Value = phanloaigia_.SGhiChu;
            thamso[4].Value = phanloaigia_.BKhongSuDung;
            thamso[5].Value = phanloaigia_.DLastUD;
            thamso[6].Value = phanloaigia_.DNgayTao;
            thamso[7].Value = phanloaigia_.SuserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("PhanloaiGia_ChinhSuaThongTinPhanloaiGia", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinPhanloaiGia(string _maLG)
        {
            SqlParameter[] thamso = { new SqlParameter("@LGID", SqlDbType.VarChar) };
            thamso[0].Value = _maLG;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("PhanloaiGia_XoaThongTinPhanloaiGia", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

        }
        public int PhanloaiGia_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhanloaiGia_LayMaxCapNhat", null);
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
        public int PhanloaiGia_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("PhanloaiGia_LayMaxCapNhat", null);
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
        public int PhanloaiGia_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhanloaiGia_LayMaxThemMoi", null);
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
        public int PhanloaiGia_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("PhanloaiGia_LayMaxThemMoi", null);
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
        public DataTable PhanloaiGia_LayDSPhanloaiGiaChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("PhanloaiGia_LayDSPhanloaiGiaChuaCapNhatTaiNT", thamso);
        }
        public DataTable PhanloaiGia_LayDSPhanloaiGiaChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("PhanloaiGia_LayDSPhanloaiGiaChuaThemMoiTaiNT", thamso);
        }
        public void PhanloaiGia_DongBoThemDanhMuc(DataTable _DSPhanloaiGiaChuaThem)
        {
            if (_DSPhanloaiGiaChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSPhanloaiGiaChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@LGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenLG", SqlDbType.NVarChar),
                                                new SqlParameter("@MarkUp", SqlDbType.Decimal), 
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["LGID"].ToString();
                    thamso[1].Value = dr["TenLG"].ToString();
                    thamso[2].Value = decimal.Parse(dr["MarkUp"].ToString());
                    thamso[3].Value = dr["GhiChu"].ToString();
                    thamso[4].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[6].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[7].Value = CStaticBien.SmaTaiKhoan;
                    thamso[8].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[9].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[10].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("PhanloaiGia_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void PhanloaiGia_DongBoSuaDanhMuc(DataTable _DSPhanloaiGiaChuaCapNhat)
        {
            if (_DSPhanloaiGiaChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSPhanloaiGiaChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@LGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenLG", SqlDbType.NVarChar),
                                                new SqlParameter("@MarkUp", SqlDbType.Decimal), 
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["LGID"].ToString();
                    thamso[1].Value = dr["TenLG"].ToString();
                    thamso[2].Value = decimal.Parse(dr["MarkUp"].ToString());
                    thamso[3].Value = dr["GhiChu"].ToString();
                    thamso[4].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[6].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[7].Value = CStaticBien.SmaTaiKhoan;
                    thamso[8].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("PhanloaiGia_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
