using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoponDataLayer.Contracts
{
    public interface IProductRepository
    {
        /// <summary>
        /// Method to Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        bool AddProduct(Product product, out string errorMsg);
        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <param name="isCompanyRequired"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(bool isCompanyRequired=false);
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProductById(int productId);
        /// <summary>
        /// Method to Update the product informations
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool UpdateProduct(Product product);
        /// <summary>
        /// Method to delete product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        bool DeleteProduct(int productId);
        /// <summary>
        /// Method to search by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<Product> Search(string key);

    }
}
