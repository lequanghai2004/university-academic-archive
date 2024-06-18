namespace WinFormsApp
{
    public class Staff : User
    // staff account has 0 < priority < 100, status != 0, branch != null
    {
        private string _status;
        private string _branch;
        public Staff(int id, int priority, string status, string branch)
            : base(id, priority)
        {
            _status = status;
            _branch = branch;
        }
    }
}
