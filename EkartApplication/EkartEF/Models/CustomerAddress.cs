using System;
using System.Collections.Generic;

#nullable disable

namespace EkartEF.Models
{
    public partial class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public string StName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
