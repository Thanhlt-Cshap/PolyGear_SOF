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

        public EmployeeDTO EmployeeInfo { get; set; } // Thêm dòng này



        public AccountsDTO() { }


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
