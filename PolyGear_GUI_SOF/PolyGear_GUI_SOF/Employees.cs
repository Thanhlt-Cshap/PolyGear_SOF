using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_SOF205;
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
using static PolyGear_DTO_SOF.AccountsDTO;

namespace PolyGear_GUI_SOF
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            btnHien.Visible = false;
            btnAn.Visible = false;


            dgvEmployee.CellFormatting += dgvEmployee_CellFormatting;
            dgvAccount.CellFormatting += dgvAccount_CellFormatting;

            LoadRoles();
            LoadDataToGrid();
            Load();
            ClearForm();


            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

        }

        private void Load()
        {
            EmployeesDAL EmployeesDAL = new EmployeesDAL();
            List<EmployeesDTO> danhSach = EmployeesDAL.selectAll()
                                                    .OrderByDescending(emp => emp.EmployeeID) // hoặc DateCreated nếu có
                                                    .ToList();

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
            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                Name = "Trạng thái"
            });

            // Đảm bảo cột "Trạng thái" là DataGridViewTextBoxColumn
            dgvEmployee.Columns["Trạng thái"].ValueType = typeof(string);



            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;


            dgvEmployee.DataSource = danhSach;



            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgvEmployee.Columns.Count)
                return;

            var columnName = dgvEmployee.Columns[e.ColumnIndex].Name;

            if (e.ColumnIndex >= 0 && dgvEmployee.Columns[e.ColumnIndex].Name == "Trạng thái" && e.Value != null)
            {
                if (bool.TryParse(e.Value.ToString(), out bool trangThai))
                {
                    e.Value = trangThai ? "Hoạt động" : "Nghỉ việc";
                    e.FormattingApplied = true;
                }
            }
        }

        private void ClearForm()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtMaTaiKhoan.Clear();
            dateTimePicker1.Value = DateTime.Now;
            rdoNam.Checked = true;
            rdoHoatDong.Checked = true;
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboVaiTro.SelectedIndex = -1;
            btnHien.Visible = false;
            btnAn.Visible = false;

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
            var accounts = accDAL.selectAccountsWithEmployee_DTO()
                                 .OrderByDescending(a => a.AccountID) // hoặc DateCreated nếu có
                                 .ToList();

            dgvAccount.AutoGenerateColumns = false;
            dgvAccount.Columns.Clear();

            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AccountID",
                HeaderText = "Mã tài khoản",
                Name = "AccountID"  // ← THÊM DÒNG NÀY
            }); dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Tên đăng nhập" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Password", HeaderText = "Mật khẩu" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoleID", HeaderText = "Mã vai trò" });
            dgvAccount.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoleName", HeaderText = "Vai trò" });
            dgvAccount.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái" });

            dgvAccount.DataSource = accounts;

        }
        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgvAccount.Columns.Count)
                return;

            var columnName = dgvAccount.Columns[e.ColumnIndex].HeaderText;

            if (columnName == "Mật khẩu" && e.Value != null)
            {
                string password = e.Value.ToString();
                e.Value = new string('*', password.Length);
                e.FormattingApplied = true;
            }
        }
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                var acc = dgvAccount.Rows[e.RowIndex].DataBoundItem as AccountsDTO;
                if (acc != null)
                {
                    // Gán giá trị cho các textbox tài khoản
                    txtMaTaiKhoan.Text = acc.AccountID;
                    txtUsername.Text = acc.Username;
                    txtPassword.Text = acc.Password;
                    cboVaiTro.SelectedValue = acc.RoleID;

                    // Kiểm tra tài khoản hiện tại
                    if (Session.CurrentAccountID != null && Session.CurrentAccountID == acc.AccountID)
                    {
                        btnHien.Visible = true;
                        btnAn.Visible = true;
                    }
                    else
                    {
                        btnHien.Visible = false;
                        btnAn.Visible = false;
                    }

                    // LẤY THÔNG TIN NHÂN VIÊN LIÊN KẾT VỚI TÀI KHOẢN
                    EmployeesDAL employeeDAL = new EmployeesDAL();
                    EmployeesDTO emp = employeeDAL.GetByAccountID(acc.AccountID);

                    if (emp != null)
                    {
                        // Gán thông tin nhân viên vào các textbox
                        txtMaNhanVien.Text = emp.EmployeeID;
                        txtHoTen.Text = emp.FullName;
                        dateTimePicker1.Value = emp.DateOfBirth;

                        // Gán giới tính
                        if (emp.Gender == "Nam")
                            rdoNam.Checked = true;
                        else if (emp.Gender == "Nữ")
                            rdoNu.Checked = true;

                        // Gán thông tin liên hệ
                        txtSDT.Text = emp.Phone;
                        txtEmail.Text = emp.Email;
                        txtDiaChi.Text = emp.Address;

                        // Gán trạng thái hoạt động
                        if (emp.Status)
                            rdoHoatDong.Checked = true;
                        else
                            rdoNghiViec.Checked = true;

                    }

                    tabConTrol.SelectedTab = TabCapNhat;
                }
            }
        }


        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                EmployeesDTO emp = (EmployeesDTO)dgvEmployee.Rows[e.RowIndex].DataBoundItem;

                LoadToForm(emp);

                string accountId = emp.AccountID;

                if (!string.IsNullOrEmpty(accountId))
                {
                    AccountDAL accDAL = new AccountDAL();
                    var acc = accDAL.selectById(accountId);

                    if (acc != null)
                    {
                        txtMaTaiKhoan.Text = acc.AccountID;
                        txtUsername.Text = acc.Username;
                        txtPassword.Text = acc.Password;
                        cboVaiTro.SelectedValue = acc.RoleID;

                        // ⚠️ Chỉ dùng để hiển thị (không ghi đè tài khoản đăng nhập)
                        // AuthUtil.user = acc;

                        // ✅ So sánh với tài khoản đang đăng nhập
                        if (accountId == Session.CurrentAccountID)
                        {
                            btnAn.Visible = true;
                            btnHien.Visible = true;
                        }
                        else
                        {
                            btnAn.Visible = false;
                            btnHien.Visible = false;
                        }
                    }
                }
                else
                {
                    txtMaTaiKhoan.Clear();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    cboVaiTro.SelectedIndex = -1;

                    // Không có tài khoản, ẩn luôn nút
                    btnAn.Visible = false;
                    btnHien.Visible = false;
                }

                tabConTrol.SelectedTab = TabCapNhat;
            }
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var accDAL = new AccountDAL();
                var account = GetAccountFromForm();

                if (account == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var danhSachTaiKhoan = accDAL.selectAll();
                bool isTrungUsername = danhSachTaiKhoan.Any(acc => acc.Username.Equals(account.Username, StringComparison.OrdinalIgnoreCase));
                if (isTrungUsername)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                account.AccountID = accDAL.GenerateNewAccountID();
                accDAL.insert(account);

                EmployeesDAL dal = new EmployeesDAL();
                EmployeesDTO emp = GetFormData();
                emp.AccountID = account.AccountID;

                emp.EmployeeID = dal.GenerateAutoEmployeeID();

                dal.insert(emp);

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load();
                LoadDataToGrid();
                ClearForm();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhân viên thất bại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Cập nhật nhân viên
                EmployeesDTO emp = GetFormData();
                EmployeesDAL dal = new EmployeesDAL();
                dal.update(emp);

                // 2. Cập nhật tài khoản
                AccountsDTO acc = GetAccountFromForm();
                if (acc != null)
                {
                    AccountDAL accDal = new AccountDAL();

                    // Kiểm tra trùng Username (trừ chính mình)
                    if (accDal.CheckDuplicateUsername(acc.Username, acc.AccountID))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    accDal.update(acc);
                }

                MessageBox.Show("Cập nhật nhân viên và tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Load();               // Load lại nhân viên
                LoadDataToGrid();     // Load lại tài khoản
                ClearForm();

                // Chọn lại dòng vừa cập nhật (nếu muốn)
                if (acc != null)
                {
                    foreach (DataGridViewRow row in dgvAccount.Rows)
                    {
                        if (row.Cells["AccountID"].Value != null && row.Cells["AccountID"].Value.ToString() == acc.AccountID)
                        {
                            row.Selected = true;
                            dgvAccount.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật nhân viên thất bại!\nChi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNhanVien.Text.Trim();
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa nhân viên này và tài khoản liên quan?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EmployeesDAL empDAL = new EmployeesDAL();
                    AccountDAL accDAL = new AccountDAL();

                    // Lấy thông tin nhân viên để biết AccountID
                    EmployeesDTO emp = empDAL.selectById(maNV);

                    if (emp == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 1. Xóa nhân viên trước
                    empDAL.delete(maNV);

                    // 2. Sau đó xóa tài khoản nếu có
                    if (!string.IsNullOrEmpty(emp.AccountID))
                    {
                        accDAL.delete(emp.AccountID);
                    }

                    MessageBox.Show("Xóa nhân viên và tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load();               // Load lại nhân viên
                    LoadDataToGrid();     // Load lại tài khoản (==> thêm dòng này!)
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void tabConTrol_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabConTrol.SelectedTab == tabDanhSach)
            {
                Load();
                LoadDataToGrid();     // Load lại tài khoản (==> thêm dòng này!)
            }
        }

        private AccountsDTO GetAccountFromForm()
        {
            if (
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cboVaiTro.SelectedValue == null)
            {
                return null; // chưa nhập đủ
            }

            return new AccountsDTO
            {
                AccountID = txtMaTaiKhoan.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                RoleID = cboVaiTro.SelectedValue.ToString(),
                Status = true // mặc định active
            };
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnHien.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnAn.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }
        private void Employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // → đảm bảo app thoát luôn
        }

    }
}


