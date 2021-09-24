﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLKho
    {
        string _sMaKho;

        public string SMaKho
        {
            get { return _sMaKho; }
            set { _sMaKho = value; }
        }

        string _sMaKhoERP;

        public string SMaKhoERP
        {
            get { return _sMaKhoERP; }
            set { _sMaKhoERP = value; }
        }

        string _sTenKho;

        public string STenKho
        {
            get { return _sTenKho; }
            set { _sTenKho = value; }
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
        string _sLoaiKhoID;

        public string SLoaiKhoID
        {
            get { return _sLoaiKhoID; }
            set { _sLoaiKhoID = value; }
        }
        int _iNhomKhoID;

        public int INhomKhoID
        {
            get { return _iNhomKhoID; }
            set { _iNhomKhoID = value; }
        }

        public CSQLKho() { }
        public CSQLKho(string maKho, string tenKho, string ghiChu, bool khongSuDung, DateTime lastud, DateTime ngaytao, string userid, string loaikhoid, int nhomkhoid)
        {
            SMaKho = maKho;
            STenKho = tenKho;
            SGhiChu = ghiChu;
            BKhongSuDung = khongSuDung;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            SuserID = userid;
            SLoaiKhoID = loaikhoid;
            INhomKhoID = nhomkhoid;
        }
        public DataTable LayDanhSachKhoLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("Kho_LoadKhoLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayKhoLenCBO_TongCongTy(string mabp_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@LoaiKhoID", SqlDbType.VarChar);
                XemTC.Value = mabp_;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadKhoLenCBO_TongCongTy", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable LoadKho_TongCongTy_NhapXuat(string mabp_, bool dieukien_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@LoaiKhoID", SqlDbType.VarChar);
                XemTC.Value = mabp_;
                thamso[0] = XemTC;
                SqlParameter XemTC1 = new SqlParameter("@DieuKien", SqlDbType.Bit);
                XemTC1.Value = dieukien_;
                thamso[1] = XemTC1;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadKho_TongCongTy_NhapXuat", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LoadKho_TongCongTy_Hu(string mabp_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@LoaiKhoID", SqlDbType.VarChar);
                XemTC.Value = mabp_;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadKho_TongCongTy_Hu", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LoadKho_NhaThuoc_NhapXuat(string mabp_, bool dieukien_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@LoaiKhoID", SqlDbType.VarChar);
                XemTC.Value = mabp_;
                thamso[0] = XemTC;

                SqlParameter XemTC1 = new SqlParameter("@DieuKien", SqlDbType.Bit);
                XemTC1.Value = dieukien_;
                thamso[1] = XemTC1;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadKho_NhaThuoc_NhapXuat", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LoadKho_NhaThuoc_Hu(string mabp_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@LoaiKhoID", SqlDbType.VarChar);
                XemTC.Value = mabp_;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadKho_NhaThuoc_Hu", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable LayKhoMacDinh()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LayKhoMacDinh", null);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LayLoaiKho()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LayLoaiKho", null);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LayNhomKho()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LayNhomKho", null);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string ThemMoiKho(CSQLKho kho_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenKho", SqlDbType.NVarChar),  
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar), 
                                        new SqlParameter("@LoaiKhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@NhomKhoID", SqlDbType.Int), 
                                        new SqlParameter("@KetQua", SqlDbType.VarChar, 50)
                                    };
            thamso[0].Value = kho_.STenKho;
            thamso[1].Value = kho_.SGhiChu;
            thamso[2].Value = kho_.BKhongSuDung;
            thamso[3].Value = kho_.DLastUD;
            thamso[4].Value = kho_.DNgayTao;
            thamso[5].Value = kho_.SuserID;
            thamso[6].Value = kho_.SLoaiKhoID;
            thamso[7].Value = kho_.INhomKhoID;

            thamso[8].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("Kho_ThemMoiKho", thamso, null);
                return thamso[8].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public DataTable LayKhoTheoMa(string KhoID)
        {
            CSQLKho kho = new CSQLKho();
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar) };
            thamso[0].Value = KhoID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("Kho_LayKhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinKho(CSQLKho Kho_)
        {
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@TenKho", SqlDbType.NVarChar), 
                                        new SqlParameter("@GhiChu", SqlDbType.NText), 
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit), 
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime), 
                                        new SqlParameter("@UserID", SqlDbType.VarChar),
                                        new SqlParameter("@LoaiKhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@NhomKhoID", SqlDbType.Int)};
            //tham số mới để chỉnh sửa
            thamso[0].Value = Kho_.SMaKho;
            thamso[1].Value = Kho_.STenKho;
            thamso[2].Value = Kho_.SGhiChu;
            thamso[3].Value = Kho_.BKhongSuDung;
            thamso[4].Value = Kho_.DLastUD;
            thamso[5].Value = Kho_.DNgayTao;
            thamso[6].Value = Kho_.SuserID;
            thamso[7].Value = Kho_.SLoaiKhoID;
            thamso[8].Value = Kho_.INhomKhoID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("Kho_ChinhSuaThongTinKho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinKho(string _maKho)
        {
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar) };
            thamso[0].Value = _maKho;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("Kho_XoaThongTinKho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

        }

        public bool KiemTraKhoDaSuDungHayChua(string khoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar),
                                    new SqlParameter("@kq", SqlDbType.Bit)};
            thamso[0].Value = khoid;
            thamso[1].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("Kho_KiemTraDaSuDung", thamso);
            if (thamso[1].Value != null)
            {
                return (bool)thamso[1].Value;
            }
            else
                return false;
        }

        public int Kho_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("Kho_LayMaxCapNhat", null);
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
        public int Kho_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("Kho_LayMaxCapNhat", null);
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
        public int Kho_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("Kho_LayMaxThemMoi", null);
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
        public int Kho_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("Kho_LayMaxThemMoi", null);
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

        public DataTable Kho_LayDSKhoChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("Kho_LayDSKhoChuaCapNhatTaiNT", thamso);
        }
        public DataTable Kho_LayDSKhoChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("Kho_LayDSKhoChuaThemMoiTaiNT", thamso);
        }
        public void Kho_DongBoThemDanhMuc(DataTable dsKhoChuaThemMoi)
        {
            //(KhoID, TenKho, GhiChu, KhongSuDung, LastUD, NgayTao, UserID,MaxCapNhat)
            if (dsKhoChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsKhoChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@Khoid", SqlDbType.VarChar),
                                                new SqlParameter("@TenKho", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@LoaiKhoID", SqlDbType.VarChar), 
                                                new SqlParameter("@NhomKhoID", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaKho", SqlDbType.VarChar)
                                            };
                    thamso[0].Value = dr["Khoid"].ToString();
                    thamso[1].Value = dr["TenKho"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = dr["LoaiKhoID"].ToString();
                    thamso[8].Value = int.Parse(dr["NhomKhoID"].ToString());
                    thamso[9].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[10].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[11].Value = dr["MaKho"].ToString();

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("Kho_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void Kho_DongBoSuaDanhMuc(DataTable dsKhoChuaCapNhat)
        {
            if (dsKhoChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsKhoChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@Khoid", SqlDbType.VarChar),
                                                new SqlParameter("@TenKho", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@LoaiKhoID", SqlDbType.VarChar), 
                                                new SqlParameter("@NhomKhoID", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaKho", SqlDbType.VarChar)
                                            };
                    thamso[0].Value = dr["Khoid"].ToString();
                    thamso[1].Value = dr["TenKho"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[5].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[6].Value = CStaticBien.SmaTaiKhoan;
                    thamso[7].Value = dr["LoaiKhoID"].ToString();
                    thamso[8].Value = int.Parse(dr["NhomKhoID"].ToString());
                    thamso[9].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[10].Value = dr["MaKho"].ToString();

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("Kho_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public DataTable LoadDSKho_DeDieuChinhTon(string makhoid_,bool dieukien_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@KhoID", SqlDbType.VarChar);
                XemTC.Value = makhoid_;
                thamso[0] = XemTC;

                SqlParameter XemTC1 = new SqlParameter("@DieuKien", SqlDbType.Bit);
                XemTC1.Value = dieukien_;
                thamso[1] = XemTC1;
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("Kho_LoadDSKho_DeDieuChinhTon", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int KiemTraNhomKho(string KhoID)
        {
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar),
                                    new SqlParameter("@NhomKhoID", SqlDbType.Int)};
            thamso[0].Value = KhoID;
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("Kho_KiemTraNhomKho", thamso);
            if (thamso[1].Value != null)
            {
                return int.Parse(thamso[1].Value.ToString());
            }
            else
                return 0;
        }

        public DataTable LayKhoDacBiet_TongCongTy(string LoaiKhoID)
        {
            SqlParameter[] thamso = { new SqlParameter("@LoaiKhoID", SqlDbType.UniqueIdentifier) };
            thamso[0].Value = new Guid(LoaiKhoID);

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("Kho_LayKhoDacBiet_TongCongTY", thamso);
        }

        public Boolean IsKhoDacBiet(string KhoID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@KhoID", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(KhoID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("Kho_KiemTraKhoDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        public string KiemTraNhomKhoDacBiet(string Khoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@KhoID", SqlDbType.VarChar) };
            thamso[0].Value = Khoid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("Kho_KiemTraNhomKhoDacBiet", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }
    }
}
