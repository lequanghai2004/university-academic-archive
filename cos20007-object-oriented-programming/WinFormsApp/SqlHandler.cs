using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp
// Note: any invocation requires to be put in a try-catch block
{
    public class SqlHandler : SqlContext
    {
        private static SqlHandler? _instance;
        public static SqlHandler Instance
        {
            get { return _instance == null ? new SqlHandler() : _instance; }
        }
        private SqlHandler() : base()
        {

        }
        public async Task<DataTable> GetTable(string query, params (string, object)[] parameters)
        // asynchronously executes a SQL query and return a SqlDataReader obj
        {
            try
            {
                SqlCommand cmd = await CreateCmd(query, parameters);
                // execute the query and retrieve the data into a DataTable
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Dispose();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error executing {query}: {e.Message}. {e.StackTrace}");
                throw new Exception();
            }
            finally
            {
                CloseConn();
            }
        }
        public async Task<object?> GetScalar(string query, params (string, object)[] parameters)
        {
            try
            {
                using (SqlCommand cmd = await CreateCmd(query, parameters))
                {
                    // ExecuteScalarAsync directly returns the count
                    return await cmd.ExecuteScalarAsync();
                }
            }
            catch (Exception e)
            {
                // Handle exceptions or log them
                throw new Exception($"Error executing {query}: {e.Message} {e.StackTrace}");
            }
            finally
            {
                CloseConn();
            }
        }
        public async Task<Dictionary<string, object>> GetSingleRecord(string query, params (string, object)[] parameters)
        {
            try
            {
                using (SqlCommand cmd = await CreateCmd(query, parameters))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        if (await reader.ReadAsync())
                        {
                            Dictionary<string, object> record = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object columnValue = reader.GetValue(i);
                                record.Add(columnName, columnValue);
                            }
                            return record;
                        }
                        throw new Exception($"No record found");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error executing {query}: {e.Message} {e.StackTrace}");
            }
            finally
            {
                CloseConn();
            }
        }
        public async Task<int> ExeQuery(string query, params (string, object)[] parameters)
        // exe query without returning sth, use for INSERT, DELETE
        // return no of affected rows
        {
            try
            {
                using (SqlCommand cmd = await CreateCmd(query, parameters))
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error executing {query}: {e.Message} {e.StackTrace}");
            }
        }
    }
}
