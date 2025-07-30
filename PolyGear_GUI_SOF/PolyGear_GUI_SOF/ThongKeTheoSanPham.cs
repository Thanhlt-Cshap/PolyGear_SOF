using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using PolyGear_DAL_SOF; // Đảm bảo namespace và các lớp này được tham chiếu và triển khai chính xác.

namespace PolyGear_GUI_SOF
{
    public partial class ThongKeTheoSanPham : Form
    {
        private ProductDAL sanPhamDAL = new ProductDAL();
        private vw_HoaDonChiTietDAL hoaDonChiTietDAL = new vw_HoaDonChiTietDAL();

        public ThongKeTheoSanPham()
        {
            InitializeComponent();
            // Đặt phạm vi ngày ban đầu như trong hình ảnh của bạn.
            // Cân nhắc đặt các giá trị này thành các giá trị động hơn hoặc phạm vi mặc định "tháng/năm trước" nếu dữ liệu tăng lên.
            dtpTungay.Value = new DateTime(2023, 7, 1);
            dtpDenNgay.Value = new DateTime(2025, 7, 25);

            LoadSanPham();
            SetupDataGridView();
        }

        private void LoadSanPham()
        {
            try
            {
                var ds = sanPhamDAL.selectAll(); // Giả sử điều này trả về một danh sách các đối tượng Product/DataTable
                cboLoaiSanPham.DataSource = ds;
                cboLoaiSanPham.DisplayMember = "ProductName"; // Hiển thị tên sản phẩm
                cboLoaiSanPham.ValueMember = "ProductID";     // Sử dụng ProductID làm giá trị cơ sở
                cboLoaiSanPham.SelectedIndex = -1; // Ban đầu không có mục nào được chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvThongKe.AutoGenerateColumns = false;
            // Xóa các cột hiện có chỉ khi chúng được thêm động, nếu không chúng có thể từ trình thiết kế.
            // Điều này an toàn hơn nếu SetupDataGridView có thể được gọi nhiều lần.
            if (dgvThongKe.Columns.Count == 0 || !dgvThongKe.Columns.Cast<DataGridViewColumn>().Any(c => c.Name == "MaHoaDon")) // Kiểm tra xem một cột khóa có tồn tại không
            {
                dgvThongKe.Columns.Clear(); // Xóa tất cả các cột để tránh trùng lặp nếu được gọi nhiều lần
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "STT", HeaderText = "STT", ReadOnly = true }); // STT nên chỉ đọc
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MaHoaDon", HeaderText = "Mã Hóa Đơn", DataPropertyName = "MaHoaDon" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayLapHoaDon", HeaderText = "Ngày Lập", DataPropertyName = "NgayLapHoaDon", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "KhachHang", HeaderText = "Khách Hàng", DataPropertyName = "KhachHang" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TenSanPham", HeaderText = "Tên Sản Phẩm", DataPropertyName = "TenSanPham" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoLuong", HeaderText = "Số Lượng", DataPropertyName = "SoLuong" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DonGia", HeaderText = "Đơn Giá", DataPropertyName = "DonGia", DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0.## VND" } });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ThanhTien", HeaderText = "Thành Tiền", DataPropertyName = "ThanhTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0.## VND" } });
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Phương thức này dường như là một bản sao hoặc một trình xử lý cũ.
            // Logic nằm trong btnThongKe_Click_1. Bạn nên xóa một trong số chúng
            // hoặc đảm bảo chỉ một trong số chúng được gắn vào sự kiện Click của nút.
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            if (cboLoaiSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lỗi: Bạn đang cố gắng lọc bằng ProductID trong khi view không có cột đó.
            // string productId = cboLoaiSanPham.SelectedValue.ToString(); // Dòng này lấy ProductID

            // SỬA LỖI: Lấy TenSanPham từ item được chọn trong ComboBox
            // Cần ép kiểu về DataRowView để truy cập các cột của nó
            string tenSanPhamDuocChon = "";
            if (cboLoaiSanPham.SelectedItem is DataRowView)
            {
                tenSanPhamDuocChon = ((DataRowView)cboLoaiSanPham.SelectedItem)["ProductName"].ToString();
            }
            else if (cboLoaiSanPham.SelectedItem != null)
            {
                // Xử lý trường hợp DataSource không phải là DataTable/DataView (ví dụ: List<Product>)
                // Giả sử Product có thuộc tính ProductName
                dynamic selectedProduct = cboLoaiSanPham.SelectedItem;
                tenSanPhamDuocChon = selectedProduct.ProductName;
            }
            else
            {
                MessageBox.Show("Không thể lấy tên sản phẩm. Vui lòng kiểm tra lại cấu hình ComboBox.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DateTime tuNgay = dtpTungay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            // SỬA LỖI TRUY VẤN SQL: Thay 'ProductID' bằng 'TenSanPham'
            string sql = @"
        SELECT * FROM vw_HoaDonChiTiet
        WHERE TenSanPham = @0
        AND NgayLapHoaDon BETWEEN @1 AND @2";

            // Truyền tên sản phẩm vào tham số @0
            var args = new List<object> { tenSanPhamDuocChon, tuNgay, denNgay };

            try
            {
                var ds = hoaDonChiTietDAL.selectBySql(sql, args);

                dgvThongKe.DataSource = null;
                // SetupDataGridView(); // Không cần gọi lại ở đây nếu nó đã được gọi trong constructor và xử lý cột đúng cách
                // Nếu bạn muốn đảm bảo cột được tạo lại, hãy giữ lại, nhưng hãy chắc chắn logic trong SetupDataGridView không tạo cột trùng lặp.

                if (ds == null || ds.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvThongKe.Rows.Clear(); // Xóa các hàng cũ nếu không có dữ liệu mới
                    return;
                }

                dgvThongKe.DataSource = ds;
                for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                {
                    dgvThongKe.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                Title = "Chọn nơi lưu file Excel",
                FileName = "ThongKe_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Không cần set lại LicenseContext ở đây vì đã set trong Program.cs
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("ThongKe");

                            // Ghi tiêu đề cột
                            for (int col = 0; col < dgvThongKe.Columns.Count; col++)
                            {
                                worksheet.Cells[1, col + 1].Value = dgvThongKe.Columns[col].HeaderText;
                                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                                worksheet.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            }

                            // Ghi dữ liệu từ DataGridView
                            for (int row = 0; row < dgvThongKe.Rows.Count; row++)
                            {
                                for (int col = 0; col < dgvThongKe.Columns.Count; col++)
                                {
                                    var value = dgvThongKe.Rows[row].Cells[col].Value;
                                    worksheet.Cells[row + 2, col + 1].Value = value != null ? value.ToString() : "";
                                }
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            // Lưu file
                            var fileInfo = new FileInfo(sfd.FileName);
                            package.SaveAs(fileInfo);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Cân nhắc thêm trình xử lý sự kiện cho nút Xuất File nếu btnXuatFile có trên biểu mẫu của bạn
        // private void btnXuatFile_Click(object sender, EventArgs e)
        // {
        //     // Logic để xuất dữ liệu
        // }
    }
}