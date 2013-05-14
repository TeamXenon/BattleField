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
            bool isValidMove = GameServices.IsValidMove(field, 5, 5);

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
        public void ExtractMineFromString_LettersInput()
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

        [TestMethod]
        public void ExtractMineFromString_EmptyString()
        {
            string line = "";
            Mine mine = GameServices.ExtractMineFromString(line);
            bool isMine = true;

            if (typeof(Mine) == typeof(BattleField.Mine))
            {
                isMine = false;
            }
            bool falseResult = false;

            Assert.AreEqual(falseResult, isMine);
        }

        [TestMethod]
        public void ExtractMineFromString_LetterAndNumber()
        {
            string line = "5 a";
            Mine mine = GameServices.ExtractMineFromString(line);
            bool isMine = true;

            if (typeof(Mine) == typeof(BattleField.Mine))
            {
                isMine = false;
            }
            bool falseResult = false;

            Assert.AreEqual(falseResult, isMine);
        }

        [TestMethod]
        public void IsValidMove_ShouldReturnFalseOutsideOfField()
        {
            char[,] field = new char[2, 2];
            bool isValidMove = GameServices.IsValidMove(field, 5, 5);

            Assert.AreEqual(false, isValidMove);
        }

        [TestMethod]
        public void IsValidMove_ShouldReturnFalseCellIsDetonated()
        {
            char[,] field = 
            { 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            bool isValidMove = GameServices.IsValidMove(field, 0, 0);

            Assert.AreEqual(false, isValidMove);
        }

        [TestMethod]
        public void IsValidMove_ShouldReturnFalseCellIsEmpty()
        {
            char[,] field = 
            { 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { 'X', 'X', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            bool isValidMove = GameServices.IsValidMove(field, 5, 5);

            Assert.AreEqual(false, isValidMove);
        }

        [TestMethod]
        public void ExtractMineFromString_ReturnNullTryWithSpace()
        {
            string line = " ";
            Mine mine = GameServices.ExtractMineFromString(line);

            Assert.AreEqual(mine, null);
        }

        [TestMethod]
        public void ExtractMineFromString_ReturnNullTryWithNull()
        {
            string line = null;
            Mine mine = GameServices.ExtractMineFromString(line);

            Assert.AreEqual(mine, null);
        }
    }
}

