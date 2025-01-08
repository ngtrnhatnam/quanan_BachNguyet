using DevComponents.DotNetBar.Controls;
using quan_an_Bach_Nguyet.Components;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Documents;
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
            String querry = "SELECT menuitem_id, name, price, availability FROM menu_items";
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
                        string id = reader["menuitem_id"].ToString();
                        string name = reader["name"].ToString();
                        string price = reader["price"].ToString();
                        bool availability = (bool)reader["availability"];
                        Widget wdg = new Widget();
                        wdg.SetData(id, name, price, availability);
                        wdg.Click += Widget_Click;
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

        private void Widget_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Widget widget)
                {
                    int soluong = int.Parse(txtSoLuong.Text) + 1;
                    decimal total = decimal.Parse(txtTongCong.Text);
                    string tenmon = widget.Controls["lblName"].Text;
                    decimal gia = Convert.ToDecimal(widget.Controls["lblPrice"].Text);
                    int id = Convert.ToInt32(widget.Controls["lblID"].Text);

                    // Kiểm tra xem món đã có trong dgvOrder chưa
                    bool daTonTai = false;
                    foreach (DataGridViewRow row in dgvOrder.Rows)
                    {
                        if (row.Cells["colTenMon"].Value?.ToString() == tenmon)
                        {
                            // Nếu đã tồn tại, tăng số lượng và cập nhật tổng cộng
                            int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                            row.Cells["colSoLuong"].Value = soLuong + 1;
                            row.Cells["colTongCong"].Value = gia * (soLuong + 1);
                            dgvOrder.ClearSelection();
                            row.Selected = true;
                            daTonTai = true;
                            break;
                        }
                    }

                    // Nếu chưa tồn tại, thêm dòng mới
                    if (!daTonTai)
                    {
                        int stt = dgvOrder.Rows.Count + 1; // Số thứ tự
                        int rowIndex = dgvOrder.Rows.Add(stt, id, tenmon, gia, 1, gia);
                        dgvOrder.ClearSelection();
                        dgvOrder.Rows[rowIndex].Selected = true;
                    }
                    total += gia;
                    txtTongCong.Text = total.ToString();
                    txtSoLuong.Text = soluong.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvOrder.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Clear();
            dgvOrder.Refresh();
            txtTongCong.Text = txtSoLuong.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvOrder.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvOrder.SelectedRows[0];
                    decimal giaMon = Convert.ToDecimal(selectedRow.Cells["colTongCong"].Value);
                    int soluong = Convert.ToInt32(selectedRow.Cells["colSoLuong"].Value);
                    decimal total = decimal.Parse(txtTongCong.Text);
                    int soLuongHT = int.Parse(txtSoLuong.Text);
                    total -= giaMon;
                    soLuongHT -= soluong;
                    dgvOrder.Rows.RemoveAt(selectedRow.Index);
                    txtTongCong.Text = total.ToString();
                    txtSoLuong.Text = soLuongHT.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(rdbCash.Checked == true)
            {
                DialogResult result = MessageBox.Show("Bạn đã nhận đủ tiền?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Hoàn tất hóa đơn!");
                    dgvOrder.Rows.Clear();
                    dgvOrder.Refresh();
                    txtTongCong.Text = txtSoLuong.Text = "0";
                }
            }
            else if(rdbBanking.Checked == true)
            {
                decimal total = Convert.ToDecimal(txtTongCong.Text);
                frmQR createQR = new frmQR(total);
                createQR.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(int.Parse(txtSoLuong.Text) == 0 && int.Parse(txtTongCong.Text) == 0)
            {
                btnThanhToan.Enabled = false;
                lblNothing.Visible = true;
            }
            else
            {
                btnThanhToan.Enabled = true;
                lblNothing.Visible = false;
            }
        }
    }
}
