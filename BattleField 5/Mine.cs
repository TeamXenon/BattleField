using System;

namespace BattleField
{
    public class Mine
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (Engine.MinSize <= value && value <= Engine.MaxSize)
                {
                    this.x = value;
                }
                else
                {
                    throw new InvalidMineCoordinatesException("Invalid coordinates!", Engine.MinSize, Engine.MaxSize);
                }
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (Engine.MinSize <= value && value <= Engine.MaxSize)
                {
                    this.y = value;
                }
                else
                {
                    throw new InvalidMineCoordinatesException("Invalid coordinates!", Engine.MinSize, Engine.MaxSize);
                }
            }
        }

        public Mine(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

