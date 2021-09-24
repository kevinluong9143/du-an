using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLXuatNhanhCT
    {
        public DataTable LoadLenLuoi(string xnid)
        {
            SqlParameter[] thamso = { new SqlParameter("@XNID", SqlDbType.VarChar) };
            thamso[0].Value = xnid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("XUATNHANHCT_LOADLENLUOI", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Them(string xnid, string spid, string khoid, decimal slxuat, string dvxuatid, string lot, DateTime date, string nsxid, string xnctid)
        {
            SqlParameter []thamso = { new SqlParameter ("@XNID", SqlDbType.VarChar), 
                                        new SqlParameter ("@SPID", SqlDbType.VarChar), 
                                        new SqlParameter ("@KHOID", SqlDbType.VarChar), 
                                        new SqlParameter ("@SLXUAT", SqlDbType.Decimal), 
                                        new SqlParameter ("@DVXUATID", SqlDbType.VarChar), 
                                        new SqlParameter ("@LOT", SqlDbType.VarChar), 
                                        new SqlParameter ("@DATE", SqlDbType.DateTime), 
                                        new SqlParameter ("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter ("@XNCTID", SqlDbType.VarChar)
                                    };
            thamso[0].Value = xnid;
            thamso[1].Value = spid;
            thamso[2].Value = khoid;
            thamso[3].Value = slxuat;
            thamso[4].Value = dvxuatid;
            thamso[5].Value = lot;
            thamso[6].Value = date;
            thamso[7].Value = nsxid;
            thamso[8].Value = xnctid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("XUATNHANHCT_THEM", thamso);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Xoa(string xnctid)
        {
            SqlParameter[] thamso = { new SqlParameter("@XNCTID", SqlDbType.VarChar) };
            thamso[0].Value = xnctid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("XUATNHANHCT_XOA", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable In_XN_XNCT(string xnid)
        {
            SqlParameter[] thamso = { new SqlParameter("@XNid", SqlDbType.VarChar, 50) };
            thamso[0].Value = xnid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("XuatNhanhCT_In_XN_XNCT", thamso);
        }

        public bool KiemTraDanhSachChiTiet(string XNID)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@XNid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = new Guid(XNID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("XUATNHANH_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }

        public DataTable BaoCaoXuatNhanh_LoadDSTuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoXuatNhanh_LoadDSTuNgay_DenNgay", thamso);
        }
    }
}
