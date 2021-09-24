using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_LayPhieuDieuChinhHSD
    {
        public DataTable LoadDanhSachLenLuoi(string ttcnn)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@TTCN", SqlDbType.VarChar);
                XemTC.Value = ttcnn;
                thamso[0] = XemTC;
                CDuLieuRemote dl = new CDuLieuRemote();
                DataTable dtb = dl.LoadTable("NT_LayPhieuDieuChinhHSD_LoadDanhSachLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
    }
}
