using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class LookCommandTest
    {
        Look_Command look = new Look_Command();
        Player player;
        Bag bag;
        Item gem;
        [TestMethod]
        public void LookAtMe_Test()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(bag);

            Assert.AreEqual("You are Thanh. A male.\r\n", look.Execute(player, new string[] { "look", "at", "inventory" }));

        }

        [TestMethod]
        public void LookAtGem_Test()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(gem);
            Assert.AreEqual("You are carrying: a big gem\r\n", look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }));

        }

        [TestMethod]
        public void LookAtunk_Test()
        {
           
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(gem);
            player.Inventory.Take("gem");
            Assert.AreEqual("Could not find gem.\r\n", look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }));

        }

        [TestMethod]
        public void LookAtGemInMe_Test()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(gem);
            Assert.AreEqual("You are carrying: a big gem\r\n", look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }));

        }

        [TestMethod]
        public void LookAtGemInBag_Test()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            Assert.AreEqual("You are carrying: a big gem\r\n", look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));

        }

        [TestMethod]
        public void LookAtNoGemInBag_Test()
        {
           
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(bag);
            Assert.AreEqual("Could not find gem.\r\n", look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));

        }

        [TestMethod]
        public void LookAtGemInNoBag_Test()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            player.Inventory.Put(gem);
            Assert.AreEqual("Could not find bag.", look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));

        }

        [TestMethod]
        public void Invalid_Look()
        {
            
            player = new Player("Thanh", "A male");
            bag = new Bag(new string[] { "bag", "bags" }, "Bag", "Stores All your Items");
            gem = new Item(new string[] { "gem" }, "a gem", "a big gem");

            Assert.AreEqual("Could not find test.\r\n", look.Execute(player, new string[] { "look", "test" }));
            Assert.AreEqual("Error in look input", look.Execute(player, new string[] { "test", "at", "gem" }));
            Assert.AreEqual("What do you want to look at?", look.Execute(player, new string[] { "look", "test", "gem" }));
            Assert.AreEqual("What do you want to look in?", look.Execute(player, new string[] { "look", "at", "gem", "test", "bag" }));
        }

    }
}
