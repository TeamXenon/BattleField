namespace BattleField
{
    public class Explosion
    {
        public const char DetonatedCell = 'X';

        public static bool IsInsideField(char[,] field, int x, int y)
        {
            bool isXOutsideOfField = x < 0 || x >= field.GetLength(0);
            bool isYOutsideOfField = y < 0 || y >= field.GetLength(1);

            if (isXOutsideOfField || isYOutsideOfField)
            {
                return false;
            }
            else
            {
                return true;
            }
        }      

        public static void Explode(char[,] field, Mine mine)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    {
                        ExplosionOne(field, mine);
                    }
                    break;
                case '2':
                    {
                        ExplosionTwo(field, mine);
                    }
                    break;
                case '3':
                    {
                        ExplosionThree(field, mine);
                    }
                    break;
                case '4':
                    {
                        ExplosionFour(field, mine);
                    }
                    break;
                case '5':
                    {
                        ExplosionFive(field, mine);
                    }
                    break;
            }
        }

        private static void ExplosionOne(char[,] field, Mine mine)
        {
            if (IsInsideField(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X - 1, mine.Y - 1))
            {
                field[mine.X - 1, mine.Y - 1] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X + 1, mine.Y - 1))
            {
                field[mine.X + 1, mine.Y - 1] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X - 1, mine.Y + 1))
            {
                field[mine.X - 1, mine.Y + 1] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X + 1, mine.Y + 1))
            {
                field[mine.X + 1, mine.Y + 1] = DetonatedCell;
            }
        }

        private static void ExplosionTwo(char[,] field, Mine mine)
        {
            for (int row = mine.X - 1; row <= mine.X + 1; row++)
            {
                for (int col = mine.Y - 1; col <= mine.Y + 1; col++)
                {
                    if (IsInsideField(field, row, col))
                    {
                        field[row, col] = DetonatedCell;
                    }
                }
            }
        }

        private static void ExplosionThree(char[,] field, Mine mine)
        {
            ExplosionTwo(field, mine);

            if (IsInsideField(field, mine.X, mine.Y - 2))
            {
                field[mine.X, mine.Y - 2] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X + 2, mine.Y))
            {
                field[mine.X + 2, mine.Y] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X, mine.Y + 2))
            {
                field[mine.X, mine.Y + 2] = DetonatedCell;
            }

            if (IsInsideField(field, mine.X - 2, mine.Y))
            {
                field[mine.X - 2, mine.Y] = DetonatedCell;
            }
        }

        private static void ExplosionFour(char[,] field, Mine mine)
        {
            for (int row = mine.X - 2; row <= mine.X + 2; row++)
            {
                for (int col = mine.Y - 2; col <= mine.Y + 2; col++)
                {
                    bool isInUpperLeftCorner = row == mine.X - 2 && col == mine.Y - 2;
                    bool isInBottomLeftCorner = row == mine.X - 2 && col == mine.Y + 2;
                    bool isInUpperRightCorner = row == mine.X + 2 && col == mine.Y - 2;
                    bool isInBottomRightCorner = row == mine.X + 2 && col == mine.Y + 2;

                    if (isInUpperLeftCorner || isInBottomLeftCorner || isInUpperRightCorner || isInBottomRightCorner)
                    {
                        continue;
                    }

                    if (IsInsideField(field, row, col))
                    {
                        field[row, col] = DetonatedCell;
                    }
                }
            }

        }

        private static void ExplosionFive(char[,] field, Mine mine)
        {
            for (int row = mine.X - 2; row <= mine.X + 2; row++)
            {
                for (int col = mine.Y - 2; col <= mine.Y + 2; col++)
                {
                    if (IsInsideField(field, row, col))
                    {
                        field[row, col] = DetonatedCell;
                    }
                }
            }
        }
    }
}
