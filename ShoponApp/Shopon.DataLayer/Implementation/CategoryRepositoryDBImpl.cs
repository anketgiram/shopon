using ShoponCommonLayer.CustomExceptions;
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
    public class CategoryRepositoryDBImpl : ICategoryRepository
    {
        private readonly String connectionString = null;
        public CategoryRepositoryDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            this.connectionString = connectionUtil.GetConnectionString();
        }
        public bool AddCategory(Category category, out string errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            try
            {
                string sqlSt = $"INSERT INTO category" +
                                   $"(categoryid, " +
                                   $"category, " +
                                   $"VALUES(@categoryid," +
                                   $"@category)";
                                  
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@categoryid", category.CategoryId);
                        command.Parameters.AddWithValue("@category", category.CategoryName);
                        
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

        public bool DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                string sqlSt = $"SELECT " +
                                     $"c.categoryid, " +
                                     $"c.category " +
                                     $"FROM dbo.category AS c WITH(NOLOCK) ";
                                  

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Category category = new Category();
                            category.CategoryId = Convert.ToInt32(reader["categoryid"]);
                            category.CategoryName = reader["category"].ToString();
                            
                            categories.Add(category);


                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            Category category = null;
            try
            {
                string sqlSt = $"SELECT " +
                                 $"c.categoryid, " +
                                 $"c.category " +
                                 $"FROM category AS c WITH(NOLOCK) " +
                                 $"WHERE c.categoryid=@categoryID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@categoryID", categoryId);
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            
                            category = new Category()
                            {
                                CategoryId = Convert.ToInt32(reader["categoryid"]),
                                CategoryName = reader["category"].ToString()
                            };
                            
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new CategoryNotFoundException($"Category with {categoryId} does not exist");
            }
            return category;
        }

        public Category GetCategoryByName(string categoryName)
        {
            Category category = null;
            try
            {
                string sqlSt = $"SELECT " +
                                 $"c.categoryid, " +
                                 $"c.category " +
                                 $"FROM category AS c WITH(NOLOCK) " +
                                 $"WHERE c.category LIKE @categoryName";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@categoryName", categoryName);
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            category = new Category()
                            {
                                CategoryId = Convert.ToInt32(reader["categoryid"]),
                                CategoryName = reader["category"].ToString()
                            };
                            
                        }
                        //else
                        //{
                        //    throw new CategoryNotFoundException($"Category with {categoryName} does not exist");
                        //}
                    }
                }
            }
            catch (Exception)
            {

                throw new CategoryNotFoundException($"Category with {categoryName} does not exist");
            }
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            bool isUpdated = false;
            try
            {
                string sqlSt = $"UPDATE company " +
                            $"SET " +
                            $"categoryname=@categoryname, " +
                            $"WHERE categoryid=@categoryId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@categoryId", category.CategoryId);
                        command.Parameters.AddWithValue("@categoryname", category.CategoryName);
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
