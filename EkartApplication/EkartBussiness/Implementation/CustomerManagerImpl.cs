using EkartBussiness.Contract;
using EkartCommon.Models;
using EkartData.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartBussiness.Implementation
{
    public class CustomerManagerImpl : ICustomerManager
    {
        //private readonly ICustomerRepo customerRepo;

        //public CustomerManagerImpl(ICustomerRepo customerRepo)
        //{
        //    this.customerRepo = customerRepo;
        //    //this.customerRepo = new CustomerRepoDBImpl();
        //}

        private readonly ICustomerRepo customerRepo;

        public CustomerManagerImpl(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public bool AddCustomer(Customer customer)
        => this.customerRepo.AddCustomer(customer);

        public Customer GetCustomer(int customerId)
            => this.customerRepo.GetCustomer(customerId);
    }
}
