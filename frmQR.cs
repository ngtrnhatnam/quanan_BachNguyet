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
        private int _employee_id;
        private int _bill_id;
        public event Action<bool> OnFormClosedEvent;
        private readonly CreatePaymentQR QR = new CreatePaymentQR();
        public frmQR(decimal total, int employee_id, int bill_id)
        {
            InitializeComponent();
            totalAmount = total;
            _employee_id = employee_id;
            _bill_id = bill_id;
        }

        private async void frmQR_Load(object sender, EventArgs e)
        {
            string content = DateTime.Now.ToString("ddMMyyyy") + " " + _bill_id + " " + _employee_id;
            lblTotal.Text += totalAmount.ToString("N0");
            lblBillID.Text += _bill_id.ToString();
            lblEmployeeID.Text += _employee_id.ToString();
            lblPaymentDay.Text += DateTime.Now.ToString("dd/MM/yyyy");
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn đã nhận đủ tiền?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OnFormClosedEvent?.Invoke(true);
                this.Close(); // Đóng form
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            OnFormClosedEvent?.Invoke(false);
            this.Close(); // Đóng form
        }
    }
}
