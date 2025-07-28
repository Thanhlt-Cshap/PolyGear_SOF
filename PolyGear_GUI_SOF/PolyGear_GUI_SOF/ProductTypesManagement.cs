using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;


namespace PolyGear_GUI_SOF
{
    public partial class ProductTypesManagement : Form
    {


        public ProductTypesManagement()
        {
            InitializeComponent();
            LoadData(); // Gọi hàm để tải dữ liệu khi form được khởi tạo
            ClearForm(); // Gọi hàm để làm sạch form khi khởi tạo
        }

        private void ClearForm()
        {
            txtMaLoai.Text = string.Empty;
            txtTenLoai.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            rdoHoatDong.Checked = true; // Đặt trạng thái hoạt động mặc định
            txtGhiChu.ScrollBars = ScrollBars.None; // Đặt thanh cuộn của TextBox mô tả về None

            btnSua.Enabled = false; // Vô hiệu hóa nút sửa khi làm sạch form
            btnXoa.Enabled = false; // Vô hiệu hóa nút xóa khi làm sạch form
            btnThem.Enabled = true; // Kích hoạt nút thêm khi làm sạch form
        }

        private void LoadData()
        {
            try
            {
                ProductTypeDAL productTypeDAL = new ProductTypeDAL();
                List<ProductTypesDTO> productTypes = productTypeDAL.selectAll();

                // Sắp xếp danh sách theo mã loại sản phẩm giảm dần trước khi gán vào DataSource
                var sortedProductTypes = productTypes
                    .OrderByDescending(pt => pt.ProductTypeID)
                    .ToList();

                dgvDSLoaiSanPham.DataSource = null; // Reset DataSource để tránh lỗi hiển thị
                dgvDSLoaiSanPham.DataSource = sortedProductTypes;

                // Đổi tên cột trong DataGridView sau khi gán DataSource
                dgvDSLoaiSanPham.Columns["ProductTypeID"].HeaderText = "Mã Loại Sản Phẩm";
                dgvDSLoaiSanPham.Columns["ProductTypeName"].HeaderText = "Tên Loại Sản Phẩm";
                dgvDSLoaiSanPham.Columns["Description"].HeaderText = "Ghi Chú";
                dgvDSLoaiSanPham.Columns["Status"].HeaderText = "Trạng Thái";
                dgvDSLoaiSanPham.Columns["Description"].Visible = false; // Ẩn cột mô tả
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            txtGhiChu.ScrollBars = ScrollBars.Vertical; // cho phép cuộn dọc trong TextBox
            txtGhiChu.Multiline = true; // cho phép nhập nhiều dòng trong TextBox
        }

        private void ProductTypesManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // mã loại tự động tăng
                ProductTypeDAL productTypeDAL = new ProductTypeDAL();
                ProductTypesDTO newProductType = new ProductTypesDTO
                {
                    ProductTypeID = productTypeDAL.generateAutoProductType(), // Gọi hàm để tự động sinh mã loại sản phẩm
                    ProductTypeName = txtTenLoai.Text,
                    Description = txtGhiChu.Text,
                    Status = rdoHoatDong.Checked // true nếu hoạt động, false nếu không hoạt động
                };
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(newProductType.ProductTypeName))
                {
                    MessageBox.Show("Tên loại sản phẩm không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // kiểm tra mô tả
                if (string.IsNullOrWhiteSpace(newProductType.Description))
                {
                    MessageBox.Show("Mô tả không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem loại sản phẩm đã tồn tại chưa
                List<ProductTypesDTO> existingProductTypes = productTypeDAL.selectAll();
                if (existingProductTypes.Any(pt => pt.ProductTypeName.Equals(newProductType.ProductTypeName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Loại sản phẩm đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                productTypeDAL.insert(newProductType); // Thêm loại sản phẩm mới vào cơ sở dữ liệu
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại dữ liệu để hiển thị loại sản phẩm mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDSLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDSLoaiSanPham.Rows.Count)
            {
                // Lấy dữ liệu từ dòng đã chọn
                DataGridViewRow selectedRow = dgvDSLoaiSanPham.Rows[e.RowIndex];
                txtMaLoai.Text = selectedRow.Cells["ProductTypeID"].Value.ToString();
                txtTenLoai.Text = selectedRow.Cells["ProductTypeName"].Value.ToString();
                txtGhiChu.Text = selectedRow.Cells["Description"].Value.ToString();
                rdoHoatDong.Checked = Convert.ToBoolean(selectedRow.Cells["Status"].Value); // Đặt trạng thái hoạt động

                // Kích hoạt nút sửa và xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false; // Vô hiệu hóa nút thêm khi đã chọn loại sản phẩm để sửa hoặc xóa
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm(); // Gọi hàm để làm sạch form
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn loại sản phẩm để sửa chưa
                if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProductTypeDAL productTypeDAL = new ProductTypeDAL();
                ProductTypesDTO updatedProductType = new ProductTypesDTO
                {
                    ProductTypeID = txtMaLoai.Text,
                    ProductTypeName = txtTenLoai.Text,
                    Description = txtGhiChu.Text,
                    Status = rdoHoatDong.Checked // true nếu hoạt động, false nếu không hoạt động
                };
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(updatedProductType.ProductTypeName))
                {
                    MessageBox.Show("Tên loại sản phẩm không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // kiểm tra mô tả
                if (string.IsNullOrWhiteSpace(updatedProductType.Description))
                {
                    MessageBox.Show("Mô tả không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra xem loại sản phẩm đã tồn tại chưa
                List<ProductTypesDTO> existingProductTypes = productTypeDAL.selectAll();
                if (existingProductTypes.Any(pt => pt.ProductTypeName.Equals(updatedProductType.ProductTypeName, StringComparison.OrdinalIgnoreCase) && pt.ProductTypeID != updatedProductType.ProductTypeID))
                {
                    MessageBox.Show("Loại sản phẩm đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // xác nhận sửa loại sản phẩm
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa loại sản phẩm này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // Sửa lại điều kiện xác nhận
                {
                    productTypeDAL.update(updatedProductType); // Cập nhật loại sản phẩm trong cơ sở dữ liệu
                    MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Tải lại dữ liệu để hiển thị danh sách loại sản phẩm đã cập nhật
                    ClearForm(); // Làm sạch form sau khi sửa
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn loại sản phẩm để xóa chưa
                if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProductTypeDAL productTypeDAL = new ProductTypeDAL();
                string productTypeIdToDelete = txtMaLoai.Text;
                // Kiểm tra xem loại sản phẩm có tồn tại trong cơ sở dữ liệu không
                ProductTypesDTO productTypeToDelete = productTypeDAL.selectById(productTypeIdToDelete);
                if (productTypeToDelete == null)
                {
                    MessageBox.Show("Loại sản phẩm không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // kiểm tra xem loại sản phẩm có sản phẩm con không
                ProductDAL productDAL = new ProductDAL();
                string sqlCheckChild = "SELECT COUNT(*) FROM Products WHERE ProductTypeID = @0";
                List<object> paramCheckChild = new List<object> { productTypeIdToDelete };
                object childCountObj = PolyGear_UTIL_SOF.DBUtil.ScalarQuery(sqlCheckChild, paramCheckChild);
                int childCount = childCountObj != null ? Convert.ToInt32(childCountObj) : 0;
                if (childCount > 0)
                {
                    MessageBox.Show("Không thể xóa loại sản phẩm này vì đang có sản phẩm thuộc loại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Xác nhận xóa loại sản phẩm
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // Sửa lại điều kiện xác nhận
                {
                    productTypeDAL.delete(productTypeIdToDelete); // Xóa loại sản phẩm khỏi cơ sở dữ liệu
                    MessageBox.Show("Xóa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Tải lại dữ liệu để hiển thị danh sách loại sản phẩm đã cập nhật
                    ClearForm(); // Làm sạch form sau khi xóa
                }
                // Nếu người dùng không xác nhận, thoát khỏi hàm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox
            if (!string.IsNullOrEmpty(searchTerm))
            {
                SearchProductType(searchTerm); // Gọi hàm tìm kiếm loại sản phẩm
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void SearchProductType(string searchTerm)
        {
            try
            {
                ProductTypeDAL productTypeDAL = new ProductTypeDAL();
                string sql = "SELECT * FROM ProductTypes WHERE ProductTypeName LIKE @0 OR ProductTypeID LIKE @1";
                List<object> parameters = new List<object> { "%" + searchTerm + "%", "%" + searchTerm + "%" };
                List<ProductTypesDTO> searchResults = productTypeDAL.selectBySql(sql, parameters);
                dgvDSLoaiSanPham.DataSource = searchResults; // Cập nhật DataGridView với kết quả tìm kiếm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSLoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
