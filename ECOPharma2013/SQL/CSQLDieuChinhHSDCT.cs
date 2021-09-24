using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLDieuChinhHSDCT
    {
        public CSQLDieuChinhHSDCT() { }

        string _sDCHSDCTid;

        public string SDCHSDCTid
        {
            get { return _sDCHSDCTid; }
            set { _sDCHSDCTid = value; }
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

        decimal _decGiaMuaChuaTax;

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

        public DataTable LayMaSP_TenSP()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhHanSuDung_LayMaTenSP", null);
        }

        public string Them(CSQLDieuChinhHSDCT dctkct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DCHDCTid", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@DCHDid", SqlDbType.VarChar),
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar),
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@DateSai", SqlDbType.DateTime),
                                        new SqlParameter("@DateDung", SqlDbType.DateTime),
                                        new SqlParameter("@NTid", SqlDbType.VarChar)
                                        
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = dctkct.SDCHDid;
            thamso[2].Value = dctkct.SSPid;
            thamso[3].Value = dctkct.SNSXID;
            thamso[4].Value = dctkct.SKho;
            thamso[5].Value = dctkct.SLot;
            thamso[6].Value = dctkct.DDateSai;
            thamso[7].Value = dctkct.DDateDung;
            thamso[8].Value = dctkct._sMaNTid;

            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("DieuChinhHSDCT_Them", thamso, null);
            string kq = thamso[0].Value.ToString();
            if (kq != null && kq.Length > 0)
            {
                return kq;
            }
            else
                return "";
        }

        public DataTable LayTT_DCHSDCT_Theo_DCHSDid(string DCHSDid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCHDid", SqlDbType.VarChar, 50) };
            thamso[0].Value = DCHSDid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DieuChinhHSDCT_LayTT_DCHDCT_Theo_DCHDid", thamso);
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
        public int XoaTTDieuChinhHSDCT(string DCTKCTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DCHDCTid", SqlDbType.VarChar) };
            thamso[0].Value = DCTKCTid;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhHSDCT_XoaTTDieuChinhHSDCT", thamso);
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

        public string ImportMulti(DataTable ds, string NTid, string DCHDID)
        {
            try
            {
                SqlParameter[] thamso = { 
                                            new SqlParameter("@DataImport", SqlDbType.Structured),
                                            new SqlParameter("@NTID", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@DCHDID", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                         };
                ds.Columns.Remove("TENSP");
                ds.Columns.Remove("TenNSX");

                thamso[0].Value = ds;
                thamso[1].Value = new Guid(NTid);
                thamso[2].Value = new Guid(DCHDID);
                thamso[3].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DieuChinhHSD_ImportDanhSach", thamso);
                return thamso[3].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string XoaTatCa(string DCHDid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DCHDid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };

            thamso[0].Value = new Guid(DCHDid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("DieuChinhHSDCT_XoaTatCa", thamso);

            return thamso[1].Value.ToString();
        }
    }
}
