namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public abstract GameObject? Locate(string id);
        public abstract Inventory Inventory { get; }
        public abstract string Name { get; }
    }
}
