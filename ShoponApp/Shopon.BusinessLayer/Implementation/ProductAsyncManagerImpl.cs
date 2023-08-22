using ShoponBusinessLayer.Contracts;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Implementation
{
    public class ProductAsyncManagerImpl : IProductAsyncManager
    {
        private readonly IProductAsyncRepository asyncRepository;

        public ProductAsyncManagerImpl(IProductAsyncRepository asyncRepository)
        {
            this.asyncRepository = asyncRepository;
        }
        public Task<Product> AddProduct(Product product)
            => this.asyncRepository.AddProduct(product);

        public Task DeleteProduct(int productId)
            => this.asyncRepository.DeleteProduct(productId);

        public Task<Product> GetProductById(int productId)
            => this.asyncRepository.GetProductById(productId);

        public Task<IEnumerable<Product>> GetProducts()
            => this.asyncRepository.GetProducts();

        public Task<IEnumerable<Product>> Search(string key)
            => this.asyncRepository.Search(key);

        public Task<Product> UpdateProduct(Product product)
            => this.asyncRepository.UpdateProduct(product);
    }
}
