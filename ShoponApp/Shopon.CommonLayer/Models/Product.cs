using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Product
    {
        public int PId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string AvailableStatus { get; set; }
        public string ImageUrl { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public Company Company { get; set; }
        public Category Category { get; set; }

    }
}
