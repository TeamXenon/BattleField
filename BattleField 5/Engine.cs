namespace BattleField
{
    using System;

    public class Engine : IEngine
    {
        internal const int MinSize = 0;
        internal const int MaxSize = 10;

        public Engine() 
        { 
        }

        public void Start()
        {
            Console.WriteLine(GameMessage.IntroMessage);
            int size = this.GetFieldSize();
            IGameField field = new GameField(size);
            field.GenerateField();
            this.StartInteraction(field);
        }

        private int GetFieldSize()
        {
            int size = 0;

            while (true)
            {
                Console.Write(GameMessage.SizePrompt);
                string inputCommand = Console.ReadLine();
                bool isNumber = int.TryParse(inputCommand, out size);

                if (!isNumber || size > MaxSize || size <= MinSize)
                {
                    Console.WriteLine(GameMessage.WrongFormat);
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
                try
                {
                    field.DrawField();
                    Console.Write(GameMessage.CoordinatesPrompt);
                    readBuffer = Console.ReadLine();
                    Mine mineToBlow = GameServices.ExtractMineFromString(readBuffer);

                    while (mineToBlow == null)
                    {
                        Console.Write(GameMessage.CoordinatesPrompt);
                        readBuffer = Console.ReadLine();
                        mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                    }

                    bool isValidMove = GameServices.IsValidMove(field.Field, mineToBlow.X, mineToBlow.Y);
                    if (!isValidMove)
                    {
                        Console.WriteLine(GameMessage.InvalidMove);
                        continue;
                    }

                    Explosion.Explode(field.Field, mineToBlow);
                    blownMines++;
                }
                catch (InvalidMineCoordinatesException)
                {
                    Console.WriteLine(GameMessage.InvalidIndex);
                    continue;
                }
               
            }

            field.DrawField();
            Console.WriteLine("{0} {1}", GameMessage.GameOverMessage, blownMines);
        }
    }
}
