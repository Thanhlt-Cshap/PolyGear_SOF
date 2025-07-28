using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class ManufacturersDTO
    {
        public string ManufacturerID { get; set; } // Mã nhà sản xuất
        public string? ManufacturerName { get; set; } // Tên nhà sản xuất
        public string? Description { get; set; } // Mô tả về nhà sản xuất
        public bool Status { get; set; } // Trạng thái hoạt động của nhà sản xuất
    }
}
