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
    public class ProductDAL : BaseDAL<ProductsDTO, string>
    {
        // Hàm này sẽ tạo mã sản phẩm tự động
        public string generateAutoProductID()
        {
            string prefix = "SP";
            string sql = "SELECT TOP 1 ProductID FROM Products WHERE ProductID LIKE 'SP%' ORDER BY ProductID DESC";
            try
            {
                object result = DBUtil.ScalarQuery(sql, new List<object>());
                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string lastProductID = result.ToString();
                    string numberPart = new string(lastProductID.Skip(2).ToArray());
                    if (int.TryParse(numberPart, out int nextNumber))
                    {
                        nextNumber++;
                        return $"{prefix}{nextNumber:D4}";
                    }
                }
                return $"{prefix}0001";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã sản phẩm mới nhất: " + ex.Message);
            }
        }

        public override List<ProductsDTO> selectAll()
        {
            string sql = "SELECT * FROM Products";
            return selectBySql(sql, new List<object>());
        }

        public override ProductsDTO selectById(string id)
        {
            string sql = "SELECT * FROM Products WHERE ProductID=@0";
            List<object> parameters = new List<object> { id };
            List<ProductsDTO> list = selectBySql(sql, parameters);
            return list.Count > 0 ? list[0] : null;
        }

        public override List<ProductsDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<ProductsDTO> list = new List<ProductsDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    ProductsDTO entity = new ProductsDTO();
                    entity.ProductID = reader["ProductID"].ToString();
                    entity.ProductName = reader["ProductName"].ToString();
                    entity.ProductTypeID = reader["ProductTypeID"].ToString();
                    entity.ManufacturerID = reader["ManufacturerID"].ToString();
                    entity.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                    entity.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
                    entity.Description = reader["Description"].ToString();
                    entity.ImagePath = reader["ImagePath"].ToString();
                    entity.Status = reader.GetBoolean(reader.GetOrdinal("Status"));


                    string manufacturerID = "";
                    // lấy mã nhà sản xuất từ bảng Manufacturers
                    string sqlmanufacturer = "SELECT ManufacturerName FROM Manufacturers WHERE ManufacturerID = @0";
                    List<object> parammanufacturerID = new List<object> { entity.ManufacturerID };
                    SqlDataReader manufacturerReader = DBUtil.Query(sqlmanufacturer, parammanufacturerID);
                    if (manufacturerReader.Read())
                    {
                        manufacturerID = manufacturerReader["ManufacturerName"].ToString();
                    }
                    manufacturerReader.Close();

                    string productTypeID = "";
                    // lấy mã loại sản phẩm từ bảng ProductTypes
                    string sqlProductType = "SELECT ProductTypeName FROM ProductTypes WHERE ProductTypeID = @0";
                    List<object> paramProductTypeID = new List<object> { entity.ProductTypeID };
                    SqlDataReader productTypeReader = DBUtil.Query(sqlProductType, paramProductTypeID);
                    if (productTypeReader.Read())
                    {
                        productTypeID = productTypeReader["ProductTypeName"].ToString();
                    }
                    productTypeReader.Close();

                    list.Add(entity);
                }
                reader.Close();

            }
            catch (Exception ex) { 
                throw new Exception("Lỗi khi thực hiện truy vấn: " + ex.Message);
            }
            return list;
        }

        public override void insert(ProductsDTO entity)
        {
            string sql = "INSERT INTO Products (ProductID, ProductName, ProductTypeID, ManufacturerID, UnitPrice, Stock, Description, ImagePath, Status) " +
                         "VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
            List<object> parameters = new List<object>
            {
                entity.ProductID,
                entity.ProductName,
                entity.ProductTypeID,
                entity.ManufacturerID,
                entity.UnitPrice,
                entity.Stock,
                entity.Description,
                entity.ImagePath,
                entity.Status
            };
            DBUtil.Update(sql, parameters);
        }
        public override void update(ProductsDTO entity)
        {
            string sql = "UPDATE Products SET ProductName=@1, ProductTypeID=@2, ManufacturerID=@3, UnitPrice=@4, Stock=@5, Description=@6, ImagePath=@7, Status=@8 " +
                         "WHERE ProductID=@0";
            List<object> parameters = new List<object>
            {
                entity.ProductID,
                entity.ProductName,
                entity.ProductTypeID,
                entity.ManufacturerID,
                entity.UnitPrice,
                entity.Stock,
                entity.Description,
                entity.ImagePath,
                entity.Status,
            };
            DBUtil.Update(sql, parameters);
        }

        public override void delete(string id)
        {
            string sql = "DELETE FROM Products WHERE ProductID=@0";
            List<object> parameters = new List<object> { id };
            DBUtil.Update(sql, parameters);
        }

        public decimal getTotalPrice()
        {
            string sql = "SELECT SUM(UnitPrice * Stock) FROM Products";
            object result = DBUtil.ScalarQuery(sql, new List<object>());
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        public bool isDiscontinued(string productId)
        {
            string sql = "SELECT Status FROM Products WHERE ProductID = @0";
            List<object> parameters = new List<object> { productId };
            try
            {
                object result = DBUtil.ScalarQuery(sql, parameters);
                // Giả sử Status = 'Discontinued' là ngưng bán, 'Active' là đang bán
                return result != null && result.ToString() == "Discontinued";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra trạng thái sản phẩm: " + ex.Message);
            }

        }

        public List<ProductsDTO> searchByName(string productName)
        {
            string sql = "SELECT * FROM Products WHERE ProductName LIKE @0";
            List<object> parameters = new List<object> { "%" + productName + "%" };
            return selectBySql(sql, parameters);
        }
        public List<ProductsDTO> searchByType(string productType)
        {
            string sql = "SELECT * FROM Products WHERE ProductTypeID = @0";
            List<object> parameters = new List<object> { productType };
            return selectBySql(sql, parameters);
        }
        public List<ProductsDTO> searchByManufacturer(string manufacturerId)
        {
            string sql = "SELECT * FROM Products WHERE ManufacturerID = @0";
            List<object> parameters = new List<object> { manufacturerId };
            return selectBySql(sql, parameters);
        }

        public decimal getDonGiaByMa(string maSanPham)
        {
            string sql = "SELECT UnitPrice FROM Products WHERE ProductID = @0";
            List<object> thamSo = new List<object> { maSanPham };

            try
            {
                object result = DBUtil.ScalarQuery(sql, thamSo);
                return result != null ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy đơn giá sản phẩm: " + ex.Message);
            }
        }

        // phieu ban hang -- trang thai 
        public bool IsDiscontinued(string maSanPham)
        {
            string sql = "SELECT Status FROM Products WHERE ProductID = @0";
            List<object> thamSo = new List<object> { maSanPham };
            try
            {
                object result = DBUtil.ScalarQuery(sql, thamSo);
                // Giả sử TrangThai = false là ngưng bán, true là đang bán
                return result != null && !Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra trạng thái sản phẩm: " + ex.Message);
            }
        }


    }
}
