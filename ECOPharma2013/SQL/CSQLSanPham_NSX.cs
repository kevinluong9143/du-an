using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLSanPham_NSX
    {
        string _sMaSPNSX;

        public string SMaSPNSX
        {
            get { return _sMaSPNSX; }
            set { _sMaSPNSX = value; }
        }

        string _sMaSP;

        public string SMaSP
        {
            get { return _sMaSP; }
            set { _sMaSP = value; }
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
        
        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
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
        public CSQLSanPham_NSX() { }
        public CSQLSanPham_NSX(string maspnsx, string masp, string spid, string nsxid, string ghiChu, bool macdinh, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid)
        {
            SMaSPNSX = maspnsx;
            SMaSP = masp;
            SMaSPNSX = maspnsx;
            SSPid = spid;
            SNSXid = nsxid;
            SGhiChu = ghiChu;
            BMacDinh = macdinh;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SUserID = userid;
        }
        public DataTable LayDanhSachSanPham_NSXLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("SP_NSX_LoadSanPham_NSXLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public DataTable SP_NSX_LayDS_LenMultiColumnCombobox()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("SP_NSX_LayDS_LenMultiColumnCombobox", null);
        }

        public string ThemMoiSanPham_NSX(CSQLSanPham_NSX sanpham_nsx_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                        new SqlParameter("@MacDinh", SqlDbType.Bit),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = sanpham_nsx_.SMaSP;
            thamso[1].Value = sanpham_nsx_.SSPid;
            thamso[2].Value = sanpham_nsx_.SNSXid;
            thamso[3].Value = sanpham_nsx_.SGhiChu;
            thamso[4].Value = sanpham_nsx_.BMacDinh;
            thamso[5].Value = sanpham_nsx_.BKhongSuDung;
            thamso[6].Value = sanpham_nsx_.DLastUD;
            thamso[7].Value = sanpham_nsx_.DNgayTao;
            thamso[8].Value = sanpham_nsx_.SUserID;
            thamso[9].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("SP_NSX_ThemMoiSanPham_NSX", thamso, null);
                return thamso[9].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public int SuaThongTinSanPham_NSX(CSQLSanPham_NSX sanpham_nsx_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPNSXid", SqlDbType.VarChar),
                                        new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@MacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = sanpham_nsx_.SMaSPNSX;
            thamso[1].Value = sanpham_nsx_.SMaSP;
            thamso[2].Value = sanpham_nsx_.SSPid;
            thamso[3].Value = sanpham_nsx_.SNSXid;
            thamso[4].Value = sanpham_nsx_.SGhiChu;
            thamso[5].Value = sanpham_nsx_.BMacDinh;
            thamso[6].Value = sanpham_nsx_.BKhongSuDung;
            thamso[7].Value = sanpham_nsx_.DLastUD;
            thamso[8].Value = sanpham_nsx_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_NSX_ChinhSuaThongTinSP_NSX", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int SuaMacDinhSanPham_NSX(CSQLSanPham_NSX sanpham_nsx_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPNSXid", SqlDbType.VarChar),
                                        new SqlParameter("@MacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = sanpham_nsx_.SMaSPNSX;
            thamso[1].Value = sanpham_nsx_.BMacDinh;
            thamso[2].Value = sanpham_nsx_.DLastUD;
            thamso[3].Value = sanpham_nsx_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_NSX_SuaMacDinhSP_NSX", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        //co
        public DataTable LaySanPham_NSXTheoSPid(string SPid)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPid", SqlDbType.VarChar)};
            thamso[0].Value = SPid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NSX_LaySP_NSXTheoSPid", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //co
        public DataTable LaySanPham_NSXTheoMaSP_CoMacDinh(string masp, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@MaSP", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = masp;
            thamso[1].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NSX_LaySP_NSXTheoMaSP_CoMacDinh", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LaySanPham_NSXTheoSPID_CoMacDinh(string spid, bool xacnhan)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spid;
            thamso[1].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NSX_LaySP_NSXTheoSPID_CoMacDinh", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LaySanPham_NSXTheoMaSP_KhongMacDinh(string spnsxid_, string masp, bool xacnhan, bool kosd_)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPNSXid", SqlDbType.VarChar),
                                        new SqlParameter("@MaSP", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit),
                                      new SqlParameter("@KhongSuDung", SqlDbType.Bit)};
            thamso[0].Value = spnsxid_;
            thamso[1].Value = masp;
            thamso[2].Value = xacnhan;
            thamso[3].Value = kosd_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_NSX_LaySP_NSXTheoMaSP_KhongMacDinh", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayNSXVaoCBX(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("SanPham_NSX_LayNSXLenCBX", thamso);
        }
        ////////////
        public int KiemTraNSX(string masp_, string nsx_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter masp = new SqlParameter("@MaSP", SqlDbType.VarChar);
                SqlParameter nsx = new SqlParameter("@NSX", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);
                masp.Value = masp_;
                thamso[0] = masp;
                nsx.Value = nsx_;
                thamso[1] = nsx;
                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;
                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_NSX_KiemTraNSX", thamso);

                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public string LayNSXUuTienMacDinh(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SP_NSX_LayNSXMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return dtb.Rows[0][0].ToString();
                }
                catch { return null; }
            }
            else
                return null;
        }

        public string SP_NSX_LayNSXMacDinh(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_NSX_LayNSXMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return dtb.Rows[0][0].ToString();
                }
                catch { return null; }
            }
            else
                return null;
        }

        public int SanPham_NSX_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_NSX_LayMaxCapNhat", null);
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
        public int SanPham_NSX_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_NSX_LayMaxCapNhat", null);
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
        public int SanPham_NSX_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_NSX_LayMaxThemMoi", null);
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
        public int SanPham_NSX_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_NSX_LayMaxThemMoi", null);
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

        public DataTable SanPham_NSX_LayDSSanPham_NSXChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SanPham_NSX_LayDSSanPham_NSXChuaCapNhatTaiNT", thamso);
        }
        public DataTable SanPham_NSX_LayDSSanPham_NSXChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SanPham_NSX_LayDSSanPham_NSXChuaThemMoiTaiNT", thamso);
        }
        public void SanPham_NSX_DongBoThemDanhMuc(DataTable dsSanPham_NSXChuaThemMoi)
        {
            //@SPNSXid uniqueidentifier, @MaSP varchar(50), @SPID uniqueidentifier,@NSXID uniqueidentifier, @ghichu nvarchar(max), @MacDinh bit,@khongsudung bit,@lastud datetime, @ngaytao datetime, @userid uniqueidentifier, @maxcapnhat int
            if (dsSanPham_NSXChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham_NSXChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@SPNSXid", SqlDbType.VarChar),
                                                new SqlParameter("@MaSP", SqlDbType.VarChar),
                                                new SqlParameter("@SPID", SqlDbType.VarChar),
                                                new SqlParameter("@NSXID", SqlDbType.VarChar),
                                                new SqlParameter("@ghichu", SqlDbType.NVarChar),
                                                new SqlParameter("@MacDinh", SqlDbType.Bit),
                                                new SqlParameter("@khongsudung ", SqlDbType.Bit),
                                                new SqlParameter("@lastud", SqlDbType.DateTime),
                                                new SqlParameter("@ngaytao", SqlDbType.DateTime),
                                                new SqlParameter("@userid", SqlDbType.VarChar),
                                                new SqlParameter("@maxcapnhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["SPNSXid"].ToString();
                    thamso[1].Value = dr["MaSP"].ToString();
                    if (dr["SPID"].ToString() != null && dr["SPID"].ToString().Length > 0)
                        thamso[2].Value = dr["SPID"].ToString();
                    else
                        thamso[2].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["NSXID"].ToString() != null && dr["NSXID"].ToString().Length > 0)
                        thamso[3].Value = dr["NSXID"].ToString();
                    else
                        thamso[3].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[4].Value = dr["GhiChu"].ToString();
                    thamso[5].Value = bool.Parse(dr["MacDinh"].ToString());
                    thamso[6].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[7].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[8].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[9].Value = CStaticBien.SmaTaiKhoan;
                    thamso[10].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[11].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[12].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SanPham_NSX_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void SanPham_NSX_DongBoSuaDanhMuc(DataTable dsSanPham_NSXChuaCapNhat)
        {
            if (dsSanPham_NSXChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPham_NSXChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@SPNSXid", SqlDbType.VarChar),
                                                new SqlParameter("@MaSP", SqlDbType.VarChar),
                                                new SqlParameter("@SPID", SqlDbType.VarChar),
                                                new SqlParameter("@NSXID", SqlDbType.VarChar),
                                                new SqlParameter("@ghichu", SqlDbType.NVarChar),
                                                new SqlParameter("@MacDinh", SqlDbType.Bit),
                                                new SqlParameter("@khongsudung ", SqlDbType.Bit),
                                                new SqlParameter("@lastud", SqlDbType.DateTime),
                                                new SqlParameter("@ngaytao", SqlDbType.DateTime),
                                                new SqlParameter("@userid", SqlDbType.VarChar),
                                                new SqlParameter("@maxcapnhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["SPNSXid"].ToString();
                    thamso[1].Value = dr["MaSP"].ToString();
                    if (dr["SPID"].ToString() != null && dr["SPID"].ToString().Length > 0)
                        thamso[2].Value = dr["SPID"].ToString();
                    else
                        thamso[2].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["NSXID"].ToString() != null && dr["NSXID"].ToString().Length > 0)
                        thamso[3].Value = dr["NSXID"].ToString();
                    else
                        thamso[3].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[4].Value = dr["GhiChu"].ToString();
                    thamso[5].Value = bool.Parse(dr["MacDinh"].ToString());
                    thamso[6].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[7].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[8].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[9].Value = CStaticBien.SmaTaiKhoan;
                    thamso[10].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[11].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SanPham_NSX_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public string SanPham_NSX_LaySPNSXIDTheoSPID_NSXID(string spid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                      new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_NSX_LaySPNSXIDTheoSPID_NSXID", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }

        public int KiemTraPhatSinh(string tensp, string nsxid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@TenSP", SqlDbType.NVarChar),
                                      new SqlParameter("@NSXID", SqlDbType.VarChar)};
                thamso[0].Value = tensp;
                thamso[1].Value = nsxid;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("SanPham_NSX_KiemTraPhatSinh", thamso);
                if (dtb.Rows.Count > 0)
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public int KiemTraTonTai(string tensp, string nsxid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@TenSP", SqlDbType.NVarChar),
                                      new SqlParameter("@NSXID", SqlDbType.VarChar)};
                thamso[0].Value = tensp;
                thamso[1].Value = nsxid;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("SanPham_NSX_KiemTraTonTai", thamso);
                if (dtb.Rows.Count > 0)
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
