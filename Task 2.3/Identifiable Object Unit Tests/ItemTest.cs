using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void IdentifiableItem_Test()
        {
            Item Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Gun", "A Good Weepon");
            Assert.IsTrue(Gun.AreYou("Gun"));
        }

        [TestMethod]
        public void ShortDescription_Test()
        {
            Item Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Gun", "Ultimate Weapon");
            Assert.AreEqual("Ultimate Weapon", Gun.ShortDescription);
        }

        [TestMethod]
        public void FullDesc_Test()
        {
            Item Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Gun", "Ultimate Weapon");
            Assert.AreEqual("You are carrying: Ultimate Weapon", Gun.FullDescription);
        }

    }
}
