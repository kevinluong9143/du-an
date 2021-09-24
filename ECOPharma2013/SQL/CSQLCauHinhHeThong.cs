﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLCauHinhHeThong
    {
        string _sMaTTCN;
        public string SMaTTCN
        {
            get { return _sMaTTCN; }
            set { _sMaTTCN = value; }
        }
        string _sTenChiNhanh;

        public string STenChiNhanh
        {
            get { return _sTenChiNhanh; }
            set { _sTenChiNhanh = value; }
        }

        decimal _fTienQuy;

        public decimal FTienQuy
        {
            get { return _fTienQuy; }
            set { _fTienQuy = value; }
        }
        string _sBoPhan;

        public string SBoPhan
        {
            get { return _sBoPhan; }
            set { _sBoPhan = value; }
        }

        int _iMucTonKho;

        public int IMucTonKho
        {
            get { return _iMucTonKho; }
            set { _iMucTonKho = value; }
        }
        int _iChuKyDatHang;

        public int IChuKyDatHang
        {
            get { return _iChuKyDatHang; }
            set { _iChuKyDatHang = value; }
        }
        public CSQLCauHinhHeThong() { }

        public CSQLCauHinhHeThong(string maTTCN, string tenchinhanh, decimal tienquy, string bophan)
        {
            SMaTTCN = maTTCN;
            STenChiNhanh = tenchinhanh;
            FTienQuy = tienquy;
            SBoPhan = bophan;
        }

        public CSQLCauHinhHeThong(string maTTCN, string tenchinhanh, decimal tienquy, string bophan, int muctonkho, int chukydathang)
        {
            SMaTTCN = maTTCN;
            STenChiNhanh = tenchinhanh;
            FTienQuy = tienquy;
            SBoPhan = bophan;
            IMucTonKho = muctonkho;
            IChuKyDatHang = chukydathang;
        }
        public DataTable LayDanhSachCauHinhHeThong()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                DataTable dtb = dl.LoadTable("TTCN_LoadCauHinhHeThong", null);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public DataTable LayThongTinServerTongCty()
        {
            try
            {
                CDuLieu LopDL = new CDuLieu();
                return LopDL.LoadTable("NT_ECO_Conf_Inf", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SuaThongTinServerTongCty(string server,string user, string pass, string data)
        {
            CDuLieu LopDL = new CDuLieu();
            CMaHoa LopMaHoa = new CMaHoa();
            SqlParameter[] thamsoinput = { new SqlParameter("@ServerPath", SqlDbType.VarChar, 100), new SqlParameter("@UserData", SqlDbType.VarChar, 100), new SqlParameter("@PassData", SqlDbType.VarChar, 100), new SqlParameter("@Data", SqlDbType.VarChar, 100)};
            thamsoinput[0].Value = LopMaHoa.MaHoa(server);
            thamsoinput[1].Value = LopMaHoa.MaHoa(user);
            thamsoinput[2].Value = LopMaHoa.MaHoa(pass);
            thamsoinput[3].Value = LopMaHoa.MaHoa(data);

            SqlParameter KetQuaTraVe = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("NT_ECO_Update", thamsoinput, KetQuaTraVe);
        }

        public string ThemMoiCauHinhHeThong(CSQLCauHinhHeThong chht_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TTCNid", SqlDbType.VarChar), 
                                    new SqlParameter("@TenChiNhanh", SqlDbType.NVarChar),
                                    new SqlParameter("@TienQuy", SqlDbType.Decimal),
                                    new SqlParameter("@BoPhan", SqlDbType.VarChar),
                                    new SqlParameter("@KetQua", SqlDbType.VarChar, 50),
                                    new SqlParameter("@MucTonKho", SqlDbType.Int),
                                    new SqlParameter("@ChuKyDatHang", SqlDbType.Int)
                                    };
            thamso[0].Value = chht_.SMaTTCN;
            thamso[1].Value = chht_.STenChiNhanh;
            thamso[2].Value = chht_.FTienQuy;
            thamso[3].Value = chht_.SBoPhan;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Value = chht_.IMucTonKho;
            thamso[6].Value = chht_.IChuKyDatHang;
            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("TTCN_ThemMoiCauHinhHeThong", thamso, null);
                return thamso[4].Value.ToString();
            }
            catch (Exception Exception) { throw Exception; }
        }

        public int XoaThongTinCauHinhHeThong(string _maTTCN)
        {
            SqlParameter[] thamso = { new SqlParameter("@TTCNid", SqlDbType.VarChar) };
            thamso[0].Value = _maTTCN;
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("TTCN_XoaThongTinCauHinhHeThong", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

        }

        public string LayMaBPThongTinChiNhanh()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("TTCN_LayMaBP", null);
            try
            {
                return dtb.Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public void CapNhatXemKhoDacBiet(bool IsMo, bool isDonTraLoi)
        {
            CDuLieu dl = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsMo", SqlDbType.Bit),
                                        // DungLV thêm mới field đơn trả hàng lỗi 
                                        new SqlParameter("@isDonTraLoi", SqlDbType.Bit)
                                        // DungLV thêm mới field đơn trả hàng lỗi 
                                    };
            thamso[0].Value = IsMo;
            // DungLV thêm mới field đơn trả hàng lỗi 
            thamso[1].Value = isDonTraLoi;
            //dl.ThucThi("TTCN_CapNhatXemKhoDacBiet", thamso);
            dl.ThucThi("TTCN_CapNhatXemKhoDacBiet_TraDonHang", thamso);
            // DungLV thêm mới field đơn trả hàng lỗi 
        }

        public bool KiemTraTrangThaiXemKhoDacBiet()
        {
            CDuLieu dl = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsMo", SqlDbType.Bit)
                                    };
            thamso[0].Direction = ParameterDirection.Output;

            dl.ThucThi("TTCN_XemTrangThaiXemKhoDacBiet", thamso);

            return Boolean.Parse(thamso[0].Value.ToString());
        }

        public bool KiemTraTrangThaiDonTraLoi()
        {
            CDuLieu dl = new CDuLieu();
            SqlParameter[] thamso = { 
                                        new SqlParameter("@IsMo", SqlDbType.Bit)
                                    };
            thamso[0].Direction = ParameterDirection.Output;

            dl.ThucThi("TTCN_XemTrangThaiXemDonTraLoi", thamso);

            return Boolean.Parse(thamso[0].Value.ToString());
        }
    }
}