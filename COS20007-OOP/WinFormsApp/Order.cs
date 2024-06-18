namespace WinFormsApp
{
    public class Order : Entity
    {
        private int _customerId;
        private int _staffId;

        private DateTime _dateTime;
        private Dictionary<Item, int> _items;
        public Order(int id, int customerId, int staffId,
            Dictionary<Item, int> items, DateTime? dateTime = null) : base(id)
        {
            _customerId = customerId;
            _staffId = staffId;
            _items = items;
            
            // if no date specified, get 'now' as date (new order)
            _dateTime = dateTime == null ? DateTime.Now : (DateTime)dateTime;
        }
    }
}
