using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyGear_GUI_SOF
{
    public partial class CustomerManagementForm : Form
    {
        public CustomerManagementForm()
        {
            InitializeComponent();
            LoadDataGridView(); // Tải dữ liệu vào DataGridView khi khởi tạo form
            ClearForm(); // Xóa dữ liệu trong form khi khởi tạo
        }
        private void LoadDataGridView()
        { 
            

            //ProductTypeDAL productTypeDAL = new ProductTypeDAL();
            //List<ProductTypesDTO> productTypes = productTypeDAL.selectAll();
            CustomerDAL customerDAL = new CustomerDAL();
            List<Customers> customers = customerDAL.selectAll();

            // Sắp xếp danh sách theo mã loại sản phẩm giảm dần trước khi gán vào DataSource
            var sortedCustomers = customers
                .OrderByDescending(pt => pt.CustomerID)
                .ToList();

            dgvKhachHang.DataSource = null; // Reset DataSource để tránh lỗi hiển thị
            dgvKhachHang.DataSource = sortedCustomers;

            // Sắp xếp danh sách theo mã khách hàng giảm dần trước khi gán vào DataSource
            dgvKhachHang.Columns["CustomerID"].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns["FullName"].HeaderText = "Họ Tên";
            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["Phone"].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns["Address"].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns["RegisterDate"].HeaderText = "Ngày Đăng Ký";
            dgvKhachHang.Columns["Status"].HeaderText = "Trạng Thái";


        }

        private void ClearForm()
        {
            txtMaKhachHang.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            dtpNgayDangKy.Value = DateTime.Now;
            chkHoatDong.Checked = true;

            // mở thêm
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            LoadDataGridView(); // Tải lại dữ liệu vào DataGridView

        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                string CustomerID = customerDAL.generateAutoCustomer();

                string FullName = txtHoTen.Text.Trim();
                string Email = txtEmail.Text.Trim();
                string Phone = txtSoDienThoai.Text.Trim();
                string Address = txtDiaChi.Text.Trim();
                DateTime RegistrationDate = dtpNgayDangKy.Value;
                bool Status = chkHoatDong.Checked;
                if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Address))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // bắt lỗi email, số điện thoại, tên khách hàng ( không để trống, không có ký tự đặc biệt, có dấu) 
                if (!Email.Contains("@") || !Email.Contains("."))
                {
                    MessageBox.Show("Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Phone.Length < 10 || Phone.Length > 13 || !Phone.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(FullName) || FullName.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                {
                    MessageBox.Show("Tên khách hàng không hợp lệ. Vui lòng nhập tên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // bắt lỗi ngày đăng ký (không được để trống, không được lớn hơn ngày hiện tại và ở ngày quá khứ)
                if (RegistrationDate > DateTime.Now)
                {
                    MessageBox.Show("Ngày đăng ký không hợp lệ. Không được chọn ngày ở tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //// không được ở quá khứ
                //if (RegistrationDate <DateTime.Now)
                //{
                //    MessageBox.Show("Ngày đăng ký không hợp lệ. Không được chọn ngày ở quá khứ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}





                Customers newCustomer = new Customers
                {
                    CustomerID = CustomerID,
                    FullName = FullName,
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    RegisterDate = RegistrationDate,
                    Status = Status
                };
                customerDAL.insert(newCustomer);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                // Cập nhật lại DataGridView
                LoadDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy mã khách hàng từ ô nhập liệu
            string customerID = txtMaKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(customerID))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                // Kiểm tra xem khách hàng có tồn tại không
                Customers existingCustomer = customerDAL.selectById(customerID);
                if (existingCustomer == null)
                {
                    MessageBox.Show("Khách hàng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Cập nhật thông tin khách hàng
                existingCustomer.FullName = txtHoTen.Text.Trim();
                existingCustomer.Email = txtEmail.Text.Trim();
                existingCustomer.Phone = txtSoDienThoai.Text.Trim();
                existingCustomer.Address = txtDiaChi.Text.Trim();
                existingCustomer.RegisterDate = dtpNgayDangKy.Value;
                existingCustomer.Status = chkHoatDong.Checked;

                // bắt lỗi ngày đăng ký 
                if (existingCustomer.RegisterDate > DateTime.Now)
                {
                    MessageBox.Show("Ngày đăng ký không hợp lệ. Không được chọn ngày ở tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                


                customerDAL.update(existingCustomer);
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                // Cập nhật lại DataGridView
                LoadDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy mã khách hàng từ ô nhập liệu
                string customerID = txtMaKhachHang.Text.Trim();
                if (string.IsNullOrEmpty(customerID))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CustomerDAL customerDAL = new CustomerDAL();
                // Kiểm tra xem khách hàng có tồn tại không
                Customers existingCustomer = customerDAL.selectById(customerID);
                if (existingCustomer == null)
                {
                    MessageBox.Show("Khách hàng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    customerDAL.delete(customerID);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    // Cập nhật lại DataGridView
                    LoadDataGridView();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKhachHang.Text = row.Cells["CustomerID"].Value.ToString();
                txtHoTen.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["Phone"].Value.ToString();
                txtDiaChi.Text = row.Cells["Address"].Value.ToString();
                dtpNgayDangKy.Value = Convert.ToDateTime(row.Cells["RegisterDate"].Value);
                chkHoatDong.Checked = Convert.ToBoolean(row.Cells["Status"].Value);
            }
            // khi nhấn chọn vào một hàng trong DataGridView, nút sửa và xóa sẽ được kích hoạt và tắt thêm
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }
        private void SearchCustomer()
        {
            string keyword = txtTimKiem.Text.Trim();
            CustomerDAL customerDAL = new CustomerDAL();
            string sql = @"SELECT * FROM Customers 
                           WHERE FullName LIKE @0 OR Email LIKE @1 OR Phone LIKE @2";
            List<object> args = new List<object>
            {
                "%" + keyword + "%",
                "%" + keyword + "%",
                "%" + keyword + "%"
            };
            var result = customerDAL.selectBySql(sql, args);
            dgvKhachHang.DataSource = result;
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void dtpNgayDangKy_ValueChanged(object sender, EventArgs e)
        {
            


        }
    }
}
