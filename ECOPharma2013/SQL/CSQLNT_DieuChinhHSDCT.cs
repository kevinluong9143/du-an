using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_DieuChinhHSDCT
    {
        public CSQLNT_DieuChinhHSDCT() { }

        string _sDCHDCTid;

        public string SDCHDCTid
        {
            get { return _sDCHDCTid; }
            set { _sDCHDCTid = value; }
        }

        string _sDCHDid;

        public string SDCHDid
        {
            get { return _sDCHDid; }
            set { _sDCHDid = value; }
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
        
        string _sKho;

        public string SKho
        {
            get { return _sKho; }
            set { _sKho = value; }
        }
        string _sLot;

        public string SLot
        {
            get { return _sLot; }
            set { _sLot = value; }
        }
        DateTime _dDateSai;

        public DateTime DDateSai
        {
            get { return _dDateSai; }
            set { _dDateSai = value; }
        }
        DateTime _dDateDung;

        public DateTime DDateDung
        {
            get { return _dDateDung; }
            set { _dDateDung = value; }
        }

        public string ThemMoi(CSQLNT_DieuChinhHSDCT nt_dchdct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCHDCTid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@DCHDid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@DateSai", SqlDbType.DateTime), 
                                        new SqlParameter("@DateDung", SqlDbType.DateTime)
                                        };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nt_dchdct.SDCHDid;
            thamso[2].Value = nt_dchdct.SSPid;
            thamso[3].Value = nt_dchdct.SNSXID;
            thamso[4].Value = nt_dchdct.SKho;
            thamso[5].Value = nt_dchdct.SLot;
            thamso[6].Value = nt_dchdct.DDateSai;
            thamso[7].Value = nt_dchdct.DDateDung;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_DieuChinhHSDCT_ThemMoi", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }
        public DataTable LayTT_DCHDCT_Theo_DCHDid(string DCHDid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCHDid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCHDid;

            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DieuChinhHSDCT_LayTT_DCHDCT_Theo_DCHDid", thamso);
        }

        public DataTable LayTT_DCHDCT_TheoMa(string DCHDid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCHDid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCHDid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_DieuChinhHSDCT_LayTT_DCHDCT_Theo_DCHDid", thamso);
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
