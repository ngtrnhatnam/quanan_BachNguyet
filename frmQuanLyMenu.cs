using quan_an_Bach_Nguyet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace quan_an_Bach_Nguyet
{
    public partial class frmQuanLyMenu : Form
    {
        public frmQuanLyMenu()
        {
            InitializeComponent();
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

        private void FillCombobox(List<category> _category)
        {
            this.cmbCategory.DataSource = _category;
            this.cmbCategory.DisplayMember = "fod_category";
            this.cmbCategory.ValueMember = "category_id";
        }

        private void BindGrid(List<category> _category)
        {
            // Xoá hết các hàng đi (nếu có)
            dgvCategory.Rows.Clear();
            foreach (var item in _category)
            {
                int index = dgvCategory.Rows.Add();
                dgvCategory.Rows[index].Cells[0].Value = item.category_id;
                dgvCategory.Rows[index].Cells[1].Value = item.fod_category;
            }
            FillCombobox(_category);
        }

        private void BindGrid(List<menu_items> _menu_items)
        {
            // Xoá hết các hàng đi (nếu có)
            dgvMenu.Rows.Clear();
            foreach (var item in _menu_items)
            {
                int index = dgvMenu.Rows.Add();
                dgvMenu.Rows[index].Cells[0].Value = item.menuitem_id;
                dgvMenu.Rows[index].Cells[1].Value = item.category.fod_category;
                dgvMenu.Rows[index].Cells[2].Value = item.item_name;
                dgvMenu.Rows[index].Cells[3].Value = item.price;
                dgvMenu.Rows[index].Cells[4].Value = item.description;
                dgvMenu.Rows[index].Cells[5].Value = item.availability;
                dgvMenu.Rows[index].Cells[6].Value = item.category.category_id;
            }
        }

        private void frmQuanLyMenu_Load(object sender, EventArgs e)
        {
            SetPlaceholderText(txtFindCategoryName, "Theo tên phân loại...");
            SetPlaceholderText(txtFindMenuitemName, "Theo tên món...");

            try
            {
                // Đại diện cho database
                BachNguyetDBContext context = new BachNguyetDBContext();

                // Lấy danh sách 
                List<menu_items> _menu_items = context.menu_items.ToList();
                List<category> _category = context.categories.ToList();

                BindGrid(_menu_items);
                BindGrid(_category);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActiveControl = null;
            cmbCategory.SelectedIndex = -1;
        }

        private void dgvMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là cột cần định dạng
            if (dgvMenu.Columns[e.ColumnIndex].Name == "colAvailability")
            {
                if (e.Value is bool value)
                {
                    e.Value = value ? "Sẵn sàng để bán" : "Đã hết";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            txtCategory.Text = txtCategoryID.Text = "";
            int id = (dgvCategory.RowCount) + 1;
            txtCategoryID.Text = id.ToString();
            statuspnlChung(false, pnlPhanLoaiMenu);
            btnReturnCategory.Visible = btnSaveCategory.Visible =
            txtCategory.Enabled = true;
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvCategory.SelectedRows.Count > 0)
                {
                    statuspnlChung(false, pnlPhanLoaiMenu);
                    btnReturnCategory.Visible = btnSaveCategory.Visible =
                    txtCategory.Enabled = true;
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

        private void statuspnlChung(bool tf, Control name)
        {
            foreach (Control control in this.Controls)
            {
                if(control!=pnlChung)
                    control.Enabled = tf;
            }
            foreach (Control control in pnlChung.Controls)
            {
                if(control != name)
                    control.Enabled = tf;
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvCategory.Rows.Count)
                {
                    dgvCategory.Rows[e.RowIndex].Selected = true;
                    using (var context = new BachNguyetDBContext())
                    {
                        txtCategoryID.Text = dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtCategory.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvMenu.Rows.Count)
                {
                    dgvMenu.Rows[e.RowIndex].Selected = true;
                    using (var context = new BachNguyetDBContext())
                    {
                        txtID.Text = dgvMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
                        List<category> listPositions = context.categories.ToList();
                        var listCategory = listPositions.FirstOrDefault(x => x.fod_category == dgvMenu.Rows[e.RowIndex].Cells[1].Value.ToString());

                        if (listCategory != null)
                        {
                            cmbCategory.SelectedValue = listCategory.category_id;
                        }
                        else
                        {
                            cmbCategory.SelectedIndex = -1; // Bỏ chọn bất kỳ giá trị nào trong ComboBox
                        }
                        txtName.Text = dgvMenu.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtPrice.Text = dgvMenu.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtDescription.Text = dgvMenu.Rows[e.RowIndex].Cells[4].Value.ToString();
                        if ((bool)dgvMenu.Rows[e.RowIndex].Cells[5].Value == true)
                        {
                            chbAvailability.Checked = true;
                        }
                        else
                        {
                            chbAvailability.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            using (var context = new BachNguyetDBContext())
            {
                int id = int.Parse(txtCategoryID.Text);
                
                category _category = context.categories.FirstOrDefault(x => x.category_id == id);
                if (_category != null)
                {
                    _category.fod_category = txtCategory.Text;
                    context.SaveChanges();
                }
                else
                {
                    category new_category = new category
                    {
                        fod_category = txtCategory.Text,
                    };

                    // Thêm xuống vào table
                    context.categories.Add(new_category);
                    // Lưu xuống database
                    context.SaveChanges();
                }

                // Hiển thị lại trên giao diện danh sách
                List<category> _categoryList = context.categories.ToList();
                BindGrid(_categoryList);
                statuspnlChung(true, pnlPhanLoaiMenu);
                btnReturnMenu.Visible = btnSaveCategory.Visible =
                txtCategory.Enabled = txtCategoryID.Enabled = false;
            }
        }

        private void btnReturnCategory_Click(object sender, EventArgs e)
        {
            statuspnlChung(true, pnlPhanLoaiMenu);
            btnReturnCategory.Visible = btnSaveCategory.Visible =
            txtCategory.Enabled = txtCategoryID.Enabled = false;
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            txtDescription.Text = txtPrice.Text = txtFindMenuitemName.Text = txtName.Text = "";
            cmbCategory.SelectedIndex = -1;
            int id = (dgvMenu.RowCount) + 1;
            txtID.Text = id.ToString();
            statuspnlChung(false, pnlTheoMenu);
            btnReturnMenu.Visible = btnSaveMenu.Visible = chbAvailability.Checked =
            txtDescription.Enabled = txtPrice.Enabled = txtFindMenuitemName.Enabled =
            chbAvailability.Enabled = cmbCategory.Enabled = txtName.Enabled = true;
        }

        private void btnEditMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvMenu.SelectedRows.Count > 0)
                {
                    statuspnlChung(false, pnlTheoMenu);
                    btnReturnMenu.Visible = btnSaveMenu.Visible =
                    txtDescription.Enabled = txtPrice.Enabled = txtFindMenuitemName.Enabled =
                    chbAvailability.Enabled = cmbCategory.Enabled = txtName.Enabled = true;
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

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {
            using (var context = new BachNguyetDBContext())
            {
                int id = int.Parse(txtID.Text);
                int value;
                if (!int.TryParse(txtPrice.Text, out value))
                {
                    MessageBox.Show("Vui lòng nhập giá tiền hợp lệ!!!");
                    return;
                }
                if(value <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá tiền hợp lệ!!!");
                    return;
                }
                menu_items _menu_items = context.menu_items.FirstOrDefault(x => x.menuitem_id == id);
                if (_menu_items != null)
                {
                    _menu_items.item_name = txtName.Text;
                    _menu_items.category_id = int.Parse(cmbCategory.SelectedValue.ToString());
                    _menu_items.price = value;
                    _menu_items.description = txtDescription.Text;
                    _menu_items.availability = chbAvailability.Checked ? true : false;
                    context.SaveChanges();
                }
                else
                {
                    menu_items new_menu_items = new menu_items
                    {
                        item_name = txtName.Text,
                        category_id = int.Parse(cmbCategory.SelectedValue.ToString()),
                        price = value,
                        description = txtDescription.Text,
                        availability = chbAvailability.Checked ? true : false,
                    };
                    // Thêm xuống vào table
                    context.menu_items.Add(new_menu_items);
                    // Lưu xuống database
                    context.SaveChanges();
                }

                // Hiển thị lại trên giao diện danh sách
                List<menu_items> items = context.menu_items.ToList();
                BindGrid(items);
                statuspnlChung(true, pnlTheoMenu);
                btnReturnMenu.Visible = btnSaveMenu.Visible =
                txtDescription.Enabled = txtPrice.Enabled = txtFindMenuitemName.Enabled =
                chbAvailability.Enabled = cmbCategory.Enabled = txtName.Enabled = false;
            }
        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            statuspnlChung(true, pnlTheoMenu);
            btnReturnMenu.Visible = btnSaveMenu.Visible =
            txtDescription.Enabled = txtPrice.Enabled = txtFindMenuitemName.Enabled =
            chbAvailability.Enabled = cmbCategory.Enabled = txtName.Enabled = false;
        }

    }
}
