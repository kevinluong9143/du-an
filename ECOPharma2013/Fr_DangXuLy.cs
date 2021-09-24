using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ECOPharma2013
{
    public partial class Fr_DangXuLy : Form
    {
        private Fr_DangXuLy()
        {
            InitializeComponent();
        }

        // Các biến toàn cục lưu thread
        private static Thread _ThreadFrmCho;
        private static Fr_DangXuLy _FormDangXuLy;
        private int inttime=0;

        // Hiện màn hình form Chờ   
        public static void ShowFormCho()
        {
            //if (_ThreadFrmCho == null)
            //{
                // Hiển thị form chờ trong thread mới         
                _ThreadFrmCho = new Thread(new ThreadStart(HienFormCho));
                //_ThreadFrmCho.IsBackground = true;
                _ThreadFrmCho.Start();
            //}
        }
        
        // Hàm gọi bởi thread 
        private static void HienFormCho()
        {
            _FormDangXuLy = new Fr_DangXuLy();
            _FormDangXuLy.StartPosition = FormStartPosition.CenterScreen;
            _FormDangXuLy.TopMost = true;
            _FormDangXuLy.timerTG.Start();
   
            //Application.Run(_FormDangXuLy);
            _FormDangXuLy.ShowDialog();
        }

        // Đóng màn hình form chờ
        public static void DongFormCho()
        {
            try
            {
                _FormDangXuLy.timerTG.Stop();
                if (_FormDangXuLy.InvokeRequired)
                    _FormDangXuLy.Invoke(new MethodInvoker(DongFormCho));
                else
                {
                    //Application.ExitThread();
                    if (_ThreadFrmCho.IsAlive == true)
                    {
                        //_ThreadFrmCho.Abort();
                        _FormDangXuLy.Close();
                    }
                }
            }
            catch (Exception ex)
            { 
                //MessageBox.Show(ex.Message); 
            }
        }

        private int DoiGioPhutGiaySangGiay(string gio, string phut, string giay)
        {
            try
            {
                int kq = int.Parse(gio) * 3600 + int.Parse(phut) * 60 + int.Parse(giay);
                return kq;
            }
            catch (Exception ex) { throw ex; }
        }

        private string[] DoiGiaySangGioPhut(int giay)
        {
            try
            {
                string[] thoigian = new string[3];
                thoigian[0] = (giay / 3600).ToString();
                if (thoigian[0].Length == 1)
                    thoigian[0] = "0" + thoigian[0];
                thoigian[1] = ((giay % 3600) / 60).ToString();
                if (thoigian[1].Length == 1)
                    thoigian[1] = "0" + thoigian[1];
                thoigian[2] = ((giay % 3600) % 60).ToString();
                if (thoigian[2].Length == 1)
                    thoigian[2] = "0" + thoigian[2];
                return thoigian;
            }
            catch (Exception ex) { throw ex; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                inttime += 1;
                string[] thoigianchay = DoiGiaySangGioPhut(inttime);
                lblThoiGianChay.Text = thoigianchay[0] + " : " + thoigianchay[1] + " : " + thoigianchay[2];
            }
            catch { }
        }
    }
}
