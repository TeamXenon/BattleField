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
            char[,] field = new char[2, 2];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = '-';
                }
            }

            field[0, 1] = '2';
            string line = "-1 2";
            Mine mine = GameServices.ExtractMineFromString(line);

            Assert.IsInstanceOfType(mine, typeof(BattleField.Mine));
        }
    }
}
