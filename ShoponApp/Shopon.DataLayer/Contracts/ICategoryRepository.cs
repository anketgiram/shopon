using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Contracts
{
    public interface ICategoryRepository
    {
        bool AddCategory(Category category, out string errorMsg);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category GetCategoryByName(string categoryName);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
    }
}
