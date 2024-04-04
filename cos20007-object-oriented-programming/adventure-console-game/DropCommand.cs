using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

namespace SwinAdventure
{
    public class DropCommand : Command
    {
        public DropCommand() : base(new string[] { @"^(put|drop) [a-z]+( in [a-z]+)?$" })
        {

        }
        public override string Do(Player player, string[] text)
        // player put item into a container.
        // if no destination specified use current location
        // exp: put paper (in room), drop paper (in bag) 
        // exp: put paper in shovel -> not valid, shovel is not container
        {
            string itemId = text[1];
            IHaveInventory container;

            // destination is room or is unspecified
            if (text.Length == 2 || text[3] == "room")
            {
                container = player.Location;
            }
            else // text.Length == 4 // cmd with destination
            {
                string containerId = text[3];

                // identify the container
                GameObject? thing = player.Locate(containerId);
                
                // no item found
                if (thing == null) return "There is no " + containerId + " around";
                    
                // item is not container
                if (thing is not IHaveInventory) return "The " + containerId + " cannot contain anything";
                
                // the container is found
                container = (IHaveInventory)thing;
            }

            // take item away from player
            Item? item = player.Inventory.Take(itemId);

            // player does not assume the item
            if (item == null) return "You do not have a " + itemId + " in your inventory";

            // place item into container
            container.Inventory.Put(item);
            return "You placed the " + item.Name + " into the " + container.Name;
        }
    }
}
