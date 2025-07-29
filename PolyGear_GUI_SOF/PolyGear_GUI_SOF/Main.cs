using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_SOF205;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace PolyGear_GUI_SOF
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void CheckRole()
        {
            if (!AuthUtil.IsLogin())
            {
                Login formlogin = new Login();
                formlogin.ShowDialog();


            }

            if (AuthUtil.IsLogin())
            {
                var dal = new AccountDAL();
                var acc = dal.selectById(AuthUtil.user.AccountID);

                if (acc != null && acc.IsFirstLogin)
                {
                    MessageBox.Show("Bạn đang đăng nhập lần đầu. Vui lòng đổi mật khẩu.", "Thông báo");

                    ChangePasswordForm form = new ChangePasswordForm(acc);
                    form.ShowDialog();

                    string sql = "UPDATE Accounts SET IsFirstLogin = 0 WHERE AccountID = @0";
                    DBUtil.Update(sql, new List<object> { acc.AccountID });

                    acc.IsFirstLogin = false; 
                }
            }
        }

        private void ShowFromInPanel(Form form)
        {
            pnlFormContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlFormContainer.Controls.Add(form);
            form.Show();
        }

        //private void Logout()
        //{
        //    this.Close();
        //    AuthUtil.Logout();
        //    Login fromLogin = new Login();
        //    fromLogin.ShowDialog();
        //    this.Show();
        //}
        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            CheckRole();
            pnlFormContainer.Controls.Clear();
        }


        private void itmQLNhanVien_Click(object sender, EventArgs e)
        {
            if (!AuthUtil.IsStoreOwner())
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowFromInPanel(new Employees());
        }

        private void imtDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form Main hiện tại

            Login loginForm = new Login();
            loginForm.Show(); // Mở lại form đăng nhập

            // Nếu muốn đóng form Main sau khi loginForm đóng => dùng:
            // loginForm.FormClosed += (s, args) => this.Close();        
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            if (AuthUtil.IsLogin())
            {
                lblTaiKhoan.Text = AuthUtil.user.AccountID;
            }
            //itmQLNhanVien.Enabled = AuthUtil.IsStoreOwner();

        }
        private void itmDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form Main hiện tại
            AccountDAL dal = new AccountDAL();
            AccountsDTO acc = dal.selectById(AuthUtil.user.AccountID);

            if (acc == null)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản trong CSDL.");
                return;
            }

            ChangePasswordForm form = new ChangePasswordForm(acc);
            form.ShowDialog();

            Login loginForm = new Login();
            loginForm.Show(); // Mở lại form đăng nhập

        }
        private void LoginGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && e.CloseReason == CloseReason.UserClosing)
            {
                MessageBox.Show("Vui lòng đăng xuất!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
