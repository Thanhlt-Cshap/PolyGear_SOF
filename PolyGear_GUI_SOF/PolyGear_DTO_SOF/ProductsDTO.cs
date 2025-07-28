using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class ProductsDTO
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductTypeID { get; set; }
        public string? ManufacturerID { get; set; }
        public Decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public bool Status { get; set; }



    }
}
