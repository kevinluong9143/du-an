﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_TraHangVeCty
    {
        public string[] Them(string dest, string ghichu, DateTime ngaytao, string usertao, int loaihangtra, bool IsKhoDacBiet, bool IsTraDacBiet)
        {
            // DungLV thêm mới field isTraDacBiet 
            SqlParameter[] thamso = {  
                                        new SqlParameter("@DESTINATION", SqlDbType.VarChar),
                                        new SqlParameter("@LoaiHangTra", SqlDbType.Int),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@NGAYTAO", SqlDbType.DateTime),
                                        new SqlParameter("@USERTAO", SqlDbType.VarChar),
                                        new SqlParameter("@THID", SqlDbType.VarChar,50),
                                        new SqlParameter("@SOPTH", SqlDbType.VarChar,12),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        // DungLV thêm mới field isTraDacBiet 
                                         new SqlParameter("@IsTraDacBiet", SqlDbType.Bit),
                                        // DungLV thêm mới field isTraDacBiet 
                                     };
            thamso[0].Value = dest;
            thamso[1].Value = loaihangtra;
            thamso[2].Value = ghichu;
            thamso[3].Value = ngaytao;
            thamso[4].Value = usertao;
            thamso[5].Direction = ParameterDirection.Output;
            thamso[6].Direction = ParameterDirection.Output;
            thamso[7].Value = IsKhoDacBiet;
            // DungLV thêm mới field isTraDacBiet 
            thamso[8].Value = IsTraDacBiet;
            // DungLV thêm mới field isTraDacBiet 
            CDuLieu dl = new CDuLieu();
            try
            {
                //dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTY_THEM", thamso);
                dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTY_THEM_DONTRALOI", thamso);
                
                string[] THID_SOPTH = new string[2];
                if (thamso[4].Value != null && thamso[4].Value.ToString().Length > 0)
                {
                    THID_SOPTH[0] = thamso[5].Value.ToString();
                    THID_SOPTH[1] = thamso[6].Value.ToString();
                }
                else
                {
                    THID_SOPTH[0] = "00000000-0000-0000-0000-000000000000";
                    THID_SOPTH[1] = "000000000000";
                }
                return THID_SOPTH;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Sua(string THID, string dest, string ghichu, DateTime lastud, string userud, bool daxetduyet, DateTime ngayxetduyet, string userxetduyet, int loaihangtra, bool IsKhoDacBiet, bool IsTraDacBiet)
        {
            // DungLV thêm mới field isTraDacBiet 
            SqlParameter[] thamso = {  
                                        new SqlParameter("@THID", SqlDbType.VarChar),
                                        new SqlParameter("@DESTINATION", SqlDbType.VarChar),
                                        new SqlParameter("@LOAIHANGTRA", SqlDbType.Int),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@LASTUD", SqlDbType.DateTime),
                                        new SqlParameter("@USERUD", SqlDbType.VarChar),
                                        new SqlParameter("@DAXETDUYET", SqlDbType.Bit),
                                        new SqlParameter("@NGAYXETDUYET", SqlDbType.DateTime),
                                        new SqlParameter("@USERXETDUYET", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        // DungLV thêm mới field isTraDacBiet 
                                        new SqlParameter("@IsTraDacBiet", SqlDbType.Bit)
                                        // DungLV thêm mới field isTraDacBiet 
                                     };
            thamso[0].Value = THID;
            thamso[1].Value = dest;
            thamso[2].Value = loaihangtra;
            thamso[3].Value = ghichu;
            thamso[4].Value = lastud;
            thamso[5].Value = userud;
            thamso[6].Value = daxetduyet;
            thamso[7].Value = ngayxetduyet;
            thamso[8].Value = userxetduyet;
            thamso[9].Value = IsKhoDacBiet;
            // DungLV thêm mới field isTraDacBiet 
            thamso[10].Value = IsTraDacBiet;
            // DungLV thêm mới field isTraDacBiet 
            CDuLieu dl = new CDuLieu();
            try
            {
                //DataTable dtb = dl.LoadTable("NTTRAHANGVECTY_SUA", thamso);
                DataTable dtb = dl.LoadTable("NTTRAHANGVECTY_SUA_DONTRALOI", thamso);
                if (dtb != null && dtb.Rows.Count > 0)
                    return dtb;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDSLenLuoi(bool IsXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = IsXemTatCa;
            CDuLieu dl = new CDuLieu();
            try
            {
                // DungLV thêm mới field đơn trả hàng lỗi 
                //return dl.LoadTable("NTTRAHANGVECTY_LOADLENLUOI", thamso);
                return dl.LoadTable("NTTRAHANGVECTY_LOADLENLUOI_TRADONHANGLOI", thamso);
                // DungLV thêm mới field đơn trả hàng lỗi 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayTraHang(string THID)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = THID;
            CDuLieu dl = new CDuLieu();
            try
            {
                // DungLV thêm mới field đơn trả hàng lỗi 
                //return dl.LoadTable("NTTRAHANGVECTY_LAYTraHang", thamso);
                return dl.LoadTable("NTTRAHANGVECTY_LAYTRAHANG_TRADONHANG", thamso);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayTraHangLenLuoiXacNhan(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NTTRAHANGVECTY_LAYLENLUOIXACNHAN", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime XacNhanTraHang(string THID, DateTime ngayxacnhan, string userxacnhan)
        {
            DateTime NGAYXACNHAN = DateTime.MinValue;

            SqlParameter[] thamso = {   new SqlParameter("@THID", SqlDbType.VarChar),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                    };
            thamso[0].Value = THID;
            thamso[1].Direction = ParameterDirection.Output;
            thamso[2].Value = userxacnhan;
            CDuLieu dl = new CDuLieu();
            try
            {
                if (dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTY_XACNHAN", thamso) > 0)
                {
                    string s = thamso[1].Value.ToString();
                    NGAYXACNHAN= DateTime.Parse(thamso[1].Value.ToString());
                }

                return NGAYXACNHAN;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CapNhatIsDaChuyenVeCty(string thid)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = thid;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTY_CAPNHATISDACHUYENVECTY", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int XoaToanBo(string THID)
        {
            SqlParameter[] thamso = { new SqlParameter("@THID", SqlDbType.VarChar) };
            thamso[0].Value = THID;
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("NTTRAHANGVECTY_XOATOANBO", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsKhoDacBiet(string THID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@THid", SqlDbType.UniqueIdentifier), 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(THID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NTTRAHANGVECTY_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
    }
}
