namespace Breakout.GameObject
{
    public class Board : Point
    {
        public List<Point> boardPosition = new();
        private const char boardSymbol = '\u2588';
        private Wall wall;

        public Board(int leftX, int topY, Wall wall)
            : base(leftX, topY)
        {
            this.wall = wall;
            Point point = new Point(wall.LeftX / 2 - 5, wall.TopY - 5);
            for (int i = 0; i < 10; i++)
            {
                boardPosition.Add(point);
                point = new Point(point.LeftX + 1, point.TopY);
            }
            foreach (Point p in boardPosition)
            {
                this.Draw(p.LeftX, p.TopY, boardSymbol);
            }
        }

        public bool IsPointOfBoard(Point point)
        {
            foreach (Point boardPoint in boardPosition) if (boardPoint.TopY == point.TopY && boardPoint.LeftX == point.LeftX) return true;

            return false;

        }

        public void MoveBoard(Point direction)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Point firstPoint = new Point
                (boardPosition.First().LeftX + direction.LeftX, boardPosition.First().TopY + direction.TopY);
            Point lastPoint = new Point
                (boardPosition.Last().LeftX + direction.LeftX, boardPosition.Last().TopY + direction.TopY);
            if (wall.IsPointOfWall(firstPoint) || wall.IsPointOfWall(lastPoint)) return;

            List<Point> newBoardPosition = new();
            foreach (Point p in boardPosition)
            {
                newBoardPosition.Add(new Point(p.LeftX + direction.LeftX, p.TopY + direction.TopY));
                this.Draw(p.LeftX + direction.LeftX, p.TopY + direction.TopY, boardSymbol);
            }
            boardPosition = newBoardPosition;

        }
    }
}
