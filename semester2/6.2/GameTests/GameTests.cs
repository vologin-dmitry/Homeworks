using Microsoft.VisualStudio.TestTools.UnitTesting;
using H6T2;
using System;
using System.Collections.Generic;

namespace GameTests
{
    [TestClass]
    public class GameTests
    {
        private EventLoop eventLoop;
        private Game game;
        private List<string> map;

        [TestInitialize]
        public void Initialize()
        {
            eventLoop = new EventLoop();
            map = FileReader.MakeList("MapTest.txt");
            game = new Game(map);
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.TopHandler += game.OnUp;
            eventLoop.BottomHandler += game.OnDown;
        }

        [TestMethod]
        public void MapReaderTest()
        {
            var line = new string[] { "########", "#@     #", "# # # ##", "# ### ##", "# ######", "########" };
            for (int i = 0; i < map.Count; ++i)
            {
                Assert.AreEqual(line[i], map[i]);
            }
        }

        [TestMethod]
        public void WallUpTest()
        {
            game.OnUp(game, null);
            Assert.AreEqual('@', map[1][1]);
        }

        public void WallLeftTest()
        {
            game.OnLeft(game, null);
            Assert.AreEqual('@', map[1][1]);
        }

        [TestMethod]
        public void WalkTest()
        {
            game.OnRight(game, null);
            Assert.AreEqual('@', map[1][2]);
            Assert.AreEqual(' ', map[1][1]);
        }

        [TestMethod]
        public void SeveralStepsTest()
        {
            game.OnRight(game, null);
            game.OnRight(game, null);
            game.OnDown(game, null);
            Assert.AreEqual('@', map[2][3]);
        }

        [TestMethod]
        public void WallRightTest()
        {
            game.OnRight(game, null);
            game.OnRight(game, null);
            game.OnDown(game, null);
            game.OnRight(game, null);
            Assert.AreEqual('@', map[2][3]);
        }

        [TestMethod]
        public void WallDownTest()
        {
            game.OnRight(game, null);
            game.OnRight(game, null);
            game.OnDown(game, null);
            game.OnDown(game, null);
            Assert.AreEqual('@', map[2][3]);
        }

        [TestMethod]
        public void ThereAndBackTest()
        {
            game.OnRight(game, null);
            game.OnLeft(game,null);
            Assert.AreEqual('@', map[1][1]);
        }
    }

//           Entered map:     Expecting changed map
//              _____               ########
//              _#_#_               #______#
//              _###_               #_#_#_##
//              _                   #_###_##
//                                  #_######
//                                  ########
}
