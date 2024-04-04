namespace WinFormsApp
{
    public class OrderHandler : EntityHandler
    {
        private static OrderHandler? _instance;
        public static OrderHandler Instance
        {
            get { return _instance == null ? new OrderHandler() : _instance; }
        }
        private OrderHandler() : base("orders", "") { }
        public async void AddOrder(int orderId, int customerId, int staffId, 
            Dictionary<Item, int> items, int approach)
        {
            try
            {
                Task addorder = AddRecord(("id", orderId),
                    ("customer_id", customerId),
                    ("staff_id", staffId),
                    ("approach", approach));
                


                await addorder;
            }
            catch(Exception e) 
            {
                MessageBox.Show("Add order failed: " + e.Message);
            }
        }
    }
}
//public Task AddUser(string username, string password, string priority,
//          string fullname, string email, string phoneNo)
//{
//    int p;
//    try // convert priority input from str to int
//    {
//        p = Int32.Parse(priority);
//        if (p < 0) throw new Exception();
//    }
//    catch
//    {
//        throw new Exception("Priority must be a non-negative integer");
//    }

//         handle the empty string parameters
//        List<(string, object)> parameters = new List<(string, object)>
//                {
//                    ("username", username),
//                    ("password", hashPassword),
//                    ("pwd_salt", salt),
//                    ("priority", p),
//                };
//        if (fullname != "") parameters.Add(("fullname", fullname));
//        if (email != "") parameters.Add(("email", email));
//        if (phoneNo != "") parameters.Add(("phone_no", phoneNo));

//        return AddRecord(parameters.ToArray());
//    }
//    catch (Exception e)