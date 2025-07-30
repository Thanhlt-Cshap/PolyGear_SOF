using PolyGear_DAL_SOF;
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
    public class OrderDetailDAL : BaseDAL <OrderDetailsDTO, string>
    {
        public string generateAutoOrderID()
        {
            string prefix = "CT"; // Tiền tố cho mã phiếu bán hàng
            string sql = "SELECT TOP 1 DetailID  FROM OrderDetails ORDER BY DetailID  DESC"; // Lấy mã phiếu mới nhất
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
                        return $"{prefix}{nextNumber:D4}"; // Định dạng với 3 chữ số
                    }
                }
                return $"{prefix}0001"; // Nếu không có mã phiếu nào, trả về mã phiếu đầu tiên
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã phiếu mới nhất: " + ex.Message);
            }

        }

        public bool exists(string id)
        {
            string sql = "SELECT COUNT(*) FROM OrderDetails WHERE DetailID = @0";
            List<object> thamSo = new List<object> { id };

            int count = Convert.ToInt32(DBUtil.ScalarQuery(sql, thamSo));
            return count > 0;
        }

        public override List<OrderDetailsDTO> selectAll()
        {
            string sql = "SELECT * FROM OrderDetails";
            return selectBySql(sql, new List<object>());
        }

        public override OrderDetailsDTO selectById(string id)
        {
            string sql = "SELECT * FROM OrderDetails WHERE DetailID = @0";
            List<object> thamSo = new List<object> { id };
            List<OrderDetailsDTO> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public override List<OrderDetailsDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<OrderDetailsDTO> list = new List<OrderDetailsDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    OrderDetailsDTO entity = new OrderDetailsDTO
                    {
                        DetailID = reader.GetString("DetailID"),
                        OrderID = reader.GetString("OrderID"),
                        ProductID = reader.GetString("ProductID"),
                        Quantity = reader.GetInt32("Quantity"),
                        UnitPrice = reader.GetDecimal("UnitPrice")
                    };
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public override void update(OrderDetailsDTO entity)
        {
            string sql = "UPDATE OrderDetails SET OrderID = @0,ProductID = @1, " +
                         "Quantity = @2, UnitPrice = @3 WHERE DetailID = @4";
            List<object> thamSo = new List<object>
            {
                entity.OrderID,
                entity.ProductID,
                entity.Quantity,
                entity.UnitPrice,
                entity.DetailID
            };
            DBUtil.Update(sql, thamSo);
        }

        public override void insert(OrderDetailsDTO entity)
        {
            string sql = "INSERT INTO OrderDetails (DetailID, OrderID, ProductID, Quantity, UnitPrice) " +
                         "VALUES (@0, @1, @2, @3, @4)";
            List<object> thamSo = new List<object>
            {
                entity.DetailID, // Include DetailID
                entity.OrderID,
                entity.ProductID,
                entity.Quantity,
                entity.UnitPrice
            };
            DBUtil.Update(sql, thamSo);
        }

        public override void delete(string id)
        {
            string sql = "DELETE FROM OrderDetails WHERE DetailID = @0";
            List<object> thamSo = new List<object> { id };
            DBUtil.Update(sql, thamSo);
        }

        
    }
}
