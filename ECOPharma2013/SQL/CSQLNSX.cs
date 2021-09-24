using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;
using System.Data;

namespace ECOPharma2013.SQL
{
    class CSQLNSX
    {
         string _sNSXID;

        public string SNSXID
        {
            get { return _sNSXID; }
            set { _sNSXID = value; }
        }
        string _sTenNSX;

        public string STenNSX
        {
            get { return _sTenNSX; }
            set { _sTenNSX = value; }
        }

        string _sDiaChi;

        public string SDiaChi
        {
            get { return _sDiaChi; }
            set { _sDiaChi = value; }
        }
        string _sQuanID;

        public string SQuanID
        {
            get { return _sQuanID; }
            set { _sQuanID = value; }
        }
        string _sTPID;

        public string STPID
        {
            get { return _sTPID; }
            set { _sTPID = value; }
        }
        string _sTel;

        public string STel
        {
            get { return _sTel; }
            set { _sTel = value; }
        }
        string _sFax;

        public string SFax
        {
            get { return _sFax; }
            set { _sFax = value; }
        }
        string _sNSXEmail;

        public string SNSXEmail
        {
            get { return _sNSXEmail; }
            set { _sNSXEmail = value; }
        }
        string _sPIC;

        public string SPIC
        {
            get { return _sPIC; }
            set { _sPIC = value; }
        }
        string _sDTDD;

        public string SDTDD
        {
            get { return _sDTDD; }
            set { _sDTDD = value; }
        }
        string _sPICEmail;

        public string SPICEmail
        {
            get { return _sPICEmail; }
            set { _sPICEmail = value; }
        }
        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }
        bool _bKhongSuDung;

        public bool BKhongSuDung
        {
            get { return _bKhongSuDung; }
            set { _bKhongSuDung = value; }
        }
        DateTime _dLastUD;

        public DateTime DLastUD
        {
            get { return _dLastUD; }
            set { _dLastUD = value; }
        }
        DateTime _dNgayTao;

        public DateTime DNgayTao
        {
            get { return _dNgayTao; }
            set { _dNgayTao = value; }
        }
        string _sUserID;

        public string SUserID
        {
            get { return _sUserID; }
            set { _sUserID = value; }
        }

        string _sQGid;

        public string SQGid
        {
            get { return _sQGid; }
            set { _sQGid = value; }
        }

        public CSQLNSX() { }

