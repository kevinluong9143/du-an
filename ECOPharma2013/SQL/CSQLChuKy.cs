using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECOPharma2013.DuLieu;
using System.Data.SqlClient;
using System.Data;

namespace ECOPharma2013.SQL
{
    class CSQLChuKy
    {
        int _ChuKyID;

        public int ChuKyID
        {
            get { return _ChuKyID; }
            set { _ChuKyID = value; }
        }
        string _NhomSPID;

        public string NhomSPID
        {
            get { return _NhomSPID; }
            set { _NhomSPID = value; }
        }
        DateTime _NgayTao;

        public DateTime NgayTao
        {
            get { return _NgayTao; }
            set { _NgayTao = value; }
        }
        string _NhanVienTao;

        public string NhanVienTao
        {
            get { return _NhanVienTao; }
            set { _NhanVienTao = value; }
        }
        bool _IsKetThuc;

        public bool IsKetThuc
        {
            get { return _IsKetThuc; }
            set { _IsKetThuc = value; }
        }
        DateTime _NgayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }
        string _NhanVienKetThuc;

        public string NhanVienKetThuc
        {
            get { return _NhanVienKetThuc; }
            set { _NhanVienKetThuc = value; }
        }

        public CSQLChuKy() { }
        public CSQLChuKy(int chuKyID, string nhomSPID, DateTime ngayTao, string nhanVienTao, bool isKetThuc, DateTime ngayKetThuc, string nhanVienKetThuc)
        {
            this.ChuKyID = chuKyID;
            this.NhomSPID = nhomSPID;
            this.NgayTao = ngayTao;
            this.NhanVienTao = nhanVienTao;
            this.IsKetThuc = isKetThuc;
            this.NgayKetThuc = ngayKetThuc;
            this.NhanVienKetThuc = nhanVienKetThuc;
        }

        public int Them(string nhomspid, string nhanVienTao)
        {
            SqlParameter [] thamso = {  
                                        new SqlParameter("@NhomSPID", nhomspid),
                                        new SqlParameter("@NhanVienTao", nhanVienTao)
                                     };

            CDuLieu dl = new CDuLieu();
            try
            {
                int chukyid = dl.ThucThiTraVeKetQuaKieuInt("EcoChuKy_Them", thamso);
                return chukyid; 
            }
            catch (Exception ex)
            { throw ex; }            
        }

        public int KetThuc(int chuKyID, string nhanVienKetThuc)
        {
            SqlParameter[] thamso = {   
                                        new SqlParameter("@ChuKyID", chuKyID),
                                        new SqlParameter("@NhanVienKetThuc", nhanVienKetThuc)
                                     };
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoChuKy_KetThuc", thamso);
                return kq;
            }
            catch (Exception ex)
            { throw ex; }    
        }

        public DataTable LoadLenLuoi(bool xemtatca)
        {
            SqlParameter [] thamso = {   
                                        new SqlParameter("@XemTatCa", xemtatca)
                                     };
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable kq = dl.LoadTable("EcoChuKy_LoadLenLuoi", thamso);
                return kq;
            }
            catch (Exception ex)
            { throw ex; }    
        }

        //EcoChuKy_KetThucChuKy(@NhomSPID uniqueidentifier, @NhanVienKetThuc uniqueidentifier)
        public int KetThucChuKy(string nhomspid, string nhanvienketthuc)
        {
            SqlParameter[] thamso = {   
                                        new SqlParameter("@NhomSPID", nhomspid),
                                        new SqlParameter("@NhanVienKetThuc", nhanvienketthuc)
                                     };
            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoChuKy_KetThucChuKy", thamso);
                return kq;
            }
            catch (Exception ex)
            { throw ex; }   
        }
    }
}
