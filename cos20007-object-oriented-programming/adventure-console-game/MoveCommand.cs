namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { 
            $@"^(move|go|head|leave) ({string.Join("|", Enum.GetNames(typeof(Direction)))})$" })
        {

        }
        public override string Do(Player player, string[] text)
        // text[0] is either move/go/head/leave + text[1] is a valid direction
        // exp: move north, leave southeast, go down, head west
        {
            return player.Travel(text[1]); 
            // player has a machanism to validate the direction provided
        }
    }
}
