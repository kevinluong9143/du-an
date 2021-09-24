using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNhapKhoChiTiet
    {
        string _sPNCTid;

        public string SPNCTid
        {
            get { return _sPNCTid; }
            set { _sPNCTid = value; }
        }

        string _sPNid;

        public string SPNid
        {
            get { return _sPNid; }
            set { _sPNid = value; }
        }

        string _sSPid;

        public string SSPid
        {
            get { return _sSPid; }
            set { _sSPid = value; }
        }

        string _sNSPid;

        public string SNSPid
        {
            get { return _sNSPid; }
            set { _sNSPid = value; }
        }

        string _sMaKho;

        public string SMaKho
        {
            get { return _sMaKho; }
            set { _sMaKho = value; }
        }

        decimal _fSLMua;

        public decimal FSLMua
        {
            get { return _fSLMua; }
            set { _fSLMua = value; }
        }

        decimal _fSLFree;

        public decimal FSLFree
        {
            get { return _fSLFree; }
            set { _fSLFree = value; }
        }

        decimal _fTongSL;

        public decimal FTongSL
        {
            get { return _fTongSL; }
            set { _fTongSL = value; }
        }

        string _sDVT;

        public string SDVT
        {
            get { return _sDVT; }
            set { _sDVT = value; }
        }

        decimal _fGiaMuaChuaTAX;

        public decimal FGiaMuaChuaTAX
        {
            get { return _fGiaMuaChuaTAX; }
            set { _fGiaMuaChuaTAX = value; }
        }

        decimal _fTTGiaMuaChuaTAX;

        public decimal FTTGiaMuaChuaTAX
        {
            get { return _fTTGiaMuaChuaTAX; }
            set { _fTTGiaMuaChuaTAX = value; }
        }

        decimal _fTAX;

        public decimal FTAX
        {
            get { return _fTAX; }
            set { _fTAX = value; }
        }

        decimal _fTTTAX;

        public decimal FTTTAX
        {
            get { return _fTTTAX; }
            set { _fTTTAX = value; }
        }

        decimal _fTTGiaMuaCoTAX;

        public decimal FTTGiaMuaCoTAX
        {
            get { return _fTTGiaMuaCoTAX; }
            set { _fTTGiaMuaCoTAX = value; }
        }

        string _sLot;

        public string SLot
        {
            get { return _sLot; }
            set { _sLot = value; }
        }

        DateTime _dDate;

        public DateTime DDate
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        string _sMaNSX;

        public string SMaNSX
        {
            get { return _sMaNSX; }
            set { _sMaNSX = value; }
        }

        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }

        string _sUserNhap;

        public string SUserNhap
        {
            get { return _sUserNhap; }
            set { _sUserNhap = value; }
        }

        public CSQLNhapKhoChiTiet() { }
        public CSQLNhapKhoChiTiet(string pnctid, string pnid, string spid, string nspid, string makho, decimal slmua, decimal slfree, decimal tongsl, string dvt, decimal giamuachuatax, decimal ttgiamuachuatax, decimal tax, decimal tttax, decimal ttgiamuacotax, string lot, DateTime date, string mansx)
        {
            SPNCTid = pnctid;
            SPNid = pnid;
            SSPid = spid;
            SNSPid = nspid;
            SMaKho = makho;
            FSLMua = slmua;
            FSLFree = slfree;
            FTongSL = tongsl;
            SDVT = dvt;
            FGiaMuaChuaTAX = giamuachuatax;
            FTTGiaMuaChuaTAX = ttgiamuachuatax;
            FTAX = tax;
            FTTTAX = tttax;
            FTTGiaMuaCoTAX = ttgiamuacotax;
            SLot = lot;
            DDate = date;
            SMaNSX = mansx;
        }

        public DataTable LayDanhSachNhapKhoChiTietLenLuoi(string pnid)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@PNid", SqlDbType.VarChar);
                XemTC.Value = pnid;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapKhoChiTiet_LoadNhapKhoChiTietLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public DataTable LayNhapKhoChiTietTheoPNCT(string PNCTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNCTid", SqlDbType.VarChar) };
            thamso[0].Value = PNCTid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhapKhoChiTiet_LayNhapKhoChiTietTheoPNCT", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayNhapKhoChiTietTheoPN(string PNid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNid", SqlDbType.VarChar) };
            thamso[0].Value = PNid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NhapKhoChiTiet_LayNhapKhoChiTietTheoPN", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BaoCaoNhapKho_LoadDataTheoSoCT(string SoChungTu)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCTN", SqlDbType.VarChar) };
            thamso[0].Value = SoChungTu;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("BaoCaoNhapKho_LoadDataTheoSoCT", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ThemMoiNhapKhoChiTiet(CSQLNhapKhoChiTiet nhapkhoct_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@PNCTid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@PNid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar), 
                                        new SqlParameter("@NSPid", SqlDbType.VarChar), 
                                        new SqlParameter("@MaKho", SqlDbType.VarChar), 
                                        new SqlParameter("@SLMua", SqlDbType.Decimal), 
                                        new SqlParameter("@SLFree", SqlDbType.Decimal), 
                                        new SqlParameter("@TongSL", SqlDbType.Decimal), 
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        //new SqlParameter("@GiaMuaChuaTAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTGiaMuaChuaTAX", SqlDbType.Decimal),
                                        //new SqlParameter("@TAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTTAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTGiaMuaCoTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime), 
                                        new SqlParameter("@MaNSX", SqlDbType.VarChar),
                                        new SqlParameter("@ghiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@UserID", SqlDbType.VarChar)};
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nhapkhoct_.SPNid;
            thamso[2].Value = nhapkhoct_.SSPid;
            thamso[3].Value = nhapkhoct_.SNSPid;
            thamso[4].Value = nhapkhoct_.SMaKho;
            thamso[5].Value = nhapkhoct_.FSLMua;
            thamso[6].Value = nhapkhoct_.FSLFree;
            thamso[7].Value = nhapkhoct_.FTongSL;
            thamso[8].Value = nhapkhoct_.SDVT;
            //thamso[9].Value = nhapkhoct_.FGiaMuaChuaTAX;
            //thamso[10].Value = nhapkhoct_.FTTGiaMuaChuaTAX;
            //thamso[9].Value = nhapkhoct_.FTAX;
            //thamso[10].Value = nhapkhoct_.FTTTAX;
            //thamso[13].Value = nhapkhoct_.FTTGiaMuaCoTAX;
            thamso[9].Value = nhapkhoct_.SLot;
            thamso[10].Value = nhapkhoct_.DDate;
            thamso[11].Value = nhapkhoct_.SMaNSX;
            thamso[12].Value = nhapkhoct_.SGhiChu;
            thamso[13].Value = nhapkhoct_.SUserNhap;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NhapKhoChiTiet_ThemMoiNhapKhoChiTiet", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public int SuaThongTinNhapKhoChiTiet(CSQLNhapKhoChiTiet nhapkhoct_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@PNCTid", SqlDbType.VarChar),
                                        new SqlParameter("@SPid", SqlDbType.VarChar), 
                                        new SqlParameter("@NSPid", SqlDbType.VarChar), 
                                        new SqlParameter("@MaKho", SqlDbType.VarChar), 
                                        new SqlParameter("@SLMua", SqlDbType.Decimal), 
                                        new SqlParameter("@SLFree", SqlDbType.Decimal), 
                                        new SqlParameter("@TongSL", SqlDbType.Decimal), 
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        //new SqlParameter("@GiaMuaChuaTAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTGiaMuaChuaTAX", SqlDbType.Decimal),
                                        //new SqlParameter("@TAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTTAX", SqlDbType.Decimal), 
                                        //new SqlParameter("@TTGiaMuaCoTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime), 
                                        new SqlParameter("@MaNSX", SqlDbType.VarChar)};
            thamso[0].Value = nhapkhoct_.SPNCTid;
            thamso[1].Value = nhapkhoct_.SSPid;
            thamso[2].Value = nhapkhoct_.SNSPid;
            thamso[3].Value = nhapkhoct_.SMaKho;
            thamso[4].Value = nhapkhoct_.FSLMua;
            thamso[5].Value = nhapkhoct_.FSLFree;
            thamso[6].Value = nhapkhoct_.FTongSL;
            thamso[7].Value = nhapkhoct_.SDVT;
            //thamso[8].Value = nhapkhoct_.FGiaMuaChuaTAX;
            //thamso[9].Value = nhapkhoct_.FTTGiaMuaChuaTAX;
            //thamso[10].Value = nhapkhoct_.FTAX;
            //thamso[11].Value = nhapkhoct_.FTTTAX;
            //thamso[12].Value = nhapkhoct_.FTTGiaMuaCoTAX;
            thamso[8].Value = nhapkhoct_.SLot;
            thamso[9].Value = nhapkhoct_.DDate;
            thamso[10].Value = nhapkhoct_.SMaNSX;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKhoChiTiet_ChinhSuaThongTinNhapKhoChiTiet", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public int XoaThongTinNhapKhoChiTiet(string _PNCTid, string UserID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNCTid", SqlDbType.VarChar),
                                        new SqlParameter("@UserID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = _PNCTid;
            thamso[1].Value = UserID;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NhapKhoChiTiet_XoaThongTinNhapKhoChiTiet", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int KiemTraTrungLoKhacDate(string SPid, string Lot, DateTime Date, string NSXid)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@SPid", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar), 
                                        new SqlParameter("@Date", SqlDbType.DateTime),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                    };
            thamso[0].Value = SPid;
            thamso[1].Value = Lot;
            thamso[2].Value = Date;
            thamso[3].Value = NSXid;

            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dt = dl.LoadTable("NhapKho_KiemTraTrungLoKhacDate", thamso);
                if (dt.Rows.Count == 1)
                {
                    return int.Parse(dt.Rows[0]["Result"].ToString());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public int KiemTraLotDateDieuChinhTonKho(string SPid, string Lot, DateTime Date, string NSXid)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@SPid", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar), 
                                        new SqlParameter("@Date", SqlDbType.DateTime),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar)
                                    };
            thamso[0].Value = SPid;
            thamso[1].Value = Lot;
            thamso[2].Value = Date;
            thamso[3].Value = NSXid;

            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dt = dl.LoadTable("DieuChinhTonKho_KiemTraLotDate", thamso);
                if (dt.Rows.Count == 1)
                {
                    return int.Parse(dt.Rows[0]["Result"].ToString());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable GetSPidFromMaSP(string MaSP)
        {
            DataTable dt = new DataTable();

            SqlParameter[] thamso = {  
                                        new SqlParameter("@MaSP", SqlDbType.VarChar)
                                    };
            thamso[0].Value = MaSP;

            CDuLieu dl = new CDuLieu();
            try
            {
                dt = dl.LoadTable("ECO_GetSanPhamFromMaSP", thamso);
                if (dt.Rows.Count == 1)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return dt;
                throw ex;
            }
        }

        public DataTable BaoCaoNhapKho_LoadDSTuNgay_DenNgay_NSXID(string tungay_, string denngay_, string NSXID_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = NSXID_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNhaCungCap_LoadDSTuNgay_DenNgay_NSXID", thamso);
        }

        public DataTable BaoCaoNhapKho_LoadDSTuNgay_DenNgay_NSX(string tungay_, string denngay_, string NSXID_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = NSXID_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNhaCungCap_LoadDSTuNgay_DenNgay_NSX", thamso);
        }

        public DataTable BaoCaoNhapKho_ChiTietTheoThang(string from, string to, string npp)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@From", SqlDbType.VarChar),
                                        new SqlParameter("@To", SqlDbType.VarChar),
                                        new SqlParameter("@NPPId", SqlDbType.VarChar)
                                    };
            thamso[0].Value = from;
            thamso[1].Value = to;
            thamso[2].Value = npp;
            
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCao_TongSLNhapKho_TheoThang_TheoNPP", thamso);
        }

        public DataTable BaoCaoNhapKho_ChiTietTheoThang_NSX(string from, string to, string nsx)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@From", SqlDbType.VarChar),
                                        new SqlParameter("@To", SqlDbType.VarChar),
                                        new SqlParameter("@NSXId", SqlDbType.VarChar)
                                    };
            thamso[0].Value = from;
            thamso[1].Value = to;
            thamso[2].Value = nsx;
            
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCao_TongSLNhapKho_TheoThang_TheoNSX", thamso);
        }

        public DataTable BaoCaoNhapKho_LoadDSTuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoNhaCungCap_LoadDSTuNgay_DenNgay]", thamso);
        }

        public DataTable BaoCaoNhapKho_LoadDSTuNgay_DenNgay_NgayTao(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("[BaoCaoNhaCungCap_LoadDSTuNgay_DenNgay_NgayTao]", thamso);
        }

        public string ImportDanhSach(DataTable Data, string SoPCK)
        {
            try { 
                SqlParameter[] thamso = { 
                                            new SqlParameter("@Data", SqlDbType.Structured),
                                            new SqlParameter("@SoPCK", SqlDbType.VarChar),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };

                thamso[0].Value = Data;
                thamso[1].Value = SoPCK;
                thamso[2].Direction = ParameterDirection.Output;
                CDuLieu dl = new CDuLieu();
                dl.ThucThi("ChuyenKhoCT_ThemMoiMulti", thamso);

                return thamso[2].Value.ToString();
            }
            catch (Exception ex) { 
                return ex.Message; 
            }
        }

        public bool KiemTraDanhSachChiTiet(string PNid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(PNid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NhapKhoChiTiet_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
    }
}