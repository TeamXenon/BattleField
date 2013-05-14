using System;
using System.Collections.Generic;

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
                if (value >= Engine.MinSize || value < Engine.MaxSize)
                {
                    this.x = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Coordinates must be between 0 and 10!");
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
                if (value >= Engine.MinSize || value < Engine.MaxSize)
                {
                    this.y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Coordinates must be between 0 and 10!");
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

