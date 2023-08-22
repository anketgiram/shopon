using Microsoft.EntityFrameworkCore;
using ShoponCommonLayer.CustomExceptions;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Implementation
{
    public class ProductRepositoryEFImpl : IProductRepository
    {
        private readonly db_shoponContext context=null;
       

        public ProductRepositoryEFImpl(db_shoponContext context)
        {
            this.context = context;
        }
        public bool AddProduct(ShoponCommonLayer.Models.Product product, out string errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            try
            {
                
                var productDb = new Models.Product()//convert to business model(common) to data modelef
                {
                    Pid = product.PId,
                    Productname = product.ProductName,
                    Availablestatus = product.AvailableStatus,
                    Categoryid = product.Category.CategoryId,
                    Companyid = product.Company.CompanyId,
                    ImageUrl = product.ImageUrl,
                    IsDeleted = false,
                    Price = product.Price
                };
                this.context.Products.Add(productDb);//still in the memory
                this.context.SaveChanges();

                isInserted = true;

            }
            catch(NullReferenceException)
            {
                if (product.Company == null)
                {
                    throw new CompanyNotFoundException($"Company with {product.Company.CompanyName} does not exists");
                }
                if (product.Category == null)
                {
                    throw new CategoryNotFoundException($"Company with {product.Company.CompanyName} does not exists");
                }
            }
            
            return isInserted;
        }

        public bool DeleteProduct(int productId)
        {
            bool isDeleted = false;
            //HardDeleted
            //var productDb = this.context.Products.FirstOrDefault(x => x.Pid == productId);
            //this.context.Remove(productDb);
            //this.context.SaveChanges();
            //isDeleted = true;

            var productToDelete = this.context.Products.FirstOrDefault(x => x.Pid == productId);
            if (productToDelete == null)
            {
                throw new ProductNotFoundException($"Product with {productId} does not exists");
            }
            productToDelete.IsDeleted = true;
            this.context.SaveChanges();
            return isDeleted;
        }

        public ShoponCommonLayer.Models.Product GetProductById(int productId)
        {
            ShoponCommonLayer.Models.Product product = null;
            try
            {
                var productsDb = context.Products.Include(x => x.Company).Include(x => x.Category).FirstOrDefault(x => x.Pid == productId);
                //if (productsDb == null)
                //{
                //    throw new ProductNotFoundException($"Product with {productId} does not exists");
                //} 
                if (productsDb != null)
                {
                    product = new ShoponCommonLayer.Models.Product()
                    {
                        AvailableStatus = productsDb.Availablestatus,
                        ImageUrl = productsDb.ImageUrl,
                        PId = productsDb.Pid,
                        Price = productsDb.Price.Value,
                        ProductName = productsDb.Productname,
                        CategoryId = productsDb.Categoryid.Value,
                        CompanyId = productsDb.Companyid.Value,
                        Company = new ShoponCommonLayer.Models.Company()
                        {
                            CompanyId = productsDb.Company.Companyid,
                            CompanyName = productsDb.Company.Companyname
                        },
                        Category = new ShoponCommonLayer.Models.Category()
                        {
                            CategoryId = productsDb.Category.Categoryid,
                            CategoryName = productsDb.Category.Category1
                        }

                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return product;
        }

        public IEnumerable<ShoponCommonLayer.Models.Product> GetProducts(bool isCompanyRequired = false)
        {
            var productsDb = context.Products.ToList();
            var companiesDb = context.Companies.ToList();
            var categoriesDb = context.Categories.ToList();
            //var productsDb = context.Products.Include(x => x.Company);
            //List<ShoponCommonLayer.Models.Product> products = new List<ShoponCommonLayer.Models.Product>();
            /*
            var productsDb = context.Products.Include(x => x.Company); //context.product() will return the Dbset,convert it to list
            foreach (var productDb in productsDb)
            {
                ShoponCommonLayer.Models.Product product = new ShoponCommonLayer.Models.Product()
                {
                    PId = productDb.Pid,
                    ProductName = productDb.Productname,
                    AvailableStatus = productDb.Availablestatus,
                    ImageUrl = productDb.ImageUrl,
                    Price = productDb.Price ?? 0,
                    //CompanyId=productDb.Companyid.Value,
                    Company = new ShoponCommonLayer.Models.Company()
                    {
                        CompanyId = productDb.Company.Companyid,
                        CompanyName=productDb.Company.Companyname
                    },
                    CategoryId = productDb.Categoryid.Value

                };
                products.Add(product);
            }
            */

            /**var products = from p in productsDb
                           select new ShoponCommonLayer.Models.Product
                           {
                               AvailableStatus = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               PId = p.Pid,
                               Price = p.Price.Value,
                               ProductName = p.Productname,
                               Company = new ShoponCommonLayer.Models.Company()
                               {
                                   CompanyId = p.Company.Companyid,
                                   CompanyName = p.Company.Companyname
                               },
                               Category = new ShoponCommonLayer.Models.Category()
                               {
                                   CategoryId = p.Category.Categoryid,
                                   CategoryName = p.Category.Category1
                               }

                           };
            
            **/
            var products = from p in productsDb
                           where p.IsDeleted == false
                           join c in companiesDb
                           on p.Companyid equals c.Companyid
                           join ca in categoriesDb
                           on p.Categoryid equals ca.Categoryid
                           
                           select new ShoponCommonLayer.Models.Product
                           {
                               AvailableStatus = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               PId = p.Pid,
                               Price = p.Price.Value,
                               ProductName = p.Productname,
                               Company = new ShoponCommonLayer.Models.Company()
                               {
                                   CompanyId = c.Companyid,
                                   CompanyName = c.Companyname
                               },
                               Category = new ShoponCommonLayer.Models.Category()
                               {
                                   CategoryId = ca.Categoryid,
                                   CategoryName = ca.Category1
                               }
                           };
           
            return products.ToList();
        }

        public IEnumerable<ShoponCommonLayer.Models.Product> Search(string key)
        {
            var productsDb = context.Products.ToList();
            var products = from p in productsDb
                           where p.IsDeleted == false &&
                           p.Productname.ToLower().Contains(key.ToLower())
                           select new ShoponCommonLayer.Models.Product
                           {
                               AvailableStatus = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               PId = p.Pid,
                               Price = p.Price.Value,
                               ProductName = p.Productname,
                               //Company = new ShoponCommonLayer.Models.Company()
                               //{
                               //    CompanyId = c.Companyid,
                               //    CompanyName = c.Companyname
                               //},
                           };

            return products.ToList();
        }

        public bool UpdateProduct(ShoponCommonLayer.Models.Product product)
        {
            bool isUpdated = false;
            //1.Find the product to update from DB
            //2.Replace Content of product found in DB
            //3.Savechanges
            try
            {
                var productToUpdate = this.context.Products.FirstOrDefault(x => x.Pid == product.PId);
                if (productToUpdate == null)
                {
                    throw new ProductNotFoundException($"Product with {product.PId} does not exists");
                }
                //PUT-put all the data without checking whether its updated or not
                //PATCH-compare each column,and findout which column is updated only then change it
                productToUpdate.Availablestatus = product.AvailableStatus;
                productToUpdate.Categoryid = product.Category.CategoryId;
                productToUpdate.Companyid = product.Company.CompanyId;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Price = product.Price;
                productToUpdate.Productname = product.ProductName;

                this.context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return isUpdated;
        }
    }
}
