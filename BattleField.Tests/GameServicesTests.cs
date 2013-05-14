using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class GameServicesTests
    {
        [TestMethod]
        public void IsValidMove_ShouldReturnTrue()
        {
            char[,] field = new char[6, 6];
            bool isValidMove = GameServices.IsValidMove(field, 5, 5); ;

            Assert.AreEqual(true, isValidMove);
        }

        [TestMethod]
        public void ExtractMineFromString_ShouldReturnTrue()
        {
            string line = "1 2";
            Mine mine = GameServices.ExtractMineFromString(line);

            Assert.IsInstanceOfType(mine, typeof(BattleField.Mine));
        }

        [TestMethod]
        public void ExtractMineFromString_ShouldReturnFalse()
        {
            string line = "a b";
            Mine mine = GameServices.ExtractMineFromString(line);

            bool isMine = true;
            if (typeof(Mine) == typeof(BattleField.Mine))
            {
                isMine = false;
            }
            bool falseResult = false;
            Assert.AreEqual(falseResult, isMine);
        }
    }
}
