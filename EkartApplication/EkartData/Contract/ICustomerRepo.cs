using EkartCommon.Models;

namespace EkartData.Contract
{
    public interface ICustomerRepo
    {
        bool AddCustomer(Customer customer);

        Customer GetCustomer(int customerId);
    }
}
