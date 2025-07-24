namespace PolyGear_GUI_SOF
{
    partial class Employees
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
            dgvEmployee = new DataGridView();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            label7 = new Label();
            label9 = new Label();
            rdoHoatDong = new RadioButton();
            rdoNghiViec = new RadioButton();
            tabDanhSach = new TabPage();
            dateTimePicker1 = new DateTimePicker();
            label11 = new Label();
            txtDiaChi = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            panelVaiTro = new Panel();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtEmail = new TextBox();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            txtMaNhanVien = new TextBox();
            label8 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            txtMaTaiKhoan = new TextBox();
            label1 = new Label();
            label6 = new Label();
            tabConTrol = new TabControl();
            TabCapNhat = new TabPage();
            dgvAccount = new DataGridView();
            groupBox2 = new GroupBox();
            pictureBox1 = new PictureBox();
            btnHien = new Button();
            btnAn = new Button();
            label14 = new Label();
            cboVaiTro = new ComboBox();
            txtPassword = new TextBox();
            label13 = new Label();
            txtUsername = new TextBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            tabDanhSach.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            panelVaiTro.SuspendLayout();
            tabConTrol.SuspendLayout();
            TabCapNhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployee
            // 
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Location = new Point(3, 3);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 62;
            dgvEmployee.Size = new Size(1464, 695);
            dgvEmployee.TabIndex = 0;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(318, 8);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(64, 32);
            rdoNu.TabIndex = 45;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(163, 8);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(79, 32);
            rdoNam.TabIndex = 44;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(3, 5);
            label7.Name = "label7";
            label7.Size = new Size(87, 28);
            label7.TabIndex = 54;
            label7.Text = "Giới tính";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(3, 3);
            label9.Name = "label9";
            label9.Size = new Size(105, 28);
            label9.TabIndex = 59;
            label9.Text = "Trạng Thái:";
            // 
            // rdoHoatDong
            // 
            rdoHoatDong.AutoSize = true;
            rdoHoatDong.Location = new Point(164, 6);
            rdoHoatDong.Name = "rdoHoatDong";
            rdoHoatDong.Size = new Size(132, 32);
            rdoHoatDong.TabIndex = 60;
            rdoHoatDong.TabStop = true;
            rdoHoatDong.Text = "Hoạt động";
            rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // rdoNghiViec
            // 
            rdoNghiViec.AutoSize = true;
            rdoNghiViec.Location = new Point(318, 6);
            rdoNghiViec.Name = "rdoNghiViec";
            rdoNghiViec.Size = new Size(119, 32);
            rdoNghiViec.TabIndex = 61;
            rdoNghiViec.TabStop = true;
            rdoNghiViec.Text = "Nghỉ việc";
            rdoNghiViec.UseVisualStyleBackColor = true;
            // 
            // tabDanhSach
            // 
            tabDanhSach.Controls.Add(dgvEmployee);
            tabDanhSach.Location = new Point(4, 39);
            tabDanhSach.Name = "tabDanhSach";
            tabDanhSach.Padding = new Padding(3);
            tabDanhSach.Size = new Size(1470, 701);
            tabDanhSach.TabIndex = 1;
            tabDanhSach.Text = "DANH SÁCH";
            tabDanhSach.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 10F);
            dateTimePicker1.Location = new Point(171, 299);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(299, 34);
            dateTimePicker1.TabIndex = 108;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(8, 299);
            label11.Name = "label11";
            label11.Size = new Size(99, 28);
            label11.TabIndex = 107;
            label11.Text = "Ngày sinh";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(171, 237);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(298, 34);
            txtDiaChi.TabIndex = 106;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.Location = new Point(8, 237);
            label10.Name = "label10";
            label10.Size = new Size(71, 28);
            label10.TabIndex = 105;
            label10.Text = "Địa chỉ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(panelVaiTro);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtMaNhanVien);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(909, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(524, 597);
            groupBox1.TabIndex = 53;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhân viên";
            // 
            // panel2
            // 
            panel2.Controls.Add(label9);
            panel2.Controls.Add(rdoHoatDong);
            panel2.Controls.Add(rdoNghiViec);
            panel2.Font = new Font("Segoe UI", 10F);
            panel2.Location = new Point(8, 444);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 40);
            panel2.TabIndex = 104;
            // 
            // panelVaiTro
            // 
            panelVaiTro.Controls.Add(rdoNu);
            panelVaiTro.Controls.Add(rdoNam);
            panelVaiTro.Controls.Add(label7);
            panelVaiTro.Font = new Font("Segoe UI", 10F);
            panelVaiTro.Location = new Point(8, 365);
            panelVaiTro.Name = "panelVaiTro";
            panelVaiTro.Size = new Size(462, 48);
            panelVaiTro.TabIndex = 103;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Lime;
            btnLamMoi.Font = new Font("Microsoft Sans Serif", 9F);
            btnLamMoi.Location = new Point(365, 512);
            btnLamMoi.Margin = new Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(104, 51);
            btnLamMoi.TabIndex = 102;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.SandyBrown;
            btnXoa.Font = new Font("Microsoft Sans Serif", 9F);
            btnXoa.Location = new Point(253, 512);
            btnXoa.Margin = new Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(104, 51);
            btnXoa.TabIndex = 101;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LightCoral;
            btnSua.Font = new Font("Microsoft Sans Serif", 9F);
            btnSua.Location = new Point(141, 512);
            btnSua.Margin = new Padding(4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(104, 51);
            btnSua.TabIndex = 100;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Turquoise;
            btnThem.Font = new Font("Microsoft Sans Serif", 9F);
            btnThem.Location = new Point(29, 512);
            btnThem.Margin = new Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(104, 51);
            btnThem.TabIndex = 99;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(171, 136);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(298, 34);
            txtEmail.TabIndex = 97;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.Location = new Point(172, 190);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(298, 34);
            txtSDT.TabIndex = 96;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(172, 95);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(298, 34);
            txtHoTen.TabIndex = 95;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Font = new Font("Segoe UI", 10F);
            txtMaNhanVien.Location = new Point(172, 44);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.ReadOnly = true;
            txtMaNhanVien.Size = new Size(298, 34);
            txtMaNhanVien.TabIndex = 91;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(8, 191);
            label8.Name = "label8";
            label8.Size = new Size(47, 28);
            label8.TabIndex = 98;
            label8.Text = "SĐT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(8, 95);
            label4.Name = "label4";
            label4.Size = new Size(98, 28);
            label4.TabIndex = 94;
            label4.Text = "Họ Và Tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(8, 136);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 93;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(8, 44);
            label2.Name = "label2";
            label2.Size = new Size(135, 28);
            label2.TabIndex = 92;
            label2.Text = "Mã Nhân Viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(81, 380);
            label5.Name = "label5";
            label5.Size = new Size(17, 28);
            label5.TabIndex = 74;
            label5.Text = " ";
            // 
            // txtMaTaiKhoan
            // 
            txtMaTaiKhoan.Font = new Font("Microsoft Sans Serif", 10F);
            txtMaTaiKhoan.Location = new Point(355, 49);
            txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            txtMaTaiKhoan.ReadOnly = true;
            txtMaTaiKhoan.Size = new Size(318, 30);
            txtMaTaiKhoan.TabIndex = 86;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(621, 6);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(299, 65);
            label1.TabIndex = 52;
            label1.Text = "NHÂN VIÊN";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label6.Location = new Point(31, 49);
            label6.Name = "label6";
            label6.Size = new Size(138, 30);
            label6.TabIndex = 75;
            label6.Text = "Mã tài khoản";
            // 
            // tabConTrol
            // 
            tabConTrol.Controls.Add(TabCapNhat);
            tabConTrol.Controls.Add(tabDanhSach);
            tabConTrol.Dock = DockStyle.Fill;
            tabConTrol.Font = new Font("Segoe UI", 11F);
            tabConTrol.Location = new Point(0, 0);
            tabConTrol.Name = "tabConTrol";
            tabConTrol.SelectedIndex = 0;
            tabConTrol.Size = new Size(1478, 744);
            tabConTrol.TabIndex = 2;
            // 
            // TabCapNhat
            // 
            TabCapNhat.Controls.Add(dgvAccount);
            TabCapNhat.Controls.Add(groupBox2);
            TabCapNhat.Controls.Add(groupBox1);
            TabCapNhat.Controls.Add(label1);
            TabCapNhat.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            TabCapNhat.Location = new Point(4, 39);
            TabCapNhat.Name = "TabCapNhat";
            TabCapNhat.Padding = new Padding(3);
            TabCapNhat.Size = new Size(1470, 701);
            TabCapNhat.TabIndex = 0;
            TabCapNhat.Text = "CẬP NHẬT";
            TabCapNhat.UseVisualStyleBackColor = true;
            // 
            // dgvAccount
            // 
            dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccount.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccount.Location = new Point(56, 393);
            dgvAccount.Name = "dgvAccount";
            dgvAccount.RowHeadersWidth = 62;
            dgvAccount.Size = new Size(836, 300);
            dgvAccount.TabIndex = 88;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(btnHien);
            groupBox2.Controls.Add(btnAn);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(cboVaiTro);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(txtUsername);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMaTaiKhoan);
            groupBox2.Location = new Point(56, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(822, 306);
            groupBox2.TabIndex = 87;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tài khoản";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(690, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(68, 30);
            pictureBox1.TabIndex = 95;
            pictureBox1.TabStop = false;
            // 
            // btnHien
            // 
            btnHien.Location = new Point(690, 180);
            btnHien.Name = "btnHien";
            btnHien.Size = new Size(68, 34);
            btnHien.TabIndex = 94;
            btnHien.Text = "Hiện";
            btnHien.UseVisualStyleBackColor = true;
            // 
            // btnAn
            // 
            btnAn.Location = new Point(616, 182);
            btnAn.Name = "btnAn";
            btnAn.Size = new Size(68, 34);
            btnAn.TabIndex = 93;
            btnAn.Text = "Ẩn";
            btnAn.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label14.Location = new Point(31, 246);
            label14.Name = "label14";
            label14.Size = new Size(78, 30);
            label14.TabIndex = 92;
            label14.Text = "Vai Trò";
            // 
            // cboVaiTro
            // 
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(357, 243);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(316, 38);
            cboVaiTro.TabIndex = 91;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 10F);
            txtPassword.Location = new Point(355, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(318, 30);
            txtPassword.TabIndex = 90;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label13.Location = new Point(31, 182);
            label13.Name = "label13";
            label13.Size = new Size(103, 30);
            label13.TabIndex = 89;
            label13.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 10F);
            txtUsername.Location = new Point(355, 121);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(318, 30);
            txtUsername.TabIndex = 88;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label12.Location = new Point(31, 120);
            label12.Name = "label12";
            label12.Size = new Size(156, 30);
            label12.TabIndex = 87;
            label12.Text = "Tên đăng nhập";
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1478, 744);
            Controls.Add(tabConTrol);
            Name = "Employees";
            Text = "Employees";
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            tabDanhSach.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelVaiTro.ResumeLayout(false);
            panelVaiTro.PerformLayout();
            tabConTrol.ResumeLayout(false);
            TabCapNhat.ResumeLayout(false);
            TabCapNhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmployee;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Label label7;
        private Label label9;
        private RadioButton rdoHoatDong;
        private RadioButton rdoNghiViec;
        private TabPage tabDanhSach;
        private DateTimePicker dateTimePicker1;
        private Label label11;
        private TextBox txtDiaChi;
        private Label label10;
        private GroupBox groupBox1;
        private Panel panel2;
        private Panel panelVaiTro;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtHoTen;
        private TextBox txtMaNhanVien;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private TextBox txtMaTaiKhoan;
        private Label label1;
        private Label label6;
        private TabControl tabConTrol;
        private TabPage TabCapNhat;
        private DataGridView dgvAccount;
        private GroupBox groupBox2;
        private PictureBox pictureBox1;
        private Button btnHien;
        private Button btnAn;
        private Label label14;
        private ComboBox cboVaiTro;
        private TextBox txtPassword;
        private Label label13;
        private TextBox txtUsername;
        private Label label12;
    }
}