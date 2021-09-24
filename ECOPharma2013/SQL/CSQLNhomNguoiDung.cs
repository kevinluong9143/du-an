using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhomNguoiDung
    {
        private string NhomNDid;

        public string sNhomNDid
        {
            get { return NhomNDid; }
            set { NhomNDid = value; }
        }
        private string TenNhom;

        public string sTenNhom
        {
            get { return TenNhom; }
            set { TenNhom = value; }
        }
        private bool IsKhongDung;

        public bool bIsKhongDung
        {
            get { return IsKhongDung; }
            set { IsKhongDung = value; }
        }
        private string GhiChu;

        public string sGhiChu
        {
            get { return GhiChu; }
            set { GhiChu = value; }
        }

        public DataTable LayDSNhomNguoiDungLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhomNguoiDung_LayDSNhomNguoiDungLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayNhomNguoiDungTheoMa(string qgID)
        {
            CSQLQuan quan = new CSQLQuan();
            SqlParameter[] thamso = { new SqlParameter("@NhomNDid", SqlDbType.VarChar) };
            thamso[0].Value = qgID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhomNguoiDung_LayNhomNguoiDungTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDSNhomNguoiDungLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@FalseHoatDong", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("NhomNguoiDung_LoadDSNhomLenCombobox", thamsoinput);
        }

        public string LuuNhomND(CSQLNhomNguoiDung objNhomND)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@TenNhom", SqlDbType.NVarChar, 200), 
                                             new SqlParameter("@Note", SqlDbType.NText), 
                                             new SqlParameter("@IsKhongDung", SqlDbType.Bit) };
            thamsoinput[0].Value = objNhomND.sTenNhom;
            thamsoinput[1].Value = objNhomND.sGhiChu;
            thamsoinput[2].Value = objNhomND.bIsKhongDung;

            SqlParameter NhomNDidfromTable = new SqlParameter("@MaNhomNDfrmTable", SqlDbType.VarChar, 50);
            return LopDL.CapNhatDuLieu("NhomNguoiDung_ThemMoi", thamsoinput, NhomNDidfromTable);
        }

        public int SuaThongTinNhomNguoiDung(CSQLNhomNguoiDung nhomnd_)
        {
            SqlParameter[] thamso = { new SqlParameter("@NhomNDid", SqlDbType.VarChar), 
                                         new SqlParameter("@TenNhom", SqlDbType.NVarChar), 
                                         new SqlParameter("@GhiChu", SqlDbType.NText), 
                                         new SqlParameter("@IsKhongDung", SqlDbType.Bit) };
            //tham số mới để chỉnh sửa
            thamso[0].Value = nhomnd_.sNhomNDid;
            thamso[1].Value = nhomnd_.sTenNhom;
            thamso[2].Value = nhomnd_.sGhiChu;
            thamso[3].Value = nhomnd_.bIsKhongDung;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhomNguoiDung_SuaThongTinNhomNguoiDung", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int NhomNguoiDung_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhomNguoiDung_LayMaxCapNhat", null);
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
        public int NhomNguoiDung_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhomNguoiDung_LayMaxCapNhat", null);
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
        public int NhomNguoiDung_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NhomNguoiDung_LayMaxThemMoi", null);
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
        public int NhomNguoiDung_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NhomNguoiDung_LayMaxThemMoi", null);
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
        public DataTable NhomNguoiDung_LayDSNhomNguoiDungChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhomNguoiDung_LayDSNhomNguoiDungChuaCapNhatTaiNT", thamso);
        }
        public DataTable NhomNguoiDung_LayDSNhomNguoiDungChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NhomNguoiDung_LayDSNhomNguoiDungChuaThemMoiTaiNT", thamso);
        }
        public void NhomNguoiDung_DongBoThemDanhMuc(DataTable _DSNhomNguoiDungChuaThem)
        {
            if (_DSNhomNguoiDungChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhomNguoiDungChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NhomNDID", SqlDbType.VarChar),
                                                new SqlParameter("@TenNhom", SqlDbType.NVarChar, 200),
                                                new SqlParameter("@IsKhongDung", SqlDbType.Bit),
                                                new SqlParameter("@GHICHU", SqlDbType.NVarChar, 500),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int)
                                            };
                    thamso[0].Value = dr["NhomNDID"].ToString();
                    thamso[1].Value = dr["TenNhom"].ToString();
                    thamso[2].Value = bool.Parse(dr["IsKhongDung"].ToString());
                    thamso[3].Value = dr["GHICHU"].ToString();
                    thamso[4].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxCapNhat"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhomNguoiDung_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void NhomNguoiDung_DongBoSuaDanhMuc(DataTable _DSNhomNguoiDungChuaCapNhat)
        {
            if (_DSNhomNguoiDungChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSNhomNguoiDungChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NhomNDID", SqlDbType.VarChar),
                                                new SqlParameter("@TenNhom", SqlDbType.NVarChar, 200),
                                                new SqlParameter("@IsKhongDung", SqlDbType.Bit),
                                                new SqlParameter("@GHICHU", SqlDbType.NVarChar, 500),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int)
                                            };
                    thamso[0].Value = dr["NhomNDID"].ToString();
                    thamso[1].Value = dr["TenNhom"].ToString();
                    thamso[2].Value = bool.Parse(dr["IsKhongDung"].ToString());
                    thamso[3].Value = dr["GHICHU"].ToString();
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NhomNguoiDung_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
