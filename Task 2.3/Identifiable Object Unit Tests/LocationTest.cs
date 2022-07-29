using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class LocationTest
    {
        Look_Command look = new Look_Command();
        Location room; 
        Player Player1;
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item Gun;

        [TestMethod]
        public void PlayerLocationTest()
        {
            room = new Location("bedroom", "A huge room");
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            Player1.Location = room;
            Assert.AreEqual("Your location is bedroom. A huge room.\r\n", look.Execute(Player1, new string[] {"look", "at", "room" }));

        }

        
        [TestMethod]
        public void ObjectLocationTest()
        {
            room = new Location("room", "A huge room");
            Player1 = new Player("Thanh", "Player Unknown");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "Short Hand Weapon");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "Average range weapon");
            Gun = new Item(new string[] { "Gun", "Machine Gun" }, "Ak-47 ", "An OP weapon");

            room.Inventory.Put(Sword);
            Player1.Location = room;
            Assert.AreEqual("You are carrying: Short Hand Weapon\r\n", look.Execute(Player1, new string[] {"look", "at", "Sword", "in", "room" }));

        }

    }
}
