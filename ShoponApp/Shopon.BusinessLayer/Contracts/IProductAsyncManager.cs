using ShoponCommonLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Contracts
{
    public interface IProductAsyncManager
    {
        /// <summary>
        /// Method to add product and return newly created product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> AddProduct(Product product);
        /// <summary>
        /// Method to get all the products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();
        /// <summary>
        /// Method to search for products based on a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> Search(string key);
        /// <summary>
        /// Method to get product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int productId);
        /// <summary>
        /// Mathod to upadte product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateProduct(Product product);
        /// <summary>
        /// Method to delete product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeleteProduct(int productId);

    }
}
