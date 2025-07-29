using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PolyGear_DAL_SOF;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace DAL_SOF205
{
    public class AccountDAL : SystemDAL.BaseDAL<AccountsDTO, string>
    {
        public override List<AccountsDTO> selectAll()
        {
            string sql = "SELECT A.*, R.RoleName \r\nFROM Accounts A\r\nJOIN Roles R ON A.RoleID = R.RoleID\r\n";
            return selectBySql(sql, new List<object>());
        }
        public override List<AccountsDTO> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<AccountsDTO> list = new List<AccountsDTO>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    AccountsDTO entity = new AccountsDTO
                    {
                        AccountID = reader["AccountID"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleID = reader["RoleID"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"]),
                        RoleName = reader["RoleName"].ToString(),
                        IsFirstLogin = reader["IsFirstLogin"] != DBNull.Value && Convert.ToBoolean(reader["IsFirstLogin"])

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

        public override AccountsDTO selectById(string id)
        {
            string sql = "SELECT A.*, R.RoleName FROM Accounts A JOIN Roles R ON A.RoleID = R.RoleID WHERE A.AccountID = @0";
            List<AccountsDTO> list = selectBySql(sql, new List<object> { id });
            return list.Count > 0 ? list[0] : null;
        }

        public override void insert(AccountsDTO entity)
        {
            string sql = @"INSERT INTO Accounts (AccountID, Username, Password, RoleID, Status, IsFirstLogin)
               VALUES (@0, @1, @2, @3, @4, @5)";
            DBUtil.Update(sql, new List<object> {
    entity.AccountID,
    entity.Username,
    entity.Password,
    entity.RoleID,
    entity.Status,
    entity.IsFirstLogin
});
        }

        public override void update(AccountsDTO entity)
        {
            string sql = @"UPDATE Accounts SET 
                Username = @0, 
                Password = @1, 
                RoleID = @2, 
                Status = @3,
                IsFirstLogin = @4
               WHERE AccountID = @5";

            DBUtil.Update(sql, new List<object> {
    entity.Username,
    entity.Password,
    entity.RoleID,
    entity.Status,
    entity.IsFirstLogin,
    entity.AccountID
});

        }

        public override void delete(string id)
        {
            string sql = "DELETE FROM Accounts WHERE AccountID = @0";
            DBUtil.Update(sql, new List<object> { id });
        }
        public void deleteByUsername(string username)
        {
            string sql = "DELETE FROM Accounts WHERE Username = @0";
            DBUtil.Update(sql, new List<object> { username });
        }





        public AccountsDTO selectByUsernamePassword(string username, string password)
        {
            string sql = @"SELECT A.*, R.RoleName 
               FROM Accounts A 
               JOIN Roles R ON A.RoleID = R.RoleID 
               WHERE A.Username = @Username AND A.Password = @Password";
            List<object> parameters = new List<object>
{
    new SqlParameter("@Username", username),
    new SqlParameter("@Password", password)
};
            List<AccountsDTO> list = selectBySql(sql, parameters);

            return list.FirstOrDefault();
        }
        public List<AccountsDTO> selectAccountsWithEmployee_DTO()
        {
            string sql = @"
        SELECT 
            a.AccountID, a.Username, a.Password, a.RoleID, r.RoleName, a.Status AS AccountStatus,
            e.EmployeeID, e.FullName, e.DateOfBirth, e.Gender, e.Phone, e.Email, e.Address, e.Status AS EmpStatus
        FROM 
            Accounts a
        JOIN Roles r ON a.RoleID = r.RoleID
        JOIN Employees e ON a.AccountID = e.AccountID";

            DataTable dt = DBUtil.GetDataTable(sql, new List<object>());
            List<AccountsDTO> list = new List<AccountsDTO>();

            foreach (DataRow row in dt.Rows)
            {
                var acc = new AccountsDTO
                {
                    AccountID = row["AccountID"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    RoleID = row["RoleID"].ToString(),
                    Status = Convert.ToBoolean(row["AccountStatus"]),
                    RoleName = row["RoleName"].ToString(),

                    EmployeeInfo = new EmployeesDTO
                    {
                        EmployeeID = row["EmployeeID"].ToString(),
                        FullName = row["FullName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        Gender = row["Gender"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),
                        Address = row["Address"].ToString(),
                        Status = Convert.ToBoolean(row["EmpStatus"])
                    }
                };

                list.Add(acc);
            }

            return list;
        }
        public string GenerateNewAccountID()
        {
            string prefix = "AC";
            int max = 0;

            var list = selectAll(); // Lấy tất cả tài khoản

            foreach (var acc in list)
            {
                if (acc.AccountID.StartsWith(prefix))
                {
                    string numberPart = acc.AccountID.Substring(prefix.Length); // Lấy phần số
                    if (int.TryParse(numberPart, out int num))
                    {
                        if (num > max) max = num;
                    }
                }
            }

            return $"{prefix}{(max + 1).ToString("D4")}"; // Format thành AC0001, AC0011,...
        }

        public bool CheckDuplicateUsername(string username, string currentEmployeeId)
        {
            string sql = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND AccountID <> @AccountID";
            List<object> parameters = new List<object>
    {
        new SqlParameter("@Username", username),
        new SqlParameter("@AccountID", currentEmployeeId)
    };

            object result = DBUtil.ExecuteScalarQuery(sql, parameters.Cast<SqlParameter>().ToList());
            int count = Convert.ToInt32(result);

            return count > 0;
        }



    }

}
