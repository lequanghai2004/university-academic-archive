using SwinAdventure;

namespace SwinAdventureTest
{
    [TestFixture]
    public class CmdProcTest
    {
        private SwinAdventure.CommandProcessor _cmdProc;
        private SwinAdventure.Player _player;
        private SwinAdventure.Location _location1;
        [SetUp]
        public void SetUp()
        {
            _location1 = new SwinAdventure.Location("location1", "This is default location");
            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _location1);
            _cmdProc = new SwinAdventure.CommandProcessor(_player);

            _player.Inventory.Put(new SwinAdventure.Item(new string[] { "ruby", "ruBy", "player" },
                "rubY Gem", "thiS is a ruBY gEm in player's bag!"));
        }
        [Test]
        public void TestNotCmd()
        {
            string cmd1 = "inventory me";
            string cmd2 = "took a break";
            string cmd3 = "exit";

            var result1 = _cmdProc.Execute(cmd1);
            var result2 = _cmdProc.Execute(cmd2);
            var result3 = _cmdProc.Execute(cmd3);

            string expected = "Invalid command";
            Assert.That(result1, Is.EqualTo(expected));
            Assert.That(result2, Is.EqualTo(expected));
            Assert.That(result3, Is.EqualTo(expected));
        }
        [Test]
        public void TestInvalidCmd()
        {
            string cmd = "go hOme";
            var result = _cmdProc.Execute(cmd);
            string expected = "Invalid command";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestFailedCmd()
        {
            string cmd1 = "move north";
            var result1 = _cmdProc.Execute(cmd1);
            string expected1 = "There is no valid path to go north";

            string cmd2 = "put paper";
            var result2 = _cmdProc.Execute(cmd2);
            string expected2 = "You do not have a paper in your inventory";

            Assert.That(result1, Is.EqualTo(expected1));
            Assert.That(result2, Is.EqualTo(expected2));
        }
        [Test]
        public void TestExeCmd()
        {
            var mss2 = _cmdProc.Execute("look at me");
            string expected2 = "You are Erik Le, lecturer at SwinBuRnE. You are carrying:\n\t"
                + "a ruby gem (ruby)\n\t";
            Assert.That(mss2, Is.EqualTo(expected2));

            var mss1 = _cmdProc.Execute("drop ruBy");
            string expected1 = "You placed the ruby gem into the location1";
            Assert.That(mss1, Is.EqualTo(expected1));
        }
    }
}
