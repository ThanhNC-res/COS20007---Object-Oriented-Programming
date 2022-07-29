using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Swin_Adventure
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AreYouTest()
        {
            string[] test_Array = new string[] {"fred", "bob"};
            Identifiable_Object idents = new Identifiable_Object(test_Array);
            Assert.IsTrue(idents.AreYou("bob"));

        }

        [TestMethod]
        public void NotAreYouTest()
        {
            string[] test_Array = new string[] {"fred", "bob"};
            Identifiable_Object idents = new Identifiable_Object(test_Array);
            Assert.IsFalse(idents.AreYou("wilma"));
        }

        [TestMethod]
        public void caseSensitiveTest()
        {
            string[] test_Array = new string[] {"fred", "bob"};
            Identifiable_Object idents = new Identifiable_Object(test_Array);
            Assert.IsTrue(idents.AreYou("bOB"));
        }

        [TestMethod]
        public void FirstIdTest()
        {
            string[] test_Array = new string[] {"fred", "bob"};
            Identifiable_Object idents = new Identifiable_Object(test_Array);
            StringAssert.ReferenceEquals("fred", idents.FirstId);
        }

        [TestMethod]
        public void AddIdTest()
        {
            string[] test_Array = new string[] { "fred", "bob" };
            Identifiable_Object idents = new Identifiable_Object(test_Array);
            idents.Add_Identifier("wilma");
            Assert.IsTrue(idents.AreYou("fred"));
            Assert.IsTrue(idents.AreYou("bob"));
            Assert.IsTrue(idents.AreYou("wilma"));

        }
    }
}
