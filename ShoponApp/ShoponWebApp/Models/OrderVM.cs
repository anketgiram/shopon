using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Models
{
    public class OrderVM
    {
       
            public int OrderId { get; set; }
            public int ClientOrderId { get; set; }

            public DateTime OrderDate { get; set; }
            public double OrderAmount { get; set; }
            public DateTime ActualDeliveryDate { get; set; }
            public DateTime ExpectedDeliveryDate { get; set; }

            public int CustomerId { get; set; }
            public Customer Customer { get; set; }

            public int OrderStatusId { get; set; }



            public OrderStatus OrderStatus { get; set; }
            public virtual ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();

        }
        public class OrderItem
        {
            public int OrderItemId { get; set; }
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public int Qty { get; set; }
            public double Price { get; set; }

        }
        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerMobileNo { get; set; }
            public string EmailID { get; set; }
            public bool IsDeleted { get; set; }
            public string AppCustomerId { get; set; }
            public CustomerAddress CustomerAddress { get; set; }
        }
        public class CustomerAddress
        {
            public int CustomerAddressId { get; set; }
            public string CustomerId { get; set; }
            public string StName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }
        public class OrderStatus
        {
            public int OrderStatusId { get; set; }
            public string OrderStatusType { get; set; }
            public string Description { get; set; }
        }
    }

