using ECOPharma2013.DuLieu;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ECOPharma2013.SQL
{
    class CSQLLSTonKhoKeToan
    {
        
    
        public DataTable LayThongTinLenLuoi(DateTime Ngay,string Key)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { 
                                            new SqlParameter("@Date", SqlDbType.Date), 
                                            new SqlParameter("@Key", SqlDbType.NVarChar)
                                         };

            thamsoinput[0].Value = Ngay.Date;
            thamsoinput[1].Value = Key;
            return LopDL.LoadTable("LichSuTonKhoKeToan_LayDanhSach", thamsoinput);
        }
        // DungLV Add method lay thong tin len luoi chi tiet start
        public DataTable LayThongTinLenLuoiChiTiet(DateTime Ngay, string Key)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { 
                                            new SqlParameter("@Date", SqlDbType.Date), 
                                            new SqlParameter("@Key", SqlDbType.NVarChar)
                                         };

            thamsoinput[0].Value = Ngay.Date;
            thamsoinput[1].Value = Key;
            return LopDL.LoadTable("LichSuTonKhoKeToanChiTiet_LayDanhSach", thamsoinput);
        }
        // DungLV Add method lay thong tin len luoi chi tiet end
        public DataTable LayThongTinNhaThuocLenLuoi(DateTime Ngay, string Key, string NTid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { 
                                            new SqlParameter("@Date", SqlDbType.Date), 
                                            new SqlParameter("@Key", SqlDbType.NVarChar),
                                            new SqlParameter("@NTid", SqlDbType.UniqueIdentifier)
                                         };
            thamsoinput[0].Value = Ngay.Date;
            thamsoinput[1].Value = Key;
            thamsoinput[2].Value = new Guid(NTid);
            return LopDL.LoadTable("LichSuTonKhoKeToan_LayDanhSachTheoNhaThuoc", thamsoinput);
        }
        // DungLV Add method lay thong tin len luoi chi tiet start
        public DataTable LayThongTinNhaThuocLenLuoiChiTiet(DateTime Ngay, string Key, string NTid)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { 
                                            new SqlParameter("@Date", SqlDbType.Date), 
                                            new SqlParameter("@Key", SqlDbType.NVarChar),
                                            new SqlParameter("@NTid", SqlDbType.UniqueIdentifier)
                                         };
            thamsoinput[0].Value = Ngay.Date;
            thamsoinput[1].Value = Key;
            thamsoinput[2].Value = new Guid(NTid);
            return LopDL.LoadTable("LichSuTonKhoKeToanChiTiet_LayDanhSachTheoNhaThuoc", thamsoinput);
        }
        // DungLV Add method lay thong tin len luoi chi tiet end
    }
}