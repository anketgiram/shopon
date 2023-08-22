using EkartCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartBussiness.Contract
{
    public interface IOrderManager
    {
       
        /// <summary>
        /// Methos to add Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool AddOrder(Order order);

        /// <summary>
        /// method to get order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrder(int orderId);

        /// <summary>
        /// method to update order status type and staff id based on order id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name=""></param>
        /// <returns></returns>
        bool UpdateOrder(int id, OrderstatusType orderstatusType, string staffId);

        /// <summary>
        /// method to get Order according to address
        /// </summary>
        /// <param name="city"></param>
        /// <param name="orderStatusType"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrders(OrderstatusType orderStatusType, string city = null);

        IEnumerable<EkartCommon.Models.Order> GetOrdersToDeliverd(OrderstatusType orderStatusType, string staffId);

    }
}
