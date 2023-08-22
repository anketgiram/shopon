using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoponBusinessLayer.Contracts
{
    public interface IProductManager
    {
        /// <summary>
        /// Method to add product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        bool AddProduct(Product product, out string errorMsg);

        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(bool isCompanyRequired = false);

        /// <summary>
        /// Method to get the product by Id
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        Product GetProductById(int prodId);

        /// <summary>
        /// Method to update the product details
        /// </summary>
        /// <param name="updatedproduct"></param>
        /// <returns></returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// Method to delete the product
        /// </summary>
        /// <param name="deleteProduct"></param>
        /// <returns></returns>
        bool DeleteProduct(int deleteProductId);

        /// <summary>
        /// Method to sort the product by Id
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> SortById();

        /// <summary>
        /// Method to sort the product by name
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> SortByName();

        /// <summary>
        /// Method to sort the product by price
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> SortByPrice();
        /// <summary>
        /// Method to search product by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<Product> SearchByKey(string key);
    }
}
