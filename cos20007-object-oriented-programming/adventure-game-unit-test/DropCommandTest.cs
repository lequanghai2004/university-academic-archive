namespace SwinAdventureTest
{
    [TestFixture]
    public class DropCommandTest
    {
        SwinAdventure.DropCommand _dropcmd;
        SwinAdventure.Location _loc;
        SwinAdventure.Player _player;

        SwinAdventure.Item _item;

        SwinAdventure.Bag _playerBag;
        SwinAdventure.Bag _locBag;
        [SetUp]
        public void SetUp()
        {
            _dropcmd = new SwinAdventure.DropCommand();

            _playerBag = new SwinAdventure.Bag(new string[] { "playerbAG", "SmalL" },
                "play baG", "thiS is A smaLL BAG!");
            _locBag = new SwinAdventure.Bag(new string[] { "roombAG", "SmalL" },
                "loc baG", "thiS BAG is in the room!");
            _item = new SwinAdventure.Item(new string[] { "gEm", "ruBy", "player" },
                "rubY Gem", "thiS is a ruBY gEm");

            _loc = new SwinAdventure.Location("location1", "this is default location");
            _loc.Inventory.Put(_locBag); // a bag is in the room

            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _loc);
            _player.Inventory.Put(_item); // player has an item to drop
            _player.Inventory.Put(_playerBag); // player carries a bag
        }
        private bool ContainerTakeItem(SwinAdventure.IdentifiableObject obj, string itemId)
        {
            // check if a container has an item
            SwinAdventure.IHaveInventory? container = obj as SwinAdventure.IHaveInventory;

            return container != null
                && container.Inventory.HasItem(itemId) 
                && !_player.Inventory.HasItem(itemId);
        }
        [Test]
        public void TestAreYou()
        {
            var result1 = _dropcmd.AreYou("drop paper");
            var result2 = _dropcmd.AreYou("drop paper in room");
            var result3 = _dropcmd.AreYou("put paper in bag");
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }
        [Test]
        public void TestInvalidDrop()
        {
            string cmd1 = "drop pen away"; // wrong take cmd len
            string cmd2 = "move north"; // not take cmd
            string cmd3 = "drop paper to room"; // wrong 4-word take cmd syntax

            // AreYou returns false for invalid cmd
            var result11 = _dropcmd.AreYou(cmd1);
            var result21 = _dropcmd.AreYou(cmd2);
            var result31 = _dropcmd.AreYou(cmd3);

            // Execute returns null for invalid cmd
            var result12 = _dropcmd.Execute(_player, cmd1);
            var result22 = _dropcmd.Execute(_player, cmd2);
            var result32 = _dropcmd.Execute(_player, cmd3);

            // Test results
            Assert.False(result11); Assert.IsNull(result12);
            Assert.False(result21); Assert.IsNull(result22);
            Assert.False(result31); Assert.IsNull(result32);
        }
        [Test]
        public void TestDropThing()
        {
            // 2-word cmd - drop to location
            string cmd = "drop gEm";
            
            // check return mss
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "You placed the ruby gem into the location1";
            Assert.That(mss, Is.EqualTo(expected));
            
            // check cmd effect
            Assert.IsTrue(ContainerTakeItem(_loc, "gem"));
        }
        [Test]
        public void TestDropNoThing()
        {
            // drop sth you do not have
            string cmd = "drop something";
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "You do not have a something in your inventory";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestDropThingInRoom()
        {
            // 4-word cmd with location being container
            string cmd = "DROP geM in rOOm";

            // check return mss
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "You placed the ruby gem into the location1";
            Assert.That(mss, Is.EqualTo(expected));

            // check cmd effect
            Assert.IsTrue(ContainerTakeItem(_loc, "gem"));
        }
        [Test]
        public void TestDropThingInContainer()
        {
            // 4-word cmd drop thing into a container
            string cmd = "Drop geM in roomBag";

            // check return mss
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "You placed the ruby gem into the loc bag";
            Assert.That(mss, Is.EqualTo(expected));

            // check cmd effect
            Assert.IsTrue(ContainerTakeItem(_locBag, "gem"));
        }
        [Test]
        public void TestDropNoThingInContainer()
        {
            // drop sth you do not have
            string cmd = "drop something in roombag";
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "You do not have a something in your inventory";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestDropThingInNoContainer()
        {
            // drop sth to non-existent container
            string cmd = "drop gem in yourbag";
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "There is no yourbag around";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestDropThingInNotAContainer()
        {
            SwinAdventure.Item item = new SwinAdventure.Item(
                new string[] { "vaSe" }, "bluE vase", "an item in loc1 room");
            
            // drop sth into sth that is not a container
            _loc.Inventory.Put(item);
            string cmd = "drop gem in vase";
            var mss = _dropcmd.Execute(_player, cmd);
            string expected = "The vase cannot contain anything";
            Assert.That(mss, Is.EqualTo(expected));
        }
    }
}
