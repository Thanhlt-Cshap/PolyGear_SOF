using System;
using System.Windows.Forms;
using DAL_SOF205;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
using static PolyGear_DTO_SOF.AccountsDTO;

namespace PolyGear_GUI_SOF
{
    public partial class Login : Form
    {
        AccountDAL accDAL = new AccountDAL();

        public Login()
        {
            InitializeComponent();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); // nên hash nếu bạn có mã hóa

            var account = accDAL.selectByUsernamePassword(username, password);

            if (account != null)
            {
                AuthUtil.user = account;
                Session.CurrentAccountID = account.AccountID;

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Main mainForm = new Main();
                mainForm.Show();
                mainForm.FormClosed += (s, args) => this.Show(); // hoặc this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}
