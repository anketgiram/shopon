using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Contracts
{
    public interface IBankManager
    {
        /// <summary>
        /// Method to Add Banks
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        bool AddBank(Bank bank);
        ///// <summary>
        ///// Method to get all banks
        ///// </summary>
        ///// <returns></returns>
        //IEnumerable<Bank> GetBanks();
    }
}
