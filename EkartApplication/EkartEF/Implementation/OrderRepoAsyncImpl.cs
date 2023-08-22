using EkartCommon.Models;
using EkartData.Contract;
using EkartEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartEF.Implementation
{
    public class OrderRepoAsyncImpl : IOrderRepoAsync
    {
        private readonly db_eKARTSContext context;

        public OrderRepoAsyncImpl(db_eKARTSContext context)
        {
            this.context = context;
        }
        public async Task<EkartCommon.Models.Order> Add(EkartCommon.Models.Order order)
        {
            var orderDb = new Models.Order()
            {
                ClientOrderId = order.ClientOrderId,
                ExceptedDeliveryDate = order.DateTime.AddDays(2),
                OrderAmount = order.OrderAmount,
                DateTime = order.DateTime,
                Customer = new Models.Customer()
                {
                    AppCustomerId = order.Customer.appCustomerId,
                    CustomerName = order.Customer.CustomerName,
                    CustomerMobileNo = order.Customer.CustomerMobileNo,
                    CustomerEmailId = order.Customer.EmailID,
                    IsDeleted = false,
                    CustomerAddress = new Models.CustomerAddress()
                    {
                        StName = order.Customer.CustomerAddress.StName,
                        City = order.Customer.CustomerAddress.City,
                        State = order.Customer.CustomerAddress.State
                    }
                },
                OrderItems = GetOrderItemDb(order.OrderItems),
                OrderStatus = this.context.OrderStatuses.FirstOrDefault(x=> x.OrderStatusId == (int)OrderstatusType.ORDERECEVIED )
            };
            var result = await this.context.Orders.AddAsync(orderDb);
            await context.SaveChangesAsync();
            var newOrder = result.Entity;
            order.OrderId = newOrder.OrderId;
            return order;
        }
        private ICollection<Models.OrderItem> GetOrderItemDb(ICollection<EkartCommon.Models.OrderItem> orderItems)
        {
            var orderItemDb = from o in orderItems
                              select new Models.OrderItem
                              {
                                  Orderid = o.Orderid,
                                  Qty = o.Qty,
                                  Price = o.Price
                              };
            return orderItemDb.ToList();
        }

        public async Task<EkartCommon.Models.Order> Get(int orderId)
        {
            var orderDb = this.context.Orders.FirstOrDefault(x => x.ClientOrderId == orderId);
            if(orderDb != null)
            {
                var orderStatusDb = await this.context.OrderStatuses.FirstOrDefaultAsync(x => x.OrderStatusId == orderDb.OrderStatusId);
                return new EkartCommon.Models.Order()
                {
                    ClientOrderId = orderDb.ClientOrderId,
                    OrderAmount = orderDb.OrderAmount,
                    DateTime = orderDb.DateTime,
                    ExceptedDeliveryDate = orderDb.ExceptedDeliveryDate,
                    ActualDeliveryDate = orderDb.ActualDeliveryDate,
                    OrderStatus = new EkartCommon.Models.OrderStatus()
                    {
                        Description = orderDb.OrderStatus.Description,
                        OrderStatusId = orderDb.OrderStatus.OrderStatusId,
                        OrderStatusType = orderDb.OrderStatus.OrderStatusType
                    }
                };
            }
            return null;
        }

       
    }

   
}

