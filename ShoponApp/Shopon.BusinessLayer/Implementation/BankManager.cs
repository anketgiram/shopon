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
    public class BankManager : IBankManager
    {
        private readonly IBankRepository bankRepository;
        public BankManager(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }
        public bool AddBank(Bank bank)
            =>bankRepository.AddBank(bank);
        
    }
}
