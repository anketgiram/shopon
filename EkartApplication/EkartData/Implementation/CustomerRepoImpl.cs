using EkartCommon.Models;
using EkartData.Contract;
using EkartData.Util;
using System;
using System.Data.SqlClient;

namespace EkartData.Implementation
{
    public class CustomerRepoImpl : ICustomerRepo
    {

        private string connectionString = string.Empty;
        public CustomerRepoImpl()
        {
            var connectionHelp = ConnectionHelper.Instance;
            this.connectionString = connectionHelp.GetConnectionString();
        }
        public bool AddCustomer(Customer customer)
        {
            //1.Check if customer is already exist in the application
            //-Yes(Check for the data and update if required)
            //-No(add new customer)
            //2.Check if customer address is already exits in the application
            //Yes (check for the data and update if required)
            //No-Add new Customer address

            bool isInserted = false;
            string sqlSt = "sp_InsertCustomerInfo";
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(sqlSt, sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@customerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@customerMobileNumber", customer.CustomerMobileNo);
                    command.Parameters.AddWithValue("@customerEmailid", customer.EmailID);
                    command.Parameters.AddWithValue("@appcustomerid", customer.appCustomerId);
                    command.Parameters.AddWithValue("@stname", customer.CustomerAddress.StName);
                    command.Parameters.AddWithValue("@city", customer.CustomerAddress.City);
                    command.Parameters.AddWithValue("@state", customer.CustomerAddress.State);

                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        isInserted = true;
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
            return isInserted;
        }

        public Customer GetCustomer(int customerId)
        {
            Customer customer = null;
            try
            {
                string sqlSt = $"SELECT CustomerId,CustomerName,CustomerMobileNo,AppCustomerId,CustomerEmailID " +
                               $"from dbo.customer where customerid=@id";
                //1.Create connection using connection string
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    //2.Create Cammand
                    SqlCommand command = new SqlCommand(sqlSt, sqlConnection);
                    command.Parameters.AddWithValue("@id", customerId);
                    //3.Execute Cammand
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        customer = new Customer();
                        customer.appCustomerId = reader["appcustomerid"].ToString();
                        customer.CustomerId = Convert.ToInt32(reader["customerid"].ToString());
                        customer.CustomerName = reader["customername"].ToString();
                        customer.CustomerMobileNo = reader["customermobileno"].ToString();
                        customer.EmailID = reader["Customeremailid"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return customer;
        }
    }
}
