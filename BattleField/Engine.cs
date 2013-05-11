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
            Console.Write("Enter battle field size: n=");
            string inputCommand = Console.ReadLine();
            int size = 0;
            bool isNumber = int.TryParse(inputCommand, out size);

            while (!isNumber || size > 10 || size <= 0)
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Enter battle field size: n=");
                inputCommand = Console.ReadLine();
                isNumber = int.TryParse(inputCommand, out size);
            }

            return size;
        }

        private void StartInteraction()
        {
            string readBuffer = null;
            int blownMines = 0;
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine();
            //}

            while (GameServices.ContainsMines(gameField))
            {
                GameServices.DrawField(gameField);
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow =  GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                if (!GameServices.IsValidMove(gameField, mineToBlow.X, mineToBlow.Y))
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
