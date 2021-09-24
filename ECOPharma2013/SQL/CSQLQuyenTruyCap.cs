using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLQuyenTruyCap
    {
        private string QuyenID;
        private string NhomNDID;
        private string MenuID;
        private string FormID;
        private bool Xem;
        private bool Them_Sua;
        private bool Xoa;
        private bool Inn;


        public string sQuyenID
        {
            get { return QuyenID; }
            set { QuyenID = value; }
        }

        public string sNhomNDID
        {
            get { return NhomNDID; }
            set { NhomNDID = value; }
        }

        public string sMenuID
        {
            get { return MenuID; }
            set { MenuID = value; }
        }

        public string sFormID
        {
            get { return FormID; }
            set { FormID = value; }
        }

        public bool bXem
        {
            get { return Xem; }
            set { Xem = value; }
        }

        public bool bThem_Sua
        {
            get { return Them_Sua; }
            set { Them_Sua = value; }
        }


        public bool bXoa
        {
            get { return Xoa; }
            set { Xoa = value; }
        }

        public bool bInn
        {
            get { return Inn; }
            set { Inn = value; }
        }

        public DataTable LoadDSQuyenLenLuoi(string MaNhomNguoiDung, string MaMenu)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@NhomNDid", SqlDbType.VarChar, 50), new SqlParameter("@MenuID", SqlDbType.VarChar, 100) };
            thamsoinput[0].Value = MaNhomNguoiDung;
            thamsoinput[1].Value = MaMenu;

            return LopDL.LoadTable("QuyenTruyCap_LoadDSQuyenLenLuoi", thamsoinput);
        }

        public void InsertQuyen(string NhomNDID, string MenuID, string FormID)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@NhomNDID", SqlDbType.VarChar, 50), new SqlParameter("@MenuID", SqlDbType.VarChar, 100), new SqlParameter("@FormID", SqlDbType.VarChar, 100) };
            thamsoinput[0].Value = NhomNDID;
            thamsoinput[1].Value = MenuID;
            thamsoinput[2].Value = FormID;

            //SqlParameter MaBPfromTable = new SqlParameter("@MaBPfrmTable", SqlDbType.VarChar, 50);
            LopDL.InsertDuLieu("QuyenTruyCap_ThemMoi", thamsoinput, null);
        }

        public string SuaQuyen(CSQLQuyenTruyCap objQuyen)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@QuyenID", SqlDbType.VarChar, 50), new SqlParameter("@Xem", SqlDbType.Bit), new SqlParameter("@Them_Sua", SqlDbType.Bit), new SqlParameter("@Xoa", SqlDbType.Bit), new SqlParameter("@In", SqlDbType.Bit) };
            thamsoinput[0].Value = objQuyen.sQuyenID;
            thamsoinput[1].Value = objQuyen.bXem;
            thamsoinput[2].Value = objQuyen.bThem_Sua;
            thamsoinput[3].Value = objQuyen.bXoa;
            thamsoinput[4].Value = objQuyen.bInn;

            SqlParameter KetQuaTraVe = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("QuyenTruyCap_CapNhat", thamsoinput, KetQuaTraVe);
        }

        public string XoaQuyen()
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = {  };
            
            SqlParameter KetQuaTraVe = new SqlParameter("@KetQua", SqlDbType.NVarChar, 500);
            return LopDL.CapNhatDuLieu("QuyenTruyCap_Xoa", thamsoinput, KetQuaTraVe);
        }

        public DataTable QuyenMenu(string MaNhomNguoiDung)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@NhomNDid", SqlDbType.VarChar, 50)};
            thamsoinput[0].Value = MaNhomNguoiDung;

            return LopDL.LoadTable("QuyenTruyCap_LoadQuyenMenuCuaNhom", thamsoinput);
        }

        public DataTable QuyenChiTiet(string MaNhomNguoiDung, string MaForm)
        {
            CDuLieu LopDL = new CDuLieu();
            SqlParameter[] thamsoinput = { new SqlParameter("@NhomNDid", SqlDbType.VarChar, 50), new SqlParameter("@FormID", SqlDbType.VarChar, 100) };
            thamsoinput[0].Value = MaNhomNguoiDung;
            thamsoinput[1].Value = MaForm;

            return LopDL.LoadTable("QuyenTruyCap_LoadQuyenChiTietCuaNhom", thamsoinput);
        }

        public int QuyenTruyCap_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("QuyenTruyCap_LayMaxCapNhat", null);
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
        public int QuyenTruyCap_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("QuyenTruyCap_LayMaxCapNhat", null);
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
        public int QuyenTruyCap_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("QuyenTruyCap_LayMaxThemMoi", null);
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
        public int QuyenTruyCap_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("QuyenTruyCap_LayMaxThemMoi", null);
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
        public DataTable QuyenTruyCap_LayDSQuyenTruyCapChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("QuyenTruyCap_LayDSQuyenTruyCapChuaCapNhatTaiNT", thamso);
        }
        public DataTable QuyenTruyCap_LayDSQuyenTruyCapChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("QuyenTruyCap_LayDSQuyenTruyCapChuaThemMoiTaiNT", thamso);
        }
        public void QuyenTruyCap_DongBoThemDanhMuc(DataTable _DSQuyenTruyCapChuaThem)
        {
            if (_DSQuyenTruyCapChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSQuyenTruyCapChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@QuyenID", SqlDbType.VarChar),
                                                new SqlParameter("@NhomNDID", SqlDbType.VarChar),
                                                new SqlParameter("@MenuID", SqlDbType.VarChar, 100),
                                                new SqlParameter("@FormID", SqlDbType.VarChar, 100),
                                                new SqlParameter("@Xem", SqlDbType.Bit),
                                                new SqlParameter("@Them_Sua", SqlDbType.Bit),
                                                new SqlParameter("@Xoa", SqlDbType.Bit),
                                                new SqlParameter("@Inn", SqlDbType.Bit),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int)
                                            };
                    thamso[0].Value = dr["QuyenID"].ToString();
                    thamso[1].Value = dr["NhomNDID"].ToString();
                    thamso[2].Value = dr["MenuID"].ToString();
                    thamso[3].Value = dr["FormID"].ToString();
                    thamso[4].Value = bool.Parse(dr["Xem"].ToString());
                    thamso[5].Value = bool.Parse(dr["Them_Sua"].ToString());
                    thamso[6].Value = bool.Parse(dr["Xoa"].ToString());
                    thamso[7].Value = bool.Parse(dr["Inn"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[9].Value = int.Parse(dr["MaxCapNhat"].ToString());
                   

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("QuyenTruyCap_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void QuyenTruyCap_DongBoSuaDanhMuc(DataTable _DSQuyenTruyCapChuaCapNhat)
        {
            if (_DSQuyenTruyCapChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSQuyenTruyCapChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@QuyenID", SqlDbType.VarChar),
                                                new SqlParameter("@NhomNDID", SqlDbType.VarChar),
                                                new SqlParameter("@MenuID", SqlDbType.VarChar, 100),
                                                new SqlParameter("@FormID", SqlDbType.VarChar, 100),
                                                new SqlParameter("@Xem", SqlDbType.Bit),
                                                new SqlParameter("@Them_Sua", SqlDbType.Bit),
                                                new SqlParameter("@Xoa", SqlDbType.Bit),
                                                new SqlParameter("@Inn", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int)
                                            };
                    thamso[0].Value = dr["QuyenID"].ToString();
                    thamso[1].Value = dr["NhomNDID"].ToString();
                    thamso[2].Value = dr["MenuID"].ToString();
                    thamso[3].Value = dr["FormID"].ToString();
                    thamso[4].Value = bool.Parse(dr["Xem"].ToString());
                    thamso[5].Value = bool.Parse(dr["Them_Sua"].ToString());
                    thamso[6].Value = bool.Parse(dr["Xoa"].ToString());
                    thamso[7].Value = bool.Parse(dr["Inn"].ToString());
                    thamso[8].Value = int.Parse(dr["MaxCapNhat"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("QuyenTruyCap_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }

        public DataTable LoadLenLuoi()
        {
            try
            {
                CDuLieu dl = new CDuLieu();
                return dl.LoadTable("QuyenTruyCap_LoadLenLuoi", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
