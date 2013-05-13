using System;

namespace BattleField
{
    class Engine
    {
        //poLeto za biTka
        private char[,] gameField;
        public Engine()
        {
            //gameField = null;
        }

        public void Start()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            
            //string readBuffer = null;

            int size = GetFieldSize();

            // if (size > 10 || size <= 0)
            //{ 
            //    Start();
            //}
            //else{

            gameField = GameServices.GenerateField(size);
            StartInteraction();
           // }
        }

        // extracted method
        private int GetFieldSize()
        {
            int size = 0;

            while (true)
            {
                Console.Write("Enter battle field size: n=");
                string inputCommand = Console.ReadLine();
                bool isNumber = int.TryParse(inputCommand, out size);

                if (!isNumber || size > 10 || size <= 0)
                {
                    Console.WriteLine("Wrong format!");
                }
                else
                {
                    break;
                }
            }

            return size;
        }

        private void StartInteraction()
        {
            Console.Clear();

            int blownMines = 0;

            while (GameServices.ContainsMines(gameField))
            {
                GameServices.DrawField(gameField);

                Mine mineToBlow = null;
                string readBuffer = string.Empty;

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                bool isValid = GameServices.IsValidMove(gameField, mineToBlow.X, mineToBlow.Y);

                if (!isValid)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Explode(gameField, mineToBlow);
                blownMines++;
            }

            GameServices.DrawField(gameField);
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }
    }
}
