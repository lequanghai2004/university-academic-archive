using System.Reflection;
using System.Security.Cryptography;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands = new List<Command>();
        private Player _player;
        public CommandProcessor(Player player)
        {
            _player = player;

            // get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                // iterate through types in assembly
                foreach (Type type in assembly.GetTypes())
                {
                    // Check if the type is a subclass of Command
                    if (type.IsSubclassOf(typeof(Command)))
                    {
                        // create instance of class
                        Command cmd = assembly.CreateInstance(type.FullName) as Command;
                        // add to cmd list
                        _commands.Add(cmd);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Issue occurs when initiating command processor: " + exc.Message);
            }
        }
        public string Execute(string text)
        {
            // check each command type and execute the one matches
            text = text.Trim().ToLower();
            string? result;
            
            foreach(Command command in _commands)
            {
                result = command.Execute(_player, text);
                if(result != null) return result;
            }
            return "Invalid command";
        }
    }
}
