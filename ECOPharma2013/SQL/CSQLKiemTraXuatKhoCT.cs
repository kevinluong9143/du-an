using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLKiemTraXuatKhoCT
    {
        public DataTable KiemTraXuatKhoCT_LayKTXKCT_TheoMa(string ma_)
        {
            SqlParameter[] thamso = { new SqlParameter("@KTid", SqlDbType.VarChar) };
            thamso[0].Value = ma_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("KiemTraXuatKhoCT_LayKTXKCT_TheoMa", thamso);
            return dtb;
        }
        public int Update_SoLuong_Date(string ktctid_, decimal slthucte_, string lotthucte_)
        {
            SqlParameter[] thamso = { new SqlParameter("@KTCTid", SqlDbType.VarChar),
                                    new SqlParameter("@SLThucTe", SqlDbType.Decimal),
                                    new SqlParameter("@LotThucTe", SqlDbType.VarChar)};
            thamso[0].Value = ktctid_;
            thamso[1].Value = slthucte_;
            thamso[2].Value = lotthucte_;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("KiemTraXuatKhoCT_Update_SoLuong_Date", thamso);
        }
    }
}
