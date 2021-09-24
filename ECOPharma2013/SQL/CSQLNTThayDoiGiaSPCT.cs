using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNTThayDoiGiaSPCT
    {
        public int NTThayDoiGiaSPCT_Them(string tDGID, string sPID, string NSXID, decimal GiaMuaChuaTaxHT, decimal GiaMuaChuaTaxmoi,string DVNhapid,string DVBanid,string DVChuanid)
        {
            SqlParameter[] thamso = {new SqlParameter("@TDGID", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@GiaMuaChuaTaxHT", SqlDbType.Decimal),
                                        new SqlParameter("@GiaMuaChuaTaxMoi", SqlDbType.Decimal),
                                        new SqlParameter("@DVNhapid", SqlDbType.VarChar),
                                            new SqlParameter("@DVBanid", SqlDbType.VarChar),
                                                new SqlParameter("@DVChuanid", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tDGID;
            thamso[1].Value = sPID;
            thamso[2].Value = NSXID;
            thamso[3].Value = GiaMuaChuaTaxHT;
            thamso[4].Value = GiaMuaChuaTaxmoi;
            thamso[5].Value = DVNhapid;
            thamso[6].Value = DVBanid;
            thamso[7].Value = DVChuanid;
            try
            {
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSPCT_Them", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int NTThayDoiGiaSPCT_Them_DoiDinhGia(string tDGID, string sPID, decimal dinhGiaMoi)
        {
            SqlParameter[] thamso = {new SqlParameter("@TDGID", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@DinhGiaMoi", SqlDbType.Decimal)
                                    };
            thamso[0].Value = tDGID;
            thamso[1].Value = sPID;
            thamso[2].Value = dinhGiaMoi;
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSPCT_Them_DoiDinhGia", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadLenLuoi(string tdgid)
        {
            SqlParameter[] thamso = {new SqlParameter("@TDGID", SqlDbType.VarChar)};
            thamso[0].Value = tdgid;
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("NTTHAYDOIGIASPCT_LOADLENLUOI", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable In_TDGSP_TDGSPTT(string TDGid)
        {
            SqlParameter[] thamso = { new SqlParameter("@TDGid", SqlDbType.VarChar, 50) };
            thamso[0].Value = TDGid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NTTHAYDOIGIASPCT_In_TDGSP_TDGSPTT", thamso);
        }

        public int NTThayDoiGiaSPCT_CapNhatGia()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NTThayDoiGiaSP_CapNhatGia", null);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BaoCaoNTTHAYDOIGIASPCT_TuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNTTHAYDOIGIASPCT_TuNgay_DenNgay", thamso);
        }
    }
}
