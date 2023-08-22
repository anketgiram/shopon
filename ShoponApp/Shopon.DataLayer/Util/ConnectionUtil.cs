using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponDataLayer.Util
{
    public sealed class ConnectionUtil
    {
        private readonly String connectionString = string.Empty;
            

        private static readonly ConnectionUtil connectionUtil = new ConnectionUtil();
        private ConnectionUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetConnectionString("Default");
        }
        public static ConnectionUtil GetInstance()//it will rwtuen the object of this class,using this each class access the GETConnectionString()
        {
            return connectionUtil;
        }

        public string GetConnectionString()
        {
            return this.connectionString;
        }
    }
}
