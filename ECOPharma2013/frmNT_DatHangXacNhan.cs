using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using System.Transactions;
using ECOPharma2013.DuLieu;
using System.Threading;

namespace ECOPharma2013
{
    public partial class frmNT_DatHangXacNhan : Form
    {
        frmMain fmain;
        public frmNT_DatHangXacNhan()
        {
            InitializeComponent();
        }
        public frmNT_DatHangXacNhan(frmMain _frmMain)
        {
            InitializeComponent();
            fmain = _frmMain;
        }

        private void frmNT_DatHangXacNhan_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLNT_DatHang dh = new CSQLNT_DatHang();
            try
            {
                rgv.DataSource = dh.LoadLenLuoi_XacNhan();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void XacNhan()
        {
            CQuyenTruyCap qtc = new CQuyenTruyCap();
            if (qtc.KiemTraQuyenThem_Sua(fmain.fNT_DatHangXacNhan.Name) == false)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
                return;
            }
            try
            {
                CRmtServer KetNoiServer = new CRmtServer();
                if (KetNoiServer.KiemTraKetNoiRmtServer() == false)
                {
                    MessageBox.Show("Kết nối server tổng công ty không thành công. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    Fr_DangXuLy.ShowFormCho();

                    #region Bản Củ
                    ////Fr_DangXuLy.HienThiManHinhCho();
                    //for (int i = 0; i < rgv.Rows.Count; i++)
                    //{
                    //    rgv.Rows[i].Cells[0].EndEdit();
                    //    if (rgv.Rows[i].Cells[0].Value != null)
                    //    {
                    //        bool chon = (bool)rgv.Rows[i].Cells[0].Value;
                    //        if (chon == true)
                    //        {
                    //            TransactionOptions options = new TransactionOptions();
                    //            options.Timeout = new TimeSpan(0, 1, 0);
                    //            using (TransactionScope giaotac = new TransactionScope(TransactionScopeOption.Required, options))
                    //            {
                    //                //Xác nhận đơn hàng
                    //                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                    //                int kqxn = -1;
                    //                try
                    //                {
                    //                    kqxn = dh.XacNhan(rgv.Rows[i].Cells["colDHID"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    Fr_DangXuLy.DongFormCho();
                    //                    MessageBox.Show("Đã có lỗi phát sinh khi xác nhận: " + ex.Message);
                    //                    return;
                    //                }
                    //                //Copy đơn hàng lên server
                    //                if (kqxn > 0)
                    //                {
                    //                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    //                    DataTable table_dhct = dhct.LoadLenLuoi(rgv.Rows[i].Cells["colDHID"].Value.ToString());
                    //                    if (table_dhct != null && table_dhct.Rows.Count > 0)
                    //                    {
                    //                        //Thêm đơn hàng xuất master
                    //                        using (TransactionScope giaotac2 = new TransactionScope())
                    //                        {
                    //                            try
                    //                            {
                    //                                if (bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()) == false)
                    //                                {
                    //                                    dh.Them_DonHangXuat_TaiTCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, false, rgv.Rows[i].Cells["NhomSPID"].Value.ToString());
                    //                                }
                    //                                else 
                    //                                {
                    //                                    dh.Them_DonHangXuat_TaiTCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, bool.Parse(rgv.Rows[i].Cells["colHangDacBiet"].Value.ToString()));
                    //                                }
                    //                                giaotac2.Complete();
                    //                            }
                    //                            catch (Exception ex)
                    //                            {
                    //                                MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất lên tổng cty: " + ex.Message);
                    //                                return;
                    //                            }
                    //                        }
                    //                        //Thêm đơn hàng xuất ct
                    //                        using (TransactionScope giaotac1 = new TransactionScope())
                    //                        {
                    //                            foreach (DataRow dr in table_dhct.Rows)
                    //                            {
                    //                                try
                    //                                {
                    //                                    decimal sldat = 0;
                    //                                    if (dr["SLDat"].ToString().CompareTo("") != 0)
                    //                                        sldat = decimal.Parse(dr["SLDat"].ToString());
                    //                                    dhct.Them_DonHangXuatCT_TaiTongCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), dr["SPID"].ToString(), sldat, dr["DVT"].ToString(), dr["NSXID"].ToString());
                    //                                }
                    //                                catch (ApplicationException ex)
                    //                                {
                    //                                    MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất chi tiết lên tổng cty: " + ex.Message);
                    //                                    return;
                    //                                }
                    //                                catch (Exception ex)
                    //                                {
                    //                                    MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất chi tiết lên tổng cty: " + ex.Message);
                    //                                    return;
                    //                                }
                    //                            }
                    //                            giaotac1.Complete();
                    //                        }
                    //                    }
                    //                }

                    //                //update Đã chuyển công ty
                    //                dh.CapNhat_DaChuyenVeTongCty(rgv.Rows[i].Cells["colDHID"].Value.ToString());
                    //                giaotac.Complete();

                    //            }
                    //        }
                    //    }
                    //}
                    //LoadLenLuoi();
                    ////Fr_DangXuLy.DongManHinhCho();
                    #endregion 

                    #region  Gởi đơn hàng đặt về ECO

                    //CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    //DataTable table_dhct = new DataTable();

                    //TransactionOptions options = new TransactionOptions();
                    //options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                    //options.Timeout = new TimeSpan(0, 20, 0);
                    //using (TransactionScope giaotac = new TransactionScope(TransactionScopeOption.Required, options))
                    //{
                    //    for (int i = 0; i < rgv.Rows.Count; i++)
                    //    {
                    //        rgv.Rows[i].Cells[0].EndEdit();
                    //        if (rgv.Rows[i].Cells[0].Value != null)
                    //        {
                    //            bool chon = (bool)rgv.Rows[i].Cells[0].Value;
                    //            if (chon == true)
                    //            {

                    //                //Xác nhận đơn hàng
                    //                #region
                    //                CSQLNT_DatHang dh = new CSQLNT_DatHang();
                    //                int kqxn = -1;
                    //                //using (TransactionScope giaotac_xacnhandonhang = new TransactionScope(TransactionScopeOption.RequiresNew))
                    //                //{
                    //                try
                    //                {
                    //                    kqxn = dh.XacNhan(rgv.Rows[i].Cells["colDHID"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                    //                    //giaotac_xacnhandonhang.Complete();
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    Fr_DangXuLy.DongFormCho();
                    //                    MessageBox.Show("Đã có lỗi phát sinh khi xác nhận: " + ex.Message);
                    //                    return;
                    //                }
                    //                //}

                    //                #endregion

                    //                //Copy đơn hàng lên server
                    //                if (kqxn > 0)
                    //                {
                    //                    //using (TransactionScope giaotac_LayDH_NT = new TransactionScope(TransactionScopeOption.RequiresNew))
                    //                    //{
                    //                    //try
                    //                    //{
                    //                    table_dhct = dhct.LoadLenLuoi(rgv.Rows[i].Cells["colDHID"].Value.ToString());
                    //                    //giaotac_LayDH_NT.Complete();
                    //                    //}
                    //                    //catch (System.Transactions.TransactionAbortedException ex)
                    //                    //{
                    //                    //    MessageBox.Show("Chưa lấy được đơn hàng đặt từ Nhà Thuốc.");
                    //                    //}
                    //                    //}

                    //                    if (table_dhct != null && table_dhct.Rows.Count > 0)
                    //                    {
                    //                        using (TransactionScope giaotac_TaoMaster_Cty = new TransactionScope(TransactionScopeOption.RequiresNew))
                    //                        {
                    //                            //Thêm đơn hàng xuất master
                    //                            #region
                    //                            try
                    //                            {
                    //                                if (bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()) == false)
                    //                                {
                    //                                    dh.Them_DonHangXuat_TaiTCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, false, rgv.Rows[i].Cells["NhomSPID"].Value.ToString());
                    //                                }
                    //                                else
                    //                                {
                    //                                    dh.Them_DonHangXuat_TaiTCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, bool.Parse(rgv.Rows[i].Cells["colHangDacBiet"].Value.ToString()));
                    //                                }

                    //                            }
                    //                            catch (Exception ex)
                    //                            {
                    //                                MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất lên tổng cty: " + ex.Message);
                    //                                return;
                    //                            }
                    //                            #endregion

                    //                            //Thêm đơn hàng xuất ct
                    //                            #region
                    //                            //using (TransactionScope giaotac_TaoDetail_Cty = new TransactionScope(TransactionScopeOption.RequiresNew))
                    //                            //{
                    //                            foreach (DataRow dr in table_dhct.Rows)
                    //                            {
                    //                                try
                    //                                {
                    //                                    decimal sldat = 0;
                    //                                    if (dr["SLDat"].ToString().CompareTo("") != 0)
                    //                                        sldat = decimal.Parse(dr["SLDat"].ToString());

                    //                                    dhct.Them_DonHangXuatCT_TaiTongCty(rgv.Rows[i].Cells["colDHID"].Value.ToString(), dr["SPID"].ToString(), sldat, dr["DVT"].ToString(), dr["NSXID"].ToString());
                    //                                }
                    //                                //catch (System.Transactions.TransactionAbortedException ex)
                    //                                //{
                    //                                //    MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất chi tiết lên tổng cty: " + ex.Message);
                    //                                //    return;
                    //                                //}
                    //                                catch (Exception ex)
                    //                                {
                    //                                    MessageBox.Show("Đã có lỗi phát sinh khi thêm đơn hàng xuất chi tiết lên tổng cty: " + ex.Message);
                    //                                    return;
                    //                                }
                    //                            }
                    //                            #endregion
                    //                            giaotac_TaoMaster_Cty.Complete();
                    //                            //giaotac_TaoDetail_Cty.Complete();
                    //                        }

                    //                    }
                    //                }
                    //                //update Đã chuyển công ty
                    //                #region
                    //                dh.CapNhat_DaChuyenVeTongCty(rgv.Rows[i].Cells["colDHID"].Value.ToString());
                    //                #endregion

                    //            }
                    //        }
                    //    }
                    //    giaotac.Complete();
                    //}
                    //LoadLenLuoi();
                    #endregion

                    #region  Gởi đơn hàng đặt theo Datatable về ECO

                    CSQLNT_DatHang dh = new CSQLNT_DatHang();
                    CSQLNT_DatHangCT dhct = new CSQLNT_DatHangCT();
                    DataTable table_dhct = new DataTable();

                    for (int i = 0; i < rgv.Rows.Count; i++)
                    {
                        rgv.Rows[i].Cells[0].EndEdit();
                        if (rgv.Rows[i].Cells[0].Value != null)
                        {
                            bool chon = (bool)rgv.Rows[i].Cells[0].Value;
                            if (chon == true)
                            {
                                //Xác nhận đơn hàng
                                #region

                                int kqxn = -1;
                                try
                                {
                                    kqxn = dh.XacNhan(rgv.Rows[i].Cells["colDHID"].Value.ToString(), CStaticBien.SmaTaiKhoan);

                                }
                                catch (Exception ex)
                                {
                                    Fr_DangXuLy.DongFormCho();
                                    MessageBox.Show("Đã có lỗi phát sinh khi xác nhận: " + ex.Message);
                                    return;
                                }
                                #endregion

                                //Gửi đơn hàng đặt về công ty
                                if (kqxn > 0)
                                {
                                    table_dhct = dhct.Load_SPid_DVT_NSXid_SLDat(rgv.Rows[i].Cells["colDHID"].Value.ToString());

                                    if (table_dhct != null && table_dhct.Rows.Count > 0)
                                    {
                                        string ketqua;
                                        //Thêm đơn hàng đặt vào đơn hàng xuất công ty
                                        #region

                                        if (bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()) == false)
                                        {
                                            ketqua = dhct.NTDatHangCT_Insert_ECODonHangXuatCT(table_dhct, rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, false, rgv.Rows[i].Cells["NhomSPID"].Value.ToString());
                                        }
                                        else
                                        {
                                            ketqua = dhct.NTDatHangCT_Insert_ECODonHangXuatCT(table_dhct, rgv.Rows[i].Cells["colDHID"].Value.ToString(), rgv.Rows[i].Cells["colSODH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), rgv.Rows[i].Cells["colNoiDH"].Value.ToString(), bool.Parse(rgv.Rows[i].Cells["colDonKhan"].Value.ToString()), rgv.Rows[i].Cells["colGhiChu"].Value.ToString(), CStaticBien.SmaTaiKhoan, bool.Parse(rgv.Rows[i].Cells["colHangDacBiet"].Value.ToString()));
                                        }

                                        if (!ketqua.Equals("OK"))
                                        {
                                            kqxn = dh.CAPNHATLAI_XACNHAN(rgv.Rows[i].Cells["colDHID"].Value.ToString(), CStaticBien.SmaTaiKhoan);
                                            Fr_DangXuLy.DongFormCho();
                                            MessageBox.Show(ketqua);

                                        }
                                        else
                                        {
                                            //update Đã chuyển đơn đặt hàng về công ty      

                                            dh.CapNhat_DaChuyenVeTongCty(rgv.Rows[i].Cells["colDHID"].Value.ToString());
                                            Fr_DangXuLy.DongFormCho();
                                            MessageBox.Show("Đã gửi đơn hàng thành công");
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    LoadLenLuoi();
                    #endregion

                    Fr_DangXuLy.DongFormCho();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Fr_DangXuLy.DongFormCho();
            }
        }
    }
}
