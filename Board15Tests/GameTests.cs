using Microsoft.VisualStudio.TestTools.UnitTesting;
using Board15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board15.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(3, game.GetDigitAt(2, 0));
            Assert.AreEqual(4, game.GetDigitAt(3, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(6, game.GetDigitAt(1, 1));
            Assert.AreEqual(7, game.GetDigitAt(2, 1));
            Assert.AreEqual(8, game.GetDigitAt(3, 1));
            Assert.AreEqual(9, game.GetDigitAt(0, 2));
            Assert.AreEqual(10, game.GetDigitAt(1, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 2));
            Assert.AreEqual(12, game.GetDigitAt(3, 2));
            Assert.AreEqual(13, game.GetDigitAt(0, 3));
            Assert.AreEqual(14, game.GetDigitAt(1, 3));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(3, 3));
        }

        [TestMethod()]
        public void PressAtTest()
        {
            Game game = new Game(4);
            game.Start();
            game.PressAt(2,3);
            Assert.AreEqual(0, game.GetDigitAt(2, 3));
            Assert.AreEqual(15, game.GetDigitAt(3, 3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }

        [TestMethod()]
        public void GetDigitAtTest()
        {
            Game game = new Game(4);
            game.Start();
            game.PressAt(2, 3);
            Assert.AreEqual(0, game.GetDigitAt(-5, -34));
            Assert.AreEqual(0, game.GetDigitAt(15, 6));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}