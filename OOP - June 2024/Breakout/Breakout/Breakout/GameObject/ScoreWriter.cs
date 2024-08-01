namespace Breakout.GameObject
{
    public class ScoreWriter
    {
        public ScoreWriter(Wall wall)
        {
            this.wall = wall;
        }

        private Wall wall;
        public int  score { get; set; }

        public void ScoreWrite()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(this.wall.LeftX + 20, 15);
            Console.Write($"Current Score : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(score);
            Console.ResetColor();
        }
    }
}
