using System;
using System.Windows.Forms;
using DAL_SOF205;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace PolyGear_GUI_SOF
{
    public partial class ChangePasswordForm : Form
    {
        private AccountsDTO account;

        public ChangePasswordForm(AccountsDTO acc)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.account = acc;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            if (account != null)
            {
                txtAccountID.Text = account.AccountID;
                txtUsername.Text = account.Username;
            }
        }

        private void chkOldPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = chkMatKhauCu.Checked ? '\0' : '*';
        }

        private void chkNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = chkMatKhauMoi.Checked ? '\0' : '*';
        }

        private void chkConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.PasswordChar = chkXacNhanMatKhau.Checked ? '\0' : '*';
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = txtMatKhauCu.Text.Trim();
                string newPassword = txtMatKhauMoi.Text.Trim();
                string confirmPassword = txtXacNhanMatKhau.Text.Trim();

                // Kiểm tra mật khẩu cũ có đúng không
                if (oldPassword != account.Password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mật khẩu mới không được trống
                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Mật khẩu mới không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mật khẩu mới khác mật khẩu cũ
                if (newPassword == oldPassword)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Kiểm tra mật khẩu xác nhận có khớp không
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu mọi thứ hợp lệ, cập nhật mật khẩu mới
                account.Password = newPassword;

                AccountDAL dal = new AccountDAL();
                dal.update(account);

                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AuthUtil.user = null;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đổi mật khẩu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
