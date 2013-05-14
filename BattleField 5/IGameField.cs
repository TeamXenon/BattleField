namespace BattleField
{
    public interface IGameField
    {
        /// <summary>
        /// Two dimensional char array representing the game field.
        /// </summary>
        char[,] Field { get; set; }

        /// <summary>
        /// Integer value representing the size of the game field.
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Generates the Battle Field and places mines on random coordinates.
        /// </summary>
        void GenerateField();

        /// <summary>
        /// Check to see if any mines are present on the Battle Field.
        /// </summary>
        /// <returns>
        /// <value>True</value>: if there are any mines on the Battle Field. 
        /// <value>False</value>: if the Battle Field is empty.
        /// </returns>
        bool ContainsMines();

        /// <summary>
        /// Prints the Battle Field to the Console.
        /// </summary>
        void DrawField();
    }
}