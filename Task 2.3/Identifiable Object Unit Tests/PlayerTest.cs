using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class PlayerTest
    {
        Player Player1;
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item Gun;

        [TestMethod]
        public void IdentifiablePlayer_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Assert.IsTrue(Player1.AreYou("me"));
        }

        [TestMethod]
        public void PlayerLocateItem_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Player1.Inventory.Put(Sword);
            Assert.AreEqual(Sword, Player1.Locate("Sword"));
        }

        [TestMethod]
        public void PlayerLocateItSelf_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Assert.AreEqual(Player1, Player1.Locate("me"));
        }

        [TestMethod]
        public void PlayerLocateNothing_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Assert.AreEqual(null, Player1.Locate("Sword"));
        }

        [TestMethod]
        public void PlayerFullDesc_Test()
        {
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Player1.Inventory.Put(Gun);
            Assert.AreEqual("You are Thanh. Player Unknown.", Player1.FullDescription);
        }

    }
}
