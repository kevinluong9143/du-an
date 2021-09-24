using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013.SQL
{
    class CSQLThanhPho
    {
        string _sMaThanhPho;

        public string SMaThanhPho
        {
            get { return _sMaThanhPho; }
            set { _sMaThanhPho = value; }
        }
        string _sTenThanhPho;

        public string STenThanhPho
        {
            get { return _sTenThanhPho; }
            set { _sTenThanhPho = value; }
        }
        string _sGhiChu;

        public string SGhiChu
        {
            get { return _sGhiChu; }
            set { _sGhiChu = value; }
        }
        bool _bKhongSuDung;

        public bool BKhongSuDung
        {
            get { return _bKhongSuDung; }
            set { _bKhongSuDung = value; }
        }

        public CSQLThanhPho() { }
        public CSQLThanhPho(string maThanhPho, string tenThanhPho, string ghiChu, bool khongSuDung)
        {
            this.SMaThanhPho = maThanhPho;
            this.STenThanhPho = tenThanhPho;
            this.SGhiChu = ghiChu;
            this.BKhongSuDung = khongSuDung;
        }

        /// <summary>
        /// Hàm thêm thành phố
        /// </summary>
        /// <param name="tenThanhPho">Tên thành phố (string)</param>
        /// <param name="ghiChu">Ghi chú về thành phố (string)</param>
        /// <param name="khongSuDung">Xác định trạng thái có sử dụng thông tin thành phố này hay không (Bool: 0:có / 1:không)</param>
        /// <returns>'Mã thành phố' sẽ được trả về nếu thêm thành công, nếu không trả về chuỗi null.</returns>
        public string ThemThanhPho(CSQLThanhPho thanhPho)
        {
            SqlParameter[] thamso = { new SqlParameter("@TenTP", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@KhongSuDung", SqlDbType.Bit), new SqlParameter("@KetQua", SqlDbType.VarChar, 50) };
            thamso[0].Value = thanhPho.STenThanhPho;
            thamso[1].Value = thanhPho.SGhiChu;
            thamso[2].Value = thanhPho.BKhongSuDung;
            thamso[3].Direction = ParameterDirection.Output;

            CDuLieu xldl = new CDuLieu();
            try
            {
                xldl.InsertDuLieu("ThanhPho_ThemMoiThanhPho", thamso, null);
                string kq = thamso[3].Value.ToString();
                if (kq.CompareTo("") > 0)
                {
                    return kq;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm sửa thành phố
        /// </summary>
        /// <param name="tenThanhPho">Tên thành phố (string)</param>
        /// <param name="ghiChu">Ghi chú về thành phố (string)</param>
        /// <param name="khongSuDung">Xác định trạng thái có sử dụng thông tin thành phố này hay không (Bool: 0:có / 1:không)</param>
        /// <returns>Nếu sửa thành công kq trả về là 1, nếu ko trả về 0</returns>
        public int SuaThanhPho(CSQLThanhPho thanhPho)
        {
            SqlParameter[] thamso = { new SqlParameter("@TPID", SqlDbType.VarChar, 50),new SqlParameter("@TenTP", SqlDbType.NVarChar), new SqlParameter("@GhiChu", SqlDbType.NText), new SqlParameter("@KhongSuDung", SqlDbType.Bit)};
            thamso[0].Value = thanhPho.SMaThanhPho;
            thamso[1].Value = thanhPho.STenThanhPho;
            thamso[2].Value = thanhPho.SGhiChu;
            thamso[3].Value = thanhPho.BKhongSuDung;

            CDuLieu xldl = new CDuLieu();
            try
            {
                return xldl.ThucThiTraVeKetQuaKieuInt("ThanhPho_ChinhSuaThongTinThanhPho", thamso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Hàm xóa thông tin thành phố
        /// </summary>
        /// <param name="maThanhPho">Mã thành phố muốn xóa</param>
        /// <returns></returns>
        public int XoaThanhPho(string maThanhPho)
        {
            SqlParameter[] thamso = { new SqlParameter("@TPID", SqlDbType.VarChar, 50) };
            thamso[0].Value = maThanhPho;
            CDuLieu xldl = new CDuLieu();
            try
            {
                return xldl.ThucThiTraVeKetQuaKieuInt("ThanhPho_XoaThongTinThanhPho", thamso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Hàm lấy thông tin thành phố
        /// </summary>
        /// <param name="XemTatCa">Trạng thái về thông tin thành phố (bool) active: 0, disable: 1</param>
        /// <returns>Bảng lưu thông tin về thành phố</returns>
        public DataTable LayThongTinThanhPho(bool xemTatCa)
        {
            SqlParameter[] thamso = { new SqlParameter("@XemTatCa", SqlDbType.Bit) };
            thamso[0].Value = xemTatCa;

            CDuLieu xldl = new CDuLieu();
            try
            {
                return xldl.LoadTable("ThanhPho_LayThongTinLenLuoi", thamso);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Hàm lấy thông tin thành phố
        /// </summary>
        /// <param name="maTP">Mã thành phố muốn lấy thông tin</param>
        /// <returns>Bảng lưu thông tin về thành phố</returns>
        public DataTable LayThongTinThanhPhoTheoMa(string matp)
        {
            SqlParameter[] thamso = {new SqlParameter("@TPID", SqlDbType.VarChar, 50)};
            thamso[0].Value = matp;
            CDuLieu xldl = new CDuLieu();
            try { return xldl.LoadTable("ThanhPho_LayThanhPhoTheoMa", thamso); }
            catch (Exception ex) { throw ex; }
        }

        public int ThanhPho_LayMaxCapNhatNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("ThanhPho_LayMaxCapNhat", null);
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
        public int ThanhPho_LayMaxCapNhatECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("ThanhPho_LayMaxCapNhat", null);
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
        public int ThanhPho_LayMaxThemMoiNT()
        {
            CDuLieu dl = new CDuLieu();
            DataTable dtb = dl.LoadTable("ThanhPho_LayMaxThemMoi", null);
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
        public int ThanhPho_LayMaxThemMoiECO()
        {
            CDuLieuRemote dl = new CDuLieuRemote();
            DataTable dtb = dl.LoadTable("ThanhPho_LayMaxThemMoi", null);
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
        public DataTable ThanhPho_LayDSThanhPhoChuaCapNhatTaiNT(int maxCapNhatNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxCapNhatnt", SqlDbType.Int) };
            thamso[0].Value = maxCapNhatNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("ThanhPho_LayDSThanhPhoChuaCapNhatTaiNT", thamso);
        }
        public DataTable ThanhPho_LayDSThanhPhoChuaThemMoiTaiNT(int maxThemMoiNT)
        {
            SqlParameter[] thamso = { new SqlParameter("@MaxThemMoiNT", SqlDbType.Int) };
            thamso[0].Value = maxThemMoiNT;
            CDuLieuRemote dl = new CDuLieuRemote();
            return dl.LoadTable("ThanhPho_LayDSThanhPhoChuaThemMoiTaiNT", thamso);
        }
        public void ThanhPho_DongBoThemDanhMuc(DataTable _DSThanhPhoChuaThem)
        {
            if (_DSThanhPhoChuaThem.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSThanhPhoChuaThem.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@TenTP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@MaxThemMoi", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["TPID"].ToString();
                    thamso[1].Value = dr["TenTP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = int.Parse(dr["MaxThemMoi"].ToString());
                    thamso[6].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("ThanhPho_DongBoThemDanhMuc", thamso, null);
                }
            }
        }

        public void ThanhPho_DongBoSuaDanhMuc(DataTable _DSThanhPhoChuaCapNhat)
        {
            if (_DSThanhPhoChuaCapNhat.Rows.Count > 0)
            {
                foreach (DataRow dr in _DSThanhPhoChuaCapNhat.Rows)
                {
                    SqlParameter[] thamso = { new SqlParameter("@TPID", SqlDbType.VarChar),
                                                new SqlParameter("@TenTP", SqlDbType.NVarChar),
                                                new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                                                new SqlParameter("@KhongSuDung", SqlDbType.Bit),
                                                new SqlParameter("@MaxCapNhat", SqlDbType.Int),
                                                new SqlParameter("@IsXoa", SqlDbType.Bit)
                                            };
                    thamso[0].Value = dr["TPID"].ToString();
                    thamso[1].Value = dr["TenTP"].ToString();
                    thamso[2].Value = dr["GhiChu"].ToString();
                    thamso[3].Value = bool.Parse(dr["KhongSuDung"].ToString());
                    thamso[4].Value = int.Parse(dr["MaxCapNhat"].ToString());
                    thamso[5].Value = bool.Parse(dr["IsXoa"].ToString());

                    CDuLieu dl = new CDuLieu();
                    dl.InsertDuLieu("ThanhPho_DongBoSuaDanhMuc", thamso, null);
                }
            }
        }
    }
}
