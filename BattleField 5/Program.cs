namespace BattleField
{
    public class Program
    {
        public static void Main()
        {
            IEngine game = new Engine();
            game.Start();
        }
    }
}
