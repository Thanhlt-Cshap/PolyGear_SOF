using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyGear_DTO_SOF;

namespace PolyGear_UTIL_SOF
{
    public class AuthUtil
    {
        public static AccountsDTO? user = null;

        /// <summary>
        /// Đăng xuất người dùng hiện tại.
        /// </summary>
        public static void Logout()
        {
            user = null;
        }

        /// <summary>
        /// Kiểm tra trạng thái đăng nhập.
        /// </summary>
        public static Boolean IsLogin()
        {
            return user != null;
        }

        /// <summary>
        /// Kiểm tra quyền  của tài khoản.
        /// </summary>


        /// <summary>
        /// Kiểm tra tài khoản có quyền Chủ cửa hàng không.
        /// </summary>
        public static bool IsStoreOwner()
        {
            return user != null && user.RoleID == "RL0001";
        }

        /// <summary>
        /// Kiểm tra tài khoản có quyền Quản lý không.
        /// </summary>
        public static bool IsManager()
        {
            return user != null && user.RoleID == "RL0002";
        }

        /// <summary>
        /// Kiểm tra tài khoản có quyền Nhân viên không.
        /// </summary>
        public static bool IsEmployee()
        {
            return user != null && user.RoleID == "RL0003";
        }

    }
}
