using System.ComponentModel;
using System.Numerics;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { @"^(pickup|take) [a-z]+( from [a-z]+)?$" })
        {

        }
        public override string Do(Player player, string[] text)
        // allows the player to pick something up from the room, or other containers.
        // exp: pickup paper (from room), take paper (from bag)
        {
            Location loc = player.Location;
            string itemId = text[1];
            IHaveInventory container;

            if (text.Length == 2 || text[3] == "room") // put sth back to the loc
            {
                container = loc;
            }
            else // text.Length == 4 // put sth in player inventory
            {
                string containerId = text[3];

                // identify the container
                GameObject? thing = player.Locate(containerId);
                
                // no item found
                if (thing == null) return "There is no " + containerId + " around" ;

                // item is not a container
                if(thing is not IHaveInventory) return "The " + containerId + " does not contain anything";
                
                // the container is found
                container = (IHaveInventory)thing;
            }
            
            // remove item from container
            Item? item = container.Inventory.Take(itemId);
            
            // no item in container
            if (item == null) return "There is no " + itemId + " in the " + container.Name;

            // move that item to player inventory
            player.Inventory.Put(item);
            return "You have taken a " + item.Name;
        }
    }
}
