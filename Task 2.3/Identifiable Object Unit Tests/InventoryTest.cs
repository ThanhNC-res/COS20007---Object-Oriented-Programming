using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class InventoryTest
    {
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item Gun;
        [TestMethod]
        public void FindItemTest()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            inv.Put(Sword);
            Assert.AreEqual(true, inv.HasItem("Sword"));

        }

        [TestMethod]
        public void NoItemFind_Test()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            inv.Fetch("Sword");
            inv.Take("Sword");
            Assert.AreEqual(false, inv.HasItem("Sword"));
        }

       
        [TestMethod]
        public void FetchItem_Test()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            inv.Fetch("Gun");
            Assert.AreNotEqual(true, inv.Fetch("Gun"));
        }

        [TestMethod]
        public void TakeItem_Test()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            inv.Put(Bow);
            inv.Put(Gun);
            inv.Take("Bow");
            Assert.AreEqual(false, inv.HasItem("Bow"));
            Assert.IsTrue(inv.HasItem("Gun"));
        }

        [TestMethod]
        public void ItemList_Test()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            inv.Put(Sword);
            Assert.AreEqual("Short Hand Weapon\n", inv.ItemList);

        }

    }
}
