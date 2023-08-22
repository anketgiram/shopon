using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Util
{
    public class ProductByNameComparer: IComparer<Product>
    {
        public int Compare(Product x, Product y)
           => x.ProductName.CompareTo(y.ProductName);
    }
}
