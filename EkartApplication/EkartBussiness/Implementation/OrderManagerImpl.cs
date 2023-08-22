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
    public class OrderManagerImpl : IOrderManagerAsync
    {
        private readonly IOrderRepoAsync orderRepoAsync;

        public OrderManagerImpl(IOrderRepoAsync orderRepoAsync )
        {
            
            this.orderRepoAsync = orderRepoAsync;
        }
        public Task<Order> Add(Order order)
            => this.orderRepoAsync.Add(order);

        public Task<Order> Get(int orderId)
              => this.orderRepoAsync.Get(orderId);
    }
}
