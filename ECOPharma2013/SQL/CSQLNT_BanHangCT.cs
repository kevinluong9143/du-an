using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_BanHangCT
    {
        public int Them(string bhid, string spid, string makho, decimal slban, string dvbanid, string lot, DateTime date, string giamgia, string nsxid,string bhctid, string tenmaythungan)
        {

            SqlParameter []thamso = {   new SqlParameter ("@BHID", SqlDbType.VarChar),
                                        new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@MaKho", SqlDbType.VarChar),
                                        new SqlParameter ("@SLBan", SqlDbType.Decimal),
                                        new SqlParameter ("@DVBanID", SqlDbType.VarChar),
                                        new SqlParameter ("@Lot", SqlDbType.VarChar),
                                        new SqlParameter ("@Date", SqlDbType.DateTime),
                                        new SqlParameter ("@GiamGia", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@BHCTID", SqlDbType.VarChar),
                                        new SqlParameter ("@TenMayThuNgan", SqlDbType.NVarChar)
                                    };

            thamso[0].Value = bhid;
            thamso[1].Value = spid;
            thamso[2].Value = makho;
            thamso[3].Value = slban;
            thamso[4].Value = dvbanid;
            thamso[5].Value = lot;
            thamso[6].Value = date;
            thamso[7].Value = giamgia;
            thamso[8].Value = nsxid;
            //if (bhctid.Length == 0)
            //{
            //    thamso[9].Value = "00000000-0000-0000-0000-000000000000";
            //}
            //else
            //{
                thamso[9].Value = bhctid;
            //}
                thamso[10].Value = tenmaythungan;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_BanHangCT_Them", thamso);
        }
        public DataTable LayLenLuoi(string bhid)
        {
            SqlParameter []thamso = {   new SqlParameter ("@BHID", SqlDbType.VarChar)};
            thamso[0].Value = bhid;
            
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BANHANGCT_LAYLENLUOI", thamso);
        }
        public DataTable LayINCHITIET(string bhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHID", SqlDbType.VarChar) };
            thamso[0].Value = bhid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BANHANGCT_INCHITIET", thamso);
        }
        public int Xoa(string BHCTid)
        {
            SqlParameter[] thamso = { new SqlParameter("@BHCTID", SqlDbType.VarChar) };
            thamso[0].Value = BHCTid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_BanHangCT_Xoa", thamso);
        }


        public DataTable LayDSBanHangDaThanhToanTheoSoCT(string soct)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCT", SqlDbType.VarChar) };
            thamso[0].Value = soct;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_BanHangCT_LayDSBanHangDaThanhToanTheoSoCT", thamso);
        }

        public bool KiemTraCoHangDacBiet(string BHid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@BHid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(BHid);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NT_BanHangCT_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        internal int ThemHangDacBiet(string bhid, string spid, decimal slban, string dvbanid, string lot, DateTime date, string giamgia, string nsxid, string bhctid, string tenmaythungan)
        {
            SqlParameter[] thamso = {   new SqlParameter ("@BHID", SqlDbType.VarChar),
                                        new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@MaKho", SqlDbType.VarChar),
                                        new SqlParameter ("@SLBan", SqlDbType.Decimal),
                                        new SqlParameter ("@DVBanID", SqlDbType.VarChar),
                                        new SqlParameter ("@Lot", SqlDbType.VarChar),
                                        new SqlParameter ("@Date", SqlDbType.DateTime),
                                        new SqlParameter ("@GiamGia", SqlDbType.VarChar),
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@BHCTID", SqlDbType.VarChar),
                                        new SqlParameter ("@TenMayThuNgan", SqlDbType.NVarChar)
                                    };

            thamso[0].Value = bhid;
            thamso[1].Value = spid;
            thamso[2].Value = "00000000-0000-0000-0000-000000000000";
            thamso[3].Value = slban;
            thamso[4].Value = dvbanid;
            thamso[5].Value = lot;
            thamso[6].Value = date;
            thamso[7].Value = giamgia;
            thamso[8].Value = nsxid;
            thamso[9].Value = bhctid;
            thamso[10].Value = tenmaythungan;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_BanHangCT_Them_HangDacBiet", thamso);
        }
    }
}
