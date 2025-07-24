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
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace PolyGear_GUI_SOF
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }
        private void Load()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            List<EmployeesDTO> danhSach = employeeDAL.selectAll();

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.Columns.Clear();

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployeeID", Name = "Mã nhân viên" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", Name = "Họ tên" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateOfBirth", Name = "Ngày sinh" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", Name = "Giới tính" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", Name = "SĐT" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", Name = "Email" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", Name = "Địa chỉ" });
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AccountID", Name = "Mã tài khoản" });
            dgvEmployee.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Status", Name = "Trạng thái" });

            dgvEmployee.DataSource = danhSach;
            dgvEmployee.CellFormatting += dgvEmployee_CellFormatting;


        }
        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvEmployee.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                if (bool.TryParse(e.Value.ToString(), out bool trangThai))
                {
                    e.Value = trangThai ? "Hoạt động" : "Nghỉ việc";
                    e.FormattingApplied = true;
                }
            }
        }
        private void LoadRoles()
        {
            RoleDAL roleDAL = new RoleDAL();
            var list = roleDAL.selectAll();

            cboVaiTro.DataSource = list;
            cboVaiTro.DisplayMember = "RoleName";
            cboVaiTro.ValueMember = "RoleID";
        }

        private void LoadToForm(EmployeesDTO emp)
        {
            txtMaNhanVien.Text = emp.EmployeeID;
            txtHoTen.Text = emp.FullName;
            dateTimePicker1.Value = (DateTime)emp.DateOfBirth;

            if (emp.Gender == "Nam")
                rdoNam.Checked = true;
            else if (emp.Gender == "Nữ")
                rdoNu.Checked = true;

            txtSDT.Text = emp.Phone;
            txtEmail.Text = emp.Email;
            txtDiaChi.Text = emp.Address;

            if (emp.Status)
                rdoHoatDong.Checked = true;
            else
                rdoNghiViec.Checked = true;
        }
        private void ClearForm()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtMaTaiKhoan.Clear();
            dateTimePicker1.Value = DateTime.Now;
            rdoNam.Checked = true;       // Giới tính mặc định
            rdoHoatDong.Checked = true;  // Trạng thái mặc định
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboVaiTro.SelectedIndex = -1; // ✅ bỏ chọn item

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            Load();              // Load lại danh sách nhân viên
            LoadDataToGrid();
        }
        private EmployeesDTO GetFormData()
        {
            EmployeesDTO emp = new EmployeesDTO();

            emp.EmployeeID = txtMaNhanVien.Text.Trim();
            emp.AccountID = txtMaTaiKhoan.Text.Trim();
            emp.FullName = txtHoTen.Text.Trim();
            emp.DateOfBirth = dateTimePicker1.Value;

            // Giới tính
            if (rdoNam.Checked)
                emp.Gender = "Nam";
            else if (rdoNu.Checked)
                emp.Gender = "Nữ";

            emp.Phone = txtSDT.Text.Trim();
            emp.Email = txtEmail.Text.Trim();
            emp.Address = txtDiaChi.Text.Trim();


            // Trạng thái
            emp.Status = rdoHoatDong.Checked ? true : false;

            return emp;
        }

        private void LoadDataToGrid()
        {
            AccountDAL accDAL = new AccountDAL();
            var accounts = accDAL.selectAccountsWithEmployee_DTO();

            dgvAccount.AutoGenerateColumns = false;
            dgvAccount.Columns.Clear();

            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AccountID", HeaderText = "Mã tài khoản" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Tên đăng nhập" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Password", HeaderText = "Mật khẩu" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoleID", HeaderText = "Mã vai trò" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoleName", HeaderText = "Vai trò" });
            dgvAccount.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái" });

            dgvAccount.DataSource = accounts;
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var acc = dgvAccount.Rows[e.RowIndex].DataBoundItem as AccountsDTO;

                if (acc != null)
                {
                    // Tài khoản
                    txtMaTaiKhoan.Text = acc.AccountID;
                    txtUsername.Text = acc.Username;
                    txtPassword.Text = acc.Password;
                    cboVaiTro.SelectedValue = acc.RoleID;

                    // Nhân viên (nếu có thông tin Employee)
                    if (acc.EmployeeInfo != null)
                    {
                        var emp = acc.EmployeeInfo;

                        txtMaNhanVien.Text = emp.EmployeeID;
                        txtHoTen.Text = emp.FullName;
                        txtEmail.Text = emp.Email;
                        txtSDT.Text = emp.Phone;
                        txtDiaChi.Text = emp.Address;
                        dateTimePicker1.Value = emp.DateOfBirth;

                        rdoNam.Checked = emp.Gender == "Nam";
                        rdoNu.Checked = emp.Gender == "Nữ";

                        rdoHoatDong.Checked = emp.Status;
                        rdoNghiViec.Checked = !emp.Status;
                    }

                    tabConTrol.SelectedTab = TabCapNhat;
                }
            }
        }

    }
}
