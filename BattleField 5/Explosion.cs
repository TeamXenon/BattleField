namespace BattleField
{
    public class Explosion
    {
        public const char DetonatedCell = 'X';

        internal static bool IsInsideField(char[,] field, int x, int y)
        {
            bool rowCondition = x < 0 || x >= field.GetLength(0);
            bool colCondition = y < 0 || y >= field.GetLength(1);

            if (rowCondition || colCondition)
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

            if (IsInsideField(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = DetonatedCell;
            }

            if (IsInsideField(field, URcorner.X, URcorner.Y))
            {
                field[URcorner.X, URcorner.Y] = DetonatedCell;
            }

            if (IsInsideField(field, ULcorner.X, ULcorner.Y))
            {
                field[ULcorner.X, ULcorner.Y] = DetonatedCell;
            }

            if (IsInsideField(field, DRcorner.X, DRcorner.Y))
            {
                field[DRcorner.X, DRcorner.Y] = DetonatedCell;
            }

            if (IsInsideField(field, DLcorner.X, DLcorner.Y))
            {
                field[DLcorner.X, DLcorner.Y] = DetonatedCell;
            }
        }

        private static void ExplodeTwo(char[,] field, Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X + 1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y + 1; j++)
                {
                    if (IsInsideField(field, i, j))
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

            if (IsInsideField(field, Up.X, Up.Y))
            {
                field[Up.X, Up.Y] = DetonatedCell;
            }

            if (IsInsideField(field, Down.X, Down.Y))
            {
                field[Down.X, Down.Y] = DetonatedCell;
            }

            if (IsInsideField(field, Left.X, Left.Y))
            {
                field[Left.X, Left.Y] = DetonatedCell;
            }

            if (IsInsideField(field, Right.X, Right.Y))
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

                    if (IsInsideField(field, i, j))
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
                    if (IsInsideField(field, i, j))
                    {
                        field[i, j] = DetonatedCell;
                    }
                }
            }
        }
    }
}
