using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECOPharma2013.DuLieu;
using System.Data;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_LayPhieuChuyen
    { 
        public string LayThongTinChiNhanh()
        {
            try
            {
                CDuLieu dlrm = new CDuLieu();
                return dlrm.LoadTable("NT_NHANCHUYENHANG_LAYTHONGTINCHINHANH", null).Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayPhieuChuyenTuTongCTy(string ntid)
        {
            SqlParameter [] thamso = {   new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = ntid;
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try{
                return dlrm.LoadTable("NT_NHANCHUYENHANG_LAYTTCHUYENHANG_TUTONGCTY", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayPhieuChuyenChiTietTuTongCty(string nchid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar) };
            thamso[0].Value = nchid;
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.LoadTable("NT_NHANCHUYENHANGCT_LAYTTCHUYENHANG_TUTONGCTY", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CapNhatPhieuChuyenTaiTongCongTy(string nchid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NCHID", SqlDbType.VarChar) };
            thamso[0].Value = nchid;
            CDuLieuRemote dlrm = new CDuLieuRemote();
            try
            {
                return dlrm.ThucThiTraVeKetQuaKieuInt("NT_NHANCHUYENHANG_CAPNHATCHINHANHDATAIVE", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
