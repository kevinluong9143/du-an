using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_NhapKhoChiTiet
    {
        string _sPNCTid;

        public string SPNCTid
        {
            get { return _sPNCTid; }
            set { _sPNCTid = value; }
        }

        string _sPNid;

        public string SPNid
        {
            get { return _sPNid; }
            set { _sPNid = value; }
        }

        string _sSPid;

        public string SSPid
        {
            get { return _sSPid; }
            set { _sSPid = value; }
        }

        string _sNSPid;

        public string SNSPid
        {
            get { return _sNSPid; }
            set { _sNSPid = value; }
        }

        string _sMaKho;

        public string SMaKho
        {
            get { return _sMaKho; }
            set { _sMaKho = value; }
        }

        decimal _fSLXuat;

        public decimal FSLXuat
        {
            get { return _fSLXuat; }
            set { _fSLXuat = value; }
        }

        string _sDVT;

        public string SDVT
        {
            get { return _sDVT; }
            set { _sDVT = value; }
        }

        decimal _fGiaMuaChuaTAX;

        public decimal FGiaMuaChuaTAX
        {
            get { return _fGiaMuaChuaTAX; }
            set { _fGiaMuaChuaTAX = value; }
        }

        decimal _fTTGiaMuaChuaTAX;

        public decimal FTTGiaMuaChuaTAX
        {
            get { return _fTTGiaMuaChuaTAX; }
            set { _fTTGiaMuaChuaTAX = value; }
        }

        decimal _fGiaNKChuaTAX;

        public decimal FGiaNKChuaTAX
        {
            get { return _fGiaNKChuaTAX; }
            set { _fGiaNKChuaTAX = value; }
        }

        decimal _fTTGiaNKChuaTAX;

        public decimal FTTGiaNKChuaTAX
        {
            get { return _fTTGiaNKChuaTAX; }
            set { _fTTGiaNKChuaTAX = value; }
        }

        decimal _fTAX;

        public decimal FTAX
        {
            get { return _fTAX; }
            set { _fTAX = value; }
        }

        decimal _fTTTAX;

        public decimal FTTTAX
        {
            get { return _fTTTAX; }
            set { _fTTTAX = value; }
        }

        decimal _fTTGiaNKCoTAX;

        public decimal FTTGiaNKCoTAX
        {
            get { return _fTTGiaNKCoTAX; }
            set { _fTTGiaNKCoTAX = value; }
        }

        string _sLot;

        public string SLot
        {
            get { return _sLot; }
            set { _sLot = value; }
        }

        DateTime _dDate;

        public DateTime DDate
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        string _sMaNSX;

        public string SMaNSX
        {
            get { return _sMaNSX; }
            set { _sMaNSX = value; }
        }

        public CSQLNT_NhapKhoChiTiet() { }
        public CSQLNT_NhapKhoChiTiet(string pnctid, string pnid, string spid, string nspid, string makho, decimal slxuat, string dvt, decimal giamuachuatax, decimal ttgiamuachuatax, decimal giaxkchuatax, decimal ttgiaxkchuatax, decimal tax, decimal tttax, decimal ttgiaxkcotax, string lot, DateTime date, string mansx)
        {
            SPNCTid = pnctid;
            SPNid = pnid;
            SSPid = spid;
            SNSPid = nspid;
            SMaKho = makho;
            FSLXuat = slxuat;
            SDVT = dvt;
            FGiaMuaChuaTAX = giamuachuatax;
            FTTGiaMuaChuaTAX = ttgiamuachuatax;
            FGiaNKChuaTAX = giaxkchuatax;
            FTTGiaNKChuaTAX = ttgiaxkchuatax;
            FTAX = tax;
            FTTTAX = tttax;
            FTTGiaNKCoTAX = ttgiaxkcotax;
            SLot = lot;
            DDate = date;
            SMaNSX = mansx;
        }
        public DataTable LayDanhSachLenLuoi(string pnid)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@PNid", SqlDbType.VarChar);
                XemTC.Value = pnid;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_NhapKhoChiTiet_LayDanhSachLenLuoi", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public DataTable LoadECOPhieuXuatCT_theo_SoPX(string sopx_)
        {
            SqlParameter[] thamso = {new SqlParameter("@PXid", SqlDbType.VarChar)};
            thamso[0].Value = sopx_;

            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NT_NhapKhoChiTiet_LoadECOPhieuXuatCT_TheoSoPX", thamso);
            return dtb;
        }
        public string ThemMoi(CSQLNT_NhapKhoChiTiet nt_nhapkhoct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@PNCTid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@PNid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar), 
                                        new SqlParameter("@NSPid", SqlDbType.VarChar), 
                                        new SqlParameter("@MaKho", SqlDbType.VarChar), 
                                        new SqlParameter("@SLXuat", SqlDbType.Decimal), 
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        new SqlParameter("@GiaMuaChuaTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaMuaChuaTAX", SqlDbType.Decimal),
                                        new SqlParameter("@GiaXKChuaTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaXKChuaTAX", SqlDbType.Decimal),
                                        new SqlParameter("@TAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@TTGiaXKCoTAX", SqlDbType.Decimal), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime), 
                                        new SqlParameter("@MaNSX", SqlDbType.VarChar)};
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = nt_nhapkhoct.SPNid;
            thamso[2].Value = nt_nhapkhoct.SSPid;
            thamso[3].Value = nt_nhapkhoct.SNSPid;
            thamso[4].Value = nt_nhapkhoct.SMaKho;
            thamso[5].Value = nt_nhapkhoct.FSLXuat;
            thamso[6].Value = nt_nhapkhoct.SDVT;
            thamso[7].Value = nt_nhapkhoct.FGiaMuaChuaTAX;
            thamso[8].Value = nt_nhapkhoct.FTTGiaMuaChuaTAX;
            thamso[9].Value = nt_nhapkhoct.FGiaNKChuaTAX;
            thamso[10].Value = nt_nhapkhoct.FTTGiaNKChuaTAX;
            thamso[11].Value = nt_nhapkhoct.FTAX;
            thamso[12].Value = nt_nhapkhoct.FTTTAX;
            thamso[13].Value = nt_nhapkhoct.FTTGiaNKCoTAX;
            thamso[14].Value = nt_nhapkhoct.SLot;
            thamso[15].Value = nt_nhapkhoct.DDate;
            thamso[16].Value = nt_nhapkhoct.SMaNSX;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_NhapKhoChiTiet_ThemMoi", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

       public void ChinhSuaKhoNhap(DataTable dsKhoCanCapNhat)
        {
            if (dsKhoCanCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsKhoCanCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@PNCTid", SqlDbType.VarChar, 50), 
                                               new SqlParameter("@MaKho", SqlDbType.VarChar) };
                    thamso[0].Value = dr["PNCTid"].ToString();
                    thamso[1].Value = dr["MaKho"].ToString();
                    
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NT_NhapKhoCT_ChinhSuaKhoNhap", thamso, null);
                }
            }
        }

       public int ChinhSuaKhoNhap(string pnctid, string makho)
       {
           try
           {
               SqlParameter[] thamso = { new SqlParameter("@PNCTid", SqlDbType.VarChar, 50), 
                                               new SqlParameter("@MaKho", SqlDbType.VarChar) };
               thamso[0].Value = pnctid;
               thamso[1].Value = makho;

               CDuLieu dl = new CDuLieu();
               return dl.ThucThiTraVeKetQuaKieuInt("NT_NhapKhoCT_ChinhSuaKhoNhap", thamso);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
