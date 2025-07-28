namespace PolyGear_GUI_SOF
{
    partial class ProductsManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsManagement));
            dgvDSSanPham = new DataGridView();
            tabDanhSach = new TabPage();
            btnLocSanPham = new Button();
            cboLocSanPham = new ComboBox();
            picTimKiem = new PictureBox();
            txtTimKiem = new TextBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            picHinhAnh = new PictureBox();
            btnChonAnh = new Button();
            rdoNgungBan = new RadioButton();
            rdoHoatDong = new RadioButton();
            cboLoaiSanPham = new ComboBox();
            txtDonGia = new TextBox();
            txtTenSanPham = new TextBox();
            txtMaSanPham = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            tabCapNhat = new TabPage();
            txtSoLuongTonKho = new TextBox();
            label9 = new Label();
            txtGhiChu = new TextBox();
            label8 = new Label();
            cboHangSanXuat = new ComboBox();
            label6 = new Label();
            tabSanPham = new TabControl();
            ((System.ComponentModel.ISupportInitialize)dgvDSSanPham).BeginInit();
            tabDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTimKiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            tabCapNhat.SuspendLayout();
            tabSanPham.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDSSanPham
            // 
            dgvDSSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSanPham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDSSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSSanPham.Location = new Point(6, 103);
            dgvDSSanPham.Name = "dgvDSSanPham";
            dgvDSSanPham.RowHeadersWidth = 51;
            dgvDSSanPham.Size = new Size(1312, 547);
            dgvDSSanPham.TabIndex = 2;
            dgvDSSanPham.CellClick += dgvDSSanPham_CellClick_1;
            // 
            // tabDanhSach
            // 
            tabDanhSach.Controls.Add(btnLocSanPham);
            tabDanhSach.Controls.Add(cboLocSanPham);
            tabDanhSach.Controls.Add(picTimKiem);
            tabDanhSach.Controls.Add(txtTimKiem);
            tabDanhSach.Controls.Add(dgvDSSanPham);
            tabDanhSach.Location = new Point(4, 29);
            tabDanhSach.Name = "tabDanhSach";
            tabDanhSach.Padding = new Padding(3);
            tabDanhSach.Size = new Size(1324, 656);
            tabDanhSach.TabIndex = 1;
            tabDanhSach.Text = "DANH SÁCH";
            tabDanhSach.UseVisualStyleBackColor = true;
            // 
            // btnLocSanPham
            // 
            btnLocSanPham.Location = new Point(628, 69);
            btnLocSanPham.Name = "btnLocSanPham";
            btnLocSanPham.Size = new Size(94, 29);
            btnLocSanPham.TabIndex = 59;
            btnLocSanPham.Text = "Lọc";
            btnLocSanPham.UseVisualStyleBackColor = true;
            // 
            // cboLocSanPham
            // 
            cboLocSanPham.FormattingEnabled = true;
            cboLocSanPham.Location = new Point(471, 69);
            cboLocSanPham.Name = "cboLocSanPham";
            cboLocSanPham.Size = new Size(151, 28);
            cboLocSanPham.TabIndex = 58;
            // 
            // picTimKiem
            // 
            picTimKiem.Image = (Image)resources.GetObject("picTimKiem.Image");
            picTimKiem.Location = new Point(1276, 57);
            picTimKiem.Name = "picTimKiem";
            picTimKiem.Size = new Size(40, 40);
            picTimKiem.SizeMode = PictureBoxSizeMode.StretchImage;
            picTimKiem.TabIndex = 57;
            picTimKiem.TabStop = false;
            picTimKiem.Click += picTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 12F);
            txtTimKiem.Location = new Point(995, 57);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(275, 40);
            txtTimKiem.TabIndex = 56;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(595, 562);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 42);
            btnLamMoi.TabIndex = 44;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(417, 562);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 42);
            btnXoa.TabIndex = 43;
            btnXoa.Text = "Xóa    ";
            btnXoa.TextAlign = ContentAlignment.MiddleRight;
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(242, 562);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 42);
            btnSua.TabIndex = 42;
            btnSua.Text = "Sửa    ";
            btnSua.TextAlign = ContentAlignment.MiddleRight;
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(47, 562);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 42);
            btnThem.TabIndex = 41;
            btnThem.Text = "Thêm   ";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(985, 135);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(270, 305);
            picHinhAnh.TabIndex = 40;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChonAnh.Image = (Image)resources.GetObject("btnChonAnh.Image");
            btnChonAnh.ImageAlign = ContentAlignment.MiddleLeft;
            btnChonAnh.Location = new Point(1060, 446);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(139, 59);
            btnChonAnh.TabIndex = 39;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.TextAlign = ContentAlignment.MiddleRight;
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // rdoNgungBan
            // 
            rdoNgungBan.AutoSize = true;
            rdoNgungBan.Font = new Font("Segoe UI", 10.8F);
            rdoNgungBan.Location = new Point(331, 470);
            rdoNgungBan.Name = "rdoNgungBan";
            rdoNgungBan.Size = new Size(124, 29);
            rdoNgungBan.TabIndex = 38;
            rdoNgungBan.TabStop = true;
            rdoNgungBan.Text = "Ngưng bán";
            rdoNgungBan.UseVisualStyleBackColor = true;
            // 
            // rdoHoatDong
            // 
            rdoHoatDong.AutoSize = true;
            rdoHoatDong.Font = new Font("Segoe UI", 10.8F);
            rdoHoatDong.Location = new Point(200, 470);
            rdoHoatDong.Name = "rdoHoatDong";
            rdoHoatDong.Size = new Size(125, 29);
            rdoHoatDong.TabIndex = 37;
            rdoHoatDong.TabStop = true;
            rdoHoatDong.Text = "Hoạt động ";
            rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.Font = new Font("Segoe UI", 12F);
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Location = new Point(201, 289);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(387, 36);
            cboLoaiSanPham.TabIndex = 36;
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Segoe UI", 12F);
            txtDonGia.Location = new Point(201, 229);
            txtDonGia.Multiline = true;
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(388, 34);
            txtDonGia.TabIndex = 35;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Font = new Font("Segoe UI", 12F);
            txtTenSanPham.Location = new Point(200, 162);
            txtTenSanPham.Multiline = true;
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(388, 34);
            txtTenSanPham.TabIndex = 34;
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Font = new Font("Segoe UI", 12F);
            txtMaSanPham.Location = new Point(201, 107);
            txtMaSanPham.Multiline = true;
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.ReadOnly = true;
            txtMaSanPham.Size = new Size(388, 34);
            txtMaSanPham.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(21, 469);
            label5.Name = "label5";
            label5.Size = new Size(98, 28);
            label5.TabIndex = 32;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(21, 168);
            label4.Name = "label4";
            label4.Size = new Size(134, 28);
            label4.TabIndex = 31;
            label4.Text = "Tên sản phẩm:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(21, 229);
            label3.Name = "label3";
            label3.Size = new Size(85, 28);
            label3.TabIndex = 30;
            label3.Text = "Đơn giá:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(21, 292);
            label2.Name = "label2";
            label2.Size = new Size(146, 28);
            label2.TabIndex = 29;
            label2.Text = "Loại sản phẩm: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 107);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 28;
            label1.Text = "Mã sản phẩm:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(501, 23);
            label7.Name = "label7";
            label7.Size = new Size(359, 46);
            label7.TabIndex = 27;
            label7.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // tabCapNhat
            // 
            tabCapNhat.Controls.Add(txtSoLuongTonKho);
            tabCapNhat.Controls.Add(label9);
            tabCapNhat.Controls.Add(txtGhiChu);
            tabCapNhat.Controls.Add(label8);
            tabCapNhat.Controls.Add(cboHangSanXuat);
            tabCapNhat.Controls.Add(label6);
            tabCapNhat.Controls.Add(btnLamMoi);
            tabCapNhat.Controls.Add(btnXoa);
            tabCapNhat.Controls.Add(btnSua);
            tabCapNhat.Controls.Add(btnThem);
            tabCapNhat.Controls.Add(picHinhAnh);
            tabCapNhat.Controls.Add(btnChonAnh);
            tabCapNhat.Controls.Add(rdoNgungBan);
            tabCapNhat.Controls.Add(rdoHoatDong);
            tabCapNhat.Controls.Add(cboLoaiSanPham);
            tabCapNhat.Controls.Add(txtDonGia);
            tabCapNhat.Controls.Add(txtTenSanPham);
            tabCapNhat.Controls.Add(txtMaSanPham);
            tabCapNhat.Controls.Add(label5);
            tabCapNhat.Controls.Add(label4);
            tabCapNhat.Controls.Add(label3);
            tabCapNhat.Controls.Add(label2);
            tabCapNhat.Controls.Add(label1);
            tabCapNhat.Controls.Add(label7);
            tabCapNhat.Location = new Point(4, 29);
            tabCapNhat.Name = "tabCapNhat";
            tabCapNhat.Padding = new Padding(3);
            tabCapNhat.Size = new Size(1324, 656);
            tabCapNhat.TabIndex = 0;
            tabCapNhat.Text = "CẬP NHẬT";
            tabCapNhat.UseVisualStyleBackColor = true;
            // 
            // txtSoLuongTonKho
            // 
            txtSoLuongTonKho.Font = new Font("Segoe UI", 12F);
            txtSoLuongTonKho.Location = new Point(201, 406);
            txtSoLuongTonKho.Multiline = true;
            txtSoLuongTonKho.Name = "txtSoLuongTonKho";
            txtSoLuongTonKho.Size = new Size(388, 34);
            txtSoLuongTonKho.TabIndex = 54;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(21, 412);
            label9.Name = "label9";
            label9.Size = new Size(174, 28);
            label9.TabIndex = 53;
            label9.Text = "Số lượng tồn kho: ";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.Location = new Point(617, 135);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(332, 305);
            txtGhiChu.TabIndex = 52;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(617, 100);
            label8.Name = "label8";
            label8.Size = new Size(108, 32);
            label8.TabIndex = 51;
            label8.Text = "Ghi chú: ";
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.Font = new Font("Segoe UI", 12F);
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Location = new Point(201, 349);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(387, 36);
            cboHangSanXuat.TabIndex = 46;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(21, 357);
            label6.Name = "label6";
            label6.Size = new Size(144, 28);
            label6.TabIndex = 45;
            label6.Text = "Hãng sản xuất: ";
            // 
            // tabSanPham
            // 
            tabSanPham.Controls.Add(tabCapNhat);
            tabSanPham.Controls.Add(tabDanhSach);
            tabSanPham.Location = new Point(-1, 2);
            tabSanPham.Name = "tabSanPham";
            tabSanPham.SelectedIndex = 0;
            tabSanPham.Size = new Size(1332, 689);
            tabSanPham.TabIndex = 1;
            tabSanPham.TabIndexChanged += tabSanPham_TabIndexChanged;
            // 
            // ProductsManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(tabSanPham);
            Name = "ProductsManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductsManagement";
            Load += ProductsManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDSSanPham).EndInit();
            tabDanhSach.ResumeLayout(false);
            tabDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTimKiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            tabCapNhat.ResumeLayout(false);
            tabCapNhat.PerformLayout();
            tabSanPham.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDSSanPham;
        private TabPage tabDanhSach;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private RadioButton rdoNgungBan;
        private RadioButton rdoHoatDong;
        private ComboBox cboLoaiSanPham;
        private TextBox txtDonGia;
        private TextBox txtTenSanPham;
        private TextBox txtMaSanPham;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private TabPage tabCapNhat;
        private ComboBox cboHangSanXuat;
        private Label label6;
        private TabControl tabSanPham;
        private TextBox txtGhiChu;
        private Label label8;
        private PictureBox picTimKiem;
        private TextBox txtTimKiem;
        private TextBox txtSoLuongTonKho;
        private Label label9;
        private ComboBox cboLocSanPham;
        private Button btnLocSanPham;
    }
}