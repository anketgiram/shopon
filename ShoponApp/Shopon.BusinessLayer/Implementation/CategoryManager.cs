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
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public bool AddCategory(Category category, out string errorMsg)
            => categoryRepository.AddCategory(category,out errorMsg);


        public IEnumerable<Category> GetCategories()
            => categoryRepository.GetCategories();
        

        public Category GetCategoryById(int categoryId)
            => categoryRepository.GetCategoryById(categoryId);


        public Category GetCategoryByName(string categoryName)
            => categoryRepository.GetCategoryByName(categoryName);

        public bool UpdateCategory(Category category)
            => categoryRepository.UpdateCategory(category);
        
    }
}
