using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLBangDanhMuc
    {
        string _stenbang;

        public string Stenbang
        {
            get { return _stenbang; }
            set { _stenbang = value; }
        }

        string _smota;

        public string Smota
        {
            get { return _smota; }
            set { _smota = value; }
        }
        public CSQLBangDanhMuc() { }
        public CSQLBangDanhMuc(string tenbang_, string mota_)
        {
            Stenbang = tenbang_;
            Smota = mota_;
        }
        public DataTable LayDanhSachLenLuoi()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_BangDanhMuc_LoadDanhSachLenLuoi", null);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ThemMoi(CSQLBangDanhMuc bdm_)
        {
            SqlParameter[] thamso = {   new SqlParameter("@TenBang", SqlDbType.VarChar),
                                        new SqlParameter("@MoTa", SqlDbType.NVarChar) };
            thamso[0].Value = bdm_.Stenbang;
            thamso[1].Value = bdm_.Smota;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NT_BangDanhMuc_ThemMoi", thamso);
            }
            catch (Exception Exception) { throw Exception; }
        }
    }
}
