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
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public bool AddCompany(Company company)
            => companyRepository.AddCompany(company);

        public bool DeleteCompany(int companyId)
            => companyRepository.DeleteCompany(companyId);
        

        public IEnumerable<Company> GetCompanies()
            => companyRepository.GetCompanies();
        

        public Company GetCompanyById(int companyId)
            => companyRepository.GetCompanyById(companyId);


        public Company GetCompanyByName(string companyName)
            => companyRepository.GetCompanyByName(companyName);

        public bool UpdateCompany(Company company)
            => companyRepository.UpdateCompany(company);
        
    }
}
