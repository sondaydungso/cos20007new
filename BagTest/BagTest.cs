using SwinAdventure;
namespace BagTest
{
    public class Tests
    {
        Bag b;
        Bag b2;
        Item i;
        Item i2;
        [SetUp]
        public void Setup()
        {
            b = new Bag(new string[] { "bag", "small" }, "small bag", "a small bag");
            b2 = new Bag(new string[] { "bag", "big" }, "big bag", "a big bag");
            i = new Item(new string[] { "sword", "brozen" }, "brozen sword", "a sword made from brozen");
            i2 = new Item(new string[] { "knife", "silver" }, "silver knife", "a knife made from silver");
            b.Inventory.Put(i);
            b.Inventory.Put(i2);
            b.Inventory.Put(b2);
            b2.Inventory.Put(i);
            b2.Inventory.Put(i2);   
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.IsTrue(b.Inventory.HasItem("sword"));
            Assert.IsTrue(b.Inventory.HasItem("knife"));
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.IsTrue(b.AreYou("bag"));
        }
        public void TestBagLocatesNothing()
        {
            Assert.IsFalse(b.AreYou("torch"));
        }
        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the small bag you can see:\nbrozen sword silver knife big bag ", b.FullDescription);
        }
        [Test]
        public void TestBagInBag()
        {
            Assert.AreEqual(i, b.Locate("sword"));
            Assert.AreEqual(i2, b.Locate("knife"));
        }
    }
}