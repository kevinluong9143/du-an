using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSDLQuan
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

        public CSDLQuan() { }
        public CSDLQuan(string maBoPhan, string tenBoPhan, string ghiChu, bool khongSuDung)
        {
            SMaQuan = maBoPhan;
            SMaQuan = tenBoPhan;
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
                return null;
            }
        }

        public CSDLQuan LayCSDLQuanTheoMa(string quanID)
        {
            CSDLQuan quan = new CSDLQuan();
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
            CSDLQuan quan = new CSDLQuan();
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
        public string ThemMoiQuan(CSDLQuan quan_)
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
        public int SuaThongTinQuan(CSDLQuan quan_)
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
    }
}
