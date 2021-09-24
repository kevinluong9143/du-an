using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNhapKho
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

        string _sSoSeri;

        public string SSoSeri
        {
            get { return _sSoSeri; }
            set { _sSoSeri = value; }
        }
        DateTime _dNgayCTN;

        public DateTime DNgayCTN
        {
            get { return _dNgayCTN; }
            set { _dNgayCTN = value; }
        }

        string _sNPPid;

        public string SNPPid
        {
            get { return _sNPPid; }
            set { _sNPPid = value; }
        }

        string _sXuatChoNT;

        public string SXuatChoNT
        {
            get { return _sXuatChoNT; }
            set { _sXuatChoNT = value; }
        }

        bool _bDirect;

        public bool BDirect
        {
            get { return _bDirect; }
            set { _bDirect = value; }
        }

        bool _bNhapXong;

        public bool BNhapXong
        {
            get { return _bNhapXong; }
            set { _bNhapXong = value; }
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

        Boolean _sIsKhoDacBiet;
        public Boolean SIsKhoDacBiet
        {
            get { return _sIsKhoDacBiet; }
            set { _sIsKhoDacBiet = value; }
        }

        public CSQLNhapKho() { }
        public CSQLNhapKho(string mapnid, string soctn, DateTime ngayctn, string nppid, string xuatchont, bool direct,bool nhapxong, bool xnphieunhap,  string ghichu, DateTime lastud, DateTime ngaytao, DateTime ngayxacnhan, string usernhap, string userxn)
        {
            SMaPN = mapnid;
            SSoCTN = soctn;
            DNgayCTN = ngayctn;
            SNPPid = nppid;
            SXuatChoNT = xuatchont;
            BDirect = direct;
            BNhapXong = nhapxong;
            BXNPhieuNhap = xnphieunhap;
            SGhiChu = ghichu;
            DLastUD = lastud;
            DNgayTao = ngaytao;
            DNgayXacNhan = ngayxacnhan;
            SUserNhap = usernhap;
            SUserXN = userxn;
        }

        public DataTable LayDanhSachNhapKhoLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapKho_LoadNhapKhoLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public DataTable LayDanhSachNhapKhoXacNhanLenLuoi(bool xong, bool xacnhan)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter NhapXong = new SqlParameter("@NhapXong", SqlDbType.Bit);
                NhapXong.Value = xong;
                thamso[0] = NhapXong;
                SqlParameter XNPhieuNhap = new SqlParameter("@XNPhieuNhap", SqlDbType.Bit);
                XNPhieuNhap.Value = xacnhan;
                thamso[1] = XNPhieuNhap;

                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapKho_LoadNhapKhoXacNhanLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public string ThemMoiNhapKho(CSQLNhapKho  nhapkho_)
        {
            SqlParameter[] thamso = {   
                                        new SqlParameter("@PNID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@SoCTN", SqlDbType.VarChar), 
                                        new SqlParameter("@NgayCTN", SqlDbType.DateTime), 
                                        new SqlParameter("@NPPID", SqlDbType.VarChar), 
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar), 
                                        new SqlParameter("@Direct", SqlDbType.Bit), 
                                        new SqlParameter("@NhapXong", SqlDbType.Bit), 
                                        new SqlParameter("@XNPhieuNhap", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@SoSeri", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nhapkho_.SSoCTN;
            thamso[2].Value = nhapkho_.DNgayCTN;
            thamso[3].Value = nhapkho_.SNPPid;
            thamso[4].Value = nhapkho_.SXuatChoNT;
            thamso[5].Value = nhapkho_.BDirect;
            thamso[6].Value = nhapkho_.BNhapXong;
            thamso[7].Value = nhapkho_.BXNPhieuNhap;
            thamso[8].Value = nhapkho_.SGhiChu;
            thamso[9].Value = nhapkho_.DLastUD;
            thamso[10].Value = nhapkho_.DNgayTao;
            thamso[11].Value = nhapkho_.SUserNhap;
            thamso[12].Value = nhapkho_.SSoSeri;
            thamso[13].Value = nhapkho_.SIsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NhapKho_ThemMoiNhapKho", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public DataTable LayNhapKhoTheoMa(string PNid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNid", SqlDbType.VarChar) };
            thamso[0].Value = PNid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhapKho_LayNhapKhoTheoMa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayNhapKhoTheoSoCTN(string SoCTN)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCTN", SqlDbType.VarChar) };
            thamso[0].Value = SoCTN;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhapKho_LayNhapKhoTheoSoCTN", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaThongTinNhapKho(CSQLNhapKho nhapkho_)
        {
            SqlParameter[] thamso = {   
                                        new SqlParameter("@PNid", SqlDbType.VarChar),
                                        new SqlParameter("@SoCTN", SqlDbType.NVarChar), 
                                        new SqlParameter("@NgayCTN", SqlDbType.DateTime), 
                                        new SqlParameter("@NPPID", SqlDbType.VarChar), 
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar), 
                                        new SqlParameter("@Direct", SqlDbType.Bit), 
                                        new SqlParameter("@NhapXong", SqlDbType.Bit),  
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime), 
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar), 
                                        new SqlParameter("@SoSeri", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = nhapkho_.SMaPN;
            thamso[1].Value = nhapkho_.SSoCTN;
            thamso[2].Value = nhapkho_.DNgayCTN;
            thamso[3].Value = nhapkho_.SNPPid;
            thamso[4].Value = nhapkho_.SXuatChoNT;
            thamso[5].Value = nhapkho_.BDirect;
            thamso[6].Value = nhapkho_.BNhapXong;
            thamso[7].Value = nhapkho_.SGhiChu;
            thamso[8].Value = nhapkho_.DLastUD;
            thamso[9].Value = nhapkho_.SUserNhap;
            thamso[10].Value = nhapkho_.SSoSeri;
            thamso[11].Value = nhapkho_.SIsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKho_ChinhSuaThongTinNhapKho", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int SuaThongTinNhapKhoXacNhan(CSQLNhapKho nhapkho_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@PNid", SqlDbType.VarChar), 
                                        new SqlParameter("@XNPhieuNhap", SqlDbType.Bit), 
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime), 
                                        new SqlParameter("@UserXN", SqlDbType.VarChar) };
            thamso[0].Value = nhapkho_.SMaPN;
            thamso[1].Value = nhapkho_.BXNPhieuNhap;
            thamso[2].Value = nhapkho_.DNgayXacNhan;
            thamso[3].Value = nhapkho_.SUserXN;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKho_ChinhSuaNhapKhoXacNhan", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int XoaNhapKho(string _PNid, string UserID)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNid", SqlDbType.VarChar) ,   
                                        new SqlParameter("@UserID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = _PNid;
            thamso[1].Value = UserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKho_Xoa", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

        }
        public DataTable LayDSDonHangDirect()
        {
            try 
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("NhapKho_LayDSDonHangDirect", null);
            }
            catch
            {
                return null;
            }
        }

        public int UpdateDaXuat(string pnid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@PNid", SqlDbType.VarChar) };
                thamso[0].Value = pnid;
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NhapKho_UpdateDaXuat", thamso);
            }
            catch
            {
                return -1;
            }
        }
        public int KiemTraTrungSoChungTu(string soct_, string pnid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@SoChungTu", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@PNID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);


                XemTC.Value = soct_;
                thamso[0] = XemTC;

                nvid.Value = pnid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKho_KiemTraTrungSoChungTu", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public bool IsKhoDacBiet(string PNid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNid", SqlDbType.UniqueIdentifier), 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(PNid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NhapKho_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        public bool IsXacNhan(string PNid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNid", SqlDbType.UniqueIdentifier), 
                                        new SqlParameter("@IsXacNhan", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(PNid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NhapKho_IsXacNhan", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
    }
}
