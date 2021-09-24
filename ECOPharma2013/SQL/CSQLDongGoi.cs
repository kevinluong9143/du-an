using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDongGoi
    {
        public DataTable LayDSDongGoi(bool xemtatca)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = xemtatca;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DongGoi_LoadLenLuoi", thamso);
        }

        public int DoDuLieuTuKiemTraXuatSangDongGoi()
        {
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("KiemTraXuatKho_DoDuLieuVaoDongGoi", null);
        }

        public int CapNhatXacNhanXong(string dgid, string userdg)
        {
            SqlParameter[] thamso = { new SqlParameter("@DGID", SqlDbType.VarChar),
                                        new SqlParameter ("@UserXacNhan", SqlDbType.VarChar)};
            thamso[0].Value = dgid;
            thamso[1].Value = userdg;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DongGoi_CapNhatXacNhanXong", thamso);
        }


        

        public int CapNhatNgayDongGoi(string dgid, string userdg)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DGID", SqlDbType.VarChar),
                                        new SqlParameter ("@UserDongGoi", SqlDbType.VarChar)};
            thamso[0].Value = dgid;
            thamso[1].Value = userdg;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DongGoi_CapNhatNgayDongGoi", thamso);
        }

        public DataTable LayThongTin_TheoDGID(string dgid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DGID", SqlDbType.VarChar)};
            thamso[0].Value = dgid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DongGoi_LayThongTin_TheoDGID", thamso);
        }

        public bool KiemTraDaXacNhan(string dgid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DGID", SqlDbType.VarChar),
                                        new SqlParameter("@IsXong", SqlDbType.Bit)};
            thamso[0].Value = dgid;
            thamso[1].Direction = ParameterDirection.Output;
            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("DongGoi_KiemTraDaXacNhan", thamso);
            if (thamso[1] != null)
                return (bool)thamso[1].Value;
            else
                return false;
        }
    }
}
