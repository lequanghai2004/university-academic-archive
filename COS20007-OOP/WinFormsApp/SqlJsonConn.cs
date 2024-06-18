using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class SqlJsonConn : SqlContext
    {
        public SqlJsonConn() : base(GetConnStr())
        {

        }
        private static string GetConnStr()
        {
            string configDir = Directory.GetCurrentDirectory() + @"\..\..\..";
            string configPath = "config.json";
            try
            {
                // Build configuration
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(configDir)
                    .AddJsonFile(configPath)
                    .Build();

                // Retrieve the connection string
                return configuration.GetConnectionString("DefaultConnection");
            }
            catch (Exception e)
            {
                throw new Exception("Connection establishment failed: " + e.Message + e.StackTrace);
            }
        }
    }
}
