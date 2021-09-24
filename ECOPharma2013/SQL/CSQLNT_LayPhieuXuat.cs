using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_LayPhieuXuat
    {
        public DataTable LoadDanhSachLenLuoi(string ttcnn)
        {
            try
            {
                SqlParameter[] thamso = {
                                            new SqlParameter("@TTCN", SqlDbType.VarChar),
                                            new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                        };

                CSQLCauHinhHeThong chht = new CSQLCauHinhHeThong();
                thamso[0].Value = ttcnn;
                thamso[1].Value = chht.KiemTraTrangThaiXemKhoDacBiet();

                CDuLieuRemote dl = new CDuLieuRemote();
                DataTable dtb = dl.LoadTable("NT_LayPhieuXuat_LoadDanhSachLenLuoi", thamso);
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
