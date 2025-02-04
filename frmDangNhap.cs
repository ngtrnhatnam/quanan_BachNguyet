﻿using quan_an_Bach_Nguyet.Models;
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
            txt_Username.Focus();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            String username = txt_Username.Text;
            String password = txt_Password.Text;

            using (SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True"))
            {
                try
                {
                    conn.Open();
                    String query = "SELECT * FROM users WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Kiểm tra nếu có dữ liệu
                            if (reader.Read())
                            {
                                var storedHashedPassword = reader["password"] as string;

                                // Kiểm tra mật khẩu người dùng nhập với mật khẩu đã mã hóa
                                if (VerifyPasswordWithBcrypt(password, storedHashedPassword))
                                {
                                    int employeeId = reader.GetInt32(reader.GetOrdinal("employee_id"));
                                    bool permission = reader.GetBoolean(reader.GetOrdinal("permission"));

                                    // Ẩn form đăng nhập và hiển thị trang chủ
                                    Hide();
                                    frmTrangChu home = new frmTrangChu(employeeId, permission);
                                    home.ShowDialog();
                                    home = null;
                                    Show();

                                    // Xóa mật khẩu và đưa focus về txt_Username
                                    txt_Password.Clear();
                                    txt_Username.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không đúng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txt_Password.Clear();
                                    txt_Username.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thông tin tài khoản không đúng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_Password.Clear();
                                txt_Username.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }

        public bool VerifyPasswordWithBcrypt(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
