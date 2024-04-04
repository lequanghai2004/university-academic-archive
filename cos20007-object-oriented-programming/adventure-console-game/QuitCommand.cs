namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { @"^quit$" })
        {

        }
        public override string Do(Player player, string[] text)
        {
            throw new Exception("You ends the program");
        }
    }
}
