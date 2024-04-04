using SwinAdventure;
using System.Reflection;

namespace SwinAdventureTest
{
    [TestFixture]
    public class MapTest
    {
        // class Map follows singleton design pattern
        // a map instance is created on first call
        SwinAdventure.Map map;

        [SetUp]
        public void SetUp()
        // run test one by one since map is a unique object that cannot be re-initilize
        {
            map = Map.Instance;
        }
        [Test] 
        public void TestAddLocByString()
        {
            // add new loc to map using name, desc as input
            var result = map.AddLoc("newLoc", "This the a house in VietNam");
            Assert.IsNotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(SwinAdventure.Location)));
        }
        [Test]
        public void TestAddLocByLoc()
        {
            SwinAdventure.Location loc = new SwinAdventure.Location("newLoc", "This is new location");
            // add new loc to map using the loc itself
            var result = map.AddLoc(loc);
            string expected = "Successfully add the newLoc to the map";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test] 
        public void TestAddExistLocByString()
        {
            // add duplicated loc to map by name, desc input
            var result1 = map.AddLoc("newLoc", "Add the first time");
            var result2 = map.AddLoc("newLoc", "Add this AGAIN");

            // check return obj
            Assert.IsNotNull(result1); 
            Assert.IsNull(result2);
        }
        [Test]
        public void TestAddExistLocByLoc()
        {
            SwinAdventure.Location loc = new SwinAdventure.Location("newLoc", "This is new location");
            map.AddLoc(loc);
            // add duplicate loc to map by the loc itselef
            var result = map.AddLoc(loc);
            string expected = "Location already exists in the map";
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddPath()
        {
            map.AddLoc("newLoc", "Add the first time");
            
            // add new path to map
            var mss = map.AddPath("newLoc", "default location", "north", "south", 
                "You travel by train", "You use the magical teleport");
            string expected = "Successfully create new path between newLoc and default location";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddInvalidDirPath()
        {
            map.AddLoc("newLoc", "Add the first time");

            // add path with invalid dir
            var mss = map.AddPath("newLoc", "default location", "weird", "south",
                "This path is not valid", "Since weird is not a direction");
            string expected = "Invalid directions provided";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void AddInconsistentDirPath()
        {
            map.AddLoc("newLoc", "Add the first time");

            // path with inconsistent dirs: south-north are consistent, east-up are not
            var mss = map.AddPath("newLoc", "default location", "weird", "south",
                "This path is not valid", "Since weird is not a direction");
            string expected = "Invalid directions provided";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddExistPath()
        {
            map.AddLoc("newLoc", "Add the first time");
            map.AddPath("newLoc", "default location", "north", "south",
                "You travel by train", "You use the magical teleport");
            
            // add path connecting 2 locs that has already been connected by a path
            var mss = map.AddPath("newLoc", "default location", "east", "west",
                "There is already a path", "Between these to locs");
            string expected = "Already exists a path between newLoc and default location";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddNoLocPath()
        {
            // add path connecting a loc not in map
            var mss = map.AddPath("newLoc", "default location", "east", "west",
               "This connects a location", "That is not in the map");
            string expected = "The map does not contains those locations";
            Assert.That(mss, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateLoc()
        {
            var result = map.Locate("default location");
            Assert.That(result, Is.EqualTo(map.DefaultLoc));
        }
        [Test]
        public void TestLocateNoLoc()
        {
            var result = map.Locate("some weird location");
            Assert.IsNull(result);
        }
    }
}
