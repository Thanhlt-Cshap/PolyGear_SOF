using System;
using System.Text.RegularExpressions;
using PolyGear_DTO_SOF;

namespace PolyGear_UTIL_SOF
{
    public static class EmployeeValidation
    {
        // Kiểm tra định dạng email
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Kiểm tra email có trùng không (dựa vào danh sách Employees)
        public static bool IsEmailDuplicate(string email, List<EmployeesDTO> list)
        {
            return list.Any(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // Bạn có thể thêm các hàm kiểm tra khác nếu cần, ví dụ:
        public static bool IsValidPhoneNumber(string phone)
        {
            var pattern = @"^(0|\+84)[1-9][0-9]{8}$"; // Số Việt Nam cơ bản
            return Regex.IsMatch(phone, pattern);
        }

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                return false;

            // Kiểm tra tất cả ký tự phải là chữ hoặc khoảng trắng (cho phép tên có khoảng trắng)
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }

            return true;
        }

        public static bool IsPhoneDuplicate(string phone, List<EmployeesDTO> list, string currentEmployeeID)
        {
            return list.Any(e => e.Phone == phone && e.EmployeeID != currentEmployeeID);
        }


        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            return char.IsLetter(username[0]);
        }

    }
}
