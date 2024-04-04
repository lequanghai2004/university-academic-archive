namespace SwinAdventureTest
{
    [TestFixture]
    public class MoveCommandTest
    {
        SwinAdventure.Player _player;
        SwinAdventure.Location _location1;
        SwinAdventure.Location _location2;
        SwinAdventure.Path _path;
        SwinAdventure.MoveCommand _movecmd;
        [SetUp]
        public void SetUp()
        {
            _movecmd = new SwinAdventure.MoveCommand();
            _location1 = new SwinAdventure.Location("location1", "This is default location");
            _location2 = new SwinAdventure.Location("a small Garden", "Hooray! welcome to leveL2");
            _path = new SwinAdventure.Path(_location1, _location2, 
                "You travel through a small door, and then crawl a few meters before arriving from the north", "Opps, you are back to the initial location", "north", "south");
            _player = new SwinAdventure.Player("Erik lE", "lecturer at SwinBuRnE", _location1);
        }
        [Test]
        public void TestAreYou()
        {
            var result1 = _movecmd.AreYou("leave north");
            var result2 = _movecmd.AreYou("go up");
            var result3 = _movecmd.AreYou("head southeast");
            var result4 = _movecmd.AreYou("move west");
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.True);
            Assert.That(result4, Is.True);
        }
        [Test]
        public void TestExe()
        {
            string[] cmds = new string[] { // loc1->loc2, or mss1
                "move north",
                "go south",
                "leave north",
                "head south"};

            string[] expected = new string[] { // loc2->loc1, or mss2
                "You head North"
                + "\nYou travel through a small door, and then crawl a few meters before arriving from the north"
                + "\nYou have arrived in a small Garden",
                "You head South"
                + "\nOpps, you are back to the initial location"
                + "\nYou have arrived in location1"};

            var result1 = _movecmd.Execute(_player, cmds[0]); // loc1 -> loc2
            Assert.That(result1, Is.EqualTo(expected[0]));
            Assert.That(_player.Location, Is.EqualTo(_location2));

            var result2 = _movecmd.Execute(_player, cmds[1]); // loc2 -> loc1
            Assert.That(result2, Is.EqualTo(expected[1]));
            Assert.That(_player.Location, Is.EqualTo(_location1));

            var result3 = _movecmd.Execute(_player, cmds[2]); // loc1 -> loc2
            Assert.That(result3, Is.EqualTo(expected[0]));
            Assert.That(_player.Location, Is.EqualTo(_location2));

            var result4 = _movecmd.Execute(_player, cmds[3]); // loc2 -> loc1
            Assert.That(result4, Is.EqualTo(expected[1]));
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
        [Test]
        public void TestInvalidLen()
        {
            // Execute returns null for not move cmd
            string cmd = "move north now";
            var result = _movecmd.Execute(_player, cmd);
            Assert.IsNull(result);
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
        [Test]
        public void TestNotMoveCmd()
        {
            // Execute returns null for not move cmd
            string cmd = "look north";
            var result = _movecmd.Execute(_player, cmd);
            Assert.IsNull(result);
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
        [Test]
        public void TestInvalidDir()
        {
            // move cmd must have a dir
            string cmd = "go home";
            var result = _movecmd.Execute(_player, cmd);
            Assert.IsNull(result);
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
        [Test]
        public void TestNoPath()
        {
            // cmd -> player -> location -> no path found
            _player.Location = _location1;
            string cmd = "go south";
            var result = _movecmd.Execute(_player, cmd);
            string expected = "There is no valid path to go south";
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(_player.Location, Is.EqualTo(_location1));
        }
    }
}
