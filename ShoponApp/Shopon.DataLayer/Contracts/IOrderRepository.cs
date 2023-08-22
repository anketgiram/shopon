using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Contracts
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Method to get order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrder(int orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Order AddOrder(Order order);

        /// <summary>
        /// Method to get all orders by customer ID
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrderByCustomerID(int CustomerId);
    }
}
