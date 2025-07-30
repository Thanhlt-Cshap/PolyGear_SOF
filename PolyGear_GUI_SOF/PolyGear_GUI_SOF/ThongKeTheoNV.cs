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
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;

namespace PolyGear_GUI_SOF
{
    public partial class ThongKeTheoNV : Form
    {
        private EmployeeDAL employeeDAL = new EmployeeDAL(); // Cần có EmployeeDAL
        private vw_HoaDonChiTietDAL hoaDonChiTietDAL = new vw_HoaDonChiTietDAL();
        public ThongKeTheoNV()
        {
            InitializeComponent();
            dtpTungay.Value = new DateTime(2023, 7, 1);
            dtpDenNgay.Value = new DateTime(2025, 7, 25);

            LoadNhanVien();
            SetupDataGridView();
        }
        private void LoadNhanVien()
        {
            var dsNhanVien = employeeDAL.selectAll();

            cboNhanVien.DataSource = dsNhanVien;
            cboNhanVien.DisplayMember = "FullName";   // <-- Cái này QUAN TRỌNG
            cboNhanVien.ValueMember = "EmployeeID";   // <-- Giá trị dùng để truy vấn
            cboNhanVien.SelectedIndex = -1;           // Không chọn gì ban đầu
        }

        private void SetupDataGridView()
        {
            dgvThongKe.AutoGenerateColumns = false; // Tắt tự động tạo cột để chúng ta định nghĩa thủ công

            // Chỉ thêm cột nếu chúng chưa được tạo
            if (dgvThongKe.Columns.Count == 0)
            {
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "STT", HeaderText = "STT" }); // Cột STT thủ công
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MaHoaDon", HeaderText = "Mã Hóa Đơn", DataPropertyName = "MaHoaDon" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NgayLapHoaDon", HeaderText = "Ngày Lập Hóa Đơn", DataPropertyName = "NgayLapHoaDon", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "KhachHang", HeaderText = "Khách Hàng", DataPropertyName = "KhachHang" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "NhanVienBan", HeaderText = "Nhân Viên Bán", DataPropertyName = "NhanVienBan" }); // Cột Tên Nhân Viên
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TenSanPham", HeaderText = "Tên Sản Phẩm", DataPropertyName = "TenSanPham" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoLuong", HeaderText = "Số Lượng", DataPropertyName = "SoLuong" });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DonGia", HeaderText = "Đơn Giá", DataPropertyName = "DonGia", DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0.## VND" } });
                dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ThanhTien", HeaderText = "Thành Tiền", DataPropertyName = "ThanhTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "#,##0.## VND" } });
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để thống kê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNhanVien = cboNhanVien.SelectedValue.ToString();
            DateTime tuNgay = dtpTungay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            string sql = @"
                SELECT *
                FROM vw_HoaDonChiTiet
                WHERE EmployeeID = @0
                AND NgayLapHoaDon BETWEEN @1 AND @2";

            List<object> args = new List<object> { maNhanVien, tuNgay, denNgay };

            List<vw_HoaDonChiTietDTO> danhSach = hoaDonChiTietDAL.selectBySql(sql, args);

            dgvThongKe.DataSource = null;
            dgvThongKe.Columns.Clear();
            SetupDataGridView();

            if (danhSach == null || danhSach.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê nào trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvThongKe.DataSource = danhSach;

            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
            {
                dgvThongKe.Rows[i].Cells["STT"].Value = (i + 1).ToString();
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
    }
}
