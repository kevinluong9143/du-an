using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLDieuChinhTonCT
    {
        public CSQLDieuChinhTonCT() { }

        string _sDCTKCTid;

        public string SDCTKCTid
        {
            get { return _sDCTKCTid; }
            set { _sDCTKCTid = value; }
        }

        string _sDCTKid;

        public string SDCTKid
        {
            get { return _sDCTKid; }
            set { _sDCTKid = value; }
        }
        string _sMaNTid;

        public string SMaNTid
        {
            get { return _sMaNTid; }
            set { _sMaNTid = value; }
        }

        string _sSPid;

        public string SSPid
        {
            get { return _sSPid; }
            set { _sSPid = value; }
        }
        string _sNSXID;

        public string SNSXID
        {
            get { return _sNSXID; }
            set { _sNSXID = value; }
        }
        decimal _decSLCanChinh;

        public decimal DecSLCanChinh
        {
            get { return _decSLCanChinh; }
            set { _decSLCanChinh = value; }
        }
        string _sDVT;

        public string SDVT
        {
            get { return _sDVT; }
            set { _sDVT = value; }
        }
        string _sKho;

        public string SKho
        {
            get { return _sKho; }
            set { _sKho = value; }
        }

        decimal _decGiaMuaChuaTax;

        public decimal DecGiaMuaChuaTax
        {
            get { return _decGiaMuaChuaTax; }
            set { _decGiaMuaChuaTax = value; }
        }

        decimal _decTTGiaMuaChuaTAX;

        public decimal DecTTGiaMuaChuaTAX
        {
            get { return _decTTGiaMuaChuaTAX; }
            set { _decTTGiaMuaChuaTAX = value; }
        }
        decimal _decGiaDCChuaTAX;

        public decimal DecGiaDCChuaTAX
        {
            get { return _decGiaDCChuaTAX; }
            set { _decGiaDCChuaTAX = value; }
        }

        decimal _decTTGiaDCChuaTAX;

        public decimal DecTTGiaDCChuaTAX
        {
            get { return _decTTGiaDCChuaTAX; }
            set { _decTTGiaDCChuaTAX = value; }
        }
        decimal _decTax;

        public decimal DecTax
        {
            get { return _decTax; }
            set { _decTax = value; }
        }

        decimal _decTTTax;

        public decimal DecTTTax
        {
            get { return _decTTTax; }
            set { _decTTTax = value; }
        }
        decimal _decTTGiaDCCoTAX;

        public decimal DecTTGiaDCCoTAX
        {
            get { return _decTTGiaDCCoTAX; }
            set { _decTTGiaDCCoTAX = value; }
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

        public DataTable LayMaSP_TenSP()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhTonKho_LayMaTenSP", null);
        }

        public string Them(CSQLDieuChinhTonCT dctkct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCTKCTid", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@DCTKid", SqlDbType.VarChar),
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                        new SqlParameter("@SLCanChinh", SqlDbType.Decimal),
                                        new SqlParameter("@DVTid", SqlDbType.VarChar),
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime),
                                        new SqlParameter("@NTid", SqlDbType.VarChar)
                                        
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = dctkct.SDCTKid;
            thamso[2].Value = dctkct.SSPid;
            thamso[3].Value = dctkct.SNSXID;
            thamso[4].Value = dctkct.DecSLCanChinh;
            thamso[5].Value = dctkct.SDVT;
            thamso[6].Value = dctkct.SKho;
            thamso[7].Value = dctkct.SLot;
            thamso[8].Value = dctkct.DDate;
            thamso[9].Value = dctkct._sMaNTid;

            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("DieuChinhTonKhoCT_Them", thamso, null);
            string kq = thamso[0].Value.ToString();
            if (kq != null && kq.Length > 0)
            {
                return kq;
            }
            else
                return "";
        }

        public DataTable LayTT_DCTKCT_Theo_DCTKid(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCTKid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhTonKhoCT_LayTT_DCTKCT_Theo_DCTKid", thamso);
        }

        public DataTable IN_DCTK_DCTKCT(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCTKid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhTonKhoCT_IN_DCTK_DCTKCT", thamso);
        }
        public DataTable BaoCaoKiemKe_LoadDataTheoSoPDC(string sophieudieuchinh)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPDC", SqlDbType.VarChar, 12) };
            thamso[0].Value = sophieudieuchinh;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoKiemKe_LoadDataTheoSoPDC", thamso);
        }

        public DataTable BaoCaoKiemKe_LoadDSTuNgay_DenNgay_NTID(string tungay_, string denngay_, string ntid_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            thamso[2].Value = ntid_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoKiemKe_LoadDSTuNgay_DenNgay_NTID", thamso);
        }
        public int XoaTTDieuChinhTonKhoCT(string DCTKCTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKCTid", SqlDbType.VarChar) };
            thamso[0].Value = DCTKCTid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKhoCT_XoaTTDieuChinhTonKhoCT", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public int UpdateKho_DieuChinhTonKhoCT(string _maDCTKCTid, string makhoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKCTid", SqlDbType.VarChar),
                                   new SqlParameter("@KhoID", SqlDbType.VarChar)};
            thamso[0].Value = _maDCTKCTid;
            thamso[1].Value = makhoid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKhoCT_UpdateKho_DieuChinhTonKhoCT", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public DataTable LayKho()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
               return  dl.LoadTable("DieuChinhTonKho_LayKho", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string Import(string masp, decimal slcanchinh, string lot, DateTime date, string ntid, string dctkid, string userid)
        //{
        //    SqlParameter [] thamso = { new SqlParameter("@MaSP", masp),
        //                                  new SqlParameter("@SLCanChinh", slcanchinh),
        //                                  new SqlParameter("@LOT", lot),
        //                                  new SqlParameter("@Date", date),
        //                                  new SqlParameter("@NTID", ntid),
        //                                  new SqlParameter("@DCTKID", dctkid),
        //                                  new SqlParameter("@UserID", userid)
        //                             };
        //    thamso[5].Direction = ParameterDirection.InputOutput;

        //    CDuLieu dl = new CDuLieu();
        //    int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoDieuChinhTonCT_Import", thamso);
        //    if(kq>0)
        //    {
        //        return thamso[5].Value.ToString();
        //    }
        //    else
        //    {
        //        return "00000000-0000-0000-0000-000000000000";
        //    }
        //}

        public int Import(string masp, decimal slcanchinh, string lot, DateTime date, string ntid, string dctkid, string userid)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaSP", masp),
                                          new SqlParameter("@SLCanChinh", slcanchinh),
                                          new SqlParameter("@LOT", lot),
                                          new SqlParameter("@Date", date),
                                          new SqlParameter("@NTID", ntid),
                                          new SqlParameter("@DCTKID", dctkid),
                                          new SqlParameter("@UserID", userid)
                                     };

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoDieuChinhTonCT_Import", thamso);
            return kq;
        }


        public string ImportMulti(DataTable ds, string NTid, string DCTKID)
        {
            try { 
                SqlParameter[] thamso = { 
                                            new SqlParameter("@DataImport", SqlDbType.Structured),
                                            new SqlParameter("@NTID", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@DCTKID", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                         };
                ds.Columns.Remove("TENSP");
                ds.Columns.Remove("TenNSX");
                ds.Columns.Remove("DVT");

                thamso[0].Value = ds;
                thamso[1].Value = new Guid(NTid);
                thamso[2].Value = new Guid(DCTKID);
                thamso[3].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhTonKho_ImportDanhSach", thamso);
                return thamso[3].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateKho_DieuChinhTonKhoCTMulti(string DCTKid, string NTid, DataTable dtDataSource)
        {
            try { 
                DataTable dtFinal = new DataTable();
                dtFinal.Columns.Add("DCTKCTid");
                dtFinal.Columns.Add("KhoID");
                CopyColumns(dtDataSource, dtFinal, "DCTKCTid", "KhoID");

                SqlParameter[] thamso = { 
                                            new SqlParameter("@DCTKid", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Data", SqlDbType.Structured),
                                            new SqlParameter("@NTid", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };

                thamso[0].Value = new Guid(DCTKid);
                thamso[1].Value = dtFinal;
                thamso[2].Value = new Guid(NTid);
                thamso[3].Direction = ParameterDirection.Output;
                CDuLieu dl = new CDuLieu();
                dl.ThucThi("DieuChinhTonKhoCT_UpdateKho_DieuChinhTonKhoCTMulti", thamso);
                return thamso[3].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
        {
            foreach (DataRow sourcerow in source.Rows)
            {
                DataRow destRow = dest.NewRow();
                foreach (string colname in columns)
                {
                    destRow[colname] = sourcerow[colname];
                }
                dest.Rows.Add(destRow);
            }
        }

        public string XoatTatCa(string DCTKid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DCTKid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };

            thamso[0].Value = new Guid(DCTKid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("EcoDieuChinhTonCT_XoaTatCa", thamso);

            return thamso[1].Value.ToString();
        }
    }
}
