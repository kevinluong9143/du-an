using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLSanPham_NPP
    {
        string _sMaSPNPP;

        public string SMaSPNPP
        {
            get { return _sMaSPNPP; }
            set { _sMaSPNPP = value; }
        }

        string _sSPid;

        public string SSPid
        {
            get { return _sSPid; }
            set { _sSPid = value; }
        }

        string _sNSXid;

        public string SNSXid
        {
            get { return _sNSXid; }
            set { _sNSXid = value; }
        }

        string _sNPPid;

        public string SNPPid
        {
          get { return _sNPPid; }
          set { _sNPPid = value; }
        }
        
        string _sGhiChu1;

        public string SGhiChu1
        {
            get { return _sGhiChu1; }
            set { _sGhiChu1 = value; }
        }
        string _sGhiChu2;

        public string SGhiChu2
        {
          get { return _sGhiChu2; }
          set { _sGhiChu2 = value; }
        }

        string _sGhiChu3;

        public string SGhiChu3
        {
            get { return _sGhiChu3; }
            set { _sGhiChu3 = value; }
        }

        bool _bMacDinh;

        public bool BMacDinh
        {
            get { return _bMacDinh; }
            set { _bMacDinh = value; }
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
        public CSQLSanPham_NPP() { }
        public CSQLSanPham_NPP(string maspnpp, string spid, string nsxid, string nppid, string ghiChu1, string ghiChu2, string ghiChu3, bool macdinh, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid)
        {
            SMaSPNPP = maspnpp;
            SSPid = spid;
            SNSXid = nsxid;
            SNPPid = nppid;
            SGhiChu1 = ghiChu1;
            SGhiChu2 = ghiChu2;
            SGhiChu3 = ghiChu3; ;
            BMacDinh = macdinh;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SUserID = userid;
        }
        public DataTable LayDanhSachSanPham_NPPLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("SP_NPP_LoadSanPham_NPPLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public string ThemMoiSanPham_NPP(CSQLSanPham_NPP sanpham_npp_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NPPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu1", SqlDbType.NVarChar), 
                                        new SqlParameter("@GhiChu2", SqlDbType.NVarChar),
                                        new SqlParameter("@GhiChu3", SqlDbType.NVarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = sanpham_npp_.SSPid;
            thamso[1].Value = sanpham_npp_.SNPPid;
            thamso[2].Value = sanpham_npp_.SNSXid;
            thamso[3].Value = sanpham_npp_.SGhiChu1;
            thamso[4].Value = sanpham_npp_.SGhiChu2;
            thamso[5].Value = sanpham_npp_.SGhiChu3;
            thamso[6].Value = sanpham_npp_.BMacDinh;
            thamso[7].Value = sanpham_npp_.BKhongSuDung;
            thamso[8].Value = sanpham_npp_.DLastUD;
            thamso[9].Value = sanpham_npp_.DNgayTao;
            thamso[10].Value = sanpham_npp_.SUserID;
            thamso[11].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("SP_NPP_ThemMoiSanPham_NPP", thamso, null);
                return thamso[11].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }
        public int SuaThongTinSanPham_NPP(CSQLSanPham_NPP sanpham_npp_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPNPPid", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NPPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu1", SqlDbType.NVarChar), 
                                        new SqlParameter("@GhiChu2", SqlDbType.NVarChar),
                                        new SqlParameter("@GhiChu3", SqlDbType.NVarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = sanpham_npp_.SMaSPNPP;
            thamso[1].Value = sanpham_npp_.SSPid;
            thamso[2].Value = sanpham_npp_.SNPPid;
            thamso[3].Value = sanpham_npp_.SNSXid;
            thamso[4].Value = sanpham_npp_.SGhiChu1;
            thamso[5].Value = sanpham_npp_.SGhiChu2;
            thamso[6].Value = sanpham_npp_.SGhiChu3;
            thamso[7].Value = sanpham_npp_.BMacDinh;
            thamso[8].Value = sanpham_npp_.BKhongSuDung;
            thamso[9].Value = sanpham_npp_.DLastUD;
            thamso[10].Value = sanpham_npp_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_NPP_ChinhSuaThongTinSP_NPP", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable LaySP_NPPTheoSPID_CoMacDinh(string spid, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spid;
            thamso[1].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NPP_LaySP_NPPTheoSPID_CoMacDinh", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LaySP_NPPTheoSPID_NSXID_NPPID(string spid, string nsxid, string nppid, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@NPPid", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = nppid;
            thamso[3].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NPP_LaySP_NPPTheoSPID_NSXID_NPPID", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LaySP_NPPTheoSPID_NSXID(string spid, string nsxid, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            thamso[2].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NPP_LaySP_NPPTheoSPID_NSXID", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LaySP_NPPTheoSPID_NSXID_KhacSPNPPid(string spnppid, string spid, string nsxid, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPNPPid", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spnppid;
            thamso[1].Value = spid;
            thamso[2].Value = nsxid;
            thamso[3].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NPP_LaySP_NPPTheoSPID_NSXID_KhacSPNPPid", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SuaMacDinhSP_NPP(CSQLSanPham_NPP sp_npp_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPNPPid", SqlDbType.VarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = sp_npp_._sMaSPNPP;
            thamso[1].Value = sp_npp_.BMacDinh;
            thamso[2].Value = sp_npp_.DLastUD;
            thamso[3].Value = sp_npp_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_NPP_SuaMacDinhSP_NPP", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable LaySanPham_NPPTheoMa(string SPNPPID)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPNPPid", SqlDbType.VarChar) };
            thamso[0].Value = SPNPPID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NPP_LaySP_NPPTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
