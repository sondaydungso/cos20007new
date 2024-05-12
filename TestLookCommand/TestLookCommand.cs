using SwinAdventure;

namespace TestLookCommand
{
    public class Tests
    {
        LookCommand _look;
        Player _player;
        Item _gem;
        string _gemDescription = "this is a gem";
        Bag _bag;
        [SetUp]
        public void Setup()
        {
            _player = new Player("Panzer04", "the player");
            _gem = new Item(new string[] { "gem" }, "Gem", _gemDescription);
            
            _look = new LookCommand();
            _bag = new Bag(new string[] { "bag" }, "Bag", "This is a bag");
            
        }
        
        
        [Test]
        public void TestLookAtMe()
        {
            
            Assert.AreEqual(_player.FullDescription, _look.Execute(_player, new string[] { "look", "at", "inventory" }));
        }
        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_gem);
            Assert.AreEqual(_gem.FullDescription, _look.Execute(_player, new string[] { "look", "at", "gem" }));
        }
        [Test]
        public void TestLookAtUnk()
        {
            Assert.AreEqual("I can't find the gem", _look.Execute(_player, new string[] { "look", "at", "gem" }));
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_gem);
            Assert.AreEqual(_gem.FullDescription, _look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" }));
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_gem);
            Assert.AreEqual(_gem.FullDescription, _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
        [Test]
        public void TestLookAtGemInNoBag()
        {
            Assert.AreEqual("I can't find the bag", _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);
            Assert.AreEqual("I can't find the gem", _look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
        [Test]
        public void InvalidLook()
        {
            Assert.AreEqual("I don't know how to look like that", _look.Execute(_player, new string[] { "look", "at" }));
        }
        
        

    }
}
