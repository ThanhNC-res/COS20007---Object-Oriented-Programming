using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class PathTest
    {
        Player _Player;
        Location _testRoom1;
        Location _testRoom2;
        Path _testPath;
        [TestMethod]
        public void DirectionTest()
        {
            _Player = new Player("Zero", "The Player!");

            _testRoom1 = new Location("Room 1", "Room 1");
            _testRoom2 = new Location("Room 2", "Room 2");

            _Player.Location = _testRoom1;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoom1, _testRoom2);
            _testRoom1.AddPath(_testPath);

            Assert.AreEqual(_testRoom1.FirstId, _testPath.To.FirstId);
        }
        [TestMethod]
        public void LocatePathTest()
        {
            _Player = new Player("Zero", "The Player!");

            _testRoom1 = new Location("Room 1", "Room 1");
            _testRoom2 = new Location("Room 2", "Room 2");

            _Player.Location = _testRoom1;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoom1, _testRoom2);
            _testRoom1.AddPath(_testPath);

            GameObject _expected = _testRoom1.Locate("north");
            GameObject _actual = _testPath;
        }
    }
}
