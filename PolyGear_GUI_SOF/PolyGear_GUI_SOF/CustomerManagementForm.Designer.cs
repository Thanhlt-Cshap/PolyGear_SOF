namespace PolyGear_GUI_SOF
{
    partial class CustomerManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerManagementForm));
            pictureBox1 = new PictureBox();
            txtTimKiem = new TextBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvKhachHang = new DataGridView();
            dtpNgayDangKy = new DateTimePicker();
            chkHoatDong = new CheckBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtSoDienThoai = new TextBox();
            txtHoTen = new TextBox();
            txtMaKhachHang = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1219, 253);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 43;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(880, 253);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(338, 41);
            txtTimKiem.TabIndex = 42;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamMoi.Location = new Point(617, 253);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 41);
            btnLamMoi.TabIndex = 41;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.Location = new Point(456, 253);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 41);
            btnXoa.TabIndex = 40;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.Location = new Point(264, 253);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 41);
            btnSua.TabIndex = 39;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThem.Location = new Point(91, 253);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 41);
            btnThem.TabIndex = 38;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(12, 326);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1308, 365);
            dgvKhachHang.TabIndex = 37;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            // 
            // dtpNgayDangKy
            // 
            dtpNgayDangKy.Font = new Font("Segoe UI", 13F);
            dtpNgayDangKy.Format = DateTimePickerFormat.Short;
            dtpNgayDangKy.Location = new Point(1045, 64);
            dtpNgayDangKy.Name = "dtpNgayDangKy";
            dtpNgayDangKy.Size = new Size(139, 36);
            dtpNgayDangKy.TabIndex = 36;
            dtpNgayDangKy.ValueChanged += dtpNgayDangKy_ValueChanged;
            // 
            // chkHoatDong
            // 
            chkHoatDong.AutoSize = true;
            chkHoatDong.Font = new Font("Segoe UI", 13F);
            chkHoatDong.Location = new Point(1045, 108);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(139, 34);
            chkHoatDong.TabIndex = 35;
            chkHoatDong.Text = "Hoạt động";
            chkHoatDong.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.Location = new Point(880, 188);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(359, 41);
            txtEmail.TabIndex = 34;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10.8F);
            txtDiaChi.Location = new Point(456, 188);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(359, 41);
            txtDiaChi.TabIndex = 33;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 10.8F);
            txtSoDienThoai.Location = new Point(456, 95);
            txtSoDienThoai.Multiline = true;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(359, 41);
            txtSoDienThoai.TabIndex = 32;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10.8F);
            txtHoTen.Location = new Point(55, 188);
            txtHoTen.Multiline = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(359, 41);
            txtHoTen.TabIndex = 31;
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Font = new Font("Segoe UI", 10.8F);
            txtMaKhachHang.Location = new Point(55, 95);
            txtMaKhachHang.Multiline = true;
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.Size = new Size(359, 41);
            txtMaKhachHang.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(873, 108);
            label8.Name = "label8";
            label8.Size = new Size(127, 31);
            label8.TabIndex = 29;
            label8.Text = "Trạng thái: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(873, 61);
            label7.Name = "label7";
            label7.Size = new Size(166, 31);
            label7.TabIndex = 28;
            label7.Text = "Ngày đăng ký: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(456, 154);
            label6.Name = "label6";
            label6.Size = new Size(95, 31);
            label6.TabIndex = 27;
            label6.Text = "Địa chỉ: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(873, 154);
            label5.Name = "label5";
            label5.Size = new Size(81, 31);
            label5.TabIndex = 26;
            label5.Text = "Email: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(456, 61);
            label4.Name = "label4";
            label4.Size = new Size(159, 31);
            label4.TabIndex = 25;
            label4.Text = "Số điện thoại: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(55, 154);
            label3.Name = "label3";
            label3.Size = new Size(93, 31);
            label3.TabIndex = 24;
            label3.Text = "Họ tên: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 61);
            label2.Name = "label2";
            label2.Size = new Size(182, 31);
            label2.TabIndex = 23;
            label2.Text = "Mã khách hàng: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.8F, FontStyle.Bold);
            label1.Location = new Point(515, -2);
            label1.Name = "label1";
            label1.Size = new Size(332, 47);
            label1.TabIndex = 22;
            label1.Text = "Quản lý khách hàng";
            // 
            // CustomerManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvKhachHang);
            Controls.Add(dtpNgayDangKy);
            Controls.Add(chkHoatDong);
            Controls.Add(txtEmail);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaKhachHang);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CustomerManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerManagementForm";
            Load += CustomerManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtTimKiem;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvKhachHang;
        private DateTimePicker dtpNgayDangKy;
        private CheckBox chkHoatDong;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtSoDienThoai;
        private TextBox txtHoTen;
        private TextBox txtMaKhachHang;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}