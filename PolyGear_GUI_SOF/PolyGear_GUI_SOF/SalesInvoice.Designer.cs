namespace PolyGear_GUI_SOF
{
    partial class SalesInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInvoice));
            groupBox1 = new GroupBox();
            rdoDaThanhToan = new RadioButton();
            rdoChoXacNhan = new RadioButton();
            dtpNgayTao = new DateTimePicker();
            cboMaThe = new ComboBox();
            cboMaNhanVien = new ComboBox();
            txtMaPhieu = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            cboMaSanPham = new ComboBox();
            txtThanhTien = new TextBox();
            txtSoLuong = new TextBox();
            txtDonGia = new TextBox();
            label10 = new Label();
            label2 = new Label();
            dgvChiTietPhieu = new DataGridView();
            label9 = new Label();
            label8 = new Label();
            tabChiTietPhieu = new TabPage();
            btnXoaChiTiet = new Button();
            btnSuaChiTiet = new Button();
            btnThemChiTiet = new Button();
            btnThanhToan = new Button();
            btnLamMoi = new Button();
            btnXoaPhieu = new Button();
            btnSuaPhieu = new Button();
            btnThemPhieu = new Button();
            dgvDSPhieuBanhang = new DataGridView();
            groupBox2 = new GroupBox();
            label7 = new Label();
            tabPhieuBanHang = new TabPage();
            tabDSPhieuBanHang = new TabControl();
            btnXuatHoaDon = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).BeginInit();
            tabChiTietPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSPhieuBanhang).BeginInit();
            groupBox2.SuspendLayout();
            tabPhieuBanHang.SuspendLayout();
            tabDSPhieuBanHang.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(rdoDaThanhToan);
            groupBox1.Controls.Add(rdoChoXacNhan);
            groupBox1.Controls.Add(dtpNgayTao);
            groupBox1.Controls.Add(cboMaThe);
            groupBox1.Controls.Add(cboMaNhanVien);
            groupBox1.Controls.Add(txtMaPhieu);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(60, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(728, 204);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu";
            // 
            // rdoDaThanhToan
            // 
            rdoDaThanhToan.AutoSize = true;
            rdoDaThanhToan.Font = new Font("Segoe UI", 10F);
            rdoDaThanhToan.Location = new Point(314, 151);
            rdoDaThanhToan.Name = "rdoDaThanhToan";
            rdoDaThanhToan.Size = new Size(142, 27);
            rdoDaThanhToan.TabIndex = 10;
            rdoDaThanhToan.TabStop = true;
            rdoDaThanhToan.Text = "Đã thanh toán";
            rdoDaThanhToan.UseVisualStyleBackColor = true;
            // 
            // rdoChoXacNhan
            // 
            rdoChoXacNhan.AutoSize = true;
            rdoChoXacNhan.Font = new Font("Segoe UI", 10F);
            rdoChoXacNhan.Location = new Point(136, 150);
            rdoChoXacNhan.Name = "rdoChoXacNhan";
            rdoChoXacNhan.Size = new Size(136, 27);
            rdoChoXacNhan.TabIndex = 9;
            rdoChoXacNhan.TabStop = true;
            rdoChoXacNhan.Text = "Chờ xác nhận";
            rdoChoXacNhan.UseVisualStyleBackColor = true;
            // 
            // dtpNgayTao
            // 
            dtpNgayTao.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayTao.Format = DateTimePickerFormat.Short;
            dtpNgayTao.Location = new Point(449, 88);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new Size(195, 30);
            dtpNgayTao.TabIndex = 8;
            // 
            // cboMaThe
            // 
            cboMaThe.Font = new Font("Segoe UI", 10F);
            cboMaThe.FormattingEnabled = true;
            cboMaThe.Location = new Point(449, 30);
            cboMaThe.Name = "cboMaThe";
            cboMaThe.Size = new Size(195, 31);
            cboMaThe.TabIndex = 7;
            // 
            // cboMaNhanVien
            // 
            cboMaNhanVien.Font = new Font("Segoe UI", 10F);
            cboMaNhanVien.FormattingEnabled = true;
            cboMaNhanVien.Location = new Point(138, 90);
            cboMaNhanVien.Name = "cboMaNhanVien";
            cboMaNhanVien.Size = new Size(205, 31);
            cboMaNhanVien.TabIndex = 6;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Font = new Font("Segoe UI", 10F);
            txtMaPhieu.Location = new Point(138, 31);
            txtMaPhieu.Multiline = true;
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.ReadOnly = true;
            txtMaPhieu.Size = new Size(205, 34);
            txtMaPhieu.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(365, 91);
            label6.Name = "label6";
            label6.Size = new Size(80, 23);
            label6.TabIndex = 4;
            label6.Text = "Ngày tạo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(365, 35);
            label5.Name = "label5";
            label5.Size = new Size(68, 23);
            label5.TabIndex = 3;
            label5.Text = "Mã thẻ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(17, 150);
            label4.Name = "label4";
            label4.Size = new Size(91, 23);
            label4.TabIndex = 2;
            label4.Text = "Trạng thái:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(17, 95);
            label3.Name = "label3";
            label3.Size = new Size(118, 23);
            label3.TabIndex = 1;
            label3.Text = "Mã nhân viên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(17, 35);
            label1.Name = "label1";
            label1.Size = new Size(86, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã phiếu:";
            // 
            // cboMaSanPham
            // 
            cboMaSanPham.Font = new Font("Segoe UI", 10F);
            cboMaSanPham.FormattingEnabled = true;
            cboMaSanPham.Location = new Point(126, 29);
            cboMaSanPham.Name = "cboMaSanPham";
            cboMaSanPham.Size = new Size(273, 31);
            cboMaSanPham.TabIndex = 8;
            cboMaSanPham.SelectedIndexChanged += cboMaSanPham_SelectedIndexChanged;
            // 
            // txtThanhTien
            // 
            txtThanhTien.Font = new Font("Segoe UI", 10F);
            txtThanhTien.Location = new Point(126, 159);
            txtThanhTien.Multiline = true;
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Size = new Size(273, 34);
            txtThanhTien.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(126, 112);
            txtSoLuong.Multiline = true;
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(273, 34);
            txtSoLuong.TabIndex = 6;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            txtSoLuong.KeyPress += txtSoLuong_KeyPress;
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Segoe UI", 10F);
            txtDonGia.Location = new Point(126, 65);
            txtDonGia.Multiline = true;
            txtDonGia.Name = "txtDonGia";
            txtDonGia.ReadOnly = true;
            txtDonGia.Size = new Size(273, 34);
            txtDonGia.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F);
            label10.Location = new Point(9, 170);
            label10.Name = "label10";
            label10.Size = new Size(96, 23);
            label10.TabIndex = 3;
            label10.Text = "Thành tiền:";
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(523, 6);
            label2.Name = "label2";
            label2.Size = new Size(313, 46);
            label2.TabIndex = 8;
            label2.Text = "PHIẾU BÁN HÀNG";
            // 
            // dgvChiTietPhieu
            // 
            dgvChiTietPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieu.Location = new Point(10, 11);
            dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            dgvChiTietPhieu.RowHeadersWidth = 51;
            dgvChiTietPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietPhieu.Size = new Size(1293, 650);
            dgvChiTietPhieu.TabIndex = 0;
            dgvChiTietPhieu.CellClick += dgvChiTietPhieu_CellClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(13, 123);
            label9.Name = "label9";
            label9.Size = new Size(82, 23);
            label9.TabIndex = 2;
            label9.Text = "Số lượng:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(13, 76);
            label8.Name = "label8";
            label8.Size = new Size(74, 23);
            label8.TabIndex = 1;
            label8.Text = "Đơn giá:";
            // 
            // tabChiTietPhieu
            // 
            tabChiTietPhieu.Controls.Add(dgvChiTietPhieu);
            tabChiTietPhieu.Location = new Point(4, 29);
            tabChiTietPhieu.Name = "tabChiTietPhieu";
            tabChiTietPhieu.Padding = new Padding(3);
            tabChiTietPhieu.Size = new Size(1318, 667);
            tabChiTietPhieu.TabIndex = 1;
            tabChiTietPhieu.Text = "CHI TIẾT PHIẾU";
            tabChiTietPhieu.UseVisualStyleBackColor = true;
            // 
            // btnXoaChiTiet
            // 
            btnXoaChiTiet.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnXoaChiTiet.Image = (Image)resources.GetObject("btnXoaChiTiet.Image");
            btnXoaChiTiet.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoaChiTiet.Location = new Point(1070, 286);
            btnXoaChiTiet.Name = "btnXoaChiTiet";
            btnXoaChiTiet.Size = new Size(161, 41);
            btnXoaChiTiet.TabIndex = 19;
            btnXoaChiTiet.Text = "Xóa chi tiết";
            btnXoaChiTiet.TextAlign = ContentAlignment.MiddleRight;
            btnXoaChiTiet.UseVisualStyleBackColor = true;
            btnXoaChiTiet.Click += btnXoaChiTiet_Click;
            // 
            // btnSuaChiTiet
            // 
            btnSuaChiTiet.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnSuaChiTiet.Image = (Image)resources.GetObject("btnSuaChiTiet.Image");
            btnSuaChiTiet.ImageAlign = ContentAlignment.MiddleLeft;
            btnSuaChiTiet.Location = new Point(866, 311);
            btnSuaChiTiet.Name = "btnSuaChiTiet";
            btnSuaChiTiet.Size = new Size(161, 41);
            btnSuaChiTiet.TabIndex = 18;
            btnSuaChiTiet.Text = "Sửa chi tiết";
            btnSuaChiTiet.TextAlign = ContentAlignment.MiddleRight;
            btnSuaChiTiet.UseVisualStyleBackColor = true;
            btnSuaChiTiet.Click += btnSuaChiTiet_Click;
            // 
            // btnThemChiTiet
            // 
            btnThemChiTiet.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnThemChiTiet.Image = (Image)resources.GetObject("btnThemChiTiet.Image");
            btnThemChiTiet.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemChiTiet.Location = new Point(866, 262);
            btnThemChiTiet.Name = "btnThemChiTiet";
            btnThemChiTiet.Size = new Size(161, 41);
            btnThemChiTiet.TabIndex = 17;
            btnThemChiTiet.Text = "Thêm chi tiết";
            btnThemChiTiet.TextAlign = ContentAlignment.MiddleRight;
            btnThemChiTiet.UseVisualStyleBackColor = true;
            btnThemChiTiet.Click += btnThemChiTiet_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThanhToan.Image = (Image)resources.GetObject("btnThanhToan.Image");
            btnThanhToan.ImageAlign = ContentAlignment.MiddleLeft;
            btnThanhToan.Location = new Point(463, 275);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(161, 60);
            btnThanhToan.TabIndex = 16;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.TextAlign = ContentAlignment.MiddleRight;
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(279, 310);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(161, 41);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoaPhieu
            // 
            btnXoaPhieu.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnXoaPhieu.Image = (Image)resources.GetObject("btnXoaPhieu.Image");
            btnXoaPhieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoaPhieu.Location = new Point(279, 264);
            btnXoaPhieu.Name = "btnXoaPhieu";
            btnXoaPhieu.Size = new Size(161, 41);
            btnXoaPhieu.TabIndex = 14;
            btnXoaPhieu.Text = "Xóa phiếu";
            btnXoaPhieu.TextAlign = ContentAlignment.MiddleRight;
            btnXoaPhieu.UseVisualStyleBackColor = true;
            btnXoaPhieu.Click += btnXoaPhieu_Click;
            // 
            // btnSuaPhieu
            // 
            btnSuaPhieu.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnSuaPhieu.Image = (Image)resources.GetObject("btnSuaPhieu.Image");
            btnSuaPhieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnSuaPhieu.Location = new Point(62, 311);
            btnSuaPhieu.Name = "btnSuaPhieu";
            btnSuaPhieu.Size = new Size(161, 41);
            btnSuaPhieu.TabIndex = 13;
            btnSuaPhieu.Text = "Sửa phiếu";
            btnSuaPhieu.TextAlign = ContentAlignment.MiddleRight;
            btnSuaPhieu.UseVisualStyleBackColor = true;
            btnSuaPhieu.Click += btnSuaPhieu_Click;
            // 
            // btnThemPhieu
            // 
            btnThemPhieu.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnThemPhieu.Image = (Image)resources.GetObject("btnThemPhieu.Image");
            btnThemPhieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemPhieu.Location = new Point(62, 264);
            btnThemPhieu.Name = "btnThemPhieu";
            btnThemPhieu.Size = new Size(161, 41);
            btnThemPhieu.TabIndex = 12;
            btnThemPhieu.Text = "Thêm phiếu";
            btnThemPhieu.TextAlign = ContentAlignment.MiddleRight;
            btnThemPhieu.UseVisualStyleBackColor = true;
            btnThemPhieu.Click += btnThemPhieu_Click;
            // 
            // dgvDSPhieuBanhang
            // 
            dgvDSPhieuBanhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSPhieuBanhang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSPhieuBanhang.Location = new Point(3, 357);
            dgvDSPhieuBanhang.Name = "dgvDSPhieuBanhang";
            dgvDSPhieuBanhang.RowHeadersWidth = 51;
            dgvDSPhieuBanhang.Size = new Size(1309, 304);
            dgvDSPhieuBanhang.TabIndex = 11;
            dgvDSPhieuBanhang.CellClick += dgvDSPhieuBanhang_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cboMaSanPham);
            groupBox2.Controls.Add(txtThanhTien);
            groupBox2.Controls.Add(txtSoLuong);
            groupBox2.Controls.Add(txtDonGia);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(832, 52);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(423, 204);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết phiếu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(13, 29);
            label7.Name = "label7";
            label7.Size = new Size(91, 23);
            label7.TabIndex = 0;
            label7.Text = "Sản phẩm:";
            // 
            // tabPhieuBanHang
            // 
            tabPhieuBanHang.Controls.Add(btnXuatHoaDon);
            tabPhieuBanHang.Controls.Add(btnXoaChiTiet);
            tabPhieuBanHang.Controls.Add(btnSuaChiTiet);
            tabPhieuBanHang.Controls.Add(btnThemChiTiet);
            tabPhieuBanHang.Controls.Add(btnThanhToan);
            tabPhieuBanHang.Controls.Add(btnLamMoi);
            tabPhieuBanHang.Controls.Add(btnXoaPhieu);
            tabPhieuBanHang.Controls.Add(btnSuaPhieu);
            tabPhieuBanHang.Controls.Add(btnThemPhieu);
            tabPhieuBanHang.Controls.Add(dgvDSPhieuBanhang);
            tabPhieuBanHang.Controls.Add(groupBox2);
            tabPhieuBanHang.Controls.Add(groupBox1);
            tabPhieuBanHang.Controls.Add(label2);
            tabPhieuBanHang.Location = new Point(4, 29);
            tabPhieuBanHang.Name = "tabPhieuBanHang";
            tabPhieuBanHang.Padding = new Padding(3);
            tabPhieuBanHang.Size = new Size(1318, 667);
            tabPhieuBanHang.TabIndex = 0;
            tabPhieuBanHang.Text = "PHIẾU BÁN HÀNG";
            tabPhieuBanHang.UseVisualStyleBackColor = true;
            // 
            // tabDSPhieuBanHang
            // 
            tabDSPhieuBanHang.Controls.Add(tabPhieuBanHang);
            tabDSPhieuBanHang.Controls.Add(tabChiTietPhieu);
            tabDSPhieuBanHang.Location = new Point(2, 0);
            tabDSPhieuBanHang.Name = "tabDSPhieuBanHang";
            tabDSPhieuBanHang.SelectedIndex = 0;
            tabDSPhieuBanHang.Size = new Size(1326, 700);
            tabDSPhieuBanHang.TabIndex = 1;
            // 
            // btnXuatHoaDon
            // 
            btnXuatHoaDon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXuatHoaDon.Image = (Image)resources.GetObject("btnXuatHoaDon.Image");
            btnXuatHoaDon.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuatHoaDon.Location = new Point(630, 275);
            btnXuatHoaDon.Name = "btnXuatHoaDon";
            btnXuatHoaDon.Size = new Size(173, 60);
            btnXuatHoaDon.TabIndex = 20;
            btnXuatHoaDon.Text = "Xuất hóa đơn";
            btnXuatHoaDon.TextAlign = ContentAlignment.MiddleRight;
            btnXuatHoaDon.UseVisualStyleBackColor = true;
            // 
            // SalesInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(tabDSPhieuBanHang);
            Name = "SalesInvoice";
            Text = "SalesInvoice";
            Load += SalesInvoice_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).EndInit();
            tabChiTietPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSPhieuBanhang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPhieuBanHang.ResumeLayout(false);
            tabPhieuBanHang.PerformLayout();
            tabDSPhieuBanHang.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rdoDaThanhToan;
        private RadioButton rdoChoXacNhan;
        private DateTimePicker dtpNgayTao;
        private ComboBox cboMaThe;
        private ComboBox cboMaNhanVien;
        private TextBox txtMaPhieu;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private ComboBox cboMaSanPham;
        private TextBox txtThanhTien;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
        private Label label10;
        private Label label2;
        private DataGridView dgvChiTietPhieu;
        private Label label9;
        private Label label8;
        private TabPage tabChiTietPhieu;
        private Button btnXoaChiTiet;
        private Button btnSuaChiTiet;
        private Button btnThemChiTiet;
        private Button btnThanhToan;
        private Button btnLamMoi;
        private Button btnXoaPhieu;
        private Button btnSuaPhieu;
        private Button btnThemPhieu;
        private DataGridView dgvDSPhieuBanhang;
        private GroupBox groupBox2;
        private Label label7;
        private TabPage tabPhieuBanHang;
        private TabControl tabDSPhieuBanHang;
        private Button btnXuatHoaDon;
    }
}