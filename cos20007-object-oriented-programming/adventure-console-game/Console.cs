using SplashKitSDK;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace SwinAdventure
{
    public class GameConsole
    {
        private static Map CreateMap(string locFile, string pathFile)
        {
            Map map = Map.Instance; // with a default location
            string line; string[] fields;

            // create locs
            StreamReader locStream = new StreamReader(locFile);
            while(!locStream.EndOfStream)
            {
                line = locStream.ReadLine();
                fields = line.Split(';');
                
                try
                {
                    map.AddLoc(fields[0], fields[1]);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("The CSV file does not contain proper "
                        + "information to create the location\n" + e.Message);
                }
            }
            locStream.Close();

            // create paths
            StreamReader pathStream = new StreamReader(pathFile);
            while (!pathStream.EndOfStream)
            {
                line = pathStream.ReadLine();
                fields = line.Split(';');

                try
                {
                    map.AddPath(fields[0], fields[1], 
                        fields[2], fields[3], fields[4], fields[5]);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("The CSV file does not contain proper "
                        + "information to create the path\n" + e.Message);
                }
            }
            pathStream.Close();


            //map.AddPath("default location", "location2", "north", "south",
            //    "Using Doreamon magical door, let's go to the next level",
            //    "Via the magical bridge, again you return where all starts");
            //map.AddPath("default location", "a small Garden", "east", "west",
            //    "You travel through a small door, and then crawl a few meters before arriving from the north",
            //    "Opps, you are back to the initial location");
            //map.AddPath("location2", "a small Garden", "southeast", "northwest",
            //    "You fly across the ocean, to restore the heart of Tefiti",
            //    "You use a submarine to go underneath the ocean");


            //Item[] items = new Item[] 
            //{
            //    new Item(new string[] { "pen" }, "yellow pen", "This is a yellow pen"),
            //    new Item(new string[] { "pencil" }, "black pen", "This is a black pen"),
            //    new Item(new string[] { "scythe" }, "kagn's scythe", "This equipment is legendary"),
            //    new Item(new string[] { "bomb" }, "c4 Bomb", "Bring explosion to your enemy's surprise"),
            //    new Item(new string[] { "basketball" }, "squeezing ball", "OMG, who did this"),
            //    new Item(new string[] { "necklace" }, "Sapphire Necklace", "A beautiful necklace with a blue sapphire pendant"),
            //    new Item(new string[] { "gem" }, "Fire Ruby", "A precious gem that glows like fire"),
            //    new Item(new string[] { "scroll" }, "Scroll of Wisdom", "Contains ancient wisdom and secrets"),
            //    new Item(new string[] { "potion" }, "Invisibility Potion", "Makes you invisible for a short duration"),
            //    new Item(new string[] { "wand" }, "Wand of Lightning", "A wand that can unleash powerful lightning bolts"),
            //    new Bag(new string[] { "locbagone" }, "bag at begin location", "If you don't have one, take one"),
            //    new Bag(new string[] { "locbagtwo" }, "4 dimensional bag", "Small as bean, large as dimension!")
            //};

            //((Bag)items[10]).Inventory.Put(items[3]);
            //((Bag)items[11]).Inventory.Put(items[6]);

            //loc1.Inventory.Put(items[0]);
            //loc1.Inventory.Put(items[2]);
            //loc1.Inventory.Put(items[4]);
            
            //loc2.Inventory.Put(items[1]);
            //loc2.Inventory.Put(items[5]);
            //loc2.Inventory.Put(items[7]);
            
            //map.DefaultLoc.Inventory.Put(items[10]);
            //map.DefaultLoc.Inventory.Put(items[9]);
            //map.DefaultLoc.Inventory.Put(items[8]);

            return map;
        }
        private static Player CreatePlayer(Location loc)
        {
            string? name = null; string? desc = null;
            while (name == null || desc == null)
            {
                Console.WriteLine("Enter character name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter character description: ");
                desc = Console.ReadLine();
            }

            Player player = new Player(name, desc, loc);
            
            //Item item1 = new Item(new string[] { "sWord", "iRon" },
            //    "iRON SwoRd", "this sword is given on character creation");
            //Item item2 = new Item(new string[] { "shielD", "broKen" },
            //    "broken Shield", "this shiEld is given on character creation");
            //Item item3 = new Item(new string[] { "tShIrt", "revealing" },
            //    "tshIrt", "this piece of garment is in the bag");
            //Bag bag = new Bag(new string[] { "bAg", "smaLl" },
            //      "sMall BaG", "this is provided to player on creation");

            //player.Inventory.Put(item1);
            //player.Inventory.Put(item2);
            //player.Inventory.Put(bag);
            //bag.Inventory.Put(item3);

            return player;
        }
        private static void CreateItem(Player player, Map map, string itemFile)
        {
            StreamReader stream = new StreamReader(itemFile);
            string line; string[] fields; int i = 0;
            Exception ect = new Exception("Incorrect location or container in item.csv");
            while (!stream.EndOfStream)
            {
                line = stream.ReadLine();
                fields = line.Split(';');

                i++;
                try
                {
                    Item item = fields[0] == "item" 
                        ? new Item(new string[] { fields[1] }, fields[2], fields[3])
                        : new Bag(new string[] { fields[1] }, fields[2], fields[3]);

                    // item can be in a specific location or in player inventory
                    IHaveInventory? container = fields[4] == "player" 
                        ? player : map.Locate(fields[4]);
                    if (container == null) throw ect;

                    // item can be in another container in that location or player
                    IHaveInventory? itemContainer = fields.Count() == 5
                        ? container : container.Locate(fields[5]) as IHaveInventory;
                    if (itemContainer == null) throw ect;
                    
                    // add item to container
                    itemContainer.Inventory.Put(item);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Line " + i + ": The CSV file does not contain proper "
                        + "information to create the item\n" + e.Message);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine("Line " + i + ": Wrong value in item.csv file\n" + e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);                        
                }
            }
            stream.Close();
        }
        public static void Main()
        {
            string locFile = @"..\..\..\location.csv";
            string pathFile = @"..\..\..\path.csv";
            string itemFile = @"..\..\..\item.csv";
            try
            {
                Map map = CreateMap(locFile, pathFile);
                Player player = CreatePlayer(map.DefaultLoc);
                CreateItem(player, map, itemFile);

                CommandProcessor cmdProc = new CommandProcessor(player);
                while (true)
                {
                    Console.WriteLine("Enter a command");
                    string? cmd = Console.ReadLine();
                    if (cmd != null)
                    {
                        Console.Write(cmdProc.Execute(cmd) + "\n\n");
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("CSV file cannot be found\n" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program ends in 5 seconds");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
 