        public string ThemNSX(CSQLNSX NSX)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NSXID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@TenNSX", SqlDbType.NVarChar),
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                        new SqlParameter("@QuanID", SqlDbType.VarChar),
                                        new SqlParameter("@TPID", SqlDbType.VarChar),
                                        new SqlParameter("@Tel", SqlDbType.VarChar),
                                        new SqlParameter("@Fax", SqlDbType.VarChar),
                                        new SqlParameter("@NSXEmail", SqlDbType.VarChar),
                                        new SqlParameter("@PIC", SqlDbType.NVarChar),
                                        new SqlParameter("@DTDD", SqlDbType.VarChar),
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NText),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar),
                                        new SqlParameter("@QGid", SqlDbType.VarChar) 
                                    };
                thamso[0].Direction = ParameterDirection.Output;
                thamso[1].Value = NSX.STenNSX;
                thamso[2].Value = NSX.SDiaChi;
                thamso[3].Value = NSX.SQuanID;
                thamso[4].Value = NSX.STPID;
                thamso[5].Value = NSX.STel;
                thamso[6].Value = NSX.SFax;
                thamso[7].Value = NSX.SNSXEmail;
                thamso[8].Value = NSX.SPIC;
                thamso[9].Value = NSX.SDTDD;
                thamso[10].Value = NSX.SPICEmail;
                thamso[11].Value = NSX.SGhiChu;
                thamso[12].Value = NSX.BKhongSuDung;
                thamso[13].Value = NSX.DLastUD;
                thamso[14].Value = NSX.DNgayTao;
                thamso[15].Value = NSX.SUserID;
                thamso[16].Value = NSX.SQGid;

                CDuLieu dl = new CDuLieu();
                dl.InsertDuLieu("NSX_ThemNSX", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string SuaNSX(CSQLNSX NSX)
        {
            try
            {
                SqlParameter[] thamso = {new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@TenNSX", SqlDbType.NVarChar),
                                        new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                        new SqlParameter("@QuanID", SqlDbType.VarChar),
                                        new SqlParameter("@TPID", SqlDbType.VarChar),
                                        new SqlParameter("@Tel", SqlDbType.VarChar),
                                        new SqlParameter("@Fax", SqlDbType.VarChar),
                                        new SqlParameter("@NSXEmail", SqlDbType.VarChar),
                                        new SqlParameter("@PIC", SqlDbType.NVarChar),
                                        new SqlParameter("@DTDD", SqlDbType.VarChar),
                                        new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                        new SqlParameter("@GhiChu", SqlDbType.NText),
                                        new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@UserID", SqlDbType.VarChar),
                                        new SqlParameter("@QGid", SqlDbType.VarChar),
                                        new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                                    };
                thamso[0].Value = NSX.SNSXID;
                thamso[1].Value = NSX.STenNSX;
                thamso[2].Value = NSX.SDiaChi;
                thamso[3].Value = NSX.SQuanID;
                thamso[4].Value = NSX.STPID;
                thamso[5].Value = NSX.STel;
                thamso[6].Value = NSX.SFax;
                thamso[7].Value = NSX.SNSXEmail;
                thamso[8].Value = NSX.SPIC;
                thamso[9].Value = NSX.SDTDD;
                thamso[10].Value = NSX.SPICEmail;
                thamso[11].Value = NSX.SGhiChu;
                thamso[12].Value = NSX.BKhongSuDung;
                thamso[13].Value = NSX.DLastUD;
                thamso[14].Value = NSX.DNgayTao;
                thamso[15].Value = NSX.SUserID;
                thamso[16].Value = NSX.SQGid;
                thamso[17].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThi("NSX_SuaNSX", thamso);
                return thamso[17].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string XoaNSX(string NSXid)
        {
            try
            {
                SqlParameter[] thamso = { 
                                            new SqlParameter("@NSXID", SqlDbType.VarChar),
                                            new SqlParameter("@Message", SqlDbType.NVarChar, -1) 
                                        };
                thamso[0].Value = NSXid;
                thamso[1].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThi("NSX_XoaNSX", thamso);

                return thamso[1].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable LayNSXLenLuoi(bool xemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = xemTatCa;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NSX_LayNSXLenLuoi", thamso);
        }

        public DataTable LayNSXTheoMa(string NSXid)
        {
            SqlParameter[] thamso = { new SqlParameter("@NSXID", SqlDbType.VarChar) };
            thamso[0].Value = NSXid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NSX_LayNSXTheoMa", thamso);
        }


        public int NSX_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NSX_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NSX_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NSX_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NSX_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NSX_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        public int NSX_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("NSX_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch { return 0; }
            }
            else
                return 0;
        }

        public DataTable NSX_LayDSNSXChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NSX_LayDSNSXChuaCapNhatTaiNT", thamso);
        }
        public DataTable NSX_LayDSNSXChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("NSX_LayDSNSXChuaThemMoiTaiNT", thamso);
        }
        public void NSX_DongBoThemDanhMuc(DataTable dsNSXChuaThemMoi)
        {
            //MST, DiaChi, QuanID, TPID, Tel, Fax, NSXEmail, PIC, DTDD, PICEmail,
            if (dsNSXChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNSXChuaThemMoi.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NSXid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNSX", SqlDbType.NVarChar),
                                                new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                                new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@Tel", SqlDbType.VarChar),
                                                new SqlParameter("@Fax", SqlDbType.VarChar),
                                                new SqlParameter("@NSXEmail", SqlDbType.VarChar),
                                                new SqlParameter("@PIC", SqlDbType.NVarChar),
                                                new SqlParameter("@DTDD", SqlDbType.VarChar),
                                                new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@QGid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["NSXid"].ToString();
                    thamso[1].Value = dr["TenNSX"].ToString();
                    thamso[2].Value = dr["DiaChi"].ToString();
                    if (dr["QuanID"].ToString() != null && dr["QuanID"].ToString().Length > 0)
                        thamso[3].Value = dr["QuanID"].ToString();
                    else
                        thamso[3].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["TPID"].ToString() != null && dr["TPID"].ToString().Length > 0)
                        thamso[4].Value = dr["TPID"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[5].Value = dr["Tel"].ToString();
                    thamso[6].Value = dr["Fax"].ToString();
                    thamso[7].Value = dr["NSXEmail"].ToString();
                    thamso[8].Value = dr["PIC"].ToString();
                    thamso[9].Value = dr["DTDD"].ToString();
                    thamso[10].Value = dr["PICEmail"].ToString();
                    thamso[11].Value = dr["GhiChu"].ToString();
                    thamso[12].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[13].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[15].Value = CStaticBien.SmaTaiKhoan;
                    if (dr["QGid"].ToString() != null && dr["QGid"].ToString().Length > 0)
                    {
                        thamso[16].Value = dr["QGid"].ToString();
                    }
                    else
                    {
                        thamso[16].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    thamso[17].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[18].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[19].Value = bool.Parse(dr["IsXoa"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NSX_DongBoThemDanhMuc", thamso, null);
                }
            }
        }
        public void NSX_DongBoSuaDanhMuc(DataTable dsNSXChuaCapNhat)
        {
            if (dsNSXChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsNSXChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@NSXid", SqlDbType.VarChar),
                                                new SqlParameter("@TenNSX", SqlDbType.NVarChar),
                                                new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                                                new SqlParameter("@QuanID", SqlDbType.VarChar),
                                                new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@Tel", SqlDbType.VarChar),
                                                new SqlParameter("@Fax", SqlDbType.VarChar),
                                                new SqlParameter("@NSXEmail", SqlDbType.VarChar),
                                                new SqlParameter("@PIC", SqlDbType.NVarChar),
                                                new SqlParameter("@DTDD", SqlDbType.VarChar),
                                                new SqlParameter("@PICEmail", SqlDbType.VarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@LastUD", SqlDbType.DateTime),
                                                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                                new SqlParameter("@UserID", SqlDbType.VarChar),
                                                new SqlParameter("@QGid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["NSXid"].ToString();
                    thamso[1].Value = dr["TenNSX"].ToString();
                    thamso[2].Value = dr["DiaChi"].ToString();
                    if (dr["QuanID"].ToString() != null && dr["QuanID"].ToString().Length > 0)
                        thamso[3].Value = dr["QuanID"].ToString();
                    else
                        thamso[3].Value = "00000000-0000-0000-0000-000000000000";
                    if (dr["TPID"].ToString() != null && dr["TPID"].ToString().Length > 0)
                        thamso[4].Value = dr["TPID"].ToString();
                    else
                        thamso[4].Value = "00000000-0000-0000-0000-000000000000";
                    thamso[5].Value = dr["Tel"].ToString();
                    thamso[6].Value = dr["Fax"].ToString();
                    thamso[7].Value = dr["NSXEmail"].ToString();
                    thamso[8].Value = dr["PIC"].ToString();
                    thamso[9].Value = dr["DTDD"].ToString();
                    thamso[10].Value = dr["PICEmail"].ToString();
                    thamso[11].Value = dr["GhiChu"].ToString();
                    thamso[12].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[13].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[14].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[15].Value = CStaticBien.SmaTaiKhoan;
                    if (dr["QGid"].ToString() != null && dr["QGid"].ToString().Length > 0)
                    {
                        thamso[16].Value = dr["QGid"].ToString();
                    }
                    else
                    {
                        thamso[16].Value = "00000000-0000-0000-0000-000000000000";
                    }
                    thamso[17].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[18].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("NSX_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
        public DataTable LayDSNSXLenMultiColumnCombobox()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NSX_LayDSNSXLenMultiColumnCombobox", null);
        }
    }
}
