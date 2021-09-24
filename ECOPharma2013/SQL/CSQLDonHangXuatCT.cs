using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangXuatCT
    {
        public CSQLDonHangXuatCT() { }
        string sDHCTid;

        public string SDHCTid
        {
            get { return sDHCTid; }
            set { sDHCTid = value; }
        }
        string sDHid;

        public string SDHid
        {
            get { return sDHid; }
            set { sDHid = value; }
        }
        string sSPid;

        public string SSPid
        {
            get { return sSPid; }
            set { sSPid = value; }
        }
        string sKhoid;

        public string SKhoid
        {
            get { return sKhoid; }
            set { sKhoid = value; }
        }
        string sNSPid;

        public string SNSPid
        {
            get { return sNSPid; }
            set { sNSPid = value; }
        }
        decimal fSLDat;

        public decimal FSLDat
        {
            get { return fSLDat; }
            set { fSLDat = value; }
        }
        decimal fSLDapUng;

        public decimal FSLDapUng
        {
            get { return fSLDapUng; }
            set { fSLDapUng = value; }
        }
        decimal fLConThieu;

        public decimal FLConThieu
        {
            get { return fLConThieu; }
            set { fLConThieu = value; }
        }
        string sDVT;

        public string SDVT
        {
            get { return sDVT; }
            set { sDVT = value; }
        }
        decimal fGiaMuaChuaTax;

        public decimal FGiaMuaChuaTax
        {
            get { return fGiaMuaChuaTax; }
            set { fGiaMuaChuaTax = value; }
        }
        decimal fTTGiaMuaChuaTax;

        public decimal FTTGiaMuaChuaTax
        {
            get { return fTTGiaMuaChuaTax; }
            set { fTTGiaMuaChuaTax = value; }
        }
        decimal fGiaXKChuaTax;

        public decimal FGiaXKChuaTax
        {
            get { return fGiaXKChuaTax; }
            set { fGiaXKChuaTax = value; }
        }
        decimal fTTGiaXKChuaTax;

        public decimal FTTGiaXKChuaTax
        {
            get { return fTTGiaXKChuaTax; }
            set { fTTGiaXKChuaTax = value; }
        }
        decimal fTax;

        public decimal FTax
        {
            get { return fTax; }
            set { fTax = value; }
        }
        decimal fTTTax;

        public decimal FTTTax
        {
            get { return fTTTax; }
            set { fTTTax = value; }
        }
        decimal fTTGiaXKCoTax;

        public decimal FTTGiaXKCoTax
        {
            get { return fTTGiaXKCoTax; }
            set { fTTGiaXKCoTax = value; }
        }
        string sLot;

        public string SLot
        {
            get { return sLot; }
            set { sLot = value; }
        }
        DateTime dDate;

        public DateTime DDate
        {
            get { return dDate; }
            set { dDate = value; }
        }
        string sNSXID;

        public string SNSXID
        {
            get { return sNSXID; }
            set { sNSXID = value; }
        }


        public string Them(CSQLDonHangXuatCT dhxct)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DHCTid", SqlDbType.VarChar), 
                                        new SqlParameter("@DHid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@Khoid", SqlDbType.VarChar),
                                        //new SqlParameter("@NSPid", SqlDbType.VarChar),
                                        new SqlParameter("@SLDat", SqlDbType.Decimal),
                                        new SqlParameter("@SLDapUng", SqlDbType.Decimal),
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@Date", SqlDbType.DateTime),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar)
                                    };
            thamso[0].Value = dhxct.SDHCTid;
            thamso[1].Value = dhxct.SDHid;
            thamso[2].Value = dhxct.SSPid;
            thamso[3].Value = dhxct.SKhoid;
            //thamso[4].Value = dhxct.SNSPid;
            thamso[4].Value = dhxct.FSLDat;
            thamso[5].Value = dhxct.FSLDapUng;
            thamso[6].Value = dhxct.SDVT;
            thamso[7].Value = dhxct.SLot;
            thamso[8].Value = dhxct.DDate;
            thamso[9].Value = dhxct.SNSXID;
            CDuLieu dl = new CDuLieu();
            dl.InsertDuLieu("DonHangXuatCT_Them", thamso, null);
            string kq = thamso[0].Value.ToString();
            if (kq != null && kq.Length > 0)
            {
                return kq;
            }
            else
                return "";
        }
        public DataTable LayTTDHXTheoDHXid(string dhxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHXid", SqlDbType.VarChar, 50) };
            thamso[0].Value = dhxid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("EcoDonHangXuatCT_LayTTDDHXChiTietTheoDHXid", thamso);
        }

        public DataTable IN_DHX_DHXCT(string dhxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHXid", SqlDbType.VarChar, 50) };
            thamso[0].Value = dhxid;

            CDuLieu dl = new CDuLieu();
            //return dl.LoadTable("DonHangXuatCT_IN_DHX_DHXCT", thamso);
            return dl.LoadTable("DonHangXuatCT_IN_DHX_DHXCT_DHCHUNG", thamso);
        }

        public DataTable DonHangXuatCT_DonHangChoTheoNhom(string NhomSPID)
        {
            SqlParameter[] thamso = { new SqlParameter("@NhomSPID", SqlDbType.VarChar, 50) };
            thamso[0].Value = NhomSPID;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_DonHangChoTheoNhom", thamso);
        }
        //public DataTable LayTTDXHTheoSoDH(string sodh)
        //{
        //    SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar, 12) };
        //    thamso[0].Value = sodh;

        //    CDuLieu dl = new CDuLieu();
        //    return dl.LoadTable("EcoDonHangXuatCT_LayTTDDHXChiTietTheoSoDH", thamso);
        //}

        public int Xoa(string dhxctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHXCTid", SqlDbType.VarChar, 50) };
            thamso[0].Value = dhxctid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DonHangXuatCT_Xoa", thamso);
        }


        public int DonHangXuatCT_InsertPhieuXuatct(string sodh)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDH_INPUT", SqlDbType.VarChar, 12) };
            thamso[0].Value = sodh;

            CDuLieu dl = new CDuLieu();
            //return dl.ThucThiTraVeKetQuaKieuInt("DonHangXuatCT_InsertPhieuXuat", thamso);
            return dl.ThucThiTraVeKetQuaKieuInt("NGHIEPVUPHIEUXUATCT", thamso);
        }


        public DataTable LayMaSP_TenSP(bool IsHangDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit) 
                                    };
            thamso[0].Value = IsHangDacBiet;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayMaTenSP", thamso);
        }

        public DataTable LayDateTheoSP_Lot(string spid, string lot, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = lot;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayDateTheoSP_Lot", thamso);
        }
        public DataTable LayLoTheoSPID_KhoID(string spid, string khoid, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayLotTheoSP_KhoID", thamso);
        }
        public DataTable LayLoTheoSPID_NSXID(string spid, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayLotTheoSP_NSXID", thamso);
        }
        public DataTable LayTTKDVT(string spid, string khoid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayTTDVT", thamso);
        }

        public DataTable LayTTKho(string spid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@NSXID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            thamso[1].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayTTKho", thamso);
        }

        public DataTable LayDate_SLTon_SLCoTheXuat_TheoLo(string spid, string khoid, string lot, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter("@KhoID", SqlDbType.VarChar), 
                                        new SqlParameter("@Lot", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = lot;
            thamso[3].Value = nsxid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuatCT_LayDateTheoSP_KhoID_Lot", thamso);
        }


        public DataTable PhieuXuat_LayDSDHXCT(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // DungLV add Xuat Thu Cong Start
        public DataTable PhieuXuat_LayDSDHXCT_hoadon(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT_KhoHangHoaDon", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PhieuXuat_LayDSDHXCT_HoaDonThuCong(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT_KhoHangHoaDonThuCong", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PhieuXuat_LayDSDHXCT_hoadonKM(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT_KhoHangHoaDonKM", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PhieuXuat_LayDSDHXCT_KhongCoHoaDonThuCong(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT_KhongHoaDon_ThuCong", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PhieuXuat_LayDSDHXCT_KhongCoHoaDon(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("PhieuXuat_LayDSDHXCT_KhongHoaDon", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // DungLV add Xuat Thu Cong End
        public bool KiemTraCoHangDacBiet(string DHID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DHid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(DHID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("DonHangXuatCT_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
        public DataTable BaoCaoDonHang_DangChoVaChuaXacNhan(string spid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@SPID", SqlDbType.VarChar)};
            thamso[0].Value = spid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoDonHang_DangChoVaChuaXacNhan", thamso);
        }

        public string ImportMulti(string DHID, string SoPTH)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@SoPTH", SqlDbType.VarChar, 12),
                                            new SqlParameter("@DHID", SqlDbType.UniqueIdentifier),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)};
                thamso[0].Value = SoPTH;
                thamso[1].Value = new Guid(DHID);
                thamso[2].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DonHangXuatCT_ImportDanhSach", thamso);
                return thamso[2].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
