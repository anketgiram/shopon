using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public string CustomerId { get; set; }
        public string StName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
