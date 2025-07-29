using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class ChangePasswordDTO
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }      // Mật khẩu cũ
        public string NewPassword { get; set; }      // Mật khẩu mới
        public string ConfirmPassword { get; set; }  // Xác nhận mật khẩu mới
    }
}
