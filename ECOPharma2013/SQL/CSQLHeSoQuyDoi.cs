using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLHeSoQuyDoi
    {
        string _hsqdid;

        public string Hsqdid
        {
            get { return _hsqdid; }
            set { _hsqdid = value; }
        }
        string _spid;

        public string Spid
        {
            get { return _spid; }
            set { _spid = value; }
        }
        string _diengiai;

        public string Diengiai
        {
            get { return _diengiai; }
            set { _diengiai = value; }
        }
        string _tudvt;

        public string Tudvt
        {
            get { return _tudvt; }
            set { _tudvt = value; }
        }
        string _sangdvt;

        public string Sangdvt
        {
            get { return _sangdvt; }
            set { _sangdvt = value; }
        }
        decimal _gtqdthuan;

        public decimal Gtqdthuan
        {
            get { return _gtqdthuan; }
            set { _gtqdthuan = value; }
        }
        decimal _gtqdnguoc;

        public decimal Gtqdnguoc
        {
            get { return _gtqdnguoc; }
            set { _gtqdnguoc = value; }
        }
        int _capdo;

        public int Capdo
        {
            get { return _capdo; }
            set { _capdo = value; }
        }
        DateTime _lastupdate;

        public DateTime Lastupdate
        {
            get { return _lastupdate; }
            set { _lastupdate = value; }
        }
        DateTime _ngaytao;

        public DateTime Ngaytao
        {
            get { return _ngaytao; }
            set { _ngaytao = value; }
        }
        string _userid;

        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }


        public string ThemHeSoQuiDoi(CSQLHeSoQuyDoi hsqd)
        {
            SqlParameter[] thamso = {    new SqlParameter("@HSQDid", SqlDbType.VarChar, 50),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@DienGiai", SqlDbType.NVarChar),
                                         new SqlParameter("@TuDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@SangDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@GTQDThuan", SqlDbType.Decimal),
                                         new SqlParameter("@GTQDNguoc", SqlDbType.Decimal),
                                         new SqlParameter("@CapDo", SqlDbType.Int),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar)
                                     };
            thamso[0].Direction = ParameterDirection.Output;
            thamso[1].Value = hsqd.Spid;
            thamso[2].Value = hsqd.Diengiai;
            thamso[3].Value = hsqd.Tudvt;
            thamso[4].Value = hsqd.Sangdvt;
            thamso[5].Value = hsqd.Gtqdthuan;
            thamso[6].Value = hsqd.Gtqdnguoc;
            thamso[7].Value = hsqd.Capdo;
            thamso[8].Value = hsqd.Lastupdate;
            thamso[9].Value = hsqd.Ngaytao;
            thamso[10].Value = hsqd.Userid;

            CDuLieu qldl = new CDuLieu();
            qldl.InsertDuLieu("HeSoQuiDoi_Them", thamso, null);
            return thamso[0].Value.ToString();
        }

        public int SuaHeSoQuiDoi(CSQLHeSoQuyDoi hsqd)
        {
            SqlParameter[] thamso = {    new SqlParameter("@HSQDid", SqlDbType.VarChar, 50),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@DienGiai", SqlDbType.NVarChar),
                                         new SqlParameter("@TuDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@SangDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@GTQDThuan", SqlDbType.Decimal),
                                         new SqlParameter("@GTQDNguoc", SqlDbType.Decimal),
                                         new SqlParameter("@CapDo", SqlDbType.Int),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar)
                                     };
            thamso[0].Value = hsqd.Hsqdid;
            thamso[1].Value = hsqd.Spid;
            thamso[2].Value = hsqd.Diengiai;
            thamso[3].Value = hsqd.Tudvt;
            thamso[4].Value = hsqd.Sangdvt;
            thamso[5].Value = hsqd.Gtqdthuan;
            thamso[6].Value = hsqd.Gtqdnguoc;
            thamso[7].Value = hsqd.Capdo;
            thamso[8].Value = hsqd.Lastupdate;
            thamso[9].Value = hsqd.Ngaytao;
            thamso[10].Value = hsqd.Userid;

            CDuLieu qldl = new CDuLieu();
            return qldl.ThucThiTraVeKetQuaKieuInt("HeSoQuiDoi_Sua", thamso);

        }

        public DataTable LayHSQDTheoSPID(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("HeSoQuiDoi_LayHSQDTheoSPID", thamso);
        }
        public DataTable LayHSQDTheoSPID_TuDVT(string spid, string dvt)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar),
                                    new SqlParameter("@TuDVTID", SqlDbType.VarChar)};
            thamso[0].Value = spid;
            thamso[1].Value = dvt;
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("HeSoQuiDoi_LayHSQDTheoSPID_TuDVT", thamso);
        }
        public string Lay1HSQDTheoSPID(string spid)
        {
            string kq = "";
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu qldl = new CDuLieu();
            DataTable dtb = qldl.LoadTable("HeSoQuiDoi_LayHSQDTheoSPID", thamso);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                kq = dtb.Rows[0][0].ToString();
            }
            return kq;
        }

        public DataTable LayDSHSQDTheoHSQDID(string hsqdid)
        {
            SqlParameter[] thamso = { new SqlParameter("@HSQDID", SqlDbType.VarChar) };
            thamso[0].Value = hsqdid;
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("HeSoQuiDoi_LayDanhSachHSQDTheoHSQDID", thamso);
        }

        public DataTable LayDVTTheoSPID(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar) };
            thamso[0].Value = spid;
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("HeSoQuiDoi_LayDSDVT", thamso);
        }


        public int Xoa(string hsqdid)
        {
            SqlParameter[] thamso = { new SqlParameter("@HSQDID", SqlDbType.VarChar) };
            thamso[0].Value = hsqdid;
            CDuLieu qldl = new CDuLieu();
            return qldl.ThucThiTraVeKetQuaKieuInt("HeSoQuiDoi_Xoa", thamso);
        }

        public DataTable LayLenLuoi()
        {
            CDuLieu qldl = new CDuLieu();
            return qldl.LoadTable("HeSoQuiDoi_LayHSQDLenLuoi", null);
        }

        public string CapHeSoQuiDoiLonNhat(string spid)
        {
            DataTable dtb = LayHSQDTheoSPID(spid);
            string hsqdmax = "";
            int max = 0;
            foreach (DataRow dr in dtb.Rows)
            {
                if ((int)dr["CapDo"] >= max)
                    hsqdmax = dr["HSQDID"].ToString();
            }
            return hsqdmax;
        }



        #region Hàm tính số lượng chuẩn theo cấp hệ số quy đổi
        /// <summary>
        /// Hàm tính số lượng chuẩn của sản phẩm theo cấp hệ số quy đổi.
        /// VD: Ta có:  HSQD của SP A là: Thùng - Hộp - Vỉ - Viên.
        ///             Hệ số quy đổi chuẩn của sản phẩm là Hộp.
        ///             Ta dùng hàm này để tính ra số lượng của (vỉ/viên/thùng) trong 1 hộp.             
        /// </summary>
        /// <param name="spid">(string dạng uniqueidentifier): ID của sản phẩm </param>
        /// <param name="maDVTOutput">(string dạng uniqueidentifier): ID của Đơn vị tính muốn chuyển đổi, ID này bắt buộc phải tồn tại trong HSQD của SP trên</param>
        /// <returns>Số lượng chuẩn (decimal): Số lượng quy đổi từ Hệ số chuẩn (vd: 1 thùng) sang Hệ số mong muốn (vd: 1000 Viên)</returns>
        public decimal Tinh_SO_LUONG_CHUAN_TheoCapHSQD(string spid, string maDVTOutput)
        {
            //1. Lấy đơn vị chuẩn của sp.
            CSQLSanPham sp = new CSQLSanPham();
            string mahsqdchuan = sp.LayHeSoQuiDoiChuanTheoMaSP(spid);

            //2. Lấy bảng hệ số quy đổi theo sp đó.
            DataTable bangHSQDTheoSPID = LayHSQDTheoSPID(spid);

            int caphsqdchuan = 0;
            int caphsqdoutput = 0;
            foreach (DataRow dr in bangHSQDTheoSPID.Rows)
            {
                if (dr["TuDVTID"].ToString().CompareTo(mahsqdchuan) == 0)
                    caphsqdchuan = (int)dr["CapDo"];
                if (dr["TuDVTID"].ToString().CompareTo(maDVTOutput) == 0)
                    caphsqdoutput = (int)dr["CapDo"];
            }

            //3. So sánh cấp của hsqd chuẩn và hsqd đầu ra (hsqd muốn chuyển tới): nếu cấp hsqd chuẩn lớn hơn - nghịch (/), ngược lại - thuận (*)
            decimal soluongchuan = 1;
            if (caphsqdchuan <= caphsqdoutput)
            {
                for (int i = caphsqdchuan; i < caphsqdoutput; i++)
                {
                    soluongchuan = soluongchuan * decimal.Parse(bangHSQDTheoSPID.Rows[i]["GTQDNguoc"].ToString());
                }
            }
            else
            {
                for (int i = caphsqdchuan; i > caphsqdoutput; i--)
                {
                    if (i > 0)
                        soluongchuan = soluongchuan * decimal.Parse(bangHSQDTheoSPID.Rows[i - 1]["GTQDThuan"].ToString());
                }
            }

            //4. Return KQ
            return soluongchuan;
        }
        #endregion

        public decimal TinhTyLeHSQD(string spid, string dvtmongmuon)
        {
            SqlParameter[] thamso = { new SqlParameter("@sanphamid", SqlDbType.VarChar),
                                        new SqlParameter ("@DVTMongMuon", SqlDbType.VarChar),
                                    new SqlParameter("@tyle", SqlDbType.Decimal,38)};
            thamso[0].Value = spid;
            thamso[1].Value = dvtmongmuon;
            thamso[2].Direction = ParameterDirection.Output;
            thamso[2].Precision = 38;
            thamso[2].Scale = 20;

            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("[HeSoQuyDoi_LayTiLe_Nguoc]", thamso);
            return decimal.Parse(thamso[2].Value.ToString());
        }

        public decimal TinhTyLeHSQD_Thuan(string spid, string dvtmongmuon)
        {
            SqlParameter[] thamso = { new SqlParameter("@sanphamid", SqlDbType.VarChar),
                                        new SqlParameter ("@DVTMongMuon", SqlDbType.VarChar),
                                    new SqlParameter("@tyle", SqlDbType.Decimal,38)};
            thamso[0].Value = spid;
            thamso[1].Value = dvtmongmuon;
            thamso[2].Direction = ParameterDirection.Output;
            thamso[2].Precision = 38;
            thamso[2].Scale = 20;
            CDuLieu dl = new CDuLieu();
            int kq = dl.ThucThiTraVeKetQuaKieuInt("[HeSoQuyDoi_LayTiLe]", thamso);
            return decimal.Parse(thamso[2].Value.ToString());
        }

        public int HeSoQuiDoi_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("HeSoQuiDoi_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }

            }
            else
                return 0;
        }
        public int HeSoQuiDoi_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("HeSoQuiDoi_LayMaxCapNhat", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public int HeSoQuiDoi_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("HeSoQuiDoi_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public int HeSoQuiDoi_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("HeSoQuiDoi_LayMaxThemMoi", null);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                try
                {
                    return int.Parse(dtb.Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public DataTable HeSoQuiDoi_LayDSHeSoQuiDoiChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("HeSoQuiDoi_LayDSHeSoQuiDoiChuaCapNhatTaiNT", thamso);
        }
        public DataTable HeSoQuiDoi_LayDSHeSoQuiDoiChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("HeSoQuiDoi_LayDSHeSoQuiDoiChuaThemMoiTaiNT", thamso);
        }
        public void HeSoQuiDoi_DongBoThemDanhMuc(DataTable _DSHeSoQuiDoiChuaThem)
        {
            if (_DSHeSoQuiDoiChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSHeSoQuiDoiChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@HSQDid", SqlDbType.VarChar, 50),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@DienGiai", SqlDbType.NVarChar),
                                         new SqlParameter("@TuDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@SangDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@GTQDThuan", SqlDbType.Decimal),
                                         new SqlParameter("@GTQDNguoc", SqlDbType.Decimal),
                                         new SqlParameter("@CapDo", SqlDbType.Int),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar), 
                                         new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@HeSoTon", SqlDbType.Decimal)};
                    thamso[0].Value = dr["HSQDid"].ToString();
                    thamso[1].Value = dr["SPID"].ToString();
                    thamso[2].Value = dr["DienGiai"].ToString();
                    thamso[3].Value = dr["TuDVTid"].ToString();
                    thamso[4].Value = dr["SangDVTid"].ToString();
                    thamso[5].Value = decimal.Parse(dr["GTQDThuan"].ToString());
                    thamso[6].Value = decimal.Parse(dr["GTQDNguoc"].ToString());
                    thamso[7].Value = int.Parse(dr["CapDo"].ToString());
                    thamso[8].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[9].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[10].Value = CStaticBien.SmaTaiKhoan;
                    thamso[11].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[12].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[13].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[14].Value = decimal.Parse(dr["HeSoTon"].ToString());
                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("HeSoQuiDoi_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void HeSoQuiDoi_DongBoSuaDanhMuc(DataTable _DSHeSoQuiDoiChuaCapNhat)
        {
            if (_DSHeSoQuiDoiChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSHeSoQuiDoiChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@HSQDid", SqlDbType.VarChar, 50),
                                         new SqlParameter("@SPID", SqlDbType.VarChar),
                                         new SqlParameter("@DienGiai", SqlDbType.NVarChar),
                                         new SqlParameter("@TuDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@SangDVTid", SqlDbType.VarChar),
                                         new SqlParameter("@GTQDThuan", SqlDbType.Decimal),
                                         new SqlParameter("@GTQDNguoc", SqlDbType.Decimal),
                                         new SqlParameter("@CapDo", SqlDbType.Int),
                                         new SqlParameter("@LastUD", SqlDbType.DateTime),
                                         new SqlParameter("@NgayTao", SqlDbType.DateTime),
                                         new SqlParameter("@UserID", SqlDbType.VarChar), 
                                         new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit),
                                                new SqlParameter("@HeSoTon", SqlDbType.Decimal)};
                    thamso[0].Value = dr["HSQDid"].ToString();
                    thamso[1].Value = dr["SPID"].ToString();
                    thamso[2].Value = dr["DienGiai"].ToString();
                    thamso[3].Value = dr["TuDVTid"].ToString();
                    thamso[4].Value = dr["SangDVTid"].ToString();
                    thamso[5].Value = decimal.Parse(dr["GTQDThuan"].ToString());
                    thamso[6].Value = decimal.Parse(dr["GTQDNguoc"].ToString());
                    thamso[7].Value = int.Parse(dr["CapDo"].ToString());
                    thamso[8].Value = DateTime.Parse(dr["LastUD"].ToString());
                    thamso[9].Value = DateTime.Parse(dr["NgayTao"].ToString());
                    thamso[10].Value = CStaticBien.SmaTaiKhoan;
                    thamso[11].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[12].Value = bool.Parse(dr["IsXoa"].ToString());
                    thamso[13].Value = decimal.Parse(dr["HeSoTon"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("HeSoQuiDoi_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public int KiemTraSPTonKho(string spid)
        {
            SqlParameter[] thamso = { new SqlParameter("@SPID", SqlDbType.VarChar, 50) };
            thamso[0].Value = spid;
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("HeSoQuiDoi_KiemTraMaSanPhamTonKho", thamso);
            if (dtb.Rows.Count > 0)
            {
                return int.Parse(dtb.Rows[0][0].ToString());
            }
            else
                return 0;
        }
        public DataTable LoadDataHeSoQuiDoi()
        {
            CDuLieu dl = new CDuLieu();
            return dl.LoadTable("BaoCaoHeSoQuiDoi_LoadData", null);
        }
    }
}
    