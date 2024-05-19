using SwinAdventure;

namespace LookCommandPro
{
    public class Tests
    {
        Command c = new CommandProcessor();
        Player p = new Player("tson", "the player");
        Bag bag = new Bag(new string[] { "bag" }, "bag", "this is a bag");
        Location l = new Location(new string[] { "start" }, "start", "this is the start");
        Location l2 = new Location(new string[] { "south" }, "south", "this is the south");
        Item item = new Item(new string[] { "item" }, "item", "this is an item");
       
        SwinAdventure.Path path;
        [SetUp]
        public void Setup()
        {
            path = new SwinAdventure.Path(new string[] { "south" }, "door", "this is a door", l, l2);
            p.Location = l;
            l.AddPath(path);
            l.Inventory.Put(item);
        }

        [Test]
        public void Test1()
        {
            p.Inventory.Put(bag);
            string input = "look at bag";
            c.Execute(p, input.ToLower().Split(' '));
            Assert.AreEqual(bag.FullDescription, c.Execute(p, input.ToLower().Split(' ')));
        }
        [Test]
        public void Test2()
        {
            string input = "move south";
            c.Execute(p, input.ToLower().Split(' '));
            Assert.AreEqual(l2, p.Location);     
        }
        [Test]
        public void Test3()
        {
            string input = "mmb";
            c.Execute(p, input.ToLower().Split(' '));
            Assert.AreEqual("I don't know how to do that.", c.Execute(p, input.ToLower().Split(' ')));
        }
        [Test]
        public void Test4()
        {
            string input = "look at item";
            c.Execute(p, input.ToLower().Split(' '));
            Assert.AreEqual(item.FullDescription, c.Execute(p, input.ToLower().Split()));
        }
    }
}