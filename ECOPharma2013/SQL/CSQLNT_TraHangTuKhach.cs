using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_TraHangTuKhach
    {
        public DataTable NT_TraHangTuKhach_LayDSTraHangTheoSoPhieuBan(string soCTBan)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPhieuBan", SqlDbType.VarChar) };
            thamso[0].Value = soCTBan;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHangTuKhach_LayDSTraHangTheoSoPhieuBan", thamso);
        }

        public string [] NT_TraHangTuKhach_Them(string soctban, string tenmaythungan, string usertao, string nvbanhang, int soca, string khid, DateTime ngaytao, string phitrahang, bool hangdacbiet)
        {
            SqlParameter[] thamso = {
                                         new SqlParameter("@SoCTBan", SqlDbType.VarChar),
                                         new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar),
                                         new SqlParameter("@UserTao", SqlDbType.VarChar),
                                         new SqlParameter("@NVBanHang", SqlDbType.VarChar),
                                         new SqlParameter("@SoCa", SqlDbType.Int),
                                         new SqlParameter("@KHID", SqlDbType.VarChar),
                                         new SqlParameter("@THID", SqlDbType.VarChar,50),
                                         new SqlParameter("@SoCTTra", SqlDbType.VarChar,50),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                          new SqlParameter("@PhiTraHang", SqlDbType.VarChar),
                                        new SqlParameter("@HangDacBiet", SqlDbType.Bit)  };

            thamso[0].Value = soctban;
            thamso[1].Value = tenmaythungan;
            thamso[2].Value = usertao;
            thamso[3].Value = nvbanhang;
            thamso[4].Value = soca;
            thamso[5].Value = khid;
            thamso[6].Direction = ParameterDirection.Output;
            thamso[7].Direction = ParameterDirection.Output;
            thamso[8].Value = ngaytao;
            thamso[9].Value = phitrahang;
            thamso[10].Value = hangdacbiet;
            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_TraHangTuKhach_Them", thamso);
            string []stringkq= new string[2];
            if (kq > 0)
            {
                stringkq[0] = thamso[6].Value.ToString();//THID
                stringkq[1] = thamso[7].Value.ToString();//SoCTTra
            }
            else
            {
                stringkq = null;
            }
            return stringkq;
        }

        public decimal NT_TraHang_LayTongTienTheoTHID(string thid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = thid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("NT_TraHang_LayTongTienTheoTHID", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return decimal.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }


        /// <summary>
        /// Hàm kiểm tra phiếu trả hàng đã thanh toán hay chưa.
        /// </summary>
        /// <param name="thid"></param>
        /// <returns>Đã thanh toán: true / Chưa thanh toán: false</returns>
        public bool NT_TraHang_KiemTraThanhToan(string thid)
        {
            SqlParameter[] thamso = { new SqlParameter("@isDaThanhToan", SqlDbType.Bit),
                                        new SqlParameter("@THID", SqlDbType.VarChar)
                                    };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = thid;

            CDuLieu dl = new CDuLieu();
            try
            {
                dl.ThucThiTraVeKetQuaKieuInt("NT_TraHang_KiemTraThanhToan", thamso);
                //if (dl.ThucThiTraVeKetQuaKieuInt("NT_TraHang_KiemTraThanhToan", thamso) > 0)
                //{
                    return (bool)thamso[0].Value;
                //}
                //else
                //    return false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable LayDataTheoSoCa(int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = soca_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_TraHang_LayDataTheoSoCa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayPhieuHuyTheoSoCa(int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = soca_;
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_TraHang_LayPhieuHuyTheoSoCa", thamso);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NT_TraHang_HuyPhieu(string thid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
                thamso[0].Value = thid;
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("NT_TraHang_HuyPhieu", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDanhSachTamTinh(string tenMayThuNgan, int soca_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenMayThuNgan", SqlDbType.VarChar)  ,
                                    new SqlParameter("@SoCa", SqlDbType.Int) };
            thamso[0].Value = tenMayThuNgan;
            thamso[1].Value = soca_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHang_LayDSPhieuTamTinh", thamso);
        }

        public int NT_TraHang_ThanhToan(string thid, string usertiepnhantrahang, string khid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar),
                                       new SqlParameter("@UserTiepNhanTraHang", SqlDbType.VarChar),
                                        new SqlParameter("@KHID", SqlDbType.VarChar) };
            thamso[0].Value = thid;
            thamso[1].Value = usertiepnhantrahang;
            thamso[2].Value = khid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NT_TRAHANG_THANHTOAN", thamso);
        }

        public DataTable NT_TraHang_LayDSLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHang_LayDSLenLuoi", thamso);
        }
        public DataTable NT_TraHangTuKhach_LayTienDaNhan_SoCTTra(string thid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = thid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("NT_TraHangTuKhach_LayTienDaNhan_SoCTTra", thamso);
        }
    }
}
