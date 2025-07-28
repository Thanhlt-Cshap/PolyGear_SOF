namespace PolyGear_GUI_SOF
{
    partial class ManufacturerManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManufacturerManagementForm));
            dgvHangSX = new DataGridView();
            lblMaHangSX = new Label();
            txtTenHangSX = new TextBox();
            lblTenHangSX = new Label();
            txtMaHangSX = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            txtGhiChu = new TextBox();
            label3 = new Label();
            btnLamMoi = new Button();
            chkHoatDong = new CheckBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            pictureBox1 = new PictureBox();
            txtTimKiem = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHangSX).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvHangSX
            // 
            dgvHangSX.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangSX.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangSX.Location = new Point(12, 123);
            dgvHangSX.Name = "dgvHangSX";
            dgvHangSX.RowHeadersWidth = 51;
            dgvHangSX.Size = new Size(755, 568);
            dgvHangSX.TabIndex = 53;
            dgvHangSX.CellClick += dgvHangSX_CellClick;
            // 
            // lblMaHangSX
            // 
            lblMaHangSX.AutoSize = true;
            lblMaHangSX.Font = new Font("Segoe UI", 14F);
            lblMaHangSX.Location = new Point(47, 16);
            lblMaHangSX.Name = "lblMaHangSX";
            lblMaHangSX.Size = new Size(216, 32);
            lblMaHangSX.TabIndex = 1;
            lblMaHangSX.Text = "Mã hãng sản xuất: ";
            // 
            // txtTenHangSX
            // 
            txtTenHangSX.Font = new Font("Segoe UI", 12F);
            txtTenHangSX.Location = new Point(49, 141);
            txtTenHangSX.Multiline = true;
            txtTenHangSX.Name = "txtTenHangSX";
            txtTenHangSX.Size = new Size(400, 40);
            txtTenHangSX.TabIndex = 5;
            // 
            // lblTenHangSX
            // 
            lblTenHangSX.AutoSize = true;
            lblTenHangSX.Font = new Font("Segoe UI", 14F);
            lblTenHangSX.Location = new Point(49, 107);
            lblTenHangSX.Name = "lblTenHangSX";
            lblTenHangSX.Size = new Size(220, 32);
            lblTenHangSX.TabIndex = 2;
            lblTenHangSX.Text = "Tên hãng sản xuất: ";
            // 
            // txtMaHangSX
            // 
            txtMaHangSX.Font = new Font("Segoe UI", 12F);
            txtMaHangSX.Location = new Point(49, 50);
            txtMaHangSX.Multiline = true;
            txtMaHangSX.Name = "txtMaHangSX";
            txtMaHangSX.ReadOnly = true;
            txtMaHangSX.Size = new Size(400, 40);
            txtMaHangSX.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(49, 195);
            label4.Name = "label4";
            label4.Size = new Size(132, 32);
            label4.TabIndex = 3;
            label4.Text = "Trạng thái: ";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(chkHoatDong);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(lblMaHangSX);
            panel1.Controls.Add(txtTenHangSX);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(lblTenHangSX);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(txtMaHangSX);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(794, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(492, 568);
            panel1.TabIndex = 52;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.Location = new Point(49, 273);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(400, 143);
            txtGhiChu.TabIndex = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(49, 238);
            label3.Name = "label3";
            label3.Size = new Size(108, 32);
            label3.TabIndex = 49;
            label3.Text = "Ghi chú: ";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamMoi.Image = (Image)resources.GetObject("btnLamMoi.Image");
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(289, 493);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(136, 55);
            btnLamMoi.TabIndex = 48;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.TextAlign = ContentAlignment.MiddleRight;
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // chkHoatDong
            // 
            chkHoatDong.AutoSize = true;
            chkHoatDong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkHoatDong.Location = new Point(187, 196);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(129, 32);
            chkHoatDong.TabIndex = 6;
            chkHoatDong.Text = "Hoạt động";
            chkHoatDong.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(79, 493);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(136, 55);
            btnXoa.TabIndex = 47;
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
            btnSua.Location = new Point(289, 422);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(136, 55);
            btnSua.TabIndex = 46;
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
            btnThem.Location = new Point(79, 422);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(136, 55);
            btnThem.TabIndex = 45;
            btnThem.Text = "Thêm   ";
            btnThem.TextAlign = ContentAlignment.MiddleRight;
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(293, 77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 55;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 12F);
            txtTimKiem.Location = new Point(12, 77);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(275, 40);
            txtTimKiem.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(500, 5);
            label1.Name = "label1";
            label1.Size = new Size(0, 46);
            label1.TabIndex = 51;
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(479, 9);
            label2.Name = "label2";
            label2.Size = new Size(456, 46);
            label2.TabIndex = 56;
            label2.Text = "QUẢN LÝ HÃNG SẢN XUẤT";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ManufacturerManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 703);
            Controls.Add(label2);
            Controls.Add(dgvHangSX);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Controls.Add(label1);
            Name = "ManufacturerManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManufacturerManagementForm";
            Load += ManufacturerManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHangSX).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHangSX;
        private Label lblMaHangSX;
        private TextBox txtTenHangSX;
        private Label lblTenHangSX;
        private TextBox txtMaHangSX;
        private Label label4;
        private Panel panel1;
        private Button btnLamMoi;
        private CheckBox chkHoatDong;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private PictureBox pictureBox1;
        private TextBox txtTimKiem;
        private Label label1;
        private Label label2;
        private TextBox txtGhiChu;
        private Label label3;
    }
}