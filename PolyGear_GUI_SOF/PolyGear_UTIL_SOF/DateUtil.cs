using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_UTIL_SOF
{
    public class DateUtil
    {
        public static class DatePattern
        {
            public static readonly String Date = "dd/MM/yyyy";
            public static readonly String DateTime = "HH:mm:ss dd/MM/yyyy";

            ///note
            ///

        }

        /// <summary>
        /// Chuyển đổi String sang DateTime
        /// </summary>
        /// <param name="dateString">Chuỗi ngày cần chuyển</param>
        /// <param name="pattern">Mẫu định dạng</param>
        /// <returns>DateTime đã chuyển đổi</returns>
        public static DateTime ToDateTime(String dateString, String pattern)
        {
            try
            {
                return DateTime.ParseExact(dateString, pattern, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Chuyển đổi DateTime sang String
        /// </summary>
        /// <param name="date">Thời gian cần chuyển</param>
        /// <param name="pattern">Mẫu định dạng</param>
        /// <returns>String đã chuyển đổi</returns>
        public static String ToString(DateTime date, String pattern)
        {
            return date.ToString(pattern);
        }
    }
}
