using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class GameFIeldTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            int size = 5;
            GameField field = new GameField(size);
            Assert.AreEqual(size * size, field.Field.Length);
        }

        [TestMethod]
        public void ContainsMinesTest_TrueResult()
        {
            int size = 5;
            GameField field = new GameField(size);
            bool result = field.ContainsMines();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ContainsMinesTest_TrueResult2()
        {
            int size = 8;
            GameField field = new GameField(size);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    field.Field[row, col] = '-';
                }
            }
            field.Field[3, 4] = '4';
            bool result = field.ContainsMines();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ContainsMinesTest_FalseResult()
        {
            int size = 5;
            GameField field = new GameField(size);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    field.Field[row, col] = '-';
                }
            }
            bool result = field.ContainsMines();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ContainsMinesTest_FalseResult2()
        {
            int size = 5;
            GameField field = new GameField(size);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    field.Field[row, col] = 'X';
                }
            }
            bool result = field.ContainsMines();
            Assert.AreEqual(false, result);
        }
    }
}
