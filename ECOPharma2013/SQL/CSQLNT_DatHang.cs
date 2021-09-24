using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLNT_DatHang
    {
        public string[] Them(bool donkhan, string ghichu, DateTime ngaytao, string usertao, bool IsKhoDacBiet, string nhomspid = null)
        {
            SqlParameter [] thamso ={   new SqlParameter("@DONKHAN", SqlDbType.Bit),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@NGAYTAO", SqlDbType.DateTime),
                                        new SqlParameter("@USERTAO", SqlDbType.VarChar),
                                        new SqlParameter("@DHID", SqlDbType.VarChar,50),
                                        new SqlParameter("@SODH", SqlDbType.VarChar,50),
                                        new SqlParameter("@NhomSPID", SqlDbType.VarChar,50),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = donkhan;
            thamso[1].Value = ghichu;
            thamso[2].Value = ngaytao;
            thamso[3].Value = usertao;
            thamso[4].Direction = ParameterDirection.Output;
            thamso[5].Direction = ParameterDirection.Output;
            thamso[6].Value = nhomspid;
            thamso[7].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try{
            int kq = dl.ThucThiTraVeKetQuaKieuInt("DATHANG_THEMDATHANG", thamso);
            if(kq > 0)
            {
                string []dhid_sodh = {thamso[4].Value.ToString(), thamso[5].Value.ToString()};
                return dhid_sodh;
            }
            else
                return null;}
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public DataTable LoadLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@isXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;

            CDuLieu dl = new CDuLieu();
            try 
            {
                return dl.LoadTable("DATHANG_LOADLENLUOI", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LayDatHang(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            CDuLieu dl = new CDuLieu();
            try 
            {
                return dl.LoadTable("DATHANG_LAYDATHANG", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Sua(string dhid, string ghichu, bool duyetdh, string userud, bool IsKhoDacBiet)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DHID", SqlDbType.VarChar),
                                        new SqlParameter("@GHICHU", SqlDbType.NVarChar),
                                        new SqlParameter("@DUYETDH", SqlDbType.Bit),
                                        new SqlParameter("@USERUD", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit)
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = ghichu;
            thamso[2].Value = duyetdh;
            thamso[3].Value = userud;
            thamso[4].Value = IsKhoDacBiet;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANG_SUA",thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLenLuoi_XacNhan()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("DATHANG_LOADLENLUOIXACNHAN", null);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int XacNhan(string dhid, string userxacnhan)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar),
                                    new SqlParameter("@UserXacNhan", SqlDbType.NVarChar)};
            thamso[0].Value = dhid;
            thamso[1].Value = userxacnhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANG_XACNHAN", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CAPNHATLAI_XACNHAN(string dhid, string userxacnhan)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar),
                                    new SqlParameter("@UserXacNhan", SqlDbType.NVarChar)};
            thamso[0].Value = dhid;
            thamso[1].Value = userxacnhan;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANG_CAPNHATLAI_XACNHAN", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Them_DonHangXuat_TaiTCty(string dhid, string sodh, string noidh, string xuatchont, bool donkhan, string ghichu, string usernhap, bool IsKhoDacBiet, string nhomspid = null)
        {
            SqlParameter[] thamso = {   new SqlParameter("@DHID", SqlDbType.VarChar),
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@NoiDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        new SqlParameter("@Nhomspid", SqlDbType.VarChar)
                                  };
            thamso[0].Value = dhid;
            thamso[1].Value = sodh;
            thamso[2].Value = noidh;
            thamso[3].Value = xuatchont;
            thamso[4].Value = donkhan;
            thamso[5].Value = ghichu;
            thamso[6].Value = usernhap;
            thamso[7].Value = IsKhoDacBiet;
            thamso[8].Value = nhomspid;

            CDuLieuRemote dl = new CDuLieuRemote();
            try
            {
                dl.InsertDuLieu("DATHANG_THEMDONHANGXUAT_TONGCTY", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        public int CapNhat_DaChuyenVeTongCty(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar)};
            thamso[0].Value = dhid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANG_CAPNHATDACHUYENVETONGCTY", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Xoa(string dhid, string userxoa)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar),
                                      new SqlParameter("@UserXoa", SqlDbType.VarChar)  };
            thamso[0].Value = dhid;
            thamso[1].Value = userxoa;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.ThucThiTraVeKetQuaKieuInt("DATHANG_XOA", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayTongTienSauKhiDatHang()
        {
            CDuLieu dl = new CDuLieu();
            try
            {
                DataTable dtb = dl.LoadTable("NT_DatHang_LayTongTienSauKhiDatHang", null);
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Them_DonHang_DinhMuc(string SoDonHangDat, decimal DinhMucTonCuaHang, decimal TongTienTonCuaHang, decimal TongTienDatHang, decimal TongTienSauKhiDatHang, decimal DuoiOrQuaDM)
        {
            SqlParameter[] thamso = {   
                                        new SqlParameter("@DHDMid", SqlDbType.VarChar, 50),
                                        new SqlParameter("@SoDonHangDat", SqlDbType.VarChar),
                                        new SqlParameter("@DinhMucTonCuaHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienTonCuaHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienDatHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienSauKhiDatHang", SqlDbType.Decimal),
                                        new SqlParameter("@DuoiOrQuaDM", SqlDbType.Decimal)
                                  };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = SoDonHangDat;
            thamso[2].Value = DinhMucTonCuaHang;
            thamso[3].Value = TongTienTonCuaHang;
            thamso[4].Value = TongTienDatHang;
            thamso[5].Value = TongTienSauKhiDatHang;
            thamso[6].Value = DuoiOrQuaDM;


            CDuLieu dl = new CDuLieu();
            try
            {
                dl.InsertDuLieu("NT_DatHang_ThemCacLoaiTien", thamso, null);
                return thamso[0].Value.ToString();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Sua_DonHang_DinhMuc(string SoDonHangDat, decimal DinhMucTonCuaHang, decimal TongTienTonCuaHang, decimal TongTienDatHang, decimal TongTienSauKhiDatHang, decimal DuoiOrQuaDM)        
        {
            SqlParameter[] thamso = {   new SqlParameter("@SoDonHangDat", SqlDbType.VarChar),
                                        new SqlParameter("@DinhMucTonCuaHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienTonCuaHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienDatHang", SqlDbType.Decimal),
                                        new SqlParameter("@TongTienSauKhiDatHang", SqlDbType.Decimal),
                                        new SqlParameter("@DuoiOrQuaDM", SqlDbType.Decimal)
                                  };
            thamso[0].Value = SoDonHangDat;
            thamso[1].Value = DinhMucTonCuaHang;
            thamso[2].Value = TongTienTonCuaHang;
            thamso[3].Value = TongTienDatHang;
            thamso[4].Value = TongTienSauKhiDatHang;
            thamso[5].Value = DuoiOrQuaDM;

            CDuLieu dl = new CDuLieu();
            try
            {
                int kq = dl.ThucThiTraVeKetQuaKieuInt("NT_DatHang_SuaCacLoaiTien", thamso);
                return kq;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public DataTable LayDatHang_DinhMuc(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDonHangDat", SqlDbType.VarChar) };
            thamso[0].Value = dhid;

            CDuLieu dl = new CDuLieu();
            try
            {
                return dl.LoadTable("NT_DatHang_LayDatHangDinhMuc", thamso);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsKhoDacBiet(string DHID)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@DHid", SqlDbType.UniqueIdentifier), 
                                        new SqlParameter("@IsHangDacBiet", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(DHID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("NTDatHang_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
    }
}
