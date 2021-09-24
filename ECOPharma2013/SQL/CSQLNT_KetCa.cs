using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLNT_KetCa
    {
        string _sCKCid;

        public string SCKCid
        {
            get { return _sCKCid; }
            set { _sCKCid = value; }
        }

        string _sTenMayThuNgan;

        public string STenMayThuNgan
        {
            get { return _sTenMayThuNgan; }
            set { _sTenMayThuNgan = value; }
        }

        decimal _fTienBanDau;

        public decimal FTienBanDau
        {
            get { return _fTienBanDau; }
            set { _fTienBanDau = value; }
        }

        decimal _fTienKetCa;

        public decimal FTienKetCa
        {
            get { return _fTienKetCa; }
            set { _fTienKetCa = value; }
        }

        int _iT500k;

        public int IT500k
        {
            get { return _iT500k; }
            set { _iT500k = value; }
        }
        int _iT200k;

        public int IT200k
        {
            get { return _iT200k; }
            set { _iT200k = value; }
        }

        int _iT100k;

        public int IT100k
        {
            get { return _iT100k; }
            set { _iT100k = value; }
        }

        int _iT50k;

        public int IT50k
        {
            get { return _iT50k; }
            set { _iT50k = value; }
        }

        int _iT20k;

        public int IT20k
        {
            get { return _iT20k; }
            set { _iT20k = value; }
        }

        int _iT10k;

        public int IT10k
        {
            get { return _iT10k; }
            set { _iT10k = value; }
        }

        int _iT5k;

        public int IT5k
        {
            get { return _iT5k; }
            set { _iT5k = value; }
        }

        int _iT2k;

        public int IT2k
        {
            get { return _iT2k; }
            set { _iT2k = value; }
        }

        int _iT1k;

        public int IT1k
        {
            get { return _iT1k; }
            set { _iT1k = value; }
        }

        int _iT500;

        public int IT500
        {
            get { return _iT500; }
            set { _iT500 = value; }
        }

        int _iT200;

        public int IT200
        {
            get { return _iT200; }
            set { _iT200 = value; }
        }

        string _sUserID;

        public string SUserID
        {
            get { return _sUserID; }
            set { _sUserID = value; }
        }

        public CSQLNT_KetCa() { }
        public CSQLNT_KetCa(string mackcid, string tenmaytn, decimal tienbandau, decimal tienketca, int t500k, int t200k, int t100k, int t50k, int t20k, int t10k, int t5k, int t2k, int t1k, int t500, int t200, string userid )
        {
            SCKCid = mackcid;
            STenMayThuNgan = tenmaytn;
            FTienBanDau = tienbandau;
            FTienKetCa = tienketca;
            IT500k = t500k;
            IT200k = t200k;
            IT100k = t100k;
            IT50k = t50k;
            IT20k = t20k;
            IT10k = t10k;
            IT5k = t5k;
            IT2k = t2k;
            IT1k = t1k;
            IT500 = t500;
            IT200 = t200;
            SUserID = userid;
        }

        public DataTable LayDanhSachLenLuoi()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("NT_KetCa_LayDanhSachLenLuoi", null);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public DataTable LayDanhSachTheo_MaCKCid(string ckcid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKCid", SqlDbType.VarChar) };
            thamso[0].Value = ckcid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_KetCa_LayDanhSachTheo_MaCKCid", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Update_IsDaKetCa(string ckcid)
        {
            SqlParameter[] thamso = { new SqlParameter("@CKCid", SqlDbType.VarChar) };
            thamso[0].Value = ckcid;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_KetCa_Update_IsDaKetCa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_SoLieuKetCa(CSQLNT_KetCa nt_ketca)
        {
            SqlParameter[] thamso = {   new SqlParameter("@CKCid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@TienBanDau", SqlDbType.Decimal), 
                                        new SqlParameter("@TienKetCa", SqlDbType.Decimal), 
                                        new SqlParameter("@T500k", SqlDbType.Int), 
                                        new SqlParameter("@T200k", SqlDbType.Int), 
                                        new SqlParameter("@T100k", SqlDbType.Int),
                                        new SqlParameter("@T50k", SqlDbType.Int),
                                        new SqlParameter("@T20k", SqlDbType.Int), 
                                        new SqlParameter("@T10k", SqlDbType.Int),
                                        new SqlParameter("@T5k", SqlDbType.Int),
                                        new SqlParameter("@T2k", SqlDbType.Int),
                                        new SqlParameter("@T1k", SqlDbType.Int),
                                        new SqlParameter("@T500", SqlDbType.Int), 
                                        new SqlParameter("@T200", SqlDbType.Int),
                                        new SqlParameter("@UserID", SqlDbType.VarChar)};
            thamso[0].Value = nt_ketca.SCKCid;
            thamso[1].Value = nt_ketca.STenMayThuNgan;
            thamso[2].Value = nt_ketca.FTienBanDau;
            thamso[3].Value = nt_ketca.FTienKetCa;
            thamso[4].Value = nt_ketca.IT500k;
            thamso[5].Value = nt_ketca.IT200k;
            thamso[6].Value = nt_ketca.IT100k;
            thamso[7].Value = nt_ketca.IT50k;
            thamso[8].Value = nt_ketca.IT20k;
            thamso[9].Value = nt_ketca.IT10k;
            thamso[10].Value = nt_ketca.IT5k;
            thamso[11].Value = nt_ketca.IT2k;
            thamso[12].Value = nt_ketca.IT1k;
            thamso[13].Value = nt_ketca.IT500;
            thamso[14].Value = nt_ketca.IT200;
            thamso[15].Value = nt_ketca.SUserID;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_KetCa_Update_SoLieuKetCa", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }

        /// <summary>
        /// Hàm kiểm tra máy thu ngân đã kết ca hay chưa.
        /// Nếu đã kết ca: Tạo ca mới - Lấy số ca mới.
        /// Nếu chưa kết ca: Lấy số ca cũ để sử dụng tiếp.
        /// </summary>
        /// <param name="tenMayThuNgan">(string): Tên của máy thu ngân</param>
        /// <returns>Số ca hiện tại (nếu kết quả trả về = -1: có lỗi xảy ra)</returns>
        public int KiemTraVaLaySoCa(string tenMayThuNgan)
        {
            SqlParameter []thamso = {new SqlParameter("@TenMayThuNgan",SqlDbType.VarChar)};
            thamso[0].Value = tenMayThuNgan;
            CDuLieu dl = new CDuLieu();
            DataTable dtb= dl.LoadTable("NTCaKetCa_KiemTraVaLaySoCa", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return int.Parse(dtb.Rows[0][0].ToString());
            }
            else
                return -1;
        }
    }
}
