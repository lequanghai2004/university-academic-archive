namespace SwinAdventureTest
{
    [TestFixture]
    public class LookCommandTest
    {
        SwinAdventure.Player _player;
        SwinAdventure.LookCommand _lookcmd;
        SwinAdventure.Bag _bag;
        SwinAdventure.Item _item1;
        SwinAdventure.Item _item2;
        SwinAdventure.Location _location;
        [SetUp]
        public void SetUp()
        {
            _location = new SwinAdventure.Location("location1", "this is default location");
            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _location);
            _lookcmd = new SwinAdventure.LookCommand();

            _bag = new SwinAdventure.Bag(new string[] { "bAG", "SmalL" },
                "SMAll baG", "thiS is A smaLL BAG!");
            _item1 = new SwinAdventure.Item(new string[] { "gEm", "ruBy", "player" },
                "rubY Gem", "thiS is a ruBY gEm in player inventory!");
            _item2 = new SwinAdventure.Item(new string[] { "gEm", "ruBy", "bag" },
                "rubY Gem", "thiS is a ruBY gEm in the bag!");

            _player.Inventory.Put(_item1);
        }
        [Test]
        public void TestAreYou()
        {
            var result1 = _lookcmd.AreYou("look");
            var result2 = _lookcmd.AreYou("look at something");
            var result3 = _lookcmd.AreYou("look at something in container");
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }
        [Test]
        public void TestLookAtMe()
        {
            string cmd = "look at iNventory";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "You are Erik Le, lecturer at SwinBuRnE. You are carrying:\n\t" 
                + "a ruby gem (gem)\n\t";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtGem()
        {
            string cmd = "loOk at gEm";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "thiS is a ruBY gEm in player inventory!";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestLookAtUnknown()
        {
            string cmd = "loOk at weIrdo";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "I cannot find the weirdo";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            string cmd = "look aT Gem in inventory"; 
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "thiS is a ruBY gEm in player inventory!";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            _bag.Inventory.Put(_item2);
            _player.Inventory.Put(_bag);

            string cmd = "look aT gem In bag";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "thiS is a ruBY gEm in the bag!";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtGemInNoBag()
        {
            _bag.Inventory.Put(_item2);

            string cmd = "look at gEM in bAG";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "I cannot find the bag";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);

            string cmd = "LOok at gem in bag";
            var result = _lookcmd.Execute(_player, cmd);
            string expected = "I cannot find the gem in the small bag";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestInvalidLook()
        {
            string cmd1 = "look around here"; // wrong 3-word look cmd syntax
            string cmd2 = "move north"; // not look cmd
            string cmd3 = "look at a and b"; // wrong 5-word look cmd syntax

            // AreYou returns false for invalid cmd
            var result11 = _lookcmd.AreYou(cmd1);
            var result21 = _lookcmd.AreYou(cmd2);
            var result31 = _lookcmd.AreYou(cmd3);
            
            // Execute returns null for invalid cmd
            var result12 = _lookcmd.Execute(_player, cmd1);
            var result22 = _lookcmd.Execute(_player, cmd2);
            var result32 = _lookcmd.Execute(_player, cmd3);
            
            // Test results
            Assert.False(result11); Assert.IsNull(result12);
            Assert.False(result21); Assert.IsNull(result22);
            Assert.False(result31); Assert.IsNull(result32);
        }
        [Test]
        public void TestLook()
        {
            SwinAdventure.Location anotherLoc 
                = new SwinAdventure.Location("location2", "yet another location");
            SwinAdventure.Path path
                = new SwinAdventure.Path(_location, anotherLoc, "desc1", "desc2", "north", "south");
            
            _location.Inventory.Put(_bag);
            _location.Inventory.Put(_item1);

            string expected = "You are in location1"
                + "\nthis is default location"
                + "\nThere are exits to the north"
                + "\nIn this room you can see:\n\t"
                + "a small bag (bag)\n\t"
                + "a ruby gem (gem)\n\t";
            var result = _lookcmd.Execute(_player, "lOok");
            Assert.AreEqual(expected, result);
        }
    }
}
