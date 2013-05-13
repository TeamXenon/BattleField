using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class GameField
    {
        private static readonly Random rand = new Random();
        private const double LowerMineLimit = 0.15;
        private const double UpperMineLimit = 0.3;
        public const char EmptyCell = '-';

        public char[,] Field { get; set; }
        public int Size { get; set; }

        // Constructor
        public GameField(int size)
        {
            this.Size = size;
            this.Field = new char[size, size];
        }        
        
        public void GenerateField()
        {
            GenerateEmptyField();
            GenerateMines();
        }

        private int DetermineMineCount()
        {
            double fields = (double)this.Size * this.Size;
            int lowBound = (int)(LowerMineLimit * fields);
            int upperBound = (int)(UpperMineLimit * fields);
            return rand.Next(lowBound, upperBound);
        }

        private void GenerateMines()
        {
            List<Mine> mines = new List<Mine>();

            int minesCount = DetermineMineCount();

            for (int i = 0; i < minesCount; i++)
            {
                int mineX = rand.Next(0, this.Size);
                int mineY = rand.Next(0, this.Size);
                Mine newMine = new Mine(mineX, mineY);

                if (Contains(newMine, mines))
                {
                    i--;
                    continue;
                }

                int mineType = rand.Next('1', '6');
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


    }
}
