using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLUser
    {
        string _sUserID;

        public string SUserID
        {
            get { return _sUserID; }
            set { _sUserID = value; }
        }

        string _sUserName;

        public string SUserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }

        string _sPass;

        public string SPass
        {
            get { return _sPass; }
            set { _sPass = value; }
        }

        string _sNhomND;

        public string SNhomND
        {
            get { return _sNhomND; }
            set { _sNhomND = value; }
        }

        bool _bKhongSuDung;

        public bool BKhongSuDung
        {
            get { return _bKhongSuDung; }
            set { _bKhongSuDung = value; }
        }

        string _sNVID;

        public string SNVID
        {
            get { return _sNVID; }
            set { _sNVID = value; }
        }

        public CSQLUser() { }
        public CSQLUser(string mauserid, string username, string pass, bool khongSuDung, string nvid)
        {
            _sUserID = mauserid;
            _sUserName = username;
            _sPass = pass;
            _bKhongSuDung = khongSuDung;
            _sNVID = nvid;
        }

        public int User_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("User_LayMaxCapNhat", null);
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
        public int User_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("User_LayMaxCapNhat", null);
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
        public int User_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("User_LayMaxThemMoi", null);
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
        public int User_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("User_LayMaxThemMoi", null);
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
        public DataTable User_LayDSUserChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("User_LayDSUserChuaCapNhatTaiNT", thamso);
        }
        public DataTable User_LayDSUserChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("User_LayDSUserChuaThemMoiTaiNT", thamso);
        }
        public void User_DongBoThemDanhMuc(DataTable _DSUserChuaThem)
        {
            if (_DSUserChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSUserChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@UserName", SqlDbType.VarChar),
                                                new SqlParameter("@Pass", SqlDbType.VarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@NVID", SqlDbType.VarChar),
                                                new SqlParameter("@NhomNDid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["UserID"].ToString();
                    thamso[1].Value = dr["UserName"].ToString();
                    thamso[2].Value = dr["Pass"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = dr["NVID"].ToString();
                    thamso[5].Value = dr["NhomNDid"].ToString();
                    thamso[6].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[7].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("User_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void User_DongBoSuaDanhMuc(DataTable _DSUserChuaCapNhat)
        {
            if (_DSUserChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSUserChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@UserName", SqlDbType.VarChar),
                                                new SqlParameter("@Pass", SqlDbType.VarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@NVID", SqlDbType.VarChar),
                                                new SqlParameter("@NhomNDid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["UserID"].ToString();
                    thamso[1].Value = dr["UserName"].ToString();
                    thamso[2].Value = dr["Pass"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = dr["NVID"].ToString();
                    thamso[5].Value = dr["NhomNDid"].ToString();
                    thamso[6].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[7].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("User_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public int SuaMatKhau(CSQLUser user_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@UserID", SqlDbType.VarChar),
                                        new SqlParameter("@Pass", SqlDbType.VarChar) };
            thamso[0].Value = user_.SUserID;
            thamso[1].Value = user_.SPass;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("User_SuaMatKhau", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable LayMatKhauTheoMa(string userID_)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = userID_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("User_LayMatKhauTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayHoTenNhanVienTheoMa(string userID_)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = userID_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("User_LoadHoTenNhanVien", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDSUserLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("User_LayDSUserLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ThemMoi(CSQLUser user_)
        {
            SqlParameter[] thamso = {  new SqlParameter("@UserName", SqlDbType.VarChar), 
                                         new SqlParameter("@Pass", SqlDbType.VarChar),
                                         new SqlParameter("@NVID", SqlDbType.VarChar), 
                                         new SqlParameter("@NhomNDid", SqlDbType.VarChar), 
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                         new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = user_.SUserName;
            thamso[1].Value = user_.SPass;
            thamso[2].Value = user_.SNVID;
            thamso[3].Value = user_.SNhomND;
            thamso[4].Value = user_.BKhongSuDung;
            thamso[5].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("User_ThemMoi", thamso, null);
                return thamso[5].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }
        public int SuaThongTin(CSQLUser user_)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@UserName", SqlDbType.VarChar), 
                                         new SqlParameter("@Pass", SqlDbType.VarChar),
                                         new SqlParameter("@NVID", SqlDbType.VarChar), 
                                         new SqlParameter("@NhomNDid", SqlDbType.VarChar), 
                                         new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            thamso[0].Value = user_.SUserID;
            thamso[1].Value = user_.SUserName;
            thamso[2].Value = user_.SPass;
            thamso[3].Value = user_.SNVID;
            thamso[4].Value = user_.SNhomND;
            thamso[5].Value = user_.BKhongSuDung;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("User_ChinhSua", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int TKXacNhan_ChungThuc(string tentaikhoan, string matkhau)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserName", SqlDbType.VarChar), 
                                        new SqlParameter("@Pass", SqlDbType.VarChar),
                                        new SqlParameter("@KQ", SqlDbType.Int)};
            thamso[0].Value = tentaikhoan;
            thamso[1].Value = matkhau;
            thamso[2].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.ThucThiTraVeKetQuaKieuInt("User_TKXacNhan_ChungThuc", thamso);
                if (thamso[2].Value != null && int.Parse(thamso[2].Value.ToString())> 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TKXacNhan_ChungThuc(string tentaikhoan, string matkhau, string formID)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserName", SqlDbType.VarChar), 
                                        new SqlParameter("@Pass", SqlDbType.VarChar),
                                        new SqlParameter("@KQ", SqlDbType.Int),
                                    new SqlParameter("@formID", SqlDbType.VarChar)};
            thamso[0].Value = tentaikhoan;
            thamso[1].Value = matkhau;
            thamso[2].Direction = ParameterDirection.Output;
            thamso[3].Value = formID;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.ThucThiTraVeKetQuaKieuInt("User_TKXacNhan_XacNhan", thamso);
                if (thamso[2].Value != null && int.Parse(thamso[2].Value.ToString())> 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid LayThongTinNhomND(string UserID)
        {
            SqlParameter[] thamso ={
                                        new SqlParameter("@UserID", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@NhomNDid", SqlDbType.UniqueIdentifier) 
                                   };
            thamso[0].Value = new Guid(UserID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("User_LayThongTinNhomND", thamso);

            return new Guid(thamso[1].Value.ToString());
        }

        public Guid LayNhomND()
        {
            SqlParameter[] thamso ={
                                        new SqlParameter("@NhomNDid", SqlDbType.UniqueIdentifier) 
                                   };
            thamso[0].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("User_LayNhomND", thamso);

            return new Guid(thamso[0].Value.ToString());
        }

        public int KiemTraTrungUser(string userdangnhap_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@MaNV", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);


                XemTC.Value = userdangnhap_;
                thamso[0] = XemTC;

                KQ.Direction = ParameterDirection.Output;
                thamso[1] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("User_KiemTraTrungUser", thamso);
                return int.Parse(thamso[1].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
    }
}
