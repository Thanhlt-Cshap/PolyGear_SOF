using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class SalesOrdersDTO
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public bool Status { get; set; }
    }
}
