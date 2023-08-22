using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Util;
using ShoponCommonLayer.CustomExceptions;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoponBusinessLayer.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository productRepo)
        {
            this.productRepository = productRepo;
        }
        public bool AddProduct(Product product, out string errorMsg)
        {
            try
            {
                return productRepository.AddProduct(product, out errorMsg);
            }
            catch (DuplicateProductException de)
            {
                throw new DuplicateProductException("Duplicate Product Entry", de);

            }
        }

        public bool DeleteProduct(int deleteProductId)
            => productRepository.DeleteProduct(deleteProductId);
       
        public Product GetProductById(int prodId)
            => productRepository.GetProductById(prodId);
        

        public IEnumerable<Product> GetProducts(bool isCompanyRequired = false)
            => productRepository.GetProducts(isCompanyRequired);

        public IEnumerable<Product> SearchByKey(string key)
            => productRepository.Search(key);

        public IEnumerable<Product> SortById()
        {
            var result = this.productRepository.GetProducts();
            var sortedData = result.ToList();
            sortedData.Sort(new ProductByIdComparer());
            return sortedData;
        }

        public IEnumerable<Product> SortByName()
        {
            var result = this.productRepository.GetProducts();
            var sortedData = result.ToList();
            sortedData.Sort(new ProductByNameComparer());
            return sortedData;
        }

        public IEnumerable<Product> SortByPrice()
        {
            var result = this.productRepository.GetProducts();
            var sortedData = result.ToList();
            sortedData.Sort(new ProductByPriceComparer());
            return sortedData;
        }

        public bool UpdateProduct(Product updatedproduct)
            => productRepository.UpdateProduct(updatedproduct);
       
    }
}
