﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using static System.Net.WebRequestMethods;

namespace quan_an_Bach_Nguyet
{
    public partial class frmTrangChu : DevComponents.DotNetBar.RibbonForm
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        // Kiểm tra tình trạng mạng
        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReversedValue);

        public static bool CheckForInternetConnection()//(int timeoutMs = 5000, string url = "https://google.com/")
        {
            try
            {
                Ping myPing = new Ping();
                String host = "8.8.8.8";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            // Child form
            frmBanHang selling = new frmBanHang();

            // Define Mdi parent form
            selling.MdiParent = this;
            selling.Show();
            selling.WindowState = FormWindowState.Maximized;
            selling.MaximizeBox = false;
            selling.MinimizeBox = false;
            btnSelling.Enabled = false;
        }

        private void now_Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");          
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
        }

        private void internet_Check_Tick(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
                pcbConnection.Image = Properties.Resources.have_internet;
            else pcbConnection.Image = Properties.Resources.not_have_internet;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string bankCode = "VCB";        // Mã ngân hàng (VD: VCB, TCB)
        //    string accountNumber = "0123456";    // Số tài khoản
        //    string amount = "30000";            // Số tiền
        //    string description = "TEXT";  // Nội dung chuyển khoản

        //    // Tạo nội dung QR theo chuẩn VietQR
        //    string qrContent = GenerateVietQRContent(bankCode, accountNumber, amount, description);

        //    // Tạo QR Code
        //    GenerateQRCode("00020101021238540010A00000072701240006970418011064207734260208QRIBFTTA5303704540410005802VN62080804Dat16304A632");
        //}

        //    private string GenerateVietQRContent(string bankCode, string accountNumber, string amount, string description)
        //    {
        //        // Giả lập cấu trúc VietQR đơn giản
        //        return $"bank:{bankCode}|acc:{accountNumber}|amt:{amount}|desc:{description}";
        //    }

        //private void GenerateQRCode(string content)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);

        //    // Hiển thị QR Code lên PictureBox
        //    picQrCode.Image = qrCode.GetGraphic(10);
        //}
    }
}
