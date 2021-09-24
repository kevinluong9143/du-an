using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.SQL;

namespace ECOPharma2013.DuLieu
{
    class CQuyenTruyCap
    {
        public bool KiemTraQuyenXem(string frmName)
        {
            CSQLQuyenTruyCap LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            try
            {
                BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if(BangQuyenChiTiet!=null && BangQuyenChiTiet.Rows.Count>0)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Xem"].ToString());
            }

            return false;
        }

        public bool KiemTraQuyenThem_Sua(string frmName)
        {

            CSQLQuyenTruyCap LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            try
            {
                BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
                //for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (BangQuyenChiTiet != null && BangQuyenChiTiet.Rows.Count > 0)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Them_Sua"].ToString());
            }

            return false;
        }

        public bool KiemTraQuyenXoa(string frmName)
        {

            CSQLQuyenTruyCap LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            try
            {
                BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
                //for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (BangQuyenChiTiet != null && BangQuyenChiTiet.Rows.Count > 0)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Xoa"].ToString());
            }

            return false;
        }

        public bool KiemTraQuyenIn(string frmName)
        {

            CSQLQuyenTruyCap LopCSQLQuyenTruyCap = new CSQLQuyenTruyCap();
            DataTable BangQuyenChiTiet = new DataTable();
            try
            {
                BangQuyenChiTiet = LopCSQLQuyenTruyCap.QuyenChiTiet(CStaticBien.sNhomTaiKhoan, frmName);
                //for (int i = 0; i < BangQuyenChiTiet.Rows.Count; i++)
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (BangQuyenChiTiet != null && BangQuyenChiTiet.Rows.Count > 0)
            {
                return bool.Parse(BangQuyenChiTiet.Rows[0]["Inn"].ToString());
            }

            return false;
        }

    }
}
