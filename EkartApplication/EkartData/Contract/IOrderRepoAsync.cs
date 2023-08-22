using EkartCommon.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartData.Contract
{
    public interface IOrderRepoAsync
    { /*
        /// <summary>
        /// Method to return all orders based on the order status
        /// </summary>
        /// <param name="orderstatusType"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> Get(OrderstatusType orderstatusType);
        */
       
        /// <summary>
        /// method to get order by clientorder id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> Get(int orderId);

        /// <summary>
        /// method to add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> Add(Order order);
        //when you create thet time you have to return creted object that why as parameter we tak Order as object
        //when ever you add the order or any thing thatv time you have to return that object

        /*
        /// <summary>
        /// method to upaadte order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> Upadte(Order order);
           //here also while updateing you have to return that object so that why we use Order as object
        */
    }
}
