using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStatus { get; set; }

        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.products;
        }
    }
}
