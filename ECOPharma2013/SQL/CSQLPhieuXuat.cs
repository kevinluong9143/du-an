using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLPhieuXuat
    {
        string _SPXid;

        public string SPXid
        {
            get { return _SPXid; }
            set { _SPXid = value; }
        }
        string _SSoPX;

        public string SSoPX
        {
            get { return _SSoPX; }
            set { _SSoPX = value; }
        }
        string _SSoDH;

        public string SSoDH
        {
            get { return _SSoDH; }
            set { _SSoDH = value; }
        }
        string _XuatChoNT;

        public string XuatChoNT
        {
            get { return _XuatChoNT; }
            set { _XuatChoNT = value; }
        }
        bool _BDonKhan;

        public bool BDonKhan
        {
            get { return _BDonKhan; }
            set { _BDonKhan = value; }
        }
        bool _BDirect;

        public bool BDirect
        {
            get { return _BDirect; }
            set { _BDirect = value; }
        }
        int _BSoLanIn;

        public int BSoLanIn
        {
            get { return _BSoLanIn; }
            set { _BSoLanIn = value; }
        }
        DateTime _DLastUD;

        public DateTime DLastUD
        {
            get { return _DLastUD; }
            set { _DLastUD = value; }
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
        string _SUserTao;

        public string SUserTao
        {
            get { return _SUserTao; }
            set { _SUserTao = value; }
        }
        string _SUserXoa;

        public string SUserXoa
        {
            get { return _SUserXoa; }
            set { _SUserXoa = value; }
        }

        public CSQLPhieuXuat() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sodh"></param>
        /// <param name="xuatchont"></param>
        /// <param name="donkhan"></param>
        /// <param name="direct"></param>
        /// <param name="solanin"></param>
        /// <param name="lastupdate"></param>
        /// <param name="ngaytao"></param>
        /// <param name="isxoa"></param>
        /// <param name="usertaoid"></param>
        /// <param name="userxoaid"></param>
        /// <param name="iskiemtraxuatkho"></param>
        /// <returns>hàm trả về mảng gồm 2 giá trị: pxid, sopx</returns>
        public string[] Them(string sodh, string xuatchont, bool donkhan, bool direct, int solanin, DateTime lastupdate, DateTime ngaytao, bool isxoa, string usertaoid, string userxoaid, bool iskiemtraxuatkho, bool isxuatcochidinh)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PXid", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@SoPX", SqlDbType.VarChar,12),
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@Direct", SqlDbType.Bit),
                                        new SqlParameter("@SoLanIn", SqlDbType.Int),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@UserTao", SqlDbType.VarChar),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar),
                                        new SqlParameter("@IsKiemTraXuatKho", SqlDbType.Bit),
                                        new SqlParameter("@IsXuatCoChiDinh", SqlDbType.Bit)
                                    };
            thamso[0].Value = "00000000-0000-0000-0000-000000000000";
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Direction = ParameterDirection.Output;
            thamso[2].Value = sodh;
            thamso[3].Value = xuatchont;
            thamso[4].Value = donkhan;
            thamso[5].Value = direct;
            thamso[6].Value = solanin;
            thamso[7].Value = lastupdate;
            thamso[8].Value = ngaytao;
            thamso[9].Value = isxoa;
            thamso[10].Value = usertaoid;
            thamso[11].Value = userxoaid;
            thamso[12].Value = iskiemtraxuatkho;
            // DungLV add Xuat Chi Dinh Don Hang start
            thamso[13].Value = isxuatcochidinh;
            // DungLV add Xuat Chi Dinh Don Hang End
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang start
            // int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoPhieuXuat_Them", thamso);
            int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoPhieuXuat_XuatCoChiDinh_Them", thamso);
            // DungLV add Xuat Chi Dinh Don Hang End
            string [] kqreturn = new string[2];
            if (kq > 0)
            {
                kqreturn[0] = thamso[0].Value.ToString();
                kqreturn[1] = thamso[1].Value.ToString();
                return kqreturn;
            }
            else
                return null;
        }

        public string[] Them_HoaDon(string sodh, string xuatchont, bool donkhan, bool direct, int solanin, DateTime lastupdate, DateTime ngaytao, bool isxoa, string usertaoid, string userxoaid, bool iskiemtraxuatkho, bool isxuatcochidinh)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@PXid", SqlDbType.VarChar, 50), 
                                        new SqlParameter("@SoPX", SqlDbType.VarChar,12),
                                        new SqlParameter("@SoDH", SqlDbType.VarChar),
                                        new SqlParameter("@XuatChoNT", SqlDbType.VarChar),
                                        new SqlParameter("@DonKhan", SqlDbType.Bit),
                                        new SqlParameter("@Direct", SqlDbType.Bit),
                                        new SqlParameter("@SoLanIn", SqlDbType.Int),
                                        new SqlParameter("@LastUD", SqlDbType.DateTime),
                                        new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                        new SqlParameter("@IsXoa", SqlDbType.Bit),
                                        new SqlParameter("@UserTao", SqlDbType.VarChar),
                                        new SqlParameter("@UserXoa", SqlDbType.VarChar),
                                        new SqlParameter("@IsKiemTraXuatKho", SqlDbType.Bit),
                                        new SqlParameter("@IsXuatCoChiDinh", SqlDbType.Bit)
                                    };
            thamso[0].Value = "00000000-0000-0000-0000-000000000000";
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Direction = ParameterDirection.Output;
            thamso[2].Value = sodh;
            thamso[3].Value = xuatchont;
            thamso[4].Value = donkhan;
            thamso[5].Value = direct;
            thamso[6].Value = solanin;
            thamso[7].Value = lastupdate;
            thamso[8].Value = ngaytao;
            thamso[9].Value = isxoa;
            thamso[10].Value = usertaoid;
            thamso[11].Value = userxoaid;
            thamso[12].Value = iskiemtraxuatkho;
            // DungLV add Xuat Chi Dinh Don Hang start
            thamso[13].Value = isxuatcochidinh;
            // DungLV add Xuat Chi Dinh Don Hang End
            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang start
            // int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoPhieuXuat_Them", thamso);
            int kq = dl.ThucThiTraVeKetQuaKieuInt("EcoPhieuXuat_XuatCoChiDinh_HoaDon_Them", thamso);
            // DungLV add Xuat Chi Dinh Don Hang End
            string[] kqreturn = new string[2];
            if (kq > 0)
            {
                kqreturn[0] = thamso[0].Value.ToString();
                kqreturn[1] = thamso[1].Value.ToString();
                return kqreturn;
            }
            else
                return null;
        }

        public DataTable LayDHXCTTheoSoDH(string soDH)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar, 12) };
            thamso[0].Value = soDH;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayDHXCTTheoSoDH", thamso);
            return dtb;
        }

        public string[] LayTKCTid_SLTonTheoSPID_KhoID_Lot_NSXid_DVTid(string spid, string khoid, string lot, string nsxid, string dvtid)
        {
            SqlParameter[] thamso = { 
                                        new SqlParameter("@spid", SqlDbType.VarChar), 
                                        new SqlParameter("@khoid", SqlDbType.VarChar),
                                        new SqlParameter("@lot", SqlDbType.VarChar),
                                        new SqlParameter("@nsxid", SqlDbType.VarChar),
                                        new SqlParameter("@dvtid", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = lot;
            thamso[3].Value = nsxid;
            thamso[4].Value = dvtid;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayTKCTid_SLTonTheoSPID_KhoID_Lot_NSXid_DVTid", thamso);
            string[] kq = new string[3];
            if (dtb != null && dtb.Rows.Count > 0)
            {
                kq[0] = dtb.Rows[0]["TKCTID"].ToString();
                kq[1] = dtb.Rows[0]["SLTon"].ToString();
                kq[2] = dtb.Rows[0]["SLCoTheXuat"].ToString();
            }
            else
            {
                kq = null;
            }
            return kq;
        }

        public int UpdateDonHangXuatCT_SLConThieu(string dhid, decimal slconthieu,string spid, string nsxid, string lot)
        {
            SqlParameter[] thamso = { new SqlParameter("@dhid", SqlDbType.VarChar), 
                                        new SqlParameter("@slconthieu", SqlDbType.Decimal),
                                        new SqlParameter("@SPID", SqlDbType.VarChar),
                                        new SqlParameter("@NSXID", SqlDbType.VarChar),
                                        new SqlParameter("@Lot", SqlDbType.VarChar)
                                    };
            thamso[0].Value = dhid;
            thamso[1].Value = slconthieu;
            thamso[2].Value = spid;
            thamso[3].Value = nsxid;
            thamso[4].Value = lot;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_UpdateDonHangXuatCT_SLConThieu", thamso);
        }

        public int UpdateEcoTonKhoCT_SLTon(string tkctid, decimal slton)
        {
            SqlParameter[] thamso = { new SqlParameter("@tkctid", SqlDbType.VarChar), 
                                        new SqlParameter("@slton", SqlDbType.Decimal)};
            thamso[0].Value = tkctid;
            thamso[1].Value = slton;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_UpdateEcoTonKhoCT_SLTon", thamso);
        }

        public int InsertPhieuXuatCT(string pxid, string spid, string nspid, decimal slxuat, string dvtid, string makho, decimal giamuachuatax, decimal ttgiamuachuatax, decimal giaxkchuatax, decimal ttgiaxkchuatax, decimal tax, decimal tttax, decimal ttgiaxkcotax, string lot, DateTime date, string nsxid)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@pxid", SqlDbType.VarChar),
                                        new SqlParameter("@spid", SqlDbType.VarChar),
                                        new SqlParameter("@nspid", SqlDbType.VarChar),
                                        new SqlParameter("@slxuat", SqlDbType.Decimal),
                                        new SqlParameter("@dvtid", SqlDbType.VarChar),
                                        new SqlParameter("@makho", SqlDbType.VarChar),
                                        new SqlParameter("@giamuachuatax", SqlDbType.Decimal),
                                        new SqlParameter("@ttgiamuachuatax", SqlDbType.Decimal),
                                        new SqlParameter("@giaxkchuatax", SqlDbType.Decimal),
                                        new SqlParameter("@ttgiaxkchuatax", SqlDbType.Decimal),
                                        new SqlParameter("@tax", SqlDbType.Decimal),
                                        new SqlParameter("@tttax", SqlDbType.Decimal),
                                        new SqlParameter("@ttgiaxkcotax", SqlDbType.Decimal),
                                        new SqlParameter("@lot", SqlDbType.VarChar),
                                        new SqlParameter("@date", SqlDbType.DateTime),
                                        new SqlParameter("@nsxid", SqlDbType.VarChar)
                                    };

            thamso[0].Value = pxid;
            thamso[1].Value = spid;
            thamso[2].Value = nspid;
            thamso[3].Value = slxuat;
            thamso[4].Value = dvtid;
            thamso[5].Value = makho;
            thamso[6].Value = giamuachuatax;
            thamso[7].Value = ttgiamuachuatax;
            thamso[8].Value = giaxkchuatax;
            thamso[9].Value = ttgiaxkchuatax;
            thamso[10].Value = tax;
            thamso[11].Value = tttax;
            thamso[12].Value = ttgiaxkcotax;
            thamso[13].Value = lot;
            thamso[14].Value = date;
            thamso[15].Value = nsxid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_InsertPhieuXuatCT", thamso);
        }

        public DataTable LaySLTon_SLCoTheXuat_LotTheoSPID_KhoID_DVTID(string spid, string khoid, string dvtid)
        {
            SqlParameter[] thamso = {   new SqlParameter("@spid", SqlDbType.VarChar),
                                        new SqlParameter("@khoid", SqlDbType.VarChar),
                                        new SqlParameter("@dvtid", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = khoid;
            thamso[2].Value = dvtid;

            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("PhieuXuat_LaySLTon_SLCoTheXuat_LotTheoSPID_KhoID_DVTID", thamso);
        }

        public void KiemTraDonHangXuatConThieu(string dhid)
        {
            SqlParameter[] thamso = { new SqlParameter("@DHID", SqlDbType.VarChar) };
            thamso[0].Value = dhid;
            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_KiemTraDHXConThieu", thamso);
        }
        public DataTable LayPhieuNhapDirectCT(string pnid)
        {
            SqlParameter[] thamso = { new SqlParameter("@PNID", SqlDbType.VarChar) };
            thamso[0].Value = pnid;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("PhieuXuat_LayDSDirectCT", thamso);
        }

        public int UpdateECOPhieuXuat_SoLanIn(string pxid_, int slin)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXid", SqlDbType.VarChar), 
                                        new SqlParameter("@SoLanIn", SqlDbType.Int)};
            thamso[0].Value = pxid_;
            thamso[1].Value = slin;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_UpdateECOPhieuXuat_SoLanIn", thamso);
        }
        public DataTable LayPhieuXuat_TheoSoLanIn(int solanin)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoLanIn", SqlDbType.Int) };
            thamso[0].Value = solanin;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_TheoSoLanIn", thamso);
            return dtb;
        }

        public DataTable LayPhieuXuat_LayMin_MaxSoPX()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_LayMin_MaxSoPX", null);
            return dtb;
        }
        public DataTable LayDSPhieuXuat_TheoPXid(string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXID", SqlDbType.VarChar) };
            thamso[0].Value = pxid_;

            CDuLieu dl = new CDuLieu();
            // DungLV add Xuat Chi Dinh Don Hang start
            //DataTable dtb = dl.LoadTable("PhieuXuat_LayDSPhieuXuat_TheoPXid", thamso);
            DataTable dtb = dl.LoadTable("PhieuXuat_LayDSPhieuXuat_XuatCoChiDinh_TheoPXid", thamso);
            // DungLV add Xuat Chi Dinh Don Hang End
            return dtb;
        }
        public DataTable LayPhieuXuat_TheoSoLanIn_PXid(string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXid", SqlDbType.VarChar) };
            thamso[0].Value = pxid_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_TheoSoLanIn_PXid", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_TheoSoPhieuXuat(string px_)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoPX", SqlDbType.VarChar, 12) };
            thamso[0].Value = px_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_TheoSoPhieuXuat", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_TuSoPX_DenSoPX(string tu_, string den_)
        {
            SqlParameter[] thamso = { new SqlParameter("@TuSoPX", SqlDbType.VarChar, 12),
                                    new SqlParameter("@DenSoPX", SqlDbType.VarChar, 12)};
            thamso[0].Value = tu_;
            thamso[1].Value = den_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_TuSoPX_DenSoPX", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_SoLanIn_IsKiemTraXuatKho(int so_, bool kt_)
        {
            SqlParameter[] thamso = { new SqlParameter("@So", SqlDbType.Int),
                                    new SqlParameter("@KT", SqlDbType.Bit)};
            thamso[0].Value = so_;
            thamso[1].Value = kt_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayPhieuXuat_SoLanIn_IsKiemTraXuatKho", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_InsertKTXK(string user_)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserKT", SqlDbType.VarChar) };
            thamso[0].Value = user_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_InsertKTXK", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_InsertKTXK_PxID(string user_, string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@UserKT", SqlDbType.VarChar)
                                    , new SqlParameter("@PXid", SqlDbType.VarChar)};
            thamso[0].Value = user_;
            thamso[1].Value = pxid_; 

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_InsertKTXK_PxID", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_InsertKTXKCT(string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXid", SqlDbType.VarChar) };
            thamso[0].Value = pxid_; 

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_InsertKTXKCT", thamso);
            return dtb;
        }
        public DataTable LayPhieuXuat_UpdateIsKiemTraXuatKho_PX(string pxid_)
        {
            SqlParameter[] thamso = { new SqlParameter("@PXid", SqlDbType.VarChar) };
            thamso[0].Value = pxid_;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_UpdateIsKiemTraXuatKho_PX", thamso);
            return dtb;
        }
        public int KiemTraTonTaiPhieuXuat(string sodh)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar) };
            thamso[0].Value = sodh;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_KiemTraTonTaiDonHang", thamso);
            if (dtb.Rows.Count > 0)
            {
                return int.Parse(dtb.Rows[0][0].ToString());
            }
            else
                return -1;
        }

        public string[] LayMangPXID_SoPXTheoSoDH(string sodh)
        {
            SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar) };
            thamso[0].Value = sodh;

            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_LayMangPXID_SoPXTheoSoDH", thamso);
            if (dtb.Rows.Count > 0)
            {
                string[] kq = new string[2];
                kq[0] = dtb.Rows[0][0].ToString();
                kq[1] = dtb.Rows[0][1].ToString();
                return kq;
            }
            else
                return null;
        }

        public int XoaPhieuXuat(string pxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@pxid", SqlDbType.VarChar) };
            thamso[0].Value = pxid;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_XoaPX", thamso);
        }
        public int NghiepVuPhieuXuat(string sodh, string xuatchont, bool donkhan, string usertaoid)
        {
            SqlParameter[] thamso = { new SqlParameter("@sodh", SqlDbType.VarChar),
                                    new SqlParameter("@xuatchont", SqlDbType.VarChar),
        new SqlParameter("@donkhan", SqlDbType.Bit),
        new SqlParameter("@usertaoid", SqlDbType.VarChar)};
            thamso[0].Value = sodh;
            thamso[1].Value = xuatchont;
            thamso[2].Value = donkhan;
            thamso[3].Value = usertaoid;
            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("NghiepVuPhieuXuat", thamso);
        }

        public void XoaPhieuXuatKhongCoGiaTri(string pxid)
        {
            SqlParameter[] thamso = { new SqlParameter("@pxid", SqlDbType.VarChar) };
            thamso[0].Value = pxid;

            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_XoaPhieuXuatRong", thamso);
        }
        public void XoaPhieuXuatRong()
        {
            CDuLieu dl = new CDuLieu();
            dl.ThucThiTraVeKetQuaKieuInt("phieuxuat_xoaphieuxuatrong_v2", null);
            
        }

        public int PhieuXuat_UpdateSLCoTheXuatTrongTonKhoCT(string spid, string lot, string dvtid, string nsxid, string khoid, decimal slxuat)
        {
            SqlParameter[] thamso = {
                                        new SqlParameter("@spid", SqlDbType.VarChar),
                                        new SqlParameter("@lot", SqlDbType.VarChar),
                                        new SqlParameter("@dvtid", SqlDbType.VarChar),
                                        new SqlParameter("@nsxid", SqlDbType.VarChar),
                                        new SqlParameter("@khoid", SqlDbType.VarChar),
                                        new SqlParameter("@slxuat", SqlDbType.Decimal)
                                    };

            thamso[0].Value = spid;
            thamso[1].Value = lot;
            thamso[2].Value = dvtid;
            thamso[3].Value = nsxid;
            thamso[4].Value = khoid;
            thamso[5].Value = slxuat;

            CDuLieu dl = new CDuLieu();
            return dl.ThucThiTraVeKetQuaKieuInt("PhieuXuat_UpdateSLCoTheXuatTrongTonKhoCT", thamso);
        }
        public DataTable LayDanhSachLenLuoi(bool xemTatCa)
        {
            try
            {
                SqlParameter[] thamso = new SqlParameter[1];
                SqlParameter XemTC = new SqlParameter("@XemTatCa", SqlDbType.Bit);
                XemTC.Value = xemTatCa;
                thamso[0] = XemTC;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // DataTable dtb = dl.LoadTable("PhieuXuat_LoadDSLenLuoi", thamso);
                DataTable dtb = dl.LoadTable("PhieuXuat_XuatCoChiDinh_LoadDSLenLuoi", thamso);
                // DungLV add Xuat Chi Dinh Don Hang End
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BaoCaoDonHangDaXuatKho_LoadDSTuNgay_DenNgay(string tungay_, string denngay_)
        {

            SqlParameter[] thamso = { new SqlParameter("@TuNgay", SqlDbType.VarChar),
                                        new SqlParameter("@DenNgay", SqlDbType.VarChar)
                                    };
            thamso[0].Value = tungay_;
            thamso[1].Value = denngay_;
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoDonHangDaXuatKho_LoadDSTuNgay_DenNgay", thamso);
        }

        public int CapNhatIsPhieuCuoi(string pxid)
        {
            try
            {
                SqlParameter[] thamso = { new SqlParameter("@PXID", SqlDbType.VarChar) };
                thamso[0].Value = pxid;
                CDuLieu dl = new CDuLieu();
                return dl.ThucThiTraVeKetQuaKieuInt("PHIEUXUAT_CAPNHATISPHIEUCUOI", thamso);
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

        public string PhieuXuatCT_Tao1CT(string dhctid, string pxid)
        {
            try
            {
                SqlParameter[] thamso = {   new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                            new SqlParameter("@PXID", SqlDbType.VarChar, 50),
                                            new SqlParameter("@UserTao", SqlDbType.VarChar)};
                thamso[0].Value = dhctid;
                thamso[1].Value = pxid;
                thamso[1].Direction = ParameterDirection.InputOutput;
                thamso[2].Value = CStaticBien.SmaTaiKhoan;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_Tao1CT", thamso) > 0)
                if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_XuatCoChiDinh_Tao1CT", thamso) > 0)
                // DungLV add Xuat Chi Dinh Don Hang start
                    return thamso[1].Value.ToString();
                else
                    return null;
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

        // DungLV add Xuat Chi Dinh Don Hang start
        public string PhieuXuatCT_Tao1CT_HoaDon(string dhctid, string pxid)
        {
            try
            {
                SqlParameter[] thamso = {   new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                            new SqlParameter("@PXID", SqlDbType.VarChar, 50),
                                            new SqlParameter("@UserTao", SqlDbType.VarChar)};
                thamso[0].Value = dhctid;
                thamso[1].Value = pxid;
                thamso[1].Direction = ParameterDirection.InputOutput;
                thamso[2].Value = CStaticBien.SmaTaiKhoan;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_Tao1CT", thamso) > 0)
                if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_XuatCoChiDinh_Tao1CT_HoaDon", thamso) > 0)
                    // DungLV add Xuat Chi Dinh Don Hang start
                    return thamso[1].Value.ToString();
                else
                    return null;
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

        public string PhieuXuatCT_Tao1CT_HoaDonKhuyenMai(string dhctid, string pxid)
        {
            try
            {
                SqlParameter[] thamso = {   new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                            new SqlParameter("@PXID", SqlDbType.VarChar, 50),
                                            new SqlParameter("@UserTao", SqlDbType.VarChar)};
                thamso[0].Value = dhctid;
                thamso[1].Value = pxid;
                thamso[1].Direction = ParameterDirection.InputOutput;
                thamso[2].Value = CStaticBien.SmaTaiKhoan;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_Tao1CT", thamso) > 0)
                if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_XuatCoChiDinh_Tao1CT_HoaDonKhuyenMai", thamso) > 0)
                    // DungLV add Xuat Chi Dinh Don Hang start
                    return thamso[1].Value.ToString();
                else
                    return null;
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

        public string PhieuXuatCT_Tao1CT_HoaDonThuCong(string dhctid, string pxid)
        {
            try
            {
                SqlParameter[] thamso = {   new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                            new SqlParameter("@PXID", SqlDbType.VarChar, 50),
                                            new SqlParameter("@UserTao", SqlDbType.VarChar)};
                thamso[0].Value = dhctid;
                thamso[1].Value = pxid;
                thamso[1].Direction = ParameterDirection.InputOutput;
                thamso[2].Value = CStaticBien.SmaTaiKhoan;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_Tao1CT", thamso) > 0)
                if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_XuatCoChiDinh_Tao1CT_HoaDonThuCong", thamso) > 0)
                    // DungLV add Xuat Chi Dinh Don Hang start
                    return thamso[1].Value.ToString();
                else
                    return null;
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

        public string PhieuXuatCT_Tao1CT_KhongHoaDon(string dhctid, string pxid)
        {
            try
            {
                SqlParameter[] thamso = {   new SqlParameter("@DHCTID", SqlDbType.VarChar),
                                            new SqlParameter("@PXID", SqlDbType.VarChar, 50),
                                            new SqlParameter("@UserTao", SqlDbType.VarChar)};
                thamso[0].Value = dhctid;
                thamso[1].Value = pxid;
                thamso[1].Direction = ParameterDirection.InputOutput;
                thamso[2].Value = CStaticBien.SmaTaiKhoan;
                CDuLieu dl = new CDuLieu();
                // DungLV add Xuat Chi Dinh Don Hang start
                // if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_Tao1CT", thamso) > 0)
                if (dl.ThucThiTraVeKetQuaKieuInt("PhieuXuatCT_XuatCoChiDinh_Tao1CT_KhongHoaDon", thamso) > 0)
                    // DungLV add Xuat Chi Dinh Don Hang start
                    return thamso[1].Value.ToString();
                else
                    return null;
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

        // DungLV add Xuat Chi Dinh Don Hang end

        public string getPhieuXuatId(string pxid)
        {
            //SqlParameter[] thamso = { new SqlParameter("@SoDH", SqlDbType.VarChar) };
            //thamso[0].Value = sodh;

            SqlParameter[] thamso = { new SqlParameter("@pxid", SqlDbType.VarChar, 250)};
            thamso[0].Value = pxid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("PhieuXuat_theoPXID", thamso);
            if (dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][0].ToString();
            }
            else
                return null;
           
        }

    }
}
