 namespace Breakout.GameObject
{
    public class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int SpeedX { get; private set; }
        public int SpeedY { get; private set; }
        private int leftX { get; set; }
        private int rightX { get; set; }
        private int topY { get; set; }
        private int downY { get; set; }

        private Board board;
        private Box box;
        public Ball(int startX, int startY, int speedX, int speedY, Wall wall, Board board, Box box)
        {
            X = startX;
            Y = startY;
            SpeedX = speedX;
            SpeedY = speedY;
            leftX = 0;
            rightX = wall.LeftX - 1;
            topY = 0;
            downY = wall.TopY - 1;
            this.board = board;
            this.box = box;
        }

        public void Move()
        {
            Point oldBallPosition = new Point(X, Y);
           Clear();

            X += SpeedX;
            Y += SpeedY;
            Point ballPosition = new Point(X, Y);

            if (X == leftX + 1)
            {
                SpeedX = 1;
            }
            if (X == rightX - 1)
            {
                SpeedX = -1;
            }

            if (Y == topY + 1)
            {
                SpeedY = 1;
            }

            if (Y == downY - 1)
            {
                throw new ArgumentException();
            }
            Draw();

            foreach (Point boardPoint in board.boardPosition)
            {
                if (ballPosition.TopY == boardPoint.TopY-1 && ballPosition.LeftX == boardPoint.LeftX)
                {
                    SpeedY = -SpeedY;
                }
            }

            foreach (Point boxPosition in box.boxField)
            {
                if (ballPosition.TopY == boxPosition.TopY && ballPosition.LeftX == boxPosition.LeftX)
                {
                    SpeedY = -SpeedY;
                    box.RemoveBox(boxPosition);
                    return;
                }
            }
        }

        public bool IsPointOfBall(Point point)
        {
            return this.Y == point.TopY && this.X == point.LeftX;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(X, Y);
            Console.Write('\u25A0');
            Console.ResetColor();
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.ResetColor();
        }
    }
}