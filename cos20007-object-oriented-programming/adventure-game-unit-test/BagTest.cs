using SwinAdventure;
using System.Diagnostics.CodeAnalysis;

namespace SwinAdventureTest
{
    [TestFixture]
    public class BagTest
    {
        SwinAdventure.Item _item1;
        SwinAdventure.Item _item2;
        SwinAdventure.Item _item3;
        SwinAdventure.Bag _bag;
        SwinAdventure.Bag _anotherBag;
        [SetUp]
        public void SetUp()
        {
            _item1 = new SwinAdventure.Item(new string[] { "swORd", "FrEd" },
                "bronZe swOrd", "thiS is A bronze sword!");
            _item2 = new SwinAdventure.Item(new string[] { "gUn", "bOb" },
                "YeLLoW guN", "thiS is A yElLow Gun!");
            _item3 = new SwinAdventure.Item(new string[] { "SuiT", "HaI" },
                "WhiTE sUIt", "thiS is A whITe suiT!");

            _bag = new SwinAdventure.Bag(new string[] { "bAg", "smaLl" }, 
                "sMall BaG", "A small brown leather bag");
            _bag.Inventory.Put(_item1);
            _bag.Inventory.Put(_item2);

            _anotherBag = new SwinAdventure.Bag(new string[] {"neW BaG", "tINY"},
                "TiNy Bag", "resides IN the bAg");
            _bag.Inventory.Put(_anotherBag);
            _anotherBag.Inventory.Put(_item3);
        }
        [Test]
        public void TestLocateItem()
        {
            SwinAdventure.Item expected = _item1;
            var result = _bag.Locate("sWoRD");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestLocateSelf()
        {
            SwinAdventure.Bag expected = _bag;
            var result = _bag.Locate("baG");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestLocateNothing()
        {
            var result = _bag.Locate("nothing");
            Assert.IsNull(result);
        }
        [Test]
        public void TestFullDescription()
        {
            string expected = "A small brown leather bag"
                + "\nIn the small bag you can see:"
                + "\n\ta bronze sword (sword)"
                + "\n\ta yellow gun (gun)"
                + "\n\ta tiny bag (new bag)\n\t";
            var result = _bag.FullDescription;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestBagInBag()
        {
            var result1 = _bag.Locate("nEw Bag");
            Assert.AreEqual(_anotherBag, result1);

            var result2 = _bag.Locate("hAI");
            Assert.IsNull(result2);
        }
    }
}
