using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_DieuChinhHSD
    {
        public CSQLNT_DieuChinhHSD() { }

        string _sDCHDid;

        public string SDCHDid
        {
            get { return _sDCHDid; }
            set { _sDCHDid = value; }
        }

        DateTime _dNgayChinh;

        public DateTime DNgayChinh
        {
            get { return _dNgayChinh; }
            set { _dNgayChinh = value; }
        }

        string _sSoPDC;

        public string SSoPDC
        {
            get { return _sSoPDC; }
            set { _sSoPDC = value; }
        }

        string _sMaNTid;

        public string SMaNTid
        {
            get { return _sMaNTid; }
            set { _sMaNTid = value; }
        }

        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }
        DateTime _dNgayNhan;

        public DateTime DNgayNhan
        {
            get { return _dNgayNhan; }
            set { _dNgayNhan = value; }
        }

        string _sUserNhan;

        public string SUserNhan
        {
            get { return _sUserNhan; }
            set { _sUserNhan = value; }
        }

        bool _bDaXetDuyet;

        public bool BDaXetDuyet
        {
            get { return _bDaXetDuyet; }
            set { _bDaXetDuyet = value; }
        }
        DateTime _dNgayXetDuyet;

        public DateTime DNgayXetDuyet
        {
            get { return _dNgayXetDuyet; }
            set { _dNgayXetDuyet = value; }
        }
        string _sUserXetDuyet;

        public string SUserXetDuyet
        {
            get { return _sUserXetDuyet; }
            set { _sUserXetDuyet = value; }
        }
        bool _bDaXacNhan;

        public bool BDaXacNhan
        {
            get { return _bDaXacNhan; }
            set { _bDaXacNhan = value; }
        }
        DateTime _dNgayXacNhan;

        public DateTime DNgayXacNhan
        {
            get { return _dNgayXacNhan; }
            set { _dNgayXacNhan = value; }
        }
        string _sUserXacNhan;

        public string SUserXacNhan
        {
            get { return _sUserXacNhan; }
            set { _sUserXacNhan = value; }
        }
        bool _bIsXoa;

        public bool BIsXoa
        {
            get { return _bIsXoa; }
            set { _bIsXoa = value; }
        }
        DateTime _dNgayXoa;

        public DateTime DNgayXoa
        {
            get { return _dNgayXoa; }
            set { _dNgayXoa = value; }
        }
        string _sUserXoa;

        public string SUserXoa
        {
            get { return _sUserXoa; }
            set { _sUserXoa = value; }
        }
        bool _bHangDacBiet;

        public bool BHangDacBiet
        {
            get { return _bHangDacBiet; }
            set { _bHangDacBiet = value; }
        }
        public int Sua(CSQLNT_DieuChinhHSD nt_dchsd)
        {
            SqlParameter[] thamso = {  new SqlParameter("@DCHDid", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@DaXetDuyet", SqlDbType.Bit),
                                        new SqlParameter("@NgayXetDuyet", SqlDbType.DateTime),
                                        new SqlParameter("@UserXetDuyet", SqlDbType.VarChar)
                                  };
            thamso[0].Value = nt_dchsd.SDCHDid;
            thamso[1].Value = nt_dchsd.SGhiChu;
            thamso[2].Value = nt_dchsd.BDaXetDuyet;
            thamso[3].Value = nt_dchsd.DNgayXetDuyet;
            thamso[4].Value = nt_dchsd.SUserXetDuyet;

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_DieuChinhHSD_Sua", thamso);
            return kq;
        }
        public int ThemMoi(CSQLNT_DieuChinhHSD nt_dct_)
        {
            SqlParameter[] thamso = {  new SqlParameter("@DCHDid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@SoPDC", SqlDbType.VarChar),
                                        new SqlParameter("@NgayChinh", SqlDbType.DateTime), 
                                        new SqlParameter("@NTid", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@NgayNhan", SqlDbType.DateTime),
                                        new SqlParameter("@UserNhan", SqlDbType.VarChar),                            
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)};
            thamso[0].Value = nt_dct_.SDCHDid;
            thamso[1].Value = nt_dct_.SSoPDC;
            thamso[2].Value = nt_dct_.DNgayChinh;
            thamso[3].Value = nt_dct_.SMaNTid;
            thamso[4].Value = nt_dct_.SGhiChu;
            thamso[5].Value = nt_dct_.DNgayNhan;
            thamso[6].Value = nt_dct_.SUserNhan;
            thamso[7].Value = nt_dct_.BHangDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_NhanDieuChinhHSD_ThemMoiNhanDieuChinhHSD", thamso);
                return kq;
            }
            catch (Exception Exception) { throw Exception; }
        }
        public DataTable LoadNT_DieuChinhHSDLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_DieuChinhHSD_LoadDieuChinhHSDLenLuoi", thamso);
        }

        public DataTable LayDieuChinhHSDTheoMa(string DCHDid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCHDid", SqlDbType.VarChar) };
            thamso[0].Value = DCHDid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_DieuChinhHSD_LayDieuChinhHSDTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string LayDCHDidTheoSoPDC(string soPDC)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPDC", SqlDbType.VarChar, 12) };
            thamso[0].Value = soPDC;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_DieuChinhHSD_LayDCHDidTheoSoPDC", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }

        public DataTable LayDanhSachNT_DieuChinhHSDXacNhanLenLuoi(bool xong, bool xacnhan)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter NhapXong = new SqlParameter("@DaXetDuyet", SqlDbType.Bit);
                NhapXong.Value = xong;
                thamso[0] = NhapXong;
                SqlParameter XNPhieuNhap = new SqlParameter("@DaXacNhan", SqlDbType.Bit);
                XNPhieuNhap.Value = xacnhan;
                thamso[1] = XNPhieuNhap;

                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_DieuChinhHSD_LoadDieuChinhHSDXacNhanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public int SuaThongTinDieuChinhTonKhoXacNhan(CSQLNT_DieuChinhHSD nt_dchsd_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCHDid", SqlDbType.VarChar), 
                                        new SqlParameter("@DaXacNhan", SqlDbType.Bit), 
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime), 
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar) };
            thamso[0].Value = nt_dchsd_.SDCHDid;
            thamso[1].Value = nt_dchsd_.BDaXacNhan;
            thamso[2].Value = nt_dchsd_.DNgayXacNhan;
            thamso[3].Value = nt_dchsd_.SUserXacNhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_DieuChinhHSD_SuaThongTinDieuChinhHSDXacNhan", thamso);
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
