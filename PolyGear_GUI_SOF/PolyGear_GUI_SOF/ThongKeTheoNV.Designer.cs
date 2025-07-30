namespace PolyGear_GUI_SOF
{
    partial class ThongKeTheoNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKeTheoNV));
            dgvThongKe = new DataGridView();
            panel1 = new Panel();
            btnThongKe = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTungay = new DateTimePicker();
            cboNhanVien = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvThongKe
            // 
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Location = new Point(7, 94);
            dgvThongKe.Margin = new Padding(3, 2, 3, 2);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.RowHeadersWidth = 51;
            dgvThongKe.Size = new Size(1152, 373);
            dgvThongKe.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnThongKe);
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTungay);
            panel1.Controls.Add(cboNhanVien);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(7, 35);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1152, 54);
            panel1.TabIndex = 15;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongKe.Image = (Image)resources.GetObject("btnThongKe.Image");
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(839, 3);
            btnThongKe.Margin = new Padding(3, 2, 3, 2);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(122, 41);
            btnThongKe.TabIndex = 7;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleRight;
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(673, 16);
            dtpDenNgay.Margin = new Padding(3, 2, 3, 2);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(131, 23);
            dtpDenNgay.TabIndex = 6;
            // 
            // dtpTungay
            // 
            dtpTungay.Format = DateTimePickerFormat.Short;
            dtpTungay.Location = new Point(416, 16);
            dtpTungay.Margin = new Padding(3, 2, 3, 2);
            dtpTungay.Name = "dtpTungay";
            dtpTungay.Size = new Size(131, 23);
            dtpTungay.TabIndex = 4;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(139, 13);
            cboNhanVien.Margin = new Padding(3, 2, 3, 2);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(196, 23);
            cboNhanVien.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(579, 16);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(341, 16);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(21, 16);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(1044, 472);
            button1.Name = "button1";
            button1.Size = new Size(115, 46);
            button1.TabIndex = 18;
            button1.Text = "Xuất File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.CornflowerBlue;
            label5.Location = new Point(7, 9);
            label5.Name = "label5";
            label5.Size = new Size(233, 25);
            label5.TabIndex = 17;
            label5.Text = "Thống kê theo nhân viên";
            // 
            // ThongKeTheoNV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 527);
            Controls.Add(dgvThongKe);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label5);
            Name = "ThongKeTheoNV";
            Text = "ThongKeTheoNV";
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvThongKe;
        private Panel panel1;
        private Button btnThongKe;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTungay;
        private ComboBox cboNhanVien;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private Label label5;
    }
}