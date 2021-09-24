using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNhanChuyenHang
    {
        string _sNCHid;

        public string SNCHid
        {
            get { return _sNCHid; }
            set { _sNCHid = value; }
        }
        bool _bDaXacNhan;

        public bool BDaXacNhan
        {
            get { return _bDaXacNhan; }
            set { _bDaXacNhan = value; }
        }
        DateTime _dNgayXacNhan;

        public  DateTime DNgayXacNhan
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

        public CSQLNhanChuyenHang() { }

        public DataTable LoadNhanChuyenHangLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();   
            return dl.LoadTable("NhanChuyenHang_LoadNhanChuyenHangLenLuoi", thamso);
        }

        /// <summary>
        /// HÀM THÊM THÔNG TIN NHẬN CHUYỂN HÀNG TỪ NHÀ THUỐC
        /// </summary>
        /// <param name="sopch"></param>
        /// <param name="ngaychungtu"></param>
        /// <param name="fromm"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public string Them(string sopch, DateTime ngaychungtu, string fromm, string destination, string ghichu, bool hangdacbiet)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SoPCH", SqlDbType.VarChar),
                                        new SqlParameter("@NgayChungTu", SqlDbType.DateTime),
                                        new SqlParameter("@Fromm", SqlDbType.VarChar),
                                        new SqlParameter("@Destination", SqlDbType.VarChar),
                                        new SqlParameter("@NCHID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Ghichu", SqlDbType.NVarChar),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = sopch;
            thamso[1].Value = ngaychungtu;
            thamso[2].Value = fromm;
            thamso[3].Value = destination;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Value = ghichu;
            thamso[6].Value = hangdacbiet;

            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                dlrm.ThucThiTraVeKetQuaKieuInt("ECONHANCHUYENHANG_THEM", thamso);
                return thamso[4].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayNhanChuyenHangTheoMa(string NCHid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHid", SqlDbType.VarChar) };
            thamso[0].Value = NCHid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhanChuyenHang_LayNhanChuyenHangTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayNhanChuyenHangCT_TheoNCHid(string nchid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHid", SqlDbType.VarChar, 50) };
            thamso[0].Value = nchid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NhanChuyenHangCT_LayNCHCT_TheoNCHid", thamso);
        }
        public int UpdateDaXetDuyet(string nchid_, bool xetduyet)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHid", SqlDbType.VarChar), 
                                      new SqlParameter("@DaXetDuyet", SqlDbType.Bit), 
                                      new SqlParameter("@UserXetDuyet", SqlDbType.VarChar) };
            thamso[0].Value = nchid_;
            thamso[1].Value = xetduyet;
            thamso[2].Value = CStaticBien.SmaTaiKhoan;
            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanChuyenHang_UpdateDaXetDuyet", thamso);
            return kq;
        }

        public DataTable LayDSNhanChuyenHangXacNhanLenLuoi(bool xong, bool xacnhan)
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
                DataTable dtb = dl.LoadTable("NhanChuyenHang_LoadNhanChuyenHangXacNhanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public int SuaThongTinNhanChuyenHangXacNhan(CSQLNhanChuyenHang nch_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@NCHid", SqlDbType.VarChar), 
                                        new SqlParameter("@DaXacNhan", SqlDbType.Bit), 
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime), 
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar) };
            thamso[0].Value = nch_.SNCHid;
            thamso[1].Value = nch_.BDaXacNhan;
            thamso[2].Value = nch_.DNgayXacNhan;
            thamso[3].Value = nch_.SUserXacNhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhanChuyenHang_ChinhSuaNhanChuyenHangXacNhan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public string Them(string sopch, DateTime ngaychungtu, string fromm, string destination, string ghichu, bool hangdacbiet, DataTable dtChiTiet)
        {
            try {
                SqlParameter[] thamso = {   
                                            new SqlParameter("@SoPCH", SqlDbType.VarChar),
                                            new SqlParameter("@NgayChungTu", SqlDbType.DateTime),
                                            new SqlParameter("@Fromm", SqlDbType.VarChar),
                                            new SqlParameter("@Destination", SqlDbType.VarChar),
                                            new SqlParameter("@Ghichu", SqlDbType.NVarChar),
                                            new SqlParameter("@HangDacBiet", SqlDbType.Bit),
                                            new SqlParameter("@ChiTiet", SqlDbType.Structured),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };
                thamso[0].Value = sopch;
                thamso[1].Value = ngaychungtu;
                thamso[2].Value = fromm;
                thamso[3].Value = destination;
                thamso[4].Value = ghichu;
                thamso[5].Value = hangdacbiet;
                thamso[6].Value = dtChiTiet;
                thamso[7].Direction = ParameterDirection.Output;

                CDuLieuRemote dlrm = new CDuLieuRemote();
                dlrm.ThucThiTraVeKetQuaKieuInt("ECONhanChuyenHang_ThemMasterVaChiTiet", thamso);
                return thamso[7].Value.ToString();
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
