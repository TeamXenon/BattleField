namespace BattleField
{
    using System;
    using System.Collections.Generic;

    public class GameField
    {
        public const char EmptyCell = '-'; 
        private const double LowerMineLimit = 0.15;
        private const double UpperMineLimit = 0.3;
        private static readonly Random RandomNumber = new Random();

        // Constructor
        public GameField(int size)
        {
            this.Size = size;
            this.Field = new char[size, size];
        }

        public char[,] Field { get; set; }

        public int Size { get; set; }

        public void GenerateField()
        {
            this.GenerateEmptyField();
            this.GenerateMines();
        }        

        public bool ContainsMines()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (this.Field[i, j] != EmptyCell && this.Field[i, j] != Explosion.DetonatedCell)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DrawField()
        {
            Console.Write("   ");
            int fieldSize = this.Field.GetLength(0);
            for (int col = 0; col < fieldSize; col++)
            {
                Console.Write("{0} ", col);
            }

            Console.WriteLine();
            Console.Write("   ");

            for (int border = 0; border < fieldSize * 2; border++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int row = 0; row < fieldSize; row++)
            {
                Console.Write("{0} |", row);
                for (int col = 0; col < fieldSize; col++)
                {
                    Console.Write("{0} ", this.Field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private int DetermineMineCount()
        {
            double fields = (double)this.Size * this.Size;
            int lowBound = (int)(LowerMineLimit * fields);
            int upperBound = (int)(UpperMineLimit * fields);
            return RandomNumber.Next(lowBound, upperBound);
        }

        private void GenerateMines()
        {
            List<Mine> mines = new List<Mine>();

            int minesCount = this.DetermineMineCount();

            for (int i = 0; i < minesCount; i++)
            {
                int mineX = RandomNumber.Next(0, this.Size);
                int mineY = RandomNumber.Next(0, this.Size);
                Mine newMine = new Mine(mineX, mineY);

                if (this.Contains(newMine, mines))
                {
                    i--;
                    continue;
                }

                int mineType = RandomNumber.Next('1', '6');
                this.Field[mineX, mineY] = Convert.ToChar(mineType);
            }
        }

        private void GenerateEmptyField()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.Field[i, j] = EmptyCell;
                }
            }
        }

        private bool Contains(Mine newMine, List<Mine> mines)
        {
            foreach (Mine currentMine in mines)
            {
                if (currentMine.X == newMine.X && currentMine.Y == newMine.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
