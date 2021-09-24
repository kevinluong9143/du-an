using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNhanTraHangCT
    {
        public int Them(string nthid, string spid, string nsxid, decimal sltra, string dvtid, decimal giamuachuatax, decimal ttgiamuachuatax, decimal giaxkchuatax, decimal ttgiaxkchuatax, decimal tax, decimal tttax, decimal ttgiaxkcotax, string lot, DateTime date, DateTime timestamps, int loaihangtra)
        {
            SqlParameter[] thamso = {   new SqlParameter("@nthid", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@SLTra", SqlDbType.Decimal),
                                        new SqlParameter("@DVTID", SqlDbType.VarChar),
                                        new SqlParameter("@GIAMUACHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAMUACHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@GIAXKCHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAXKCHUATAX", SqlDbType.Decimal),
                                        new SqlParameter("@TAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTTAX", SqlDbType.Decimal),
                                        new SqlParameter("@TTGIAXKCOTAX", SqlDbType.Decimal),
                                        new SqlParameter("@LOT", SqlDbType.VarChar),
                                        new SqlParameter("@DATE", SqlDbType.DateTime),
                                        new SqlParameter("@TIMESTAMPP", SqlDbType.DateTime),
                                        new SqlParameter("@LOAIHANGTRA", SqlDbType.Int)

                                    };
            thamso[0].Value = nthid;
            thamso[1].Value = spid;
            thamso[2].Value = nsxid;
            thamso[3].Value = sltra;
            thamso[4].Value = dvtid;
            thamso[5].Value = giamuachuatax;
            thamso[6].Value = ttgiamuachuatax;
            thamso[7].Value = giaxkchuatax;
            thamso[8].Value = ttgiaxkchuatax;
            thamso[9].Value = tax;
            thamso[10].Value = tttax;
            thamso[11].Value = ttgiaxkcotax;
            thamso[12].Value = lot;
            thamso[13].Value = date;
            thamso[14].Value = timestamps;
            thamso[15].Value = loaihangtra;
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.ThucThiTraVeKetQuaKieuInt("ECONHANTRAHANGCT_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Sua(string nthctid, string khoid)
        {
            SqlParameter[] thamso = {  new SqlParameter ("@NTHCTID", SqlDbType.VarChar),
                                         new SqlParameter ("@KHOID", SqlDbType.VarChar)};
            thamso[0].Value = nthctid;
            thamso[1].Value = khoid;

            CDuLieu dl = new CDuLieu();

            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("ECONHANTRAHANGCT_UPDATEKHO", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayKhoLenCBO(int loaihangtra, string nthid)
        {
            SqlParameter[] thamso = { new SqlParameter("@LoaiHangTra", SqlDbType.Int),
                                    new SqlParameter("@NTHID", SqlDbType.VarChar)};
            thamso[0].Value = loaihangtra;
            thamso[1].Value = nthid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NHANTRAHANGCT_LAYKHOCTY", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable LayNhanTraHangCT_NTHCTid(string nthctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTHCTID", SqlDbType.VarChar) };
            thamso[0].Value = nthctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NHANTRAHANGCT_LayNhanTraHangCT_NTHCTid", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable LayKho()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NHANTRAHANGCT_LAYKHO", null);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable BaoCaoNhaThuocTraHangVeCTY_LoadDSTuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNhaThuocTraHangVeCTY_LoadDSTuNgay_DenNgay", thamso);
        }

        public DataTable BaoCaoNhaThuocTraHangVeCTY_LoadDSTuNgay_DenNgay_DonHangTreo(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoNhaThuocTraHangVeCTY_LoadDSTuNgay_DenNgay_CHUAXACNHAN", thamso);
        }

    }
}
