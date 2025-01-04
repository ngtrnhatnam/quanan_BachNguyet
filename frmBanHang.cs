using quan_an_Bach_Nguyet.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True");
            String querry = "SELECT name, price, availability FROM menu_items";
            try
            {
                using (SqlConnection connection = conn)
                {
                    SqlCommand cmd = new SqlCommand(querry, connection);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    pnlMenu.SuspendLayout(); // Tạm dừng cập nhật giao diện
                    pnlMenu.Controls.Clear(); // Xóa các widget cũ nếu cần
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string price = reader["price"].ToString();
                        bool availability = (bool)reader["availability"];
                        Widget wdg = new Widget();
                        wdg.SetData(name, price, availability);
                        pnlMenu.Controls.Add(wdg);
                    }
                    reader.Close();
                    pnlMenu.ResumeLayout();
                    
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Button _previousButton;
        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Đặt lại màu của nút trước đó (nếu có)
                if (_previousButton != null)
                {
                    _previousButton.BackColor = Color.FromArgb(1, 115, 199);
                }

                // Đổi màu nút hiện tại
                button.BackColor = Color.OrangeRed;

                // Cập nhật nút hiện tại thành nút trước đó
                _previousButton = button;
            }
        }
    }
}
