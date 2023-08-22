using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkartEF.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        [ForeignKey("Order")]
        public int Orderid { get; set; }
        public virtual Order Order { get; set; }
    }
}
