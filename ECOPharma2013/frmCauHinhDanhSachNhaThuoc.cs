using CreateDllLicenseKey;
using ECOPharma2013.DuLieu;
using ECOPharma2013.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECOPharma2013
{
    public partial class frmCauHinhDanhSachNhaThuoc : Form
    {
        frmMain _frmMain;
        CreateLicenseKey XacNhanLicense = new CreateLicenseKey();

        public frmCauHinhDanhSachNhaThuoc()
        {
            
        }

        public frmCauHinhDanhSachNhaThuoc(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
            LayThongTinNhaThuoc();
        }

        private void LayThongTinNhaThuoc()
        {
            CSQLNhaThuoc nhathuoc = new CSQLNhaThuoc();
            cboTenChiNhanh.DataSource = nhathuoc.LayDanhSachNhaThuocLenLuoi(_frmMain.IsXemTatCa_);
            cboTenChiNhanh.DisplayMember = "TenNT";
            cboTenChiNhanh.ValueMember = "NTID";
            cboTenChiNhanh.SelectedIndex = -1;
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            try
            {
                CSQLCauHinhDanhSachNhaThuoc aCauHinhDanhSachNhaThuoc = new CSQLCauHinhDanhSachNhaThuoc();
                //string error1 = aCauHinhDanhSachNhaThuoc.LuuThongTinCauHinh(cboTenChiNhanh.SelectedValue.ToString(), cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem), XacNhanLicense.GetLicenseKey(txtServerName.Text), XacNhanLicense.GetLicenseKey(txtData.Text), XacNhanLicense.GetLicenseKey(txtUserName.Text), XacNhanLicense.GetLicenseKey(txtPass.Text));
               
                CStaticBien._RmtServer = txtServerName.Text.Trim();
                CStaticBien._RmtUserName = txtUserName.Text.Trim();
                CStaticBien._RmtPassword = txtPass.Text.Trim();
                CStaticBien._RmtDatabase = txtData.Text.Trim();

                SqlConnection RmtConn;
                CDuLieuRemote LopDLRmt = new CDuLieuRemote();
                RmtConn = LopDLRmt.RmtConnString();
                RmtConn.Open();
                if (RmtConn.State == ConnectionState.Open)
                {
                    RmtConn.Close();
                }
                RmtConn.Dispose();
                //Kết nối thành công => Lưu xuống Database Công ty

                //CSQLCauHinhDanhSachNhaThuoc aCauHinhDanhSachNhaThuoc = new CSQLCauHinhDanhSachNhaThuoc();
                string error =aCauHinhDanhSachNhaThuoc.LuuThongTinCauHinh(cboTenChiNhanh.SelectedValue.ToString(), cboTenChiNhanh.GetItemText(cboTenChiNhanh.SelectedItem), XacNhanLicense.GetLicenseKey(txtServerName.Text), XacNhanLicense.GetLicenseKey(txtData.Text), XacNhanLicense.GetLicenseKey(txtUserName.Text), XacNhanLicense.GetLicenseKey(txtPass.Text));
                if (!error.Equals("OK"))
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefault()
        {
            cboTenChiNhanh.SelectedIndex = -1;
            txtData.Text = txtPass.Text = txtServerName.Text = txtUserName.Text = "";
        }

        private void cboTenChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            CSQLCauHinhDanhSachNhaThuoc aCauHinhDanhSachNhaThuoc = new CSQLCauHinhDanhSachNhaThuoc();
            txtData.Text = txtPass.Text = txtServerName.Text = txtUserName.Text = "";
            try { 

            DataTable dt = aCauHinhDanhSachNhaThuoc.LayThongTinCauHinh(cboTenChiNhanh.SelectedValue.ToString());
            if (dt.Rows.Count == 1)
            {
                txtData.Text = XacNhanLicense.KiemTraLicenseKey(dt.Rows[0]["Database"].ToString());
                txtPass.Text = XacNhanLicense.KiemTraLicenseKey(dt.Rows[0]["Pass"].ToString());
                txtServerName.Text = XacNhanLicense.KiemTraLicenseKey(dt.Rows[0]["IP"].ToString());
                txtUserName.Text = XacNhanLicense.KiemTraLicenseKey(dt.Rows[0]["UserID"].ToString());
            }
            }
            catch { }
        }
    }
}
