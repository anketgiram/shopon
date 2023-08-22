using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkartEF.Models
{
    [Table("Orderd")]
    public class Order
    {
        [Key]   //--> this for primary key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // --> this for auto incremenated
        public int OrderId { get; set; }
        public int ClientOrderId { get; set; }
        public DateTime DateTime { get; set; }
        public double OrderAmount { get; set; }
        public DateTime ExceptedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string StaffId { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public void AddOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Add(orderItem);
        }
    }
}
