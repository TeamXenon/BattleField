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
        public void ExtractMineFromString()
        {
            string line = "-1 2";
            Mine mine = GameServices.ExtractMineFromString(line);

            Assert.IsInstanceOfType(mine, typeof(BattleField.Mine));
        }
    }
}
