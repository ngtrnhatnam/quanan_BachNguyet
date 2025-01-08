using quan_an_Bach_Nguyet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;
using System.IO;
using System.Security.Cryptography;

namespace quan_an_Bach_Nguyet
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ptbNhanVien.Image = Image.FromFile(filePath);
                ptbNhanVien.Tag = openFileDialog.FileName;
            }
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách nhân viên
                List<employee> _employee = context.employees.ToList();
                
                BindGrid(_employee);

                txtTotal.Text = _employee.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<employee> _employee)
        {
            // Xoá hết các hàng đi (nếu có)
            dgvEmployee.Rows.Clear();
            foreach (var item in _employee)
            {
                int index = dgvEmployee.Rows.Add();
                dgvEmployee.Rows[index].Cells[0].Value = item.employee_id;
                dgvEmployee.Rows[index].Cells[1].Value = item.fullname;
                dgvEmployee.Rows[index].Cells[2].Value = item.cccd;
                dgvEmployee.Rows[index].Cells[3].Value = item.position;
                dgvEmployee.Rows[index].Cells[4].Value = item.phonenumber;
                dgvEmployee.Rows[index].Cells[5].Value = item.email;
                dgvEmployee.Rows[index].Cells[6].Value = item.hire_date;
                dgvEmployee.Rows[index].Cells[7].Value = item.salary;
                dgvEmployee.Rows[index].Cells[8].Value = item.status;
                dgvEmployee.Rows[index].Cells[9].Value = item.picture;
            }
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là cột cần định dạng
            if (dgvEmployee.Columns[e.ColumnIndex].Name == "colStatus")
            {
                if (e.Value is bool value)
                {
                    e.Value = value ? "Vẫn còn làm viêc" : "Đã nghỉ việc";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
                {
                    dgvEmployee.Rows[e.RowIndex].Selected = true;
                    using (var context = new BachNguyetDBContext())
                    {
                        txt_MaNV.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txt_TenNV.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtCCCD.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtChucVu.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txt_SDT.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txt_Email.Text = dgvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString();
                        dtpNgayVaoLam.Value = (DateTime)dgvEmployee.Rows[e.RowIndex].Cells[6].Value;
                        txtLuongCoBan.Text = dgvEmployee.Rows[e.RowIndex].Cells[7].Value.ToString();
                        if(dgvEmployee.Rows[e.RowIndex].Cells[8].Value.Equals(true))
                        {
                            rdbVanLamViec.Checked = true;
                        }
                        else if (dgvEmployee.Rows[e.RowIndex].Cells[8].Value.Equals(false))
                        {
                            rdbDaNghiViec.Checked = true;
                        }
                        byte[] imageBytes = dgvEmployee.Rows[e.RowIndex].Cells[9].Value as byte[];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            ptbNhanVien.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }

        private bool IsID(string number)
        {
            return Regex.Match(number, @"^([0-9]{12})$").Success;
        }

        private void kiemTra()
        {
            // Kiểm tra nhập thiếu thông tin
            if (string.IsNullOrEmpty(txt_TenNV.Text) || string.IsNullOrEmpty(txtCCCD.Text) ||
                string.IsNullOrEmpty(txtChucVu.Text) || string.IsNullOrEmpty(txtLuongCoBan.Text) ||
                string.IsNullOrEmpty(txt_SDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra định dạng Email nếu có
            if (!string.IsNullOrEmpty(txt_Email.Text))
            {
                if (!IsEmail(txt_Email.Text))
                {
                    MessageBox.Show("Email sai định dạng!");
                    return;
                }
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsPhoneNumber(txt_SDT.Text))
            {
                MessageBox.Show("Số điện thoại sai định dạng!");
                return;
            }

            if (!IsID(txtCCCD.Text))
            {
                MessageBox.Show("Số CCCD sai định dạng!");
                return;
            }
        }

        private void EmptyTexbox()
        {
            txtCCCD.Text = txtChucVu.Text = txtLuongCoBan.Text = txt_Email.Text =
            txt_MaNV.Text = txt_SDT.Text = txt_TenNV.Text = String.Empty;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvEmployee.SelectedRows.Count > 0)
                {
                    int id = int.Parse(txtTotal.Text);
                    btnAdd.Visible = btnEdit.Visible = dgvEmployee.Enabled = dtpNgayVaoLam.Enabled = false;
                    btnSave_Edit.Visible = btnReturn_Edit.Visible = rdbDaNghiViec.Enabled = rdbVanLamViec.Enabled = true;
                    txtCCCD.Enabled = txtChucVu.Enabled = txtLuongCoBan.Enabled = btnInsertImage.Enabled =
                    txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmptyTexbox();
            int id = int.Parse(txtTotal.Text);
            txt_MaNV.Text = (id+1).ToString();
            ptbNhanVien.Image = null;
            btnAdd.Visible =  btnEdit.Visible = grbTrangThai.Visible = dgvEmployee.Enabled = false;
            btnSave_Add.Visible = btnReturn_Add.Visible = true;
            txtCCCD.Enabled = txtChucVu.Enabled = txtLuongCoBan.Enabled = btnInsertImage.Enabled =
            txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = true;
        }

        private void btnSave_Add_Click(object sender, EventArgs e)
        {
            try
            {
                kiemTra();
                byte[] imageBytes;
                if (ptbNhanVien.Image == null || ptbNhanVien.Tag == null)
                {
                    string defaultImagePath = @"C:\Users\moder\quanan_BachNguyet\Resources\no_img.png";
                    
                    if (!File.Exists(defaultImagePath))
                    {
                        MessageBox.Show("Không tìm thấy ảnh mặc định! Vui lòng kiểm tra đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chuyển ảnh mặc định thành mảng byte
                    imageBytes = File.ReadAllBytes(defaultImagePath);
                }
                else
                {
                    // Chuyển ảnh người dùng đã chọn thành mảng byte
                    imageBytes = File.ReadAllBytes(ptbNhanVien.Tag.ToString());
                }
                using (var context = new BachNguyetDBContext())
                {

                    // Thêm nhân viên mới
                    employee _employee = new employee();
                    _employee.employee_id = int.Parse(txt_MaNV.Text);
                    _employee.fullname = txt_TenNV.Text;
                    _employee.cccd = txtCCCD.Text;
                    _employee.position = txtChucVu.Text;
                    _employee.phonenumber = txt_SDT.Text;
                    _employee.email = txt_Email.Text;
                    _employee.hire_date = DateTime.Now;
                    _employee.salary = decimal.Parse(txtLuongCoBan.Text);
                    _employee.picture = imageBytes;
                    _employee.status = true;


                    // Thêm xuống vào table
                    context.employees.Add(_employee);
                    // Lưu xuống database
                    context.SaveChanges();

                    // Hiển thị lại trên giao diện danh sách
                    List<employee> _employeeList = context.employees.ToList();
                    BindGrid(_employeeList);

                    // Hiển thị rỗng các field
                    EmptyTexbox();
                    btnAdd.Visible = btnEdit.Visible = dgvEmployee.Enabled = grbTrangThai.Visible = true;
                    btnSave_Add.Visible = btnReturn_Add.Visible = dtpNgayVaoLam.Enabled = false;
                    txtCCCD.Enabled = txtChucVu.Enabled = txtLuongCoBan.Enabled = btnInsertImage.Enabled =
                    txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = false;

                    // Hiển thị thông báo
                    MessageBox.Show("Thêm mới thành công", "Thông tin từ hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSave_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                kiemTra();
                byte[] imageBytes;
                if (ptbNhanVien.Image == null || ptbNhanVien.Tag == null)
                {
                    string defaultImagePath = @"C:\Users\moder\quanan_BachNguyet\Resources\no_img.png";

                    if (!File.Exists(defaultImagePath))
                    {
                        MessageBox.Show("Không tìm thấy ảnh mặc định! Vui lòng kiểm tra đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chuyển ảnh mặc định thành mảng byte
                    imageBytes = File.ReadAllBytes(defaultImagePath);
                }
                else
                {
                    // Chuyển ảnh người dùng đã chọn thành mảng byte
                    imageBytes = File.ReadAllBytes(ptbNhanVien.Tag.ToString());
                }
                using (var context = new BachNguyetDBContext())
                {
                    int id = int.Parse(txt_MaNV.Text);
                    employee _employeeID = context.employees.FirstOrDefault(x => x.employee_id == id);
                    _employeeID.fullname = txt_TenNV.Text;
                    _employeeID.cccd = txtCCCD.Text;
                    _employeeID.position = txtChucVu.Text;
                    _employeeID.phonenumber = txt_SDT.Text;
                    _employeeID.email = txt_Email.Text;
                    _employeeID.salary = decimal.Parse(txtLuongCoBan.Text);
                    _employeeID.picture = imageBytes;
                    if (rdbDaNghiViec.Checked)
                    {
                        _employeeID.status = false;
                    } else if (rdbVanLamViec.Checked)
                    {
                        _employeeID.status = true;
                    }

                    // Lưu xuống database
                    context.SaveChanges();

                    // Hiển thị lại trên giao diện danh sách
                    List<employee> _employeeList = context.employees.ToList();
                    BindGrid(_employeeList);

                    // Hiển thị rỗng các field
                    EmptyTexbox();
                    btnAdd.Visible = btnEdit.Visible = dgvEmployee.Enabled = true;
                    btnSave_Edit.Visible = btnReturn_Edit.Visible = dtpNgayVaoLam.Enabled = false;
                    txtCCCD.Enabled = txtChucVu.Enabled = rdbVanLamViec.Enabled = rdbDaNghiViec.Enabled = btnInsertImage.Enabled =
                    txtLuongCoBan.Enabled = txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = false;

                    // Hiển thị thông báo
                    MessageBox.Show("Sửa thông tin thành công", "Thông tin từ hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra, không thể sửa!");
            }
        }

        private void btnReturn_Add_Click(object sender, EventArgs e)
        {
            EmptyTexbox();
            btnAdd.Visible = btnEdit.Visible = dgvEmployee.Enabled = grbTrangThai.Visible = true;
            btnSave_Add.Visible = btnReturn_Add.Visible = dtpNgayVaoLam.Enabled = false;
            txtCCCD.Enabled = txtChucVu.Enabled = txtLuongCoBan.Enabled = btnInsertImage.Enabled =
            txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = false;
        }

        private void btnReturn_Edit_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = btnEdit.Visible = dgvEmployee.Enabled = true;
            btnSave_Edit.Visible = btnReturn_Edit.Visible = dtpNgayVaoLam.Enabled = false;
            txtCCCD.Enabled = txtChucVu.Enabled = rdbVanLamViec.Enabled = rdbDaNghiViec.Enabled = btnInsertImage.Enabled =
            txtLuongCoBan.Enabled = txt_Email.Enabled = txt_SDT.Enabled = txt_TenNV.Enabled = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (var context = new BachNguyetDBContext()) // Thay bằng tên DbContext của bạn
            {
                // Lọc nhân viên
                var timNhanVien = context.employees
                    .Where(ten => ten.fullname.Contains(txtFindBox.Text))
                    .ToList();

                // Hiển thị kết quả trên DataGridView
                BindGrid(timNhanVien);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách nhân viên
                List<employee> _employee = context.employees.ToList();

                BindGrid(_employee);

                txtTotal.Text = _employee.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
