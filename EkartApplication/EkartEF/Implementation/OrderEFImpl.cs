using EkartCommon.CustomExceptions;
using EkartCommon.Models;
using EkartEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EkartEF.Implementation
{
    public class OrderEFImpl : IOrderRepo
    {
        private readonly db_eKARTSContext context;

        public OrderEFImpl(db_eKARTSContext context)
        {
            this.context = context;
        }

        #region Public Method
        public bool AddOrder(EkartCommon.Models.Order order)
        {
            bool isAdded = false;
            //1. check for order if is it null, Yes -throw error No- add the data
            //2. if customer not exixts then create new customer else do nothing(customer)
            //3. Insert Order with its dependency(Customer,OrderItem)
            try
            {
                if (order == null)
                {
                    throw new InvaliedOrderException("Invalied Order Details");
                }

                Models.Customer customerDb = context.Customers.FirstOrDefault(x => x.CustomerId == order.Customer.CustomerId);

                if (customerDb == null)
                {
                    customerDb = GetCustomerDb(order);
                }

                else
                {
                    context.Entry(customerDb).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    //this will avoid to creating or adding new records. 
                }

                Models.OrderStatus orderStatusDb = context.OrderStatuses.FirstOrDefault(x => x.OrderStatusId == (int)OrderstatusType.ORDERECEVIED);
                //here we use int for getting int value of enum use typecast
                context.Entry(orderStatusDb).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                List<Models.OrderItem> orderItemsDb = GetOrderItems(order).ToList();

                var customerAddressDb = new Models.CustomerAddress()
                {
                    City = order.Customer.CustomerAddress.City,
                    State = order.Customer.CustomerAddress.State,
                    StName = order.Customer.CustomerAddress.StName
                };

                customerDb.CustomerAddress = customerAddressDb;

                Models.Order orderDb = new Models.Order()
                {
                    Customer = customerDb,
                    ClientOrderId = order.ClientOrderId,
                    OrderAmount = order.OrderAmount,
                    DateTime = order.DateTime,
                    OrderStatus = orderStatusDb,
                    OrderItems = orderItemsDb

                };
                this.context.Orders.Add(orderDb);
                this.context.SaveChanges();
                var id = orderDb.OrderId;
                order.OrderId = id;
                isAdded = true;
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
            
            return isAdded;
        }

        public EkartCommon.Models.Order GetOrder(int orderId)
        {
            EkartCommon.Models.Order order = null;
            string sqlst = "sp_getOrderDataById";
            //anther way you can get connection string
            string connectionstring = this.context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(sqlst, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@orderID", orderId);
                        var result = command.ExecuteReader();
                        if(result.HasRows)
                        {
                            order = ExtractOrderData(result);
                        }
                    }
                }

            }
            catch (Exception)
            {
                //log the exception
                throw;
            }

            return order;
        }

        public IEnumerable<EkartCommon.Models.Order> GetOrders( OrderstatusType orderStatusType, string city = null)
        {
            IQueryable<Models.Order> qurey = this.context.Orders
                                               .Include(x => x.Customer)
                                               .Include(x => x.OrderItems)
                                               .Include(x=>x.Customer.CustomerAddress)
                                               .Where(x=>x.OrderStatusId == (int)orderStatusType);
            if(city != null)
            {
                qurey = qurey.Where(x => x.Customer.CustomerAddress.City.Contains(city));
            }
            var result = qurey.ToList();

            var resultToRetrun = (from o in result
                                  select new EkartCommon.Models.Order
                                  {
                                      ClientOrderId = o.ClientOrderId,
                                      Customer = new EkartCommon.Models.Customer
                                      {
                                          //appCustomerId = o.Customer.AppCustomerId,
                                          //EmailID = o.Customer.CustomerEmailId,
                                          CustomerMobileNo = o.Customer.CustomerMobileNo,
                                          CustomerId = o.Customer.CustomerId,
                                          CustomerName = o.Customer.CustomerName,
                                          CustomerAddress = new EkartCommon.Models.CustomerAddress
                                          {
                                              City = o.Customer.CustomerAddress.City,
                                              State = o.Customer.CustomerAddress.State,
                                              StName = o.Customer.CustomerAddress.StName
                                          },
                                      },
                                      ExceptedDeliveryDate = o.ExceptedDeliveryDate,
                                      OrderAmount = o.OrderAmount,
                                      DateTime = o.DateTime,
                                      //OrderStatus = new EkartCommon.Models.OrderStatus()
                                      //{
                                      //    Description = o.OrderStatus.Description,
                                      //    OrderStatusId = o.OrderStatus.OrderStatusId,
                                      //    OrderStatusType = o.OrderStatus.OrderStatusType
                                      //},
                                      OrderId = o.OrderId
                                  }
                                );
            return resultToRetrun;

        }

        public bool UpdateOrder(int id, OrderstatusType orderstatusType, string staffId)
        {
            bool isUpdated = false;
            try
            {
                var ordertoUpdate = this.context.Orders.FirstOrDefault(x => x.OrderId == id);
                if(ordertoUpdate == null)
                {
                    throw new InvaliedOrderException($"Order with {id} does not exists");
                }
                var orderStatusId = (int)orderstatusType;
                var orderStatus = this.context.OrderStatuses.FirstOrDefault(x => x.OrderStatusId == orderStatusId);
                ordertoUpdate.OrderStatus = orderStatus;
                ordertoUpdate.StaffId = staffId;
                this.context.SaveChanges();
                isUpdated = true;
             }
            catch (Exception)
            {
                // log the exception
                throw;
            }
            return isUpdated;
        }

        public IEnumerable<EkartCommon.Models.Order> GetOrdersToDeliverd(OrderstatusType orderStatusType,  string staffId)
        {
            try
            {
                var orders = this.context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.OrderItems)
                    .Include(x => x.Customer.CustomerAddress)
                    .Where(x => x.OrderStatusId == (int)orderStatusType)
                    .Where(x => x.StaffId == staffId)
                    .ToList();
                if(orders != null)
                {
                    var resultToRetrun = (from o in orders
                                          select new EkartCommon.Models.Order
                                          {
                                              OrderId = o.OrderId,
                                              OrderAmount = o.OrderAmount,
                                              Customer = new EkartCommon.Models.Customer
                                              {
                                                  CustomerName = o.Customer.CustomerName,
                                                  CustomerMobileNo = o.Customer.CustomerMobileNo,
                                                     CustomerAddress = new EkartCommon.Models.CustomerAddress
                                                     {
                                                      City = o.Customer.CustomerAddress.City,
                                                      StName = o.Customer.CustomerAddress.StName
                                                     
                                                     },
                                              },
                                          }
                                          );
                    return resultToRetrun;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        #endregion
        #region Private Method
        private IEnumerable<Models.OrderItem> GetOrderItems(EkartCommon.Models.Order order)
        {
            //Linq query in c#
            var orderItemsDb = from o in order.OrderItems
                                  select new Models.OrderItem
                                  {
                                      Price = o.Price,
                                      Qty = o.Qty
                                  };
            return orderItemsDb;
            //var orderItemsDb = new List<Models.OrderItem>();
            //foreach (var item in order.OrderItems)
            //{
            //    Models.OrderItem orderItem = new Models.OrderItem()
            //    {
            //        Price = item.Price,
            //        Qty = item.Qty,

            //    };
            //    orderItemsDb.Add(orderItem);
            //}
            //return orderItemsDb;
        }

        private Models.Customer GetCustomerDb(EkartCommon.Models.Order order)
        {
            return new Models.Customer()
            {
                AppCustomerId = order.Customer.appCustomerId,
                CustomerEmailId = order.Customer.appCustomerId,
                CustomerMobileNo = order.Customer.CustomerMobileNo,
                CustomerName = order.Customer.CustomerName,
            };
        }

        private EkartCommon.Models.Order ExtractOrderData(SqlDataReader result)
        {
            EkartCommon.Models.Order order = null;
            var datatable = new DataTable();
            datatable.Load(result);
            var newDataTable = datatable.DefaultView.ToTable(true,
                         "OrderId", "DateTime", "OrderAmount", "ExceptedDeliveryDate",
                         "OrderStatusId", "StatusType",
                         "customerid", "customername", "customermobileno", "CustomerEmailID", "appcustomerid",
                         "stname", "city", "state",
                         "Price", "Qty");

            if(newDataTable.Rows.Count > 0)
            {
                var row = newDataTable.Rows[0];
                order = new EkartCommon.Models.Order()
                {
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    DateTime = Convert.ToDateTime(row["DateTime"]),
                    OrderAmount = Convert.ToDouble(row["OrderAmount"]),
                    ExceptedDeliveryDate = Convert.ToDateTime(row["ExceptedDeliveryDate"])
                };
                EkartCommon.Models.OrderStatus orderStatusType = new EkartCommon.Models.OrderStatus()
                {
                    OrderStatusId = Convert.ToInt32(row["OrderStatusId"]),
                    OrderStatusType = row["StatusType"].ToString()
                };
                order.OrderStatus = orderStatusType;
                EkartCommon.Models.Customer customer = new EkartCommon.Models.Customer()
                {
                    appCustomerId = row["appcustomerid"].ToString(),
                    EmailID = row["CustomerEmailID"].ToString(),
                    CustomerId = Convert.ToInt32(row["customerid"]),
                    CustomerMobileNo = row["customermobileno"].ToString(),
                    CustomerName = row["customername"].ToString()
                };
                order.Customer = customer;
                EkartCommon.Models.CustomerAddress customerAddress = new EkartCommon.Models.CustomerAddress()
                {
                    City = row["city"].ToString(),
                    State = row["state"].ToString(),
                    StName = row["stname"].ToString(),
                };
                order.Customer.CustomerAddress = customerAddress;
                var orderItem = ExtractOrderItem(order.OrderId, datatable);
                order.OrderItems = orderItem;
            }

            return order;
        }

        private ICollection<EkartCommon.Models.OrderItem> ExtractOrderItem(int orderId, DataTable datatable)
        {
            List<EkartCommon.Models.OrderItem> orderItems = new List<EkartCommon.Models.OrderItem>();
            var view = datatable.DefaultView;
            var newDataTable = view.ToTable(false,
                                            "Price", "Qty");

            foreach (DataRow row in newDataTable.Rows)
            {
                EkartCommon.Models.OrderItem orderItem = new EkartCommon.Models.OrderItem()
                {
                    Orderid = orderId,
                    Price = Convert.ToInt32(row["Price"]),
                    Qty = Convert.ToInt32(row["Qty"])

                };
                orderItems.Add(orderItem);
            }
            return orderItems;
        }

        
        #endregion
    }
}
