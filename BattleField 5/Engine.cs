using System;

namespace BattleField
{
    public class Engine : IEngine
    {
        internal const int MinSize = 0;
        internal const int MaxSize = 10;

        public Engine() { }

        public void Start()
        {
            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            int size = GetFieldSize();
            IGameField field = new GameField(size);
            field.GenerateField();
            StartInteraction(field);
        }

        private int GetFieldSize()
        {
            int size = 0;

            while (true)
            {
                Console.Write("Enter battle field size: n=");
                string inputCommand = Console.ReadLine();
                bool isNumber = int.TryParse(inputCommand, out size);

                if (!isNumber || size > MaxSize || size <= MinSize)
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

        private void StartInteraction(IGameField field)
        {
            string readBuffer = null;
            int blownMines = 0;

            while (field.ContainsMines())
            {
                field.DrawField();
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                bool isValidMove = GameServices.IsValidMove(field.Field, mineToBlow.X, mineToBlow.Y);
                if (!isValidMove)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                Explosion.Explode(field.Field, mineToBlow);
                blownMines++;
            }

            field.DrawField();
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }
    }
}
