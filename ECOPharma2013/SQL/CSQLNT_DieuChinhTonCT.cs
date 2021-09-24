using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_DieuChinhTonCT
    {
        public CSQLNT_DieuChinhTonCT() { }

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

        public string ThemMoi(CSQLNT_DieuChinhTonCT nt_dctkct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCTKCTid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@DCTKid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                        new SqlParameter("@SLCanChinh", SqlDbType.Decimal), 
                                        new SqlParameter("@DVTid", SqlDbType.VarChar),
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@GiaMuaChuaTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaMuaChuaTAX", SqlDbType.Decimal),
                                        new SqlParameter("@GiaDCChuaTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaDCChuaTAX", SqlDbType.Decimal),
                                        new SqlParameter("@TAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaDCCoTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime), 
                                        };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nt_dctkct.SDCTKid;
            thamso[2].Value = nt_dctkct.SSPid;
            thamso[3].Value = nt_dctkct.SNSXID;
            thamso[4].Value = nt_dctkct.DecSLCanChinh;
            thamso[5].Value = nt_dctkct.SDVT;
            thamso[6].Value = nt_dctkct.SKho;
            thamso[7].Value = nt_dctkct.DecGiaMuaChuaTax;
            thamso[8].Value = nt_dctkct.DecTTGiaMuaChuaTAX;
            thamso[9].Value = nt_dctkct.DecGiaDCChuaTAX;
            thamso[10].Value = nt_dctkct.DecTTGiaDCChuaTAX;
            thamso[11].Value = nt_dctkct.DecTax;
            thamso[12].Value = nt_dctkct.DecTTTax;
            thamso[13].Value = nt_dctkct.DecTTGiaDCCoTAX;
            thamso[14].Value = nt_dctkct.SLot;
            thamso[15].Value = nt_dctkct.DDate;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_DieuChinhTonKhoCT_ThemMoi", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }
        public DataTable LayTT_DCTKCT_Theo_DCTKid(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCTKid;

            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DieuChinhTonKhoCT_LayTT_DCTKCT_Theo_DCTKid", thamso);
        }

        public DataTable LayTT_DCTKCT_TheoMa(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCTKid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_DieuChinhTonKhoCT_LayTT_DCTKCT_Theo_DCTKid", thamso);
        }

        public DataTable IN_NTDCTK_NTDCTKCT(string DCTKid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCTKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCTKid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_DieuChinhTonKhoCT_IN_NTDCTK_NTDCTKCT", thamso);
        }
    }
}
