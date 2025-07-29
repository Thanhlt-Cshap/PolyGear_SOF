using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace DAL_SOF205
{
    public class EmployeesDAL : SystemDAL.BaseDAL<EmployeesDTO, string>
    {

        public bool CheckDuplicateUsername(string username, string currentEmployeeId)
        {
            string sql = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND AccountID <> @AccountID";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Username", username),
        new SqlParameter("@AccountID", currentEmployeeId)
    };

            object result = DBUtil.ExecuteScalarQuery(sql, parameters);
            int count = Convert.ToInt32(result);

            return count > 0;
        }



        public override List<EmployeesDTO> selectAll()
        {
            string sql = "SELECT * FROM Employees";
            return selectBySql(sql, new List<object>());
        }

        public override EmployeesDTO selectById(string id)
        {
            string sql = "SELECT * FROM Employees WHERE EmployeeID = @0";
            var parameters = new List<object> { id };
            var result = selectBySql(sql, parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public override List<EmployeesDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<EmployeesDTO> list = new List<EmployeesDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    EmployeesDTO entity = new EmployeesDTO
                    {
                        EmployeeID = reader["EmployeeID"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        AccountID = reader["AccountID"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"])
                    };
                    list.Add(entity);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public override void insert(EmployeesDTO entity)
        {
            string sql = @"INSERT INTO Employees 
                (EmployeeID, FullName, DateOfBirth, Gender, Phone, Email, Address, AccountID, Status) 
                VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";

            List<object> parameters = new List<object>
            {
                entity.EmployeeID,
                entity.FullName,
                entity.DateOfBirth,
                entity.Gender,
                entity.Phone,
                entity.Email,
                entity.Address,
                entity.AccountID,
                entity.Status
            };
            DBUtil.Update(sql, parameters);
        }

        public override void update(EmployeesDTO entity)
        {
            string sql = @"UPDATE Employees SET 
                FullName = @1, 
                DateOfBirth = @2, 
                Gender = @3, 
                Phone = @4, 
                Email = @5, 
                Address = @6, 
                AccountID = @7, 
                Status = @8 
                WHERE EmployeeID = @0";

            List<object> parameters = new List<object>
            {
                entity.EmployeeID,
                entity.FullName,
                entity.DateOfBirth,
                entity.Gender,
                entity.Phone,
                entity.Email,
                entity.Address,
                entity.AccountID,
                entity.Status
            };

            DBUtil.Update(sql, parameters);
        }

        public override void delete(string id)
        {
            string sql = "DELETE FROM Employees WHERE EmployeeID = @0";
            List<object> parameters = new List<object> { id };
            DBUtil.Update(sql, parameters);
        }

        public string GenerateAutoEmployeeID()
        {
            string sql = "SELECT EmployeeID FROM Employees WHERE EmployeeID LIKE 'NV%'";
            List<int> numbers = new List<int>();

            try
            {
                using (SqlDataReader reader = DBUtil.Query(sql, new List<object>()))
                {
                    while (reader.Read())
                    {
                        string id = reader["EmployeeID"].ToString();
                        if (id.Length > 2 && int.TryParse(id.Substring(2), out int num))
                        {
                            numbers.Add(num);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating EmployeeID: " + ex.Message);
            }

            int nextNumber = (numbers.Count > 0) ? numbers.Max() + 1 : 1;
            return "NV" + nextNumber.ToString("D4");
        }

    }
}
