using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyGear_DTO_SOF
{
    public class Customers
    {
        public string? CustomerID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }

}
