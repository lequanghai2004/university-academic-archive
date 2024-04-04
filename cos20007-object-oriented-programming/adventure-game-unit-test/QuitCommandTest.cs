namespace SwinAdventureTest
{
    [TestFixture]
    public class QuitCommandTest
    {
        SwinAdventure.QuitCommand _quitcmd;
        SwinAdventure.Player _player;
        [SetUp]
        public void SetUp()
        {
            _quitcmd = new SwinAdventure.QuitCommand();
            _player = new SwinAdventure.Player("name", "desc", new SwinAdventure.Location("locName", "locDesc"));
        }
        [Test]
        public void TestAreYou()
        {
            var result = _quitcmd.AreYou("quit");
            Assert.That(result, Is.True);
        }
        [Test]
        public void TestInvalidCmd()
        {
            string cmd1 = "do not quit"; // wrong syntax
            string cmd2 = "move south"; // not a quit cmd

            Assert.IsNull(_quitcmd.Execute(_player, cmd1));
            Assert.IsNull(_quitcmd.Execute(_player, cmd2));

            Assert.IsFalse(_quitcmd.AreYou(cmd1));
            Assert.IsFalse(_quitcmd.AreYou(cmd2));
        }
        [Test]
        public void TestQuit()
        {
            Assert.Throws<Exception>(() => _quitcmd.Execute(_player, "quiT"));
        }
    }
}
