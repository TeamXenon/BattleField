using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BattleField.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void StartIntroMessageTest()
        {
            string inputFile = "EngineConsoleInput.txt";
            string command = "1\n0 0\n0 1\n1 0\n1 1";

            StreamWriter writer = new StreamWriter(inputFile);
            using (writer)
            {
                writer.WriteLine(command);
            }

            IEngine engine = new Engine();

            StreamReader consoleInput = new StreamReader(inputFile);

            string outputFile = "EngineConsoleOutput.txt";

            StreamWriter consoleResult = new StreamWriter(outputFile);

            using (consoleInput)
            {
                Console.SetIn(consoleInput);

                using (consoleResult)
                {
                    Console.SetOut(consoleResult);
                    engine.Start();
                }
            }

            StreamReader resultReader = new StreamReader(outputFile);

            string gameFieldFirstLine = string.Empty;

            using (resultReader)
            {
                gameFieldFirstLine = resultReader.ReadLine();
            }

            string expectedResult =@"Welcome to ""Battle Field"" game. ";
            Assert.AreEqual(expectedResult, gameFieldFirstLine);
        }
    }
}
