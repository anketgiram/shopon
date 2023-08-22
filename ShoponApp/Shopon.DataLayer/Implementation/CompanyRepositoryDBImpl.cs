using ShoponCommonLayer.CustomExceptions;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Implementation
{
    public class CompanyRepositoryDBImpl : ICompanyRepository
    {
        private readonly String connectionString = null;
        public CompanyRepositoryDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance(); //not creating a new object
            this.connectionString = connectionUtil.GetConnectionString();
        }
        public bool AddCompany(Company company)
        {
            //DISCONNECTED
            //1.create dataset
            //2.create new row with comapny data
            //3.add new row to existing rows
            //4.update to main database
            bool isInserted = false;
            string sqlSt = $"SELECT c.companyid,c.companyname,c.companyStatus,c.isDeleted FROM" +
                          $" dbo.company AS c WITH(NOLOCK)";
            SqlDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            SqlCommandBuilder builder = null;//to do the insert or update record(to adapt to changes)
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(sqlSt, connection);
                    adapter.Fill(dataSet, "Company");//dataset and sourse table,dataset has a table collection
                    builder = new SqlCommandBuilder(adapter);

                    //1.create row
                    DataRow row = dataSet.Tables["company"].NewRow();//return new row which has existing row data types
                    row["CompanyId"] = company.CompanyId;
                    row["companyname"] = company.CompanyName;
                    row["companystatus"] = "Y";
                    row["isDeleted"] = 0;
                    //3.Add new row to the exising rows
                    dataSet.Tables["company"].Rows.Add(row);

                    //4.update the main database
                    adapter.Update(dataSet, "Company");//updating the whole dataset
                    isInserted = true;

                }
            }
            catch (Exception)
            {
                throw;
            }
            return isInserted;

        }

        public bool DeleteCompany(int companyId)
        {
            bool isDeleted = false;
            try
            {
                string sqlSt = $"UPDATE company " +
                            $"SET " +
                            $"isDeleted=@isDeleted " +
                            $"WHERE companyid=@companyId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@companyId", companyId);
                        command.Parameters.AddWithValue("@isDeleted", 1);
                        command.ExecuteNonQuery();
                        isDeleted = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;

        }

        public IEnumerable<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            string sqlSt = $"SELECT c.companyid,c.companyname FROM dbo.company AS c WITH(NOLOCK)";
            //1.Create Apopter
            SqlDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            try
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(sqlSt, connection);
                    adapter.Fill(dataSet, "Company");//dataset and sourse table,dataset has a table collection

                    DataTable companyTable = dataSet.Tables["Company"];//fetching the table named company from a collection
                    foreach (DataRow row in companyTable.Rows)
                    {
                        Company company = new Company();
                        company.CompanyId = Convert.ToInt32(row["companyid"]);
                        company.CompanyName = row["companyname"].ToString();
                        //company.CompanyStatus = row["companystatus"].ToString();
                        companies.Add(company);
                    }
                        
                }
            }
            catch(Exception)
            {
                throw;
            }
            return companies;
        }

        public Company GetCompanyById(int companyId)
        {
            ///CONNECTED WAY
            Company company = null;
            try
            {
                string sqlSt = $"SELECT " +
                                 $"c.companyid, " +
                                 $"c.companyname " +
                                 $"FROM company AS c WITH(NOLOCK) " +
                                 $"WHERE c.companyid=@companyID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@companyID", companyId);
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            company = new Company()
                            {
                                CompanyId = Convert.ToInt32(reader["companyid"]),
                                CompanyName = reader["companyname"].ToString()
                            };
                            
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw new CompanyNotFoundException($"Company with Id:{companyId} does not exist");
            }
            return company;

        }

        public Company GetCompanyByName(string companyName)
        {
            //CONNECTED WAY
            Company company = null;
            try
            {
                string sqlSt = $"SELECT " +
                                 $"c.companyid, " +
                                 $"c.companyname " +
                                 $"FROM company AS c WITH(NOLOCK) " +
                                 $"WHERE c.companyname LIKE @companyName";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@companyName", companyName);
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            
                            company = new Company()
                            {
                                CompanyId = Convert.ToInt32(reader["companyid"]),
                                CompanyName = reader["companyname"].ToString()
                            };
                            
                        }
                        //else
                        //{
                        //   throw new CompanyNotFoundException($"Company with Name:{companyName} does not exist");
                        //}
                    }
                }
            }
            catch (Exception)
            {

                throw new CompanyNotFoundException($"Company with Name:{companyName} does not exist");
            }
            return company;
        }

        public bool UpdateCompany(Company company)
        {
            bool isUpdated = false;
            try
            {
                string sqlSt = $"UPDATE company " +
                            $"SET " +
                            $"companyname=@companyname, " +
                            $"companystatus=@companystatus, " +
                            $"WHERE companyid=@companyId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@companyId",company.CompanyId);
                        command.Parameters.AddWithValue("@companyname", company.CompanyName);
                        command.Parameters.AddWithValue("@companystatus", company.CompanyStatus);
                        command.ExecuteNonQuery();
                        isUpdated = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isUpdated;

        }
    }
}
