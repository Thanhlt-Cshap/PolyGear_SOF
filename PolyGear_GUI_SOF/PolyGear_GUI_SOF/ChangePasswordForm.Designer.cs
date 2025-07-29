namespace PolyGear_GUI_SOF
{
    partial class ChangePasswordForm
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
            label6 = new Label();
            txtAccountID = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtMatKhauCu = new TextBox();
            chkXacNhanMatKhau = new CheckBox();
            chkMatKhauMoi = new CheckBox();
            chkMatKhauCu = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThoat = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            btnLogin = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(146, 115);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(163, 32);
            label6.TabIndex = 36;
            label6.Text = "Mã tài khoản";
            // 
            // txtAccountID
            // 
            txtAccountID.Location = new Point(142, 159);
            txtAccountID.Margin = new Padding(4);
            txtAccountID.Multiline = true;
            txtAccountID.Name = "txtAccountID";
            txtAccountID.ReadOnly = true;
            txtAccountID.Size = new Size(448, 37);
            txtAccountID.TabIndex = 35;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 11F);
            txtXacNhanMatKhau.Location = new Point(145, 541);
            txtXacNhanMatKhau.Margin = new Padding(4);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '*';
            txtXacNhanMatKhau.Size = new Size(378, 37);
            txtXacNhanMatKhau.TabIndex = 34;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI", 11F);
            txtMatKhauMoi.Location = new Point(145, 439);
            txtMatKhauMoi.Margin = new Padding(4);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(378, 37);
            txtMatKhauMoi.TabIndex = 33;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = new Font("Segoe UI", 11F);
            txtMatKhauCu.Location = new Point(141, 358);
            txtMatKhauCu.Margin = new Padding(4);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(378, 37);
            txtMatKhauCu.TabIndex = 32;
            // 
            // chkXacNhanMatKhau
            // 
            chkXacNhanMatKhau.AutoSize = true;
            chkXacNhanMatKhau.Location = new Point(562, 548);
            chkXacNhanMatKhau.Margin = new Padding(4);
            chkXacNhanMatKhau.Name = "chkXacNhanMatKhau";
            chkXacNhanMatKhau.Size = new Size(99, 29);
            chkXacNhanMatKhau.TabIndex = 31;
            chkXacNhanMatKhau.Text = "Hiện thị";
            chkXacNhanMatKhau.UseVisualStyleBackColor = true;
            chkXacNhanMatKhau.Click += chkConfirmPassword_CheckedChanged;
            // 
            // chkMatKhauMoi
            // 
            chkMatKhauMoi.AutoSize = true;
            chkMatKhauMoi.Location = new Point(562, 448);
            chkMatKhauMoi.Margin = new Padding(4);
            chkMatKhauMoi.Name = "chkMatKhauMoi";
            chkMatKhauMoi.Size = new Size(99, 29);
            chkMatKhauMoi.TabIndex = 30;
            chkMatKhauMoi.Text = "Hiện thị";
            chkMatKhauMoi.UseVisualStyleBackColor = true;
            chkMatKhauMoi.Click += chkNewPassword_CheckedChanged;
            // 
            // chkMatKhauCu
            // 
            chkMatKhauCu.AutoSize = true;
            chkMatKhauCu.Location = new Point(562, 365);
            chkMatKhauCu.Margin = new Padding(4);
            chkMatKhauCu.Name = "chkMatKhauCu";
            chkMatKhauCu.Size = new Size(99, 29);
            chkMatKhauCu.TabIndex = 29;
            chkMatKhauCu.Text = "Hiện thị";
            chkMatKhauCu.UseVisualStyleBackColor = true;
            chkMatKhauCu.Click += chkOldPassword_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(143, 506);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(232, 32);
            label5.TabIndex = 28;
            label5.Text = "Xác nhận mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(143, 404);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(172, 32);
            label4.TabIndex = 27;
            label4.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(143, 314);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 32);
            label3.TabIndex = 26;
            label3.Text = "Mật khẩu cũ";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Salmon;
            btnThoat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThoat.Location = new Point(148, 708);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(455, 68);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label1.Location = new Point(204, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(393, 74);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(142, 215);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(141, 250);
            txtUsername.Margin = new Padding(4);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(454, 42);
            txtUsername.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.Location = new Point(148, 616);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(455, 68);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đổi mật khẩu";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnChangePassword_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtAccountID);
            groupBox1.Controls.Add(txtXacNhanMatKhau);
            groupBox1.Controls.Add(txtMatKhauMoi);
            groupBox1.Controls.Add(txtMatKhauCu);
            groupBox1.Controls.Add(chkXacNhanMatKhau);
            groupBox1.Controls.Add(chkMatKhauMoi);
            groupBox1.Controls.Add(chkMatKhauCu);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Location = new Point(112, 43);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(776, 798);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 884);
            Controls.Add(groupBox1);
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePasswordForm";
            Load += ChangePasswordForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private TextBox txtAccountID;
        private TextBox txtXacNhanMatKhau;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauCu;
        private CheckBox chkXacNhanMatKhau;
        private CheckBox chkMatKhauMoi;
        private CheckBox chkMatKhauCu;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnThoat;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private Button btnLogin;
        private GroupBox groupBox1;
    }
}