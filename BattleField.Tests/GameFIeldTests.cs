namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFIeldTests
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
        public void ContainsMinesTest_TrueResultWithOneMine()
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
        public void ContainsMinesTest_FalseResultEmptyField()
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
        public void ContainsMinesTest_FalseResultDetonatedField()
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
