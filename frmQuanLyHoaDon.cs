using quan_an_Bach_Nguyet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace quan_an_Bach_Nguyet
{
    public partial class frmQuanLyHoaDon : Form
    {
        private int basePage = 1;
        private int pageSize = 10;
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder cho TextBox
            SetPlaceholderText(txtBillID, "Theo mã hóa đơn...");
            SetPlaceholderText(txtEmployeeName, "Theo tên nhân viên...");
            
            dtpByDate.Format = DateTimePickerFormat.Custom;
            dtpByDate.CustomFormat = "dd/MM/yyyy";
            dtpByDate.MaxDate = DateTime.Today;

            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách hóa đơn
                List<bill> _bill = context.bills.ToList();

                BindGrid(_bill);

                //txtTotal.Text = _employee.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<bill> _bill)
        {
            // Xoá hết các hàng đi (nếu có)
            dgvBill.Rows.Clear();
            foreach (var item in _bill)
            {
                int index = dgvBill.Rows.Add();
                dgvBill.Rows[index].Cells[0].Value = item.bill_id;
                dgvBill.Rows[index].Cells[1].Value = item.payment_date;
                dgvBill.Rows[index].Cells[2].Value = item.total_amount;
                dgvBill.Rows[index].Cells[3].Value = item.payment_method;
                dgvBill.Rows[index].Cells[4].Value = item.order_id;
                dgvBill.Rows[index].Cells[5].Value = item.employee.fullname;
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

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvOrderDetail.Rows.Clear();
            dgvOrderDetail.Refresh();
            txtTotal.Clear();
            using (SqlConnection conn = new SqlConnection(@"Data source=MSI;initial catalog=BachNguyet;integrated security=True"))
            {
                try
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgvBill.Rows.Count)
                    {
                        var _order_id = dgvBill.Rows[e.RowIndex].Cells[4].Value;
                        txtTotal.Text = dgvBill.Rows[e.RowIndex].Cells[2].Value.ToString();
                        dgvBill.Rows[e.RowIndex].Selected = true;
                        conn.Open();
                        String querry = "SELECT order_detail_id, item_name, mi.price, quantity, subtotal FROM order_details od JOIN menu_items mi ON od.menuitem_id = mi.menuitem_id WHERE od.order_id = @order_id ";
                        using (SqlCommand cmd = new SqlCommand(querry, conn))
                        {
                            cmd.Parameters.AddWithValue("@order_id", _order_id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int _order_detail_id = reader.GetInt32(reader.GetOrdinal("order_detail_id"));
                                    string _menuitem_id = reader.GetString(reader.GetOrdinal("item_name"));
                                    decimal _price = reader.GetDecimal(reader.GetOrdinal("price"));
                                    int _quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                                    decimal _subtotal = reader.GetDecimal(reader.GetOrdinal("subtotal"));

                                    int index = dgvOrderDetail.Rows.Add();
                                    dgvOrderDetail.Rows[index].Cells[0].Value = _order_detail_id;
                                    dgvOrderDetail.Rows[index].Cells[1].Value = _menuitem_id;
                                    dgvOrderDetail.Rows[index].Cells[2].Value = _price;
                                    dgvOrderDetail.Rows[index].Cells[3].Value = _quantity;
                                    dgvOrderDetail.Rows[index].Cells[4].Value = _subtotal;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnByID_Click(object sender, EventArgs e)
        {
            var bill_id = txtBillID.Text;
            var _EmployeeName = txtEmployeeName.Text;
            if(_EmployeeName == "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
            {
                MessageBox.Show("Vui lòng nhập vào ít nhất 1 ô thông tin tìm kiếm!", "Thông báo");
                return;
            }
            else if (bill_id != "Theo mã hóa đơn..." && !ValidOrderId(txtBillID.Text))
            {
                MessageBox.Show("Số hóa đơn không hợp lệ!", "Thông báo");
                return;
            }
            try
            {
                FindWithNameOrID(_EmployeeName, bill_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FindWithNameOrID(string _EmployeeName, string bill_id)
        {
            if (_EmployeeName != "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    var timTheoTen = context.bills
                        .Where(ten => ten.employee.fullname.Contains(txtEmployeeName.Text))
                        .ToList();
                    if (timTheoTen.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timTheoTen);
                }
            }
            else if (_EmployeeName == "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
            else if (_EmployeeName != "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && id.employee.fullname.Contains(txtEmployeeName.Text))
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
        }

        private void btnByDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = dtpByDate.Value;
                FindWithDate(dateTime);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FindWithDate(DateTime dateTime)
        {
            using (var context = new BachNguyetDBContext())
            {
                var timTheoNgay = context.bills
                    .Where(id => DbFunctions.TruncateTime(id.payment_date) == dateTime.Date)
                    .ToList();
                if (timTheoNgay.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                }
                // Hiển thị kết quả trên DataGridView
                BindGrid(timTheoNgay);
            }
        }

        private void btnByMethod_Click(object sender, EventArgs e)
        {
            if (rdbCash.Checked)
            {
                FindWithMethod("Cash");
            }
            else if (rdbBank.Checked)
            {
                FindWithMethod("Bank");
            }
        }

        private void FindWithMethod(string method)
        {
            using (var context = new BachNguyetDBContext())
            {
                var timTheoNgay = context.bills
                    .Where(id => id.payment_method == method)
                    .ToList();
                if (timTheoNgay.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                }
                // Hiển thị kết quả trên DataGridView
                BindGrid(timTheoNgay);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách hóa đơn
                List<bill> _bill = context.bills.ToList();

                BindGrid(_bill);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidOrderId(string number)
        {
            return Regex.Match(number, @"^([0-9])$").Success;
        }

        private void btnMixFind_Click(object sender, EventArgs e)
        {
            int _checked = 0;
            if(ckbByID.Checked) { _checked += 2; }
            if(ckbByDate.Checked) { _checked += 3; }
            if(ckbByMethod.Checked) { _checked += 4; }
            if (_checked <= 4)
            {
                MessageBox.Show("Vui lòng chọn tối thiểu 2 chức năng để tìm kiếm kết hợp!!!", "Thông báo");
                return;
            }
            else if (_checked == 5)
            {
                var bill_id = txtBillID.Text;
                var _EmployeeName = txtEmployeeName.Text;
                DateTime dateTime = dtpByDate.Value;
                if (_EmployeeName == "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
                {
                    MessageBox.Show("Vui lòng nhập vào ít nhất 1 ô thông tin tìm kiếm!", "Thông báo");
                    return;
                }
                else if (bill_id != "Theo mã hóa đơn..." && !ValidOrderId(txtBillID.Text))
                {
                    MessageBox.Show("Số hóa đơn không hợp lệ!", "Thông báo");
                    return;
                }
                try
                {
                    Option1(_EmployeeName, bill_id, dateTime);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (_checked == 6)
            {
                var bill_id = txtBillID.Text;
                var _EmployeeName = txtEmployeeName.Text;
                if (rdbCash.Checked)
                {
                    Option2(_EmployeeName, bill_id, "Cash");
                }
                else if (rdbBank.Checked)
                {
                    Option2(_EmployeeName, bill_id, "Bank");
                }
            }
            else if (_checked == 7)
            {
                DateTime dateTime = dtpByDate.Value;
                if (rdbCash.Checked)
                {
                    Option3(dateTime, "Cash");
                }
                else if (rdbBank.Checked)
                {
                    Option3(dateTime, "Bank");
                }
            }
            else
            {
                var bill_id = txtBillID.Text;
                var _EmployeeName = txtEmployeeName.Text;
                DateTime dateTime = dtpByDate.Value;
                if (rdbCash.Checked)
                {
                    Option4(_EmployeeName, bill_id, dateTime, "Cash");
                }
                else if (rdbBank.Checked)
                {
                    Option4(_EmployeeName, bill_id, dateTime, "Bank");
                }
            }
        }

        private void Option1(string _EmployeeName, string bill_id, DateTime dateTime)
        {
            if (_EmployeeName != "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    var timTheoTen = context.bills
                        .Where(ten => ten.employee.fullname.Contains(txtEmployeeName.Text) &&
                                      DbFunctions.TruncateTime(ten.payment_date) == dateTime.Date)
                        .ToList();
                    if (timTheoTen.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timTheoTen);
                }
            }
            else if (_EmployeeName == "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && DbFunctions.TruncateTime(id.payment_date) == dateTime.Date)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
            else if (_EmployeeName != "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && id.employee.fullname.Contains(txtEmployeeName.Text) &&
                                                    DbFunctions.TruncateTime(id.payment_date) == dateTime.Date)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
        }

        private void Option2(string _EmployeeName, string bill_id, string method)
        {
            if (_EmployeeName != "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    var timTheoTen = context.bills
                        .Where(ten => ten.employee.fullname.Contains(txtEmployeeName.Text) &&
                                      ten.payment_method == method)
                        .ToList();
                    if (timTheoTen.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timTheoTen);
                }
            }
            else if (_EmployeeName == "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && id.payment_method == method)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
            else if (_EmployeeName != "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && id.employee.fullname.Contains(txtEmployeeName.Text) &&
                                                    id.payment_method == method)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
        }

        private void Option3(DateTime dateTime, string method)
        {
            using (var context = new BachNguyetDBContext())
            {
                var timTheoNgay = context.bills
                    .Where(id => DbFunctions.TruncateTime(id.payment_date) == dateTime.Date && id.payment_method == method)
                    .ToList();
                if (timTheoNgay.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                }
                // Hiển thị kết quả trên DataGridView
                BindGrid(timTheoNgay);
            }
        }

        private void Option4(string _EmployeeName, string bill_id, DateTime dateTime, string method)
        {
            if (_EmployeeName != "Theo tên nhân viên..." && bill_id == "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    var timTheoTen = context.bills
                        .Where(ten => ten.employee.fullname.Contains(txtEmployeeName.Text) &&
                                      DbFunctions.TruncateTime(ten.payment_date) == dateTime.Date && ten.payment_method == method)
                        .ToList();
                    if (timTheoTen.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timTheoTen);
                }
            }
            else if (_EmployeeName == "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && DbFunctions.TruncateTime(id.payment_date) == dateTime.Date && id.payment_method == method)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
            else if (_EmployeeName != "Theo tên nhân viên..." && bill_id != "Theo mã hóa đơn...")
            {
                using (var context = new BachNguyetDBContext())
                {
                    int _bill_id = int.Parse(bill_id);
                    var timHoaDon = context.bills
                        .Where(id => id.order_id == _bill_id && id.employee.fullname.Contains(txtEmployeeName.Text) &&
                                                    DbFunctions.TruncateTime(id.payment_date) == dateTime.Date && id.payment_method == method)
                        .ToList();
                    if (timHoaDon.Count == 0)
                    {
                        MessageBox.Show("Không có hóa đơn cần tìm!", "Thông báo");
                    }
                    // Hiển thị kết quả trên DataGridView
                    BindGrid(timHoaDon);
                }
            }
        }
    }
}