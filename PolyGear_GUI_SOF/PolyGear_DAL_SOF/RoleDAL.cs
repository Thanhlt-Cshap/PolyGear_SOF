using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyGear_DTO_SOF;
using PolyGear_UTIL_SOF;

namespace PolyGear_DAL_SOF
{
    public class RoleDAL
    {
        public List<RoleDTO> selectAll()
        {
            string sql = "SELECT * FROM Roles";
            SqlDataReader reader = DBUtil.Query(sql, new List<object>());
            List<RoleDTO> list = new List<RoleDTO>();

            while (reader.Read())
            {
                list.Add(new RoleDTO
                {
                    RoleID = reader["RoleID"].ToString(),
                    RoleName = reader["RoleName"].ToString()
                });
            }

            reader.Close();
            return list;
        }
    }
}
