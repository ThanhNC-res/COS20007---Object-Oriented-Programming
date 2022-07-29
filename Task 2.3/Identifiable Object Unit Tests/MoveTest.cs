using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Swin_Adventure;

namespace Identifiable_Object_Unit_Tests
{
    [TestClass]
    public class MoveTest
    {
        Move _move;
        Player _Player;
        Location _testRoom1;
        Location _testRoom2;
        Path _testPath;
        [TestMethod]
        public void MovePlayerTest()
        {
            _move = new Move();
            _Player = new Player("Zero", "The Player!");

            _testRoom1 = new Location("Room 1", "Room 1");
            _testRoom2 = new Location("Room 2", "Room 2");

            _Player.Location = _testRoom1;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoom1, _testRoom2);
            _testRoom1.AddPath(_testPath);

            _move.Execute(_Player, new string[] { "move", "to", "north" });

            String _expected = _testRoom2.Name;
            String _actual = _Player.Location.Name;
            Assert.AreEqual(_expected, _actual, "Testing that move can move the player");

        }
        [TestMethod]
        public void ErrorMove()
        {
            _move = new Move();
            _Player = new Player("Zero", "The Player!");

            _testRoom1 = new Location("Room 1", "Room 1");
            _testRoom2 = new Location("Room 2", "Room 2");

            _Player.Location = _testRoom1;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoom1, _testRoom2);
            _testRoom1.AddPath(_testPath);

            _move.Execute(_Player, new string[] { "move", "to", "north" });
            _move.Execute(_Player, new string[] { "move", "south" });

            String _expected = "Room 2";
            String _actual = _Player.Location.Name;
            Assert.AreEqual(_expected, _actual, "No path have initialized");
        }
    }
}
