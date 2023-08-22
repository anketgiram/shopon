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
    public class CompanyMenu
    {
        public void CompanyMainMenu()
        {
            ICompanyRepository companyRepository = new CompanyRepositoryDBImpl();
            ICompanyManager companyManager = new CompanyManager(companyRepository);

            int choice = 0;
            string isContinue = "Y";
            while (isContinue == "Y" || isContinue == "y")
            {
                Console.WriteLine("Company MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.Add Company");
                Console.WriteLine("2.List all Company");
                Console.WriteLine("3.Get Company By Id");
                Console.WriteLine("4.Update Company");
                Console.WriteLine("5.Delete Company Using Company Id");
                Console.WriteLine("9.Back to Main");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddCompany(companyManager);
                        break;
                    case 2:
                        DisplayCompanyDetails(companyManager);
                        break;
                    case 3:
                        GetCompanyById(companyManager);
                        break;
                    case 4:
                        UpdateCompany(companyManager);
                        break;
                    case 5:
                        DeleteCompany(companyManager);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine("Do you want to continue in Product Menu? y/n");
                isContinue = Console.ReadLine();


            }

        }

        private void DeleteCompany(ICompanyManager companyManager)
        {
            Console.WriteLine("Enter the Company Id");
            int companyId = Convert.ToInt32(Console.ReadLine());
            if(companyManager.DeleteCompany(companyId))
            {
                Console.WriteLine("Company Deleted");
            }
            else
            {
                Console.WriteLine("Company Not Deleted");
            }
        }

        private void UpdateCompany(ICompanyManager companyManager)
        {
            Company company = new Company();
            Console.WriteLine("Enter the Company Id");
            company.CompanyId = Convert.ToInt32(Console.ReadLine());
            company.CompanyName = Console.ReadLine();
            if (companyManager.UpdateCompany(company))
            {
                Console.WriteLine("Company Updated");
            }
            else
            {
                Console.WriteLine("Company not Updated");
            }
        }

        private void GetCompanyById(ICompanyManager companyManager)
        {
            Console.WriteLine("Enter the Company Id");
            int companyId = Convert.ToInt32(Console.ReadLine());
            Company company = companyManager.GetCompanyById(companyId);
            Console.WriteLine("Company Id\tCompany Name");
            DrawLine(50, "-");
            Console.WriteLine($"{company.CompanyId}\t\t\t{company.CompanyName}");

        }

        

        private void AddCompany(ICompanyManager companyManager)
        {
            Company company = new Company();
            Console.WriteLine("Enter the Company Id");
            company.CompanyId = Convert.ToInt32(Console.ReadLine());
            company.CompanyName = Console.ReadLine();
            if(companyManager.AddCompany(company))
            {
                Console.WriteLine("Company Added");
            }
            else
            {
                Console.WriteLine("Company not Added");
            }
        }

        private void DisplayCompanyDetails(ICompanyManager companyManager)
        {
            var companies = companyManager.GetCompanies();
            Console.WriteLine("Company Id\tCompany Name");
            DrawLine(50, "-");
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.CompanyId}\t\t\t{company.CompanyName}");
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
