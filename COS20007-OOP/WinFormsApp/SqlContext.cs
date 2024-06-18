using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public abstract class SqlContext : IDisposable
    {
        private SqlConnection _conn;
        protected SqlContext(string connectionString)
        {
            try
            {
                _conn = new SqlConnection(connectionString);
            }
            catch (ArgumentException e)
            {
                throw new Exception("Invalid connection string, failed to connect to the database: " + e.Message, e);
            }
            catch (Exception e)
            {
                throw new Exception("Error initializing SqlConnection: " + e.Message);
            }
        }
        protected SqlContext() : this(GetConnStr())
        // get connection string from a external json file
        // connect to the database using the obtained string
        // throw an exception if fails
        {
            
        }
        private static string GetConnStr()
        {
            string configDir = Directory.GetCurrentDirectory() + @"\..\..\..";
            string configPath = "config.json";

            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(configDir)
                .AddJsonFile(configPath)
                .Build();
            // Retrieve the connection string
            return configuration.GetConnectionString("DefaultConnection");
        }
        public async Task OpenConn()
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    await _conn.OpenAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error opening connection: " + e.Message);
            }
        }
        public void CloseConn()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error closing connection: " + e.Message);
            }
        }
        public void Dispose()
        // release the resources
        {
            _conn.Dispose();
        }
        protected async Task<SqlCommand> CreateCmd(string query, params (string, object)[] parameters)
        // return a SqlCommand object for other methods to execute
        {
            SqlCommand cmd = new SqlCommand(query, _conn);

            // add params to the cmd to prevent sql injection
            if (parameters != null)
            {
                foreach ((string key, object value) in parameters)
                {
                    cmd.Parameters.AddWithValue(key, value);
                }
            }

            // open the connection for execution
            await OpenConn(); 
            return cmd;
        }
    }
}
