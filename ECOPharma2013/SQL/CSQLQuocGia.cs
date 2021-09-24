using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLQuocGia
    {
        string _sMaQuocGia;

        public string SMaQuocGia
        {
            get { return _sMaQuocGia; }
            set { _sMaQuocGia = value; }
        }

        string _sTenQuocGia;

        public string STenQuocGia
        {
            get { return _sTenQuocGia; }
            set { _sTenQuocGia = value; }
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

         public CSQLQuocGia() { }
         public CSQLQuocGia(string maqg, string tenqg, string ghiChu, bool khongSuDung)
        {
            SMaQuocGia = maqg;
            STenQuocGia = tenqg;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
        }

         public DataTable LayDSQuocGiaLenLuoi(bool xemTatCa)
         {
             try
             {
                 SqlParameter[] thamso = new SqlParameter[1];
                 SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                 XemTC.Value = xemTatCa;
                 thamso[0] = XemTC;
                 CDuLieu dl = new CDuLieu();
                 DataTable dtb = dl.LoadTable("QuocGia_LoadDSQuocGiaLenLuoi", thamso);
                 return dtb;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public string ThemMoiQuocGia(CSQLQuocGia quocgia_)
         {
             SqlParameter[] thamso = { new SqlParameter("@TenQuocGia", SqlDbType.NVarChar), 
                                         new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                         new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
             thamso[0].Value = quocgia_.STenQuocGia;
             thamso[1].Value = quocgia_.SGhiChu;
             thamso[2].Value = quocgia_.BKhongSuDung;
             thamso[3].Direction = ParameterDirection.Output;
             CDuLieu dl = new CDuLieu();
             try
             {
                 dl.InsertDuLieu("QuocGia_ThemMoiQuocGia", thamso, null);
                 return thamso[3].Value.ToString();
             }
             catch (Exception Exception) { throw Exception; }
         }
         public int SuaThongTinQuocGia(CSQLQuocGia quocgia_)
         {
             SqlParameter[] thamso = { new SqlParameter("@QGID", SqlDbType.VarChar), 
                                         new SqlParameter("@TenQuocGia", SqlDbType.NVarChar), 
                                         new SqlParameter("@GhiChu", SqlDbType.NText), 
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
             //tham số mới để chỉnh sửa
             thamso[0].Value = quocgia_._sMaQuocGia;
             thamso[1].Value = quocgia_._sTenQuocGia;
             thamso[2].Value = quocgia_._sGhiChu;
             thamso[3].Value = quocgia_._bKhongSuDung;
             CDuLieu dl = new CDuLieu();
             try
             {
                 int kq = dl.ThucThiTraVeKetQuaKieuInt("QuocGia_ChinhSuaThongTinQuocGia", thamso);
                 return kq;
             }
             catch (Exception ex)
             {
                 return -1;
                 throw ex;
             }
         }
         public int XoaThongTinQuocGia(string _maQuocGia)
         {
             SqlParameter[] thamso = { new SqlParameter("@QGID", SqlDbType.VarChar) };
             thamso[0].Value = _maQuocGia;
             CDuLieu dl = new CDuLieu();
             try
             {
                 int kq = dl.ThucThiTraVeKetQuaKieuInt("QuocGia_XoaThongTinQuocGia", thamso);
                 return kq;
             }
             catch (Exception ex)
             {
                 return -1;
                 throw ex;
             }
         }
         public DataTable LayQuocGiaTheoMa(string qgID)
         {
             SqlParameter[] thamso = { new SqlParameter("@QGID", SqlDbType.VarChar) };
             thamso[0].Value = qgID;
             CDuLieu dl = new CDuLieu();
             try
             {
                 DataTable dtb = dl.LoadTable("QuocGia_LayQuocGiaTheoMa", thamso);
                 return dtb;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public int QuocGia_LayMaxCapNhatNT()
         {
             CDuLieu dl = new CDuLieu();
             DataTable dtb = dl.LoadTable("QuocGia_LayMaxCapNhat", null);
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
         public int QuocGia_LayMaxCapNhatECO()
         {
             CDuLieuRemote dl = new CDuLieuRemote();
             DataTable dtb = dl.LoadTable("QuocGia_LayMaxCapNhat", null);
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
         public int QuocGia_LayMaxThemMoiNT()
         {
             CDuLieu dl = new CDuLieu();
             DataTable dtb = dl.LoadTable("QuocGia_LayMaxThemMoi", null);
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
         public int QuocGia_LayMaxThemMoiECO()
         {
             CDuLieuRemote dl = new CDuLieuRemote();
             DataTable dtb = dl.LoadTable("QuocGia_LayMaxThemMoi", null);
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
         public DataTable QuocGia_LayDSQuocGiaChuaCapNhatTaiNT(int maxCapNhatNT)
         {
             SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
             thamso[0].Value = maxCapNhatNT;
             CDuLieuRemote dl = new CDuLieuRemote();
             return dl.LoadTable("QuocGia_LayDSQuocGiaChuaCapNhatTaiNT", thamso);
         }
         public DataTable QuocGia_LayDSQuocGiaChuaThemMoiTaiNT(int maxThemMoiNT)
         {
             SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
             thamso[0].Value = maxThemMoiNT;
             CDuLieuRemote dl = new CDuLieuRemote();
             return dl.LoadTable("QuocGia_LayDSQuocGiaChuaThemMoiTaiNT", thamso);
         }
         public void QuocGia_DongBoThemDanhMuc(DataTable _DSQuocGiaChuaThem)
         {
             if (_DSQuocGiaChuaThem.Rows.Count > 0)
             {
                 foreach (DataRow dr in _DSQuocGiaChuaThem.Rows)
                 {
                     SqlParameter[] thamso = { new SqlParameter("@QGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenQuocGia", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                     thamso[0].Value = dr["QGID"].ToString();
                     thamso[1].Value = dr["TenQuocGia"].ToString();
                     thamso[2].Value = dr["GhiChu"].ToString();
                     thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                     thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                     thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                     thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());

                     CDuLieu dl = new CDuLieu();
                     dl.InsertDuLieu("QuocGia_DongBoThemDanhMuc", thamso, null);
                 }
             }
         }

         public void QuocGia_DongBoSuaDanhMuc(DataTable _DSQuocGiaChuaCapNhat)
         {
             if (_DSQuocGiaChuaCapNhat.Rows.Count > 0)
             {
                 foreach (DataRow dr in _DSQuocGiaChuaCapNhat.Rows)
                 {
                     SqlParameter[] thamso = { new SqlParameter("@QGID", SqlDbType.VarChar),
                                                new SqlParameter("@TenQuocGia", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                     thamso[0].Value = dr["QGID"].ToString();
                     thamso[1].Value = dr["TenQuocGia"].ToString();
                     thamso[2].Value = dr["GhiChu"].ToString();
                     thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                     thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                     thamso[5].Value = bool.Parse(dr["IsXoa"].ToString());

                     CDuLieu dl = new CDuLieu();
                     dl.InsertDuLieu("QuocGia_DongBoSuaDanhMuc", thamso, null);
                 }
             }
         }
    }
}
