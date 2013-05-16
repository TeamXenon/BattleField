namespace BattleField.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void StartIntroMessageTest()
        {
            string inputFile = "EngineConsoleInput.txt";
            string command = "2\n0 0\n0 1\n1 0\n1 1\n";

            StreamWriter writer = new StreamWriter(inputFile);
            using (writer)
            {
                writer.WriteLine(command);
            }

            IEngine engine = new Engine();

            StreamReader consoleInput = new StreamReader(inputFile);

            string outputFile = "EngineConsoleOutput.txt";

            StreamWriter consoleOutput = new StreamWriter(outputFile);

            using (consoleInput)
            {
                Console.SetIn(consoleInput);

                using (consoleOutput)
                {
                    Console.SetOut(consoleOutput);
                    engine.Start();
                }
            }

            StreamReader consoleResult = new StreamReader(outputFile);

            string gameFieldFirstLine = string.Empty;

            using (consoleResult)
            {
                gameFieldFirstLine = consoleResult.ReadLine();
            }

            string expectedResult = @"Welcome to ""Battle Field"" game.";
            Assert.AreEqual(expectedResult, gameFieldFirstLine);
        }

        [TestMethod]
        public void GameOverMessageTest()
        {
            string inputFile = "EngineConsoleInput.txt";
            string command = "2\n0 0\n0 1\n1 0\n1 1\n";

            StreamWriter writer = new StreamWriter(inputFile);
            using (writer)
            {
                writer.WriteLine(command);
            }

            IEngine engine = new Engine();

            StreamReader consoleInput = new StreamReader(inputFile);

            string outputFile = "EngineConsoleOutput.txt";

            StreamWriter consoleOutput = new StreamWriter(outputFile);

            using (consoleInput)
            {
                Console.SetIn(consoleInput);

                using (consoleOutput)
                {
                    Console.SetOut(consoleOutput);
                    engine.Start();
                }
            }

            StreamReader consoleResult = new StreamReader(outputFile);

            string gameFieldLastLine = string.Empty;
            string expectedResult = @"Game over. Detonated mines: ";

            using (consoleResult)
            {
                string[] outputResult = consoleResult.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                gameFieldLastLine = outputResult[outputResult.Length - 1].Substring(0, expectedResult.Length);
            }
            
            Assert.AreEqual(expectedResult, gameFieldLastLine);
        }
    }
}
