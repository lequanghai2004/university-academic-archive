namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        public Bag(string[] ids, string name, string desc)
            : base(ids, name, desc) {}
        public override string FullDescription
        {
            get
            {
                return base.FullDescription + "\nIn the " + Name + " you can see:\n" + _inventory.ItemList;
            }
        }
        public Inventory Inventory { get { return _inventory; } }
        public GameObject? Locate(string id)
        {
            if(AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}
