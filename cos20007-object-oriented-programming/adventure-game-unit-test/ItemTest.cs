namespace SwinAdventureTest
{
    [TestFixture]
    public class ItemTest
    {
        SwinAdventure.Item _item;
        [SetUp]
        public void SetUp()
        {
            string name = "broNze Sword";
            string desc = "fUll desC";
            string[] idents = {"swORd", "FrEd"};
            _item = new SwinAdventure.Item(idents, name, desc);
        }
        [Test]
        public void TestIsIdentifiable() 
        {
            var result = _item.AreYou("sWorD");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestShortDescription() 
        {
            string expected = "a bronze sword (sword)";
            var result = _item.ShortDescription;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestFullDescription()
        {
            string expected = "fUll desC";
            var result = _item.FullDescription;
            Assert.AreEqual(expected, result);
        }
    }
}
