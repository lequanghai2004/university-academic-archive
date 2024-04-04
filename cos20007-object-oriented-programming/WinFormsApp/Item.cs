namespace WinFormsApp
{
    public class Item : Entity
    {
        private string _title;
        private string _types;
        private string _options;
        private decimal _costInVnd;
        public Item(int id, string title, string types, string options, decimal costInVnd) 
            : base(id)
        {
            _title = title;
            _types = types;
            _options = options;
            _costInVnd = costInVnd;
        }
        public string Title { get { return _title; } }
        public string Types { get { return _types; } }
        public string Options { get { return _options;} }
        public decimal CostInVnd { get {  return _costInVnd; } }
    }
}
