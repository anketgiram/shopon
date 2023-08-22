 using Microsoft.EntityFrameworkCore;
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
    public class ProductRepositoryAsyncImpl : IProductAsyncRepository
    {
        private readonly db_shoponContext context;

        public ProductRepositoryAsyncImpl(db_shoponContext context)
        {
            this.context = context;
        }
        public async Task<ShoponCommonLayer.Models.Product> AddProduct(ShoponCommonLayer.Models.Product product)
        {
            
            try
            {

                var productDb = new Models.Product()//convert to business model(common) to data modelef
                {
                    Pid=product.PId,
                    Productname = product.ProductName,
                    Availablestatus = product.AvailableStatus,
                    Categoryid = product.CategoryId,
                    Companyid = product.CompanyId,
                    ImageUrl = product.ImageUrl,
                    IsDeleted = false,
                    Price = product.Price
                };
                var result=await this.context.Products.AddAsync(productDb);//still in the memory
                await this.context.SaveChangesAsync();
                return new ShoponCommonLayer.Models.Product()
                {
                    PId = result.Entity.Pid,
                    AvailableStatus = result.Entity.Availablestatus,
                    CategoryId = result.Entity.Categoryid.Value,
                    CompanyId = result.Entity.Companyid.Value,
                    Price = result.Entity.Price.Value,
                    ProductName = result.Entity.Productname,
                    ImageUrl = result.Entity.ImageUrl
                };
                

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteProduct(int productId)
        {
            var productsToDelete = this.context.Products.FirstOrDefaultAsync(x => x.Pid == productId);
            if(productsToDelete!=null)
            {
                this.context.Products.Remove(await productsToDelete);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<ShoponCommonLayer.Models.Product> GetProductById(int productId)
        {
            var result = await this.context.Products
                .Include(p => p.Company)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(x => x.Pid == productId);
            if(result!=null)
            {
                var company = new ShoponCommonLayer.Models.Company()
                {
                    CompanyId=result.Company.Companyid,
                    CompanyName=result.Company.Companyname
                };

                var category = new ShoponCommonLayer.Models.Category()
                {
                    CategoryId=result.Category.Categoryid,
                    CategoryName=result.Category.Category1
                };
                return new ShoponCommonLayer.Models.Product()
                {
                    PId = result.Pid,
                    AvailableStatus = result.Availablestatus,
                    CategoryId = result.Categoryid.Value,
                    CompanyId = result.Companyid.Value,
                    ImageUrl = result.ImageUrl,
                    Price = result.Price.Value,
                    ProductName = result.Productname,
                    Company = company,
                    Category = category
                };
            }
            return null;
        }

        public async Task<IEnumerable<ShoponCommonLayer.Models.Product>> GetProducts()
        {
            var result = await this.context.Products.ToListAsync();
            var resultToReturn = (from p in result
                                  where p.IsDeleted == false
                                  select new ShoponCommonLayer.Models.Product
                                  {
                                      PId = p.Pid,
                                      ProductName=p.Productname,
                                      AvailableStatus=p.Availablestatus,
                                      Price=p.Price.Value,
                                      CompanyId=p.Companyid.Value,
                                      CategoryId=p.Categoryid.Value,
                                      ImageUrl=p.ImageUrl
                                  }).ToList();
            return resultToReturn;

        }

        public async Task<IEnumerable<ShoponCommonLayer.Models.Product>> Search(string key)
        {
            IQueryable<Models.Product> query = this.context.Products;
            if(string.IsNullOrEmpty(key))
            {
                query = query.Where(p => p.Productname.Contains(key.ToLower()));
            }
            var result = await query.ToListAsync();
            var resultToReturn = (from p in result
                                  where p.IsDeleted == false
                                  select new ShoponCommonLayer.Models.Product
                                  {
                                      PId = p.Pid,
                                      ProductName = p.Productname,
                                      AvailableStatus = p.Availablestatus,
                                      Price = p.Price.Value,
                                      CompanyId = p.Companyid.Value,
                                      CategoryId = p.Categoryid.Value,
                                      ImageUrl = p.ImageUrl
                                  }).ToList();
            return resultToReturn;
        }

        public async Task<ShoponCommonLayer.Models.Product> UpdateProduct(ShoponCommonLayer.Models.Product product)
        {
            var productToUpdate = await this.context.Products.FirstOrDefaultAsync(p => p.Pid == product.PId);
            if(productToUpdate!=null)
            {
                //Patch
                //if(productToUpdate.Availablestatus != product.AvailableStatus)
                //{
                //    productToUpdate.Availablestatus = product.AvailableStatus;
                //}
                //Put
                productToUpdate.Availablestatus = product.AvailableStatus;
                productToUpdate.Categoryid = product.CategoryId;
                productToUpdate.Companyid = product.CompanyId;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Price = product.Price;
                productToUpdate.Productname = product.ProductName;
                await this.context.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
