using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_DatHangCT
    {
        public DataTable LoadDSSanPhamLenCBO()
        {
            CDuLieu dl = new CDuLieu();
            try 
            {
                return dl.LoadTable("DATHANG_LOADDANHSACHSANPHAM_NSXLENCBO", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDSDVTLenCBO(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("DATHANG_LAYDVTLENCBO", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LoadDSNhomSanPhamLenCBO(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("DATHANG_LAYNHOMSANPHAMLENCBO", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDSNhomSPLenCBO()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("DATHANG_LAYDSNHOMLENCBO", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ThemKhan(string dhid, string spid, int sldat, string dvt, string nsxid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DHID", SqlDbType.VarChar),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@SLDat", SqlDbType.Int),
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar)      
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = spid;
            thamso[2].Value = sldat;
            thamso[3].Value= dvt;
            thamso[4].Value = nsxid;

            CDuLieu dl= new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("DATHANGCT_THEMDONKHAN", thamso);
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    return dtb.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLenLuoi(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar)};
            thamso[0].Value = dhid;
            CDuLieu dl = new CDuLieu();
            try
            {
                //if (dhid != null)
                    return dl.LoadTable("DATHANGCT_LOADLENLUOI", thamso);
                //else
                //    return null;
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Load_SPid_DVT_NSXid_SLDat(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;
            CDuLieu dl = new CDuLieu();
            try
            {
                //if (dhid != null)
                return dl.LoadTable("DATHANGCT_Load_SPid_DVT_NSXid_SLDat", thamso);
                //else
                //    return null;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal LaySLDeNghi(string spid, string dvtid, string nsxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@DVTID", SqlDbType.VarChar),
                                    new SqlParameter("@NSXID", SqlDbType.VarChar)    };
            thamso[0].Value = spid;
            thamso[1].Value = dvtid;
            thamso[2].Value = nsxid;

            CDuLieu dl = new CDuLieu();
            try
            {
                string kq = dl.LoadTable("DATHANGCT_LAYSLDENGHI", thamso).Rows[0][0].ToString();
                if (kq == string.Empty)
                { return 0; }
                else
                    return decimal.Parse(kq);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SuaSLDat(string dhctid, decimal sldat)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                    new SqlParameter("@SLDAT", SqlDbType.Decimal)};
            thamso[0].Value = dhctid;
            thamso[1].Value = sldat;

            CDuLieu dl = new CDuLieu();
            try {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANGCT_SUASLDAT", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ThemChuKy(string dhid, string nhomsp)
        {
            try
            {
                SqlParameter[] thamso = { 
                                            new SqlParameter("@DHID", SqlDbType.VarChar),
                                            new SqlParameter("@NHOMSP", SqlDbType.VarChar),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                        };
                thamso[0].Value = dhid;
                thamso[1].Value = nhomsp;
                thamso[2].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
            
                dl.ThucThi("DATHANGCT_THEMDONCHUKY_2", thamso);
                return thamso[2].Value.ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public int Them_DonHangXuatCT_TaiTongCty(string dhid, string spid, decimal sldat, string dvt, string nsxid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DHid", SqlDbType.VarChar), 
                                        new SqlParameter("@SPid", SqlDbType.VarChar),
                                        new SqlParameter("@SLDat", SqlDbType.Decimal),
                                        new SqlParameter("@DVT", SqlDbType.VarChar),
                                        new SqlParameter("@NSXid", SqlDbType.VarChar)
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = spid;
            thamso[2].Value = sldat;
            thamso[3].Value = dvt;
            thamso[4].Value = nsxid;
            CDuLieuRemote dl = new CDuLieuRemote();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANGCT_THEMDONHANGXUATCT_TONGCTY", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string NTDatHangCT_Insert_ECODonHangXuatCT(DataTable ds, string dhid, string sodh, string noidh, string xuatchont, bool donkhan, string ghichu, string usernhap, bool IsKhoDacBiet, string nhomspid = null)
        {
            try
            {
                SqlParameter[] thamso = {  
                                        new SqlParameter("@DataImport", SqlDbType.Structured),
                                        new SqlParameter("@DHid", SqlDbType.VarChar), 
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@NoiDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        new SqlParameter("@Nhomspid", SqlDbType.VarChar),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };
                thamso[0].Value = ds;
                thamso[1].Value = dhid;
                thamso[2].Value = sodh;
                thamso[3].Value = noidh;
                thamso[4].Value = xuatchont;
                thamso[5].Value = donkhan;
                thamso[6].Value = ghichu;
                thamso[7].Value = usernhap;
                thamso[8].Value = IsKhoDacBiet;
                thamso[9].Value = nhomspid;
                thamso[10].Direction = ParameterDirection.Output;

                CDuLieuRemote dl = new CDuLieuRemote();

                dl.InsertDuLieu("NTDatHangCT_Insert_ECODonHangXuatCT", thamso, null);

                return thamso[10].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int Xoa(string dhctid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DHCTid", SqlDbType.VarChar)
                                    };
            thamso[0].Value = dhctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANGCT_XOA", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable IN_DH_DHCT(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHid", SqlDbType.VarChar, 50) };
            thamso[0].Value = dhid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DATHANGCT_IN_DH_DHCT", thamso);
        }

        public int ThemDatHangCTTheoDBACC(string dhid, string masp, decimal sldat, decimal sldenghi)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar),
                                    new SqlParameter("@MASP", SqlDbType.VarChar),
                                    new SqlParameter("@SLDAT", SqlDbType.Decimal),
                                    new SqlParameter("@SLDENGHI", SqlDbType.Decimal)
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = masp;
            thamso[2].Value = sldat;
            thamso[3].Value = sldenghi;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DatHangCT_ThemDonTuFileAccess", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable XemThongTinCacChuKyTruoc(string spid, int soRecordHienThi = 10)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter("@spid", spid),
                                         new SqlParameter("@soRecordHienThi", soRecordHienThi)
                                     };
            CDuLieu dl = new CDuLieu();
            try 
            {
                return dl.LoadTable("DathangCT_XemThongTinCacChuKyTruoc", thamso);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
