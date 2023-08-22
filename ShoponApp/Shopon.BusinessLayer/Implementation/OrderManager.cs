using ShoponBusinessLayer.Contracts;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Implementation
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Order AddOrder(Order order)
            => orderRepository.AddOrder(order);
        
    }
}
