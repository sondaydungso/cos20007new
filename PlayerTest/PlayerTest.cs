using SwinAdventure;

namespace PlayerTest
{
    public class Tests
    {
        Player p;
        Item i;
        Item i2;
        [SetUp]
        public void Setup()
        {
            p = new Player("me", "inventory");
            i = new Item(new string[] { "sword", "brozen" }, "brozen sword", "a sword made from brozen");
            i2 = new Item(new string[] { "shield", "brozen" }, "brozen shield", "a shield made from brozen");
            p.Inventory.Put(i);
            p.Inventory.Put(i2);
        }

        
        public void TestPlayerisIdentifiable(string s)
        {
            Assert.IsTrue(p.AreYou(s));

        }
        [Test]
        public void TestPlayerLocateItem()
        {
            Assert.AreEqual(i, p.Locate("sword"));
        }
        [Test]
        public void TestPlayerLocateSelf()
        {
            Assert.AreEqual(p, p.Locate("me"));
        }
        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.AreEqual(null, p.Locate("nothing"));
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.AreEqual("You are carrying: \t brozen sword\n\t brozen shield\n", p.FullDescription);
        }
    }
}