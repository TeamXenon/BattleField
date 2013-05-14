namespace BattleField
{
    using System;

    class InvalidMineCoordinatesException : ApplicationException
    {
        private int MinCoordinate { get; set; }
        private int MaxCoordinate { get; set; }

        public InvalidMineCoordinatesException(string msg)
            : base(msg)
        {
        }

        public InvalidMineCoordinatesException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public InvalidMineCoordinatesException(string msg, int minCoordinate, int maxCoordinate)
            : this(msg)
        {
            this.MinCoordinate = minCoordinate;
            this.MaxCoordinate = maxCoordinate;
        }

        public override string Message
        {
            get
            {
                string result = string.Format("{0}: Coordinates must be between {1} and {2}!", base.Message, this.MinCoordinate, this.MaxCoordinate);
                return result;
            }
        }
    }
}
