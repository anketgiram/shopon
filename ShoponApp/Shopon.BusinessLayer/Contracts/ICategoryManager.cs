using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Contracts
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Method to Add Category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        bool AddCategory(Category category, out string errorMsg);
        /// <summary>
        /// Method to get all Categories
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategories();
        /// <summary>
        /// Method to get Category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCategoryById(int categoryId);
        /// <summary>
        /// Method to get Category by name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Category GetCategoryByName(string categoryName);
        /// <summary>
        /// Method to update the category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        bool UpdateCategory(Category category);
        //bool DeleteCategory(int categoryId);
    }
}
