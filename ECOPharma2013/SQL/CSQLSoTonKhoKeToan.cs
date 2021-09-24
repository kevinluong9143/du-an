using ECOPharma2013.DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECOPharma2013.SQL
{
    class CSQLSoTonKhoKeToan
    {
        #region Old Code
        /*
         private string _SoID;
        private DateTime _TuNgay;
        private DateTime _DenNgay;
        private Boolean _TinhTrangSoHT_IsKhoa;
        private string _SoKT;
        private int _TT;
        private DateTime? _NgayCapNhat;

        public string SoID {
            get { return _SoID; }
            set { _SoID = value; }
        }

        public DateTime TuNgay {
            get { return _TuNgay; }
            set { _TuNgay = value; }
        }

        public DateTime DenNgay
        {
            get { return _DenNgay; }
            set { _DenNgay = value; }
        }

        public Boolean TinhTrangSoHT_IsKhoa {
            get { return _TinhTrangSoHT_IsKhoa; }
            set { _TinhTrangSoHT_IsKhoa = value; }
        }

        public string SoKT
        {
            get { return _SoKT; }
            set { _SoKT = value; }
        }

        public int TT
        {
            get { return _TT; }
            set { _TT = value; }
        }

        public DateTime? NgayCapNhat {
            get { return _NgayCapNhat; }
            set { _NgayCapNhat = value; }
        }
         */
        #endregion

        public string _SoID { get; set; }
        public DateTime _TuNgay { get; set; }
        public DateTime _DenNgay { get; set; }
        public Boolean _TinhTrangSoHT_IsKhoa { get; set; }
        public string _SoKT { get; set; }
        public int _TT { get; set; }
        public DateTime? _NgayCapNhat { get; set; }

        public string KiemTraSoTonKhoKeToanBiKhoa() {
            try
            {
                CDuLieu LopDL = new CDuLieu();
                SqlParameter[] ThamSo = { 
                                            new SqlParameter("@Message", SqlDbType.NVarChar, 100) 
                                        };
                ThamSo[0].Direction = ParameterDirection.Output;

                LopDL.LoadTable("KeToan_KiemTraSoTonKhoKeToanBiKhoa", ThamSo);

                return ThamSo[0].Value.ToString();
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string TaoSoTonKhoKeToan()
        {
            try
            {
                CDuLieu LopDL = new CDuLieu();
                SqlParameter[] ThamSo = { 
                                            new SqlParameter("@Message", SqlDbType.NVarChar, 100) 
                                        };
                ThamSo[0].Direction = ParameterDirection.Output;

                LopDL.LoadTable("KeToan_TaoSoTonKhoKeToan", ThamSo);

                return ThamSo[0].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
