using SwinAdventure;
using System.Runtime.InteropServices.JavaScript;

namespace Item_Test
{
    public class Tests
    {
        Item i;
        [SetUp]
        public void Setup()
        {
            i = new Item(new string[] { "sword", "brozen" }, "brozen sword", "a sword made from brozen");
        }

        
        public void IsIdentifiable(string s)
        {
            Assert.IsTrue(i.AreYou(s));
        }
        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("brozen sword", i.Name);
        }
        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("The brozen sword a sword made from brozen", i.FullDescription);
        }
    }
}