namespace PolyGear_GUI_SOF
{
    partial class ProductTypesManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTypesManagement));
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            label2 = new Label();
            txtTenLoai = new TextBox();
            txtGhiChu = new TextBox();
            txtMaLoai = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblTrangThai = new Label();
            rdoNgungBan = new RadioButton();
            rdoHoatDong = new RadioButton();
            dgvDSLoaiSanPham = new DataGridView();
            pictureBox1 = new PictureBox();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDSLoaiSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.MenuHighlight;
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(1142, 547);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(147, 46);
            btnLamMoi.TabIndex = 33;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.LightCoral;
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(1142, 626);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(147, 46);
            btnXoa.TabIndex = 32;
            btnXoa.Text = "Xóa    ";
            btnXoa.TextAlign = ContentAlignment.MiddleRight;
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSua.ForeColor = Color.Crimson;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(893, 626);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(147, 46);
            btnSua.TabIndex = 31;
            btnSua.Text = "Sửa    ";
            btnSua.TextAlign = ContentAlignment.MiddleRight;
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnThem.ForeColor = Color.CornflowerBlue;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(893, 547);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(147, 46);
            btnThem.TabIndex = 30;
            btnThem.Text = "Thêm  ";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(504, 9);
            label2.Name = "label2";
            label2.Size = new Size(445, 46);
            label2.TabIndex = 29;
            label2.Text = "QUẢN LÝ LOẠI SẢN PHẨM";
            // 
            // txtTenLoai
            // 
            txtTenLoai.Font = new Font("Segoe UI", 13F);
            txtTenLoai.Location = new Point(893, 242);
            txtTenLoai.Multiline = true;
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(398, 43);
            txtTenLoai.TabIndex = 28;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.Location = new Point(891, 338);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(400, 143);
            txtGhiChu.TabIndex = 27;
            txtGhiChu.TextChanged += txtGhiChu_TextChanged;
            // 
            // txtMaLoai
            // 
            txtMaLoai.Font = new Font("Segoe UI", 13F);
            txtMaLoai.Location = new Point(891, 147);
            txtMaLoai.Multiline = true;
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Size = new Size(398, 43);
            txtMaLoai.TabIndex = 26;
            // 
            // label3
            // 
            label3.AccessibleRole = AccessibleRole.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(872, 112);
            label3.Name = "label3";
            label3.Size = new Size(105, 32);
            label3.TabIndex = 23;
            label3.Text = "Mã loại: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(872, 303);
            label4.Name = "label4";
            label4.Size = new Size(108, 32);
            label4.TabIndex = 25;
            label4.Text = "Ghi chú: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(872, 207);
            label5.Name = "label5";
            label5.Size = new Size(109, 32);
            label5.TabIndex = 24;
            label5.Text = "Tên loại: ";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 14F);
            lblTrangThai.Location = new Point(872, 492);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(120, 32);
            lblTrangThai.TabIndex = 34;
            lblTrangThai.Text = "Trạng thái";
            // 
            // rdoNgungBan
            // 
            rdoNgungBan.AutoSize = true;
            rdoNgungBan.Font = new Font("Segoe UI", 13F);
            rdoNgungBan.Location = new Point(1146, 490);
            rdoNgungBan.Name = "rdoNgungBan";
            rdoNgungBan.Size = new Size(143, 34);
            rdoNgungBan.TabIndex = 40;
            rdoNgungBan.TabStop = true;
            rdoNgungBan.Text = "Ngưng bán";
            rdoNgungBan.UseVisualStyleBackColor = true;
            // 
            // rdoHoatDong
            // 
            rdoHoatDong.AutoSize = true;
            rdoHoatDong.Font = new Font("Segoe UI", 13F);
            rdoHoatDong.Location = new Point(998, 490);
            rdoHoatDong.Name = "rdoHoatDong";
            rdoHoatDong.Size = new Size(144, 34);
            rdoHoatDong.TabIndex = 39;
            rdoHoatDong.TabStop = true;
            rdoHoatDong.Text = "Hoạt động ";
            rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // dgvDSLoaiSanPham
            // 
            dgvDSLoaiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSLoaiSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSLoaiSanPham.Location = new Point(12, 175);
            dgvDSLoaiSanPham.Name = "dgvDSLoaiSanPham";
            dgvDSLoaiSanPham.RowHeadersWidth = 51;
            dgvDSLoaiSanPham.Size = new Size(821, 516);
            dgvDSLoaiSanPham.TabIndex = 41;
            dgvDSLoaiSanPham.CellClick += dgvDSLoaiSanPham_CellClick;
            dgvDSLoaiSanPham.CellContentClick += dgvDSLoaiSanPham_CellContentClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(293, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 57;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 12F);
            txtTimKiem.Location = new Point(12, 129);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(275, 40);
            txtTimKiem.TabIndex = 56;
            // 
            // ProductTypesManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvDSLoaiSanPham);
            Controls.Add(rdoNgungBan);
            Controls.Add(rdoHoatDong);
            Controls.Add(lblTrangThai);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label2);
            Controls.Add(txtTenLoai);
            Controls.Add(txtGhiChu);
            Controls.Add(txtMaLoai);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Name = "ProductTypesManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductTypesManagement";
            Load += ProductTypesManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDSLoaiSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Label label2;
        private TextBox txtTenLoai;
        private TextBox txtGhiChu;
        private TextBox txtMaLoai;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblTrangThai;
        private RadioButton rdoNgungBan;
        private RadioButton rdoHoatDong;
        private DataGridView dgvDSLoaiSanPham;
        private PictureBox pictureBox1;
        private TextBox txtTimKiem;
    }
}