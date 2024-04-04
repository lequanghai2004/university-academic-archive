using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp
{
    public class UserHandler : EntityHandler
    // singleton class
    // responsible for add or drop and validate user account
    {
        private static UserHandler? _instance;
        public static UserHandler Instance
        {
            get { return _instance == null ? new UserHandler() : _instance; }
        }
        private UserHandler() : base("users", "username") { }
        private short GetSalt()
        // get a random value to concatenate to pwd before hashing
        {
            Random random = new Random();
            short min = short.MinValue + 1000;
            short max = short.MaxValue - 1000;
            return (short)random.Next(min, max);
        }
        private byte[] HashPassword(string password)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public Task AddUser(string username, string password, string priority, 
            string fullname, string email, string phoneNo)
        {
            int p; 
            try // convert priority input from str to int
            {
                p = Int32.Parse(priority);
                if (p < 0) throw new Exception();
            }
            catch
            {
                throw new Exception("Priority must be a non-negative integer");
            }

            try
            {
                // hash the password before storing
                short salt = GetSalt();
                byte[] hashPassword = HashPassword(password + salt);

                // handle the empty string parameters
                List<(string, object)> parameters = new List<(string, object)>
                {
                    ("username", username),
                    ("password", hashPassword),
                    ("pwd_salt", salt),
                    ("priority", p),
                };
                if (fullname != "") parameters.Add(("fullname", fullname));
                if (email != "") parameters.Add(("email", email));
                if (phoneNo != "") parameters.Add(("phone_no", phoneNo));

                return AddRecord(parameters.ToArray());
            }
            catch(Exception e)
            {
                throw new Exception("User handler: Invalid input argument" + e.Message + e.StackTrace);
            }
        }
        public async Task<User?> ValidateUser(string username, string password)
        {
            string query = $"SELECT * FROM {_table} "
                + $"WHERE username COLLATE SQL_Latin1_General_CP1_CS_AS = @username";

            try // valid username & password should match exclusively 1 record
            {
                DataTable data = await _sql.GetTable(query, ("@username", username));

                // check if there is any row
                if (data.Rows.Count == 0) return null;

                // check password
                if (!PasswordIsCorrect(password, data)) return null; 

                // return a user
                return new User(data.Rows[0].Field<int>("id"),
                    data.Rows[0].Field<int>("priority"));
            }
            catch (SqlException e)
            {
                MessageBox.Show("SQL error validating user: " + e.Message + e.StackTrace);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error validating user: " + e.Message + e.StackTrace);
                return null;
            }
        }
        private bool PasswordIsCorrect(string password, DataTable data)
        {
            // extract salt from the DataTable (assuming it's a short?)
            short? salt = data.Rows[0].Field<short?>("pwd_salt");

            // extract the hashed password (non-nullanle) from db 
            byte[] dbPassword = data.Rows[0].Field<byte[]>("password");

            // calculate hashed (pwd + salt)
            byte[] hashPassword = HashPassword(password + salt ? .ToString() ?? "");

            // compare the hashed passwords
            return hashPassword.SequenceEqual(dbPassword);
        }
        public async Task<DataTable> GetAllUser()
        {
            return await _sql.GetTable("SELECT * FROM users");
        }
    }
}