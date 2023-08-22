using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Order
    {
        private List<OrderItem> orderItems = new List<OrderItem>();
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string AspCustomerId { get; set; }

        /// <summary>
        /// Method to Add new order item
        /// </summary>
        /// <param name="orderItem"></param>
        public void AddOrderItem(OrderItem orderItem)
        {
            this.orderItems.Add(orderItem);
        }
        /// <summary>
        /// Method to get all order items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return this.orderItems;
        }
        /// <summary>
        /// Method to get total order value
        /// </summary>
        /// <returns></returns>
        public double GetOrderTotal()
        {
            return 0.0;
        }

    }
}
