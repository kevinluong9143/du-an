using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;

namespace ECOPharma2013
{
    class CSQLSanPham
    {
        private string SPid;

        public string sSPid
        {
            get { return SPid; }
            set { SPid = value; }
        }
        private string MaSP;

        public string sMaSP
        {
            get { return MaSP; }
            set { MaSP = value; }
        }
        private string MaVach;

        public string sMaVach
        {
            get { return MaVach; }
            set { MaVach = value; }
        }
        private string TenSP;

        public string sTenSP
        {
            get { return TenSP; }
            set { TenSP = value; }
        }
        private string DBCid;

        public string sDBCid
        {
            get { return DBCid; }
            set { DBCid = value; }
        }
        private string DVNhapID;

        public string sDVNhapID
        {
            get { return DVNhapID; }
            set { DVNhapID = value; }
        }
        private string DVXuatID;

        public string sDVXuatID
        {
            get { return DVXuatID; }
            set { DVXuatID = value; }
        }
        private string DVBanID;

        public string sDVBanID
        {
            get { return DVBanID; }
            set { DVBanID = value; }
        }
        string _sDVChuan;

        public string sDVChuanID
        {
            get { return _sDVChuan; }
            set { _sDVChuan = value; }
        }
        private string HDSD;

        public string sHDSD
        {
            get { return HDSD; }
            set { HDSD = value; }
        }
        //private string NSXid;

        //public string sNSXid
        //{
        //    get { return NSXid; }
        //    set { NSXid = value; }
        //}
        private string NPPid;

        public string sNPPid
        {
            get { return NPPid; }
            set { NPPid = value; }
        }
        private string KhoNhapID;

        public string sKhoNhapID
        {
            get { return KhoNhapID; }
            set { KhoNhapID = value; }
        }
        private string KhoXuatID;

        public string sKhoXuatID
        {
            get { return KhoXuatID; }
            set { KhoXuatID = value; }
        }
        private string NhomID;

        public string sNhomID
        {
            get { return NhomID; }
            set { NhomID = value; }
        }
        private decimal GiaMuaChuaTAXKyTruoc;

        public decimal dGiaMuaChuaTAXKyTruoc
        {
            get { return GiaMuaChuaTAXKyTruoc; }
            set { GiaMuaChuaTAXKyTruoc = value; }
        }
        private decimal TAXKyTruoc;

        public decimal dTAXKyTruoc
        {
            get { return TAXKyTruoc; }
            set { TAXKyTruoc = value; }
        }
        private decimal GiaMuaChuaTAXHT;

        public decimal dGiaMuaChuaTAXHT
        {
            get { return GiaMuaChuaTAXHT; }
            set { GiaMuaChuaTAXHT = value; }
        }
        private decimal TAXHT;

        public decimal dTAXHT
        {
            get { return TAXHT; }
            set { TAXHT = value; }
        }
        private string HoatChat;

        public string sHoatChat
        {
            get { return HoatChat; }
            set { HoatChat = value; }
        }

        
        private string GhiChu;

        public string sGhiChu
        {
            get { return GhiChu; }
            set { GhiChu = value; }
        }
        private bool KhongSuDung;

        public bool bKhongSuDung
        {
            get { return KhongSuDung; }
            set { KhongSuDung = value; }
        }
        private string UserID;

        public string sUserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        private decimal fChietKhau;

        public decimal FChietKhau
        {
            get { return fChietKhau; }
            set { fChietKhau = value; }
        }

        private string _sPhanLoai;

        public string SPhanLoai
        {
            get { return _sPhanLoai; }
            set { _sPhanLoai = value; }
        }

        public DataTable LoadDSDBCLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("SanPham_LayDSDBC", thamsoinput);
        }

