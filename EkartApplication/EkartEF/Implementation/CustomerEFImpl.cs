using EkartData.Contract;
using EkartEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EkartEF.Implementation
{
    public class CustomerEFImpl : ICustomerRepo
    {
        private readonly db_eKARTSContext context;

        public CustomerEFImpl(db_eKARTSContext context)
        {
            this.context = context;
        }
        public bool AddCustomer(EkartCommon.Models.Customer customer)
        {
            var isAdded = false;
            var oldCustomer = this.context.Customers.FirstOrDefault(c => c.AppCustomerId == customer.appCustomerId);
            try
            {
                if (oldCustomer == null)
                {
                    var customerDB = new Models.Customer()
                    {
                        AppCustomerId = customer.appCustomerId,
                        CustomerMobileNo = customer.CustomerMobileNo,
                        CustomerName = customer.CustomerName,
                        CustomerEmailId = customer.EmailID,
                        IsDeleted = customer.isDeleted
                    };
                    var customerAddress = new Models.CustomerAddress()
                    {

                        StName = customer.CustomerAddress.StName,
                        City = customer.CustomerAddress.City,
                        State = customer.CustomerAddress.State
                    };
                    customerDB.CustomerAddress = customerAddress;

                    this.context.Customers.Add(customerDB);
                    this.context.SaveChanges();
                    isAdded = true;
                }
                else
                {

                    oldCustomer.CustomerName = customer.CustomerName;
                    oldCustomer.CustomerMobileNo = customer.CustomerMobileNo;
                    oldCustomer.CustomerEmailId = customer.EmailID;
                    var address = context.CustomerAddresses.FirstOrDefault(x => x.CustomerId == oldCustomer.CustomerId);
                    address.City = customer.CustomerAddress.City;
                    address.State = customer.CustomerAddress.State;
                    address.StName = customer.CustomerAddress.StName;
                   // oldCustomer.CustomerAddress.Add(address);

                }
                this.context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return isAdded;
        }

        public EkartCommon.Models.Customer GetCustomer(int customerId)
        {
            //var customerDB = context.Customers.Where(x => x.CustomerId == customerId)
            //                            .Include(x => x.CustomerAddresss)
            //                            .FirstOrDefault();

            var customerDB = context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            EkartCommon.Models.Customer customer = null;
            if (customerDB != null)
            {
                customer = new EkartCommon.Models.Customer()
                {
                    appCustomerId = customerDB.AppCustomerId,
                    CustomerId = customerDB.CustomerId,
                    CustomerMobileNo = customerDB.CustomerMobileNo,
                    CustomerName = customerDB.CustomerName,
                    isDeleted = false
                };
                var address = context.CustomerAddresses.FirstOrDefault(x => x.CustomerId == customerId);
                EkartCommon.Models.CustomerAddress customerAddress = new EkartCommon.Models.CustomerAddress()
                {
                    StName = address.StName,
                    State = address.State,
                    City = address.City
                };
                customer.CustomerAddress = customerAddress;
            }
            return customer;
        }
    }
}
