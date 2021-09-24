using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_XacNhanNhapKho
    {
        public DataTable LayDSNTXacNhanNhapKhoLenLuoi()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_XacNhanPhieuNhap_LayLenLuoi", null);
        }

        public int XacNhanNhapKho(string pnid, bool tinhtrangxacnhan, string userxn)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PNID", SqlDbType.VarChar),
                                        new SqlParameter ("@XNPhieuNhap", SqlDbType.Bit),
                                        new SqlParameter ("@UserXN", SqlDbType.VarChar)
                                        //,new SqlParameter("@Message", SqlDbType.Int)
                                    };
            thamso[0].Value = pnid;
            thamso[1].Value = tinhtrangxacnhan;
            thamso[2].Value = userxn;
            //thamso[3].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_XacNhanPhieuNhap_XacNhan", thamso);

            //return int.Parse(thamso[3].Value.ToString());
        }
    }
}
