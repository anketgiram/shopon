using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponConsoleApp
{
    public class OrderMain
    {
        public void Main()
        {
            IOrderRepository orderRepository = new OrderRepositoryDBImpl();
            IOrderManager orderManager = new OrderManager(orderRepository);
            AddOrder(orderManager);

        }

        private void AddOrder(IOrderManager orderManager)
        {
            Order order = new Order()
            {
                CustomerId=5,
                OrderDate=DateTime.UtcNow,
                OrderStatus="New",
                OrderTotal=0
            };
            OrderItem orderItem1 = new OrderItem()
            {
                Product =new Product()
                {
                    PId=2
                },
                Qty=3
            };
            OrderItem orderItem2 = new OrderItem()
            {
                Product = new Product()
                {
                    PId = 4
                },
                Qty = 1
            };

            order.AddOrderItem(orderItem1);
            order.AddOrderItem(orderItem2);

            orderManager.AddOrder(order);

            if(order.OrderId==0)
            {
                Console.WriteLine("Order Not added");
            }
            else
            {
                Console.WriteLine($"New order id is {order.OrderId}");
            }
        }
    }
}
