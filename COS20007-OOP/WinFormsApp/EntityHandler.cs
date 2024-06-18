using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Security.Permissions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp
{
    public abstract class EntityHandler
    // responsible for add/drop record to/from a table on db
    // functionality extends on child class
    {
        protected SqlHandler _sql;
        protected string _table;
        protected string? _uniqueField;
        protected EntityHandler(string table, string? uniqueField = null)
        {
            _sql = SqlHandler.Instance;
            _table = table;
            _uniqueField = uniqueField;
        }
        protected async Task<bool> RecordExist(object value)
        {
            string query = $"SELECT COUNT(*) FROM {_table} "
                + $"WHERE {_uniqueField} COLLATE SQL_Latin1_General_CP1_CS_AS = @{_uniqueField}";
            
            return await _sql.GetScalar(query, ($"@{_uniqueField}", value)) as int? == 1;
        }
        public async Task AddRecord(params (string field, object obj)[] data)
        {
            try
            {
                object? value = null;
                
                // take the unique column value 
                foreach (var pair in data)
                {
                    if (pair.field == _uniqueField)
                    {
                        value = pair.obj;
                        break;
                    }
                }

                // check if that value exists
                if (value != null)
                {
                    // check if the record with that value exists
                    if (await RecordExist(value))
                    {
                        MessageBox.Show("There exists a record with that " + _uniqueField);
                        return;
                    } // else continue
                }

                // add new record to db
                string query = $"INSERT INTO {_table} (";

                foreach (var pair in data) query += pair.field + ",";
                query = query.TrimEnd(',');
                query += ") VALUES (";

                for (int i = 0; i < data.Length; i++)
                // Add "@" at the beginning of each field
                {
                    data[i] = (@"@" + data[i].field, data[i].obj);
                }

                foreach (var pair in data) query += pair.field + ",";
                query = query.TrimEnd(',');
                query += ");";

                // execute and check if succeeded (1 row affected)
                if (await _sql.ExeQuery(query, data) == 1)
                {
                    MessageBox.Show($"A new record has been added to {_table} table");
                }
                else throw new Exception();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error adding record: " + e.Message + e.StackTrace);
            }
        }
        public async Task DropRecord(object value)
        {
            try
            {
                // check if the record exists
                if (!await RecordExist(value))
                {
                    MessageBox.Show("There isn't a record with that " + _uniqueField);
                    return;
                }

                // remove record from db
                string query = $"DELETE FROM {_table} WHERE {_uniqueField} = @{_uniqueField}";

                // check if succeed (1 row affected)
                if (await _sql.ExeQuery(query, ($"@{_uniqueField}", value)) == 1)
                {
                    MessageBox.Show($"Record has been removed from the {_table} table");
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to delete from " + _table + ": " + e.Message + e.StackTrace);
            }
        }
    }
}
