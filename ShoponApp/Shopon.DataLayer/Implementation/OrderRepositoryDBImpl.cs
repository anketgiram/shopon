using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Implementation
{
    public class OrderRepositoryDBImpl : IOrderRepository
    {
        private readonly string connectionString = null; 
        public OrderRepositoryDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            this.connectionString = connectionUtil.GetConnectionString();
        }
        public Order AddOrder(Order order)
        {
            //1.Insert to Order
            //2.Get new orderid and insert all orderitems with new orderid
            //3.if any exception raise,then cancel insert to order and orderitem(Handle it in Transaction)
            //because if the order is not added then orderitem also should not be added
            //4.Return order with new order id

            /*string sqlSt = $"INSERT INTO dbo.orderd(" +
                            $"orderstatus," +
                            $"orderdate," +
                            $"customerid," +              //NORMAL WAY FOR INSERTING
                            $"totalAmount" +
                            $")VALUES(" +
                                $"@orderStatus," +
                                $"@orderDate," +
                                $"@customerId," +
                                $"@totalAmount)";
            */
            SqlTransaction transaction = null;
            try
            {
                string sqlSt = "sp_InsertOrder";//name of stored procedure
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //1.Create transaction
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection,transaction))
                    {
                        //command.CommandText = sqlSt;   //also use like that instead of passing in constructor of SqlCommand
                        //command.Connection = connection;
                        //command.Transaction = transaction;

                        ///2.Command type is StoredProcedure
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        //creating parameter to pass to storedprocedure

                        //@orderDate
                        SqlParameter orderDate = command.Parameters.Add("@orderDate", System.Data.SqlDbType.Date);
                        orderDate.Value = order.OrderDate;
                        orderDate.Direction = System.Data.ParameterDirection.Input;

                        //@customerId
                        SqlParameter customerId = command.Parameters.Add("@customerId", System.Data.SqlDbType.Int);
                        customerId.Value = order.CustomerId==0?null:order.CustomerId;
                        customerId.Direction = System.Data.ParameterDirection.Input;

                        //@totalAmount
                        SqlParameter totalAmount = command.Parameters.Add("@totalAmount", System.Data.SqlDbType.Float);
                        totalAmount.Value = order.OrderTotal;
                        totalAmount.Direction = System.Data.ParameterDirection.Input;

                        //@aspNetCustomerId
                        SqlParameter aspNetCustomerId = command.Parameters.Add("@aspNetCustomerId", System.Data.SqlDbType.NVarChar,450);
                        aspNetCustomerId.Value = order.AspCustomerId;
                        aspNetCustomerId.Direction = System.Data.ParameterDirection.Input;

                        //@orderId
                        SqlParameter orderId = command.Parameters.Add("@orderId", System.Data.SqlDbType.Int);
                        orderId.Direction = System.Data.ParameterDirection.Output;

                        var recNo = command.ExecuteNonQuery();
                        if(recNo>0)
                        {
                            var newOrderId = Convert.ToInt32(command.Parameters["@orderId"].Value);
                            order.OrderId = newOrderId;
                            var isOrderItemInserted =InsertOrderItem(connection, transaction, newOrderId, order.GetOrderItems());
                            if(isOrderItemInserted)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }



                    }
                }
            }
            catch (Exception e)
            {
                //If anything happends cancel trans
                //transaction.Rollback();
                throw;
            }
            return order;
        }

        

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrderByCustomerID(int CustomerId)
        {
            throw new NotImplementedException();
        }

        private bool InsertOrderItem(SqlConnection connection, SqlTransaction transaction, int newOrderId, IEnumerable<OrderItem> orderItems)
        {
            bool isInserted = false;
            string sqlSt = "sp_InsertOrderItem";
            try
            {
                foreach (var item in orderItems)
                {
                    using (SqlCommand command = new SqlCommand(sqlSt, connection, transaction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        //@pid
                        SqlParameter pid = command.Parameters.Add("@pid", System.Data.SqlDbType.Int);
                        pid.Value = item.Product.PId;
                        pid.Direction = System.Data.ParameterDirection.Input;

                        //@qty
                        SqlParameter qty = command.Parameters.Add("@qty", System.Data.SqlDbType.Int);
                        qty.Value = item.Qty;
                        qty.Direction = System.Data.ParameterDirection.Input;

                        //@orderId
                        SqlParameter orderId = command.Parameters.Add("@orderID", System.Data.SqlDbType.Int);
                        orderId.Value = newOrderId;
                        orderId.Direction = System.Data.ParameterDirection.Input;

                        var noRecInserted = command.ExecuteNonQuery();
                        if(noRecInserted>0)
                        {
                            isInserted = true;
                            //transaction.Commit
                        }
                        //else
                        //{
                        //    transaction.Rollback;
                        //}

                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return isInserted;
        }
    }
}
