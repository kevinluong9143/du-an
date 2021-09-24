using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhapXuatTon
    {
        public DataTable LayDanhSachNT_NhapXuatTonLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_NhapXuatTon_LoadNT_NhapXuatTonLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDSNT_NhapXuatTonTuNgay_DenNgay(DateTime tungay_, DateTime denngay_)
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
                DataTable dtb = dl.LoadTable("NT_NhapXuatTon_LoadNT_NhapXuatTonTuNgay_DenNgay", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDSNT_NhapXuatTonTuNgay_DenNgay_MaSP(DateTime tungay_, DateTime denngay_, string spid_)
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
                DataTable dtb = dl.LoadTable("NT_NhapXuatTon_LoadNT_NhapXuatTonTuNgay_DenNgay_MaSP", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BaoCao_SLXuat_TuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCao_SLXuat_TuNgay_DenNgay", thamso);
        }

        public DataTable LaySLTon(string spid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@SPid", SqlDbType.UniqueIdentifier)
                                    };
            thamso[0].Value = new Guid(spid);

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_NhapXuatTon_IsDacBiet", thamso);
        }
    }
}
