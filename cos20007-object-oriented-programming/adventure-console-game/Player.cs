using System;
using System.Globalization;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;
        public Player(string name, string desc, Location location)
            : base(new string[] {"me", "inventory"}, name, desc)
        {
            _location = location;
        }
        public override string FullDescription
        {
            get // name, desc, details of items in inventory
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                return "You are " + textInfo.ToTitleCase(Name)
                    + ", " + base.FullDescription
                    + ". You are carrying:\n" 
                    + _inventory.ItemList;
            }
        }
        public Inventory Inventory { get { return _inventory; } }
        public Location Location 
        {
            get { return _location; }
            set { _location = value; }
        }
        public GameObject? Locate(string id)
        // find a Game Object around the player
        {
            // find themselves
            if (AreYou(id)) { return this; }

            // find in player inventory
            Item? item = _inventory.Fetch(id);
            if (item != null) { return item; }
            
            // find in current location
            return _location.Locate(id);
        }
        public string Travel(string direction)
        // move to new location, return the path description
        {
            Path? path = _location.Travel(direction);
            if (path == null) return "There is no valid path to go " + direction;
            return path.Travel(this);
        }
    }
}
