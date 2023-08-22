using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientOrderId { get; set; }
        public DateTime DateTime { get; set; }
        public double OrderAmount { get; set; }
        public DateTime ExceptedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string StaffId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public void AddOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Add(orderItem);
        }
    }
}
