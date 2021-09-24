using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLQuan
    {
        string _sMaQuan;

        public string SMaQuan
        {
            get { return _sMaQuan; }
            set { _sMaQuan = value; }
        }
        string _sTenQuan;

        public string STenQuan
        {
            get { return _sTenQuan; }
            set { _sTenQuan = value; }
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

        public CSQLQuan() { }
        public CSQLQuan(string maBoPhan, string tenBoPhan, string ghiChu, bool khongSuDung)
        {
            SMaQuan = maBoPhan;
            STenQuan= tenBoPhan;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
        }

        public DataTable LayDanhSachQuanLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("Quan_LoadQuanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CSQLQuan LayCSDLQuanTheoMa(string quanID)
        {
            CSQLQuan quan = new CSQLQuan();
            SqlParameter[] thamso = { new SqlParameter("QuanID", SqlDbType.UniqueIdentifier) };
            thamso[0].Value = quanID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("Quan_LayQuanTheoMa", thamso);
                if (dtb.Rows.Count > 0)
                {
                    quan.SMaQuan = dtb.Rows[0]["QuanID"].ToString();
                    quan.SMaQuan = dtb.Rows[0]["TenQ"].ToString();
                    quan.SGhiChu = dtb.Rows[0]["GhiChu"].ToString();
                    quan.BKhongSuDung = (bool)dtb.Rows[0]["KhongSuDung"];
                }
                return quan;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public DataTable LayQuanTheoMa(string quanID)
        {
            CSQLQuan quan = new CSQLQuan();
            SqlParameter[] thamso = { new SqlParameter("@QuanID", SqlDbType.VarChar) };
            thamso[0].Value = quanID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("Quan_LayQuanTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ThemMoiQuan(CSQLQuan quan_)
        {
            SqlParameter [] thamso = {new SqlParameter("@TenQ", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NVarChar), new SqlParameter("@KhongSuDung", SqlDbType.Bit),new SqlParameter("@KetQua",SqlDbType.VarChar,50)};
            thamso[0].Value = quan_.STenQuan;
            thamso[1].Value = quan_.SGhiChu;
            thamso[2].Value = quan_.BKhongSuDung;

            thamso[3].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try {
                dl.InsertDuLieu("Quan_ThemMoiQuan", thamso, null);
                return thamso[3].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }
        public int SuaThongTinQuan(CSQLQuan quan_)
        {
            SqlParameter[] thamso = { new SqlParameter("@QuanID", SqlDbType.VarChar), new SqlParameter("@TenQ", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            //tham số mới để chỉnh sửa
            thamso[0].Value = quan_._sMaQuan;
            thamso[1].Value = quan_._sTenQuan;
            thamso[2].Value = quan_._sGhiChu;
            thamso[3].Value = quan_._bKhongSuDung;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("Quan_ChinhSuaThongTinQuan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public int XoaThongTinQuan(string _maQuan)
        {
            SqlParameter[] thamso = { new SqlParameter("@QuanID", SqlDbType.VarChar) };
            thamso[0].Value = _maQuan;
            CDuLieu dl = new CDuLieu();
            try 
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("Quan_XoaThongTinQuan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

        }

        public int Quan_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("Quan_LayMaxCapNhat", null);
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
        public int Quan_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("Quan_LayMaxCapNhat", null);
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
        public int Quan_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("Quan_LayMaxThemMoi", null);
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
        public int Quan_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("Quan_LayMaxThemMoi", null);
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
        public DataTable Quan_LayDSQuanChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("Quan_LayDSQuanChuaCapNhatTaiNT", thamso);
        }
        public DataTable Quan_LayDSQuanChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("Quan_LayDSQuanChuaThemMoiTaiNT", thamso);
        }
        public void Quan_DongBoThemDanhMuc(DataTable _DSQuanChuaThem)
        {
            if (_DSQuanChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSQuanChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TenQ", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["QuanID"].ToString();
                    thamso[1].Value = dr["TenQ"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("Quan_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void Quan_DongBoSuaDanhMuc(DataTable _DSQuanChuaCapNhat)
        {
            if (_DSQuanChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSQuanChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TenQ", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["QuanID"].ToString();
                    thamso[1].Value = dr["TenQ"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("Quan_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
