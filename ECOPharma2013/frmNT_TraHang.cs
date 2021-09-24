using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.Printer_POS;
using ECOPharma2013.DuLieu;

namespace ECOPharma2013
{
    public partial class frmNT_TraHang : Form
    {
        frmMain fmain;
        public frmNT_TraHang(frmMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }

        private void frmNT_TraHang_Load(object sender, EventArgs e)
        {
            LoadLenLuoi();
        }

        public void LoadLenLuoi()
        {
            CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
            radGridView1.DataSource = th.NT_TraHang_LayDSLenLuoi(fmain.IsXemTatCa_);
        }

        public void RefreshrgvTraHang()
        {
            CSQLNT_TraHangTuKhach th = new CSQLNT_TraHangTuKhach();
            radGridView1.DataSource = th.NT_TraHang_LayDSLenLuoi(fmain.IsXemTatCa_);
        }
        public void SelectRows_NTTraHang(object sender, EventArgs e)
        {
            if (fmain.frmNT_TraHangEditisOpen_ == true)
            {

                fmain.fNT_TraHangEdit_.Select();
                return;
            }
            else
            {
                if (radGridView1.CurrentRow != null)
                {
                    try
                    {
                        fmain.fNT_TraHangEdit_ = new frmNT_TraHangEdit(fmain);
                        fmain.fNT_TraHangEdit_.NhanThongTinTufrmTraHang(radGridView1.CurrentRow.Cells["colSoCTBan"].Value.ToString(), radGridView1.CurrentRow.Cells["colSoCTTra"].Value.ToString(), radGridView1.CurrentRow.Cells["colTHid"].Value.ToString(), sender, e);
                        fmain.fNT_TraHangEdit_.ShowDialog();
                    }
                    catch { }
                }
            }
        }
        InTam_TraHang intam_tahang = new InTam_TraHang();
        bool intam = false;
        bool KTmayin = false;
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    XuLyMayInPos xuly_ = new XuLyMayInPos();
            //    if (KTmayin == false)
            //    {
            //        if (xuly_.printer == null)
            //        {
            //            try
            //            {
            //                xuly_.KetNoiMayIn();
            //                KTmayin = true;
            //                //statusTB.Text = "Máy in đã được kết nối";
            //            }
            //            catch
            //            {
            //                xuly_.printer = null;
            //                KTmayin = true;
            //                //statusTB.Text = "Máy in đang bị ngắt kết nối. Vui lòng kiểm tra lại";
            //            }
            //        }
            //    }
            //    CSQLNT_TraHangTuKhachCT thct = new CSQLNT_TraHangTuKhachCT();
            //    if (radGridView1.CurrentRow.Cells["colTHid"].Value.ToString() != null)
            //    {
            //        //Bảng cần in của anh em lấy ra đây
            //        //code In đặt đây
            //        CSQLNhaThuoc nhathuoc_ = new CSQLNhaThuoc();
            //        CSQLCauHinhHeThong chtt_ = new CSQLCauHinhHeThong();
            //        CSQLNT_BanHangCT banhangct_ = new CSQLNT_BanHangCT();
            //        CSQLNhanVien nv = new CSQLNhanVien();
            //        string tennv_ = nv.LayThongTinNhanVienTheoMa(radGridView1.CurrentRow.Cells["colNVBanHang"].Value.ToString()).Rows[0]["HoTen"].ToString();

            //        DataTable dtbnhathuoc = nhathuoc_.LayNhaThuocTheoMa(chtt_.LayDanhSachCauHinhHeThong().Rows[0]["TTCNid"].ToString());
            //        string tennhathuoc_ = dtbnhathuoc.Rows[0]["TenNT"].ToString();
            //        string telnhathuoc_ = dtbnhathuoc.Rows[0]["Tel"].ToString();

            //        DataTable bangTraHangCanIn = thct.NT_TraHangTuKhachCT_LayDSTraHangTuKhachCTTheoTHID(radGridView1.CurrentRow.Cells["colTHid"].Value.ToString());
            //        if (xuly_.printer != null)
            //        {
            //            try
            //            {
            //                intam_tahang.InTamCuaTraHang(xuly_.printer, tennhathuoc_, telnhathuoc_, radGridView1.CurrentRow.Cells["colSoCTTra"].Value.ToString(), CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, bangTraHangCanIn, decimal.Parse(radGridView1.CurrentRow.Cells["colTTTraCoTAXDaTinhPhiTraHang"].Value.ToString()));
            //                intam = true;
            //            }
            //            catch
            //            {
            //                xuly_.NgatKetNoiMayIn(xuly_.printer);
            //            }
            //            finally
            //            {
            //                if (intam == false)
            //                {
            //                    if (MessageBox.Show("Máy in đang bị mất kết nối. Nếu chọn YES để in thì phải kiểm tra nguồn máy in đã mở chưa hay dây USB của máy in có bị tuột không. Nếu chọn NO thì không cần in.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                    {
            //                        xuly_.KetNoiMayIn();
            //                        intam_tahang.InTamCuaTraHang(xuly_.printer, tennhathuoc_, telnhathuoc_, radGridView1.CurrentRow.Cells["colSoCTTra"].Value.ToString(), CStaticBien.STenMayThuNgan, tennv_, CStaticBien.StaiKhoan, bangTraHangCanIn, decimal.Parse(radGridView1.CurrentRow.Cells["colTTTraCoTAXDaTinhPhiTraHang"].Value.ToString()));
            //                    }
            //                }
            //                else
            //                {
            //                    intam = false;
            //                }

            //            }
            //        }
            //        else
            //        {
            //            //statusTB.Text = " Máy in bị ngắt kết nối. Vui lòng kiểm tra.";
            //        }
            //    }
            //    if (xuly_.printer != null)
            //    {
            //        xuly_.NgatKetNoiMayIn(xuly_.printer);
            //    }
            //    KTmayin = false;
            //}
            //catch { }
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectRows_NTTraHang(sender, e);
        }
    }
}
