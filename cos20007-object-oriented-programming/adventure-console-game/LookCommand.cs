using System.ComponentModel;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { 
            @"^look( at [a-z]+( in [a-z]+)?)?$" })
        {

        }
        public override string Do(Player player, string[] text)
        // a look command example: "look", "at", <item>, ("in", <container>)
        // text[2] is item to look, text[4] is container to search for item
        // when no container specified, search from the player's inventory and location
        {
            // look around location
            if (text.Length == 1) return player.Location.FullDescription;
            
            IHaveInventory? container;
            // look inside inventory
            if (text.Length == 5 && !new string[] { "me", "inventory" }.Contains(text[4]))
            {
                container = FetchContainer(player, text[4]);
                if (container == null) return "I cannot find the " + text[4];
            }
            // look themselves
            else container = player;
            return LookAtIn(text[2], container);
        }
        private IHaveInventory? FetchContainer(Player player, string containerId)
        {
            return player.Inventory.Fetch(containerId) as IHaveInventory;
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? item = container.Locate(thingId);
            if (item == null)
            {
                if (container is Player) return "I cannot find the " + thingId;
                return "I cannot find the " + thingId + " in the " + container.Name;
            }
            return item.FullDescription;
        }
    }
}
