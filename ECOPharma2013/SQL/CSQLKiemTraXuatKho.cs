using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLKiemTraXuatKho
    {
        public DataTable KiemTraXuatKho_LoadLenLuoi_IsXong(bool xong_)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXong", SqlDbType.Bit) };
            thamso[0].Value = xong_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("KiemTraXuatKho_LoadLenLuoi_IsXong", thamso);
            return dtb;
        }
        public DataTable KiemTraXuatKho_LoadLenLuoi(bool XemTatCa_)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = XemTatCa_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("KiemTraXuatKho_LoadLenLuoi", thamso);
            return dtb;
        }
        public DataTable KiemTraXuatKho_LayKTXKTheoMa(string ma_)
        {
            SqlParameter[] thamso = { new SqlParameter("@KTid", SqlDbType.VarChar) };
            thamso[0].Value = ma_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("KiemTraXuatKho_LayKTXKTheoMa", thamso);
            return dtb;
        }
        public int Update_IsXong_Date(string KTid_ )
        {
            SqlParameter[] thamso = { new SqlParameter("@KTid", SqlDbType.VarChar)};
            thamso[0].Value = KTid_;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("KiemTraXuatKho_Update_IsXong_Date", thamso);
        }
        public int Update_IsChuyenChiNhanh(string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXid", SqlDbType.VarChar) };
            thamso[0].Value = pxid_;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.ThucThiTraVeKetQuaKieuInt("KiemTraXuatKho_Update_IsChuyenChiNhanh", thamso);
        }

        public int XacNhanThucXuat()
        {
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("KiemTraXuatKho_XacNhanThucXuat", null);
        }

        public bool KiemTraTonTaiSoPX(string SoPX)
        {
            SqlParameter[] thamso = {  
                                        new SqlParameter("@SoPX", SqlDbType.VarChar, 12),
                                        new SqlParameter("@IsExist", SqlDbType.Bit)
                                    };

            thamso[0].Value = SoPX;
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("KiemTraXuatKho_KiemTraTonTaiSoPX", thamso);

            return Convert.ToBoolean(thamso[1].Value);
        }
    }
}
