using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PolyGear_DAL_SOF.SystemDAL;

namespace PolyGear_DAL_SOF
{
    public class SalesOrderDAL : BaseDAL<SalesOrdersDTO, string>
    {
        public string generateAutoOrderID()
        {
            string prefix = "OD"; // Tiền tố cho mã phiếu bán hàng
            string sql = "SELECT TOP 1 OrderID  FROM SalesOrders ORDER BY OrderID  DESC"; // Lấy mã phiếu mới nhất
            try
            {
                object result = DBUtil.ScalarQuery(sql, new List<object>());
                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string lastMaPhieu = result.ToString();
                    // Tách phần số từ mã phiếu mới nhất

                    string numberPart = new string(lastMaPhieu.Skip(2).ToArray());
                    if (int.TryParse(numberPart, out int nextNumber))
                    {
                        nextNumber++; // Tăng số lên 1 và tạo mã phiếu mới
                        return $"{prefix}{nextNumber:D3}"; // Định dạng với 3 chữ số
                    }
                }
                return $"{prefix}0001"; // Nếu không có mã phiếu nào, trả về mã phiếu đầu tiên
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã phiếu mới nhất: " + ex.Message);
            }

        }

        public bool exists(string maPhieu)
        {
            string sql = "SELECT COUNT(*) FROM SalesOrders WHERE OrderID = @0";
            List<Object> thamSo = new List<Object> { maPhieu };

            try
            {
                object result = DBUtil.ScalarQuery(sql, thamSo);
                return Convert.ToInt32(result) > 0; // Nếu count > 0, mã phiếu đã tồn tại
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã phiếu: " + ex.Message);
            }
        }

        public override List<SalesOrdersDTO> selectAll()
        {
            // 
            String sql = "SELECT * FROM SalesOrders";
            return selectBySql(sql, new List<Object>());
        }

        public override SalesOrdersDTO selectById(string id)
        {
            String sql = "SELECT * FROM SalesOrders WHERE OrderID=@0";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            List<SalesOrdersDTO> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public override List<SalesOrdersDTO> selectBySql(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            List<SalesOrdersDTO> list = new List<SalesOrdersDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    SalesOrdersDTO phieu = new SalesOrdersDTO
                    {
                        OrderID = reader["OrderID"].ToString(),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        EmployeeID = reader["EmployeeID"].ToString(),
                        CustomerID = reader["CustomerID"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"])
                    };
                    list.Add(phieu);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public override void delete(string id)
        {
            String sql = "DELETE FROM SalesOrders WHERE OrderID=@0";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            try
            {
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phiếu bán hàng: " + ex.Message);
            }
        }
        public override void update(SalesOrdersDTO entity)
        {
            String sql = "UPDATE SalesOrders SET OrderDate=@0, EmployeeID=@1, CustomerID=@2, Status=@3 WHERE OrderID=@4";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(entity.OrderDate);
            thamSo.Add(entity.EmployeeID);
            thamSo.Add(entity.CustomerID);
            thamSo.Add(entity.Status);
            thamSo.Add(entity.OrderID);
            try
            {
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phiếu bán hàng: " + ex.Message);
            }

        }

        public override void insert(SalesOrdersDTO entity)
        {
            String sql = "INSERT INTO SalesOrders (OrderID, OrderDate, EmployeeID, CustomerID, Status) " +
                         "VALUES (@0, @1, @2, @3, @4)";
            List<object> thamSo = new List<object>
            {
                entity.OrderID,
                entity.OrderDate,
                entity.EmployeeID,
                entity.CustomerID,
                entity.Status
            };
            DBUtil.Update(sql, thamSo);


        }

        public List<Customers> getAllCustomers()
        {
            String sql = "SELECT * FROM Customers"; // Đảm bảo tên bảng đúng với DB
            List<Customers> danhSach = new List<Customers>();

            try
            {
                SqlDataReader reader = DBUtil.Query(sql, new List<Object>());
                while (reader.Read())
                {
                    Customers customers = new Customers
                    {
                        CustomerID = reader["CustomerID"].ToString(),
                        FullName = reader["FullName"].ToString(),
                    };
                    danhSach.Add(customers);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách thẻ khách hàng: " + ex.Message);
            }

            return danhSach;
        }

        public List<EmployeesDTO> getAllEmployees()
        {
            String sql = "SELECT * FROM Employees"; // Đảm bảo tên bảng đúng với DB
            List<EmployeesDTO> danhSach = new List<EmployeesDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, new List<Object>());
                while (reader.Read())
                {
                    EmployeesDTO employees = new EmployeesDTO
                    {
                        EmployeeID = reader["EmployeeID"].ToString(),
                        FullName = reader["FullName"].ToString()
                    };
                    danhSach.Add(employees);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            return danhSach;
        }

        public List<ProductsDTO> getAllProducts()
        {
            String sql = "SELECT * FROM Products"; // Đảm bảo tên bảng đúng với DB
            List<ProductsDTO> danhSach = new List<ProductsDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, new List<Object>());
                while (reader.Read())
                {
                    ProductsDTO products = new ProductsDTO
                    {
                        ProductID = reader["ProductID"].ToString(),
                        ProductName = reader["ProductName"].ToString()
                    };
                    danhSach.Add(products);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            return danhSach;
        }

        public bool hasOrderDetails(string maPhieu)
        {
            string sql = "SELECT COUNT(*) FROM OrderDetails WHERE DetailID = @0";
            List<object> thamSo = new List<object> { maPhieu };

            try
            {
                object result = DBUtil.ScalarQuery(sql, thamSo);
                return Convert.ToInt32(result) > 0; // Nếu count > 0, đã có chi tiết phiếu
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra chi tiết phiếu: " + ex.Message);
            }
        }

        public bool GetStatusSalesOrders(string maPhieu)
        {
            string query = "SELECT Status FROM SalesOrders WHERE OrderID = @0";
            var result = DBUtil.ScalarQuery(query, new List<object> { maPhieu });

            return result != null && Convert.ToBoolean(result);
        }
        public bool UpdateStatus(string maPhieu, bool trangThai)
        {
            if (trangThai && !CheckSalesOrders(maPhieu))
            {
                MessageBox.Show("Không thể thanh toán vì chưa có chi tiết sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string query = "UPDATE SalesOrders SET Status = @0 WHERE OrderID = @1";
            DBUtil.Update(query, new List<object> { trangThai, maPhieu });
            return true;
        }

        public bool CheckSalesOrders(string maPhieu)
        {
            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Mã phiếu rỗng, vui lòng chọn phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string query = "SELECT COUNT(*) FROM SalesOrders WHERE OrderID = @0"; // Kiểm tra ChiTietPhieu thay vì ChiTietSanPham

            try
            {
                var result = DBUtil.ScalarQuery(query, new List<object> { maPhieu });

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("Dữ liệu trống hoặc lỗi kết nối database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int count = 0;
                if (int.TryParse(result.ToString(), out count))
                {
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chi tiết phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi chuyển đổi dữ liệu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool GetTrangThaiThe(string maKhachHang)
        {
            string query = "SELECT Status FROM Customers WHERE CustomerID = @0";
            var result = DBUtil.ScalarQuery(query, new List<object> { maKhachHang });
            return result != null && Convert.ToBoolean(result);
            // Nếu không tìm thấy thẻ, trả về false
        }
    }
 }
 
