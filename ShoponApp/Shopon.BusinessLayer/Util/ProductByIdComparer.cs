using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Util
{
    public class ProductByIdComparer:IComparer<Product>
    {
        public int Compare(Product x, Product y)
            => x.PId.CompareTo(y.PId);
        
    }
}
