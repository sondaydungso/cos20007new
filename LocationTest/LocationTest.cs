using SwinAdventure;

namespace LocationTest
{
    public class Tests
    {
        Location _loc;
        Player _player;
        Item _item;
      

        [SetUp]
        public void Setup()
        {
            _player = new Player("player", "this is player");
            _loc = new Location(new string[] { "location" }, "myplace", "This is my place");
            _item = new Item(new string[] { "item" }, "an item", "this is an item");
            

            _player.Location = _loc;
            
            _loc.Inventory.Put(_item);
            
        }

        [Test]
        public void Locationthemslf()
        {
            
            Assert.IsTrue(_loc.AreYou("location"));
        }
        [Test]
        public void LocationHasItem()
        {
            _loc.Locate("item");
            Assert.AreEqual(_item, _loc.Locate("item"));
        }
        [Test]
        public void PlayerlocateItem()
        {
            
            Assert.AreEqual(_item, _player.Locate("item"));
           
        }
        
        
        
    }
}