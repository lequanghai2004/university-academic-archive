using SwinAdventure;
using System.Diagnostics.CodeAnalysis;

namespace SwinAdventureTest
{
    [TestFixture]
    public class LocationTest
    {
        SwinAdventure.Location _currentLoc;
        SwinAdventure.Location _nextLoc;
        SwinAdventure.Path _path;
        SwinAdventure.Item _item;
        [SetUp] 
        public void SetUp()
        {
            _currentLoc = new SwinAdventure.Location("VieNam", "this is the default location");
            _nextLoc = new SwinAdventure.Location("ChiNa", "this is the next door location");
            
            _path = new SwinAdventure.Path(_currentLoc, _nextLoc, 
                "Go Chnia", "Go VieNam", "northeast", "southwest");
            _item = new SwinAdventure.Item(new string[] { "swORd", "FrEd" },
                "bronZe swOrd", "thiS is A bronze sword!");
            _currentLoc.Inventory.Put(_item);
        }
        [Test]
        public void TestIsIdentifiable()
        {
            var result = _currentLoc.AreYou("location");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestAddRemovePath()
        {
            // this process should only be performed by the 'Map' class
            _currentLoc.AddPath("northeast", _path);
            
            // remove the path from loc
            var result = _currentLoc.RemovePath("northeast");
            string expected = "Successfully remove the path to northeast";

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestRemoveNoPath()
        {
            // remove path from a dir with no path
            var result = _currentLoc.RemovePath("north");
            string expected = "There is no path to go north";
        
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestRemovePathInvalidDir()
        {
            // remove path from an invalid dir
            var result = _currentLoc.RemovePath("some invalid dir");
            string expected = "There is no path to go some invalid dir";

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateItem()
        {
            Item expected = _item;
            var result = _currentLoc.Locate("sWorD");
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateNoItem()
        {
            var result = _currentLoc.Locate("non-existent thing");
            Assert.IsNull(result);
        }
        [Test]
        public void TestFullDescription()
        {
            string expected = "You are in VieNam\nthis is the default location"
                + "\nThere are exits to the northeast"
                + "\nIn this room you can see:\n\t"
                + "a bronze sword (sword)\n\t";
            var result = _currentLoc.FullDescription;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestTravel()
        {
            _currentLoc.AddPath("nortHeasT", _path);

            // test if loc could return path from specified dir
            var result = _currentLoc.Travel("northEasT");
            Assert.That(result, Is.EqualTo(_path));
        }
        public void TestTravelInvalidDir()
        {
            // travel with invalid dir returns null
            var result = _currentLoc.Travel("rediculousDir");
            Assert.IsNull(result);
        }
        public void TestTravelNoWhere()
        {
            // loc has no path to go up, travel returns null
            var result = _currentLoc.Travel("up");
            Assert.IsNull(result);
        }
    }
}
