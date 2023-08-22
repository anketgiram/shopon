using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Contracts
{
    public interface ICompanyRepository
    {
        bool AddCompany(Company company);
        IEnumerable<Company> GetCompanies();
        Company GetCompanyById(int companyId);
        Company GetCompanyByName(string companyName);
        bool UpdateCompany(Company company);
        bool DeleteCompany(int companyId);
    }
}
