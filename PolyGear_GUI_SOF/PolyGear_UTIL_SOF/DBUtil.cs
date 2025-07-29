using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_UTIL_SOF
{
    public class DBUtil
    {
        private static string connString = "Data Source=.;Database=PolyGear;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public static SqlCommand GetCommand(string sql, List<Object> args, CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            for (int i = 0; i < args.Count; i++)
            {
                if (args[i] is SqlParameter param)
                {
                    cmd.Parameters.Add(param);
                }
                else
                {
                    cmd.Parameters.AddWithValue($"@{i}", args[i]);
                }
            }
            return cmd;
        }

        public static void Update(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            SqlCommand cmd = GetCommand(sql, args, cmdType);
            cmd.Connection.Open();
            cmd.Transaction = cmd.Connection.BeginTransaction();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                throw;
            }

        }

        public static SqlDataReader Query(string sql, List<Object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static object Value(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                object result = new object();

                if (reader.HasRows)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        PropertyInfo propertyInfo = result.GetType().GetProperty(columnName);

                        if (propertyInfo != null)
                        {
                            var value = reader.IsDBNull(i) ? null : reader[columnName];
                            propertyInfo.SetValue(result, value);
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object ScalarQuery(string sql, List<object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@{i + i}", parameters[i] ?? DBNull.Value);
                    }
                    object result = command.ExecuteScalar();
                    return result;
                }
            }
        }


        public static DataTable GetDataTable(string sql, List<object> args = null, CommandType cmdType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;

                if (args != null)
                {
                    for (int i = 0; i < args.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@{i}", args[i] ?? DBNull.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public static object ExecuteScalarQuery(string sql, List<SqlParameter> parameters = null, CommandType cmdType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

    }
}
