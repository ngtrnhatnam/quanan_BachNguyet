using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btn_reEnter_Click(object sender, EventArgs e)
        {
            txt_Username.Text = txt_Password.Text = String.Empty;
            txt_Username.Focus();
        }

        private void chb_showpw_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_showpw.Checked)
            {
                txt_Password.UseSystemPasswordChar = false;
            } else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            pcb_logo.Image = Properties.Resources.logo;
            pcb_username.Image = Properties.Resources.username;
            pcb_password.Image = Properties.Resources.password;
        }

        SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True");
        private void btn_Login_Click(object sender, EventArgs e)
        {
            String username, password;

            username = txt_Username.Text;
            password = txt_Password.Text;

            try
            {
                String querry = "SELECT * FROM users WHERE username = '" + txt_Username.Text + "' AND password = '" + txt_Password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_Username.Text;
                    password = txt_Password.Text;

                    Hide();
                    frmTrangChu home = new frmTrangChu();
                    home.ShowDialog();
                    home = null;
                    Show();
                    txt_Password.Clear();
                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không đúng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Password.Clear();

                    txt_Username.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
