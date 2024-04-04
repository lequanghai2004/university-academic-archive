namespace SwinAdventureTest
{
    [TestFixture]
    public class InventoryTest
    {
        SwinAdventure.Inventory _inventory;
        SwinAdventure.Item _item1;
        SwinAdventure.Item _item2;
        SwinAdventure.Item _item3;
        [SetUp]
        public void SetUp()
        {
            _inventory = new SwinAdventure.Inventory();

            _item1 = new SwinAdventure.Item(new string[] { "swORd", "FrEd" },
                "bronZe swOrd", "thiS is A bronze sword!");
            _item2 = new SwinAdventure.Item(new string[] { "gUn", "bOb" },
                "YeLLoW guN", "thiS is A yElLow Gun!");
            _item3 = new SwinAdventure.Item(new string[] { "SuiT", "HaI" },
                "WhiTE sUIt", "thiS is A whITe suiT!");

            _inventory.Put(_item1);
            _inventory.Put(_item2);
            _inventory.Put(_item3);
        }
        [Test]
        public void TestFindItem()
        {
            bool result = _inventory.HasItem("sWord");
            Assert.True(result);
        }
        [Test]
        public void TestNoItemFound()
        {
            bool result = _inventory.HasItem("wibu");
            Assert.IsFalse(result);
        }
        [Test]
        public void TestFetchItem()
        {
            SwinAdventure.Item expected = _item1;
            var result = _inventory.Fetch("sworD");
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestTakeItem()
        {
            SwinAdventure.Item expected = _item1;
            var result1 = _inventory.Take("sworD");
            Assert.AreEqual(expected, result1);

            var result2 = _inventory.HasItem("sworD");
            Assert.IsFalse(result2);
        }
        [Test]
        public void TestItemList()
        {
            string expected = "\ta bronze sword (sword)\n\t"
                + "a yellow gun (gun)\n\t"
                + "a white suit (suit)\n\t";
            var result = _inventory.ItemList;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestEmptyItemList()
        {
            // remove all item
            _inventory.Take("sword");
            _inventory.Take("suit");
            _inventory.Take("gun");

            // check mss when all items is taken away from inventory
            string expected = "There is nothing in here";
            var result = _inventory.ItemList;
            Assert.AreEqual(expected, result);
        }
    }
}
