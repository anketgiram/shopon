using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public int Orderid { get; set; }
        public  Order Order { get; set; }
    }
}
