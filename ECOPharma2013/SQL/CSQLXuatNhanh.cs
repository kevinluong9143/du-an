using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLXuatNhanh
    {
        public DataTable LoadLenLuoi(bool isxemtatca)
        {
            SqlParameter [] thamso = {new SqlParameter("@isXemTatCa", SqlDbType.Bit)};
            thamso[0].Value = isxemtatca;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("XUATNHANH_LOADLENLUOI", thamso);
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

        public DataTable LoadLenLuoiXacNhan()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("XUATNHANH_LOADLENLUOIXACNHAN", null);
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

        public DataTable Load1XuatNhanh(string xnid)
        {
            SqlParameter [] thamso = {new SqlParameter("@XNID", SqlDbType.VarChar)};
            thamso[0].Value = xnid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("XUATNHANH_LOAD1RECORD", thamso);
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

        public DataTable LoadLyDoXuatLenCBO()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("LYDOXUAT_LAYLENCBO_1", null);
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

        public string[] Them(int ldid, string xuatdenid, string ghichu, string usertao, string xnid, bool IsKhoDacBiet)
        {
            SqlParameter []thamso = {
                                        new SqlParameter("@LDID", SqlDbType.Int),
                                        new SqlParameter("@XUATDENID", SqlDbType.VarChar),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@USERTAO", SqlDbType.VarChar),
                                        new SqlParameter("@XNID", SqlDbType.VarChar, 50),
                                        new SqlParameter("@SoPXN", SqlDbType.VarChar, 50),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = ldid;
            thamso[1].Value = xuatdenid;
            thamso[2].Value = ghichu;
            thamso[3].Value = usertao;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Direction = ParameterDirection.Output;
            thamso[6].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try{
            int kq = dl.ThucThiTraVeKetQuaKieuInt("XUATNHANH_THEM", thamso);
                if(kq>0)
                {
                    string[] xnid_sopxn = new string[2];
                    xnid_sopxn[0] = thamso[4].Value.ToString();
                    xnid_sopxn[1] = thamso[5].Value.ToString();
                    return xnid_sopxn;
                }
                else
                {
                    return null;
                }
            }
            catch(ApplicationException ex) {throw ex;}
            catch(Exception ex) {throw ex;}
        }

        public int Sua(int ldid, string xuatdenid, string ghichu, string userud, bool daxetduyet, string xnid, bool IsKhoDacBiet)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@LDID", SqlDbType.Int),
                                        new SqlParameter("@XUATDENID", SqlDbType.VarChar),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@USERUD", SqlDbType.VarChar),
                                        new SqlParameter("@DAXETDUYET", SqlDbType.Bit),
                                        new SqlParameter("@XNID", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = ldid;
            thamso[1].Value = xuatdenid;
            thamso[2].Value = ghichu;
            thamso[3].Value = userud;
            thamso[4].Value = daxetduyet;
            thamso[5].Value = xnid;
            thamso[6].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("XUATNHANH_SUA", thamso);
            }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public int XacNhan(string xnid, string userxacnhan)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@XNID", SqlDbType.VarChar),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar)};
            thamso[0].Value = xnid;
            thamso[1].Value = userxacnhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("XUATNHANH_XACNHAN", thamso);
            }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public int Xoa(string xnid, string userxoa)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@XNID", SqlDbType.VarChar),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar)};
            thamso[0].Value = xnid;
            thamso[1].Value = userxoa;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("XUATNHANH_XOA", thamso);
            }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }


        public bool IsKhoDacBiet(string XNID)
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
    }
}
