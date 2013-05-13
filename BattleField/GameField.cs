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
        internal const char EmptyCell = '-';
        internal const char DetonatedCell = 'X';

        public static char[,] GenerateField(int size)
        {
            char[,] field = GenerateEmptyField(size);
            field = GenerateMines(field);

            return field;
        }

        private static char[,] GenerateMines(char[,] field)
        {
            List<Mine> mines = new List<Mine>();

            int minesCount = DetermineMineCount(field.GetLength(0));

            for (int i = 0; i < minesCount; i++)
            {
                int mineX = rand.Next(0, field.GetLength(0));
                int mineY = rand.Next(0, field.GetLength(1));

                Mine newMine = new Mine(mineX, mineY);

                if (GameField.CheckIfMineExists(mines, newMine))
                {
                    i--;
                    continue;
                }

                int mineType = rand.Next('1', '6');
                field[mineX, mineY] = Convert.ToChar(mineType);
            }

            return field;
        }

        // extrated method
        private static char[,] GenerateEmptyField(int size)
        {
            char[,] field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = EmptyCell;
                }
            }

            return field;
        }

        private static int DetermineMineCount(int size)
        {
            double fields = (double)size * size;
            int lowBound = (int)(LowerMineLimit * fields);
            int upperBound = (int)(UpperMineLimit * fields);

            return rand.Next(lowBound, upperBound);
        }

        private static bool CheckIfMineExists(IList<Mine> list, Mine mine)
        {
            foreach (Mine currentMine in list)
            {
                if (currentMine.X == mine.X && currentMine.Y == mine.Y)
                {
                    return true;
                }
            }

            list.Add(mine);

            return false;
        }

        public static bool ContainsMines(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    // for const
                    if (field[i, j] != EmptyCell && field[i, j] != DetonatedCell)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsInsideField(char[,] field, int x, int y)
        {
            bool rowCondition = x < 0 || x >= field.GetLength(0);
            bool colCondition = y < 0 || y >= field.GetLength(1);

            if (rowCondition || colCondition)
            {
                return false;
            }

            return true;
        }

        public static void DrawField(char[,] field)
        {
            Console.Write("   ");
            int fieldSize = field.GetLength(0);

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
                    Console.Write("{0} ", field[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static Mine ExtractMineFromString(string line)
        {
            bool lineEmpty = (line == null) || (!line.Contains(" "));
            if (lineEmpty)
            {
                Console.WriteLine(Resource1.InvalidIndex);
                return null;
            }

            string[] splited = line.Split(' ');
            int row = 0;
            int col = 0;

            bool isValidRow = int.TryParse(splited[0], out row);
            if (!isValidRow)
            {
                Console.WriteLine(Resource1.InvalidIndex);
                return null;
            }

            bool isValidCol = int.TryParse(splited[1], out col);
            if (!isValidCol)
            {
                Console.WriteLine(Resource1.InvalidIndex);
                return null;
            }

            return new Mine(row, col);
        }
    }
}
