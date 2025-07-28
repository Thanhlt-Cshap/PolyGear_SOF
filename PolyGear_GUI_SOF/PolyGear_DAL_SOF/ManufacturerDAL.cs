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
    public class ManufacturerDAL : BaseDAL<ManufacturersDTO, string>
    {
        // Hàm này sẽ tạo mã nhà sản xuất tự động
        public string generateAutoManufacturer()
        {
            string prefix = "MF"; // Tiền tố cho mã nhà sản xuất
            string sql = "SELECT TOP 1 ManufacturerID FROM Manufacturers ORDER BY ManufacturerID DESC"; // Lấy mã khách hàng mới nhất
            try
            {
                object result = DBUtil.ScalarQuery(sql, new List<object>());
                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string lastManufacturerID = result.ToString();
                    // Tách phần số từ mã nhân viên mới nhất
                    string numberPart = new string(lastManufacturerID.Skip(2).ToArray());
                    if (int.TryParse(numberPart, out int nextNumber))
                    {
                        nextNumber++; // Tăng số lên 1 và tạo mã mới
                        return $"{prefix}{nextNumber:D4}"; // Định dạng với 4 chữ số
                    }
                }
                return $"{prefix}0001"; // 
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã nhà sản xuất mới nhất: " + ex.Message);
            }
        }

        public override List<ManufacturersDTO> selectAll()
        {
            string sql = "SELECT * FROM Manufacturers";
            return selectBySql(sql, new List<object>());
        }

        public override ManufacturersDTO selectById(String id)
        {
            String sql = "SELECT * FROM Manufacturers WHERE ManufacturerID=@0";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            List<ManufacturersDTO> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public override List<ManufacturersDTO> selectBySql(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            List<ManufacturersDTO> list = new List<ManufacturersDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    ManufacturersDTO entity = new ManufacturersDTO();
                    entity.ManufacturerID = reader["ManufacturerID"].ToString();
                    entity.ManufacturerName = reader["ManufacturerName"].ToString();
                    entity.Description = reader["Description"].ToString();
                    entity.Status = Convert.ToBoolean(reader["Status"]);
                    list.Add(entity);
                }
                ;

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn dữ liệu nhà sản xuất: " + ex.Message);
            }
            return list;
        }

        public override void insert(ManufacturersDTO entity)
        {
            string sql = "INSERT INTO Manufacturers (ManufacturerID, ManufacturerName, Description, Status) VALUES (@0, @1, @2, @3)";
            List<Object> thamSo = new List<Object>
            {
                entity.ManufacturerID,
                entity.ManufacturerName,
                entity.Description,
                entity.Status
            };
            DBUtil.Update(sql, thamSo);
        }

        public override void update(ManufacturersDTO entity)
        {
            string sql = "UPDATE Manufacturers SET ManufacturerName=@0,Description=@1, Status=@2 WHERE ManufacturerID=@3";
            List<Object> thamSo = new List<Object>
            {
                entity.ManufacturerName,
                entity.Description,
                entity.Status,
                entity.ManufacturerID
            };
            DBUtil.Update(sql, thamSo);
        }

        public override void delete(string id)
        {
            string sql = "DELETE FROM Manufacturers WHERE ManufacturerID=@0";
            List<Object> thamSo = new List<Object> { id };
            DBUtil.Update(sql, thamSo);
        }

    }
}
