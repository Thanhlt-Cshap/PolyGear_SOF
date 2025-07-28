using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
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
    public partial class ManufacturerManagementForm : Form
    {
        public ManufacturerManagementForm()
        {
            InitializeComponent();
            LoadData();
            ClearForm();

        }
        private void ClearForm()
        {
            txtMaHangSX.Text = string.Empty;
            txtTenHangSX.Text = string.Empty;
            chkHoatDong.Checked = true;
            txtTimKiem.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void LoadData()
        {
            try
            {
                ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
                List<ManufacturersDTO> manufacturers = manufacturerDAL.selectAll();
                // Sắp xếp danh sách theo mã loại sản phẩm giảm dần trước khi gán vào DataSource
                manufacturers.Sort((x, y) => string.Compare(y.ManufacturerID, x.ManufacturerID, StringComparison.Ordinal));
                dgvHangSX.DataSource = manufacturers;
                dgvHangSX.Columns["ManufacturerID"].HeaderText = "Mã Hãng Sản Xuất";
                dgvHangSX.Columns["ManufacturerName"].HeaderText = "Tên Hãng Sản Xuất";
                dgvHangSX.Columns["Status"].HeaderText = "Trạng Thái";

                // ẩn cột Description nếu không cần thiết
                dgvHangSX.Columns["Description"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ManufacturerManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
                ManufacturersDTO manufacturer = new ManufacturersDTO
                {
                    ManufacturerID = manufacturerDAL.generateAutoManufacturer(),
                    ManufacturerName = txtTenHangSX.Text.Trim(),
                    Description = txtGhiChu.Text.Trim(),
                    Status = chkHoatDong.Checked
                };
                // Kiểm tra thông tin nhập vào.
                if (string.IsNullOrEmpty(manufacturer.ManufacturerName))
                {
                    MessageBox.Show("Vui lòng nhập tên hãng sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(manufacturer.Description))
                {
                    MessageBox.Show("Vui lòng nhập mô tả cho hãng sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra xem tên hãng sản xuất đã tồn tại hay chưa
                List<ManufacturersDTO> existingManufacturers = manufacturerDAL.selectBySql("SELECT * FROM Manufacturers WHERE ManufacturerName = @0", new List<object> { manufacturer.ManufacturerName });
                if (existingManufacturers.Count > 0)
                {
                    MessageBox.Show("Tên hãng sản xuất đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                manufacturerDAL.insert(manufacturer);
                MessageBox.Show("Thêm hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hãng sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy mã hãng sản xuất từ textbox
                string maHangSX = txtMaHangSX.Text.Trim();
                if (string.IsNullOrEmpty(maHangSX))
                {
                    MessageBox.Show("Vui lòng nhập mã hãng sản xuất để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
                ManufacturersDTO manufacturer = manufacturerDAL.selectById(maHangSX);
                if (manufacturer == null)
                {
                    MessageBox.Show("Hãng sản xuất không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // báo lên không thể xóa hãng sản xuất nếu có sản phẩm liên kết
                ProductDAL productDAL = new ProductDAL();
                List<ProductsDTO> products = productDAL.selectBySql("SELECT * FROM Products WHERE ManufacturerID = @0", new List<object> { maHangSX });
                if (products.Count > 0)
                {
                    MessageBox.Show("Không thể xóa hãng sản xuất này vì có sản phẩm liên kết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hãng sản xuất này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    manufacturerDAL.delete(maHangSX);
                    MessageBox.Show("Xóa hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hãng sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string manufacturerID = txtMaHangSX.Text.Trim();
                string manufacturerName = txtTenHangSX.Text.Trim();
                string description = txtGhiChu.Text.Trim();
                bool status = chkHoatDong.Checked;
                if (string.IsNullOrEmpty(manufacturerID) || string.IsNullOrEmpty(manufacturerName) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hãng sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
                ManufacturersDTO manufacturer = manufacturerDAL.selectById(manufacturerID);
                if (manufacturer == null)
                {
                    MessageBox.Show("Hãng sản xuất không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                manufacturer.ManufacturerName = manufacturerName;
                manufacturer.Status = status;
                manufacturerDAL.update(manufacturer);
                MessageBox.Show("Sửa hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hãng sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchManufacturerForm()
        {
            string searchTerm = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
                string sql = "SELECT * FROM Manufacturers WHERE ManufacturerName LIKE @0";
                List<object> args = new List<object> { "%" + searchTerm + "%" };
                List<ManufacturersDTO> manufacturers = manufacturerDAL.selectBySql(sql, args);
                if (manufacturers.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hãng sản xuất nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvHangSX.DataSource = manufacturers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hãng sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchManufacturerForm();
        }

        private void dgvHangSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvHangSX.Rows.Count)
                {
                    DataGridViewRow row = dgvHangSX.Rows[e.RowIndex];
                    txtMaHangSX.Text = row.Cells["ManufacturerID"].Value.ToString();
                    txtTenHangSX.Text = row.Cells["ManufacturerName"].Value.ToString();
                    chkHoatDong.Checked = Convert.ToBoolean(row.Cells["Status"].Value);
                    txtGhiChu.Text = row.Cells["Description"].Value != null ? row.Cells["Description"].Value.ToString() : string.Empty; // Lấy mô tả nếu có
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hãng sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }


    }
}
