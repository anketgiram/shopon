using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public string EmailID { get; set; }
        public bool isDeleted { get; set; }
        public string appCustomerId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }

        public IEnumerable<Order> orders { get; } = new List<Order>();

        public void AddOrder(Order order)
        {
            this.orders.Equals(order);
        }
    }
}
