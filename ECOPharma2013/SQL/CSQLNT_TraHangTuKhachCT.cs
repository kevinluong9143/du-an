using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_TraHangTuKhachCT
    {
        /// <summary>
        /// Hàm lấy Sl có thể trả theo dvchuan và dvchuan của spid
        /// </summary>
        /// <param name="sophieuban"></param>
        /// <param name="spid"></param>
        /// <returns>Datatable với 2 giá trị là: SLCoTheTra & DVChuan của sản phẩm</returns>
        public DataTable NT_TraHangTuKhach_LaySLCoTheTra(string sophieuban, string bhctid, string spid, string lot, DateTime handung)
        {
            SqlParameter[] thamso = {new SqlParameter ("@SoPhieuBan", SqlDbType.VarChar),
                                        new SqlParameter ("@BHCTID", SqlDbType.VarChar),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter ("@lot", SqlDbType.VarChar),
                                    new SqlParameter ("@handung", SqlDbType.DateTime)};
            thamso[0].Value = sophieuban;
            thamso[1].Value = bhctid;
            thamso[2].Value = spid;
            thamso[3].Value = lot;
            thamso[4].Value = handung;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHangTuKhach_LaySLCoTheTra", thamso);
        }


                //@THID uniqueidentifier , 
                //@SPID uniqueidentifier, 
                //@MaKho uniqueidentifier, 
                //@SLDaBan decimal, 
                //@DVBanID uniqueidentifier, 
                //@LotBan varchar(50), 
                //@DateBan datetime, 
                //@SLTra decimal, 
                //@DVTraID uniqueidentifier, 
                //@DonGiaVonChuaTax decimal, 
                //@DonGiaTraChuaTaxChuaTinhPhiTraHang decimal, 
                //@PhiTraHang uniqueidentifier, 
                //@PhanTramTax decimal)

        public string Them(string thid, string bhctid, string spid,
            int stt, string makho, decimal sldaban, string dvbanid, string lotban, DateTime dateban, 
            decimal sltra, string dvtraid,
            decimal dongiavonchuatax, decimal dongiatrachuataxchuatinhphitrahang, 
            string phitrahang
            , decimal phantramtax, string nsxid
            )
        {
            SqlParameter[] thamso = {new SqlParameter ("@THID", SqlDbType.VarChar),
                                        new SqlParameter ("@BHCTID", SqlDbType.VarChar),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@STT", SqlDbType.Int),
                                         new SqlParameter("@MaKho", SqlDbType.VarChar),
                                         new SqlParameter("@SLDaBan", SqlDbType.Decimal),
                                         new SqlParameter("@DVBanID", SqlDbType.VarChar),
                                         new SqlParameter("@LotBan", SqlDbType.VarChar),
                                         new SqlParameter("@DateBan", SqlDbType.DateTime),
                                         new SqlParameter("@SLTra", SqlDbType.Decimal),
                                         new SqlParameter("@DVTraID", SqlDbType.VarChar),
                                         new SqlParameter("@DonGiaVonChuaTax", SqlDbType.Decimal),
                                         new SqlParameter("@DonGiaTraChuaTaxChuaTinhPhiTraHang", SqlDbType.Decimal),
                                         new SqlParameter("@PhiTraHang", SqlDbType.VarChar),
                                         new SqlParameter("@PhanTramTax", SqlDbType.Decimal),
                                         new SqlParameter("@NSXID", SqlDbType.VarChar),
                                         new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };
            thamso[0].Value = thid;
            thamso[1].Value = bhctid;
            thamso[2].Value = spid;
            thamso[3].Value = stt;
            thamso[4].Value = makho;
            thamso[5].Value = sldaban;
            thamso[6].Value = dvbanid;
            thamso[7].Value = lotban;
            thamso[8].Value = dateban;
            thamso[9].Value = sltra;
            thamso[10].Value = dvtraid;
            thamso[11].Value = dongiavonchuatax;
            thamso[12].Value = dongiatrachuataxchuatinhphitrahang;
            thamso[13].Value = phitrahang;
            thamso[14].Value = phantramtax;
            thamso[15].Value = nsxid;
            thamso[16].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            //return dl.ThucThiTraVeKetQuaKieuInt("NT_TraHangTuKhachCT_Them", thamso);

            dl.ThucThi("NT_TraHangTuKhachCT_Them", thamso);
            return thamso[16].Value.ToString();
        }

        public DataTable NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoTHID(string thid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = thid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoTHID", thamso);
        }


        public DataTable NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoSoCTTra(string socttra)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCTTra", SqlDbType.VarChar) };
            thamso[0].Value = socttra;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoSoCTTra", thamso);
        }

        public int NT_TraHangCT_Huy1CT(string thctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THCTID", SqlDbType.VarChar) };
            thamso[0].Value = thctid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_TraHangCT_Huy1CT", thamso);
        }

    }
}
