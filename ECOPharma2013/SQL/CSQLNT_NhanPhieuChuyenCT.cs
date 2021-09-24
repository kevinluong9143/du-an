using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhanPhieuChuyenCT
    {

        /// <summary>
        /// Thêm thông tin nhận phiếu chuyến chi tiết
        /// </summary>
        /// <param name="nchctid"></param>
        /// <param name="nchid"></param>
        /// <param name="spid"></param>
        /// <param name="nsxid"></param>
        /// <param name="slnhan"></param>
        /// <param name="dvtid"></param>
        /// <param name="giamuachuatax"></param>
        /// <param name="ttgiamuachuatax"></param>
        /// <param name="giankchuatax"></param>
        /// <param name="ttgiankchuatax"></param>
        /// <param name="tax"></param>
        /// <param name="tttax"></param>
        /// <param name="ttgiankcotax"></param>
        /// <param name="lot"></param>
        /// <param name="date"></param>
        /// <param name="timestampp"></param>
        /// <returns></returns>
        public int Them(string nchctid, string nchid, string spid, string nsxid, decimal slnhan, string dvtid, decimal giamuachuatax, decimal ttgiamuachuatax, decimal giankchuatax, decimal ttgiankchuatax, decimal tax, decimal tttax, decimal ttgiankcotax, string lot, DateTime date, DateTime timestampp)
        {
            SqlParameter[] thamso = {   new SqlParameter ("@NCHCTID", SqlDbType.VarChar),
                                         new SqlParameter ("@NCHID", SqlDbType.VarChar),
                                         new SqlParameter ("@SPID", SqlDbType.VarChar),
                                         new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                         new SqlParameter ("@SLNHAN", SqlDbType.Decimal),
                                         new SqlParameter ("@DVTID", SqlDbType.VarChar),
                                         new SqlParameter ("@GIAMUACHUATAX", SqlDbType.Decimal),
                                         new SqlParameter ("@TTGIAMUACHUATAX", SqlDbType.Decimal),
                                         new SqlParameter ("@GIANKCHUATAX", SqlDbType.Decimal),
                                         new SqlParameter ("@TTGIANKCHUATAX", SqlDbType.Decimal),
                                         new SqlParameter ("@TAX", SqlDbType.Decimal),
                                         new SqlParameter ("@TTTAX", SqlDbType.Decimal),
                                         new SqlParameter ("@TTGIANKCOTAX", SqlDbType.Decimal),
                                         new SqlParameter ("@LOT", SqlDbType.VarChar),
                                         new SqlParameter ("@DATE", SqlDbType.DateTime),
                                         new SqlParameter ("@TIMESTAMPP", SqlDbType.DateTime)
                                     };
            thamso[0].Value = nchctid;
            thamso[1].Value = nchid;
            thamso[2].Value = spid;
            thamso[3].Value = nsxid;
            thamso[4].Value = slnhan;
            thamso[5].Value = dvtid;
            thamso[6].Value = giamuachuatax;
            thamso[7].Value = ttgiamuachuatax;
            thamso[8].Value = giankchuatax;
            thamso[9].Value = ttgiankchuatax;
            thamso[10].Value = tax;
            thamso[11].Value = tttax;
            thamso[12].Value = ttgiankcotax;
            thamso[13].Value = lot;
            thamso[14].Value = date;
            thamso[15].Value = timestampp;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NT_NHANCHUYENHANGCT_THEM", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLenLuoi(string nchid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar) };
            thamso[0].Value = nchid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NT_NHANCHUYENHANGCT_LOADLENLUOI", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayKhoLenCBO()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NT_NHANCHUYENHANGCT_LAYKHONT", null);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int Sua(string nchctid, string khoid, string userud)
        {
            SqlParameter [] thamso = { new SqlParameter ("@NCHCTID", SqlDbType.VarChar),
                                         new SqlParameter ("@KHOID", SqlDbType.VarChar), 
                                         new SqlParameter ("@USERUD", SqlDbType.VarChar)};
            thamso[0].Value = nchctid;
            thamso[1].Value = khoid;
            thamso[2].Value = userud;
            CDuLieu dl = new CDuLieu();

            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NT_NHANCHUYENHANGCT_SUA", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
