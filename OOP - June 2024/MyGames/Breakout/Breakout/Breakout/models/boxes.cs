using Breakout.methods;

namespace Breakout.models
{
    public class boxes
    {
        public List<(int, int)> boxPosition { get; set; }
        private char boxSymbol = '\u25A0';
        public boxes(Wall wall)
        {
            boxPosition = new();
            drawing drawing = new();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 1; i < wall.wallRow ; i++)
            {
                for (int j = 2; j < 4; j++)
                {
                    drawing.drawPoint(i,j,boxSymbol);
                    boxPosition.Add((i,j));
                }
                
            }
            Console.ResetColor();
        }
    }
}
