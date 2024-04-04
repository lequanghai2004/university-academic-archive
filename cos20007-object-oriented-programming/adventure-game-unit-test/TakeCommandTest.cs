using SwinAdventure;
using System.ComponentModel;

namespace SwinAdventureTest
{
    [TestFixture]
    public class TakeCommandTest
    {
        SwinAdventure.TakeCommand _takecmd;
        SwinAdventure.Location _loc;
        SwinAdventure.Player _player;
        SwinAdventure.Item _locBagItem;
        SwinAdventure.Item _playerBagItem;
        SwinAdventure.Item _locItem;
        SwinAdventure.Bag _playerBag;
        SwinAdventure.Bag _locBag;
        [SetUp]
        public void SetUp()
        {
            _takecmd = new SwinAdventure.TakeCommand();
            _loc = new SwinAdventure.Location("location1", "this is default location");
            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _loc);

            _playerBag = new SwinAdventure.Bag(new string[] { "playerbAG", "SmalL" },
                "play baG", "thiS is A smaLL BAG!"); 
            _locBag = new SwinAdventure.Bag(new string[] { "roombAG", "SmalL" },
                "loc baG", "thiS BAG is in the room!");

            _playerBagItem = new SwinAdventure.Item(new string[] { "ruby", "ruBy", "player" },
                "rubY Gem", "thiS is a ruBY gEm in player's bag!");
            _locBagItem = new SwinAdventure.Item(new string[] { "sapphire", "ruBy", "bag" },
                "SAPphire Gem", "thiS is a ruBY gEm in the room's bag!");
            _locItem = new SwinAdventure.Item(new string[] { "ball", "black" },
                "bLack ball", "This ball is in The roOM");

            _player.Inventory.Put(_playerBag); // player carries a bag
            _playerBag.Inventory.Put(_playerBagItem); // the bag contains an item

            _loc.Inventory.Put(_locBag); // a bag is in the room
            _locBag.Inventory.Put(_locBagItem); // the bag contains an item
            _loc.Inventory.Put(_locItem); // another item is in the room
        }
        private bool NothingChange()
        {
            return _player.Inventory.HasItem("playerBag")
                && _loc.Inventory.HasItem("Ball")
                && _loc.Inventory.HasItem("ROOmbag")

                && _playerBag.Inventory.HasItem("ruBy")
                && _locBag.Inventory.HasItem("saPPhire");
        }
        [Test]
        public void TestAreYou()
        {
            var result1 = _takecmd.AreYou("pickup paper");
            var result2 = _takecmd.AreYou("pickup paper from room");
            var result3 = _takecmd.AreYou("take paper");
            var result4 = _takecmd.AreYou("take paper from bag");
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.True);
            Assert.That(result4, Is.True);
        }
        [Test]
        public void TestInvalidTake()
        {
            string cmd1 = "take a break"; // wrong take cmd len
            string cmd2 = "move north"; // not take cmd
            string cmd3 = "take paper in room"; // wrong 4-word take cmd syntax

            // AreYou returns false for invalid cmd
            var result11 = _takecmd.AreYou(cmd1);
            var result21 = _takecmd.AreYou(cmd2);
            var result31 = _takecmd.AreYou(cmd3);

            // Execute returns null for invalid cmd
            var result12 = _takecmd.Execute(_player, cmd1);
            var result22 = _takecmd.Execute(_player, cmd2);
            var result32 = _takecmd.Execute(_player, cmd3);

            // Test results
            Assert.False(result11); Assert.IsNull(result12);
            Assert.False(result21); Assert.IsNull(result22);
            Assert.False(result31); Assert.IsNull(result32);
        }
        [Test]
        public void TestTakeThing()
        {
            // 2-word take cmd - take from location
            string cmd = "Take balL";

            // check return mss
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "You have taken a black ball";
            Assert.That(mss, Is.EqualTo(expected));

            // check cmd effect on loc
            bool locHasItem = _loc.Inventory.HasItem("baLl");
            Assert.IsFalse(locHasItem); // item in loc is taken away

            // check cmd effect on player
            bool playerHasItem = _player.Inventory.HasItem("BalL");
            Assert.IsTrue(playerHasItem); // player possesses item
        }
        [Test]
        public void TestTakeNoThing()
        {
            // 2-word take cmd with non-existent thing
            string cmd = "take money";
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "There is no money in the location1";
            Assert.That(mss, Is.EqualTo(expected));
            Assert.IsTrue(NothingChange());
        }
        [Test]
        public void TestTakeThingFromRoom()
        {
            // 4-word take cmd with container=room - result is similar to 2-word cmd
            string cmd = "taKe Ball From rOom";

            // check return mss
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "You have taken a black ball";
            Assert.That(mss, Is.EqualTo(expected));

            // check cmd effect on loc
            bool locHasItem = _loc.Inventory.HasItem("ball");
            Assert.IsFalse(locHasItem);

            // check cmd effect on player
            bool playerHasItem = _player.Inventory.HasItem("bAll");
            Assert.IsTrue(playerHasItem);
        }
        [Test]
        public void TestTakeNoThingFromRoom()
        {
            // take sth not in location
            string cmd = "taKe money from room";
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "There is no money in the location1";
            Assert.That(mss, Is.EqualTo(expected));
            Assert.IsTrue(NothingChange());
        }
        [Test]
        public void TestTakeThingFromContainer()
        {
            // 4-word take cmd with container!=room
            string cmd = "taKe sapPhire From roomBAG";

            // check return mss
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "You have taken a sapphire gem";
            Assert.That(mss, Is.EqualTo(expected));

            // check cmd effect on container
            bool containerHasItem = _locBag.Inventory.HasItem("sappHire");
            Assert.IsFalse(containerHasItem);

            // check cmd effect on player
            bool playerHasItem = _player.Inventory.HasItem("sapphIRE");
            Assert.IsTrue(playerHasItem);
        }
        [Test]
        public void TestTakeNoThingFromContainer()
        {
            // take sth not in specified container
            string cmd = "taKe money from playerbag";
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "There is no money in the play bag";
            Assert.That(mss, Is.EqualTo(expected));
            Assert.IsTrue(NothingChange());
        }
        [Test]
        public void TestTakeThingFromNoContainer()
        {
            // take sth from non-existent container
            string cmd = "taKe ball from mybag";
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "There is no mybag around";
            Assert.That(mss, Is.EqualTo(expected));
            Assert.IsTrue(NothingChange());
        }
        [Test]
        public void TestTakeThingFromNotAContainer()
        {
            // take sth from an item that does not have inventory
            string cmd = "taKe thing from ball";
            var mss = _takecmd.Execute(_player, cmd);
            string expected = "The ball does not contain anything";
            Assert.That(mss, Is.EqualTo(expected));
            Assert.IsTrue(NothingChange());
        }
    }
}
