 using System;
using System.Collections.Generic;

namespace BattleField
{
    public class GameServices
    {
        // tova e klasa v koito se pravqt magiite
        private static readonly Random rand = new Random();
        private const double LowerMineLimit = 0.15;
        private const double UpperMineLimit = 0.3;
        private const char EmptyCell = '-';
        private const char DetonatedCell = 'X';
        
        public static char[,] GenerateField(int size)
        {
            char[,] field = GenerateEmptyField(size);

            // in a new method
            GenerateMines(size, field);

            return field;
        }

        // extrated method
        private static char[,] GenerateMines(int size, char[,] field)
        {
                List<Mine> mines = new List<Mine>();

                int minesCount = DetermineMineCount(size);

                for (int i = 0; i < minesCount; i++)
                {
                    int mineX = rand.Next(0, size);
                    int mineY = rand.Next(0, size);
                    Mine newMine = new Mine(mineX, mineY);

                    if (GameServices.Contains(mines, newMine))
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

        private static bool Contains(List<Mine> list, Mine mine)
        {
            //renaming
            foreach (Mine mina in list)
            {
                if (mina.X == mine.X && mina.Y == mine.Y)
                {
                    return true;
                }
            }

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

        private static bool VPoletoLiE(char[,] field, int x, int y)
        {
            if (x < 0 || y < 0 || x >= field.GetLength(0) || y >= field.GetLength(1))
            {
                return false;

            }

            return true;
        }

        public static void Explode(char[,] field, Mine mine)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    {
                        ExplodeOne(field, mine);
                    }
                    break;
                case '2':
                    {
                        ExplodeTwo(field, mine);
                    }
                    break;
                case '3':
                    {
                        ExplodeThree(field, mine);
                    }
                    break;
                case '4':
                    {
                        ExplodeFour(field, mine);
                    }
                    break;
                case '5':
                    {
                        ExplodeFive(field, mine);
                    }
                    break;
            }
        }

        private static void ExplodeOne(char[,] field, Mine mine)
        {
            Mine URcorner = new Mine(mine.X - 1, mine.Y - 1);
            Mine ULcorner = new Mine(mine.X - 1, mine.Y + 1);
            Mine DRcorner = new Mine(mine.X + 1, mine.Y - 1);
            Mine DLcorner = new Mine(mine.X + 1, mine.Y + 1);

            if (VPoletoLiE(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, URcorner.X, URcorner.Y))
            {
                field[URcorner.X, URcorner.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, ULcorner.X, ULcorner.Y))
            {
                field[ULcorner.X, ULcorner.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, DRcorner.X, DRcorner.Y))
            {
                field[DRcorner.X, DRcorner.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, DLcorner.X, DLcorner.Y))
            {
                field[DLcorner.X, DLcorner.Y] = DetonatedCell;
            }
        }

        private static void ExplodeTwo(char[,] field, Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X+1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y+1; j++)
                {
                    if(VPoletoLiE(field, i,j))
                    {
                        field[i, j] = DetonatedCell;
                    }
                }
            }
        }

        private static void ExplodeThree(char[,] field, Mine mine)
        {
            ExplodeTwo(field, mine);
            Mine Up = new Mine(mine.X - 2, mine.Y);
            Mine Down = new Mine(mine.X + 2, mine.Y);
            Mine Left = new Mine(mine.X, mine.Y - 2);
            Mine Right = new Mine(mine.X, mine.Y + 2);

            if (VPoletoLiE(field, Up.X, Up.Y))
            {
                field[Up.X, Up.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, Down.X, Down.Y))
            {
                field[Down.X, Down.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, Left.X, Left.Y))
            {
                field[Left.X, Left.Y] = DetonatedCell;
            }

            if (VPoletoLiE(field, Right.X, Right.Y))
            {
                field[Right.X, Right.Y] = DetonatedCell;
            }
        }

        private static void ExplodeFour(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    bool UR = i == mine.X - 2 && j == mine.Y - 2;
                    bool UL = i == mine.X - 2 && j == mine.Y + 2;
                    bool DR = i == mine.X + 2 && j == mine.Y - 2;
                    bool DL = i == mine.X + 2 && j == mine.Y + 2;

                    if (UR) continue;
                    if (UL) continue;
                    if (DR) continue;
                    if (DL) continue;

                    if (VPoletoLiE(field, i, j))
                    {
                        field[i, j] = DetonatedCell;
                    }
                }
            }

        }

        private static void ExplodeFive(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (VPoletoLiE(field, i, j))
                    {
                        field[i, j] = DetonatedCell;
                    }
                }
            }
        }

        public static bool IsValidMove(char[,] field, int x, int y)
        {
            if (!VPoletoLiE(field, x, y))
            {
                return false;
            }
            if (field[x, y] == DetonatedCell || field[x, y] == EmptyCell)
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
                    Console.Write("{0} ", field[row,col]);
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
