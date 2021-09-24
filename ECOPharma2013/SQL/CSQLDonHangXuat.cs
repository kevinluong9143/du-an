using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLDonHangXuat
    {
        string _SDHID;

        public string SDHID
        {
            get { return _SDHID; }
            set { _SDHID = value; }
        }
        string _SSoDonHang;

        public string SSoDonHang
        {
            get { return _SSoDonHang; }
            set { _SSoDonHang = value; }
        }
        string _SNoiDH;

        public string SNoiDH
        {
            get { return _SNoiDH; }
            set { _SNoiDH = value; }
        }
        string _SXuatChoNT;

        public string SXuatChoNT
        {
            get { return _SXuatChoNT; }
            set { _SXuatChoNT = value; }
        }
        bool _BDonKhan;

        public bool BDonKhan
        {
            get { return _BDonKhan; }
            set { _BDonKhan = value; }
        }
        bool _BDuyetDH;

        public bool BDuyetDH
        {
            get { return _BDuyetDH; }
            set { _BDuyetDH = value; }
        }
        bool _BDaXacNhanDH;

        public bool BDaXacNhanDH
        {
            get { return _BDaXacNhanDH; }
            set { _BDaXacNhanDH = value; }
        }
        DateTime _DNgayDuyetDH;

        public DateTime DNgayDuyetDH
        {
            get { return _DNgayDuyetDH; }
            set { _DNgayDuyetDH = value; }
        }
        bool _BDaXuatDu;

        public bool BDaXuatDu
        {
            get { return _BDaXuatDu; }
            set { _BDaXuatDu = value; }
        }
        string _SGhiChu;

        public string SGhiChu
        {
            get { return _SGhiChu; }
            set { _SGhiChu = value; }
        }
        DateTime _DLastUD;

        public DateTime DLastUD
        {
            get { return _DLastUD; }
            set { _DLastUD = value; }
        }
        DateTime _DNgayXacNhan;

        public DateTime DNgayXacNhan
        {
            get { return _DNgayXacNhan; }
            set { _DNgayXacNhan = value; }
        }
        DateTime _DNgayTao;

        public DateTime DNgayTao
        {
            get { return _DNgayTao; }
            set { _DNgayTao = value; }
        }
        bool _BIsXoa;

        public bool BIsXoa
        {
            get { return _BIsXoa; }
            set { _BIsXoa = value; }
        }
        string _SUserNhap;

        public string SUserNhap
        {
            get { return _SUserNhap; }
            set { _SUserNhap = value; }
        }
        string _SUserDuyet;

        public string SUserDuyet
        {
            get { return _SUserDuyet; }
            set { _SUserDuyet = value; }
        }
        string _SUserXacNhan;

        public string SUserXacNhan
        {
            get { return _SUserXacNhan; }
            set { _SUserXacNhan = value; }
        }
        string _SUserXoa;

        public string SUserXoa
        {
            get { return _SUserXoa; }
            set { _SUserXoa = value; }
        }

        Boolean _IsKhoDacBiet;
        public bool SIsKhoDacBiet
        {
            get { return _IsKhoDacBiet; }
            set { _IsKhoDacBiet = value; }
        }
        // DungLV add Xuat Chi Dinh Don Hang Start
        Boolean _IsXuatCoChiDinh;
        public Boolean SIsXuatCoChiDinh
        {
            get { return _IsXuatCoChiDinh; }
            set { _IsXuatCoChiDinh = value; }
        }

        Boolean _IsXuatThuCong;
        public Boolean SIsXuatThuCong
        {
            get { return _IsXuatThuCong; }
            set { _IsXuatThuCong = value; }
        }

        // DungLV add Xuat Chi Dinh Don Hang end
        public CSQLDonHangXuat() { }

        public string [] Them(CSQLDonHangXuat dhx)
        {
            SqlParameter [] thamso = {  new SqlParameter("@SoDH", SqlDbType.VarChar, 12),
                                        new SqlParameter("@NoiDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@DuyetDH", SqlDbType.Bit),
                                        new SqlParameter("@DaXacNhanDH", SqlDbType.Bit),
                                        new SqlParameter("@NgayDuyetDH", SqlDbType.DateTime),
                                        new SqlParameter("@DaXuatDu", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@UserDuyet", SqlDbType.VarChar),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar),
                                        new SqlParameter("@DHID", SqlDbType.VarChar,50),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        // DungLV add Xuat Chi Dinh Don Hang Start
                                        new SqlParameter("@IsXuatCoChiDinh", SqlDbType.Bit),
                                        new SqlParameter("@IsXuatTuDong", SqlDbType.Bit)
                                        // DungLV add Xuat Chi Dinh Don Hang End
                                  };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = dhx.SNoiDH;
            thamso[2].Value = dhx.SXuatChoNT;
            thamso[3].Value = dhx.BDonKhan;
            thamso[4].Value = dhx.BDuyetDH;
            thamso[5].Value = dhx.BDaXacNhanDH;
            thamso[6].Value = dhx.DNgayDuyetDH;
            thamso[7].Value = dhx.BDaXuatDu;
            thamso[8].Value = dhx.SGhiChu;
            thamso[9].Value = dhx.DLastUD;
            thamso[10].Value = dhx.DNgayXacNhan;
            thamso[11].Value = dhx.DNgayTao;
            thamso[12].Value = dhx.BIsXoa;
            thamso[13].Value = dhx.SUserNhap;
            thamso[14].Value = dhx.SUserDuyet;
            thamso[15].Value = dhx.SUserXacNhan;
            thamso[16].Value = dhx.SUserXoa;
            thamso[17].Direction = ParameterDirection.Output;
            thamso[18].Value = dhx.SIsKhoDacBiet;
            // DungLV add Xuat Chi Dinh Don Hang Start
            thamso[19].Value = dhx.SIsXuatCoChiDinh;
            thamso[20].Value = dhx.SIsXuatThuCong; 
            // DungLV add Xuat Chi Dinh Don Hang End
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang Start
            //dl.InsertDuLieu("DonHangXuat_Them", thamso, null);
            ///dl.InsertDuLieu("DonHangXuat_XuatCoChiDinh_Them", thamso, null);
            dl.InsertDuLieu("DonHangXuat_XuatCoChiDinh_ThemHoaDon", thamso, null);
            // DungLV add Xuat Chi Dinh Don Hang End
            return new string[] {thamso[0].Value.ToString(), thamso[17].Value.ToString()}; 
        }
        public int Sua(CSQLDonHangXuat dhx)
        {
            SqlParameter[] thamso = {  new SqlParameter("@SoDH", SqlDbType.VarChar, 12),
                                        new SqlParameter("@NoiDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@DuyetDH", SqlDbType.Bit),
                                        new SqlParameter("@DaXacNhanDH", SqlDbType.Bit),
                                        new SqlParameter("@NgayDuyetDH", SqlDbType.DateTime),
                                        new SqlParameter("@DaXuatDu", SqlDbType.Bit),
                                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayXacNhan", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@UserNhap", SqlDbType.VarChar),
                                        new SqlParameter("@UserDuyet", SqlDbType.VarChar),
                                        new SqlParameter("@UserXacNhan", SqlDbType.VarChar),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar),
                                        new SqlParameter("@IsKhoDacBiet", SqlDbType.Bit),
                                        // DungLV add Xuat Chi Dinh Don Hang Start
                                        new SqlParameter("@IsXuatCoChiDinh", SqlDbType.Bit),
                                        new SqlParameter("@IsXuatTuDong", SqlDbType.Bit)
                                        // DungLV add Xuat Chi Dinh Don Hang End

                                  };
            thamso[0].Value = dhx.SSoDonHang;
            thamso[1].Value = dhx.SNoiDH;
            thamso[2].Value = dhx.SXuatChoNT;
            thamso[3].Value = dhx.BDonKhan;
            thamso[4].Value = dhx.BDuyetDH;
            thamso[5].Value = dhx.BDaXacNhanDH;
            thamso[6].Value = dhx.DNgayDuyetDH;
            thamso[7].Value = dhx.BDaXuatDu;
            thamso[8].Value = dhx.SGhiChu;
            thamso[9].Value = dhx.DLastUD;
            thamso[10].Value = dhx.DNgayXacNhan;
            thamso[11].Value = dhx.DNgayTao;
            thamso[12].Value = dhx.BIsXoa;
            thamso[13].Value = dhx.SUserNhap;
            thamso[14].Value = dhx.SUserDuyet;
            thamso[15].Value = dhx.SUserXacNhan;
            thamso[16].Value = dhx.SUserXoa;
            thamso[17].Value = dhx.SIsKhoDacBiet;
            // DungLV add Xuat Chi Dinh Don Hang Start
            thamso[18].Value = dhx.SIsXuatCoChiDinh;
            thamso[19].Value = dhx.SIsXuatThuCong; 
            // DungLV add Xuat Chi Dinh Don Hang End
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang Start
            // int kq = dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_Sua", thamso);
            // int kq = dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_XuatCoChiDinh_Sua", thamso);
            int kq = dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_XuatCoChiDinh_SuaHoaDon", thamso);
            // DungLV add Xuat Chi Dinh Don Hang End
            return kq;
        }
        public string LayDHXIDTheoSoDH(string soDH)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar, 12) };
            thamso[0].Value = soDH;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("DonHangXuat_LayDHXIDTheoSoDH", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
        }
        public DataTable LayDLLenLuoi(bool isXemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@IsXemTatCa", SqlDbType.Bit) };
            thamso[0].Value = isXemTatCa;
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang, don hang thu cong start
            //return dl.LoadTable("DonHangXuat_LayLenLuoi", thamso);
            return dl.LoadTable("DonHangXuat_XuatCoChiDinh_LayLenLuoi", thamso);
            // DungLV add Xuat Chi Dinh Don Hang don hang thu cong End
        }
        public CSQLDonHangXuat LayThongTinLenDHXCTedit(string dhid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
                thamso[0].Value = dhid;

                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // DataTable dtb = dl.LoadTable("DonHangXuat_LayThongTinLenFrmDonHangXuatCT", thamso);
                DataTable dtb = dl.LoadTable("DonHangXuat_XuatCoChiDinh_LayThongTinLenFrmDonHangXuatCT", thamso);
                // DungLV add Xuat Chi Dinh Don Hang End
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    CSQLDonHangXuat dhx = new CSQLDonHangXuat();
                    dhx.SDHID = dtb.Rows[0]["DHID"].ToString();
                    dhx.SSoDonHang = dtb.Rows[0]["SoDHChung"].ToString();
                    dhx.SNoiDH = dtb.Rows[0]["NoiDH"].ToString();
                    dhx.SXuatChoNT = dtb.Rows[0]["XuatChoNT"].ToString();
                    dhx.BDonKhan = (bool)dtb.Rows[0]["DonKhan"];
                    dhx.BDuyetDH = (bool)dtb.Rows[0]["DuyetDH"];
                    dhx.SGhiChu = dtb.Rows[0]["GhiChu"].ToString();
                    dhx.DNgayTao = DateTime.Parse(dtb.Rows[0]["NgayTao"].ToString());
                    // DungLV add Xuat Chi Dinh Don Hang End
                    dhx.SIsXuatCoChiDinh = (dtb.Rows[0]["IsXuatCoChiDinh"].ToString() != null && dtb.Rows[0]["IsXuatCoChiDinh"].ToString().Length > 0) ? (bool)dtb.Rows[0]["IsXuatCoChiDinh"] : false;
                    dhx.SIsXuatThuCong = (dtb.Rows[0]["IsXuatThuCong"].ToString() != null && dtb.Rows[0]["IsXuatThuCong"].ToString().Length > 0) ? (bool)dtb.Rows[0]["IsXuatThuCong"] : false;
                    // DungLV add Xuat Chi Dinh Don Hang End
                    //dhx.DNgayDuyetDH = DateTime.Parse(dtb.Rows[0]["NgayDuyetDH"].ToString());
                    return dhx;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Xoa(string dhid, string userxoa)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHid", SqlDbType.VarChar, 50),
                                        new SqlParameter ("@UserXoa", SqlDbType.VarChar)};
            thamso[0].Value = dhid;
            thamso[1].Value = userxoa;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_Xoa", thamso);
        }
        /// <summary>
        /// Hàm xác nhận đơn hàng xuất
        /// </summary>
        /// <param name="dhid">uniqueidentifier: Đơn hàng ID</param>
        /// <param name="xacnhan">bool: true-xác nhận, false: chưa xác nhận</param>
        /// <param name="userxacnhanid">uniqueidentifier: Người xác nhận ID</param>
        /// <returns></returns>
        public int XacNhanDonHangXuat(string dhid, bool xacnhan, string userxacnhanid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHid", SqlDbType.VarChar, 50),
                                      new SqlParameter("@DaXacNhanDH", SqlDbType.Bit),
                                      new SqlParameter("@UserXacNhan", SqlDbType.VarChar)
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = xacnhan;
            thamso[2].Value = userxacnhanid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_XacNhan", thamso);
        }
        public DataTable LayDLLenLuoiXacNhan()
        {
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang start
            //return dl.LoadTable("DonHangXuat_LayLenLuoiXacNhan", null);
            return dl.LoadTable("DonHangXuat_XuatCoChiDinh_LayLenLuoiXacNhan", null);
            // DungLV add Xuat Chi Dinh Don Hang End
        }
        public bool KiemTraXacNhanDonHang(string sodh)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar, 50), 
                                      new SqlParameter("@DaXacNhanDH", SqlDbType.Bit)};
                thamso[0].Value = sodh;
                thamso[1].Direction = ParameterDirection.Output;

                CDuLieu dl = new CDuLieu();
                dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_KiemTraXacNhan", thamso);
                if (thamso[1] != null && thamso[1].Value.ToString().Length > 0)
                {
                    return (bool)thamso[1].Value;
                }
                else
                    return false;
            }
            catch (Exception ex)
                {
                    throw ex;
                }
        }
        // DungLV add Xuat Chi Dinh Don Hang start
        public DataTable LayDSDaXacNhanChuaCoPhieuXuat()
        {
            CDuLieu dl = new CDuLieu();
            //return dl.LoadTable("DonHangXuat_LayDSDaXacNhanChuaCoPhieuXuat", null);
            return dl.LoadTable("DonHangXuat_LayDSDaXacNhanChuaCoPhieuXuat_XuatCoChiDinh", null);
        }
       
        public DataTable LayDSDaXacNhanChuaCoPhieuXuat_XuatCoChiDinh()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("DonHangXuat_XuatCoChiDinh_LayDSDaXacNhanChuaCoPhieuXuat", null);
        }
        // DungLV add Xuat Chi Dinh Don Hang End
        public int CapNhatDaTaoDonHangMuaTong(string dhid, string dhmtongid)
        {
            SqlParameter[] thamso = { new SqlParameter("@dhid", SqlDbType.VarChar), 
                                      new SqlParameter("@dhmtongid", SqlDbType.VarChar)};
            thamso[0].Value = dhid;
            thamso[1].Value = dhmtongid;
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_CapNhatDaTaoDonHangMuaTong", thamso);
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
            dl.ThucThi("DonHangXuat_KiemTraCoHangDacBiet", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
        public bool IsNT(string DHID)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@DHid", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@IsNT", SqlDbType.Bit)
                                    };

            thamso[0].Value = new Guid(DHID);
            thamso[1].Direction = ParameterDirection.Output;

            CDuLieu dl = new CDuLieu();
            dl.ThucThi("DonHangXuat_KiemTraNoiDacHang", thamso);

            return Boolean.Parse(thamso[1].Value.ToString());
        }
        public string[] DonHangXuat_ThemImport(string ntid, string ghichu, string usertao, bool donkhan, DateTime ngayduyet)
        {
            SqlParameter[] thamso = { new SqlParameter("@NTID", ntid),
                                    new SqlParameter("@GhiChu", ghichu),
                                    new SqlParameter("@UserTao", usertao),
                                    new SqlParameter("@DHID", "00000000-0000-0000-0000-000000000000"),
                                    new SqlParameter("@DonKhan", donkhan),
                                    new SqlParameter("@NgayDuyetDH", ngayduyet),
                                    new SqlParameter("@SoDH", "RO0000000000")};
            thamso[3].Direction = ParameterDirection.InputOutput;
            thamso[6].Direction = ParameterDirection.InputOutput;
            try
            {
                CDuLieu dl = new CDuLieu();
                int kq = dl.ThucThiTraVeKetQuaKieuInt("DonHangXuat_ThemImport", thamso);
                if (kq > 0)
                {
                    return new string[] { thamso[3].Value.ToString(), thamso[6].Value.ToString() }; 
                    //return thamso[3].Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
