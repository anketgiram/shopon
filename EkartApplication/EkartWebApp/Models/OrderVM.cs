using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkartWebApp.Models
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public double TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string stName { get; set; }
        public string City { get; set; }
    }
}
