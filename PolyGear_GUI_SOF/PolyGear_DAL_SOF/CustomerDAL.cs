using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PolyGear_DAL_SOF.SystemDAL;

namespace PolyGear_DAL_SOF
{
    public class CustomerDAL : BaseDAL<Customers, string>
    {
        public string generateAutoCustomer()
        {
            string prefix = "KH"; // Tiền tố cho mã nhân viên
            string sql = "SELECT TOP 1 CustomerID FROM Customers ORDER BY CustomerID DESC"; // Lấy mã khách hàng mới nhất
            try
            {
                object result = DBUtil.ScalarQuery(sql, new List<object>());
                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string lastCustomerID = result.ToString();
                    // Tách phần số từ mã nhân viên mới nhất
                    string numberPart = new string(lastCustomerID.Skip(2).ToArray());
                    if (int.TryParse(numberPart, out int nextNumber))
                    {
                        nextNumber++; // Tăng số lên 1 và tạo mã mới
                        return $"{prefix}{nextNumber:D4}"; // Định dạng với 4 chữ số
                    }
                }
                return $"{prefix}0001"; // Nếu không có mã khách hàng nào, trả về mã đầu tiên
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã loại sản phẩm mới nhất: " + ex.Message);
            }
        }

        public override List<Customers> selectAll()
        {
            // 
            String sql = "SELECT * FROM Customers";
            return selectBySql(sql, new List<Object>());
        }

        public override Customers selectById(String id)
        {
            String sql = "SELECT * FROM Customers WHERE CustomerID=@0";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            List<Customers> list = selectBySql(sql, thamSo);

            return list.Count > 0 ? list[0] : null;
        }

        public override List<Customers> selectBySql(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            List<Customers> list = new List<Customers>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    Customers entity = new Customers();
                    entity.CustomerID = reader["CustomerID"].ToString();
                    entity.FullName = reader["FullName"].ToString();
                    entity.Email = reader["Email"].ToString();
                    entity.Phone = reader["Phone"].ToString();
                    entity.Address = reader["Address"].ToString();
                    entity.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
                    entity.Status = Convert.ToBoolean(reader["Status"]);
                    list.Add(entity);
                }
                ;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
            }
            return list;
        }

        public override void update(Customers entity)
        {
            String sql = "UPDATE Customers SET FullName=@1, Email=@2, Phone=@3, Address=@4, RegisterDate=@5, Status=@6 WHERE CustomerID=@0";
            List<Object> thamSo = new List<Object>
            {
                entity.CustomerID,
                entity.FullName,
                entity.Email,
                entity.Phone,
                entity.Address,
                entity.RegisterDate,
                entity.Status
            };
            DBUtil.Update(sql, thamSo);
        }

        public override void delete(String id)
        {
            String sql = "DELETE FROM Customers WHERE CustomerID=@0";
            List<Object> thamSo = new List<Object> { id };
            DBUtil.Update(sql, thamSo);
        }

        public override void insert(Customers entity)
        {
            String sql = "INSERT INTO Customers (CustomerID, FullName, Email, Phone, Address, RegisterDate, Status) " +
                         "VALUES (@0, @1, @2, @3, @4, @5, @6)";
            List<Object> thamSo = new List<Object>();
            {
                thamSo.Add(entity.CustomerID);
                thamSo.Add(entity.FullName);
                thamSo.Add(entity.Email);
                thamSo.Add(entity.Phone);
                thamSo.Add(entity.Address);
                thamSo.Add(entity.RegisterDate);
                thamSo.Add(entity.Status);
            }
            ;
            DBUtil.Update(sql, thamSo);
        }
    }
}
