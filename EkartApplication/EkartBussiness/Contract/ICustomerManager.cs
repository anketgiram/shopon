using EkartCommon.Models;

namespace EkartBussiness.Contract
{
    public interface ICustomerManager
    {
        bool AddCustomer(Customer customer);

        Customer GetCustomer(int customerId);
    }
}
