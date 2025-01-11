namespace quan_an_Bach_Nguyet
{
    partial class frmQuanLyNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInsertImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFindBox = new System.Windows.Forms.TextBox();
            this.pnlInfomatin = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.ptbNhanVien = new System.Windows.Forms.PictureBox();
            this.grbTrangThai = new System.Windows.Forms.GroupBox();
            this.rdbVanLamViec = new System.Windows.Forms.RadioButton();
            this.rdbDaNghiViec = new System.Windows.Forms.RadioButton();
            this.txtLuongCoBan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TenNV = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReturn_Edit = new System.Windows.Forms.Button();
            this.btnSave_Edit = new System.Windows.Forms.Button();
            this.btnReturn_Add = new System.Windows.Forms.Button();
            this.btnSave_Add = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.colEmployee_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCCCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlInfomatin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNhanVien)).BeginInit();
            this.grbTrangThai.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Enabled = false;
            this.btnInsertImage.Location = new System.Drawing.Point(40, 274);
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(180, 40);
            this.btnInsertImage.TabIndex = 1;
            this.btnInsertImage.Text = "Thêm ảnh";
            this.btnInsertImage.UseVisualStyleBackColor = true;
            this.btnInsertImage.Click += new System.EventHandler(this.btnInsertImage_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.pnlInfomatin);
            this.panel1.Controls.Add(this.pnlFind);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(93, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1846, 385);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnShowAll);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Location = new System.Drawing.Point(1411, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 103);
            this.panel2.TabIndex = 78;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnShowAll.Location = new System.Drawing.Point(18, 50);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(390, 36);
            this.btnShowAll.TabIndex = 45;
            this.btnShowAll.Text = "Hiển thị danh sách toàn bộ nhân viên";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTotal.Location = new System.Drawing.Point(271, 10);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(52, 23);
            this.txtTotal.TabIndex = 86;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotal.Location = new System.Drawing.Point(9, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(270, 22);
            this.lblTotal.TabIndex = 85;
            this.lblTotal.Text = "Tổng số nhân viên còn làm việc: ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.txtFindBox);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(1411, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 101);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm theo tên người dùng";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(300, 48);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(119, 31);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFindBox
            // 
            this.txtFindBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindBox.Location = new System.Drawing.Point(18, 49);
            this.txtFindBox.Name = "txtFindBox";
            this.txtFindBox.Size = new System.Drawing.Size(261, 30);
            this.txtFindBox.TabIndex = 0;
            // 
            // pnlInfomatin
            // 
            this.pnlInfomatin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlInfomatin.Controls.Add(this.label10);
            this.pnlInfomatin.Controls.Add(this.txtCCCD);
            this.pnlInfomatin.Controls.Add(this.txtChucVu);
            this.pnlInfomatin.Controls.Add(this.ptbNhanVien);
            this.pnlInfomatin.Controls.Add(this.btnInsertImage);
            this.pnlInfomatin.Controls.Add(this.grbTrangThai);
            this.pnlInfomatin.Controls.Add(this.txtLuongCoBan);
            this.pnlInfomatin.Controls.Add(this.label7);
            this.pnlInfomatin.Controls.Add(this.txt_MaNV);
            this.pnlInfomatin.Controls.Add(this.dtpNgayVaoLam);
            this.pnlInfomatin.Controls.Add(this.label2);
            this.pnlInfomatin.Controls.Add(this.label4);
            this.pnlInfomatin.Controls.Add(this.label3);
            this.pnlInfomatin.Controls.Add(this.label6);
            this.pnlInfomatin.Controls.Add(this.txt_TenNV);
            this.pnlInfomatin.Controls.Add(this.txt_SDT);
            this.pnlInfomatin.Controls.Add(this.label1);
            this.pnlInfomatin.Controls.Add(this.label5);
            this.pnlInfomatin.Controls.Add(this.txt_Email);
            this.pnlInfomatin.Location = new System.Drawing.Point(3, 10);
            this.pnlInfomatin.Name = "pnlInfomatin";
            this.pnlInfomatin.Size = new System.Drawing.Size(1386, 368);
            this.pnlInfomatin.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(320, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 22);
            this.label10.TabIndex = 86;
            this.label10.Text = "Số CCCD";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Enabled = false;
            this.txtCCCD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCCCD.Location = new System.Drawing.Point(431, 147);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(303, 30);
            this.txtCCCD.TabIndex = 87;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Enabled = false;
            this.txtChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtChucVu.Location = new System.Drawing.Point(431, 211);
            this.txtChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(303, 30);
            this.txtChucVu.TabIndex = 85;
            // 
            // ptbNhanVien
            // 
            this.ptbNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbNhanVien.Location = new System.Drawing.Point(40, 13);
            this.ptbNhanVien.Name = "ptbNhanVien";
            this.ptbNhanVien.Size = new System.Drawing.Size(180, 240);
            this.ptbNhanVien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbNhanVien.TabIndex = 0;
            this.ptbNhanVien.TabStop = false;
            // 
            // grbTrangThai
            // 
            this.grbTrangThai.Controls.Add(this.rdbVanLamViec);
            this.grbTrangThai.Controls.Add(this.rdbDaNghiViec);
            this.grbTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbTrangThai.Location = new System.Drawing.Point(838, 255);
            this.grbTrangThai.Name = "grbTrangThai";
            this.grbTrangThai.Size = new System.Drawing.Size(457, 102);
            this.grbTrangThai.TabIndex = 80;
            this.grbTrangThai.TabStop = false;
            this.grbTrangThai.Text = "Trạng thái làm việc";
            // 
            // rdbVanLamViec
            // 
            this.rdbVanLamViec.AutoSize = true;
            this.rdbVanLamViec.Enabled = false;
            this.rdbVanLamViec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbVanLamViec.Location = new System.Drawing.Point(68, 37);
            this.rdbVanLamViec.Name = "rdbVanLamViec";
            this.rdbVanLamViec.Size = new System.Drawing.Size(145, 26);
            this.rdbVanLamViec.TabIndex = 78;
            this.rdbVanLamViec.Text = "Đang làm việc";
            this.rdbVanLamViec.UseVisualStyleBackColor = true;
            // 
            // rdbDaNghiViec
            // 
            this.rdbDaNghiViec.AutoSize = true;
            this.rdbDaNghiViec.Enabled = false;
            this.rdbDaNghiViec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbDaNghiViec.Location = new System.Drawing.Point(273, 37);
            this.rdbDaNghiViec.Name = "rdbDaNghiViec";
            this.rdbDaNghiViec.Size = new System.Drawing.Size(131, 26);
            this.rdbDaNghiViec.TabIndex = 79;
            this.rdbDaNghiViec.Text = "Đã nghỉ việc";
            this.rdbDaNghiViec.UseVisualStyleBackColor = true;
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Enabled = false;
            this.txtLuongCoBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtLuongCoBan.Location = new System.Drawing.Point(431, 290);
            this.txtLuongCoBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.Size = new System.Drawing.Size(303, 30);
            this.txtLuongCoBan.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(253, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 22);
            this.label7.TabIndex = 75;
            this.label7.Text = "Mức lương cơ bản";
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Enabled = false;
            this.txt_MaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaNV.Location = new System.Drawing.Point(431, 13);
            this.txt_MaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(303, 30);
            this.txt_MaNV.TabIndex = 65;
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Enabled = false;
            this.dtpNgayVaoLam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(959, 194);
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(336, 30);
            this.dtpNgayVaoLam.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(341, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Mã NV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(834, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 22);
            this.label4.TabIndex = 72;
            this.label4.Text = "Ngày vào làm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(337, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 62;
            this.label3.Text = "Tên NV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(892, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 22);
            this.label6.TabIndex = 68;
            this.label6.Text = "Email";
            // 
            // txt_TenNV
            // 
            this.txt_TenNV.Enabled = false;
            this.txt_TenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TenNV.Location = new System.Drawing.Point(431, 78);
            this.txt_TenNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_TenNV.Name = "txt_TenNV";
            this.txt_TenNV.Size = new System.Drawing.Size(303, 30);
            this.txt_TenNV.TabIndex = 64;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Enabled = false;
            this.txt_SDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SDT.Location = new System.Drawing.Point(955, 13);
            this.txt_SDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(336, 30);
            this.txt_SDT.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(333, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 66;
            this.label1.Text = "Chức vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(902, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 22);
            this.label5.TabIndex = 69;
            this.label5.Text = "SĐT";
            // 
            // txt_Email
            // 
            this.txt_Email.Enabled = false;
            this.txt_Email.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_Email.Location = new System.Drawing.Point(955, 102);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(336, 30);
            this.txt_Email.TabIndex = 71;
            // 
            // pnlFind
            // 
            this.pnlFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFind.Location = new System.Drawing.Point(1411, 137);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(425, 100);
            this.pnlFind.TabIndex = 77;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.btnReturn_Edit);
            this.groupBox3.Controls.Add(this.btnSave_Edit);
            this.groupBox3.Controls.Add(this.btnReturn_Add);
            this.groupBox3.Controls.Add(this.btnSave_Add);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(1410, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 106);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnReturn_Edit
            // 
            this.btnReturn_Edit.Location = new System.Drawing.Point(251, 49);
            this.btnReturn_Edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReturn_Edit.Name = "btnReturn_Edit";
            this.btnReturn_Edit.Size = new System.Drawing.Size(107, 31);
            this.btnReturn_Edit.TabIndex = 44;
            this.btnReturn_Edit.Text = "Quay lại";
            this.btnReturn_Edit.UseVisualStyleBackColor = true;
            this.btnReturn_Edit.Visible = false;
            this.btnReturn_Edit.Click += new System.EventHandler(this.btnReturn_Edit_Click);
            // 
            // btnSave_Edit
            // 
            this.btnSave_Edit.Location = new System.Drawing.Point(72, 49);
            this.btnSave_Edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave_Edit.Name = "btnSave_Edit";
            this.btnSave_Edit.Size = new System.Drawing.Size(107, 31);
            this.btnSave_Edit.TabIndex = 43;
            this.btnSave_Edit.Text = "Lưu";
            this.btnSave_Edit.UseVisualStyleBackColor = true;
            this.btnSave_Edit.Visible = false;
            this.btnSave_Edit.Click += new System.EventHandler(this.btnSave_Edit_Click);
            // 
            // btnReturn_Add
            // 
            this.btnReturn_Add.Location = new System.Drawing.Point(251, 49);
            this.btnReturn_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReturn_Add.Name = "btnReturn_Add";
            this.btnReturn_Add.Size = new System.Drawing.Size(107, 31);
            this.btnReturn_Add.TabIndex = 42;
            this.btnReturn_Add.Text = "Quay lại";
            this.btnReturn_Add.UseVisualStyleBackColor = true;
            this.btnReturn_Add.Visible = false;
            this.btnReturn_Add.Click += new System.EventHandler(this.btnReturn_Add_Click);
            // 
            // btnSave_Add
            // 
            this.btnSave_Add.Location = new System.Drawing.Point(72, 49);
            this.btnSave_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave_Add.Name = "btnSave_Add";
            this.btnSave_Add.Size = new System.Drawing.Size(107, 31);
            this.btnSave_Add.TabIndex = 41;
            this.btnSave_Add.Text = "Lưu";
            this.btnSave_Add.UseVisualStyleBackColor = true;
            this.btnSave_Add.Visible = false;
            this.btnSave_Add.Click += new System.EventHandler(this.btnSave_Add_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(251, 49);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 31);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(72, 49);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 31);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToResizeColumns = false;
            this.dgvEmployee.AllowUserToResizeRows = false;
            this.dgvEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvEmployee.ColumnHeadersHeight = 29;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployee_id,
            this.colFullNam,
            this.colCCCD,
            this.colPosition,
            this.colPhoneNumber,
            this.colEmail,
            this.colHiredDate,
            this.colSalary,
            this.colStatus,
            this.colPicture});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployee.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployee.Location = new System.Drawing.Point(93, 393);
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.RowHeadersVisible = false;
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.Height = 35;
            this.dgvEmployee.Size = new System.Drawing.Size(1846, 419);
            this.dgvEmployee.TabIndex = 3;
            this.dgvEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            this.dgvEmployee.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmployee_CellFormatting);
            // 
            // colEmployee_id
            // 
            this.colEmployee_id.FillWeight = 40F;
            this.colEmployee_id.HeaderText = "Mã NV";
            this.colEmployee_id.MinimumWidth = 6;
            this.colEmployee_id.Name = "colEmployee_id";
            this.colEmployee_id.ReadOnly = true;
            // 
            // colFullNam
            // 
            this.colFullNam.HeaderText = "Họ và tên";
            this.colFullNam.MinimumWidth = 6;
            this.colFullNam.Name = "colFullNam";
            this.colFullNam.ReadOnly = true;
            // 
            // colCCCD
            // 
            this.colCCCD.HeaderText = "CCCD";
            this.colCCCD.MinimumWidth = 6;
            this.colCCCD.Name = "colCCCD";
            this.colCCCD.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.FillWeight = 60F;
            this.colPosition.HeaderText = "Vị trí";
            this.colPosition.MinimumWidth = 6;
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.HeaderText = "Số điện thoại";
            this.colPhoneNumber.MinimumWidth = 6;
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Địa chỉ email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colHiredDate
            // 
            this.colHiredDate.HeaderText = "Ngày bắt đầu làm việc";
            this.colHiredDate.MinimumWidth = 6;
            this.colHiredDate.Name = "colHiredDate";
            this.colHiredDate.ReadOnly = true;
            // 
            // colSalary
            // 
            this.colSalary.FillWeight = 60F;
            this.colSalary.HeaderText = "Mức lương cơ bản";
            this.colSalary.MinimumWidth = 6;
            this.colSalary.Name = "colSalary";
            this.colSalary.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Trạng thái làm việc";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colPicture
            // 
            this.colPicture.HeaderText = "Ảnh";
            this.colPicture.MinimumWidth = 6;
            this.colPicture.Name = "colPicture";
            this.colPicture.ReadOnly = true;
            this.colPicture.Visible = false;
            // 
            // frmQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1942, 824);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "=";
            this.Load += new System.EventHandler(this.frmQuanLyNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlInfomatin.ResumeLayout(false);
            this.pnlInfomatin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNhanVien)).EndInit();
            this.grbTrangThai.ResumeLayout(false);
            this.grbTrangThai.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbNhanVien;
        private System.Windows.Forms.Button btnInsertImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlInfomatin;
        private System.Windows.Forms.GroupBox grbTrangThai;
        private System.Windows.Forms.RadioButton rdbVanLamViec;
        private System.Windows.Forms.RadioButton rdbDaNghiViec;
        private System.Windows.Forms.TextBox txtLuongCoBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFindBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Button btnReturn_Add;
        private System.Windows.Forms.Button btnSave_Add;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnReturn_Edit;
        private System.Windows.Forms.Button btnSave_Edit;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHiredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPicture;
    }
}