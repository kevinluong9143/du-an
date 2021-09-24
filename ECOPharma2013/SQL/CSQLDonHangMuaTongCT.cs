using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangMuaTongCT
    {
        string sDHMTongCTid;

        public string SDHMTongCTid
        {
            get { return sDHMTongCTid; }
            set { sDHMTongCTid = value; }
        }
        string sDHMTongid;

        public string SDHMTongid
        {
            get { return sDHMTongid; }
            set { sDHMTongid = value; }
        }
        string sSPid;

        public string SSPid
        {
            get { return sSPid; }
            set { sSPid = value; }
        }
        string sNSPid;

        public string SNSPid
        {
            get { return sNSPid; }
            set { sNSPid = value; }
        }
        decimal dSLNhaThuocDat;

        public decimal DSLNhaThuocDat
        {
            get { return dSLNhaThuocDat; }
            set { dSLNhaThuocDat = value; }
        }
        decimal dSLConTon;

        public decimal DSLConTon
        {
            get { return dSLConTon; }
            set { dSLConTon = value; }
        }
        string sDVT;

        public string SDVT
        {
            get { return sDVT; }
            set { sDVT = value; }
        }
        decimal dSLDatMua;

        public decimal DSLDatMua
        {
            get { return dSLDatMua; }
            set { dSLDatMua = value; }
        }
        decimal dGiaMuaChuaTaxChuaChietKhau;

        public decimal DGiaMuaChuaTaxChuaChietKhau
        {
            get { return dGiaMuaChuaTaxChuaChietKhau; }
            set { dGiaMuaChuaTaxChuaChietKhau = value; }
        }
        decimal dTTGiaMuaChuaTaxChuaChietKhau;

        public decimal DTTGiaMuaChuaTaxChuaChietKhau
        {
            get { return dTTGiaMuaChuaTaxChuaChietKhau; }
            set { dTTGiaMuaChuaTaxChuaChietKhau = value; }
        }
        decimal dPhanTramChietKhau;

        public decimal DPhanTramChietKhau
        {
            get { return dPhanTramChietKhau; }
            set { dPhanTramChietKhau = value; }
        }
        decimal dTTChietKhau;

        public decimal DTTChietKhau
        {
            get { return dTTChietKhau; }
            set { dTTChietKhau = value; }
        }
        decimal dGiaMuaChuaTaxDaChietKhau;

        public decimal DGiaMuaChuaTaxDaChietKhau
        {
            get { return dGiaMuaChuaTaxDaChietKhau; }
            set { dGiaMuaChuaTaxDaChietKhau = value; }
        }
        decimal dTTGiaMuaChuaTaxDaChietKhau;

        public decimal DTTGiaMuaChuaTaxDaChietKhau
        {
            get { return dTTGiaMuaChuaTaxDaChietKhau; }
            set { dTTGiaMuaChuaTaxDaChietKhau = value; }
        }
        decimal dTAX;

        public decimal DTAX
        {
            get { return dTAX; }
            set { dTAX = value; }
        }
        decimal dTTTAX;

        public decimal DTTTAX
        {
            get { return dTTTAX; }
            set { dTTTAX = value; }
        }
        decimal dTTGiaMuaDaChietKhauCoTAX;

        public decimal DTTGiaMuaDaChietKhauCoTAX
        {
            get { return dTTGiaMuaDaChietKhauCoTAX; }
            set { dTTGiaMuaDaChietKhauCoTAX = value; }
        }
        string sLot;

        public string SLot
        {
            get { return sLot; }
            set { sLot = value; }
        }
        DateTime dDDate;

        public DateTime DDDate
        {
            get { return dDDate; }
            set { dDDate = value; }
        }
        string sNSXid;

        public string SNSXid
        {
            get { return sNSXid; }
            set { sNSXid = value; }
        }
        string sNPPid;

        public string SNPPid
        {
            get { return sNPPid; }
            set { sNPPid = value; }
        }
        string sGhiChu;

        public string SGhiChu
        {
            get { return sGhiChu; }
            set { sGhiChu = value; }
        }
        DateTime dLastUD;

        public DateTime DLastUD
        {
            get { return dLastUD; }
            set { dLastUD = value; }
        }
        string sNVUD;

        public string SNVUD
        {
            get { return sNVUD; }
            set { sNVUD = value; }
        }

        public CSQLDonHangMuaTongCT() { }

        public int Them(string dhid, string dhmtongid, string nvid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) ,
                                        new SqlParameter("@DHMTongid", SqlDbType.VarChar),
                                        new SqlParameter("@NVUD", SqlDbType.VarChar) 
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = dhmtongid;
            thamso[2].Value = nvid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("EcoDonHangMuaTongCT_Them", thamso);
        }

        public DataTable LoadLenLuoi(string dhmtid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHMTID", dhmtid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTongCT_LoadLenLuoi", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayToanBoDVT()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTongEdit_LayToanBoDVT", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDVTTheoSPID(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", spid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTongEdit_LayDVTTheoSPID", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SuaSLDatMua(string dhmtongctid, decimal sldatmua, string nvud)
        {
            SqlParameter[] thamso = {   new SqlParameter("@dhmtongctid", dhmtongctid),
                                                    new SqlParameter("@sldatmua", sldatmua),
                                                    new SqlParameter("@nvud", nvud)
                                                };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTongEdit_SuaSLDatMua", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMuaTongEdit_SuaNPP(@dhmtongctid uniqueidentifier,  @nppid uniqueidentifier, @nvud uniqueidentifier)
        public int SuaNPP(string dhmtongctid, string nppid, string nvud)
        {
            SqlParameter[] thamso = {   new SqlParameter("@dhmtongctid", dhmtongctid),
                                                    new SqlParameter("@nppid", nppid),
                                                    new SqlParameter("@nvud", nvud)
                                                };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTongEdit_SuaNPP", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMuaTongEdit_LayDonHangMuaTongCTTheoDHMTongID(@dhmtongctid uniqueidentifier)
        public DataTable Lay1DonHangMuaTongCTTheoDHMTongID(string dhmtongctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@dhmtongctid", dhmtongctid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTongEdit_LayDonHangMuaTongCTTheoDHMTongID", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMuaTongEdit_LaySanPhamLenMCBO
        public DataTable LaySanPhamLenMCBO()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTongEdit_LaySanPhamLenMCBO", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMuaTongEdit_Them(@DHMTongID uniqueidentifier, @SPNSXID uniqueidentifier,	@sldat decimal(38,15),	@dvtid uniqueidentifier, @nppid uniqueidentifier, @NVID uniqueidentifier)
        public int Them(string dhmtongid, string spnsxid, decimal sldat, string dvtid, string nppid, string nvid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHMTongID", dhmtongid),
                                    new SqlParameter("@SPNSXID", spnsxid),
                                    new SqlParameter("@sldat", sldat),
                                    new SqlParameter("@dvtid", dvtid),
                                    new SqlParameter("@nppid", nppid),      
                                    new SqlParameter("@NVID", nvid)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTongEdit_Them", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //create proc  DonHangMuaTongEdit_Xoa(@dhmtongctid uniqueidentifier)
        public int Xoa(string dhmtongctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@dhmtongctid", dhmtongctid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTongEdit_Xoa", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
