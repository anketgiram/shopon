using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.CustomExceptions;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Implementation;
using ShoponEFLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoponConsoleApp
{
    public class ProductMenu
    {
        public void ProductMainMenu()
        {

            //IProductRepository productRepository = new ProductRepoInMemoryDictionary();
            ICategoryRepository categoryRepository = new CategoryRepositoryDBImpl();
            ICompanyRepository companyRepository = new CompanyRepositoryDBImpl();

            //IProductRepository productRepository = new ProductRepositoryDBImpl(companyRepository,categoryRepository);
            IProductRepository productRepository = new ProductRepositoryEFImpl();
            IProductManager productManager = new ProductManager(productRepository);

            int choice = 0;
            string isContinue = "Y";
            while (isContinue=="Y"|| isContinue=="y")
            {
                Console.WriteLine("PRODUCT MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.List all Products");
                Console.WriteLine("3.Get Product By Id");
                Console.WriteLine("4.Update Product");
                Console.WriteLine("5.Delete Product Using Product Id");
                Console.WriteLine("6.Sort By Id");
                Console.WriteLine("7.Sort By Name");
                Console.WriteLine("8.Sort By Price");
                Console.WriteLine("9.Search product by key");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct(productManager);
                        break;
                    case 2:
                        DisplayProducts(productManager);
                        break;
                    case 3:
                        GetProductById(productManager);
                        break;
                    case 4:
                        UpdateProduct(productManager);
                        break;
                    case 5:
                        DeleteProduct(productManager);
                        break;
                    case 6:
                        SortById(productManager);
                        break;
                    case 7:
                        SortByName(productManager);
                        break;
                    case 8:
                        SortByPrice(productManager);
                        break;
                    case 9:
                        SearchByKey(productManager);
                        break;
                    default: Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine("Do you want to continue in Product Menu? y/n");
                isContinue = Console.ReadLine();
               
                    
            }
        }

        private void SearchByKey(IProductManager productManager)
        {
            Console.WriteLine("Enter the key");
            string key = Console.ReadLine();
            var products = productManager.SearchByKey(key).ToList();
            DisplayProductData(products);
        }

        private void SortByPrice(IProductManager productManager)
        {
            var products = productManager.SortByPrice();
            DisplayProductData(products);
        }

        private void SortByName(IProductManager productManager)
        {
            var products = productManager.SortByName();
            DisplayProductData(products);
        }

        private void SortById(IProductManager productManager)
        {
            var products = productManager.SortById();
            DisplayProductData(products);
        }

        private void AddProduct(IProductManager productManager)
        {
            ICategoryRepository categoryRepository = new CategoryRepositoryDBImpl();
            ICategoryManager categoryManager = new CategoryManager(categoryRepository);
            ICompanyRepository companyRepository = new CompanyRepositoryDBImpl();
            ICompanyManager companyManager = new CompanyManager(companyRepository);

            string errorMsg = string.Empty;
            Product product = new Product();
            Console.WriteLine("Enter the ProductId:");
            product.PId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the ProductName:");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("Enter the Company Name:");
            string companyName = Console.ReadLine();
            product.Company = companyManager.GetCompanyByName(companyName);
            if(product.Company==null)
            {
                throw new CompanyNotFoundException($"Company with Name:{companyName} does not exist");
            }

            Console.WriteLine("Enter the Category Name:");
            string categoryName = Console.ReadLine();
            product.Category = categoryManager.GetCategoryByName(categoryName);
            if(product.Category==null)
            {
                throw new CategoryNotFoundException($"Category with {categoryName} does not exist");
            }
            

            Console.WriteLine("Enter the ProductPrice:");
            product.Price = Convert.ToDouble(Console.ReadLine());
            if(product.Price<=0)
            {
                throw new InvalidPriceException($"Price of the item should not be zero or negative");
            }
            Console.WriteLine("Enter the Available Status:");
            product.AvailableStatus = Console.ReadLine();
            Console.WriteLine("Enter the Image Url");
            product.ImageUrl = Console.ReadLine();
            try
            {
                if (productManager.AddProduct(product, out errorMsg) && string.IsNullOrEmpty(errorMsg))
                    Console.WriteLine("Product Added");
                else
                    Console.WriteLine("Product Not Added");
            }
            catch (DuplicateProductException excep)
            {
                Console.WriteLine(excep.Message);
                if (excep.InnerException != null)
                    Console.WriteLine($"Actual msg :{excep.InnerException.Message}");
                Console.WriteLine(excep.StackTrace);
            }
            

        }
        private void DisplayProducts(IProductManager productManager)
        {
            var products = productManager.GetProducts(true).ToList();
            DisplayProductData(products);

        }

        private void DisplayProductData(IEnumerable<Product> products)
        {
            Console.WriteLine("List of Products");
            DrawLine(40, "*");
            Console.WriteLine("ProductId\tProductName\tProductPrice\tAvailable Status\tImage Url \tCategory Name\tCompany Name");
            DrawLine(60, "-");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.PId}" +
                                   $"\t\t{product.ProductName}" +
                                   $"\t\t{product.Price}" +
                                   $"\t\t{product.AvailableStatus}" +
                                   $"\t\t{product.ImageUrl}" +
                                   $"\t\t{product.Company.CompanyName}" +
                                   $"\t\t{product.Category.CategoryName}");
                //Console.WriteLine($"{product.PId}" +
                //                   $"\t\t{product.ProductName}" +
                //                   $"\t\t{product.Price}" +
                //                   $"\t\t{product.AvailableStatus}" +
                //                   $"\t\t{product.ImageUrl}");

            }
        }

        private static void DrawLine(int noOfPrint, string pattern)
        {
            for (int i = 0; i < noOfPrint; i++)
            {
                Console.Write(pattern);
            }
            Console.WriteLine();
        }

        private void GetProductById(IProductManager productManager)
        {
            Console.WriteLine("Enter the Product Id to be searched:");
            int prodId = Convert.ToInt32(Console.ReadLine());
            Product product = productManager.GetProductById(prodId);
            Console.WriteLine("ProductId\tProductName\tProductPrice\tAvailable Status\tImage Url \tCategory Name\tCompany Name");
            DrawLine(60, "-");
            Console.WriteLine($"{product.PId}\t\t{product.ProductName}\t\t{product.Price}\t\t{product.AvailableStatus}" +
                $"\t\t{product.ImageUrl}\t\t{product.Category.CategoryName}\t\t{product.Company.CompanyName}");
        }

        private void UpdateProduct(IProductManager productManager)
        {
            ICategoryRepository categoryRepository = new CategoryRepositoryDBImpl();
            ICategoryManager categoryManager = new CategoryManager(categoryRepository);
            ICompanyRepository companyRepository = new CompanyRepositoryDBImpl();
            ICompanyManager companyManager = new CompanyManager(companyRepository);

            Console.WriteLine("Enter the Product Id to be updated:");
            int productId = Convert.ToInt32(Console.ReadLine());
            Product updatedProduct = productManager.GetProductById(productId);
            Console.WriteLine("Enter the New Product Name:");
            updatedProduct.ProductName = Console.ReadLine();
            Console.WriteLine("Enter the New Product Price:");
            updatedProduct.Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the New Company Name:");
            string companyName = Console.ReadLine();
            updatedProduct.Company = companyManager.GetCompanyByName(companyName);
            if (updatedProduct.Company == null)
            {
                throw new CompanyNotFoundException($"Company with Name:{companyName} does not exist");
            }

            Console.WriteLine("Enter the New Category Name:");
            string categoryName = Console.ReadLine();
            updatedProduct.Category = categoryManager.GetCategoryByName(categoryName);
            if (updatedProduct.Category == null)
            {
                throw new CategoryNotFoundException($"Category with {categoryName} does not exist");
            }

            Console.WriteLine("Enter the New Available status:");
            updatedProduct.AvailableStatus = Console.ReadLine();
            Console.WriteLine("Enter the New Image Url:");
            updatedProduct.ImageUrl = Console.ReadLine();
            if (productManager.UpdateProduct(updatedProduct))
            {
                Console.WriteLine("Product updated");
            }
                
            else
            {
                Console.WriteLine("Product Not updated");
            }
                
        }
        private void DeleteProduct(IProductManager productManager)
        {
            Console.WriteLine("Enter the productId of the product:");
            int productId = Convert.ToInt32(Console.ReadLine());
            if (productManager.DeleteProduct(productId))
                Console.WriteLine("Product Deleted");
            else
                Console.WriteLine("Product Not Deleted");

        }
        
    }
}
    

