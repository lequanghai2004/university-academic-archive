using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace SwinAdventure
{
    public class Location : IdentifiableObject, IHaveInventory
    {
        private string _name;
        private string _description;
        private Inventory _inventory = new Inventory();
        private Dictionary<string, Path> _paths = new Dictionary<string, Path>();
        public Location(string name, string description) 
            : base(new string[] { "location", "" })
        {
            _name = name;
            _description = description;
        }
        public Inventory Inventory { get { return _inventory; } }
        public string Name { get { return _name; } }
        public string FullDescription
        {
            get // assume there is at least an exit
            {
                string exits = "";
                foreach (string direction in _paths.Keys)
                {
                    exits += direction + ", ";
                }
                if (_paths.Count != 0) // remove the comma at the end
                {
                    exits = exits.TrimEnd(',', ' ');
                }
                return "You are in " + _name + "\n" + _description
                    + "\nThere are exits to the " + exits
                    + "\nIn this room you can see:\n" + _inventory.ItemList;
            }
        }
        public GameObject? Locate(string id)
        {
            return _inventory.Fetch(id);
        }
        public void AddPath(string direction, Path path)
        {
            _paths[direction.ToLower()] = path;
        }
        public string RemovePath(string direction)
        {
            // remove path from direction if exists
            if (_paths.ContainsKey(direction))
            {
                _paths.Remove(direction);
                return "Successfully remove the path to " + direction;
            }

            // no path to the direction
            return "There is no path to go " + direction;
        }
        public Path? Travel(string direction)   
        {
            direction = direction.ToLower();
            
            // no path available
            if (!_paths.ContainsKey(direction)) return null;
            
            // return path from that direction
            return _paths[direction];
        }
    }
}
