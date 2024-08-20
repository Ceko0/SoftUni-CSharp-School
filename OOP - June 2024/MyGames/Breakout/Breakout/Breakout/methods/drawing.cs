namespace Breakout.methods
{
    public class drawing
    {
        public void drawPoint(int row, int col, char symbol)
        {
            Console.SetCursorPosition(row, col);
            Console.Write(symbol);
        }
    }
}
