namespace SwinAdventureTest
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        SwinAdventure.IdentifiableObject _testObj1;
        SwinAdventure.IdentifiableObject _testObj2;
        [SetUp]
        public void Setup()
        {
            _testObj1 = new SwinAdventure.IdentifiableObject(new string[] { "fred", "bob" });
            _testObj2 = new SwinAdventure.IdentifiableObject(new string[] { });
        }
        [Test]
        public void TestAreYou()
        {
            var result = _testObj1.AreYou("fred");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestNotAreYou()
        {
            var result = _testObj1.AreYou("erik");
            Assert.IsFalse(result);
        }
        [Test]
        public void TestCaseSensitive()
        {
            var result = _testObj1.AreYou("bOB");
            Assert.IsTrue(result);
        }
        [Test]
        public void TestFirstId()
        {
            string expected = "fred";
            var result = _testObj1.FirstId();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestFirstIdWithNoIds()
        {
            string expected = "";
            var result = _testObj2.FirstId();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestAddId()
        {
            _testObj1.AddIdentifier("wilma");
            bool result = _testObj1.AreYou("wilma");
            Assert.IsTrue(result);
        }
    }
}