using EkartBussiness.Contract;
using EkartCommon.Models;
using EkartEF.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartBussiness.Implementation
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepo orderRepo;
        public OrderManager(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public bool AddOrder(Order order)
               => this.orderRepo.AddOrder(order);

        public Order GetOrder(int orderId)
              => this.orderRepo.GetOrder(orderId);

        public IEnumerable<Order> GetOrders(OrderstatusType orderStatusType, string city = null)
           => this.orderRepo.GetOrders(orderStatusType, city);

        public IEnumerable<Order> GetOrdersToDeliverd(OrderstatusType orderStatusType, string staffId)
           => this.orderRepo.GetOrdersToDeliverd(orderStatusType, staffId);

        public bool UpdateOrder(int id, OrderstatusType orderstatusType, string staffId)
            => this.orderRepo.UpdateOrder(id, orderstatusType, staffId);
    }
}
