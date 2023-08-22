using System;
using System.Collections.Generic;

#nullable disable

namespace EkartEF.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerMobileNo { get; set; }
        public string AppCustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
