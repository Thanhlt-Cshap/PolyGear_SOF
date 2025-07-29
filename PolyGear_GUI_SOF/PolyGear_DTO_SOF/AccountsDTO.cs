using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class AccountsDTO
    {

        public string AccountID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleID { get; set; }
        public bool Status { get; set; }
        public string RoleName { get; set; }
        public bool IsFirstLogin { get; set; }


        public EmployeesDTO EmployeeInfo { get; set; } // Thêm dòng này

        public static class Session
        {
            public static string CurrentAccountID { get; set; }
        }


        public AccountsDTO() 
        {
            IsFirstLogin = true;
        }


        public override string ToString()
        {
            return RoleName; // Để ComboBox hiển thị RoleName
        }
        public AccountsDTO(string accountID, string username, string password, string roleID, bool status)
        {
            AccountID = accountID;
            Username = username;
            Password = password;
            RoleID = roleID;
            Status = status;

        }



    }
}
