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

        private void ShowFromInPanel(Form form)
        {
            //xóa form cũ trong panel
            pnlFormContainer.Controls.Clear();
            //thiết lập form con
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            //thêm form vào panel
            pnlFormContainer.Controls.Add(form);
            form.Show();
        }
        private void CheckRole()
        {
            if (!AuthUtil.IsLogin())
            {
                Login formlogin = new Login();
                formlogin.ShowDialog();
            }
        }

        private void Logout()
        {
            this.Hide();
            AuthUtil.Logout();
            Login fromLogin = new Login();
            fromLogin.ShowDialog();
            this.Show();
        }
        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            CheckRole();
            pnlFormContainer.Controls.Clear();
        }


        private void itmQLNhanVien_Click(object sender, EventArgs e)
        {
            ShowFromInPanel(new Employees());
        }

        private void imtDangXuat_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (AuthUtil.IsLogin())
            {
                lblTaiKhoan.Text = AuthUtil.user.AccountID;
            }
        }
        //private void btnDoiMatKhau_Click(object sender, EventArgs e)
        //{
        //    // Gọi DAL lấy thông tin tài khoản
        //    AccountDAL dal = new AccountDAL();
        //    AccountsDTO acc = dal.selectById(AuthUtil.user.AccountID);

        //    if (acc == null)
        //    {
        //        MessageBox.Show("Không tìm thấy thông tin tài khoản trong CSDL.");
        //        return;
        //    }

        //    // Mở form đổi mật khẩu, truyền dữ liệu vào
        //    ChangePasswordForm form = new ChangePasswordForm(acc);
        //    form.ShowDialog();
        //}

    }
}
