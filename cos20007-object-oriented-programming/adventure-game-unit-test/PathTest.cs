using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace SwinAdventureTest
{
    [TestFixture]
    public class PathTest
    {
        SwinAdventure.Path _path;
        SwinAdventure.Location _loc1;
        SwinAdventure.Location _loc2;
        SwinAdventure.Location _loc3;
        SwinAdventure.Player _player;
        [SetUp]
        public void SetUp()
        {
            string desc1 = "You travel through a small door, and then crawl a few meters before arriving from the north";
            string desc2 = "You GO thRough the South dOOr";

            _loc1 = new SwinAdventure.Location("location1", "this is the default map");
            _loc2 = new SwinAdventure.Location("location2", "hooray! welcome to level 2");
            _path = new SwinAdventure.Path(_loc1, _loc2, desc1, desc2, "north", "south");
            
            _loc3 = new SwinAdventure.Location("location3", "this is not the loc the path connects");
            _player = new SwinAdventure.Player("ErIk Le", "swinBurne lecturer", _loc1);
        }
        [Test]
        public void TestIsIdentifiable()
        {
            var result = _path.AreYou("north") && _path.AreYou("south");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestConnectLocs()
        {
            // path should connects loc1 and loc2
            Assert.IsTrue(_path.ConnectLocs(_loc1, _loc2));
        }
        [Test]
        public void TestNotConnectLocs()
        {
            // path does not connect the 2 locs
            Assert.IsFalse(_path.ConnectLocs(_loc1, _loc3));
        }
        [Test]
        public void TestFullDescription()
        {
            string expected = "You head North"
            + "\nYou travel through a small door, and then crawl a few meters before arriving from the north"
            + "\nYou have arrived in location2";
            var result = _path.FullDescription(0);

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestOtherLoc()
        {
            // path has 2 locs: put in 1 loc to obtain the other loc
            var result1 = _path.OtherLoc(_loc1);
            Assert.That(_loc2, Is.EqualTo(result1));
            
            var result2 = _path.OtherLoc(_loc2);
            Assert.That(_loc1, Is.EqualTo(result2));
        }
        [Test]
        public void TestInvalidOtherLoc()
        {
            // location put in is not one of the path's locs the OtherLocs returns itself
            SwinAdventure.Location expected = _loc3;
            var result = _path.OtherLoc(_loc3);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestMovePlayer()
        {
            // travel mss
            string expected = "You head North"
                + "\nYou travel through a small door, and then crawl a few meters before arriving from the north"
                + "\nYou have arrived in location2";
            var result = _path.Travel(_player);
            Assert.That(result, Is.EqualTo(expected));

            // after travel 
            Assert.That(_player.Location, Is.EqualTo(_loc2));
        }
        [Test]
        public void TestMoveNotOnPathPlayer()
        {
            // player cannot use path connecting loc1 and loc2 when in loc3 
            _player.Location = _loc3;
            string expected = "Cannot use this path";
            var result = _path.Travel(_player);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
