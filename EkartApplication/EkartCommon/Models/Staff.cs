using System.Collections.Generic;

namespace EkartCommon.Models
{
    public class Staff
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
