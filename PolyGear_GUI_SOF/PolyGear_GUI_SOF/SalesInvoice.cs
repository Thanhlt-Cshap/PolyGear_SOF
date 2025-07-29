using DAL_SOF205;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PolyGear_GUI_SOF
{
    public partial class SalesInvoice : Form
    {
        private SalesOrderDAL salesOrderDAL = new SalesOrderDAL();
        private OrderDetailDAL orderDetailDAL = new OrderDetailDAL();
        private ProductDAL productDAL = new ProductDAL();
        private EmployeeDAL employeeDAL = new EmployeeDAL();
        public SalesInvoice()
        {
            InitializeComponent();
            LoadForm();
            // tắt thêm, sửa và xóa phiếu ban đầu
            btnSuaPhieu.Enabled = false;
            btnXoaPhieu.Enabled = false;
            btnThemPhieu.Enabled = true;
            // tắt nút Thêm, sửa, xóa chi tiết phiếu ban đầu nếu như chưa có chọn phiếu bán hàng
            btnSuaChiTiet.Enabled = false;
            btnXoaChiTiet.Enabled = false;
            btnThemChiTiet.Enabled = false;
            // tắt nút Thanh Toán ban đầu
            btnThanhToan.Enabled = false;
            // tắt trạng thái không thể chỉnh sửa
            rdoDaThanhToan.Enabled = false;
            rdoChoXacNhan.Enabled = false;
            // tắt thành tiền 
            txtThanhTien.Enabled = false;

        }

        private void LoadSalesOrders()
        {
            // Lấy danh sách phiếu bán hàng, nhân viên, khách hàng
            var orders = salesOrderDAL.selectAll()
                .OrderByDescending(x => x.OrderID)
                .ToList();
            var employees = employeeDAL.selectAll().ToDictionary(e => e.EmployeeID, e => e.FullName);
            var customers = salesOrderDAL.getAllCustomers().ToDictionary(c => c.CustomerID, c => c.FullName);

            // Tạo view model để hiển thị cả tên và mã
            var viewList = orders.Select(o => new
            {
                o.OrderID,
                o.OrderDate,
                o.EmployeeID,
                EmployeeName = employees.ContainsKey(o.EmployeeID) ? employees[o.EmployeeID] : "",
                o.CustomerID,
                CustomerName = customers.ContainsKey(o.CustomerID) ? customers[o.CustomerID] : "",
                o.Status
            }).ToList();

            dgvDSPhieuBanhang.DataSource = viewList;

            // Đổi tên cột
            dgvDSPhieuBanhang.Columns["OrderID"].HeaderText = "Mã phiếu";
            dgvDSPhieuBanhang.Columns["OrderDate"].HeaderText = "Ngày tạo";
            dgvDSPhieuBanhang.Columns["EmployeeName"].HeaderText = "Nhân viên";
            dgvDSPhieuBanhang.Columns["CustomerName"].HeaderText = "Khách hàng";
            dgvDSPhieuBanhang.Columns["Status"].HeaderText = "Trạng thái";

            // Ẩn cột mã nhân viên và mã khách hàng
            dgvDSPhieuBanhang.Columns["EmployeeID"].Visible = false;
            dgvDSPhieuBanhang.Columns["CustomerID"].Visible = false;
        }

        private void LoadForm()
        {
            LoadSalesOrders();
            LoadComboboxData();
            ClearChiTietPhieu();
            ClearPhieuBanHang();
        }

        private void LoadComboboxData()
        {
            // Load danh sách nhân viên
            // Lấy danh sách nhân viên đang hoạt động.
            List<EmployeesDTO> employeeList = employeeDAL.selectAll();
            cboMaNhanVien.DataSource = employeeList;     // lấy danh sách nhân viên
            cboMaNhanVien.DisplayMember = "FullName";       // Hiển thị tên nhân viên
            cboMaNhanVien.ValueMember = "EmployeeID";    // Lưu giá trị mã nhân viên

            // Load danh sách khách hàng
            cboMaThe.DataSource = salesOrderDAL.getAllCustomers();
            cboMaThe.DisplayMember = "FullName";         // Hiển thị tên khách hàng
            cboMaThe.ValueMember = "CustomerID";              // Giá trị mã khách hàng



            // Load danh sách sản phẩm
            cboMaSanPham.DataSource = salesOrderDAL.getAllProducts();
            cboMaSanPham.DisplayMember = "ProductName";   // Hiển thị tên sản phẩm
            cboMaSanPham.ValueMember = "ProductID";      // Lưu giá trị mã sản phẩm
        }


        private void ClearPhieuBanHang()
        {
            txtMaPhieu.Clear();
            cboMaThe.SelectedIndex = -1;
            cboMaNhanVien.SelectedIndex = -1;
            dtpNgayTao.Value = DateTime.Now;
            rdoChoXacNhan.Checked = true; // trạng thái chờ xác nhận

            // mở lại nút Thêm Phiếu
            btnThemPhieu.Enabled = true; // Bật nút Thêm Phiếu
            btnXoaPhieu.Enabled = false; // Tắt nút Xóa Phiếu
            btnSuaPhieu.Enabled = false; // Tắt nút Sửa Phiếu
            btnThanhToan.Enabled = false; // Tắt nút Thanh Toán
            //HienThiTabChiTietPhieu(false);
        }
        private void ClearChiTietPhieu()
        {
            cboMaSanPham.SelectedIndex = -1; // Bỏ chọn sản phẩm
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";

            //Tắt các nút sửa và xóa chi tiết phiếu
            btnSuaChiTiet.Enabled = false; // Tắt nút Sửa Chi Tiết
            btnXoaChiTiet.Enabled = false; // Tắt nút Xóa Chi Tiết
            btnThemChiTiet.Enabled = true; // Bật nút Thêm Chi Tiết khi đã xóa chi tiết phiếu
        }

        private void LoadOrderDetails(string maPhieu)
        {
            // Lấy danh sách chi tiết phiếu
            var chiTietList = orderDetailDAL.selectBySql("SELECT * FROM OrderDetails WHERE OrderID=@0", new List<object> { maPhieu });

            // Lấy danh sách sản phẩm để tra cứu tên
            var products = productDAL.selectAll().ToDictionary(p => p.ProductID, p => p.ProductName);

            // Tạo danh sách view model để hiển thị
            var viewList = chiTietList.Select(ct => new
            {
                ct.DetailID,
                ct.OrderID,
                ct.ProductID,
                ProductName = products.ContainsKey(ct.ProductID) ? products[ct.ProductID] : "",
                ct.Quantity,
                ct.UnitPrice
            }).ToList();

            dgvChiTietPhieu.DataSource = viewList;

            // Đổi tên cột
            dgvChiTietPhieu.Columns["DetailID"].HeaderText = "Mã chi tiết";
            dgvChiTietPhieu.Columns["OrderID"].HeaderText = "Mã phiếu";
            dgvChiTietPhieu.Columns["ProductID"].HeaderText = "Mã sản phẩm";
            dgvChiTietPhieu.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dgvChiTietPhieu.Columns["Quantity"].HeaderText = "Số lượng";
            dgvChiTietPhieu.Columns["UnitPrice"].HeaderText = "Đơn giá";

        }

        private void SalesInvoice_Load(object sender, EventArgs e)
        {

        }

        private void TinhThanhTien()
        {
            try
            {
                decimal donGia = string.IsNullOrEmpty(txtDonGia.Text) ? 0 : Convert.ToDecimal(txtDonGia.Text);
                int soLuong = string.IsNullOrEmpty(txtSoLuong.Text) ? 0 : Convert.ToInt32(txtSoLuong.Text);
                decimal thanhTien = donGia * soLuong;
                txtThanhTien.Text = thanhTien.ToString("N0"); // Hiện thị số có dấu phân cách
            }
            catch
            {
                txtThanhTien.Text = "0"; // Nếu có lỗi, đặt giá trị về 0
            }
        }

        private void cboMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSanPham.SelectedValue != null)
            {
                string maSanPham = cboMaSanPham.SelectedValue.ToString();
                decimal donGia = productDAL.getDonGiaByMa(maSanPham);
                txtDonGia.Text = donGia.ToString("N0");
                TinhThanhTien(); // Cập nhật thành tiền ngay khi chọn sản phẩm
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            // kiểm tra xem đã chọn nhân viên chưa
            if (cboMaNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // kiểm tra xem đã chọn thẻ chưa
            if (cboMaThe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thẻ lưu động!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bắt lỗi thêm ngày tạo phiếu bán hàng phải là ngày hiện tại
            if (dtpNgayTao.Value.Date != DateTime.Now.Date)
            {
                MessageBox.Show("Ngày tạo phiếu bán hàng phải là ngày hiện tại!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // bắt lỗi tra trạng thái nhân viên có hoạt động ko nếu hoạt động thì được thêm phiếu 
            string maNhanVien = cboMaNhanVien.SelectedValue?.ToString();
            EmployeesDTO nhanVien = employeeDAL.selectById(maNhanVien);
            if (nhanVien == null || !nhanVien.Status)
            {
                MessageBox.Show("Nhân viên này không hoạt động, không thể thêm phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem trạng thái thẻ lưu động của người dùng có hoạt động không bằng GetTrangThaiThe
            string maThe = cboMaThe.SelectedValue?.ToString();
            if (!salesOrderDAL.GetTrangThaiThe(maThe))
            {
                MessageBox.Show("Thẻ thành viên không hoạt động, không thể thêm phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // KHởi tạo mã phiếu bán hàng
            string maPhieu = salesOrderDAL.generateAutoOrderID();
            SalesOrdersDTO phieu = new SalesOrdersDTO
            {
                OrderID = maPhieu,
                CustomerID = cboMaThe.SelectedValue.ToString(), // Lấy giá trị từ ComboBox
                EmployeeID = cboMaNhanVien.SelectedValue.ToString(),
                OrderDate = DateTime.Now,
                Status = false // Mặc định là chưa xử lý
            };

            salesOrderDAL.insert(phieu);
            MessageBox.Show("Thêm phiếu bán hàng thành công!");
            LoadSalesOrders();
            LoadForm();
        }

        private void dgvDSPhieuBanhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSPhieuBanhang.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells["OrderID"].Value.ToString();
                cboMaThe.SelectedValue = row.Cells["CustomerID"].Value.ToString();
                cboMaNhanVien.SelectedValue = row.Cells["EmployeeID"].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["OrderDate"].Value);

                // Lấy trạng thái từ cột TrangThai (giả sử kiểu bool)
                bool trangThai = false;
                if (row.Cells["Status"].Value != null)
                {
                    bool.TryParse(row.Cells["Status"].Value.ToString(), out trangThai);
                }
                // Đổ trạng thái lên RadioButton
                rdoDaThanhToan.Checked = trangThai;
                rdoChoXacNhan.Checked = !trangThai;
                LoadOrderDetails(txtMaPhieu.Text); // Load chi tiết phiếu tương ứng
                // Bật các nút sửa và xóa phiếu
                btnSuaPhieu.Enabled = true;
                btnXoaPhieu.Enabled = true;
                btnThemPhieu.Enabled = false; // Tắt nút Thêm Phiếu khi đã chọn phiếu

                // bắt lỗi nếu đã chọn phiếu bán hàng thì mở lại thêm chi tiết
                btnThemChiTiet.Enabled = true;
                btnSuaChiTiet.Enabled = false;
                btnXoaChiTiet.Enabled = false;

                // nếu đã thanh toán thì tắt các nút sửa, xóa chi tiết phiếu
                if (trangThai == true)
                {
                    btnThemChiTiet.Enabled = false; // Tắt nút Thêm Chi Tiết nếu đã thanh toán
                    btnThanhToan.Enabled = false; // Tắt nút Thanh Toán nếu đã thanh toán
                    // không cho sửa phiếu bán hàng và thêm phiếu khi đẫ thanh toán
                    btnSuaPhieu.Enabled = false; // Tắt nút Sửa Phiếu nếu đã thanh toán
                    btnXoaPhieu.Enabled = false; // Tắt nút Xóa Phiếu nếu đã thanh toán
                }
                else
                {
                    btnThanhToan.Enabled = true; // Bật nút Thanh Toán nếu chưa thanh toán
                    rdoDaThanhToan.Enabled = false; // Tắt RadioButton "Đã thanh toán" nếu chưa thanh toán
                    btnThemPhieu.Enabled = false; // Tắt nút Thêm Phiếu nếu đã chọn phiếu
                    btnSuaPhieu.Enabled = true; // Bật nút Sửa Phiếu nếu đã chọn phiếu
                }

                // nếu đã có chi tiết phiếu thì tắt sửa phiếu bán hàng
                if (salesOrderDAL.GetStatusSalesOrders(txtMaPhieu.Text))
                {
                    btnSuaPhieu.Enabled = false; // Tắt nút Sửa Phiếu nếu đã có chi tiết phiếu
                    btnXoaPhieu.Enabled = false; // Tắt nút Xóa Phiếu nếu đã có chi tiết phiếu
                }
                else
                {
                    btnSuaPhieu.Enabled = true; // Bật lại nút Sửa Phiếu nếu không có chi tiết phiếu
                    btnXoaPhieu.Enabled = true; // Bật lại nút Xóa Phiếu nếu không có chi tiết phiếu
                }

                // Kiểm tra lại trạng thái thật của phiếu
                bool trangThaiPhieu = salesOrderDAL.GetStatusSalesOrders(txtMaPhieu.Text);
                if (trangThaiPhieu || dgvChiTietPhieu.Rows.Count == 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }

                // ẩn tab Chi Tiết Phiếu nếu chưa chọn phiếu bán hàng
                HienThiTabChiTietPhieu(true);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadForm(); // Nạp lại form
            ClearChiTietPhieu(); // Xóa dữ liệu nhập chi tiết phiếu
            ClearPhieuBanHang(); // Xóa dữ liệu nhập phiếu bán hàng
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                string maPhieu = txtMaPhieu.Text;
                string maNhanVien = cboMaNhanVien.SelectedValue.ToString();
                string maThe = cboMaThe.SelectedValue.ToString();
                bool trangThai = false; // Mặc định là chưa thanh toán


                // Kiểm tra xem phiếu có tồn tại không
                if (!salesOrderDAL.exists(maPhieu))
                {
                    MessageBox.Show("Phiếu bán hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra phiếu có Chi Tiết Phieu không nếu có thì không cho sửa nhân viên và thẻ
                bool coCTP = salesOrderDAL.hasOrderDetails(maPhieu);
                if (coCTP)
                {
                    cboMaNhanVien.Enabled = false; // Tắt ComboBox nhân viên
                    cboMaThe.Enabled = false; // Tắt ComboBox thẻ
                }
                else
                {
                    cboMaNhanVien.Enabled = true; // Bật ComboBox nhân viên
                    cboMaThe.Enabled = true; // Bật ComboBox thẻ
                }

     
                SalesOrdersDTO pbh = new SalesOrdersDTO
                {
                    OrderID = maPhieu,
                    EmployeeID = maNhanVien,
                    CustomerID = maThe,
                    Status = trangThai,
                    OrderDate = dtpNgayTao.Value

                };

                // Gọi hàm update từ DAL
                salesOrderDAL.update(pbh);

                // Thông báo thành công
                MessageBox.Show("Cập nhật phiếu bán hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại danh sách phiếu
                LoadSalesOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = txtMaPhieu.Text;

                // Kiểm tra xem phiếu có tồn tại không
                if (!salesOrderDAL.exists(maPhieu))
                {
                    MessageBox.Show("Phiếu bán hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Bắt lỗi nếu đã có sản phẩm trong chi tiết phiếu thì không cho xóa phiếu bán hàng và tắt btnXoaPhieu
                if (salesOrderDAL.hasOrderDetails(maPhieu))
                {
                    btnXoaPhieu.Enabled = false;
                    MessageBox.Show("Phiếu bán hàng đã có chi tiết phiếu. Không thể xóa phiếu này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    btnXoaPhieu.Enabled = true; // Bật lại nút Xóa Phiếu nếu không có chi tiết phiếu
                }

                // Hiện thông báo để xác nhận xóa phiếu bán hàng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu bán hàng này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa
                    salesOrderDAL.delete(maPhieu);
                    // Thông báo thành công
                    MessageBox.Show("Xóa phiếu bán hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm sạch form
                    ClearPhieuBanHang();
                    // Load lại danh sách phiếu
                    LoadSalesOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu bán hàng trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trạng thái phiếu
            SalesOrdersDTO phieu = salesOrderDAL.selectById(txtMaPhieu.Text);
            if (phieu != null && phieu.Status == true) // Giả sử TrangThai = true nghĩa là đã thanh toán
            {
                MessageBox.Show("Phiếu bán hàng đã thanh toán, Không thể thêm chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIểm tra xem có sản phẩm nào được chọn không
            if (cboMaSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kiểm tra trạng thái sản phẩm (ngưng bán)
            string maSanPham = cboMaSanPham.SelectedValue.ToString();
            if (productDAL.IsDiscontinued(maSanPham))
            {
                MessageBox.Show("Sản phẩm này đã ngưng bán, không thể thêm vào chi tiết phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra coi có sản phẩm nào được chọn không và có số lượng không
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng chọn nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvChiTietPhieu.Rows)
            {
                if (row.Cells["ProductID"].Value.ToString() == cboMaSanPham.SelectedValue.ToString())
                {
                    MessageBox.Show("Sản phẩm này đã tồn tại trong chi tiết phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //// Kiểm tra số lượng.
            //if (!Validation.ValidateQuantity(txtSoLuong.Text)) return;

            // Tạo phiếu chi tiết mới
            OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO
            {
                DetailID = orderDetailDAL.generateAutoOrderID(),
                OrderID = txtMaPhieu.Text,
                ProductID = cboMaSanPham.SelectedValue.ToString(),
                Quantity = int.Parse(txtSoLuong.Text),
                UnitPrice = decimal.Parse(txtDonGia.Text)
            };

            orderDetailDAL.insert(orderDetailsDTO);
            MessageBox.Show("Thêm chi tiết phiếu thành công!");
            LoadOrderDetails(txtMaPhieu.Text);
            ClearChiTietPhieu();
            //ClearPhieuBanHang();
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nhập liệu (Check input)
                if (String.IsNullOrEmpty(txtMaPhieu.Text))
                {
                    MessageBox.Show("Vui lòng chọn phiếu bán hàng trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }

                if (dgvChiTietPhieu.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết phiếu để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }

                // Lấy thông tin từ giao diện (Get information from the interface)
                string maPhieu = txtMaPhieu.Text;
                string maSanPham = cboMaSanPham.SelectedValue.ToString();
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal donGia = Decimal.Parse(txtDonGia.Text);

                // Lấy ID từ dòng chọn (Get ID from the selected row)
                string id = dgvChiTietPhieu.SelectedRows[0].Cells["DetailID"].Value.ToString();


                // Kiểm tra nếu phiếu đã xác nhận, không cho sửa (Check if the receipt has been confirmed, not editable)
                bool trangThaiPhieu = salesOrderDAL.GetStatusSalesOrders(maPhieu);
                if (trangThaiPhieu)
                {
                    MessageBox.Show("Phiếu bán hàng đã được xác nhận. Không thể chỉnh sửa chi tiết phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }

                // Kiểm tra chi tiết phiếu có tồn tại không (Check if receipt detail exists)
                if (!orderDetailDAL.exists(id))
                {
                    MessageBox.Show("Chi tiết phiếu không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }


                // Cập nhật chi tiết phiếu (Update receipt detail)
                OrderDetailsDTO chiTiet = new OrderDetailsDTO
                {
                    DetailID = id,
                    OrderID = maPhieu,
                    ProductID = maSanPham,
                    Quantity = soLuong,
                    UnitPrice = donGia

                };
                orderDetailDAL.update(chiTiet);

                // Nếu không có exception, coi như cập nhật thành công (If no exception, consider the update successful)
                MessageBox.Show("Sửa chi tiết phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrderDetails(maPhieu);
                ClearChiTietPhieu();
                // ClearPhieuBanHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa chi tiết phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nhập liệu (Check input)
                if (String.IsNullOrEmpty(txtMaPhieu.Text))
                {
                    MessageBox.Show("Vui lòng chọn phiếu bán hàng trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }
                if (dgvChiTietPhieu.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết phiếu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }
                // Lấy ID từ dòng chọn (Get ID from the selected row)
                string id = dgvChiTietPhieu.SelectedRows[0].Cells["DetailID"].Value.ToString();
                // Kiểm tra nếu phiếu đã xác nhận, không cho xóa (Check if the receipt has been confirmed, not deletable)
                string maPhieu = txtMaPhieu.Text;
                bool trangThaiPhieu = salesOrderDAL.GetStatusSalesOrders(maPhieu);
                if (trangThaiPhieu)
                {
                    MessageBox.Show("Phiếu bán hàng đã được xác nhận. Không thể xóa chi tiết phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }
                // Kiểm tra chi tiết phiếu có tồn tại không (Check if receipt detail exists)
                if (!orderDetailDAL.exists(id))
                {
                    MessageBox.Show("Chi tiết phiếu không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearChiTietPhieu();
                    //ClearPhieuBanHang();
                    return;
                }
                // Hiện thông báo để xác nhận xóa chi tiết phiếu bán hàng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết phiếu này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa
                    orderDetailDAL.delete(id);
                    // Thông báo thành công
                    MessageBox.Show("Xóa chi tiết phiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm sạch form
                    ClearChiTietPhieu();
                    // Load lại danh sách chi tiết phiếu
                    LoadOrderDetails(maPhieu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // nếu chưa có chi tiết phiếu thì không cho thanh toán 
            if (dgvChiTietPhieu.Rows.Count == 0)
            {
                btnThanhToan.Enabled = false; // Tắt nút Thanh Toán
            }
            else
            {
                btnThanhToan.Enabled = true; // Bật nút Thanh Toán nếu có chi tiết phiếu
            }

            // Kiểm tra đầu vào: Kiểm tra xem ô textbox maPhieu (mã phiếu) có trống không
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu bán hàng trước khi thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = txtMaPhieu.Text.Trim(); // Lấy mã phiếu và loại bỏ khoảng trắng thừa

            //// Tạo một thể hiện của PhieuBanHangDAL (Lớp Truy cập Dữ liệu Phiếu Bán Hàng)
            SalesOrderDAL dal = new SalesOrderDAL();
            bool trangThaiHienTai = dal.GetStatusSalesOrders(maPhieu);
            if (trangThaiHienTai) // Nếu trangThaiHienTai là true (nghĩa là đã thanh toán/hoàn thành)
            {
                MessageBox.Show("Phiếu bán hàng đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cố gắng cập nhật trạng thái phiếu thành đã thanh toán/hoàn thành
            if (dal.UpdateStatus(maPhieu, true)) // Nếu UpdateTrangThai trả về true (cập nhật thành công)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu phiếu bán hàng chính và chi tiết sau khi thanh toán thành công
                LoadSalesOrders();
                LoadOrderDetails(maPhieu);

                // Cập nhật giao diện người dùng có điều kiện cho các radio button (giả sử rbHoanThanh và rbChoXacNhan là các điều khiển RadioButton)
                if (rdoDaThanhToan != null && rdoChoXacNhan != null)
                {
                    rdoDaThanhToan.Checked = true; // Đặt radio button "Hoàn thành" thành đã chọn
                    rdoChoXacNhan.Checked = false; // Bỏ chọn radio button "Chờ xác nhận"
                }
            }


            ClearPhieuBanHang(); // Xóa dữ liệu nhập phiếu bán hàng


        }

        private void dgvChiTietPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietPhieu.Rows[e.RowIndex];

                // lấy thông tin chi tiết phiếu
                string maChiTiet = row.Cells["DetailID"].Value.ToString();
                string maPhieu = row.Cells["OrderID"].Value.ToString();
                string maSanPham = row.Cells["ProductID"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal donGia = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                // Đổ dữ liệu vào các ô nhập liệu
                txtMaPhieu.Text = maPhieu; // Đổ mã phiếu vào ô nhập liệu
                cboMaSanPham.SelectedValue = maSanPham; // Đổ mã sản phẩm vào ComboBox
                txtSoLuong.Text = soLuong.ToString(); // Đổ số lượng vào ô nhập liệu
                txtDonGia.Text = donGia.ToString("N0"); // Đổ đơn giá vào ô nhập liệu với định dạng số có dấu phân cách
                txtThanhTien.Text = (soLuong * donGia).ToString("N0"); // Tính và đổ thành tiền vào ô nhập liệu với định dạng số có dấu phân cách
                // Đặt mã chi tiết phiếu vào ô ẩn để sử dụng khi sửa hoặc xóa chi tiết phiếu
                txtMaPhieu.Tag = maChiTiet; // Lưu mã chi tiết phiếu vào Tag của ô nhập liệu


                // Tính lại Thành Tiền khi chọn chi tiết phiếu
                TinhThanhTien();

                // nếu tr thái phiếu đã thanh toán thì không cho sửa chi tiết phiếu
                bool trangThaiPhieu = salesOrderDAL.GetStatusSalesOrders(txtMaPhieu.Text);
                if (trangThaiPhieu)
                {
                    // Bật các nút sửa và xóa chi tiết phiếu tắt nút Thêm Chi Tiết
                    btnSuaChiTiet.Enabled = false; // Bật nút Sửa Chi Tiết
                    btnXoaChiTiet.Enabled = false; // Bật nút Xóa Chi Tiết   
                    btnThemChiTiet.Enabled = false; // Tắt nút Thêm Chi Tiết khi đã chọn chi tiết phiếu
                    btnThanhToan.Enabled = false; // Tắt nút Thanh Toán nếu đã thanh toán
                }
                else
                {
                    // Bật các nút sửa và xóa chi tiết phiếu tắt nút Thêm Chi Tiết
                    btnSuaChiTiet.Enabled = true; // Bật nút Sửa Chi Tiết
                    btnXoaChiTiet.Enabled = true; // Bật nút Xóa Chi Tiết   
                    btnThemChiTiet.Enabled = false; // Tắt nút Thêm Chi Tiết khi đã chọn chi tiết phiếu
                    btnThanhToan.Enabled = true; // Bật nút Thanh Toán nếu chưa thanh toán
                }

                tabDSPhieuBanHang.SelectedTab = tabPhieuBanHang; // Chuyển sang tab Chi Tiết Phiếu
            }
        }
        private void HienThiTabChiTietPhieu(bool hien)
        {
            if (hien)
            {
                if (!tabDSPhieuBanHang.TabPages.Contains(tabChiTietPhieu))
                    tabDSPhieuBanHang.TabPages.Add(tabChiTietPhieu);
            }
            else
            {
                if (tabDSPhieuBanHang.TabPages.Contains(tabChiTietPhieu))
                    tabDSPhieuBanHang.TabPages.Remove(tabChiTietPhieu);
            }


        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bỏ qua ký tự không hợp lệ
            }
        }
    }
}
