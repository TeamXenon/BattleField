namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

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

        [TestMethod]
        public void DrawGamefieldSizeFiveTest()
        {
            string consoleFile = "GameFieldConsoleOutput.txt";

            GameField field = new GameField(5);

            StreamWriter consoleResult = new StreamWriter(consoleFile);

            using (consoleResult)
            {
                Console.SetOut(consoleResult);
                field.DrawField();
            }

            StreamReader readerResult = new StreamReader(consoleFile);

            string gameFieldFirstLine = string.Empty;

            using (readerResult)
            {
                gameFieldFirstLine = readerResult.ReadLine();
            }

            string expectedResult = "   0 1 2 3 4 ";
            Assert.AreEqual(expectedResult, gameFieldFirstLine);
        }

        [TestMethod]
        public void GenerateField_TestField()
        {
            GameField field = new GameField(4);
            field.GenerateField();
            int mineCounter = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (field.Field[row, col] != '-')
                    {
                        mineCounter++;
                    }
                }
            }

            double currentMinesPercent = (mineCounter * 100) / (4 * 4);
            bool isBiggerThanMinRange = GameField.LowerMineLimit <= currentMinesPercent / 100;
            bool isSmallerThanMaxRange = currentMinesPercent / 100 <= GameField.UpperMineLimit;
            bool isInTange = isBiggerThanMinRange && isSmallerThanMaxRange;
            Assert.AreEqual(true, isInTange);
        }
    }
}
