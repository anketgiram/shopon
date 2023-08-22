using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponConsoleApp
{
    public class CategoryMenu
    {
        public void CategoryMainMenu()
        {
            ICategoryRepository categoryRepository = new CategoryRepositoryDBImpl();
            ICategoryManager categoryManager = new CategoryManager(categoryRepository);

            int choice = 0;
            string isContinue = "Y";
            while (isContinue == "Y" || isContinue == "y")
            {
                Console.WriteLine("Company MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.Add Category");
                Console.WriteLine("2.List all Category");
                Console.WriteLine("3.Get Category By Id");
                Console.WriteLine("4.Update Category");
                Console.WriteLine("5.Delete Category Using Category Id");
                Console.WriteLine("9.Back to Main");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddCategory(categoryManager);
                        break;
                    case 2:
                        DisplayCategoryDetails(categoryManager);
                        break;
                    case 3:
                        GetCategoryById(categoryManager);
                        break;
                    case 4:
                        UpdateCategory(categoryManager);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine("Do you want to continue in Product Menu? y/n");
                isContinue = Console.ReadLine();


            }

        }

        private void UpdateCategory(ICategoryManager categoryManager)
        {
            Category category = new Category();
            Console.WriteLine("Enter the Category Id");
            category.CategoryId = Convert.ToInt32(Console.ReadLine());
            category.CategoryName = Console.ReadLine();
            if (categoryManager.UpdateCategory(category))
            {
                Console.WriteLine("Category Updated");
            }
            else
            {
                Console.WriteLine("Category not Updated");
            }
        }

        private void GetCategoryById(ICategoryManager categoryManager)
        {
            Console.WriteLine("Enter the Category Id");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Category category = categoryManager.GetCategoryById(categoryId);
            Console.WriteLine("Category Id\tCategory Name");
            DrawLine(50, "-");
            Console.WriteLine($"{category.CategoryId}\t\t\t{category.CategoryName}");
        }

        private void DisplayCategoryDetails(ICategoryManager categoryManager)
        {
            var categories = categoryManager.GetCategories();
            Console.WriteLine("Category Id\tCategory Name");
            DrawLine(50, "-");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId}\t\t\t{category.CategoryName}");
            }
        }

        private void AddCategory(ICategoryManager categoryManager)
        {
            Category category = new Category();
            Console.WriteLine("Enter the Category Id");
            category.CategoryId = Convert.ToInt32(Console.ReadLine());
            category.CategoryName = Console.ReadLine();
            string errorMsg = string.Empty;
            if (categoryManager.AddCategory(category,out errorMsg))
            {
                Console.WriteLine("Category Added");
            }
            else
            {
                Console.WriteLine("Category not Added");
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
    }
}
