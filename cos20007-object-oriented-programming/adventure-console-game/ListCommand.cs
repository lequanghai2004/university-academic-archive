namespace SwinAdventure
{
    public class ListCommand : Command
    {
        public ListCommand() : base(new string[] { @"^inv(entory)?$" })
        {

        }
        public override string Do(Player player, string[] text)
        // list the items that player is carrying.
        { 
            return new LookCommand().Do(player, new string[] { "look", "at", "me" });
        }
    }
}
