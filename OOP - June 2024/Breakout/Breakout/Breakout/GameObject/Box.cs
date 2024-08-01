namespace Breakout.GameObject
{
    public class Box : Point
    {
        private readonly Wall wall;
        private readonly char foodSymbol;
        private const char BoxSymbol = '\u25A0';
        public int LeftX;
        public int startingRow;
        public int numberOfColl;
        public List<Point> boxField = new();
        ScoreWriter scoreWriter;
        public Box( int startingRow, int numberOfColl,Wall wall):
            base(startingRow, numberOfColl)
        {
            LeftX = wall.LeftX;
            this.wall = wall;
            this.startingRow = startingRow;
            this.numberOfColl = numberOfColl;
            DrawBoxField(this.startingRow, this.numberOfColl);
            scoreWriter = new(wall);
        }
        public void DrawBoxField(int startingRow , int numberOfColl)
        {
            for (int i = 1; i <= numberOfColl; i++)
            {
                for (int leftX = 1; leftX < LeftX - 1; leftX++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(leftX, startingRow);
                    Console.Write(BoxSymbol);
                    Console.ResetColor();
                    boxField.Add(new Point(leftX, i));
                }
                startingRow++;
            }
        }
        public bool IsPointOfBox(Point point)
        {
            foreach (Point boxPoint in boxField) if(boxPoint.TopY == point.TopY && boxPoint.LeftX == point.LeftX) return true;
            
            return false;
        }
        public void RemoveBox(Point boxPosition)
        {
            int index = boxField.IndexOf(boxPosition);
            boxField.RemoveAt(index);
            Console.SetCursorPosition(boxPosition.LeftX, boxPosition.TopY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
            scoreWriter.score++;
            scoreWriter.ScoreWrite();
        }
    }
}
