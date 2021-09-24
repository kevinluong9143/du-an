using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNhapXuatTon
    {
        public DataTable LayDanhSachNhapXuatTonLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapXuatTon_LoadNhapXuatTonLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDSNhapXuatTonTuNgay_DenNgay(DateTime tungay_, DateTime denngay_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[2];
                SqlParameter XemTC = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                XemTC.Value = tungay_;
                thamso[0] = XemTC;
                SqlParameter XemTC1 = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                XemTC1.Value = denngay_;
                thamso[1] = XemTC1;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapXuatTon_LoadNhapXuatTonTuNgay_DenNgay", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public DataTable LayDSNhapXuatTonTuNgay_DenNgay_MaSP(DateTime tungay_, DateTime denngay_, string spid_)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[3];
                SqlParameter XemTC = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                XemTC.Value = tungay_;
                thamso[0] = XemTC;
                SqlParameter XemTC1 = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                XemTC1.Value = denngay_;
                thamso[1] = XemTC1;
                SqlParameter XemTC2 = new SqlParameter("@SPID", SqlDbType.VarChar);
                XemTC2.Value = spid_;
                thamso[2] = XemTC2;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NhapXuatTon_LoadNhapXuatTonTuNgay_DenNgay_MaSP", thamso);
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
