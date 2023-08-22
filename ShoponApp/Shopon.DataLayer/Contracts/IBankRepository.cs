using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Contracts
{
    public interface IBankRepository
    {
        /// <summary>
        /// Method to Add Banks
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        bool AddBank(Bank bank);
        IEnumerable<Bank> GetBanks();
    }
}
