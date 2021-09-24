using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_SanPham_Kho
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
        public CSQLNT_SanPham_Kho() { }
        public CSQLNT_SanPham_Kho(string khoid, string masp, string spid, string khonhap, string khoxuat, DateTime lastud, DateTime ngaytao, string userid)
        {
            _SPKhoID = khoid;
            SMaSP = masp;
            SSPid = spid;
            SKhoNhapID = khonhap;
            SKhoXuatID = khoxuat;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SUserID = userid;
        }

        public DataTable LoadDanhSachLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_SP_Kho_LoadDanhSachLenLuoi", thamso);
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
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_SP_Kho_KiemTraMaSP", thamso);

                return int.Parse(thamso[1].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public DataTable LayDuLieuTheoSPid(string SPid)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPid", SqlDbType.VarChar) };
            thamso[0].Value = SPid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_SP_Kho_LayDuLieuTheoSPid", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDuLieuTheoMa(string SPKhoID)
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            SqlParameter[] thamso = { new SqlParameter("@SPKhoID", SqlDbType.VarChar) };
            thamso[0].Value = SPKhoID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_SP_Kho_LayDuLieuTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ThemMoi(CSQLNT_SanPham_Kho nt_sanpham_kho_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = nt_sanpham_kho_.SMaSP;
            thamso[1].Value = nt_sanpham_kho_.SSPid;
            thamso[2].Value = nt_sanpham_kho_.SKhoNhapID;
            thamso[3].Value = nt_sanpham_kho_.SKhoXuatID;
            thamso[4].Value = nt_sanpham_kho_.DLastUD;
            thamso[5].Value = nt_sanpham_kho_.DNgayTao;
            thamso[6].Value = nt_sanpham_kho_.SUserID;
            thamso[7].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_SP_Kho_ThemMoi", thamso, null);
                return thamso[7].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public int ChinhSua(CSQLNT_SanPham_Kho nt_sanpham_kho_)
        {
            SqlParameter[] thamso = {  new SqlParameter("@SPKhoID", SqlDbType.VarChar),
                                        new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),  
                                        new SqlParameter("@UserID", SqlDbType.VarChar),  };
            thamso[0].Value = nt_sanpham_kho_.SPKhoID;
            thamso[1].Value = nt_sanpham_kho_.SMaSP;
            thamso[2].Value = nt_sanpham_kho_.SSPid;
            thamso[3].Value = nt_sanpham_kho_.SKhoNhapID;
            thamso[4].Value = nt_sanpham_kho_.SKhoXuatID;
            thamso[5].Value = nt_sanpham_kho_.DLastUD;
            thamso[6].Value = nt_sanpham_kho_.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_SP_Kho_ChinhSua", thamso);
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
            DataTable dtb = dl.LoadTable("NT_SP_Kho_LayKhoNhapMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoNhapID"].ToString();
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
            DataTable dtb = dl.LoadTable("NT_SP_Kho_LayKhoXuatMacDinh", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0]["KhoXuatID"].ToString();
            }
            else
            {
                return null;
            }
        }

        public void NT_SP_Kho_DongBoThemDanhMuc(DataTable dsSanPhamChuaThemMoi, string tdgspid)
        {
            CSQLKho kho_ = new CSQLKho();
            if (dsSanPhamChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPhamChuaThemMoi.Rows)
                {
                    #region Them danh muc san pham
                    SqlParameter[] thamso = {
                                        new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit) };
                    thamso[0].Value = dr["MaSP"].ToString();
                    thamso[1].Value = dr["SPid"].ToString();
                    thamso[2].Value = kho_.LayKhoMacDinh().Rows[0]["KhoID"].ToString();
                    thamso[3].Value = kho_.LayKhoMacDinh().Rows[0]["KhoID"].ToString();
                    thamso[4].Value = DateTime.Now;
                    thamso[5].Value = DateTime.Now;
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NT_SP_Kho_DongBoThemDanhMuc", thamso, null);
                    #endregion

                }
            }
        }

        public void NT_SP_Kho_DongBoSuaDanhMuc(DataTable dsSanPhamChuaCapNhat, string tdgspid)
        {
            CSQLKho kho_ = new CSQLKho();
            if (dsSanPhamChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPhamChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = {new SqlParameter("@MaSP", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoNhapID", SqlDbType.VarChar),
                                        new SqlParameter("@KhoXuatID", SqlDbType.VarChar), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar),  
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)};
                    thamso[0].Value = dr["MaSP"].ToString();
                    thamso[1].Value = dr["SPid"].ToString();
                    thamso[2].Value = kho_.LayKhoMacDinh().Rows[0]["KhoID"].ToString();
                    thamso[3].Value = kho_.LayKhoMacDinh().Rows[0]["KhoID"].ToString();
                    thamso[4].Value = DateTime.Now;
                    thamso[5].Value = DateTime.Now;
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NT_SP_Kho_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

    }
}
