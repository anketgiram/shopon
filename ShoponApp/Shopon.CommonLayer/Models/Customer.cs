using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        
        private List<Order> orders = new List<Order>();
        public CustomerAddress CustomerAddress { get; set; }

        public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }
        public IEnumerable<Order> GetOrders()
        {
            return this.orders;
        }
    }
}
