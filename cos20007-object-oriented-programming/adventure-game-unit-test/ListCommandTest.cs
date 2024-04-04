namespace SwinAdventureTest
{
    [TestFixture]
    public class ListCommandTest
    {
        SwinAdventure.ListCommand _listcmd;
        SwinAdventure.Player _player;
        SwinAdventure.Location _loc;
        SwinAdventure.Item _item1;
        [SetUp] 
        public void SetUp()
        {
            _listcmd = new SwinAdventure.ListCommand();
            _loc = new SwinAdventure.Location("location1", "this is default location");
            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _loc);

            _item1 = new SwinAdventure.Item(new string[] { "gEm", "ruBy", "player" },
                "rubY Gem", "thiS is a ruBY gEm in player inventory!");
            _player.Inventory.Put(_item1);
        }
        [Test]
        public void TestAreYou()
        {
            var result1 = _listcmd.AreYou("inv");
            var result2 = _listcmd.AreYou("inventory");
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }
        [Test]
        public void TestInvalidCmd()
        {
            string cmd1 = "inventory me"; // wrong cmd len
            string cmd2 = "move north"; // not take cmd

            // AreYou returns false for invalid cmd
            var result11 = _listcmd.AreYou(cmd1);
            var result21 = _listcmd.AreYou(cmd2);

            // Execute returns null for invalid cmd
            var result12 = _listcmd.Execute(_player, cmd1);
            var result22 = _listcmd.Execute(_player, cmd2);
           
            // Test results
            Assert.False(result11); Assert.IsNull(result12);
            Assert.False(result21); Assert.IsNull(result22);
        }
        [Test]
        public void TestExe()
        {
            var result = _listcmd.Execute(_player, "inv");
            string expected = "You are Erik Le, lecturer at SwinBuRnE. You are carrying:\n\t"
                + "a ruby gem (gem)\n\t";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
