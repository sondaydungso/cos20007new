using SwinAdventure;


namespace PathTest
{
    public class Tests
    {
        Player _player;
        Location _loc1, _loc2;
        SwinAdventure.Path _path;

        [SetUp]
        public void Setup()
        {
            _player = new Player("player", "this is player");
            _loc1 = new Location(new string[] { "location" }, "myplace", "This is my place");
            _loc2 = new Location(new string[] { "location" }, "myplace", "This is my place");
            _path = new SwinAdventure.Path(new string[] { "south" }, "Path", "This is a path", _loc1, _loc2);
            _loc1.AddPath(_path);
            _player.Location = _loc1;
        }

        [Test]
        public void PathDestination()
        {
            Assert.AreEqual(_loc2, _path.Destination);
        }
        [Test]
        public void PathSource()
        {
            Assert.AreEqual(_loc1, _path.Source);
        }
        [Test]
        public void PlayerMove()
        {
            _player.Move(_path);
            Assert.AreEqual(_loc2, _player.Location);
        }
        [Test]
        public void PathLocate() 
        {
            _loc1.Locate("south");
            Assert.AreEqual(_path, _loc1.Locate("south"));
        }


    }
}