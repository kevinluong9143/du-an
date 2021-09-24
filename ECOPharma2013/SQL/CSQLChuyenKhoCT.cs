using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLChuyenKhoCT
    {
        public CSQLChuyenKhoCT() { }

        string _sCKCTid;

        public string SCKCTid
        {
            get { return _sCKCTid; }
            set { _sCKCTid = value; }
        }

        string _sCKid;

        public string SCKid
        {
            get { return _sCKid; }
            set { _sCKid = value; }
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
        decimal _decSLChuyen;

        public decimal DecSLChuyen
        {
            get { return _decSLChuyen; }
            set { _decSLChuyen = value; }
        }
        string _sDVT;

        public string SDVT
        {
            get { return _sDVT; }
            set { _sDVT = value; }
        }
        string _sTuKho;

        public string STuKho
        {
            get { return _sTuKho; }
            set { _sTuKho = value; }
        }
        string _sDenKho;

        public string SDenKho
        {
            get { return _sDenKho; }
            set { _sDenKho = value; }
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
        decimal _decGiaXKChuaTax;

        public decimal DecGiaXKChuaTax
        {
            get { return _decGiaXKChuaTax; }
            set { _decGiaXKChuaTax = value; }
        }

        decimal _decTTGiaXKChuaTax;

        public decimal DecTTGiaXKChuaTax
        {
            get { return _decTTGiaXKChuaTax; }
            set { _decTTGiaXKChuaTax = value; }
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
        decimal _decTTGiaXKCoTax;

        public decimal DecTTGiaXKCoTax
        {
            get { return _decTTGiaXKCoTax; }
            set { _decTTGiaXKCoTax = value; }
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

        public string Them(CSQLChuyenKhoCT ckct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@CKCTid", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@CKid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                        new SqlParameter("@SLChuyen", SqlDbType.Decimal),
                                        new SqlParameter("@DVTid", SqlDbType.VarChar),
                                        new SqlParameter("@FrommKhoID", SqlDbType.VarChar),
                                        new SqlParameter("@DestinationKhoID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime)
                                        
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = ckct.SCKid;
            thamso[2].Value = ckct.SSPid;
            thamso[3].Value = ckct.SNSXID;
            thamso[4].Value = ckct.DecSLChuyen;
            thamso[5].Value = ckct.SDVT;
            thamso[6].Value = ckct.STuKho;
            thamso[7].Value = ckct.SDenKho;
            thamso[8].Value = ckct.SLot;
            thamso[9].Value = ckct.DDate;

            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("ChuyenKhoCT_Them", thamso, null);
            string kq = thamso[0].Value.ToString();
            if (kq != null && kq.Length > 0)
            {
                return kq;
            }
            else
                return "";
        }

        public DataTable LayTTCKCTTheoCKid(string ckid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = ckid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("ChuyenKhoCT_LayTTCKCTTheoCKid", thamso);
        }
        public DataTable In_CK_CKCTT(string ckid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKid", SqlDbType.VarChar, 50) };
            thamso[0].Value = ckid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("ChuyenKhoCT_In_CK_CKCTT", thamso);
        }

        public int XoaTTChuyenKhoCT(string _PCKCTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKCTid", SqlDbType.VarChar) };
            thamso[0].Value = _PCKCTid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("ChuyenKhoCT_XoaTTChuyenKhoCT", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        public string DeleteAll(string ckid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@CKid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };

            thamso[0].Value = new Guid(ckid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("ChuyenKhoCT_XoaTatCa", thamso);

            return thamso[1].Value.ToString();
        }
        public DataTable BaoCaoChuyenKho_LoadDataTheoSoCK(string sophieuchuyen)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPCK", SqlDbType.VarChar, 12) };
            thamso[0].Value = sophieuchuyen;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoChuyenKho_LoadDataTheoSoCK", thamso);
        }
    }
}
