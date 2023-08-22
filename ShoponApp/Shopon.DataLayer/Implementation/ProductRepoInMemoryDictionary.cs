using ShoponCommonLayer.CustomExceptions;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoponDataLayer.Implementation
{
    public class ProductRepoInMemoryDictionary : IProductRepository
    {
        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        public bool AddProduct(Product product, out string errorMessage)
        {
            bool isInsterted = false;
            errorMessage = string.Empty;
            if (product.PId == 0 || string.IsNullOrEmpty(product.ProductName) || product.Price == 0 )
            {
                errorMessage = $"Invalid Product ID,Product Name,Price";
                return isInsterted;
            }
            var isDuplicateProduct = this.GetProductById(product.PId);
            if (isDuplicateProduct == null)
            {
                products.Add(product.PId, product);
                isInsterted = true;
            }
            else
            {
                throw new DuplicateProductException($"Duplicate Product with product id = {product.PId} exists");
            }

            return isInsterted;
        }

        public bool DeleteProduct(int deleteProduct)
        {
            bool isDeleted = false;
            products.Remove(deleteProduct);
            isDeleted = true;
            return isDeleted;
        }

        public Product GetProductById(int prodId)
        {
            Product product = null;
            foreach (var search in products)
            {
                if (search.Key == prodId)
                    product = search.Value;
            }
            return product;
        }

        public IEnumerable<Product> GetProducts(bool isCompanyRequired = false)
        {
            var result = this.products.Values;
            return result;
        }

        public IEnumerable<Product> Search(string key)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product updateProduct)
        {
            bool isPresent = false;
            if (GetProductById(updateProduct.PId) != null)
            {
                products[updateProduct.PId] = updateProduct;
                isPresent = true;
            }
            return isPresent;
        }
    }
}
