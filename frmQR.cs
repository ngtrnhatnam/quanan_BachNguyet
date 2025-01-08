using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;
using quan_an_Bach_Nguyet.Models;

namespace quan_an_Bach_Nguyet
{
    public partial class frmQR : Form
    {
        private decimal totalAmount;
        private readonly CreatePaymentQR QR = new CreatePaymentQR();
        public frmQR(decimal total)
        {
            InitializeComponent();
            totalAmount = total;
        }

        private async void frmQR_Load(object sender, EventArgs e)
        {
            lblTotal.Text += totalAmount.ToString();
            try
            {
                string qrDataUrl = await QR._CreatePaymentQR(totalAmount);

                // Loại bỏ tiền tố "data:image/png;base64,"
                string base64Data = qrDataUrl.Substring(qrDataUrl.IndexOf(",") + 1);
                byte[] imageBytes = Convert.FromBase64String(base64Data);

                using (var ms = new MemoryStream(imageBytes))
                {
                    ptbQR.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
