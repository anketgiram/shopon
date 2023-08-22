using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Implementation
{
    public class ProductRepositoryDBImpl : IProductRepository
    {
        private readonly string connectionString = null;
       
        private readonly ICompanyRepository companyRepository=null;
        private readonly ICategoryRepository categoryRepository = null;
        public ProductRepositoryDBImpl(ICompanyRepository companyRepository,ICategoryRepository categoryRepository)
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            this.connectionString = connectionUtil.GetConnectionString();
            this.categoryRepository = categoryRepository;
            this.companyRepository = companyRepository;
        }

        public bool AddProduct(Product product, out string errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            try
            {
                string sqlSt = $"INSERT INTO product" +
                                   $"(pid, " +
                                   $"productname, " +
                                   $"price, " +
                                   $"companyid, " +
                                   $"categoryid, " +
                                   $"availablestatus, " +
                                   $"imageUrl, " +
                                   $"isDeleted) " +
                                   $"VALUES(@pid," +
                                   $"@productname," +
                                   $"@price," +
                                   $"@companyid," +
                                   $"@categoryid," +
                                   $"@availablestatus," +
                                   $"@imageUrl," +
                                   $"@isDeleted)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@pid", product.PId);
                        command.Parameters.AddWithValue("@productname", product.ProductName);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@companyid", product.Company.CompanyId);
                        command.Parameters.AddWithValue("@categoryid", product.Category.CategoryId);
                        command.Parameters.AddWithValue("@availablestatus", product.AvailableStatus);
                        command.Parameters.AddWithValue("@imageUrl", product.ImageUrl);
                        command.Parameters.AddWithValue("@isDeleted", 0);
                        command.ExecuteNonQuery();
                        isInserted = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isInserted;
        }

        public bool DeleteProduct(int productId)
        {
            bool isDeleted = false;
            try
            {
                string sqlSt = $"UPDATE product " +
                            $"SET " +
                            $"isDeleted=@isDeleted " +
                            $"WHERE pid=@productId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        command.Parameters.AddWithValue("@isDeleted", 1);
                        command.ExecuteNonQuery();
                        isDeleted = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;

        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            try
            {
                string sqlSt = $"SELECT " +
                                     $"p.pid, " +
                                     $"p.productname, " +
                                     $"p.price, " +
                                     $"p.availablestatus, " +
                                     $"p.imageUrl, " +
                                     $"p.companyid, " +
                                     $"p.categoryid " +
                                     $"FROM dbo.product AS p WITH(NOLOCK) " +
                                     $"WHERE p.isDeleted=0 AND p.pid=@productId ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            product = new Product();
                            product.PId = Convert.ToInt32(reader["pid"]);
                            product.ProductName = reader["productname"].ToString();
                            product.Price = Convert.ToDouble(reader["price"]);
                            product.AvailableStatus = reader["availablestatus"].ToString();
                            var categoryId = Convert.ToInt32(reader["categoryid"]);
                            product.Category = categoryRepository.GetCategoryById(categoryId);
                            product.ImageUrl = reader["imageUrl"].ToString();
                            
                            var companyId = Convert.ToInt32(reader["companyId"]);
                            product.Company = companyRepository.GetCompanyById(companyId);
                            
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public IEnumerable<Product> GetProducts(bool isCompanyRequired = false)
        {
            //1.Connection->Connectionstring
            //2.Command->DDL/DML/DQL
            //3.Fetch->DataReader
            //4.Close the connection
            List<Product> products = new List<Product>();
            try
            {
                string sqlSt = $"SELECT " +
                                     $"p.pid, " +
                                     $"p.productname, " +
                                     $"p.price, " +
                                     $"p.availablestatus, " +
                                     $"p.imageUrl, " +
                                     $"p.companyid, " +
                                     $"p.categoryid " +
                                     $"FROM dbo.product AS p WITH(NOLOCK) " +
                                     $"WHERE p.isDeleted=0 ";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.PId = Convert.ToInt32(reader["pid"]);
                            product.ProductName = reader["productname"].ToString();
                            product.Price = Convert.ToDouble(reader["price"]);
                            product.AvailableStatus = reader["availablestatus"].ToString();
                            var categoryId = Convert.ToInt32(reader["categoryid"]);
                            product.Category = categoryRepository.GetCategoryById(categoryId);
                            product.ImageUrl = reader["imageUrl"].ToString();
                            if(isCompanyRequired)
                            {
                                var companyId = Convert.ToInt32(reader["companyId"]);
                                product.Company = companyRepository.GetCompanyById(companyId);
                            }
                            products.Add(product);


                        }
                    }
                }
                
            }
            catch (Exception)
            {
                throw;  
            }
            return products;
        }

        public IEnumerable<Product> Search(string key)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            bool isUpdated = false;
            try
            {
                string sqlSt = $"UPDATE product " +
                            $"SET " +
                            $"productname=@productname, " +
                            $"price=@price, " +
                            $"companyid=@companyid, " +
                            $"categoryid=@categoryid, " +
                            $"availablestatus=@availablestatus, " +
                            $"imageUrl=@imageUrl " +
                            $"WHERE pid=@productId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@productId", product.PId);
                        command.Parameters.AddWithValue("@productname", product.ProductName);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@companyid", product.Company.CompanyId);
                        command.Parameters.AddWithValue("@categoryid", product.Category.CategoryId);
                        command.Parameters.AddWithValue("@availablestatus", product.AvailableStatus);
                        command.Parameters.AddWithValue("@imageUrl", product.ImageUrl);
                        command.Parameters.AddWithValue("@isDeleted", 0);
                        command.ExecuteNonQuery();
                        isUpdated = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isUpdated;

        }
    }
}
