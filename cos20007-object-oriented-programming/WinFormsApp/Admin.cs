namespace WinFormsApp
{
    public class Admin : User
    // admin account has priority = 100, status = "admin", branch = null
    {
        public Admin(int id) 
            : base(id, 100)
        {

        }
    }
}
