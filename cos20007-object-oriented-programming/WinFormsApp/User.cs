namespace WinFormsApp
{
    public class User : Entity
    {
        private int _priority;
        public User(int id, int priority)
            : base(id)
        {
            _priority = priority;
        }
        public int Priority { get { return _priority; } }
    }
}
