using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangMuaTong
    {
        string sDHMTongid;

        public string SDHMTongid
        {
            get { return sDHMTongid; }
            set { sDHMTongid = value; }
        }
        string sSoDHMT;

        public string SSoDHMT
        {
            get { return sSoDHMT; }
            set { sSoDHMT = value; }
        }
        string sGhiChu;

        public string SGhiChu
        {
            get { return sGhiChu; }
            set { sGhiChu = value; }
        }
        DateTime dNgayTao;

        public DateTime DNgayTao
        {
            get { return dNgayTao; }
            set { dNgayTao = value; }
        }
        string sNVTao;

        public string SNVTao
        {
            get { return sNVTao; }
            set { sNVTao = value; }
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
        int iTinhTrangID;

        public int ITinhTrangID
        {
            get { return iTinhTrangID; }
            set { iTinhTrangID = value; }
        }
        string bIsXoa;

        public string BIsXoa
        {
            get { return bIsXoa; }
            set { bIsXoa = value; }
        }

        public CSQLDonHangMuaTong() { }
        //public CSQLDonHangMuaTong(string DHMTongid, string SoDHMT, string GhiChu, DateTime NgayTao, string NVTao, DateTime LastUD, string NVUD, int TinhTrangID, int IsXoa)
        //{

        //}

        public string Them(string nvtaoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@nvTao", SqlDbType.VarChar),};
            thamso[0].Value = nvtaoid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("EcoDonHangMuaTong_Them", thamso);
            if (dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
            //int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoDonHangMuaTong_Them", thamso);
            //if (kq > 0)
            //{
            //    return thamso[1].Value.ToString();
            //}
            //else
            //    return null;
        }

        public DataTable LoadLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@isXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTong_LoadLenLuoi", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CapNhatTinhTrangDonHangMuaTong(string dhmtong, string nvud, int tinhtrang)
        {
            SqlParameter[] thamso = {   new SqlParameter("@dhmtongid", dhmtong),
                                        new SqlParameter("@nvud", nvud),
                                        new SqlParameter("@tinhtrang", tinhtrang)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTong_UpdateTinhTrang", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DonHangMuaTong_Lay1DonHangMuaTongTheoDHMTongID(@dhmtongid uniqueidentifier)
        public DataTable Lay1DonHangMuaTongTheoDHMTongID(string dhmtongid)
        {
            SqlParameter[] thamso = { new SqlParameter("@dhmtongid", dhmtongid) };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("DonHangMuaTong_Lay1DonHangMuaTongTheoDHMTongID", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //
        //b1: Tao don hang mua theo nha phan phoi luu vao econhapkho & econhapkhoct
        //b2: cap nhat tinh trang cua don hang tong thanh 3
        //DonHangMuaTong_TaoDonDatHang(@dhmtongid uniqueidentifier, @nvnhap uniqueidentifier)
        //
        public int TaoDonDatHang(string dhmtongid, string nvnhap)
        {
            SqlParameter[] thamso = {    new SqlParameter("@dhmtongid", dhmtongid),
                                         new SqlParameter("@nvnhap", nvnhap)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTong_TaoDonDatHang", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///DonHangMuaTong_Xoa(@dhmtongid uniqueidentifier, @nvid uniqueidentifier)
        ///Update isxoa don hang mua tong = true
        ///Update don hang xuat isdalamdonhangmuatong = 0, SoDHMT = null
        public int Xoa(string dhmtongid, string nvxoa)
        {
            SqlParameter[] thamso = {    new SqlParameter("@dhmtongid", dhmtongid),
                                         new SqlParameter("@nvid", nvxoa)
                                    };
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangMuaTong_Xoa", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
