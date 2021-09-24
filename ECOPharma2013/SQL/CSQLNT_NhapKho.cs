using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhapKho
    {
        string _sMaPN;

        public string SMaPN
        {
            get { return _sMaPN; }
            set { _sMaPN = value; }
        }

        string _sSoCTN;

        public string SSoCTN
        {
            get { return _sSoCTN; }
            set { _sSoCTN = value; }
        }

        string _sSoHD;

        public string SSoHD
        {
            get { return _sSoHD; }
            set { _sSoHD = value; }
        }

        DateTime _dNgayNhap;

        public DateTime DNgayNhap
        {
            get { return _dNgayNhap; }
            set { _dNgayNhap = value; }
        }

        string _sFromm;

        public string SFromm
        {
            get { return _sFromm; }
            set { _sFromm = value; }
        }

        bool _bXNPhieuNhap;

        public bool BXNPhieuNhap
        {
            get { return _bXNPhieuNhap; }
            set { _bXNPhieuNhap = value; }
        }

        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }

        DateTime _dNgayXacNhan;

        public DateTime DNgayXacNhan
        {
            get { return _dNgayXacNhan; }
            set { _dNgayXacNhan = value; }
        }

        string _sUserNhap;

        public string SUserNhap
        {
            get { return _sUserNhap; }
            set { _sUserNhap = value; }
        }

        string _sUserXN;

        public string SUserXN
        {
            get { return _sUserXN; }
            set { _sUserXN = value; }
        }

        bool _bisPhieuCuoi;

        public bool BisPhieuCuoi
        {
            get { return _bisPhieuCuoi; }
            set { _bisPhieuCuoi = value; }
        }

        bool _SIsKhoDacBiet;
        public bool SIsKhoDacBiet
        {
            get { return _SIsKhoDacBiet; }
            set { _SIsKhoDacBiet = value; }
        }

        public CSQLNT_NhapKho() { }
        public CSQLNT_NhapKho(string mapnid, string soctn, string sohd, DateTime ngaynhap,  string from, bool xnphieunhap, string ghichu,  DateTime ngayxacnhan, string usernhap, string userxn, bool isPhieuCuoi )
        {
            SMaPN = mapnid;
            SSoCTN = soctn;
            SSoHD = sohd;
            DNgayNhap = ngaynhap;
            SFromm = from;
            BXNPhieuNhap = xnphieunhap;
            SGhiChu = ghichu;
            DNgayXacNhan = ngayxacnhan;
            SUserNhap = usernhap;
            SUserXN = userxn;
            BisPhieuCuoi = isPhieuCuoi;
        }

        public DataTable LayDanhSachLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_NhapKho_LayDanhSachLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public DataTable LayNhapKhoTheoMa(string PNid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNid", SqlDbType.VarChar) };
            thamso[0].Value = PNid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_NhapKho_LayNhapKhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayNT_NhapKho_theoSoCTN_SoHD(string soctn_, string sohd_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCTN", SqlDbType.VarChar, 12),
                                    new SqlParameter("@SoDH", SqlDbType.VarChar, 12)};
            thamso[0].Value = soctn_;
            thamso[1].Value = sohd_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_NhapKho_LayDS_theoSoCTN_SoHD", thamso);
            return dtb;
        }
        
        public string ThemMoi(CSQLNT_NhapKho  nt_nhapkho_)
        {
            SqlParameter[] thamso = {  new SqlParameter("@PNID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@SoCTN", SqlDbType.VarChar),
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@NgayNhap", SqlDbType.DateTime), 
                                        new SqlParameter("@Fromm", SqlDbType.VarChar),
                                        new SqlParameter("@XNPhieuNhap", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@IsPhieuCuoi", SqlDbType.Bit),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nt_nhapkho_.SSoCTN;
            thamso[2].Value = nt_nhapkho_.SSoHD;
            thamso[3].Value = nt_nhapkho_.DNgayNhap;
            thamso[4].Value = nt_nhapkho_.SFromm;
            thamso[5].Value = nt_nhapkho_.BXNPhieuNhap;
            thamso[6].Value = nt_nhapkho_.SGhiChu;
            thamso[7].Value = nt_nhapkho_.SUserNhap;
            thamso[8].Value = nt_nhapkho_.BisPhieuCuoi;
            thamso[9].Value = nt_nhapkho_.SIsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_NhapKho_ThemMoiNhapKho", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public bool KiemTraTonTaiSoCTN(string SoCTN)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@SoCTN", SqlDbType.VarChar, 12),
                                        new SqlParameter("@IsExist", SqlDbType.Bit)
                                    };

            thamso[0].Value = SoCTN;
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NT_NhapKho_KiemTraTonTaiSoCTN", thamso);

            return Convert.ToBoolean(thamso[1].Value);
        }

        public string ThemMoi(CSQLNT_NhapKho nt_nhapkho_, DataTable dtChiTiet)
        {
            try
            {
                SqlParameter[] thamso = {  
                                        new SqlParameter("@SoCTN", SqlDbType.VarChar),
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@NgayNhap", SqlDbType.DateTime), 
                                        new SqlParameter("@Fromm", SqlDbType.VarChar),
                                        new SqlParameter("@XNPhieuNhap", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@IsPhieuCuoi", SqlDbType.Bit),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        new SqlParameter("@ChiTiet", SqlDbType.Structured),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1),
                                    };

                thamso[0].Value = nt_nhapkho_.SSoCTN;
                thamso[1].Value = nt_nhapkho_.SSoHD;
                thamso[2].Value = nt_nhapkho_.DNgayNhap;
                thamso[3].Value = nt_nhapkho_.SFromm;
                thamso[4].Value = nt_nhapkho_.BXNPhieuNhap;
                thamso[5].Value = nt_nhapkho_.SGhiChu;
                thamso[6].Value = nt_nhapkho_.SUserNhap;
                thamso[7].Value = nt_nhapkho_.BisPhieuCuoi;
                thamso[8].Value = nt_nhapkho_.SIsKhoDacBiet;
                thamso[9].Value = dtChiTiet;
                thamso[10].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThi("NT_NhapKho_ThemMoiNhapKhoVaChiTiet", thamso);
                return thamso[10].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable BaoCaoNhapKho_LoadDSTuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNhapKho_LoadDSTuNgay_DenNgay", thamso);
        }
    }
}
