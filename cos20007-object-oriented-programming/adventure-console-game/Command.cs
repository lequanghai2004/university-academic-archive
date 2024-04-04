using SplashKitSDK;
using System.Text.RegularExpressions;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids) { }
        public override bool AreYou(string text)
        {
            // the cmd pattern is the first identifier
            Regex pattern = new Regex(FirstId());
            return pattern.IsMatch(text);
        }
        public string? Execute(Player player, string text)
        {
            text = text.ToLower().Trim();
            if(AreYou(text))
            {
                string[] cmd = text.Split(' ');
                return Do(player, cmd);
            }
            return null;
        }
        public abstract string Do(Player player, string[] text);
    }
}
