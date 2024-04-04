namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        public Inventory() { }
        public bool HasItem(string id)
        {
            id = id.ToLower();
            foreach(Item item in _items)
            {
                if(item.FirstId() == id) return true;
            }
            return false;
        }
        public void Put(Item item) // add item
        {
            _items.Add(item);
        }
        public Item? Take(string id) // remove item
        {
            id = id.ToLower();
            foreach(Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }
        public Item? Fetch(string id) // locate item by id
        {
            foreach(Item item in _items)
            {
                if (item.AreYou(id)) return item;
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                if(_items.Count > 0)
                {
                    string result = "\t";
                    foreach(Item item in _items) result += item.ShortDescription + "\n\t";
                    return result;
                }
                return "There is nothing in here";                
            }
            
        }
    }
}
