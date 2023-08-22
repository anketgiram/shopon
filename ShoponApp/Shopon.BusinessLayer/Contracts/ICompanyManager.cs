using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Contracts
{
    public interface ICompanyManager
    {
        /// <summary>
        /// Add new Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        bool AddCompany(Company company);
        //bool AddCompany(Company company, out string errorMsg);
        /// <summary>
        /// Method to get all the companies
        /// </summary>
        /// <returns></returns>
        IEnumerable<Company> GetCompanies();

        /// <summary>
        /// Method to get Company by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Company GetCompanyById(int companyId);
        /// <summary>
        /// Method to get company by name
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        Company GetCompanyByName(string companyName);
        /// <summary>
        /// Update the Company Information
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        bool UpdateCompany(Company company);
        /// <summary>
        /// Delete the Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        bool DeleteCompany(int companyId);
    }
}
