using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EkartData.Util
{
    public sealed class ConnectionHelper
    {
        // private  readonly string connectionString = @"Data Source=SHRUTI-KD\MSSQLSERVER01;Initial Catalog=db_eKARTS;Integrated Security=True";
        private static readonly Lazy<ConnectionHelper> connectionHelper =
            new Lazy<ConnectionHelper>(() => new ConnectionHelper());

        private ConnectionHelper()
        {
        }

        public static ConnectionHelper Instance
        {
            get
            {
                return connectionHelper.Value;
            }
        }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Default");

            return connectionString;

        }
    }
}
