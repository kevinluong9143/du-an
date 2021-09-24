using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLDieuChinhTon
    {
        string _sDCTKid;

        public string SDCTKid
        {
            get { return _sDCTKid; }
            set { _sDCTKid = value; }
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
        DateTime _dNgayTao;

        public DateTime DNgayTao
        {
            get { return _dNgayTao; }
            set { _dNgayTao = value; }
        }
        string _sUserTao;

        public string SUserTao
        {
            get { return _sUserTao; }
            set { _sUserTao = value; }
        }
        DateTime _dLastUD;

        public DateTime DLastUD
        {
            get { return _dLastUD; }
            set { _dLastUD = value; }
        }
        string _sUserUD;

        public string SUserUD
        {
            get { return _sUserUD; }
            set { _sUserUD = value; }
        }
        bool _bDaXetDuyet;

        public bool BDaXetDuyet
        {
            get { return _bDaXetDuyet; }
            set { _bDaXetDuyet = value; }
        }
        bool _bHangDacBiet;

        public bool BHangDacBiet
        {
            get { return _bHangDacBiet; }
            set { _bHangDacBiet = value; }
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

        bool _bCNDaTaiVe;

        public bool BCNDaTaiVe
        {
            get { return _bCNDaTaiVe; }
            set { _bCNDaTaiVe = value; }
        }

        public DataTable LoadDieuChinhTonLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhTonKho_LoadDieuChinhTonKhoLenLuoi", thamso);
        }

        public DataTable LayDieuChinhTonKhoTheoMa(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar) };
            thamso[0].Value = DCTKid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("DieuChinhTonKho_LayDieuChinhTonKhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Them(CSQLDieuChinhTon dctk)
        {
            SqlParameter[] thamso = {  new SqlParameter("@SoPDC", SqlDbType.VarChar, 12),
                                        new SqlParameter("@NTid", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserTao", SqlDbType.VarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@UserUD", SqlDbType.VarChar),
                                        new SqlParameter("@DaXetDuyet", SqlDbType.Bit),
                                        new SqlParameter("@NgayXetDuyet", SqlDbType.DateTime),
                                        new SqlParameter("@UserXetDuyet", SqlDbType.VarChar),
                                        new SqlParameter("@DaXacNhan", SqlDbType.Bit),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@NgayXoa", SqlDbType.DateTime),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar),                            
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                  };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = dctk.SMaNTid;
            thamso[2].Value = dctk.SGhiChu;
            thamso[3].Value = dctk.DNgayTao;
            thamso[4].Value = dctk.SUserTao;
            thamso[5].Value = dctk.DLastUD;
            thamso[6].Value = dctk.SUserUD;
            thamso[7].Value = dctk.BDaXetDuyet;
            thamso[8].Value = dctk.DNgayXetDuyet;
            thamso[9].Value = dctk.SUserXetDuyet;
            thamso[10].Value = dctk.BDaXacNhan;
            thamso[11].Value = dctk.DNgayXacNhan;
            thamso[12].Value = dctk.SUserXacNhan;
            thamso[13].Value = dctk.BIsXoa;
            thamso[14].Value = dctk.DNgayXoa;
            thamso[15].Value = dctk.SUserXoa;
            thamso[16].Value = dctk.BHangDacBiet;


            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("DieuChinhTonKho_Them", thamso, null);
            return thamso[0].Value.ToString(); ;
        }

        public int Sua(CSQLDieuChinhTon dctk)
        {
            SqlParameter[] thamso = {  new SqlParameter("@DCTKid", SqlDbType.VarChar),
                                        new SqlParameter("@SoPDC", SqlDbType.VarChar, 12),
                                        new SqlParameter("@NTid", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@UserUD", SqlDbType.VarChar),
                                        new SqlParameter("@DaXetDuyet", SqlDbType.Bit),
                                        new SqlParameter("@NgayXetDuyet", SqlDbType.DateTime),
                                        new SqlParameter("@UserXetDuyet", SqlDbType.VarChar),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                  };
            thamso[0].Value = dctk.SDCTKid;
            thamso[1].Value = dctk.SSoPDC;
            thamso[2].Value = dctk.SMaNTid;
            thamso[3].Value = dctk.SGhiChu;
            thamso[4].Value = dctk.DLastUD;
            thamso[5].Value = dctk.SUserUD;
            thamso[6].Value = dctk.BDaXetDuyet;
            thamso[7].Value = dctk.DNgayXetDuyet;
            thamso[8].Value = dctk.SUserXetDuyet;
            thamso[9].Value = dctk.BHangDacBiet;

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_Sua", thamso);
            return kq;
        }

        public string LayDCTKidTheoSoPDC(string soPDC)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPDC", SqlDbType.VarChar, 12) };
            thamso[0].Value = soPDC;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DieuChinhTonKho_LayDCTKidTheoSoPDC", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }
        public DataTable UpdatGiaKhiThayDoiNhaThuoc(string maDCTKid, string MaNTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar),
                                    new SqlParameter("@NTid", SqlDbType.VarChar)};
            thamso[0].Value = maDCTKid;
            thamso[1].Value = MaNTid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhTonKho_UpdatGiaKhiThayDoiNhaThuoc", thamso);
        }

        public DataTable LayDanhSachDieuChinhTonKhoXacNhanLenLuoi(bool xong, bool xacnhan)
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
                DataTable dtb = dl.LoadTable("DieuChinhTonKho_LoadDieuChinhTonKhoXacNhanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public int SuaThongTinDieuChinhTonKhoXacNhan(CSQLDieuChinhTon dctk_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCTKid", SqlDbType.VarChar), 
                                        new SqlParameter("@DaXacNhan", SqlDbType.Bit), 
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime), 
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar) };
            thamso[0].Value = dctk_.SDCTKid;
            thamso[1].Value = dctk_.BDaXacNhan;
            thamso[2].Value = dctk_.DNgayXacNhan;
            thamso[3].Value = dctk_.SUserXacNhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_SuaThongTinDieuChinhTonKhoXacNhan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinDieuChinhTonKho(string _maDCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar) };
            thamso[0].Value = _maDCTKid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_XoaThongTinDieuChinhTonKho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int UpdateKho_DieuChinhTonKho(string _maDCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar) };
            thamso[0].Value = _maDCTKid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_UpdateKho_DieuChinhTonKho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int Update_ChiNhanhDaTaiVe(string _maPDC)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPDC", SqlDbType.VarChar) };
            thamso[0].Value = _maPDC;
            CDuLieuRemote dl = new CDuLieuRemote();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_Update_ChiNhanhDaTaiVe", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public string DieuChinhTon_ThemImport(string ntid, string ghichu, string usertao, bool hangdacbiet)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", ntid),
                                    new SqlParameter("@GhiChu", ghichu),
                                    new SqlParameter("@UserTao", usertao),
                                    new SqlParameter("@DCTKID", "00000000-0000-0000-0000-000000000000"),
                                    new SqlParameter("@HangDacBiet", hangdacbiet)};
            thamso[3].Direction = ParameterDirection.InputOutput;
            try
            {
                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTon_ThemImport", thamso);
                if (kq > 0)
                {
                    return thamso[3].Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

    }
}
