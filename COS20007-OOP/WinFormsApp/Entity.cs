namespace WinFormsApp
{
    public class Entity
    {
        protected object _id;
        public Entity(object id)
        {
            _id = id;
        }
        public object Id { get { return _id; } }
    }
}
