using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoponDataLayer.Implementation
{
    public class ProductRepositoryArrayImpl
    { 
        //int CAPACITY = 10;
        //Product[] products = null;
        //int index = 0;

        //public ProductRepositoryArrayImpl()
        //{
        //    this.products = new Product[CAPACITY];
        //}
        //public ProductRepositoryArrayImpl(int initCap)
        //{
        //    this.products = new Product[initCap];
        //}
        ////CRUD
        ///// <summary>
        ///// method to insert product
        ///// </summary>
        ///// <param name="product"></param>
        ///// <returns></returns>
        //public bool AddProduct(Product product)
        //{
        //    bool isAdded = false;
        //    if (index == products.Length)
        //    {
        //        //1.create temp array
        //        var temp = new Product[products.Length];
        //        Array.Copy(products, temp, products.Length);
        //        this.products = new Product[products.Length * 2];
        //        Array.Copy(temp, this.products, temp.Length);
        //        temp = null;
        //    }
        //    products[index++] = product;
        //    isAdded = true;
        //    return isAdded;

        //}
        ///// <summary>
        ///// method to get all product in the repository
        ///// </summary>
        ///// <returns></returns>
        //public Product[] GetProducts()
        //{
        //    var temp = new Product[index];
        //    Array.Copy(products, temp, index);
        //    return temp;
        //}
        ///// <summary>
        ///// Method to update the pproduct
        ///// </summary>
        ///// <param name="product1"></param>
        ///// <returns></returns>
        //public bool UpdateProduct(Product product)
        //{
        //    bool isUpdated = false;
        //    foreach (var product1 in products)
        //    {
        //        if(product1.PId==product.PId)
        //        {
        //            product.ProductName = product.ProductName;
        //            product.Price = product.Price;
        //            isUpdated = true;
        //        }
               
        //    }
        //    return isUpdated;
        //}
        ///// <summary>
        ///// Delete the Product
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <returns></returns>
        //public bool DeleteProduct(int productId)
        //{
        //    bool isDeleted = false;
        //    return isDeleted;
        //}
    }
}
