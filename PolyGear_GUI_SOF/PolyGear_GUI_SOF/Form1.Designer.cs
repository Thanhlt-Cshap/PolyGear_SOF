namespace PolyGear_GUI_SOF
{
    partial class Form1
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
            btnQuanLyKhachHang = new Button();
            btnQuanLyHangSX = new Button();
            btnQuanLyLoaiSanPham = new Button();
            btnQuanLySanPham = new Button();
            SuspendLayout();
            // 
            // btnQuanLyKhachHang
            // 
            btnQuanLyKhachHang.Location = new Point(47, 42);
            btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
            btnQuanLyKhachHang.Size = new Size(166, 29);
            btnQuanLyKhachHang.TabIndex = 0;
            btnQuanLyKhachHang.Text = "Quản lý nhân khách hàng";
            btnQuanLyKhachHang.UseVisualStyleBackColor = true;
            btnQuanLyKhachHang.Click += btnQuanLyKhachHang_Click;
            // 
            // btnQuanLyHangSX
            // 
            btnQuanLyHangSX.Location = new Point(47, 130);
            btnQuanLyHangSX.Name = "btnQuanLyHangSX";
            btnQuanLyHangSX.Size = new Size(166, 29);
            btnQuanLyHangSX.TabIndex = 1;
            btnQuanLyHangSX.Text = "Quản lý hãng sản xuất";
            btnQuanLyHangSX.UseVisualStyleBackColor = true;
            btnQuanLyHangSX.Click += btnQuanLyHangSX_Click;
            // 
            // btnQuanLyLoaiSanPham
            // 
            btnQuanLyLoaiSanPham.Location = new Point(299, 42);
            btnQuanLyLoaiSanPham.Name = "btnQuanLyLoaiSanPham";
            btnQuanLyLoaiSanPham.Size = new Size(166, 29);
            btnQuanLyLoaiSanPham.TabIndex = 2;
            btnQuanLyLoaiSanPham.Text = "Quản lý loại sản phẩm";
            btnQuanLyLoaiSanPham.UseVisualStyleBackColor = true;
            btnQuanLyLoaiSanPham.Click += btnQuanLyLoaiSanPham_Click;
            // 
            // btnQuanLySanPham
            // 
            btnQuanLySanPham.Location = new Point(299, 130);
            btnQuanLySanPham.Name = "btnQuanLySanPham";
            btnQuanLySanPham.Size = new Size(166, 29);
            btnQuanLySanPham.TabIndex = 3;
            btnQuanLySanPham.Text = "Quản lý sản phẩm";
            btnQuanLySanPham.UseVisualStyleBackColor = true;
            btnQuanLySanPham.Click += btnQuanLySanPham_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuanLySanPham);
            Controls.Add(btnQuanLyLoaiSanPham);
            Controls.Add(btnQuanLyHangSX);
            Controls.Add(btnQuanLyKhachHang);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Demo";
            ResumeLayout(false);
        }

        #endregion

        private Button btnQuanLyKhachHang;
        private Button btnQuanLyHangSX;
        private Button btnQuanLyLoaiSanPham;
        private Button btnQuanLySanPham;
    }
}