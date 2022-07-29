using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class BagTest
    {
        Player Player1;
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item Gun;
        Bag Bag;
        [TestMethod]
        public void BagLocateItem_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "bag", "Stores All your Items");
            Bag.Inventory.Put(Sword);
            Assert.AreEqual(Sword, Bag.Locate("Sword"));
        }

        [TestMethod]
        public void BagLocateItSelf_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            Assert.AreEqual(Bag, Bag.Locate("Bag"));
        }

        [TestMethod]
        public void BagLocateNothing_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            Assert.AreEqual(null, Bag.Locate("Sword"));
        }

        [TestMethod]
        public void BagFullDesc_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            Bag.Inventory.Put(Gun);
            Assert.AreEqual("In the Bags You can see An OP weapon\n\n", Bag.FullDescription);
        }
    }
}
