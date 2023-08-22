using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class OrderItem
    {
        
        public Product Product { get; set; }
        public int Pid { get; set; }
        public int Qty { get; set; }

        private List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }
        public IEnumerable<Product> GetProducts()
        {
            return this.products;
        }
        public double GetAmount()
        {
            return Qty * Product.Price;
        }
    }
}
