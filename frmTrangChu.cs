using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet
{
    public partial class frmTrangChu : DevComponents.DotNetBar.RibbonForm
    {
        public int _employee_id;
        public bool _permission;
        public frmTrangChu(int employee_id, bool permission)
        {
            InitializeComponent();
            _employee_id = employee_id;
            _permission = permission;
        }

        // Kiểm tra tình trạng mạng trên một luồng riêng
        public static async Task<bool> CheckForInternetConnectionAsync()
        {
            try
            {
                Ping myPing = new Ping();
                string host = "8.8.8.8";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();

                PingReply reply = await Task.Run(() => myPing.Send(host, timeout, buffer, pingOptions));
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            // Child form
            frmBanHang selling = new frmBanHang(_employee_id);

            foreach (Form child in MdiChildren) {
                child.Close();
            }

            // Define Mdi parent form
            selling.MdiParent = this;
            selling.Dock = DockStyle.Fill;
            selling.Show();
            selling.WindowState = FormWindowState.Maximized;
            selling.MaximizeBox = selling.MinimizeBox = false;
        }

        private void now_Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");          
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            btnSelling_Click(sender,e);
            
        }
            
        private async void internet_Check_Tick(object sender, EventArgs e)
        {
            bool isConnected = await CheckForInternetConnectionAsync();
            pcbConnection.Image = isConnected
                ? Properties.Resources.have_internet
                : Properties.Resources.not_have_internet;
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            // Child form
            frmQuanLyMenu editMenu = new frmQuanLyMenu();

            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            // Define Mdi parent form
            editMenu.MdiParent = this;
            editMenu.Dock = DockStyle.Fill;
            editMenu.Show();
            editMenu.WindowState = FormWindowState.Maximized;
            editMenu.MaximizeBox = editMenu.MinimizeBox = false;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien employee = new frmQuanLyNhanVien();

            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            // Define Mdi parent form
            employee.MdiParent = this;
            employee.Dock = DockStyle.Fill;
            employee.Show();
            employee.WindowState = FormWindowState.Maximized;
            employee.MaximizeBox = employee.MinimizeBox = false;
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon invoice = new frmQuanLyHoaDon();

            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            // Define Mdi parent form
            invoice.MdiParent = this;
            invoice.Dock = DockStyle.Fill;
            invoice.Show();
            invoice.WindowState = FormWindowState.Maximized;
            invoice.MaximizeBox = invoice.MinimizeBox = false;
        }
    }
}
