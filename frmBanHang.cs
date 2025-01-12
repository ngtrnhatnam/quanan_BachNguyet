using DevComponents.DotNetBar.Controls;
using DevComponents.WinForms.Drawing;
using quan_an_Bach_Nguyet.Components;
using quan_an_Bach_Nguyet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet
{
    public partial class frmBanHang : Form
    {
        private int _employee_id;
        public frmBanHang(int employee_id)
        {
            InitializeComponent();
            _employee_id = employee_id;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            SetPlaceholderText(txtFindBox, "Nhập tên cần tìm...");
            LoadData("");
            LoadBillID();
            FillCategory();

        }

        private void LoadData(string searchText)
        {
            SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True");
            String querry = "SELECT menuitem_id, item_name, price, availability FROM menu_items";

            if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Nhập tên cần tìm...")
            {
                querry += " WHERE item_name LIKE @searchText";
            }

            try
            {
                using (SqlConnection connection = conn)
                {
                    SqlCommand cmd = new SqlCommand(querry, connection);
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");
                    }
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    pnlMenu.SuspendLayout(); // Tạm dừng cập nhật giao diện
                    pnlMenu.Controls.Clear(); // Xóa các widget cũ nếu cần
                    while (reader.Read())
                    {
                        string id = reader["menuitem_id"].ToString();
                        string name = reader["item_name"].ToString();
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
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCategory()
        {
            try
            {
                BachNguyetDBContext context = new BachNguyetDBContext();
                List<category> listCategory = context.categories.ToList();

                listCategory.Insert(0, new category
                {
                    category_id = 0,
                    fod_category = "Tất cả"
                });

                this.cmbCategory.DataSource = listCategory;
                this.cmbCategory.DisplayMember = "fod_category";
                this.cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = 0;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                    txtTongCong.Text = total.ToString("");
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
                    SaveOrder();
                    SaveBill("Cash");
                    LoadBillID();
                    dgvOrder.Rows.Clear();
                    dgvOrder.Refresh();
                    txtTongCong.Text = txtSoLuong.Text = "0";
                    
                }
            }
            else if(rdbBanking.Checked == true)
            {
                decimal total = Convert.ToDecimal(txtTongCong.Text);
                int bill_id = int.Parse(txtBillID.Text);
                frmQR createQR = new frmQR(total, bill_id, _employee_id);
                createQR.OnFormClosedEvent += (result) =>
                {
                    if (result)
                    {
                        MessageBox.Show("Hoàn tất hóa đơn!");
                        SaveOrder();
                        SaveBill("Bank");
                        LoadBillID();
                        dgvOrder.Rows.Clear();
                        dgvOrder.Refresh();
                        txtTongCong.Text = txtSoLuong.Text = "0";
                    }
                };
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

        private void SaveOrder()
        {
            try
            {
                using (var context = new BachNguyetDBContext())
                {
                    order _order = new order
                    {
                        order_id = int.Parse(txtBillID.Text),
                        order_date = DateTime.Now,
                        employee_id = _employee_id,
                    };
                    context.orders.Add(_order);
                    context.SaveChanges();
                    SaveOrderDetail();
                }
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show(dbEx.InnerException?.InnerException?.Message ?? dbEx.Message, "Lỗi khi lưu dữ liệu bảng Order!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }

        private void SaveBill(string method)
        {
            try
            {
                using (var context = new BachNguyetDBContext())
                {
                    bill _bill = new bill
                    {
                        payment_date = DateTime.Now,
                        total_amount = Convert.ToDecimal(txtTongCong.Text),
                        payment_method = method,
                        order_id = int.Parse(txtBillID.Text),
                        employee_id = _employee_id
                    };
                    context.bills.Add(_bill);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show(dbEx.InnerException?.InnerException?.Message ?? dbEx.Message, "Lỗi khi lưu dữ liệu bảng Bills!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }

        private void SaveOrderDetail()
        {
            try
            {
                //Danh sách để chứa các chi tiết đơn hàng
                using (var context = new BachNguyetDBContext())
                {
                    List<order_details> orderDetails = new List<order_details>();
                    for (int i = 0; i < dgvOrder.Rows.Count; i++)
                    {
                        var menuItemId = int.Parse(dgvOrder.Rows[i].Cells["colMaMon"].Value?.ToString());
                        var price = decimal.Parse(dgvOrder.Rows[i].Cells["colGiaMon"].Value?.ToString());
                        var quantity = int.Parse(dgvOrder.Rows[i].Cells["colSoLuong"].Value?.ToString());
                        var subtotal = decimal.Parse(dgvOrder.Rows[i].Cells["colTongCong"].Value?.ToString());
                        if (menuItemId > 0 && price > 0 && quantity > 0 && subtotal > 0)
                        {
                            order_details _order_detail = new order_details
                            {
                                order_id = int.Parse(txtBillID.Text),
                                menuitem_id = menuItemId,
                                price = price,
                                quantity = quantity,
                                subtotal = subtotal,
                            };

                            // Thêm đối tượng vào danh sách
                            orderDetails.Add(_order_detail);
                        }
                    }
                    context.order_details.AddRange(orderDetails);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show(dbEx.InnerException?.InnerException?.Message ?? dbEx.Message, "Lỗi khi lưu dữ liệu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }


        private void LoadBillID()
        {
            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách order
                List<order> _orders = context.orders.ToList();
                int count = _orders.Count;
                txtBillID.Text = (count+1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder; // Đặt chữ mờ làm nội dung ban đầu
            textBox.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám

            // Khi người dùng nhấn vào TextBox, xóa chữ mờ
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black; // Đổi màu chữ khi nhập liệu
                }
            };

            // Khi người dùng rời khỏi TextBox, khôi phục chữ mờ nếu không có nội dung
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám
                }
            };
        }

        private void txtFindBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtFindBox.Text.Trim();
            if (txtFindBox.ForeColor != System.Drawing.Color.Gray)
            {
                LoadData(searchText);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int selectedCategoryId))
                {
                    LoadWidgetsByCategory(selectedCategoryId);
                }
            } catch { }
        }

        private void LoadWidgetsByCategory(int categoryId)
        {
            SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True");
            string query;

            // Nếu chọn "Tất cả" (ID = 0), hiển thị tất cả menu_items
            if (categoryId == 0)
            {
                query = "SELECT menuitem_id, item_name, price, availability FROM menu_items";
            }
            else
            {
                // Hiển thị menu_items theo category_id
                query = "SELECT menuitem_id, item_name, price, availability FROM menu_items WHERE category_id = @categoryId";
            }

            try
            {
                using (SqlConnection connection = conn)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (categoryId != 0)
                    {
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    }
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    pnlMenu.SuspendLayout(); // Tạm dừng cập nhật giao diện
                    pnlMenu.Controls.Clear(); // Xóa các widget cũ nếu cần

                    while (reader.Read())
                    {
                        string id = reader["menuitem_id"].ToString();
                        string name = reader["item_name"].ToString();
                        string price = reader["price"].ToString();
                        bool availability = (bool)reader["availability"];

                        // Tạo Widget và thiết lập dữ liệu
                        Widget wdg = new Widget();
                        wdg.SetData(id, name, price, availability);
                        wdg.Click += Widget_Click;

                        pnlMenu.Controls.Add(wdg); // Thêm Widget vào Panel
                    }

                    reader.Close();
                    pnlMenu.ResumeLayout(); // Tiếp tục cập nhật giao diện
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
