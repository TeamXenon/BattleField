 using System;
using System.Collections.Generic;

namespace BattleField
{
    public class GameServices
    {
        public const char EmptyCell = '-';
        public const char DetonatedCell = 'X';          

        public static bool IsValidMove(char[,] field, int x, int y)
        {
            if (!Explosion.IsInsideField(field, x, y))
            {
                return false;
            }
            if (field[x, y] == DetonatedCell || field[x, y] == EmptyCell)
            {
                return false;
            }

            return true;
        }

        public static Mine ExtractMineFromString(string line)
        {
            bool lineEmpty = (line == null) || (!line.Contains(" "));
            if (lineEmpty)
            {
                Console.WriteLine(GameMessage.InvalidIndex);
                return null;
            }

            string[] splited = line.Split(' ');
            int row = 0;
            int col = 0;

            bool isValidRow = int.TryParse(splited[0], out row);
            if (!isValidRow)
            {
                Console.WriteLine(GameMessage.InvalidIndex);
                return null;
            }

            bool isValidCol = int.TryParse(splited[1], out col);
            if (!isValidCol)
            {
                Console.WriteLine(GameMessage.InvalidIndex);
                return null;
            }

            return new Mine(row, col);
        }
    }
}
