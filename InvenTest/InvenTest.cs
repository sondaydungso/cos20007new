using SwinAdventure;

namespace InvenTest
{
    public class Tests
    {
        Inventory inven;
        Item i;
        Item i2;
        [SetUp]
        public void Setup()
        {
            inven = new Inventory();
            i = new Item(new string[] { "sword", "brozen" }, "brozen sword", "a sword made from brozen");
            i2 = new Item(new string[] { "knife", "silver" }, "silver knife", "a knife made from silver");
        }
        private void PutItem()
        {
            inven.Put(i);
            inven.Put(i2);
        }

        [Test]
        public void TestFindItem()
        {
            PutItem();
            Assert.IsTrue(inven.HasItem("sword"));
            Assert.IsTrue(inven.HasItem("knife"));

        }
        [Test]
        public void TestNoItem()
        {
            PutItem();
            Assert.IsFalse(inven.HasItem("axe"));
        }
        [Test]
        public void TestFetchItem()
        {
            PutItem();
            Assert.AreEqual(i, inven.Fetch("sword"));
            Assert.AreEqual(i2, inven.Fetch("knife"));
        }
        [Test]
        public void TestTakeItem()
        {
            PutItem();
            Assert.AreEqual(i, inven.Take("sword"));
            Assert.AreEqual(i2, inven.Take("knife"));
        }
        [Test]
        public void TestItemList()
        {
            PutItem();
            string expected = "\t brozen sword\n\t silver knife\n";
            Assert.AreEqual(expected, inven.ItemList);
        }
    }
}