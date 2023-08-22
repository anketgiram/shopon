using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public String OrderStatusType { get; set; }
        public String Description { get; set; }
    }
}