        public DataTable SanPham_LayDSSanPhamlenMutiCombo()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("SanPham_LayDSSanPhamlenMutiCombo", null);
        }

        //public DataTable LoadDSNSXLenCombobox()
        //{
            //CDuLieu LopDL = new CDuLieu();
            //SqlParameter[] thamsoinput = { new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            //thamsoinput[0].Value = false;

            //return LopDL.LoadTable("SanPham_LayDSNSX", thamsoinput);
        //}

        public DataTable LoadDSDVTLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("SanPham_LayDSDVT", thamsoinput);
        }

        public DataTable LoadDSNhomSPLenCombobox()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@KhongSuDung", SqlDbType.Bit) };
            thamsoinput[0].Value = false;

            return LopDL.LoadTable("SanPham_LayDSNhomSP", thamsoinput);
        }

        public string LuuSanPham(CSQLSanPham objSanPham)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@MaSP", SqlDbType.VarChar, 20), 
                                             new SqlParameter("@MaVach", SqlDbType.VarChar, 200), 
                                             new SqlParameter("@TenSP", SqlDbType.NVarChar, 500), 
                                             new SqlParameter("@DBCid", SqlDbType.VarChar), 
                                             new SqlParameter("@DVNhapID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVXuatID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVBanID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVChuanID", SqlDbType.VarChar), 
                                             new SqlParameter("@HDSD", SqlDbType.NVarChar), 
                                             //new SqlParameter("@NSXid", SqlDbType.VarChar), 
                                             new SqlParameter("@NhomSPid", SqlDbType.VarChar), 
                                             new SqlParameter("@GiaMuaChuaTAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@GiaMuaChuaTAXHT", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXht", SqlDbType.Decimal), 
                                             new SqlParameter("@Note", SqlDbType.NVarChar), 
                                             new SqlParameter("@IsKhongDung", SqlDbType.Bit), 
                                             new SqlParameter("@UserID", SqlDbType.VarChar), 
                                             new SqlParameter("@HoatChat", SqlDbType.NVarChar),
                                             new SqlParameter("@PhanTramChietKhauHT", SqlDbType.Decimal),
                                             new SqlParameter("@PhanLoai", SqlDbType.VarChar)
                                         };
            thamsoinput[0].Value = objSanPham.sMaSP;
            thamsoinput[1].Value = objSanPham.sMaVach;
            thamsoinput[2].Value = objSanPham.sTenSP;
            //if (objSanPham.sDBCid == "")
            //{
            //    thamsoinput[3].Value = (Guid.Empty).ToString();
            //}
            //else
            //{
                thamsoinput[3].Value = objSanPham.sDBCid;
            //}
            
            thamsoinput[4].Value = objSanPham.sDVNhapID;
            thamsoinput[5].Value = objSanPham.sDVXuatID;
            thamsoinput[6].Value = objSanPham.sDVBanID;
            thamsoinput[7].Value = objSanPham.sDVChuanID;
            thamsoinput[8].Value = objSanPham.sHDSD;
            //thamsoinput[9].Value = objSanPham.sNSXid;
            thamsoinput[9].Value = objSanPham.sNhomID;
            thamsoinput[10].Value = objSanPham.dGiaMuaChuaTAXKyTruoc;
            thamsoinput[10].Precision = 38;
            thamsoinput[10].Scale = 15;
            thamsoinput[11].Value = objSanPham.dTAXKyTruoc;
            thamsoinput[11].Precision = 38;
            thamsoinput[11].Scale = 15;
            thamsoinput[12].Value = objSanPham.dGiaMuaChuaTAXHT;
            thamsoinput[12].Precision = 38;
            thamsoinput[12].Scale = 15;
            thamsoinput[13].Value = objSanPham.dTAXHT;
            thamsoinput[13].Precision = 38;
            thamsoinput[13].Scale = 15;
            thamsoinput[14].Value = objSanPham.sGhiChu;
            thamsoinput[15].Value = objSanPham.bKhongSuDung;
            thamsoinput[16].Value = objSanPham.sUserID;
            thamsoinput[17].Value = objSanPham.sHoatChat;
            thamsoinput[18].Value = objSanPham.fChietKhau;
            thamsoinput[18].Precision = 38;
            thamsoinput[18].Scale = 15;
            thamsoinput[19].Value = objSanPham.SPhanLoai;

            SqlParameter SPidfromTable = new SqlParameter("@SPid", SqlDbType.VarChar, 50);
            return LopDL.CapNhatDuLieu("SanPham_ThemMoi", thamsoinput, SPidfromTable); ;
        }

        public string SuaSanPham(CSQLSanPham objSanPham)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@SPid", SqlDbType.VarChar, 50), 
                                             new SqlParameter("@MaSP", SqlDbType.VarChar, 20), 
                                             new SqlParameter("@MaVach", SqlDbType.VarChar, 200), 
                                             new SqlParameter("@TenSP", SqlDbType.NVarChar, 500), 
                                             new SqlParameter("@DBCid", SqlDbType.VarChar), 
                                             new SqlParameter("@DVNhapID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVXuatID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVBanID", SqlDbType.VarChar),
                                             new SqlParameter("@DVChuanID", SqlDbType.VarChar), 
                                             new SqlParameter("@HDSD", SqlDbType.NVarChar), 
                                             //new SqlParameter("@NSXid", SqlDbType.VarChar), 
                                             new SqlParameter("@NhomSPid", SqlDbType.VarChar), 
                                             new SqlParameter("@GiaMuaChuaTAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@GiaMuaChuaTAXHT", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXht", SqlDbType.Decimal), 
                                             new SqlParameter("@Note", SqlDbType.NVarChar), 
                                             new SqlParameter("@IsKhongDung", SqlDbType.Bit), 
                                             new SqlParameter("@UserID", SqlDbType.VarChar), 
                                             new SqlParameter("@HoatChat", SqlDbType.NVarChar),
                                             new SqlParameter("@PhanTramChietKhauHT", SqlDbType.Decimal),
                                             new SqlParameter("@PhanLoai", SqlDbType.VarChar)};
            thamsoinput[0].Value = objSanPham.sSPid;
            thamsoinput[1].Value = objSanPham.sMaSP;
            thamsoinput[2].Value = objSanPham.sMaVach;
            thamsoinput[3].Value = objSanPham.sTenSP;
            //if (objSanPham.sDBCid == "")
            //{
            //    thamsoinput[4].Value = (Guid.Empty).ToString();
            //}
            //else
            //{
                thamsoinput[4].Value = objSanPham.sDBCid;
            //}
            thamsoinput[5].Value = objSanPham.sDVNhapID;
            thamsoinput[6].Value = objSanPham.sDVXuatID;
            thamsoinput[7].Value = objSanPham.sDVBanID;
            thamsoinput[8].Value = objSanPham.sDVChuanID;
            thamsoinput[9].Value = objSanPham.sHDSD;
            //thamsoinput[10].Value = objSanPham.sNSXid;
            thamsoinput[10].Value = objSanPham.sNhomID;
            thamsoinput[11].Value = objSanPham.dGiaMuaChuaTAXKyTruoc;
            thamsoinput[11].Precision = 38;
            thamsoinput[11].Scale = 15;
            thamsoinput[12].Value = objSanPham.dTAXKyTruoc;
            thamsoinput[12].Precision = 38;
            thamsoinput[12].Scale = 15;
            thamsoinput[13].Value = objSanPham.dGiaMuaChuaTAXHT;
            thamsoinput[13].Precision = 38;
            thamsoinput[13].Scale = 15;
            thamsoinput[14].Value = objSanPham.dTAXHT;
            thamsoinput[14].Precision = 38;
            thamsoinput[14].Scale = 15;
            thamsoinput[15].Value = objSanPham.sGhiChu;
            thamsoinput[16].Value = objSanPham.bKhongSuDung;
            thamsoinput[17].Value = objSanPham.sUserID;
            thamsoinput[18].Value = objSanPham.sHoatChat;
            thamsoinput[19].Value = objSanPham.fChietKhau;
            thamsoinput[19].Precision = 38;
            thamsoinput[19].Scale = 15;
            thamsoinput[20].Value = objSanPham.SPhanLoai;

            SqlParameter KetQuaTraVe = new SqlParameter("@KQSua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("SanPham_Sua", thamsoinput, KetQuaTraVe);
        }

        public DataTable LoadDSSanPhamLenLuoi(bool IsXemTatCa)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] XemTatCa = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            XemTatCa[0].Value = IsXemTatCa;

            return LopDL.LoadTable("SanPham_LayDanhSach", XemTatCa);
        }

        public DataTable KiemTraMaSPTruocKhiThem(string MaSP)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaSPcanKiemTra = { new SqlParameter("@MaSP", SqlDbType.VarChar,20) };
            MaSPcanKiemTra[0].Value = MaSP;

            return LopDL.LoadTable("SanPham_KiemTraMaSPKhiThemMoi", MaSPcanKiemTra);
        }

        public DataTable KiemTraMaVachTruocKhiThem(string MaVach)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] MaVachcanKiemTra = { new SqlParameter("@MaVach", SqlDbType.VarChar, 200) };
            MaVachcanKiemTra[0].Value = MaVach;

            return LopDL.LoadTable("SanPham_KiemTraMaVachKhiThemMoi", MaVachcanKiemTra);
        }

        public DataTable KiemTraMaSPTruocKhiSua(string MaSP,string SPid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] ThamSoInput = { new SqlParameter("@MaSP", SqlDbType.VarChar, 20), 
                                           new SqlParameter("@SPid", SqlDbType.VarChar, 50) };
            ThamSoInput[0].Value = MaSP;
            ThamSoInput[1].Value = SPid;

            return LopDL.LoadTable("SanPham_KiemTraMaSPKhiSua", ThamSoInput);
        }

        public DataTable KiemTraMaVachTruocKhiSua(string MaVach, string SPid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] ThamSoInput = { new SqlParameter("@MaVach", SqlDbType.VarChar, 200), new SqlParameter("@SPid", SqlDbType.VarChar, 50) };
            ThamSoInput[0].Value = MaVach;
            ThamSoInput[1].Value = SPid;

            return LopDL.LoadTable("SanPham_KiemTraMaVachKhiSua", ThamSoInput);
        }

        public DataTable LaySanPhamCanSua(string SPid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] SPidcanTim = { new SqlParameter("@SPid", SqlDbType.VarChar, 50) };
            SPidcanTim[0].Value = SPid;

            return LopDL.LoadTable("SanPham_TimSanPhamTheoMa", SPidcanTim);
        }

        public string XoaSanPham(string SPid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@SPid", SqlDbType.NVarChar, 50) };
            thamsoinput[0].Value = SPid;

            SqlParameter KetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("SanPham_Xoa", thamsoinput, KetQua);
        }

        public DataTable LaySanPhamTheoSPID(string SPID)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = SPID;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SanPham_LaySanPhamTheoSPID", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LaySanPhamTheoMaSP(string MaSP)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaSP", SqlDbType.VarChar) };
            thamso[0].Value = MaSP;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SanPham_LaySanPhamTheoMaSP", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LaySanPhamTheoMaSP_SPID_TenSP()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("SanPham_LaySanPhamTheoMaSP_SPID_TenSP", null);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LaySanPhamChuaThietLapHSQD()
        {
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("SanPham_LaySanPhamChuaThietLapHSQD", null);
        }

        public int CapNhatHeSoQuyDoiChuanTon(string spid, string dvtid,string userid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamso = {new SqlParameter("@SanPhamID", SqlDbType.VarChar),
                                     new SqlParameter("@DVChuan", SqlDbType.VarChar),
                                    new SqlParameter("@UserID", SqlDbType.VarChar)
                                  };
            thamso[0].Value = spid;
            thamso[1].Value = dvtid;
            thamso[2].Value = userid;
            return LopDL.ThucThiTraVeKetQuaKieuInt("SanPham_CapNhatDonViChuan", thamso);
        }

        public string LayHeSoQuiDoiChuanTheoMaSP(string spid)
        {
             CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamso = {new SqlParameter("@SPID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            DataTable dtb = LopDL.LoadTable("SanPham_LayHeSoQuiDoiChuanTheoMaSP", thamso);
            string kq = "";
            if (dtb!=null&& dtb.Rows.Count > 0)
            {
                kq = dtb.Rows[0][0].ToString();
            }
            return kq;
        }

        /// <summary>
        /// Hàm kiểm tra mã sản phẩm có tồn tại trong kho hay không
        /// Hay kiểm tra mã sản phẩm tồn tại nhưng số lượng bằng 0
        /// </summary>
        /// <param name="masp">SPID của sản phẩm cần kiểm tra</param>
        /// <returns>false: Không tồn tại mã SP trong bảng Tồn kho / True: Tồn tại mã SP trong bảng Tồn kho</returns>
        public bool KiemTraMaSanPhamTonKho(string masp)
        {
            CDuLieu lopdl = new CDuLieu();
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = masp;
            DataTable dtb = lopdl.LoadTable("SanPham_KiemTraTonKho", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                string kq = dtb.Rows[0][0].ToString(); //false: không tồn tại; true: tồn tại
                if (kq.CompareTo("1") == 0)
                    return true;
                else
                {
                    if (kq.CompareTo("0") == 0)
                        return false;
                    else
                        return true;
                }
            }
            else
            {
                return true;
            }
        }

        //public string LayNSXIDMacDinh(string spid)
        //{
        //                CDuLieu lopdl = new CDuLieu();
        //    SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
        //    thamso[0].Value = spid;
        //    DataTable dtb = lopdl.LoadTable("SanPham_LayNSXMacDinh", thamso);
        //    string maNSX = "";
        //    if(dtb !=null && dtb.Rows.Count>0)
        //    {
        //        maNSX = dtb.Rows[0][0].ToString();                
        //    }
        //    return maNSX;
        //}


        public int SanPham_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayMaxCapNhat", null);
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
        public int SanPham_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_LayMaxCapNhat", null);
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
        public int SanPham_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayMaxThemMoi", null);
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
        public int SanPham_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        public DataTable SanPham_LayDSSanPhamChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SanPham_LayDSSanPhamChuaCapNhatTaiNT", thamso);
        }
        public DataTable SanPham_LayDSSanPhamChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("SanPham_LayDSSanPhamChuaThemMoiTaiNT", thamso);
        }
        public void SanPham_DongBoThemDanhMuc(DataTable dsSanPhamChuaThemMoi, string tdgspid)
        {
            if (dsSanPhamChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPhamChuaThemMoi.Rows)
                {
                    #region chuan bi du lieu cho bang thay doi gia sp
                    CSQLNTThayDoiGiaSPCT nttdgspct = new CSQLNTThayDoiGiaSPCT();
                    CSQLNTThayDoiGiaSP nttdgsp = new CSQLNTThayDoiGiaSP();
                    CSQLSanPham sp = new CSQLSanPham();
                    string spid = dr["SPID"].ToString();
                    decimal giaMuaChuaTaxTheoDVChuanEco_Moi = decimal.Parse(dr["GiaMuaChuaTAXHT"].ToString());
                    decimal giaMuaChuaTaxTheoDVChuanNT_HT = 0;
                    //decimal giaBanCoTaxTheoDVChuanNT_HT
                    //decimal giaBanCoTaxTheoDCChuanECO_Moi
                    //decimal giaBanCoTaxTheoDVBanNT_HT = sp.SanPham_LayGiaBanCoTaxTheoDVBanNT_HT(spid);
                    //decimal giaBanCoTaxTheoDVBanECO_Moi = sp.SanPham_LayGiaBanCoTaxTheoDVBanECO_Moi(spid);
                    //decimal giaBanCoTaxTheoDVNhapNT_HT = sp.SanPham_LayGiaBanCoTaxTheoDVNhapNT_HT(spid);
                    //decimal giaBanCoTaxTheoDVNhapECO_Moi = sp.SanPham_LayGiaBanCoTaxTheoDVNhapECO_Moi(spid);

                    #endregion chuan bi du lieu cho bang thay doi gia sp

                    #region Them danh muc san pham
                    SqlParameter[] thamso = { new SqlParameter("@SPid", SqlDbType.VarChar, 50), 
                                             new SqlParameter("@MaSP", SqlDbType.VarChar, 20), 
                                             new SqlParameter("@MaVach", SqlDbType.VarChar, 200), 
                                             new SqlParameter("@TenSP", SqlDbType.NVarChar, 500), 
                                             new SqlParameter("@DBCid", SqlDbType.VarChar), 
                                             new SqlParameter("@DVNhapID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVXuatID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVBanID", SqlDbType.VarChar),
                                             new SqlParameter("@DVChuanID", SqlDbType.VarChar), 
                                             new SqlParameter("@HDSD", SqlDbType.NVarChar), 
                                             //new SqlParameter("@NSXid", SqlDbType.VarChar), 
                                             new SqlParameter("@NhomSPid", SqlDbType.VarChar), 
                                             new SqlParameter("@GiaMuaChuaTAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@GiaMuaChuaTAXHT", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXht", SqlDbType.Decimal), 
                                             new SqlParameter("@Note", SqlDbType.NVarChar), 
                                             new SqlParameter("@IsKhongDung", SqlDbType.Bit), 
                                             new SqlParameter("@LastUD", SqlDbType.DateTime),
                                             new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                             new SqlParameter("@UserID", SqlDbType.VarChar), 
                                             new SqlParameter("@HoatChat", SqlDbType.NVarChar),
                                             new SqlParameter("@PhanTramChietKhauKyTruoc", SqlDbType.Decimal),
                                             new SqlParameter("@PhanTramChietKhauHT", SqlDbType.Decimal),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@hcid", SqlDbType.VarChar)
                                            };
                    thamso[0].Value = dr["SPid"].ToString();
                    thamso[1].Value = dr["MaSP"].ToString();
                    thamso[2].Value = dr["MaVach"].ToString();
                    thamso[3].Value = dr["TenSP"].ToString();
                    if (dr["DBC"].ToString() != null && dr["DBC"].ToString().Length > 0)
                        thamso[4].Value = dr["DBC"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVNhap"].ToString() != null && dr["DVNhap"].ToString().Length > 0)
                        thamso[5].Value = dr["DVNhap"].ToString();
                    else
                        thamso[5].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVXuat"].ToString() != null && dr["DVXuat"].ToString().Length > 0)
                        thamso[6].Value = dr["DVXuat"].ToString();
                    else
                        thamso[6].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVBan"].ToString() != null && dr["DVBan"].ToString().Length > 0)
                        thamso[7].Value = dr["DVBan"].ToString();
                    else
                        thamso[7].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVChuan"].ToString() != null && dr["DVChuan"].ToString().Length > 0)
                        thamso[8].Value = dr["DVChuan"].ToString();
                    else
                        thamso[8].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[9].Value = dr["HDSD"].ToString();
                    if (dr["NhomID"].ToString() != null && dr["NhomID"].ToString().Length > 0)
                        thamso[10].Value = dr["NhomID"].ToString();
                    else
                        thamso[10].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[11].Value = decimal.Parse(dr["GiaMuaChuaTAXKyTruoc"].ToString());
                    thamso[12].Value = decimal.Parse(dr["TAXKyTruoc"].ToString());
                    thamso[13].Value = decimal.Parse(dr["GiaMuaChuaTAXHT"].ToString());
                    thamso[14].Value = decimal.Parse(dr["TAXht"].ToString());
                    thamso[15].Value = dr["GhiChu"].ToString();
                    thamso[16].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[17].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[18].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[19].Value = CStaticBien.SmaTaiKhoan;
                    thamso[20].Value = dr["HoatChat"].ToString();
                    thamso[21].Value = decimal.Parse(dr["PhanTramChietKhauKyTruoc"].ToString());
                    thamso[22].Value = decimal.Parse(dr["PhanTramChietKhauHT"].ToString());
                    thamso[23].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[24].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[25].Value = bool.Parse(dr["IsXoa"].ToString());
                    if (dr["hcid"].ToString() != null && dr["hcid"].ToString().Length > 0)
                        thamso[26].Value = dr["hcid"].ToString();
                    else
                        thamso[26].Value = "00000000-0000-0000-0000-000000000000";

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SanPham_DongBoThemDanhMuc", thamso, null);
                    #endregion

                    #region ghi vao thay doi gia sp
                    CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                    string nsxmacdinh = spnsx.LayNSXUuTienMacDinh(spid);
                    if (nsxmacdinh == null || nsxmacdinh.Length == 0)
                        nsxmacdinh = "00000000-0000-0000-0000-000000000000";
                    DataTable tblDVNhapDVBanDVChuan = new DataTable();
                    tblDVNhapDVBanDVChuan = SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(spid);
                    string DVNhapid="";
                    string DVBanid="";
                    string DVChuanid="";
                    if (tblDVNhapDVBanDVChuan.Rows.Count > 0)
                    {
                        DVNhapid = tblDVNhapDVBanDVChuan.Rows[0]["DVNhap"].ToString();
                        DVBanid = tblDVNhapDVBanDVChuan.Rows[0]["DVBan"].ToString();
                        DVChuanid = tblDVNhapDVBanDVChuan.Rows[0]["DVChuan"].ToString();
                    }
                    nttdgspct.NTThayDoiGiaSPCT_Them(tdgspid, spid, nsxmacdinh, giaMuaChuaTaxTheoDVChuanNT_HT, giaMuaChuaTaxTheoDVChuanEco_Moi,DVNhapid,DVBanid,DVChuanid);
                    #endregion ghi vao thay doi gia sp
                }
            }
        }
        public void SanPham_DongBoSuaDanhMuc(DataTable dsSanPhamChuaCapNhat, string tdgspid)
        {
            if (dsSanPhamChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsSanPhamChuaCapNhat.Rows)
                {
                    #region ghi vao thay doi gia sp
                    CSQLNTThayDoiGiaSPCT nttdgspct = new CSQLNTThayDoiGiaSPCT();
                    CSQLNTThayDoiGiaSP nttdgsp = new CSQLNTThayDoiGiaSP();
                    CSQLSanPham sp = new CSQLSanPham();
                    string spid = dr["SPID"].ToString();
                    decimal giaMuaChuaTaxTheoDVChuanEco_Moi = decimal.Parse(dr["GiaMuaChuaTAXHT"].ToString());
                    decimal giaMuaChuaTaxTheoDVChuanNT_HT = sp.SanPham_LayGiaMuaTheoDVChuan_HT(spid);
                    //decimal giaBanCoTaxTheoDVBanNT_HT = sp.SanPham_LayGiaBanCoTaxTheoDVBanNT_HT(spid);
                    //decimal giaBanCoTaxTheoDVBanECO_Moi = sp.SanPham_LayGiaBanCoTaxTheoDVBanECO_Moi(spid);
                    //decimal giaBanCoTaxTheoDVNhapNT_HT = sp.SanPham_LayGiaBanCoTaxTheoDVNhapNT_HT(spid);
                    //decimal giaBanCoTaxTheoDVNhapECO_Moi = sp.SanPham_LayGiaBanCoTaxTheoDVNhapECO_Moi(spid);

                    #region sua danh muc
                    SqlParameter[] thamso = { new SqlParameter("@SPid", SqlDbType.VarChar, 50), 
                                             new SqlParameter("@MaSP", SqlDbType.VarChar, 20), 
                                             new SqlParameter("@MaVach", SqlDbType.VarChar, 200), 
                                             new SqlParameter("@TenSP", SqlDbType.NVarChar, 500), 
                                             new SqlParameter("@DBCid", SqlDbType.VarChar), 
                                             new SqlParameter("@DVNhapID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVXuatID", SqlDbType.VarChar), 
                                             new SqlParameter("@DVBanID", SqlDbType.VarChar),
                                             new SqlParameter("@DVChuanID", SqlDbType.VarChar), 
                                             new SqlParameter("@HDSD", SqlDbType.NVarChar), 
                                             //new SqlParameter("@NSXid", SqlDbType.VarChar), 
                                             new SqlParameter("@NhomSPid", SqlDbType.VarChar), 
                                             new SqlParameter("@GiaMuaChuaTAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXKyTruoc", SqlDbType.Decimal), 
                                             new SqlParameter("@GiaMuaChuaTAXHT", SqlDbType.Decimal), 
                                             new SqlParameter("@TAXht", SqlDbType.Decimal), 
                                             new SqlParameter("@Note", SqlDbType.NVarChar), 
                                             new SqlParameter("@IsKhongDung", SqlDbType.Bit), 
                                             new SqlParameter("@LastUD", SqlDbType.DateTime),
                                             new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                             new SqlParameter("@UserID", SqlDbType.VarChar), 
                                             new SqlParameter("@HoatChat", SqlDbType.NVarChar),
                                             new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                             new SqlParameter("@PhanTramChietKhauKyTruoc", SqlDbType.Decimal),
                                             new SqlParameter("@PhanTramChietKhauHT", SqlDbType.Decimal),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@hcid", SqlDbType.VarChar)
                                            };
                    thamso[0].Value = dr["SPid"].ToString();
                    thamso[1].Value = dr["MaSP"].ToString();
                    thamso[2].Value = dr["MaVach"].ToString();
                    thamso[3].Value = dr["TenSP"].ToString();
                    if (dr["DBC"].ToString() != null && dr["DBC"].ToString().Length > 0)
                        thamso[4].Value = dr["DBC"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVNhap"].ToString() != null && dr["DVNhap"].ToString().Length > 0)
                        thamso[5].Value = dr["DVNhap"].ToString();
                    else
                        thamso[5].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVXuat"].ToString() != null && dr["DVXuat"].ToString().Length > 0)
                        thamso[6].Value = dr["DVXuat"].ToString();
                    else
                        thamso[6].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVBan"].ToString() != null && dr["DVBan"].ToString().Length > 0)
                        thamso[7].Value = dr["DVBan"].ToString();
                    else
                        thamso[7].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["DVChuan"].ToString() != null && dr["DVChuan"].ToString().Length > 0)
                        thamso[8].Value = dr["DVChuan"].ToString();
                    else
                        thamso[8].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[9].Value = dr["HDSD"].ToString();
                    if (dr["NhomID"].ToString() != null && dr["NhomID"].ToString().Length > 0)
                        thamso[10].Value = dr["NhomID"].ToString();
                    else
                        thamso[10].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[11].Value = decimal.Parse(dr["GiaMuaChuaTAXKyTruoc"].ToString());
                    thamso[12].Value = decimal.Parse(dr["TAXKyTruoc"].ToString());
                    thamso[13].Value = decimal.Parse(dr["GiaMuaChuaTAXHT"].ToString());
                    thamso[14].Value = decimal.Parse(dr["TAXht"].ToString());
                    thamso[15].Value = dr["GhiChu"].ToString();
                    thamso[16].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[17].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[18].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[19].Value = CStaticBien.SmaTaiKhoan;
                    thamso[20].Value = dr["HoatChat"].ToString();
                    thamso[21].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[22].Value = decimal.Parse(dr["PhanTramChietKhauKyTruoc"].ToString());
                    thamso[23].Value = decimal.Parse(dr["PhanTramChietKhauHT"].ToString());
                    thamso[24].Value = bool.Parse(dr["IsXoa"].ToString());
                    if (dr["hcid"].ToString() != null && dr["hcid"].ToString().Length > 0)
                        thamso[25].Value = dr["hcid"].ToString();
                    else
                        thamso[25].Value = "00000000-0000-0000-0000-000000000000";

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("SanPham_DongBoSuaDanhMuc", thamso, null);
                    #endregion sua danh muc

                    #region ghi vao thay doi gia sp tiep theo
                    CSQLSanPham_NSX spnsx = new CSQLSanPham_NSX();
                    string nsxmacdinh = spnsx.LayNSXUuTienMacDinh(spid);
                    if (nsxmacdinh == null || nsxmacdinh.Length == 0)
                        nsxmacdinh = "00000000-0000-0000-0000-000000000000";
                    #endregion ghi vao thay doi gia sp


                    DataTable tblDVNhapDVBanDVChuan = new DataTable();
                    tblDVNhapDVBanDVChuan = SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(spid);
                    string DVNhapid = "00000000-0000-0000-0000-000000000000";
                    string DVBanid = "00000000-0000-0000-0000-000000000000";
                    string DVChuanid = "00000000-0000-0000-0000-000000000000";
                    if (tblDVNhapDVBanDVChuan.Rows.Count > 0)
                    {
                        DVNhapid = tblDVNhapDVBanDVChuan.Rows[0]["DVNhap"].ToString();
                        DVBanid = tblDVNhapDVBanDVChuan.Rows[0]["DVBan"].ToString();
                        DVChuanid = tblDVNhapDVBanDVChuan.Rows[0]["DVChuan"].ToString();
                    }
                    nttdgspct.NTThayDoiGiaSPCT_Them(tdgspid, spid, nsxmacdinh, giaMuaChuaTaxTheoDVChuanNT_HT, giaMuaChuaTaxTheoDVChuanEco_Moi, DVNhapid, DVBanid, DVChuanid);
                    #endregion
                }
            }
        }

        public decimal SanPham_LayGiaBanCoTaxTheoDVBanNT_HT (string sPID)
        {
            decimal kq;
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = sPID;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayGiaBanCoTaxTheoDVBan", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    kq = decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch { kq = 0; }
            }
            else kq = 0;
            return kq;
        }

        public decimal SanPham_LayGiaBanCoTaxTheoDVNhapNT_HT(string sPID) 
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = sPID;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayGiaBanCoTaxTheoDVNhap", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else return 0;
        }

        public decimal SanPham_LayGiaBanCoTaxTheoDVBanECO_Moi(string sPID)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = sPID;

            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_LayGiaBanCoTaxTheoDVBan", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else return 0;
        }

        public decimal SanPham_LayGiaBanCoTaxTheoDVNhapECO_Moi(string sPID)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = sPID;

            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("SanPham_LayGiaBanCoTaxTheoDVNhap", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else return 0;
        }

        public DataTable SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayDVNhap_DVXuat_DVBan_DVChuan_TheoSPID", thamso);
            return dtb;
        }

        public DataTable SanPham_LayDSSPLenMultiColumnCombobox()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("SanPham_LayDSSPLenMultiColumnCombobox", null);
        }

        public DataTable SanPham_NSX_LayDSSPLenMultiColumnCombobox()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dt = dl.LoadTable("SanPham_NSX_LayDSSPLenMultiColumnCombobox", null);
            return dt;
        }

        public decimal SanPham_LayGiaMuaTheoDVChuan_HT(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("SanPham_LayGiaMuaChuaTaxTheoDVChuan_HT", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else return 0;
        }
        public int KiemTraTrungMaSP(string masp_, string spid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@MaSP", SqlDbType.VarChar);
                SqlParameter nvid = new SqlParameter("@SPID", SqlDbType.VarChar);
                SqlParameter KQ = new SqlParameter("@kq", SqlDbType.Int);


                XemTC.Value = masp_;
                thamso[0] = XemTC;

                nvid.Value = spid_;
                thamso[1] = nvid;

                KQ.Direction = ParameterDirection.Output;
                thamso[2] = KQ;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("SanPham_KiemTraTrungMaSP", thamso);
                return int.Parse(thamso[2].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable SanPham_LaySPTheoMaSP(string masp, string ntid)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@MaSP", masp),
                                        new SqlParameter("@NTID", ntid)};

                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("SanPham_LaySPTheoMaSP_NTID", thamso);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public DateTime? KiemTraSanPhamCanDateTheoSPid(Guid SPid)
        {
            try
            {
                SqlParameter[] thamso = {
                                            new SqlParameter("@SPid", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Date", SqlDbType.Date)
                                        };

                thamso[0].Value = SPid;
                thamso[1].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThiTraVeKetQuaKieuInt("SanPham_KiemTraSanPhamCanDateTheoSPid", thamso);

                return DateTime.Parse(thamso[1].Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
