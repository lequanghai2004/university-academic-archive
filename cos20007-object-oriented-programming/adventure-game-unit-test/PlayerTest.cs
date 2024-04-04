using SwinAdventure;

namespace SwinAdventureTest
{
    [TestFixture]
    public class PlayerTest
    {
        SwinAdventure.Player _player;
        SwinAdventure.Item _item1;
        SwinAdventure.Item _item2;
        SwinAdventure.Item _item3;
        SwinAdventure.Location _loc1;
        SwinAdventure.Location _loc2;
        SwinAdventure.Path _path;
        [SetUp]
        public void SetUp()
        {
            _loc1 = new SwinAdventure.Location("location1", "this is the default map");
            _loc2 = new SwinAdventure.Location("location2", "hooray! welcome to level 2");
            _path = new SwinAdventure.Path(_loc1, _loc2, "desc1", "desc2", "east", "west");

            _item1 = new SwinAdventure.Item(new string[] { "swORd", "FrEd" },
                "bronZe swOrd", "thiS is A bronze sword!");
            _item2 = new SwinAdventure.Item(new string[] { "gUn", "bOb" },
                "YeLLoW guN", "thiS is A yElLow Gun!");
            _item3 = new SwinAdventure.Item(new string[] { "SuiT", "HaI" },
                "WhiTE sUIt", "thiS is A whITe suiT!");
            
            _player = new SwinAdventure.Player("Erik Le", "COS20007 lecturer", _loc1);
        }
        [Test]
        public void TestIsIdentifiable()
        {
            var result = _player.AreYou("me");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestLocateFromInventory()
        {
            _player.Inventory.Put(_item1);

            // item1 should now be located by player
            Item expected = _item1;
            var result1 = _player.Locate("SwoRd");

            Assert.That(result1, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateItself()
        {
            // player should be able to located themselves
            Player expected = _player;
            var result = _player.Locate("me");

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateFromLocation()
        {
            _loc1.Inventory.Put(_item3);

            // player should be able to locate item at current location
            Item expected = _item3;
            var result = _player.Locate("sUIt");

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateNothing()
        {
            var result = _player.Locate("non-existent thing");
            Assert.IsNull(result);
        }
        [Test]
        public void TestFullDescription()
        {
            _player.Inventory.Put(_item1);
            _player.Inventory.Put(_item2);

            string expected = "You are Erik Le, COS20007 lecturer. You are carrying:\n\t" +
                "a bronze sword (sword)\n\t" +
                "a yellow gun (gun)\n\t";
            var result = _player.FullDescription;

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestTravel()
        {
            // before travel 
            var result1 = _player.Location;
            Assert.That(result1, Is.EqualTo(_loc1));

            // travel loc1 -> loc2
            string message = _player.Travel("east");
            string expected = "You head East"
                + "\ndesc1"
                + "\nYou have arrived in location2";
            Assert.That(message, Is.EqualTo(expected));

            // after travel
            var result2 = _player.Location;
            Assert.That(result2, Is.EqualTo(_loc2));
        }
        [Test]
        public void TestTravelInvalidDirection()
        {
            // 'school' is not a direction
            string expected = "There is no valid path to go school";
            var result = _player.Travel("school");

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestTravelNoPath()
        {
            // there is only path to go north, and none to go up
            string expected = "There is no valid path to go up";
            var result = _player.Travel("up");

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
