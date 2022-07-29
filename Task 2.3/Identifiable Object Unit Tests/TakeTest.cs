using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class TakeTest
    {
        Player Player1;
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item Gun;
        Bag Bag;
        Take take = new Take();
        [TestMethod]
        public void TakeTest1()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "bag", "Stores All your Items");

            Player1.Put(Bag);
            Bag.Inventory.Put(Sword);
            Bag.Inventory.Put(Bow);
            Bag.Inventory.Put(Gun);

            Assert.AreEqual("You have taken the gun.\r\n", take.Execute(Player1, new string[] { "take", "gun", "in", "bags" }));

        }

        [TestMethod]
        public void TakeTest2()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");
            Bag = new Bag(new string[] { "bag", "bags" }, "bag", "Stores All your Items");

            Player1.Put(Bag);
            Bag.Inventory.Put(Sword);
            Bag.Inventory.Put(Bow);
            Bag.Inventory.Put(Gun);

            Assert.AreEqual("Take what?", take.Execute(Player1, new string[] { "take" }));
        }
    }
}
