using PolyGear_UTIL_SOF;
using PolyGear_DAL_SOF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyGear_DTO_SOF;

namespace PolyGear_GUI_SOF
{
    public partial class ProductsManagement : Form
    {
        private ProductDAL sanPhamDAL = new ProductDAL();

        public ProductsManagement()
        {
            InitializeComponent();
            ClearForm();
            LoadData();

        }

        private void ClearForm()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtGhiChu.Clear();
            txtDonGia.Clear();
            txtDonGia.Clear();
            cboLoaiSanPham.SelectedIndex = -1;
            cboHangSanXuat.SelectedIndex = -1;
            picHinhAnh.Image = null;
            txtSoLuongTonKho.Clear();

            // tắt sửa và xóa 
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            // bật thêm
            btnThem.Enabled = true;


        }
        private void LoadData()
        {
            try
            {
                List<ProductsDTO> list = sanPhamDAL.selectAll();
                ImageUtil imageUtil = new ImageUtil();
                var productList = list.Select(sp => new
                {
                    sp.ProductID,
                    sp.ProductName,
                    sp.ProductTypeID,
                    sp.ManufacturerID,
                    sp.UnitPrice,
                    sp.Stock,
                    sp.Description,
                    sp.Status,
                    ImagePath = imageUtil.load(sp.ImagePath) // Convert string to Image
                }).ToList();
                dgvDSSanPham.DataSource = productList;
                if (dgvDSSanPham.Columns["Image"] is DataGridViewImageColumn imageColumn)
                {
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                dgvDSSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ẩn cột mô tả
                if (dgvDSSanPham.Columns.Contains("Description"))
                {
                    dgvDSSanPham.Columns["Description"].Visible = false; // Ẩn cột mô tả
                }

                // sắp xếp theo mã sản phẩm


                // đặt tiêu đề cho các cột
                dgvDSSanPham.Columns["ProductID"].HeaderText = "Mã sản phẩm";
                dgvDSSanPham.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvDSSanPham.Columns["ProductTypeID"].HeaderText = "Mã loại sản phẩm";
                dgvDSSanPham.Columns["ManufacturerID"].HeaderText = "Mã hãng sản xuất";
                dgvDSSanPham.Columns["UnitPrice"].HeaderText = "Đơn giá";
                dgvDSSanPham.Columns["Stock"].HeaderText = "Số lượng tồn kho";
                dgvDSSanPham.Columns["Status"].HeaderText = "Trạng thái";
                dgvDSSanPham.Columns["ImagePath"].HeaderText = "Hình ảnh";



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = sanPhamDAL.generateAutoProductID();
                txtMaSanPham.Text = maSanPham; // Hiển thị mã sản phẩm tự động lên TextBox
                string tenSanPham = txtTenSanPham.Text.Trim();
                string maLoaiSanPham = cboLoaiSanPham.SelectedValue.ToString();
                string maHangSanXuat = cboHangSanXuat.SelectedValue.ToString();
                decimal donGia;
                // kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi");
                    return;
                }
                if (string.IsNullOrEmpty(maLoaiSanPham))
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi");
                    return;
                }
                if (string.IsNullOrEmpty(maHangSanXuat))
                {
                    MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi");
                    return;
                }
                // kiểm tra định dạng đơn giá
                if (string.IsNullOrEmpty(txtDonGia.Text.Trim()))
                {
                    MessageBox.Show("Đơn giá không được để trống.", "Lỗi");
                    return;
                }
                // kiểm coi đơn giá có để trống hay không
                if (string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Đơn giá không được để trống.", "Lỗi");
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi");
                    return;
                }
                // đơn giá phải lớn hơn 0
                if (donGia <= 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0.", "Lỗi");
                    return;
                }
                int soLuongTonKho;
                if (!int.TryParse(txtSoLuongTonKho.Text.Trim(), out soLuongTonKho
                        ))
                {
                    MessageBox.Show("Số lượng tồn kho không hợp lệ.", "Lỗi");
                    return;
                }
                string ghiChu = txtGhiChu.Text.Trim();
                bool trangThai = rdoHoatDong.Checked; // Lấy trạng thái từ 


                string saveImageName = "";
                if (picHinhAnh.Image != null) // Kiểm tra xem hình ảnh có được chọn hay không
                {
                    string selectedImagePath = picHinhAnh.ImageLocation; // Lấy đường dẫn hình ảnh đã chọn

                    // Mở hộp thoại chọn hình ảnh
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        FileName = selectedImagePath
                    };

                    // Kiểm tra xem người dùng có chọn hình ảnh không 
                    try
                    {
                        ImageUtil imageUtil = new ImageUtil();
                        saveImageName = imageUtil.save(openFileDialog); // Lưu hình ảnh và lấy tên file đã lưu
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chọn hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                // kiểm tra coi bạn đã chọn hình ảnh hay chưa
                if (string.IsNullOrEmpty(saveImageName))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm.", "Lỗi");
                    return;
                }

                // Tạo đối tượng sản phẩm mới
                ProductsDTO newProduct = new ProductsDTO
                {
                    ProductID = maSanPham,
                    ProductName = tenSanPham,
                    ProductTypeID = maLoaiSanPham,
                    ManufacturerID = maHangSanXuat,
                    UnitPrice = donGia,
                    Stock = soLuongTonKho,
                    Description = ghiChu,
                    ImagePath = saveImageName, // Lưu tên file hình ảnh đã lưu
                    Status = trangThai
                };
                // Thêm sản phẩm vào cơ sở dữ liệu
                ProductDAL productDAL = new ProductDAL();
                sanPhamDAL.insert(newProduct);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
                ClearForm(); // Xóa form sau khi thêm sản phẩm
                LoadData(); // Tải lại dữ liệu để hiển thị sản phẩm mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = txtMaSanPham.Text.Trim();
                string tenSanPham = txtTenSanPham.Text.Trim();
                string maLoaiSanPham = cboLoaiSanPham.SelectedValue?.ToString();
                string maHangSanXuat = cboHangSanXuat.SelectedValue?.ToString();
                decimal donGia;
                string ghiChu = txtGhiChu.Text.Trim();
                bool trangThai = rdoHoatDong.Checked; // Lấy trạng thái từ RadioButton
                if (trangThai)
                {
                    trangThai = true; // Hoạt động
                }
                else
                {
                    trangThai = false; // Ngừng bán
                }
                // kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống.", "Lỗi");
                    return;
                }
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi");
                    return;
                }
                if (string.IsNullOrEmpty(maLoaiSanPham))
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi");
                    return;
                }
                if (string.IsNullOrEmpty(maHangSanXuat))
                {
                    MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi");
                    return;
                }
                // kiểm tra định dạng đơn giá
                if (string.IsNullOrEmpty(txtDonGia.Text.Trim()))
                {
                    MessageBox.Show("Đơn giá không được để trống.", "Lỗi");
                    return;
                }
                // kiểm coi đơn giá có để trống hay không
                if (string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Đơn giá không được để trống.", "Lỗi");
                    return;
                }
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi");
                    return;
                }
                // đơn giá phải lớn hơn 0
                if (donGia <= 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0.", "Lỗi");
                    return;
                }
                int soLuongTonKho;
                if (!int.TryParse(txtSoLuongTonKho.Text.Trim(), out soLuongTonKho
                        ))
                {
                    MessageBox.Show("Số lượng tồn kho không hợp lệ.", "Lỗi");
                    return;
                }

                string saveImageName = "";
                if (picHinhAnh.Image != null && !string.IsNullOrEmpty(picHinhAnh.ImageLocation))
                {
                    // Nếu người dùng vừa chọn ảnh mới
                    try
                    {
                        ImageUtil imageUtil = new ImageUtil();
                        OpenFileDialog openFileDialog = new OpenFileDialog
                        {
                            FileName = picHinhAnh.ImageLocation
                        };
                        saveImageName = imageUtil.save(openFileDialog); // Lưu hình ảnh và lấy tên file đã lưu
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chọn hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Nếu không chọn lại ảnh, lấy ảnh cũ từ DB
                    var spCu = sanPhamDAL.selectById(maSanPham);
                    if (spCu != null)
                        saveImageName = spCu.ImagePath ?? "";
                }

                // Tạo đối tượng sản phẩm mới
                ProductsDTO updatedProduct = new ProductsDTO
                {
                    ProductID = maSanPham,
                    ProductName = tenSanPham,
                    ProductTypeID = maLoaiSanPham,
                    ManufacturerID = maHangSanXuat,
                    UnitPrice = donGia,
                    Stock = soLuongTonKho,
                    Description = ghiChu,
                    ImagePath = saveImageName, // Lưu tên file hình ảnh đã lưu
                    Status = trangThai
                };
                // Cập nhật sản phẩm vào cơ sở dữ liệu
                ProductDAL productDAL = new ProductDAL();
                sanPhamDAL.update(updatedProduct);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo");
                ClearForm(); // Xóa form sau khi cập nhật sản phẩm
                LoadData(); // Tải lại dữ liệu để hiển thị sản phẩm đã cập nhật

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi");
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSanPham = txtMaSanPham.Text.Trim();
            if (string.IsNullOrEmpty(maSanPham))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Lỗi");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    sanPhamDAL.delete(maSanPham);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo");
                    ClearForm(); // Xóa form sau khi xóa sản phẩm
                    LoadData(); // Tải lại dữ liệu để hiển thị danh sách sản phẩm mới
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm(); // Xóa form cập nhật
        }

        private void ProductsManagement_Load(object sender, EventArgs e)
        {
            //LoaiSanPhamDAL loaiSanPhamDAL = new LoaiSanPhamDAL();
            //List<LoaiSanPham> listLoaiSanPham = loaiSanPhamDAL.selectAll(); // Lấy danh sách loại sản phẩm
            //cboLoaiSanPham.DataSource = listLoaiSanPham; // Gán danh sách vào ComboBox
            //cboLoaiSanPham.DisplayMember = "TenLoai"; // Thuộc tính hiển thị trong ComboBox
            //cboLoaiSanPham.ValueMember = "MaLoai"; // Thuộc tính giá trị của ComboBox
            try
            {
                ProductTypeDAL loaiSanPhamDAL = new ProductTypeDAL();
                List<ProductTypesDTO> listLoaiSanPham = loaiSanPhamDAL.selectAll(); // Lấy danh sách loại sản phẩm
                cboLoaiSanPham.DataSource = listLoaiSanPham; // Gán danh sách vào ComboBox
                cboLoaiSanPham.DisplayMember = "ProductTypeName"; // Thuộc tính hiển thị trong ComboBox
                cboLoaiSanPham.ValueMember = "ProductTypeID"; // Thuộc tính giá trị của ComboBox
                ManufacturerDAL hangSanXuatDAL = new ManufacturerDAL();
                List<ManufacturersDTO> listHangSanXuat = hangSanXuatDAL.selectAll(); // Lấy danh sách nhà sản xuất
                cboHangSanXuat.DataSource = listHangSanXuat; // Gán danh sách vào ComboBox
                cboHangSanXuat.DisplayMember = "ManufacturerName"; // Thuộc tính hiển thị trong ComboBox
                cboHangSanXuat.ValueMember = "ManufacturerID"; // Thuộc tính giá trị của ComboBox


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void dgvDSSanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the clicked row is valid
            {
                DataGridViewRow row = dgvDSSanPham.Rows[e.RowIndex];
                txtMaSanPham.Text = row.Cells["ProductID"].Value?.ToString();
                txtTenSanPham.Text = row.Cells["ProductName"].Value?.ToString();
                cboLoaiSanPham.SelectedValue = row.Cells["ProductTypeID"].Value;
                cboHangSanXuat.SelectedValue = row.Cells["ManufacturerID"].Value;
                txtDonGia.Text = row.Cells["UnitPrice"].Value?.ToString();
                txtSoLuongTonKho.Text = row.Cells["Stock"].Value?.ToString();
                txtGhiChu.Text = row.Cells["Description"].Value?.ToString();
                rdoHoatDong.Checked = row.Cells["Status"].Value?.ToString() == "Hoạt động";
                rdoNgungBan.Checked = !rdoHoatDong.Checked;

                // Load image if available
                if (row.Cells["ImagePath"].Value is Image image)
                {
                    picHinhAnh.Image = image;
                }
                else
                {
                    picHinhAnh.Image = null;
                }

                //// Xử lý hình ảnh nếu có
                //// đặt sizeMode để hình fit vào ô
                picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                //lấy đường dẫn hình ảnh từ cột HinhAnh
                if (row.Cells["ImagePath"].Value != null && row.Cells["ImagePath"].Value is Image)
                {
                    picHinhAnh.Image = (Image)row.Cells["ImagePath"].Value; // Giả sử cột HinhAnh chứa đối tượng Image
                }
                else
                {
                    picHinhAnh.Image = null; // Nếu không có hình ảnh, đặt hình ảnh là null

                }
            }
            // Chuyển sang tab cập nhật
            tabSanPham.SelectedTab = tabCapNhat;
            // Bật nút sửa và xóa
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Tắt nút thêm
            btnThem.Enabled = false;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                    Title = "Chọn hình ảnh sản phẩm"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picHinhAnh.ImageLocation = openFileDialog.FileName; // Lấy đường dẫn hình ảnh đã chọn
                    picHinhAnh.Load(); // Tải hình ảnh vào PictureBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabSanPham_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabSanPham.SelectedTab == tabDanhSach)
            {
                LoadDanhSachSanPham(); // Tải danh sách sản phẩm khi chuyển sang tab danh sách
                ClearForm(); // Xóa form cập nhật
            }
        }

        private void LoadDanhSachSanPham()
        {
            ProductDAL productDAL = new ProductDAL();
            List<ProductsDTO> productList = sanPhamDAL.selectAll();

            ImageUtil imageUntil = new ImageUtil();

            dgvDSSanPham.DataSource = null;

            var danhSachHinhAnh = productList.Select(sp => new
            {
                sp.ProductID,
                sp.ProductName,
                sp.ProductTypeID,
                sp.ManufacturerID,
                sp.UnitPrice,
                sp.Stock,
                sp.Description,
                sp.Status,
                HinhAnh = imageUntil.load(sp.ImagePath)
            }).ToList();

            dgvDSSanPham.DataSource = danhSachHinhAnh;

            // Ensure the HinhAnh column is a DataGridViewImageColumn and set its layout
            if (dgvDSSanPham.Columns["HinhAnh"] is DataGridViewImageColumn imageColumn)
            {
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            dgvDSSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void picTimKiem_Click(object sender, EventArgs e)
        {

            string searchTerm = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo");
                return;
            }
            try
            {
                List<ProductsDTO> searchResults = sanPhamDAL.searchByName(searchTerm);
                if (searchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào với từ khóa: " + searchTerm, "Thông báo");
                    return;
                }
                ImageUtil imageUtil = new ImageUtil();
                var productList = searchResults.Select(sp => new
                {
                    sp.ProductID,
                    sp.ProductName,
                    sp.ProductTypeID,
                    sp.ManufacturerID,
                    sp.UnitPrice,
                    sp.Stock,
                    sp.Description,
                    sp.Status,
                    ImagePath = imageUtil.load(sp.ImagePath) // Convert string to Image
                }).ToList();
                dgvDSSanPham.DataSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi");
            }

        }
    }

}