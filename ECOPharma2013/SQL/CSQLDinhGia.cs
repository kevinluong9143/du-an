﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDinhGia
    {
        //DGid uniqueidentifier primary key not null,
        //SPid uniqueidentifier references ECOSanPham(SPID) not null,
        //NTid uniqueidentifier references ECONhaThuoc(NTID) not null,
        //MarkUp decimal null,
        //NgayCapNhat datetime null,
        //UserCapNhatid uniqueidentifier references ECOUser(UserID) null,
        //MaxThemMoi int IDENTITY(1,1) not null,
        //MaxCapNhat int null
        string sDGID;

        public string SDGID
        {
            get { return sDGID; }
            set { sDGID = value; }
        }
        string sSPID;

        public string SSPID
        {
            get { return sSPID; }
            set { sSPID = value; }
        }
        string sNTID;

        public string SNTID
        {
            get { return sNTID; }
            set { sNTID = value; }
        }
        decimal fMarkup;

        public decimal FMarkup
        {
            get { return fMarkup; }
            set { fMarkup = value; }
        }
        DateTime dNgayCapNhat;

        public DateTime DNgayCapNhat
        {
            get { return dNgayCapNhat; }
            set { dNgayCapNhat = value; }
        }
        string sUserCapNhatID;

        public string SUserCapNhatID
        {
            get { return sUserCapNhatID; }
            set { sUserCapNhatID = value; }
        }

        public CSQLDinhGia() { }

        public int Them(string spid, decimal markup, DateTime ngaycapnhat, string usercapnhatid)
        {
            SqlParameter[] thamso = {  new SqlParameter ("@SPID", SqlDbType.VarChar),
                                        new SqlParameter ("@MarkUp", SqlDbType.VarChar),
                                        new SqlParameter ("@NgayCapNhat", SqlDbType.DateTime),
                                        new SqlParameter ("@UserCapNhatID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = markup;
            thamso[1].Precision = 38;
            thamso[1].Scale = 15;
            thamso[2].Value = ngaycapnhat; 
            thamso[3].Value = usercapnhatid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DinhGia_Them", thamso);
        }

        public DataTable LayLenLuoiTheoSPID(string spid) 
        {
            SqlParameter [] thamso = {  new SqlParameter ("@SPID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DinhGia_LayLenLuoiTheoSPID", thamso);
        }

        public int Sua(string dgid, decimal markup, string usercapnhatid)
        {
            SqlParameter[] thamso = {new SqlParameter("@DGID", SqlDbType.VarChar),
                                        new SqlParameter("@markup", SqlDbType.Decimal),
                                        new SqlParameter("@usercapnhatid" , SqlDbType.VarChar)};
            thamso[0].Value = dgid;
            thamso[1].Value = markup;
            thamso[1].Precision = 38;
            thamso[1].Scale = 15;
            thamso[2].Value = usercapnhatid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DinhGia_Sua", thamso);
        }


        public decimal LayMarkup(string spid, string ntid)
        {
            SqlParameter[] thamso = {new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NTID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = ntid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DinhGia_LayMarkUp", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return decimal.Parse(dtb.Rows[0][0].ToString());
            }
            else return 0;
        }
   
        public int DinhGia_LayMaxCapNhatNT(string mant_)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = mant_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DinhGia_LayMaxCapNhat", thamso);
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
        public int DinhGia_LayMaxCapNhatECO(string mant_)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = mant_;
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DinhGia_LayMaxCapNhat", thamso);
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
        public int DinhGia_LayMaxThemMoiNT(string mant_)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", SqlDbType.VarChar) };
            thamso[0].Value = mant_;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DinhGia_LayMaxThemMoi", thamso);
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
        public int DinhGia_LayMaxThemMoiECO(string mant_)
        {
            SqlParameter[] thamso = {new SqlParameter("@NTID", SqlDbType.VarChar)};
            thamso[0].Value = mant_;
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("DinhGia_LayMaxThemMoi", thamso);
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

        public DataTable DinhGia_LayDSDinhGiaChuaCapNhatTaiNT(int maxCapNhatNT, string mant_)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int),
                                    new SqlParameter("@NTID", SqlDbType.VarChar)};
            thamso[0].Value = maxCapNhatNT;
            thamso[1].Value = mant_;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DinhGia_LayDSDinhGiaChuaCapNhatTaiNT", thamso);
        }
        public DataTable DinhGia_LayDSDinhGiaChuaThemMoiTaiNT(int maxThemMoiNT, string mant_)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) ,
                                    new SqlParameter("@NTID", SqlDbType.VarChar)};
            thamso[0].Value = maxThemMoiNT;
            thamso[1].Value = mant_;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("DinhGia_LayDSDinhGiaChuaThemMoiTaiNT", thamso);
        }
        public void DinhGia_DongBoThemDanhMuc(DataTable dsDinhGiaChuaThemMoi, string tdgspid)
        {
            if (dsDinhGiaChuaThemMoi.Rows.Count > 0)
            {
                foreach (DataRow dr in dsDinhGiaChuaThemMoi.Rows)
                {
                    #region ghi vao thay doi gia sp tiep theo
                    CSQLNTThayDoiGiaSPCT nttdgspct = new CSQLNTThayDoiGiaSPCT();
                    nttdgspct.NTThayDoiGiaSPCT_Them_DoiDinhGia(tdgspid, dr["SPid"].ToString(), decimal.Parse(dr["MarkUp"].ToString()));
                    #endregion
                    SqlParameter[] thamso = { new SqlParameter("@DGid", SqlDbType.VarChar),
                                                new SqlParameter("@SPid", SqlDbType.VarChar),
                                                new SqlParameter("@NTid", SqlDbType.VarChar),
                                                new SqlParameter("@MarkUp", SqlDbType.Decimal),
                                                new SqlParameter("@NgayCapNhat", SqlDbType.DateTime),
                                                new SqlParameter("@UserCapNhatid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@PhanLoaiID", SqlDbType.VarChar) };
                    thamso[0].Value = dr["DGid"].ToString();
                    thamso[1].Value = dr["SPid"].ToString();
                    thamso[2].Value = dr["NTid"].ToString();
                    thamso[3].Value = decimal.Parse(dr["MarkUp"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["NgayCapNhat"].ToString());
                    thamso[5].Value = CStaticBien.SmaTaiKhoan;
                    thamso[6].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[7].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[8].Value = bool.Parse(dr["IsXoa"].ToString());
                    if (dr["PhanLoaiID"].ToString() != null && dr["PhanLoaiID"].ToString().Length > 0)
                        thamso[9].Value = dr["PhanLoaiID"].ToString();
                    else
                        thamso[9].Value = "00000000-0000-0000-0000-000000000000";
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DinhGia_DongBoThemDanhMuc", thamso, null);


                }
            }
        }
        public void DinhGia_DongBoSuaDanhMuc(DataTable dsDinhGiaChuaCapNhat, string tdgspid)
        {
            if (dsDinhGiaChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in dsDinhGiaChuaCapNhat.Rows)
                {
                    #region ghi vao thay doi gia sp tiep theo
                    CSQLNTThayDoiGiaSPCT nttdgspct = new CSQLNTThayDoiGiaSPCT();
                    nttdgspct.NTThayDoiGiaSPCT_Them_DoiDinhGia(tdgspid, dr["SPid"].ToString(), decimal.Parse(dr["MarkUp"].ToString()));
                    #endregion
                    SqlParameter[] thamso = { new SqlParameter("@DGid", SqlDbType.VarChar),
                                                new SqlParameter("@SPid", SqlDbType.VarChar),
                                                new SqlParameter("@NTid", SqlDbType.VarChar),
                                                new SqlParameter("@MarkUp", SqlDbType.Decimal),
                                                new SqlParameter("@NgayCapNhat", SqlDbType.DateTime),
                                                new SqlParameter("@UserCapNhatid", SqlDbType.VarChar),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit) ,
                                                new SqlParameter("@PhanLoaiID", SqlDbType.VarChar) };
                    thamso[0].Value = dr["DGid"].ToString();
                    thamso[1].Value = dr["SPid"].ToString();
                    thamso[2].Value = dr["NTid"].ToString();
                    thamso[3].Value = decimal.Parse(dr["MarkUp"].ToString());
                    thamso[4].Value = DateTime.Parse(dr["NgayCapNhat"].ToString());
                    thamso[5].Value = CStaticBien.SmaTaiKhoan;
                    thamso[6].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[7].Value = bool.Parse(dr["IsXoa"].ToString());
                    if (dr["PhanLoaiID"].ToString() != null && dr["PhanLoaiID"].ToString().Length > 0)
                        thamso[8].Value = dr["PhanLoaiID"].ToString();
                    else
                        thamso[8].Value = "00000000-0000-0000-0000-000000000000";

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("DinhGia_DongBoSuaDanhMuc", thamso, null);
                 
                }
            }
        }
    }
}