using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLChuyenKho
    {
        string _sChuyenKhoID;

        public string SChuyenKhoID
        {
            get { return _sChuyenKhoID; }
            set { _sChuyenKhoID = value; }
        }
        string _sSoPCK;

        public string SSoPCK
        {
            get { return _sSoPCK; }
            set { _sSoPCK = value; }
        }

        DateTime _dNgayChinh;

        public DateTime DNgayChinh
        {
            get { return _dNgayChinh; }
            set { _dNgayChinh = value; }
        }

        string _sNTid;

        public string SNTid
        {
            get { return _sNTid; }
            set { _sNTid = value; }
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

        public CSQLChuyenKho() { }
        public CSQLChuyenKho(string ckid, string sopck, string ghiChu, DateTime ngaytao, string usertao,  DateTime lastud, string userud, bool daxetduyet, DateTime ngayxetduyet, string userxetduyet, bool daxacnhan, DateTime ngayxacnhan, string userxacnhan,  bool isxoa, DateTime ngayxoa, string userxoa)
        {
            SChuyenKhoID = ckid;
            SSoPCK = sopck;
            SGhiChu = ghiChu;
            DNgayTao = ngaytao;
            SUserTao = usertao;
            DLastUD = lastud;
            SUserUD = userud;
            BDaXetDuyet = daxetduyet;
            DNgayXetDuyet = ngayxetduyet;
            SUserXetDuyet = userxetduyet;
            BDaXacNhan = daxacnhan;
            DNgayXacNhan = ngayxacnhan;
            SUserXacNhan = userxacnhan;
            BIsXoa = isxoa;
            DNgayXoa = ngayxoa;
            SUserXoa = userxoa;
        }
        public DataTable LoadChuyenKhoLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("ChuyenKho_LoadChuyenKhoLenLuoi", thamso);
        }

        public string Them(CSQLChuyenKho ck)
        {
            SqlParameter[] thamso = {  new SqlParameter("@SoPCK", SqlDbType.VarChar, 12),
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
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar)

                                  };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = ck.SGhiChu;
            thamso[2].Value = ck.DNgayTao;
            thamso[3].Value = ck.SUserTao;
            thamso[4].Value = ck.DLastUD;
            thamso[5].Value = ck.SUserUD;
            thamso[6].Value = ck.BDaXetDuyet;
            thamso[7].Value = ck.DNgayXetDuyet;
            thamso[8].Value = ck.SUserXetDuyet;
            thamso[9].Value = ck.BDaXacNhan;
            thamso[10].Value = ck.DNgayXacNhan;
            thamso[11].Value = ck.SUserXacNhan;
            thamso[12].Value = ck.BIsXoa;
            thamso[13].Value = ck.DNgayXoa;
            thamso[14].Value = ck.SUserXoa;


            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("ChuyenKho_Them", thamso, null);
            return thamso[0].Value.ToString(); ;
        }

        public int Sua(CSQLChuyenKho ck)
        {
            SqlParameter[] thamso = {  new SqlParameter("@CKid", SqlDbType.VarChar),
                                        new SqlParameter("@SoPCK", SqlDbType.VarChar, 12),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@UserUD", SqlDbType.VarChar),
                                        new SqlParameter("@DaXetDuyet", SqlDbType.Bit),
                                        new SqlParameter("@NgayXetDuyet", SqlDbType.DateTime),
                                        new SqlParameter("@UserXetDuyet", SqlDbType.VarChar)
                                  };
            thamso[0].Value = ck.SChuyenKhoID;
            thamso[1].Value = ck.SSoPCK;
            thamso[2].Value = ck.SGhiChu;
            thamso[3].Value = ck.DLastUD;
            thamso[4].Value = ck.SUserUD;
            thamso[5].Value = ck.BDaXetDuyet;
            thamso[6].Value = ck.DNgayXetDuyet;
            thamso[7].Value = ck.SUserXetDuyet;

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("ChuyenKho_Sua", thamso);
            return kq;
        }

        public string LayCKIDTheoSoPCK(string soPCK)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPCK", SqlDbType.VarChar, 12) };
            thamso[0].Value = soPCK;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("ChuyenKho_LayCKIDTheoSoPCK", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }
        public DataTable LayChuyenKhoTheoMa(string CKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKid", SqlDbType.VarChar) };
            thamso[0].Value = CKid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("ChuyenKho_LayChuyenKhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDanhSachChuyenKhoXacNhanLenLuoi(bool xong, bool xacnhan)
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
                DataTable dtb = dl.LoadTable("ChuyenKho_LoadChuyenKhoXacNhanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public int SuaThongTinChuyenKhoXacNhan(CSQLChuyenKho chuyenkho_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@CKid", SqlDbType.VarChar), 
                                        new SqlParameter("@DaXacNhan", SqlDbType.Bit), 
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime), 
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar) };
            thamso[0].Value = chuyenkho_.SChuyenKhoID;
            thamso[1].Value = chuyenkho_.BDaXacNhan;
            thamso[2].Value = chuyenkho_.DNgayXacNhan;
            thamso[3].Value = chuyenkho_.SUserXacNhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("ChuyenKho_ChinhSuaChuyenKhoXacNhan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaThongTinChuyenKho(string _maCKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKID", SqlDbType.VarChar) };
            thamso[0].Value = _maCKid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("ChuyenKho_XoaThongTinChuyenKho", thamso);
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
