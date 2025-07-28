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
    public class ProductTypeDAL : BaseDAL<ProductTypesDTO, string>
    {
        // Hàm này sẽ tạo mã  tự động
        public string generateAutoProductType()
        {
            string prefix = "TP";
            string sql = "SELECT TOP 1 ProductTypeID FROM ProductTypes WHERE ProductTypeID LIKE 'TP%' ORDER BY ProductTypeID DESC";
            try
            {
                object result = DBUtil.ScalarQuery(sql, new List<object>());
                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string lastProductTypeID = result.ToString();
                    string numberPart = new string(lastProductTypeID.Skip(2).ToArray());
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
                throw new Exception("Lỗi khi lấy mã loại sản phẩm mới nhất: " + ex.Message);
            }
        }

        public override List<ProductTypesDTO> selectAll()
        {
            string sql = "SELECT * FROM ProductTypes";
            return selectBySql(sql, new List<object>());
        }
        public override ProductTypesDTO selectById(string id)
        {
            string sql = "SELECT * FROM ProductTypes WHERE ProductTypeID=@0";
            List<object> parameters = new List<object> { id };
            List<ProductTypesDTO> list = selectBySql(sql, parameters);
            return list.Count > 0 ? list[0] : null;
        }
        public override List<ProductTypesDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<ProductTypesDTO> list = new List<ProductTypesDTO>();
            SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
            while (reader.Read())
            {
                ProductTypesDTO productType = new ProductTypesDTO
                {
                    ProductTypeID = reader["ProductTypeID"].ToString(),
                    ProductTypeName = reader["ProductTypeName"].ToString(),
                    Description = reader["Description"].ToString(),
                    Status = Convert.ToBoolean(reader["Status"])
                };
                list.Add(productType);
            }
            reader.Close();
            return list;
        }

        public override void insert(ProductTypesDTO entity)
        {
            string sql = "INSERT INTO ProductTypes (ProductTypeID, ProductTypeName, Description, Status) VALUES (@0, @1, @2, @3)";
            List<object> parameters = new List<object>
            {
                entity.ProductTypeID,
                entity.ProductTypeName,
                entity.Description,
                entity.Status
            };
            DBUtil.Update(sql, parameters);
        }

        public override void update(ProductTypesDTO entity)
        {
            string sql = "UPDATE ProductTypes SET ProductTypeName=@1, Description=@2, Status=@3 WHERE ProductTypeID=@0";
            List<object> parameters = new List<object>
            {
                entity.ProductTypeID,
                entity.ProductTypeName,
                entity.Description,
                entity.Status
            };
            DBUtil.Update(sql, parameters);
        }
        public override void delete(string id)
        {
            string sql = "DELETE FROM ProductTypes WHERE ProductTypeID=@0";
            List<object> parameters = new List<object> { id };
            DBUtil.Update(sql, parameters);
        }
    }
}
