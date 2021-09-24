using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLSanPham_Kho
    {
        string _SPKhoID;

        public string SPKhoID
        {
          get { return _SPKhoID; }
          set { _SPKhoID = value; }
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

        string _sKhoNhapID;

        public string SKhoNhapID
        {
          get { return _sKhoNhapID; }
          set { _sKhoNhapID = value; }
        } 

        string _sKhoXuatID;

        public string SKhoXuatID
        {
          get { return _sKhoXuatID; }
          set { _sKhoXuatID = value; }
        }

        string _sKhoHuID;

        public string SKhoHuID
        {
            get { return _sKhoHuID; }
            set { _sKhoHuID = value; }
        }

        string _sKhoNhapNTID;

        public string SKhoNhapNTID
        {
            get { return _sKhoNhapNTID; }
            set { _sKhoNhapNTID = value; }
        }
        string _sKhoXuatNTID;

        public string SKhoXuatNTID
        {
            get { return _sKhoXuatNTID; }
            set { _sKhoXuatNTID = value; }
        }

        string _sKhoHuNTID;

        public string SKhoHuNTID
        {
            get { return _sKhoHuNTID; }
            set { _sKhoHuNTID = value; }
        }

        bool _bIsMacDinh;

        public bool BIsMacDinh
        {
            get { return _bIsMacDinh; }
            set { _bIsMacDinh = value; }
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
        public CSQLSanPham_Kho() { }

        public DataTable LayDanhSachSanPham_KhoLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("SP_Kho_LoadSanPham_KhoLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public int KiemTraMaSP(string masp_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@MaSP", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);
                XemTC.Value = masp_;
                thamso[0] = XemTC;
                KQ.Direction = ParameterDirection.Output;
                thamso[1] = KQ;
                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_Kho_KiemTraMaSP", thamso);

                return int.Parse(thamso[1].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public DataTable LaySanPham_KhoTheoSPid(string SPid)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPid", SqlDbType.VarChar) };
            thamso[0].Value = SPid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_Kho_LaySP_KhoTheoSPid", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string LayMaKhoMacDinhNTKhiNhap(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoNhapNTMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapNTID"].ToString();
            }
            else
            {
                return null;
            }
        }

        public string LayKhoNhapCTY_Theo_KhoNhapNT(string spid, string Khoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                      new SqlParameter("@KHOID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = Khoid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoNhapCTY_Theo_KhoNhapNT", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapID"].ToString();
            }
            else
            {
                return null;
            }
        }
        public DataTable LaySanPham_KhoTheoMa(string SPKhoID)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPKhoID", SqlDbType.VarChar) };
            thamso[0].Value = SPKhoID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_Kho_LaySP_KhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ThemMoiSanPham_Kho(CSQLSanPham_Kho sanpham_kho_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoHuID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoNhapNTID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoXuatNTID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoHuNTID", SqlDbType.VarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = sanpham_kho_.SMaSP;
            thamso[1].Value = sanpham_kho_.SSPid;
            thamso[2].Value = sanpham_kho_.SKhoNhapID;
            thamso[3].Value = sanpham_kho_.SKhoXuatID;
            thamso[4].Value = sanpham_kho_.SKhoHuID;
            thamso[5].Value = sanpham_kho_.SKhoNhapNTID;
            thamso[6].Value = sanpham_kho_.SKhoXuatNTID;
            thamso[7].Value = sanpham_kho_.SKhoHuNTID;
            thamso[8].Value = sanpham_kho_.BIsMacDinh;
            thamso[9].Value = sanpham_kho_.DLastUD;
            thamso[10].Value = sanpham_kho_.DNgayTao;
            thamso[11].Value = sanpham_kho_.SUserID;
            thamso[12].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("SP_Kho_ThemMoiSanPham_Kho", thamso, null);
                return thamso[12].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public int SuaThongTinSanPham_Kho(CSQLSanPham_Kho sanpham_kho_)
        {
            SqlParameter[] thamso = {  new SqlParameter("@SPKhoID", SqlDbType.VarChar),
                                        new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoHuID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoNhapNTID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoXuatNTID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoHuNTID", SqlDbType.VarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar),  };
            thamso[0].Value = sanpham_kho_.SPKhoID;
            thamso[1].Value = sanpham_kho_.SMaSP;
            thamso[2].Value = sanpham_kho_.SSPid;
            thamso[3].Value = sanpham_kho_.SKhoNhapID;
            thamso[4].Value = sanpham_kho_.SKhoXuatID;
            thamso[5].Value = sanpham_kho_.SKhoHuID;
            if (SKhoNhapNTID == "")
            {
                thamso[6].Value = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                thamso[6].Value = sanpham_kho_.SKhoNhapNTID;
            }
            if (SKhoXuatNTID == "")
            {
                thamso[7].Value = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                thamso[7].Value = sanpham_kho_.SKhoXuatNTID;
            }
            if (SKhoHuNTID == "")
            {
                thamso[8].Value = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                thamso[8].Value = sanpham_kho_.SKhoHuNTID;
            }
            thamso[9].Value = sanpham_kho_.BIsMacDinh;
            thamso[10].Value = sanpham_kho_.DLastUD;
            thamso[11].Value = sanpham_kho_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_Kho_ChinhSuaThongTinSP_Kho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public string LayMaKhoMacDinhKhiNhap(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar)};
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoNhapMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapID"].ToString();
            }
            else
            {
                return null;
            }
        }
        public string LayMaKhoNhapMacDinh_KoSpid()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoNhap_MacDinhKoTheoSPid", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapID"].ToString();
            }
            else
            {
                return null;
            }
        }
        public string LayMaKhoNhapNTMacDinh_KoSpid()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoNhapNT_MacDinhKoTheoSPid", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapNTID"].ToString();
            }
            else
            {
                return null;
            }
        }

        public string LayMaKhoMacDinhKhiXuat(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayKhoXuatMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoXuatID"].ToString();
            }
            else
            {
                return null;
            }
        }

        public DataTable LaySP_KhoTheoSPID_CoMacDinh(string spid, bool xacnhan)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                      new SqlParameter("@MacDinh", SqlDbType.Bit) };
            thamso[0].Value = spid;
            thamso[1].Value = xacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_Kho_LaySP_KhoTheoSPID_CoMacDinh", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int SP_Kho_KiemTraTonTaiSP(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", new Guid(spid)) };
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SP_Kho_KiemTraTonTaiSP", thamso);
                if (dtb.Rows.Count > 0)
                    return int.Parse(dtb.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaMacDinhSP_Kho(CSQLSanPham_Kho sp_kho_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPKhoID", SqlDbType.VarChar),
                                        new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar) };
            thamso[0].Value = sp_kho_.SPKhoID;
            thamso[1].Value = sp_kho_.BIsMacDinh;
            thamso[2].Value = sp_kho_.DLastUD;
            thamso[3].Value = sp_kho_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SP_Kho_SuaMacDinhSP_Kho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public int SP_Kho_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayMaxCapNhat", null);
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
        public int SP_Kho_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SP_Kho_LayMaxCapNhat", null);
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
        public int SP_Kho_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SP_Kho_LayMaxThemMoi", null);
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
        public int SP_Kho_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SP_Kho_LayMaxThemMoi", null);
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

        public DataTable SP_Kho_LayDSSP_KhoChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SP_Kho_LayDSSP_KhoChuaCapNhatTaiNT", thamso);
        }
        public DataTable SP_Kho_LayDSSP_KhoChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SP_Kho_LayDSSP_KhoChuaThemMoiTaiNT", thamso);
        }
        public void SP_Kho_DongBoThemDanhMuc(DataTable dsSP_KhoChuaThemMoi)
        {
           if (dsSP_KhoChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSP_KhoChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@SPKhoID", SqlDbType.VarChar),
                                                new SqlParameter("@MaSP", SqlDbType.VarChar),
                                                new SqlParameter("@SPID", SqlDbType.VarChar), 
                                                new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoXuatID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoHuID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoNhapNTID", SqlDbType.VarChar), 
                                                new SqlParameter("@KhoXuatNTID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoHuNTID", SqlDbType.VarChar),
                                                new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@ngaytao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@maxcapnhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int) };
                        thamso[0].Value = dr["SPKhoID"].ToString();
                        thamso[1].Value = dr["MaSP"].ToString();
                        thamso[2].Value = dr["SPid"].ToString();

                        thamso[3].Value = dr["KhoNhapID"].ToString();
                        thamso[4].Value = dr["KhoXuatID"].ToString();
                        thamso[5].Value = dr["KhoHangHuID"].ToString();

                        thamso[6].Value = dr["KhoNhapNTid"].ToString();
                        thamso[7].Value = dr["KhoXuatNTid"].ToString();
                        thamso[8].Value = dr["KhoHangHuNTid"].ToString();

                        thamso[9].Value = bool.Parse(dr["IsMacDinh"].ToString());
                        thamso[10].Value = DateTime.Parse(dr["LastUD"].ToString());
                        thamso[11].Value = DateTime.Parse(dr["NgayTao"].ToString());
                        thamso[12].Value = CStaticBien.SmaTaiKhoan;
                        thamso[13].Value = int.Parse(dr["MaxCapNhat"].ToString());
                        thamso[14].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SP_Kho_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void SP_Kho_DongBoSuaDanhMuc(DataTable dsSP_KhoChuaCapNhat)
        {
            if (dsSP_KhoChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSP_KhoChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@SPKhoID", SqlDbType.VarChar),
                                                new SqlParameter("@MaSP", SqlDbType.VarChar),
                                                new SqlParameter("@SPID", SqlDbType.VarChar), 
                                                new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoXuatID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoHuID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoNhapNTID", SqlDbType.VarChar), 
                                                new SqlParameter("@KhoXuatNTID", SqlDbType.VarChar),
                                                new SqlParameter("@KhoHuNTID", SqlDbType.VarChar),
                                                new SqlParameter("@IsMacDinh", SqlDbType.Bit), 
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@ngaytao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@maxcapnhat", SqlDbType.Int) };
                    thamso[0].Value = dr["SPKhoID"].ToString();
                    thamso[1].Value = dr["MaSP"].ToString();
                    thamso[2].Value = dr["SPid"].ToString();

                    thamso[3].Value = dr["KhoNhapID"].ToString();
                    thamso[4].Value = dr["KhoXuatID"].ToString();
                    thamso[5].Value = dr["KhoHangHuID"].ToString();

                    thamso[6].Value = dr["KhoNhapNTid"].ToString();
                    thamso[7].Value = dr["KhoXuatNTid"].ToString();
                    thamso[8].Value = dr["KhoHangHuNTid"].ToString();

                    thamso[9].Value = bool.Parse(dr["IsMacDinh"].ToString());
                    thamso[10].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[11].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[12].Value = CStaticBien.SmaTaiKhoan;
                    thamso[13].Value = int.Parse(dr["MaxCapNhat"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SP_Kho_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
