using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EkartEF.Models
{
    public class Staff : IdentityUser
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
