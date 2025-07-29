namespace PolyGear_GUI_SOF
{
    partial class Login
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
            groupBox1 = new GroupBox();
            btnThoat = new Button();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            chkShowPass = new CheckBox();
            label3 = new Label();
            txtUsername = new TextBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(chkShowPass);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Location = new Point(112, 62);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(776, 761);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = ".";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Salmon;
            btnThoat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThoat.Location = new Point(141, 629);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(455, 68);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label1.Location = new Point(243, 42);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(320, 74);
            label1.TabIndex = 0;
            label1.Text = "Đăng nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(243, 449);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(144, 175);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Font = new Font("Segoe UI", 11F);
            chkShowPass.Location = new Point(148, 415);
            chkShowPass.Margin = new Padding(4);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(209, 34);
            chkShowPass.TabIndex = 7;
            chkShowPass.Text = "Hiện thị mật khẩu";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.Click += chkShowPass_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(148, 311);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 32);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(145, 216);
            txtUsername.Margin = new Padding(4);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(454, 42);
            txtUsername.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.Location = new Point(145, 525);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(455, 68);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(145, 344);
            txtPassword.Margin = new Padding(4);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(450, 44);
            txtPassword.TabIndex = 4;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 884);
            Controls.Add(groupBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += LoginGUI_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnThoat;
        private Label label1;
        private Label label4;
        private Label label2;
        private CheckBox chkShowPass;
        private Label label3;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox txtPassword;
    }
}