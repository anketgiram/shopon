using EkartCommon.Models;
using System.Threading.Tasks;

namespace EkartBussiness.Contract
{
    public interface IOrderManagerAsync
    {
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

    }
}
